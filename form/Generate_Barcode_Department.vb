Imports System.Text

Public Class Generate_Barcode_Department
    Private fontSizeNormal As Integer = 7                     ' normal font size (text below barcode)
    Private fontFamily As String = "IDAutomationHC39M Free Version"

    Private stickerCount As Integer = 0
    Private stickerToPrint As Integer = 0

    Private orderID As String

    Private barcodeValues As New Dictionary(Of String, Object)
    Private barcodeCount As New Dictionary(Of String, Integer)

    Private curBarcodeIndex As Integer = 0
    Private curPrintStickerCount As Integer = 0

    Private loadingOverlay As Loading_Overlay

    Sub New(ByVal orderIDFull As String)
        InitializeComponent()

        pd_barcode.DefaultPageSettings.PaperSize = New Printing.PaperSize("Barcode Sticker", 132, 94)
        ppd_barcode.Document = pd_barcode

        Me.orderID = orderIDFull
        cb_department.SelectedIndex = 0

        ' check and load existing records
        bgw_loadBarcode.RunWorkerAsync()
        ShowLoadingOverlay(True)
    End Sub

    ' generate document to print
    Private Sub PrintBarcode(ByVal sender As Object, ByVal e As Printing.PrintPageEventArgs) Handles pd_barcode.PrintPage

        ' text format
        Dim formatCenter As New StringFormat()
        formatCenter.Alignment = StringAlignment.Center

        If barcodeValues.ContainsKey(_PACKAGE.DEPT & curBarcodeIndex) Then
            Dim barcodeString As String = "*" & orderID & _FORMAT.ORDER_DELIMITER & barcodeValues(_PACKAGE.DEPT & curBarcodeIndex) & "*"

            ' barcode
            Dim textLocation As Integer = ((pd_barcode.DefaultPageSettings.PaperSize.Height() - fontSizeNormal) / 2) - 14
            e.Graphics.DrawString(barcodeString, New Font(fontFamily, fontSizeNormal), New SolidBrush(Color.Black), (pd_barcode.DefaultPageSettings.PaperSize.Width() / 2) + 1, textLocation, formatCenter)

            If curPrintStickerCount < barcodeCount.Item(_PACKAGE.DEPT & curBarcodeIndex) - 1 Then
                curPrintStickerCount += 1
            Else
                curPrintStickerCount = 0
                curBarcodeIndex += 1
            End If

        End If
        stickerCount += 1

        ' create new page
        e.HasMorePages = (stickerCount < stickerToPrint)
    End Sub

    Private Sub btn_print_Click(sender As Object, e As EventArgs) Handles btn_print.Click
        PrintAndSave()
    End Sub

    Private Sub btn_printer_Click(sender As Object, e As EventArgs) Handles btn_printer.Click
        pdg_settings.AllowPrintToFile = False

        If pdg_settings.ShowDialog = DialogResult.OK Then
            pd_barcode.PrinterSettings = pdg_settings.PrinterSettings
            PrintAndSave()
        End If
    End Sub

    Private Sub btn_preview_Click(sender As Object, e As EventArgs) Handles btn_preview.Click
        stickerCount = 0
        curPrintStickerCount = 0
        curBarcodeIndex = 0

        ppd_barcode.ShowDialog()
    End Sub

    Private Sub PrintAndSave()
        curPrintStickerCount = 0
        curBarcodeIndex = 0

        ' get all item from listview
        If ListView1.Items.Count > 0 Then
            ' print
            pd_barcode.Print()

            ' save
            bgw_generateBarcode.RunWorkerAsync()
            ShowLoadingOverlay(True)
        End If
    End Sub

    ' add barcode
    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        If txt_packageName.Text = String.Empty Then
            MessageBox.Show("Please fill the package name", "Error")
        Else
            Dim keyDic As New Dictionary(Of String, Object)

            ' key field
            keyDic.Add(_JSON_FIELD.PACKAGE_NAME, txt_packageName.Text)
            keyDic.Add(_JSON_FIELD.NUMBER_OF_BAGS, num_bag.Value)

            ' order field
            barcodeValues.Add(_PACKAGE.PACKAGE_KEY & barcodeCount.Count, Newtonsoft.Json.JsonConvert.SerializeObject(keyDic))


            If cb_department.SelectedItem = _DEPARTMENT_BARCODE.SHOW_E Then
                barcodeValues.Add(_PACKAGE.DEPT & barcodeCount.Count, _DEPARTMENT_BARCODE.TO_EMBROIDERY)
            ElseIf cb_department.SelectedItem = _DEPARTMENT_BARCODE.SHOW_P Then
                barcodeValues.Add(_PACKAGE.DEPT & barcodeCount.Count, _DEPARTMENT_BARCODE.TO_PRINTING)
            ElseIf cb_department.SelectedItem = _DEPARTMENT_BARCODE.SHOW_S Then
                barcodeValues.Add(_PACKAGE.DEPT & barcodeCount.Count, _DEPARTMENT_BARCODE.TO_SEWING)
            ElseIf cb_department.SelectedItem = _DEPARTMENT_BARCODE.SHOW_Z Then
                barcodeValues.Add(_PACKAGE.DEPT & barcodeCount.Count, _DEPARTMENT_BARCODE.TO_PRINT_EMBROIDERY)
            End If

            barcodeCount.Add(_PACKAGE.DEPT & barcodeCount.Count, num_bag.Value)


            Dim tempListView As ListViewItem
            tempListView = ListView1.Items.Add(txt_packageName.Text)
            tempListView.SubItems.Add(cb_department.SelectedItem)
            tempListView.SubItems.Add(num_bag.Value)
            btn_delete.Enabled = True
            txt_packageName.Clear()
            stickerToPrint += num_bag.Value
            num_bag.Value = 1
        End If
    End Sub

    ' delete barcode
    Private Sub btn_delete_Click(sender As Object, e As EventArgs) Handles btn_delete.Click
        If ListView1.SelectedItems.Count > 0 Then
            stickerToPrint = 0
            barcodeValues.Clear()
            barcodeCount.Clear()

            ListView1.Items.RemoveAt(ListView1.SelectedIndices(0))

            For Each item As ListViewItem In ListView1.Items
                Dim keyDic As New Dictionary(Of String, Object)

                ' key field
                keyDic.Add(_JSON_FIELD.PACKAGE_NAME, item.SubItems(0).Text)
                keyDic.Add(_JSON_FIELD.NUMBER_OF_BAGS, item.SubItems(2).Text)

                ' order field
                barcodeValues.Add(_PACKAGE.PACKAGE_KEY & barcodeCount.Count, Newtonsoft.Json.JsonConvert.SerializeObject(keyDic))

                If item.SubItems(1).Text = _DEPARTMENT_BARCODE.SHOW_E Then
                    barcodeValues.Add(_PACKAGE.DEPT & barcodeCount.Count, _DEPARTMENT_BARCODE.TO_EMBROIDERY)
                ElseIf item.SubItems(1).Text = _DEPARTMENT_BARCODE.SHOW_P Then
                    barcodeValues.Add(_PACKAGE.DEPT & barcodeCount.Count, _DEPARTMENT_BARCODE.TO_PRINTING)
                ElseIf item.SubItems(1).Text = _DEPARTMENT_BARCODE.SHOW_S Then
                    barcodeValues.Add(_PACKAGE.DEPT & barcodeCount.Count, _DEPARTMENT_BARCODE.TO_SEWING)
                ElseIf item.SubItems(1).Text = _DEPARTMENT_BARCODE.SHOW_Z Then
                    barcodeValues.Add(_PACKAGE.DEPT & barcodeCount.Count, _DEPARTMENT_BARCODE.TO_PRINT_EMBROIDERY)
                End If

                stickerToPrint += item.SubItems(2).Text
                barcodeCount.Add(_PACKAGE.DEPT & barcodeCount.Count, item.SubItems(2).Text)
            Next
        End If
    End Sub

    ' load existing barcode
    Private Sub bgw_loadBarcode_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgw_loadBarcode.DoWork
        e.Result = Database.SelectRows(_TABLE.PACKAGE, {_PACKAGE.ORDER_ID, "=", Method.GetOrderID(orderID)})
    End Sub

    ' load barcode result
    Private Sub bgw_loadBarcode_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw_loadBarcode.RunWorkerCompleted
        ShowLoadingOverlay(False)

        If (e.Error Is Nothing) Then
            Dim packageList As List(Of Dictionary(Of String, Object))
            packageList = e.Result

            If packageList IsNot Nothing Then
                Dim packagekeyparts As New Dictionary(Of String, Object)
                Dim tempdept As String = ""
                Dim index As Integer = 0

                For Each packageDic In packageList
                    packagekeyparts = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(packageDic.Item(_PACKAGE.PACKAGE_KEY))
                    If packageDic.Item(_PACKAGE.DEPT) = "E" Then
                        tempdept = _DEPARTMENT_BARCODE.SHOW_E
                        barcodeValues.Add(_PACKAGE.DEPT & index, _DEPARTMENT_BARCODE.TO_EMBROIDERY)
                    ElseIf packageDic.Item(_PACKAGE.DEPT) = "P" Then
                        tempdept = _DEPARTMENT_BARCODE.SHOW_P
                        barcodeValues.Add(_PACKAGE.DEPT & index, _DEPARTMENT_BARCODE.TO_PRINTING)
                    ElseIf packageDic.Item(_PACKAGE.DEPT) = "S" Then
                        tempdept = _DEPARTMENT_BARCODE.SHOW_S
                        barcodeValues.Add(_PACKAGE.DEPT & index, _DEPARTMENT_BARCODE.TO_SEWING)
                    ElseIf packageDic.Item(_PACKAGE.DEPT) = "Z" Then
                        tempdept = _DEPARTMENT_BARCODE.SHOW_Z
                        barcodeValues.Add(_PACKAGE.DEPT & index, _DEPARTMENT_BARCODE.TO_PRINT_EMBROIDERY)
                    End If

                    barcodeCount.Add(_PACKAGE.DEPT & index, packagekeyparts.Item(_JSON_FIELD.NUMBER_OF_BAGS))
                    barcodeValues.Add(_PACKAGE.PACKAGE_KEY & index, packageDic.Item(_PACKAGE.PACKAGE_KEY))

                    index += 1

                    stickerToPrint += packagekeyparts.Item(_JSON_FIELD.NUMBER_OF_BAGS)
                    ListView1.Items.Add(New ListViewItem({packagekeyparts.Item(_JSON_FIELD.PACKAGE_NAME), tempdept, packagekeyparts.Item(_JSON_FIELD.NUMBER_OF_BAGS)}))
                Next
            End If
        End If

        If ListView1.Items.Count > 0 Then
            btn_delete.Enabled = True
        End If
    End Sub

    ' insert and delete existing barcode
    Private Sub bgw_generateBarcode_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgw_generateBarcode.DoWork
        Dim sqlStmt As New StringBuilder("BEGIN; DELETE FROM ")
        Dim addComma As Boolean = False
        Dim orderIDtoInsert As Integer = Method.GetOrderID(orderID)

        With sqlStmt
            .Append(_TABLE.PACKAGE).Append(" WHERE ").Append(_PACKAGE.ORDER_ID).Append(" = ").Append(Method.GetOrderID(orderID))
            .Append("; INSERT INTO ").Append(_TABLE.PACKAGE).Append(" (").Append(_PACKAGE.ORDER_ID).Append(", ")
            .Append(_PACKAGE.PACKAGE_KEY).Append(", ")
            .Append(_PACKAGE.DEPT).Append(") VALUES ")


            For row As Integer = 0 To (barcodeValues.Count / 2) - 1
                If addComma Then
                    .Append(", ")
                End If

                .Append(" (").Append(orderIDtoInsert)
                .Append(", @").Append(_PACKAGE.PACKAGE_KEY).Append(row)
                .Append(", @").Append(_PACKAGE.DEPT).Append(row)
                .Append(")")

                addComma = True
            Next

            .Append("; COMMIT;")
        End With

        e.Result = Database.ExecuteNonQuery(sqlStmt.ToString(), barcodeValues) <> -1
    End Sub

    ' insert/delete barcode result
    Private Sub bgw_generateBarcode_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw_generateBarcode.RunWorkerCompleted
        ShowLoadingOverlay(False)
    End Sub

    Private Sub ShowLoadingOverlay(ByVal show As Boolean)
        If show Then
            loadingOverlay = New Loading_Overlay
            loadingOverlay.Size = New Size(Me.Width - 16, Me.Height - 38)
            loadingOverlay.ShowDialog()
        Else
            loadingOverlay.Close()
        End If
    End Sub

    ' reset sticker count before printing
    Private Sub pd_barcode_BeginPrint(ByVal sender As Object, ByVal e As Printing.PrintEventArgs) Handles pd_barcode.BeginPrint
        stickerCount = 0
        curPrintStickerCount = 0
        curBarcodeIndex = 0
    End Sub
End Class