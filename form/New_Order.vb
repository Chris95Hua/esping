Public Class new_order
    Private loadingOverlay As Loading_Overlay

    Private Sub form_load(sender As Object, e As System.EventArgs) Handles Me.Load
        d_delivery.Value = DateTime.Now
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Me.Close()
    End Sub

    Private Sub btn_submit_Click(sender As Object, e As EventArgs) Handles btn_submit.Click
        If txt_cusName.Text Is String.Empty Or txt_orderName.Text Is String.Empty Or
            (cb_fabricCL.Checked = False And cb_split.Checked = False) Or
            (cb_fEmbroidery.Checked = False And cb_fHeatTransfer.Checked = False And cb_fPrinting.Checked = False And cb_fPlain.Checked = False) Or
            (cb_bEmbroidery.Checked = False And cb_bHeatTransfer.Checked = False And cb_bPrinting.Checked = False And cb_bPlain.Checked = False) Or
            txt_material.Text Is String.Empty Or txt_colour.Text Is String.Empty Or
            (cb_no.Checked = False And cb_normal.Checked = False And cb_sugarBag.Checked = False And cb_follow.Checked = False) Or
            (cb_cash.Checked = False And cb_cheque.Checked = False) Then
            MessageBox.Show("Please select at least 1 item from each of the checkbox category and fill in all empty fields", "Order Creation Failed")
        Else
            bgw_createOrder.RunWorkerAsync()
            ShowLoadingOverlay(True)
        End If

    End Sub

    Private Sub bgw_OrderLoader_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgw_createOrder.DoWork
        Dim order As New Dictionary(Of String, Object)

        ' order details
        order.Add(_ORDER_CUSTOMER.CUSTOMER, txt_cusName.Text)
        order.Add(_ORDER_CUSTOMER.ORDER_NAME, txt_orderName.Text)


        ' clothes type
        Dim type As New Dictionary(Of String, Integer)
        If cb_fabricCL.CheckState = CheckState.Checked Then
            type.Add(_JSON_FIELD.FABRIC, cb_fabricCL.CheckState)
        End If

        If cb_split.CheckState = CheckState.Checked Then
            type.Add(_JSON_FIELD.SPLIT, cb_split.CheckState)
        End If

        order.Add(_ORDER_CUSTOMER.FABRIC, Newtonsoft.Json.JsonConvert.SerializeObject(type))


        ' front
        Dim front As New Dictionary(Of String, Integer)
        If cb_fPrinting.CheckState = CheckState.Checked Then
            front.Add(_JSON_FIELD.PRINTING, cb_fPrinting.CheckState)
        End If

        If cb_fHeatTransfer.CheckState = CheckState.Checked Then
            front.Add(_JSON_FIELD.HEAT, cb_fHeatTransfer.CheckState)
        End If

        If cb_fEmbroidery.CheckState = CheckState.Checked Then
            front.Add(_JSON_FIELD.EMBROIDERY, cb_fEmbroidery.CheckState)
        End If

        If cb_fPlain.CheckState = CheckState.Checked Then
            front.Add(_JSON_FIELD.PLAIN, cb_fPlain.CheckState)
        End If
        order.Add(_ORDER_CUSTOMER.FRONT, Newtonsoft.Json.JsonConvert.SerializeObject(front))


        ' back
        Dim back As New Dictionary(Of String, Integer)
        If cb_bPrinting.CheckState = CheckState.Checked Then
            back.Add(_JSON_FIELD.PRINTING, cb_bPrinting.CheckState)
        End If

        If cb_bHeatTransfer.CheckState = CheckState.Checked Then
            back.Add(_JSON_FIELD.HEAT, cb_bHeatTransfer.CheckState)
        End If

        If cb_bEmbroidery.CheckState = CheckState.Checked Then
            back.Add(_JSON_FIELD.EMBROIDERY, cb_bEmbroidery.CheckState)
        End If

        If cb_bPlain.CheckState = CheckState.Checked Then
            back.Add(_JSON_FIELD.PLAIN, cb_bPlain.CheckState)
        End If
        order.Add(_ORDER_CUSTOMER.BACK, Newtonsoft.Json.JsonConvert.SerializeObject(back))


        ' thickness
        order.Add(_ORDER_CUSTOMER.COLLAR, num_collar.Value)
        order.Add(_ORDER_CUSTOMER.CUFF, num_cuff.Value)


        ' sizes
        Dim size As New Dictionary(Of String, Integer)
        If num_XS.Value > 0 Then
            size.Add(_JSON_FIELD.XS, num_XS.Value)
        End If

        If num_S.Value > 0 Then
            size.Add(_JSON_FIELD.S, num_S.Value)
        End If

        If num_M.Value > 0 Then
            size.Add(_JSON_FIELD.M, num_M.Value)
        End If

        If num_L.Value > 0 Then
            size.Add(_JSON_FIELD.L, num_L.Value)
        End If

        If num_XL.Value > 0 Then
            size.Add(_JSON_FIELD.XL, num_XL.Value)
        End If

        If num_2XL.Value > 0 Then
            size.Add(_JSON_FIELD.XXL, num_2XL.Value)
        End If

        If num_3XL.Value > 0 Then
            size.Add(_JSON_FIELD.XXXL, num_3XL.Value)
        End If
        order.Add(_ORDER_CUSTOMER.SIZE, Newtonsoft.Json.JsonConvert.SerializeObject(size))


        ' details
        order.Add(_ORDER_CUSTOMER.MATERIAL, txt_material.Text)
        order.Add(_ORDER_CUSTOMER.COLOUR, txt_colour.Text)


        ' packaging
        Dim packaging As New Dictionary(Of String, Integer)
        If cb_no.CheckState = CheckState.Checked Then
            packaging.Add(_JSON_FIELD.NO_PACKAGE, cb_no.CheckState)
        End If

        If cb_normal.CheckState = CheckState.Checked Then
            packaging.Add(_JSON_FIELD.NORMAL_PACKAGE, cb_normal.CheckState)
        End If

        If cb_sugarBag.CheckState = CheckState.Checked Then
            packaging.Add(_JSON_FIELD.SUGARBAG_PACKAGE, cb_sugarBag.CheckState)
        End If

        If cb_follow.CheckState = CheckState.Checked Then
            packaging.Add(_JSON_FIELD.FOLLOW_PACKAGE, cb_follow.CheckState)
        End If
        order.Add(_ORDER_CUSTOMER.PACKAGING, Newtonsoft.Json.JsonConvert.SerializeObject(packaging))


        ' delivery date
        order.Add(_ORDER_CUSTOMER.DELIVERY_DATE, d_delivery.Value)


        ' artwork and payment doc
        If txt_artwork.Text.Length() > 0 Then
            Dim imgStore As String = Now.ToString("yyyyMMddHHmmss") & "_" & Guid.NewGuid().ToString("N") & IO.Path.GetExtension(txt_artwork.Text)
            order.Add(_ORDER_CUSTOMER.ARTWORK, imgStore)
            Method.FtpUpload(txt_artwork.Text, _FTP_DIRECTORY.ARTWORK, imgStore)
        End If

        If txt_docPath.Text.Length() > 0 Then
            Dim docStore As String = Now.ToString("yyyyMMddHHmmss") & "_" & Guid.NewGuid().ToString("N") & IO.Path.GetExtension(txt_docPath.Text)
            order.Add(_ORDER_CUSTOMER.PAYMENT_DOC, docStore)
            Method.FtpUpload(txt_docPath.Text, _FTP_DIRECTORY.PAYMENT, docStore)
        End If


        ' payment
        Dim payment As New Dictionary(Of String, Integer)
        If cb_cash.CheckState = CheckState.Checked Then
            payment.Add(_JSON_FIELD.CASH, cb_cash.CheckState)
        End If

        If cb_cheque.CheckState = CheckState.Checked Then
            payment.Add(_JSON_FIELD.CHEQUE, cb_cheque.CheckState)
        End If
        order.Add(_ORDER_CUSTOMER.PAYMENT, Newtonsoft.Json.JsonConvert.SerializeObject(payment))

        order.Add(_ORDER_CUSTOMER.AMOUNT, num_amount.Value)


        ' user and date
        order.Add(_ORDER_CUSTOMER.SALESPERSON_ID, Session.user_id)
        order.Add(_ORDER_CUSTOMER.ISSUE_DATE, DateTime.Now)

        e.Result = Method.CreateOrder(order)
    End Sub

    Private Sub bgw_OrderLoader_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw_createOrder.RunWorkerCompleted
        ShowLoadingOverlay(False)

        If (e.Error Is Nothing) Then
            If e.Result Then
                ' add back to datagridview
                MessageBox.Show("Order has been created successfully", "Order Creation Success")
                ClearForm()
            Else
                MessageBox.Show("Failed to create new order", "Order Creation Failed")
            End If
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

    Private Sub btn_artwork_Click(sender As Object, e As EventArgs) Handles btn_artwork.Click
        txt_artwork.Text = Method.DialogGetFile(_FILE.TYPE.IMAGE).First
    End Sub

    Private Sub btn_doc_Click(sender As Object, e As EventArgs) Handles btn_doc.Click
        txt_docPath.Text = Method.DialogGetFile(_FILE.TYPE.IMAGE).First
    End Sub

    Private Sub ClearForm()
        ' clear form
        txt_cusName.Clear()
        txt_orderName.Clear()
        cb_fabricCL.Checked = False
        cb_split.Checked = False
        cb_fPrinting.Checked = False
        cb_fHeatTransfer.Checked = False
        cb_fEmbroidery.Checked = False
        cb_fPlain.Checked = False
        cb_bPrinting.Checked = False
        cb_bHeatTransfer.Checked = False
        cb_bEmbroidery.Checked = False
        cb_bPlain.Checked = False
        num_collar.ResetText()
        num_cuff.ResetText()
        num_XS.ResetText()
        num_S.ResetText()
        num_M.ResetText()
        num_L.ResetText()
        num_XL.ResetText()
        num_2XL.ResetText()
        num_3XL.ResetText()
        txt_material.Clear()
        txt_colour.Clear()
        cb_no.Checked = False
        cb_normal.Checked = False
        cb_sugarBag.Checked = False
        cb_follow.Checked = False
        d_delivery.Value = Date.Now()
        cb_cash.Checked = False
        cb_cheque.Checked = False
        num_amount.ResetText()
        txt_artwork.ResetText()
        txt_docPath.ResetText()
    End Sub
End Class