Public Class new_order
    Private loadingOverlay As Loading_Overlay

    Private Sub form_load(sender As Object, e As System.EventArgs) Handles Me.Load
        d_delivery.MinDate = Date.Now()
        d_delivery.Value = Date.Now()
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
        If cb_fPrinting.CheckState = CheckState.Checked And cb_fEmbroidery.CheckState = CheckState.Checked Then
            order.Add(_ORDER_CUSTOMER.FRONT_DEPT, _OPTIONAL_DEPT.PRINTING_EMBROIDERY)
        ElseIf cb_fEmbroidery.CheckState = CheckState.Checked Then
            order.Add(_ORDER_CUSTOMER.FRONT_DEPT, _OPTIONAL_DEPT.EMBROIDERY)
        ElseIf cb_fPrinting.CheckState = CheckState.Checked Then
            order.Add(_ORDER_CUSTOMER.FRONT_DEPT, _OPTIONAL_DEPT.PRINTING)
        End If

        Dim front As New Dictionary(Of String, Integer)
        If cb_fHeatTransfer.CheckState = CheckState.Checked Then
            front.Add(_JSON_FIELD.HEAT, cb_fHeatTransfer.CheckState)
        End If

        If cb_fPlain.CheckState = CheckState.Checked Then
            front.Add(_JSON_FIELD.PLAIN, cb_fPlain.CheckState)
        End If
        order.Add(_ORDER_CUSTOMER.FRONT, Newtonsoft.Json.JsonConvert.SerializeObject(front))


        ' back
        If cb_bPrinting.CheckState = CheckState.Checked And cb_bEmbroidery.CheckState = CheckState.Checked Then
            order.Add(_ORDER_CUSTOMER.BACK_DEPT, _OPTIONAL_DEPT.PRINTING_EMBROIDERY)
        ElseIf cb_bEmbroidery.CheckState = CheckState.Checked Then
            order.Add(_ORDER_CUSTOMER.BACK_DEPT, _OPTIONAL_DEPT.EMBROIDERY)
        ElseIf cb_bPrinting.CheckState = CheckState.Checked Then
            order.Add(_ORDER_CUSTOMER.BACK_DEPT, _OPTIONAL_DEPT.PRINTING)
        End If

        Dim back As New Dictionary(Of String, Integer)
        If cb_bHeatTransfer.CheckState = CheckState.Checked Then
            back.Add(_JSON_FIELD.HEAT, cb_bHeatTransfer.CheckState)
        End If

        If cb_bPlain.CheckState = CheckState.Checked Then
            back.Add(_JSON_FIELD.PLAIN, cb_bPlain.CheckState)
        End If
        order.Add(_ORDER_CUSTOMER.BACK, Newtonsoft.Json.JsonConvert.SerializeObject(back))


        ' thickness
        order.Add(_ORDER_CUSTOMER.COLLAR, num_collar.Value)
        order.Add(_ORDER_CUSTOMER.CUFF, num_cuff.Value)


        ' sizes
        Dim size As New Dictionary(Of String, Integer())
        If num_XS_amount.Value > 0 Then
            size.Add(_JSON_FIELD.XS, {num_XS_size.Value, num_XS_amount.Value})
        End If

        If num_S_amount.Value > 0 Then
            size.Add(_JSON_FIELD.S, {num_S_size.Value, num_S_amount.Value})
        End If

        If num_M_amount.Value > 0 Then
            size.Add(_JSON_FIELD.M, {num_M_size.Value, num_M_amount.Value})
        End If

        If num_L_amount.Value > 0 Then
            size.Add(_JSON_FIELD.L, {num_L_size.Value, num_L_amount.Value})
        End If

        If num_XL_amount.Value > 0 Then
            size.Add(_JSON_FIELD.XL, {num_XL_size.Value, num_XL_amount.Value})
        End If

        If num_2XL_amount.Value > 0 Then
            size.Add(_JSON_FIELD.XXL, {num_2XL_size.Value, num_2XL_amount.Value})
        End If

        If num_3XL_amount.Value > 0 Then
            size.Add(_JSON_FIELD.XXXL, {num_3XL_size.Value, num_3XL_amount.Value})
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


        ' delivery type
        If rb_delivery.Checked Then
            order.Add(_ORDER_CUSTOMER.DELIVERY_TYPE, _DELIVERY_TYPE.DELIVER)
        Else
            order.Add(_ORDER_CUSTOMER.DELIVERY_TYPE, _DELIVERY_TYPE.PICKUP)
        End If


        ' artwork
        Dim tempArtworkDic As New Dictionary(Of String, Object)
        If txt_artwork1.Text.Length() > 0 Then
            Dim imgStore As String = Now.ToString("yyMMddHHmmss") & "_" & Guid.NewGuid().ToString("N") & IO.Path.GetExtension(txt_artwork1.Text)
            If Method.FtpUpload(txt_artwork1.Text, My.Settings.ARTWORK_DIR, imgStore) Then
                tempArtworkDic.Add(_JSON_FIELD.ARTWORK1, imgStore)
            End If
        End If
        If txt_artwork2.Text.Length() > 0 Then
            Dim imgStore As String = Now.ToString("yyMMddHHmmss") & "_" & Guid.NewGuid().ToString("N") & IO.Path.GetExtension(txt_artwork2.Text)
            If Method.FtpUpload(txt_artwork2.Text, My.Settings.ARTWORK_DIR, imgStore) Then
                tempArtworkDic.Add(_JSON_FIELD.ARTWORK2, imgStore)
            End If
        End If
        If txt_artwork3.Text.Length() > 0 Then
            Dim imgStore As String = Now.ToString("yyMMddHHmmss") & "_" & Guid.NewGuid().ToString("N") & IO.Path.GetExtension(txt_artwork3.Text)
            If Method.FtpUpload(txt_artwork3.Text, My.Settings.ARTWORK_DIR, imgStore) Then
                tempArtworkDic.Add(_JSON_FIELD.ARTWORK3, imgStore)
            End If
        End If
        If txt_artwork4.Text.Length() > 0 Then
            Dim imgStore As String = Now.ToString("yyMMddHHmmss") & "_" & Guid.NewGuid().ToString("N") & IO.Path.GetExtension(txt_artwork4.Text)
            If Method.FtpUpload(txt_artwork4.Text, My.Settings.ARTWORK_DIR, imgStore) Then
                tempArtworkDic.Add(_JSON_FIELD.ARTWORK4, imgStore)
            End If
        End If
        If txt_artwork5.Text.Length() > 0 Then
            Dim imgStore As String = Now.ToString("yyMMddHHmmss") & "_" & Guid.NewGuid().ToString("N") & IO.Path.GetExtension(txt_artwork5.Text)
            If Method.FtpUpload(txt_artwork5.Text, My.Settings.ARTWORK_DIR, imgStore) Then
                tempArtworkDic.Add(_JSON_FIELD.ARTWORK5, imgStore)
            End If
        End If
        If txt_artwork6.Text.Length() > 0 Then
            Dim imgStore As String = Now.ToString("yyMMddHHmmss") & "_" & Guid.NewGuid().ToString("N") & IO.Path.GetExtension(txt_artwork6.Text)
            If Method.FtpUpload(txt_artwork6.Text, My.Settings.ARTWORK_DIR, imgStore) Then
                tempArtworkDic.Add(_JSON_FIELD.ARTWORK6, imgStore)
            End If
        End If
        order.Add(_ORDER_CUSTOMER.ARTWORK, Newtonsoft.Json.JsonConvert.SerializeObject(tempArtworkDic))


        ' payment
        If txt_docPath.Text.Length() > 0 Then
            Dim docStore As String = Now.ToString("yyyyMMddHHmmss") & "_" & Guid.NewGuid().ToString("N") & IO.Path.GetExtension(txt_docPath.Text)
            If Method.FtpUpload(txt_docPath.Text, My.Settings.PAYMENT_DIR, docStore) Then
                order.Add(_ORDER_CUSTOMER.PAYMENT_DOC, docStore)
            End If
        End If

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
        Dim artwork As String() = Method.DialogGetFile(_FILE.TYPE.IMAGE, True)
        Dim tempArtwork As String

        If artwork.Length > 6 Then
            MessageBox.Show("Maximum artwork pictures is 6", "Error")
        Else
            For Each tempArtwork In artwork
                If artwork IsNot Nothing Then
                    If My.Computer.FileSystem.GetFileInfo(tempArtwork).Length() > My.Settings.MAX_UPLOAD_MB * 1048576 Then
                        MessageBox.Show("Image size exceeded " & My.Settings.MAX_UPLOAD_MB & "MB, please select another file or compress the image", "Error")
                    End If
                End If
            Next

            If artwork.Length >= 1 Then
                txt_artwork1.Text = artwork(0)
            End If
            If artwork.Length >= 2 Then
                txt_artwork2.Text = artwork(1)
            End If
            If artwork.Length >= 3 Then
                txt_artwork3.Text = artwork(2)
            End If
            If artwork.Length >= 4 Then
                txt_artwork4.Text = artwork(3)
            End If
            If artwork.Length >= 5 Then
                txt_artwork5.Text = artwork(4)
            End If
            If artwork.Length >= 6 Then
                txt_artwork6.Text = artwork(5)
            End If
        End If
    End Sub

    Private Sub btn_doc_Click(sender As Object, e As EventArgs) Handles btn_doc.Click
        Dim document As String = Method.DialogGetFile(_FILE.TYPE.IMAGE).First

        If document IsNot Nothing Then
            If My.Computer.FileSystem.GetFileInfo(document).Length() > My.Settings.MAX_UPLOAD_MB * 1048576 Then
                MessageBox.Show("Image size exceeded " & My.Settings.MAX_UPLOAD_MB & "MB, please select another file or compress the image", "Error")
                btn_doc_Click(sender, e)
            Else
                txt_docPath.Text = document
            End If
        End If
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
        num_XS_amount.ResetText()
        num_S_amount.ResetText()
        num_M_amount.ResetText()
        num_L_amount.ResetText()
        num_XL_amount.ResetText()
        num_2XL_amount.ResetText()
        num_3XL_amount.ResetText()
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
        txt_artwork1.ResetText()
        txt_artwork2.ResetText()
        txt_artwork3.ResetText()
        txt_artwork4.ResetText()
        txt_artwork5.ResetText()
        txt_artwork6.ResetText()
        txt_docPath.ResetText()
    End Sub

    Private Sub rb_pickedUp_Click(sender As Object, e As EventArgs) Handles rb_pickedUp.Click
        rb_delivery.Checked = False
    End Sub

    Private Sub rb_delivery_Click(sender As Object, e As EventArgs) Handles rb_delivery.Click
        rb_pickedUp.Checked = False
    End Sub
End Class