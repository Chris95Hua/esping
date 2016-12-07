Imports System.Text

Public Class Order_Details
    Private loadingOverlay As Loading_Overlay
    Private orderID, salePersonID As Integer
    Private orderIDFull As String
    Public status As Integer
    Public updateDateTime As DateTime
    Private artworkImg1, artworkImg2, artworkImg3, artworkImg4, artworkImg5, artworkImg6 As String
    Private paymentImg As String
    Private fromSearch As Boolean = False

    ' Order ID and status
    Sub New(ByVal orderID As Integer, ByVal status As Integer, Optional orderIDFull As String = Nothing)
        ' This call is required by the designer.
        InitializeComponent()

        Me.orderID = orderID
        Me.status = status
        Me.orderIDFull = orderIDFull

        'set listview's column width
        With ListView1
            .Columns(0).Width = CInt(.Width * 0.4)
            .Columns(1).Width = CInt(.Width * 0.2)
            .Columns(2).Width = CInt(.Width * 0.4)
        End With
    End Sub

    ' Full order detail
    Sub New(ByVal orderID As Integer, ByVal orderDetail As Dictionary(Of String, Object), ByVal status As Integer, Optional orderIDFull As String = Nothing)
        ' This call is required by the designer.
        InitializeComponent()

        Me.orderID = orderID
        Me.status = status
        Me.orderIDFull = orderIDFull
        fromSearch = True

        PopulateDetails(orderDetail)
    End Sub

    ' Setup form
    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        If Not fromSearch Then
            bgw_DetailsLoader.RunWorkerAsync(orderID)
            ShowLoadingOverlay(True)
        End If

        Dim paymentVisibility() As Integer = {_PROCESS.APPROVAL, _PROCESS.ORDER}
        Dim checkInOut() As Integer = {_PROCESS.CUTTING, _PROCESS.EMBROIDERY, _PROCESS.PRINTING, _PROCESS.SEWING}
        Dim barcode() As Integer = {_PROCESS.ORDER, _PROCESS.INVENTORY, _PROCESS.CUTTING, _PROCESS.SEWING}

        ' payment details are only visible to admin/during approval
        If paymentVisibility.Contains(Session.department_id) Then
            GroupBox7.Visible = True
        End If

        ' approval
        If Session.department_id = _PROCESS.APPROVAL And status = 0 Then
            btn_multi.Text = "Approve"
            btn_multi.Show()
        End If

        ' check in/out
        If checkInOut.Contains(Session.department_id) And status = 0 Then
            btn_multi.Text = "Check in"
            btn_multi.Show()
        ElseIf checkInOut.Contains(Session.department_id) And status = 1 Then
            btn_multi.Text = "Check out"
            btn_multi.Show()
        End If

        ' barcode generation
        If barcode.Contains(Session.department_id) Then
            btn_barcode.Show()
        End If
    End Sub

    ' Load order detail
    Private Sub bgw_OrderLoader_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgw_DetailsLoader.DoWork
        Dim sqlStmt As String = String.Concat("SELECT ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ORDER_NAME, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.SALESPERSON_ID, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.CUSTOMER, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.FABRIC, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.COLLAR, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.CUFF, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.FRONT, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.FRONT_DEPT, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.BACK, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.BACK_DEPT, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ARTWORK, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.SIZE, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.MATERIAL, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.COLOUR, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.PACKAGING, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ISSUE_DATE, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.DELIVERY_DATE, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.DELIVERY_TYPE, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.PAYMENT, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.PAYMENT_DOC, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.AMOUNT, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.REMARKS, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.PRODUCTION_PARTS, ", ",
                                               _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.INVENTORY_ORDER,
                                              " FROM ", _TABLE.ORDER_CUSTOMER,
                                              " WHERE ", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ORDER_ID, " = ", "@", _ORDER_CUSTOMER.ORDER_ID
                                        )

        Dim orderID As New Dictionary(Of String, Object)
        orderID.Add(_ORDER_CUSTOMER.ORDER_ID, e.Argument)

        e.Result = Database.ExecuteReader(sqlStmt, orderID).First
    End Sub

    ' Return result
    Private Sub bgw_OrderLoader_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw_DetailsLoader.RunWorkerCompleted
        ShowLoadingOverlay(False)

        If (e.Error Is Nothing) Then
            PopulateDetails(e.Result)
        End If
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

    ' Populate detail
    Private Sub PopulateDetails(ByVal details As Dictionary(Of String, Object))
        ' order name
        If details.ContainsKey(_ORDER_CUSTOMER.ORDER_NAME) Then
            txt_orderName.Text = details.Item(_ORDER_CUSTOMER.ORDER_NAME)
        End If

        If details.ContainsKey(_ORDER_CUSTOMER.SALESPERSON_ID) Then
            salePersonID = details.Item(_ORDER_CUSTOMER.SALESPERSON_ID)
        End If

        ' customer
        If details.ContainsKey(_ORDER_CUSTOMER.CUSTOMER) Then
            txt_cusName.Text = details.Item(_ORDER_CUSTOMER.CUSTOMER)
        End If

        ' fabric
        If details.ContainsKey(_ORDER_CUSTOMER.FABRIC) Then
            Dim type As New Dictionary(Of String, Integer)
            type = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, Integer))(details.Item(_ORDER_CUSTOMER.FABRIC))

            If type.ContainsKey(_JSON_FIELD.FABRIC) Then
                cb_fabricCL.CheckState = CheckState.Checked
            End If

            If type.ContainsKey(_JSON_FIELD.SPLIT) Then
                cb_split.CheckState = CheckState.Checked
            End If
        End If

        ' collar
        If details.ContainsKey(_ORDER_CUSTOMER.COLLAR) Then
            txt_collar.Text = details.Item(_ORDER_CUSTOMER.COLLAR)
        End If

        ' cuff
        If details.ContainsKey(_ORDER_CUSTOMER.CUFF) Then
            txt_cuff.Text = details.Item(_ORDER_CUSTOMER.CUFF)
        End If

        ' front
        If details.ContainsKey(_ORDER_CUSTOMER.FRONT) And Not IsDBNull(details.Item(_ORDER_CUSTOMER.FRONT)) Then
            Dim front As New Dictionary(Of String, Integer)
            front = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, Integer))(details.Item(_ORDER_CUSTOMER.FRONT))

            If front.ContainsKey(_JSON_FIELD.HEAT) Then
                cb_fHeatTransfer.CheckState = CheckState.Checked
            End If

            If front.ContainsKey(_JSON_FIELD.PLAIN) Then
                cb_fPlain.CheckState = CheckState.Checked
            End If
        End If

        ' front printing/embroidery
        Select Case details.Item(_ORDER_CUSTOMER.FRONT_DEPT)
            Case _OPTIONAL_DEPT.PRINTING
                cb_fPrinting.CheckState = CheckState.Checked
            Case _OPTIONAL_DEPT.EMBROIDERY
                cb_fEmbroidery.CheckState = CheckState.Checked
            Case _OPTIONAL_DEPT.PRINTING_EMBROIDERY
                cb_fPrinting.CheckState = CheckState.Checked
                cb_fEmbroidery.CheckState = CheckState.Checked
        End Select

        ' back
        If details.ContainsKey(_ORDER_CUSTOMER.BACK) And Not IsDBNull(details.Item(_ORDER_CUSTOMER.BACK)) Then
            Dim back As New Dictionary(Of String, Integer)
            back = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, Integer))(details.Item(_ORDER_CUSTOMER.BACK))

            If back.ContainsKey(_JSON_FIELD.HEAT) Then
                cb_bHeatTransfer.CheckState = CheckState.Checked
            End If

            If back.ContainsKey(_JSON_FIELD.PLAIN) Then
                cb_bPlain.CheckState = CheckState.Checked
            End If
        End If

        ' back printing/embroidery
        Select Case details.Item(_ORDER_CUSTOMER.BACK_DEPT)
            Case _OPTIONAL_DEPT.PRINTING
                cb_bPrinting.CheckState = CheckState.Checked
            Case _OPTIONAL_DEPT.EMBROIDERY
                cb_bEmbroidery.CheckState = CheckState.Checked
            Case _OPTIONAL_DEPT.PRINTING_EMBROIDERY
                cb_bPrinting.CheckState = CheckState.Checked
                cb_bEmbroidery.CheckState = CheckState.Checked
        End Select

        ' artwork
        If Not IsDBNull(details.Item(_ORDER_CUSTOMER.ARTWORK)) Then
            Dim art As New Dictionary(Of String, Object)
            art = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(details.Item(_ORDER_CUSTOMER.ARTWORK))

            If art.ContainsKey(_JSON_FIELD.ARTWORK1) Then
                artworkImg1 = art.Item(_JSON_FIELD.ARTWORK1)
            End If
            If art.ContainsKey(_JSON_FIELD.ARTWORK2) Then
                artworkImg2 = art.Item(_JSON_FIELD.ARTWORK2)
            End If
            If art.ContainsKey(_JSON_FIELD.ARTWORK3) Then
                artworkImg3 = art.Item(_JSON_FIELD.ARTWORK3)
            End If
            If art.ContainsKey(_JSON_FIELD.ARTWORK4) Then
                artworkImg4 = art.Item(_JSON_FIELD.ARTWORK4)
            End If
            If art.ContainsKey(_JSON_FIELD.ARTWORK5) Then
                artworkImg5 = art.Item(_JSON_FIELD.ARTWORK5)
            End If
            If art.ContainsKey(_JSON_FIELD.ARTWORK6) Then
                artworkImg6 = art.Item(_JSON_FIELD.ARTWORK6)
            End If
        End If

        If artworkImg1 Is Nothing Then
            pic_artwork1.Text = "No artwork available"
            pic_artwork1.Enabled = False
        End If
        If artworkImg2 Is Nothing Then
            pic_artwork2.Text = "No artwork available"
            pic_artwork2.Enabled = False
        End If
        If artworkImg3 Is Nothing Then
            pic_artwork3.Text = "No artwork available"
            pic_artwork3.Enabled = False
        End If
        If artworkImg4 Is Nothing Then
            pic_artwork4.Text = "No artwork available"
            pic_artwork4.Enabled = False
        End If
        If artworkImg5 Is Nothing Then
            pic_artwork5.Text = "No artwork available"
            pic_artwork5.Enabled = False
        End If
        If artworkImg6 Is Nothing Then
            pic_artwork6.Text = "No artwork available"
            pic_artwork6.Enabled = False
        End If

        ' payment
        If Not IsDBNull(details.Item(_ORDER_CUSTOMER.PAYMENT_DOC)) Then
            paymentImg = details.Item(_ORDER_CUSTOMER.PAYMENT_DOC)
        End If

        If paymentImg Is Nothing Then
            lbl_docPath.Text = "No document available"
            lbl_docPath.Enabled = False
        End If

        ' size
        If details.ContainsKey(_ORDER_CUSTOMER.SIZE) Then
            Dim size As New Dictionary(Of String, Integer())
            size = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, Integer()))(details.Item(_ORDER_CUSTOMER.SIZE))

            If size.ContainsKey(_JSON_FIELD.XS) Then
                lbl_XS.Text = String.Concat("(", size.Item(_JSON_FIELD.XS)(0), """) XS")
                txt_XS.Text = size.Item(_JSON_FIELD.XS)(1)
            End If

            If size.ContainsKey(_JSON_FIELD.S) Then
                lbl_S.Text = String.Concat("(", size.Item(_JSON_FIELD.S)(0), """) S")
                txt_S.Text = size.Item(_JSON_FIELD.S)(1)
            End If

            If size.ContainsKey(_JSON_FIELD.M) Then
                lbl_M.Text = String.Concat("(", size.Item(_JSON_FIELD.M)(0), """) M")
                txt_M.Text = size.Item(_JSON_FIELD.M)(1)
            End If

            If size.ContainsKey(_JSON_FIELD.L) Then
                lbl_L.Text = String.Concat("(", size.Item(_JSON_FIELD.L)(0), """) L")
                txt_L.Text = size.Item(_JSON_FIELD.L)(1)
            End If

            If size.ContainsKey(_JSON_FIELD.XL) Then
                lbl_XL.Text = String.Concat("(", size.Item(_JSON_FIELD.XL)(0), """) XL")
                txt_XL.Text = size.Item(_JSON_FIELD.XL)(1)
            End If

            If size.ContainsKey(_JSON_FIELD.XXL) Then
                lbl_2XL.Text = String.Concat("(", size.Item(_JSON_FIELD.XXL)(0), """) 2XL")
                txt_2XL.Text = size.Item(_JSON_FIELD.XXL)(1)
            End If

            If size.ContainsKey(_JSON_FIELD.XXXL) Then
                lbl_3XL.Text = String.Concat("(", size.Item(_JSON_FIELD.XXXL)(0), """) 3XL")
                txt_3XL.Text = size.Item(_JSON_FIELD.XXXL)(1)
            End If
        End If

        ' material
        If details.ContainsKey(_ORDER_CUSTOMER.MATERIAL) Then
            txt_material.Text = details.Item(_ORDER_CUSTOMER.MATERIAL)
        End If

        ' colour
        If details.ContainsKey(_ORDER_CUSTOMER.COLOUR) Then
            txt_colour.Text = details.Item(_ORDER_CUSTOMER.COLOUR)
        End If

        ' packaging
        If details.ContainsKey(_ORDER_CUSTOMER.PACKAGING) Then
            Dim packaging As New Dictionary(Of String, Integer)
            packaging = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, Integer))(details.Item(_ORDER_CUSTOMER.PACKAGING))

            If packaging.ContainsKey(_JSON_FIELD.NO_PACKAGE) Then
                cb_no.CheckState = CheckState.Checked
            End If

            If packaging.ContainsKey(_JSON_FIELD.NORMAL_PACKAGE) Then
                cb_normal.CheckState = CheckState.Checked
            End If

            If packaging.ContainsKey(_JSON_FIELD.SUGARBAG_PACKAGE) Then
                cb_sugarBag.CheckState = CheckState.Checked
            End If

            If packaging.ContainsKey(_JSON_FIELD.FOLLOW_PACKAGE) Then
                cb_follow.CheckState = CheckState.Checked
            End If
        End If

        ' issue date
        If details.ContainsKey(_ORDER_CUSTOMER.ISSUE_DATE) Then
            d_issued.Text = Format(details.Item(_ORDER_CUSTOMER.ISSUE_DATE), "dd/MM/yyyy")

        End If

        ' delivery date
        If details.ContainsKey(_ORDER_CUSTOMER.DELIVERY_DATE) Then
            d_delivery.Text = Format(details.Item(_ORDER_CUSTOMER.DELIVERY_DATE), "dd/MM/yyyy")
        End If

        ' delivery type
        If details.ContainsKey(_ORDER_CUSTOMER.DELIVERY_TYPE) Then
            Select Case details.Item(_ORDER_CUSTOMER.DELIVERY_TYPE)
                Case _DELIVERY_TYPE.DELIVER
                    lbl_deliveryType.Text = "To be delivered"
                Case _DELIVERY_TYPE.PICKUP
                    lbl_deliveryType.Text = "To be picked up"
            End Select
        End If

        ' payment
        If details.ContainsKey(_ORDER_CUSTOMER.PAYMENT) Then
            Dim payment As New Dictionary(Of String, Integer)
            payment = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, Integer))(details.Item(_ORDER_CUSTOMER.PAYMENT))

            If payment.ContainsKey(_JSON_FIELD.CASH) Then
                cb_cash.CheckState = CheckState.Checked
            End If

            If payment.ContainsKey(_JSON_FIELD.CHEQUE) Then
                cb_cheque.CheckState = CheckState.Checked
            End If
        End If

        ' amount
        If details.ContainsKey(_ORDER_CUSTOMER.AMOUNT) Then
            txt_amount.Text = details.Item(_ORDER_CUSTOMER.AMOUNT)
        End If

        ' remarks
        If Not IsDBNull(details.Item(_ORDER_CUSTOMER.REMARKS)) Then
            rtb_remarks.Text = details.Item(_ORDER_CUSTOMER.REMARKS)
        End If

        ' production parts
        If Not IsDBNull(details.Item(_ORDER_CUSTOMER.PRODUCTION_PARTS)) Then
            Dim parts As New Dictionary(Of String, Object)
            parts = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(details.Item(_ORDER_CUSTOMER.PRODUCTION_PARTS))

            If parts.ContainsKey(_JSON_FIELD.FRONT) Then
                txt_front.Text = parts.Item(_JSON_FIELD.FRONT)
            End If

            If parts.ContainsKey(_JSON_FIELD.BACK) Then
                txt_back.Text = parts.Item(_JSON_FIELD.BACK)
            End If

            If parts.ContainsKey(_JSON_FIELD.SLEEVE) Then
                txt_sleeve.Text = parts.Item(_JSON_FIELD.SLEEVE)
            End If
        End If

        ' Inventory
        If Not IsDBNull(details.Item(_ORDER_CUSTOMER.INVENTORY_ORDER)) Then
            Dim inventoryItem As New Dictionary(Of String, String())

            inventoryItem = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, String()))(details.Item(_ORDER_CUSTOMER.INVENTORY_ORDER))
            For Each pair As KeyValuePair(Of String, String()) In inventoryItem
                ListView1.Items.Add(New ListViewItem({pair.Value(0), pair.Value(1), pair.Value(2)}))
            Next
        End If
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Me.Close()
    End Sub

    ' Operation
    Private Sub btn_multi_Click(sender As Object, e As EventArgs) Handles btn_multi.Click
        bgw_multifunctional.RunWorkerAsync()
        ShowLoadingOverlay(True)
    End Sub

    Private Sub lbl_docPath_Click(sender As Object, e As EventArgs) Handles lbl_docPath.Click
        Dim showImg As New View_image(My.Settings.PAYMENT_DIR, paymentImg)
        showImg.ShowDialog()
    End Sub

    Private Sub pic_artwork1_Click(sender As Object, e As EventArgs) Handles pic_artwork1.Click
        Dim showImg As New View_image(My.Settings.ARTWORK_DIR, artworkImg1)
        showImg.Show()
    End Sub

    Private Sub pic_artwork2_Click(sender As Object, e As EventArgs) Handles pic_artwork2.Click
        Dim showImg As New View_image(My.Settings.ARTWORK_DIR, artworkImg2)
        showImg.Show()
    End Sub

    Private Sub pic_artwork3_Click(sender As Object, e As EventArgs) Handles pic_artwork3.Click
        Dim showImg As New View_image(My.Settings.ARTWORK_DIR, artworkImg3)
        showImg.Show()
    End Sub

    Private Sub pic_artwork4_Click(sender As Object, e As EventArgs) Handles pic_artwork4.Click
        Dim showImg As New View_image(My.Settings.ARTWORK_DIR, artworkImg4)
        showImg.Show()
    End Sub

    Private Sub pic_artwork5_Click(sender As Object, e As EventArgs) Handles pic_artwork5.Click
        Dim showImg As New View_image(My.Settings.ARTWORK_DIR, artworkImg5)
        showImg.Show()
    End Sub

    Private Sub pic_artwork6_Click(sender As Object, e As EventArgs) Handles pic_artwork6.Click
        Dim showImg As New View_image(My.Settings.ARTWORK_DIR, artworkImg6)
        showImg.Show()
    End Sub

    Private Sub btn_track_Click(sender As Object, e As EventArgs) Handles btn_track.Click
        Dim log As New Job_Log(orderID)
        log.ShowDialog()
    End Sub

    ' Generate barcode
    Private Sub btn_barcode_Click(sender As Object, e As EventArgs) Handles btn_barcode.Click
        Select Case Session.department_id
            Case _PROCESS.ORDER
                Dim barcodeSticker As New Generate_Barcode(orderIDFull)
                barcodeSticker.ShowDialog()
            Case _PROCESS.CUTTING
                Dim barcodeForm As New Generate_Barcode_Department(orderID, salePersonID)
                barcodeForm.ShowDialog()
            Case _PROCESS.SEWING
                Dim orderDetails As New Dictionary(Of String, Object)

                orderDetails.Add(_BADGE.ORDER, orderIDFull)
                orderDetails.Add(_BADGE.CUSTOMER, txt_cusName.Text)
                orderDetails.Add(_BADGE.ORDER_NAME, txt_orderName.Text)

                If Not txt_XS.Text.Equals(0) Then
                    orderDetails.Add(_BADGE.XS, txt_XS.Text)
                End If

                If Not txt_S.Text.Equals(0) Then
                    orderDetails.Add(_BADGE.S, txt_S.Text)
                End If

                If Not txt_M.Text.Equals(0) Then
                    orderDetails.Add(_BADGE.M, txt_M.Text)
                End If

                If Not txt_L.Text.Equals(0) Then
                    orderDetails.Add(_BADGE.L, txt_L.Text)
                End If

                If Not txt_XL.Text.Equals(0) Then
                    orderDetails.Add(_BADGE.XL, txt_XL.Text)
                End If

                If Not txt_2XL.Text.Equals(0) Then
                    orderDetails.Add(_BADGE.XXL, txt_2XL.Text)
                End If

                If Not txt_3XL.Text.Equals(0) Then
                    orderDetails.Add(_BADGE.XXXL, txt_3XL.Text)
                End If

                Dim barcodeSticker As New Generate_Barcode_Sticker(orderDetails)
                barcodeSticker.ShowDialog()
        End Select
    End Sub

    ' Update Async
    Private Sub bgw_multifunctional_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgw_multifunctional.DoWork
        Dim updateQuery As New StringBuilder("BEGIN; UPDATE ")
        Dim logValues As New StringBuilder()
        Dim update As New Dictionary(Of String, Object)
        Dim log As New Dictionary(Of String, Object)

        Select Case Me.status
            Case 0
                status = 1
            Case 1
                status = 2
        End Select

        ' order update
        updateDateTime = DateTime.Now()
        updateQuery.Append(_TABLE.ORDER_CUSTOMER).AppendFormat(" SET {0} = @{0}, {1} = @{1}, ", _ORDER_CUSTOMER.E_USER, _ORDER_CUSTOMER.E_DATE)
        update.Add(_ORDER_CUSTOMER.E_USER, Session.user_id)
        update.Add(_ORDER_CUSTOMER.E_DATE, updateDateTime)
        log.Add(_ORDER_CUSTOMER.ORDER_ID, orderID)

        ' log
        log.Add(_ORDER_LOG.DEPARTMENT_ID, Session.department_id)
        log.Add(_ORDER_LOG.DATETIME, updateDateTime)
        log.Add(_ORDER_LOG.C_USER, Session.user_id)

        ' insert the new status
        Select Case Session.department_id
            Case _PROCESS.APPROVAL
                updateQuery.AppendFormat("{0} = @{0}", _ORDER_CUSTOMER.APPROVAL)
                update.Add(_ORDER_CUSTOMER.APPROVAL, status)

                log.Add(_ORDER_LOG.STATUS, _STATUS.APPROVAL_1)
            Case _PROCESS.CUTTING
                updateQuery.AppendFormat("{0} = @{0}", _ORDER_CUSTOMER.CUTTING)
                update.Add(_ORDER_CUSTOMER.CUTTING, status)

                If status = 1 Then
                    log.Add(_ORDER_LOG.STATUS, _STATUS.CUTTING_1)
                ElseIf status = 2 Then
                    log.Add(_ORDER_LOG.STATUS, _STATUS.CUTTING_2)
                End If
            Case _PROCESS.PRINTING
                updateQuery.AppendFormat("{0} = @{0}", _ORDER_CUSTOMER.PRINTING)
                update.Add(_ORDER_CUSTOMER.PRINTING, status)

                If status = 1 Then
                    log.Add(_ORDER_LOG.STATUS, _STATUS.PRINTING_1)
                ElseIf status = 2 Then
                    log.Add(_ORDER_LOG.STATUS, _STATUS.PRINTING_2)
                End If
            Case _PROCESS.EMBROIDERY
                updateQuery.AppendFormat("{0} = @{0}", _ORDER_CUSTOMER.EMBROIDERY)
                update.Add(_ORDER_CUSTOMER.EMBROIDERY, status)

                If status = 1 Then
                    log.Add(_ORDER_LOG.STATUS, _STATUS.EMBROIDERY_1)
                ElseIf status = 2 Then
                    log.Add(_ORDER_LOG.STATUS, _STATUS.EMBROIDERY_2)
                End If
            Case _PROCESS.SEWING
                updateQuery.AppendFormat("{0} = @{0}", _ORDER_CUSTOMER.SEWING)
                update.Add(_ORDER_CUSTOMER.SEWING, status)

                If status = 1 Then
                    log.Add(_ORDER_LOG.STATUS, _STATUS.SEWING_1)
                ElseIf status = 2 Then
                    log.Add(_ORDER_LOG.STATUS, _STATUS.SEWING_2)
                End If
        End Select

        ' construct query
        updateQuery.AppendFormat(" WHERE {0} = @{0}; INSERT INTO ", _ORDER_CUSTOMER.ORDER_ID).Append(_TABLE.ORDER_LOG).Append(" (")

        Dim addComma As Boolean = False
        For Each pair In log
            If addComma Then
                updateQuery.Append(", ")
                logValues.Append(", ")
            End If

            updateQuery.Append(pair.Key)
            logValues.Append("@").Append(pair.Key)
            update.Add(pair.Key, pair.Value)

            addComma = True
        Next

        updateQuery.Append(") VALUES (").Append(logValues).Append("); COMMIT;")

        e.Result = Database.ExecuteNonQuery(updateQuery.ToString(), update)
    End Sub

    ' Update result
    Private Sub gw_multifunctional_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw_multifunctional.RunWorkerCompleted
        ShowLoadingOverlay(False)

        If e.Result > 0 Then
            btn_multi.Enabled = False
            MessageBox.Show("Order status has been updated successfully", "Update Success")
            DialogResult = DialogResult.OK
        End If
    End Sub
End Class