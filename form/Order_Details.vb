Public Class Order_Details
    Dim orderID As Integer

    Sub New(ByVal orderID As Integer)
        ' This call is required by the designer.
        InitializeComponent()

        Me.orderID = orderID
    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        bgw_DetailsLoader.RunWorkerAsync(orderID)
    End Sub

    Private Sub bgw_OrderLoader_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgw_DetailsLoader.DoWork
        Dim sqlStmt As String = String.Concat("SELECT ",
                                              TABLE.ORDER_CUSTOMER, ".", ORDER_CUSTOMER.ORDER_NAME, ", ",
                                              TABLE.ORDER_CUSTOMER, ".", ORDER_CUSTOMER.CUSTOMER, ", ",
                                              TABLE.ORDER_CUSTOMER, ".", ORDER_CUSTOMER.FABRIC, ", ",
                                              TABLE.ORDER_CUSTOMER, ".", ORDER_CUSTOMER.COLLAR, ", ",
                                              TABLE.ORDER_CUSTOMER, ".", ORDER_CUSTOMER.CUFF, ", ",
                                              TABLE.ORDER_CUSTOMER, ".", ORDER_CUSTOMER.FRONT, ", ",
                                              TABLE.ORDER_CUSTOMER, ".", ORDER_CUSTOMER.BACK, ", ",
                                              TABLE.ORDER_CUSTOMER, ".", ORDER_CUSTOMER.SIZE, ", ",
                                              TABLE.ORDER_CUSTOMER, ".", ORDER_CUSTOMER.MATERIAL, ", ",
                                              TABLE.ORDER_CUSTOMER, ".", ORDER_CUSTOMER.COLOUR, ", ",
                                              TABLE.ORDER_CUSTOMER, ".", ORDER_CUSTOMER.PACKAGING, ", ",
                                              TABLE.ORDER_CUSTOMER, ".", ORDER_CUSTOMER.ISSUE_DATE, ", ",
                                              TABLE.ORDER_CUSTOMER, ".", ORDER_CUSTOMER.DELIVERY_DATE, ", ",
                                              TABLE.ORDER_CUSTOMER, ".", ORDER_CUSTOMER.PAYMENT, ", ",
                                              TABLE.ORDER_CUSTOMER, ".", ORDER_CUSTOMER.AMOUNT, ", ",
                                              TABLE.ORDER_LOG, ".", ORDER_LOG.STATUS,
                                              " FROM ", TABLE.ORDER_CUSTOMER, " INNER JOIN ", TABLE.ORDER_LOG,
                                              " ON ", TABLE.ORDER_CUSTOMER, ".", ORDER_CUSTOMER.ORDER_ID,
                                              "=", TABLE.ORDER_LOG, ".", ORDER_LOG.LOG_ID,
                                              " WHERE ", TABLE.ORDER_LOG, ".", ORDER_LOG.DATETIME, " IN ",
                                              " (SELECT MAX(", ORDER_LOG.DATETIME, ") FROM ", TABLE.ORDER_LOG,
                                              " GROUP BY ", ORDER_LOG.ORDER_ID, ")",
                                              " AND ", TABLE.ORDER_CUSTOMER, ".", ORDER_CUSTOMER.ORDER_ID, " = ", "@", ORDER_CUSTOMER.ORDER_ID
                                        )

        Dim orderID As New Dictionary(Of String, Object)
        orderID.Add(ORDER_CUSTOMER.ORDER_ID, e.Argument)

        e.Result = Database.ExecuteReader(sqlStmt.ToString(), orderID).First

    End Sub

    Private Sub bgw_OrderLoader_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw_DetailsLoader.RunWorkerCompleted
        If (e.Error Is Nothing) Then
            Dim results As New Dictionary(Of String, Object)
            results = e.Result

            ' order name
            If results.ContainsKey(ORDER_CUSTOMER.ORDER_NAME) Then
                txt_orderName.Text = results.Item(ORDER_CUSTOMER.ORDER_NAME)
            End If

            ' customer
            If results.ContainsKey(ORDER_CUSTOMER.CUSTOMER) Then
                txt_cusName.Text = results.Item(ORDER_CUSTOMER.CUSTOMER)
            End If

            ' fabric
            If results.ContainsKey(ORDER_CUSTOMER.FABRIC) Then
                Dim type As New Dictionary(Of String, Integer)
                type = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, Integer))(results.Item(ORDER_CUSTOMER.FABRIC))

                If type.ContainsKey(JSON_FIELD.FABRIC) Then
                    cb_fabricCL.CheckState = CheckState.Checked
                End If

                If type.ContainsKey(JSON_FIELD.SPLIT) Then
                    cb_split.CheckState = CheckState.Checked
                End If
            End If

            ' collar
            If results.ContainsKey(ORDER_CUSTOMER.COLLAR) Then
                txt_collar.Text = results.Item(ORDER_CUSTOMER.COLLAR)
            End If

            ' cuff
            If results.ContainsKey(ORDER_CUSTOMER.CUFF) Then
                txt_cuff.Text = results.Item(ORDER_CUSTOMER.CUFF)
            End If

            ' front
            If results.ContainsKey(ORDER_CUSTOMER.FRONT) Then
                Dim front As New Dictionary(Of String, Integer)
                front = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, Integer))(results.Item(ORDER_CUSTOMER.FRONT))

                If front.ContainsKey(JSON_FIELD.PRINTING) Then
                    cb_fPrinting.CheckState = CheckState.Checked
                End If

                If front.ContainsKey(JSON_FIELD.HEAT) Then
                    cb_fHeatTransfer.CheckState = CheckState.Checked
                End If

                If front.ContainsKey(JSON_FIELD.EMBROIDERY) Then
                    cb_fEmbroidery.CheckState = CheckState.Checked
                End If

                If front.ContainsKey(JSON_FIELD.PLAIN) Then
                    cb_fPlain.CheckState = CheckState.Checked
                End If
            End If

            ' back
            If results.ContainsKey(ORDER_CUSTOMER.BACK) Then
                Dim back As New Dictionary(Of String, Integer)
                back = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, Integer))(results.Item(ORDER_CUSTOMER.BACK))

                If back.ContainsKey(JSON_FIELD.PRINTING) Then
                    cb_bPrinting.CheckState = CheckState.Checked
                End If

                If back.ContainsKey(JSON_FIELD.HEAT) Then
                    cb_bHeatTransfer.CheckState = CheckState.Checked
                End If

                If back.ContainsKey(JSON_FIELD.EMBROIDERY) Then
                    cb_bEmbroidery.CheckState = CheckState.Checked
                End If

                If back.ContainsKey(JSON_FIELD.PLAIN) Then
                    cb_bPlain.CheckState = CheckState.Checked
                End If
            End If

            ' artwork

            ' size
            If results.ContainsKey(ORDER_CUSTOMER.SIZE) Then
                Dim size As New Dictionary(Of String, Integer)
                size = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, Integer))(results.Item(ORDER_CUSTOMER.SIZE))

                If size.ContainsKey(JSON_FIELD.XS) Then
                    txt_XS.Text = size.Item(JSON_FIELD.XS)
                End If

                If size.ContainsKey(JSON_FIELD.S) Then
                    txt_S.Text = size.Item(JSON_FIELD.S)
                End If

                If size.ContainsKey(JSON_FIELD.M) Then
                    txt_M.Text = size.Item(JSON_FIELD.M)
                End If

                If size.ContainsKey(JSON_FIELD.L) Then
                    txt_L.Text = size.Item(JSON_FIELD.L)
                End If

                If size.ContainsKey(JSON_FIELD.XL) Then
                    txt_XL.Text = size.Item(JSON_FIELD.XL)
                End If

                If size.ContainsKey(JSON_FIELD.XXL) Then
                    txt_2XL.Text = size.Item(JSON_FIELD.XXL)
                End If

                If size.ContainsKey(JSON_FIELD.XXXL) Then
                    txt_3XL.Text = size.Item(JSON_FIELD.XXXL)
                End If
            End If

            ' material
            If results.ContainsKey(ORDER_CUSTOMER.MATERIAL) Then
                txt_material.Text = results.Item(ORDER_CUSTOMER.MATERIAL)
            End If

            ' colour
            If results.ContainsKey(ORDER_CUSTOMER.COLOUR) Then
                txt_colour.Text = results.Item(ORDER_CUSTOMER.COLOUR)
            End If

            ' packaging
            If results.ContainsKey(ORDER_CUSTOMER.PACKAGING) Then
                Dim packaging As New Dictionary(Of String, Integer)
                packaging = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, Integer))(results.Item(ORDER_CUSTOMER.PACKAGING))

                If packaging.ContainsKey(JSON_FIELD.NO_PACKAGE) Then
                    cb_no.CheckState = CheckState.Checked
                End If

                If packaging.ContainsKey(JSON_FIELD.NORMAL_PACKAGE) Then
                    cb_normal.CheckState = CheckState.Checked
                End If

                If packaging.ContainsKey(JSON_FIELD.SUGARBAG_PACKAGE) Then
                    cb_sugarBag.CheckState = CheckState.Checked
                End If

                If packaging.ContainsKey(JSON_FIELD.FOLLOW_PACKAGE) Then
                    cb_follow.CheckState = CheckState.Checked
                End If
            End If

            ' issue date
            If results.ContainsKey(ORDER_CUSTOMER.ISSUE_DATE) Then
                d_issued.Text = Format(results.Item(ORDER_CUSTOMER.ISSUE_DATE), "dd/MM/yyyy")

            End If

            ' delivery date
            If results.ContainsKey(ORDER_CUSTOMER.DELIVERY_DATE) Then
                d_delivery.Text = Format(results.Item(ORDER_CUSTOMER.DELIVERY_DATE), "dd/MM/yyyy")
            End If

            ' payment
            If results.ContainsKey(ORDER_CUSTOMER.PAYMENT) Then
                Dim payment As New Dictionary(Of String, Integer)
                payment = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, Integer))(results.Item(ORDER_CUSTOMER.PAYMENT))

                If payment.ContainsKey(JSON_FIELD.CASH) Then
                    cb_cash.CheckState = CheckState.Checked
                End If

                If payment.ContainsKey(JSON_FIELD.CHEQUE) Then
                    cb_cheque.CheckState = CheckState.Checked
                End If
            End If

            ' amount
            If results.ContainsKey(ORDER_CUSTOMER.AMOUNT) Then
                txt_amount.Text = results.Item(ORDER_CUSTOMER.AMOUNT)
            End If
        End If
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Me.Close()
    End Sub

    Private Sub btn_multi_Click(sender As Object, e As EventArgs) Handles btn_multi.Click
        'this button can perform multiple function (generate barcode, approve order and etc) based on which department 
    End Sub
End Class