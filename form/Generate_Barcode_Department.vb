Public Class Generate_Barcode_Department
    Dim orderID, salePersonID As Integer

    Sub New(ByVal orderID As Integer, ByVal salePersonID As Integer)
        InitializeComponent()
        Me.salePersonID = salePersonID
        Me.orderID = orderID
        cb_department.SelectedIndex = 0
        bgw_generateBarcode.RunWorkerAsync()
    End Sub

    Private Sub btn_print_Click(sender As Object, e As EventArgs) Handles btn_print.Click
        ' insert data into database
        Dim barcode128 As Zen.Barcode.Code128BarcodeDraw = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum

        If Not ListView1.Items.Count = 0 Then
            Dim barcode(ListView1.Items.Count) As Image
            Dim keyDic As New Dictionary(Of String, Object)
            Dim packageDic As New Dictionary(Of String, Object)

            Database.Delete(_TABLE.PACKAGE, {_PACKAGE.ORDER_ID, "=", Me.orderID})
            For index As Integer = 0 To ListView1.Items.Count - 1
                packageDic.Clear()
                keyDic.Clear()
                packageDic.Add(_PACKAGE.ORDER_ID, Me.orderID)
                keyDic.Add(_JSON_FIELD.PACKAGE_NAME, ListView1.Items(index).SubItems(0).Text)
                keyDic.Add(_JSON_FIELD.NUMBER_OF_BAGS, ListView1.Items(index).SubItems(2).Text)
                packageDic.Add(_PACKAGE.PACKAGE_KEY, Newtonsoft.Json.JsonConvert.SerializeObject(keyDic))

                If ListView1.Items(index).SubItems(1).Text = _DEPARTMENT_BARCODE.SHOW_E Then
                    packageDic.Add(_PACKAGE.DEPT, _DEPARTMENT_BARCODE.TO_EMBROIDERY)
                    barcode(index) = barcode128.Draw(salePersonID.ToString + "-" + orderID.ToString + "-" + _DEPARTMENT_BARCODE.TO_EMBROIDERY, 60, 2)
                ElseIf ListView1.Items(index).SubItems(1).Text = _DEPARTMENT_BARCODE.SHOW_P Then
                    packageDic.Add(_PACKAGE.DEPT, _DEPARTMENT_BARCODE.TO_PRINTING)
                    barcode(index) = barcode128.Draw(salePersonID.ToString + "-" + orderID.ToString + "-" + _DEPARTMENT_BARCODE.TO_PRINTING, 60, 2)
                ElseIf ListView1.Items(index).SubItems(1).Text = _DEPARTMENT_BARCODE.SHOW_S Then
                    packageDic.Add(_PACKAGE.DEPT, _DEPARTMENT_BARCODE.TO_SEWING)
                    barcode(index) = barcode128.Draw(salePersonID.ToString + "-" + orderID.ToString + "-" + _DEPARTMENT_BARCODE.TO_SEWING, 60, 2)
                ElseIf ListView1.Items(index).SubItems(1).Text = _DEPARTMENT_BARCODE.SHOW_Z Then
                    packageDic.Add(_PACKAGE.DEPT, _DEPARTMENT_BARCODE.TO_PRINT_EMBROIDERY)
                    barcode(index) = barcode128.Draw(salePersonID.ToString + "-" + orderID.ToString + "-" + _DEPARTMENT_BARCODE.TO_PRINT_EMBROIDERY, 60, 2)
                End If

                Database.Insert(_TABLE.PACKAGE, packageDic)
            Next
                MessageBox.Show("Package recorded")
        End If
    End Sub

    Private Sub bgw_generateBarcode_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgw_generateBarcode.DoWork
        e.Result = Database.SelectRows(_TABLE.PACKAGE, {_PACKAGE.ORDER_ID, "=", Me.orderID})
    End Sub

    Private Sub bgw_generateBarcode_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw_generateBarcode.RunWorkerCompleted
        If (e.Error Is Nothing) Then
            Dim packageList As List(Of Dictionary(Of String, Object))
            packageList = e.Result

            If packageList IsNot Nothing Then
                Dim packagekeyparts As New Dictionary(Of String, Object)
                Dim tempdept As String = ""
                For Each packageDic In packageList
                    packagekeyparts = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(packageDic.Item(_PACKAGE.PACKAGE_KEY))
                    If packageDic.Item(_PACKAGE.DEPT) = "E" Then
                        tempdept = _DEPARTMENT_BARCODE.SHOW_E
                    ElseIf packageDic.Item(_PACKAGE.DEPT) = "P" Then
                        tempdept = _DEPARTMENT_BARCODE.SHOW_P
                    ElseIf packageDic.Item(_PACKAGE.DEPT) = "S" Then
                        tempdept = _DEPARTMENT_BARCODE.SHOW_S
                    ElseIf packageDic.Item(_PACKAGE.DEPT) = "Z" Then
                        tempdept = _DEPARTMENT_BARCODE.SHOW_Z
                    End If
                    ListView1.Items.Add(New ListViewItem({packagekeyparts.Item(_JSON_FIELD.PACKAGE_NAME), tempdept, packagekeyparts.Item(_JSON_FIELD.NUMBER_OF_BAGS)}))
                Next
            End If
        End If
        If ListView1.Items.Count > 0 Then
            btn_delete.Enabled = True
        End If
    End Sub

    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        If txt_packageName.Text = String.Empty Or num_bag.Value = 0 Then
            MessageBox.Show("Please fill the package name", "Error")
        Else
            Dim tempListView As ListViewItem
            tempListView = ListView1.Items.Add(txt_packageName.Text)
            tempListView.SubItems.Add(cb_department.SelectedItem)
            tempListView.SubItems.Add(num_bag.Value)
            btn_delete.Enabled = True
            txt_packageName.Clear()
            num_bag.Value = 1
        End If
    End Sub

    Private Sub btn_delete_Click(sender As Object, e As EventArgs) Handles btn_delete.Click
        If ListView1.SelectedItems.Count > 0 Then
            ListView1.Items.RemoveAt(ListView1.SelectedIndices(0))
        End If
    End Sub
End Class