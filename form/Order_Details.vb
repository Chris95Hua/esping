Imports System.Text

Public Class Order_Details
    Private orderID As Integer
    Public status As Integer
    Public updateDateTime As DateTime
    Private artworkImg As String
    Private paymentImg As String

    Sub New(ByVal orderID As Integer, ByVal status As Integer)
        ' This call is required by the designer.
        InitializeComponent()

        Me.orderID = orderID
        Me.status = status
    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        bgw_DetailsLoader.RunWorkerAsync(orderID)
        Dim checkInOut() As Integer = {_PROCESS.CUTTING, _PROCESS.EMBROIDERY, _PROCESS.PRINTING, _PROCESS.SEWING}
        Dim barcode() As Integer = {_PROCESS.CUTTING, _PROCESS.SEWING}

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

    Private Sub bgw_OrderLoader_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgw_DetailsLoader.DoWork
        Dim sqlStmt As String = String.Concat("SELECT ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ORDER_NAME, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.CUSTOMER, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.FABRIC, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.COLLAR, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.CUFF, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.FRONT, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.BACK, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ARTWORK, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.SIZE, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.MATERIAL, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.COLOUR, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.PACKAGING, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ISSUE_DATE, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.DELIVERY_DATE, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.PAYMENT, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.PAYMENT_DOC, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.AMOUNT, ", ",
                                              _TABLE.ORDER_LOG, ".", _ORDER_LOG.STATUS,
                                              " FROM ", _TABLE.ORDER_CUSTOMER, " INNER JOIN ", _TABLE.ORDER_LOG,
                                              " ON ", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ORDER_ID,
                                              "=", _TABLE.ORDER_LOG, ".", _ORDER_LOG.ORDER_ID,
                                              " WHERE ", _TABLE.ORDER_LOG, ".", _ORDER_LOG.DATETIME, " IN ",
                                              " (SELECT MAX(", _ORDER_LOG.DATETIME, ") FROM ", _TABLE.ORDER_LOG,
                                              " GROUP BY ", _ORDER_LOG.ORDER_ID, ")",
                                              " AND ", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ORDER_ID, " = ", "@", _ORDER_CUSTOMER.ORDER_ID
                                        )

        Dim orderID As New Dictionary(Of String, Object)
        orderID.Add(_ORDER_CUSTOMER.ORDER_ID, e.Argument)

        Dim results As New Dictionary(Of String, Object)
        results = Database.ExecuteReader(sqlStmt.ToString(), orderID).First

        If Not IsDBNull(results.Item(_ORDER_CUSTOMER.ARTWORK)) Then
            artworkImg = results.Item(_ORDER_CUSTOMER.ARTWORK)
        End If

        If Not IsDBNull(results.Item(_ORDER_CUSTOMER.PAYMENT_DOC)) Then
            paymentImg = results.Item(_ORDER_CUSTOMER.PAYMENT_DOC)
        End If

        e.Result = results
    End Sub

    Private Sub bgw_OrderLoader_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw_DetailsLoader.RunWorkerCompleted
        If (e.Error Is Nothing) Then
            Dim results As New Dictionary(Of String, Object)
            results = e.Result

            ' order name
            If results.ContainsKey(_ORDER_CUSTOMER.ORDER_NAME) Then
                txt_orderName.Text = results.Item(_ORDER_CUSTOMER.ORDER_NAME)
            End If

            ' customer
            If results.ContainsKey(_ORDER_CUSTOMER.CUSTOMER) Then
                txt_cusName.Text = results.Item(_ORDER_CUSTOMER.CUSTOMER)
            End If

            ' fabric
            If results.ContainsKey(_ORDER_CUSTOMER.FABRIC) Then
                Dim type As New Dictionary(Of String, Integer)
                type = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, Integer))(results.Item(_ORDER_CUSTOMER.FABRIC))

                If type.ContainsKey(_JSON_FIELD.FABRIC) Then
                    cb_fabricCL.CheckState = CheckState.Checked
                End If

                If type.ContainsKey(_JSON_FIELD.SPLIT) Then
                    cb_split.CheckState = CheckState.Checked
                End If
            End If

            ' collar
            If results.ContainsKey(_ORDER_CUSTOMER.COLLAR) Then
                txt_collar.Text = results.Item(_ORDER_CUSTOMER.COLLAR)
            End If

            ' cuff
            If results.ContainsKey(_ORDER_CUSTOMER.CUFF) Then
                txt_cuff.Text = results.Item(_ORDER_CUSTOMER.CUFF)
            End If

            ' front
            If results.ContainsKey(_ORDER_CUSTOMER.FRONT) Then
                Dim front As New Dictionary(Of String, Integer)
                front = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, Integer))(results.Item(_ORDER_CUSTOMER.FRONT))

                If front.ContainsKey(_JSON_FIELD.PRINTING) Then
                    cb_fPrinting.CheckState = CheckState.Checked
                End If

                If front.ContainsKey(_JSON_FIELD.HEAT) Then
                    cb_fHeatTransfer.CheckState = CheckState.Checked
                End If

                If front.ContainsKey(_JSON_FIELD.EMBROIDERY) Then
                    cb_fEmbroidery.CheckState = CheckState.Checked
                End If

                If front.ContainsKey(_JSON_FIELD.PLAIN) Then
                    cb_fPlain.CheckState = CheckState.Checked
                End If
            End If

            ' back
            If results.ContainsKey(_ORDER_CUSTOMER.BACK) Then
                Dim back As New Dictionary(Of String, Integer)
                back = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, Integer))(results.Item(_ORDER_CUSTOMER.BACK))

                If back.ContainsKey(_JSON_FIELD.PRINTING) Then
                    cb_bPrinting.CheckState = CheckState.Checked
                End If

                If back.ContainsKey(_JSON_FIELD.HEAT) Then
                    cb_bHeatTransfer.CheckState = CheckState.Checked
                End If

                If back.ContainsKey(_JSON_FIELD.EMBROIDERY) Then
                    cb_bEmbroidery.CheckState = CheckState.Checked
                End If

                If back.ContainsKey(_JSON_FIELD.PLAIN) Then
                    cb_bPlain.CheckState = CheckState.Checked
                End If
            End If

            ' artwork
            If artworkImg Is Nothing Then
                lbl_artwork.Text = "No artwork available"
                pic_artwork.Enabled = False
            End If

            If paymentImg Is Nothing Then
                lbl_docPath.Text = "No document available"
                lbl_docPath.Enabled = False
            End If

            ' size
            If results.ContainsKey(_ORDER_CUSTOMER.SIZE) Then
                Dim size As New Dictionary(Of String, Integer)
                size = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, Integer))(results.Item(_ORDER_CUSTOMER.SIZE))

                If size.ContainsKey(_JSON_FIELD.XS) Then
                    txt_XS.Text = size.Item(_JSON_FIELD.XS)
                End If

                If size.ContainsKey(_JSON_FIELD.S) Then
                    txt_S.Text = size.Item(_JSON_FIELD.S)
                End If

                If size.ContainsKey(_JSON_FIELD.M) Then
                    txt_M.Text = size.Item(_JSON_FIELD.M)
                End If

                If size.ContainsKey(_JSON_FIELD.L) Then
                    txt_L.Text = size.Item(_JSON_FIELD.L)
                End If

                If size.ContainsKey(_JSON_FIELD.XL) Then
                    txt_XL.Text = size.Item(_JSON_FIELD.XL)
                End If

                If size.ContainsKey(_JSON_FIELD.XXL) Then
                    txt_2XL.Text = size.Item(_JSON_FIELD.XXL)
                End If

                If size.ContainsKey(_JSON_FIELD.XXXL) Then
                    txt_3XL.Text = size.Item(_JSON_FIELD.XXXL)
                End If
            End If

            ' material
            If results.ContainsKey(_ORDER_CUSTOMER.MATERIAL) Then
                txt_material.Text = results.Item(_ORDER_CUSTOMER.MATERIAL)
            End If

            ' colour
            If results.ContainsKey(_ORDER_CUSTOMER.COLOUR) Then
                txt_colour.Text = results.Item(_ORDER_CUSTOMER.COLOUR)
            End If

            ' packaging
            If results.ContainsKey(_ORDER_CUSTOMER.PACKAGING) Then
                Dim packaging As New Dictionary(Of String, Integer)
                packaging = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, Integer))(results.Item(_ORDER_CUSTOMER.PACKAGING))

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
            If results.ContainsKey(_ORDER_CUSTOMER.ISSUE_DATE) Then
                d_issued.Text = Format(results.Item(_ORDER_CUSTOMER.ISSUE_DATE), "dd/MM/yyyy")

            End If

            ' delivery date
            If results.ContainsKey(_ORDER_CUSTOMER.DELIVERY_DATE) Then
                d_delivery.Text = Format(results.Item(_ORDER_CUSTOMER.DELIVERY_DATE), "dd/MM/yyyy")
            End If

            ' payment
            If results.ContainsKey(_ORDER_CUSTOMER.PAYMENT) Then
                Dim payment As New Dictionary(Of String, Integer)
                payment = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, Integer))(results.Item(_ORDER_CUSTOMER.PAYMENT))

                If payment.ContainsKey(_JSON_FIELD.CASH) Then
                    cb_cash.CheckState = CheckState.Checked
                End If

                If payment.ContainsKey(_JSON_FIELD.CHEQUE) Then
                    cb_cheque.CheckState = CheckState.Checked
                End If
            End If

            ' amount
            If results.ContainsKey(_ORDER_CUSTOMER.AMOUNT) Then
                txt_amount.Text = results.Item(_ORDER_CUSTOMER.AMOUNT)
            End If
        End If
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Me.Close()
    End Sub

    Private Sub btn_multi_Click(sender As Object, e As EventArgs) Handles btn_multi.Click
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

        ' result
        If Database.ExecuteNonQuery(updateQuery.ToString(), update) <> -1 Then
            btn_multi.Enabled = False
            MessageBox.Show("Order status has been updated successfully", "Update Success")
            DialogResult = DialogResult.OK
        End If
    End Sub

    Private Sub pic_artwork_Click(sender As Object, e As EventArgs) Handles pic_artwork.Click
        Dim showImg As New View_image(_FTP_DIRECTORY.ARTWORK, artworkImg)
        showImg.ShowDialog()
    End Sub

    Private Sub lbl_docPath_Click(sender As Object, e As EventArgs) Handles lbl_docPath.Click
        Dim showImg As New View_image(_FTP_DIRECTORY.PAYMENT, paymentImg)
        showImg.ShowDialog()
    End Sub

    Private Sub btn_track_Click(sender As Object, e As EventArgs) Handles btn_track.Click
        Dim log As New Job_Log(orderID)

        log.ShowDialog()
    End Sub
End Class