Public Class Manage_Order
    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        If Session.department_id = _PROCESS.ADMIN Then
            Session.department_id = _PROCESS.ORDER
        End If

        txt_welcome.Text = "Welcome: " + Session.first_name
        LoadDataGridData()
    End Sub

    Private Sub btn_logout_Click(sender As Object, e As EventArgs) Handles btn_logout.Click
        Dim login As New Login
        login.Show()
        Me.Close()
    End Sub

    Private Sub btn_newOrder_Click(sender As Object, e As EventArgs) Handles btn_newOrder.Click
        Dim newOrderForm As New new_order
        newOrderForm.ShowDialog()

        LoadDataGridData()
    End Sub

    Private Sub txt_Search_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_search.GotFocus
        txt_search.Text = ""
        txt_search.ForeColor = Color.Black
    End Sub

    Private Sub btn_search_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_search.LostFocus
        If txt_search.Text = "" Then
            txt_search.Text = "Search Order"
            txt_search.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub btn_passUpdate_Click(sender As Object, e As EventArgs) Handles btn_passUpdate.Click
        Dim passUpdateForm As New Update_Password
        passUpdateForm.ShowDialog()
    End Sub

    Private Sub btn_edit_Click(sender As Object, e As EventArgs) Handles btn_edit.Click
        Dim editDeliveryForm As New Edit_Delivery_Date(Date.ParseExact(dgv_details.SelectedCells.Item(4).Value, "dd/MM/yyyy", Globalization.CultureInfo.InvariantCulture))


        If editDeliveryForm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim id As Integer = dgv_details.SelectedCells.Item(0).Value
            Dim newDate As Date = editDeliveryForm.d_newDeliveryDate.Value
            Dim update As New Dictionary(Of String, Object)

            update.Add(_ORDER_CUSTOMER.DELIVERY_DATE, newDate)

            If Database.Update(_TABLE.ORDER_CUSTOMER, {_ORDER_CUSTOMER.ORDER_ID, "=", id}, update) Then
                dgv_details.SelectedCells.Item(4).Value = newDate.ToString("dd/MM/yyyy")
                MessageBox.Show("Delivery date updated successfully")
            Else
                MessageBox.Show("Update failed.")
            End If
        End If
    End Sub

    Private Sub txt_search_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_search.KeyDown
        If e.KeyCode = Keys.Enter Then
            If IsNumeric(txt_search.Text) Then
                LoadDataGridData(txt_search.Text)
            Else
                MessageBox.Show("Invalid order number", "Error")
            End If
        End If
    End Sub

    Private Sub bgw_OrderLoader_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgw_OrderLoader.DoWork
        Dim searchQuery As String = String.Empty

        If e.Argument > 0 Then
            searchQuery = String.Concat(" AND ", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ORDER_ID, " = ", e.Argument)
        End If

        Dim sqlStmt As String = String.Concat("SELECT ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ORDER_ID, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.CUSTOMER, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ORDER_NAME, ", ",
                                              "DATE_FORMAT(", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ISSUE_DATE, ", '%d/%m/%Y') As ", _ORDER_CUSTOMER.ISSUE_DATE, ", ",
                                              "DATE_FORMAT(", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.DELIVERY_DATE, ", '%d/%m/%Y') As ", _ORDER_CUSTOMER.DELIVERY_DATE, ", ",
                                              _TABLE.ORDER_LOG, ".", _ORDER_LOG.STATUS,
                                              " FROM ", _TABLE.ORDER_CUSTOMER, " INNER JOIN ", _TABLE.ORDER_LOG,
                                              " ON ", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ORDER_ID,
                                              "=", _TABLE.ORDER_LOG, ".", _ORDER_LOG.ORDER_ID,
                                              " WHERE ", _TABLE.ORDER_LOG, ".", _ORDER_LOG.DATETIME, " IN ",
                                              " (SELECT MAX(", _ORDER_LOG.DATETIME, ") FROM ", _TABLE.ORDER_LOG,
                                              " GROUP BY ", _ORDER_LOG.ORDER_ID, ")",
                                              searchQuery,
                                              " ORDER BY ", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ORDER_ID, " DESC"
                                        )

        e.Result = Database.GetDataTable(sqlStmt.ToString())

    End Sub

    Private Sub bgw_OrderLoader_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw_OrderLoader.RunWorkerCompleted
        If (e.Error Is Nothing) Then
            dgv_details.DataSource = e.Result
        End If

        dgv_details.Enabled = True
    End Sub

    Private Sub btn_delete_Click(sender As Object, e As EventArgs) Handles btn_delete.Click
        Dim result As Integer = MessageBox.Show("Confirm deletion?", "Delete Order", MessageBoxButtons.YesNo)

        If result = DialogResult.Yes Then
            dgv_details.Enabled = False
            bgw_OrderDelete.RunWorkerAsync(dgv_details.SelectedCells.Item(0).Value)
        End If
    End Sub


    Private Sub bgw_OrderDelete_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgw_OrderDelete.DoWork
        Dim result As Boolean = False
        Dim id As Integer = e.Argument
        Dim ftpFiles As New Dictionary(Of String, Object)

        ftpFiles = Database.SelectRows(_TABLE.ORDER_CUSTOMER, {_ORDER_CUSTOMER.ORDER_ID, "=", id}, _ORDER_CUSTOMER.ARTWORK, _ORDER_CUSTOMER.PAYMENT_DOC).First

        If ftpFiles IsNot Nothing And Database.Delete(_TABLE.ORDER_CUSTOMER, {_ORDER_CUSTOMER.ORDER_ID, "=", id}) Then
            If Not IsDBNull(ftpFiles.Item(_ORDER_CUSTOMER.ARTWORK)) Then
                Method.FtpDelete(_FTP_DIRECTORY.ARTWORK, ftpFiles.Item(_ORDER_CUSTOMER.ARTWORK))

            End If

            If Not IsDBNull(ftpFiles.Item(_ORDER_CUSTOMER.PAYMENT_DOC)) Then
                Method.FtpDelete(_FTP_DIRECTORY.PAYMENT, ftpFiles.Item(_ORDER_CUSTOMER.PAYMENT_DOC))
            End If

            result = True
        End If

        e.Result = result
    End Sub

    Private Sub bgw_OrderDelete_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw_OrderDelete.RunWorkerCompleted
        If e.Result Then
            dgv_details.Rows.RemoveAt(dgv_details.SelectedRows(0).Index)
            MessageBox.Show("Order has been removed successfully", "Task Completed")
        Else
            MessageBox.Show("Failed to remove order", "Error")
        End If

        dgv_details.Enabled = True
    End Sub

    Private Sub dgv_details_CellMouseDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles dgv_details.CellMouseDoubleClick
        Dim details As New Order_Details(dgv_details.SelectedCells(0).Value, -1)
        details.ShowDialog()
    End Sub

    Private Sub btn_refresh_Click(sender As Object, e As EventArgs) Handles btn_refresh.Click
        LoadDataGridData()
    End Sub

    Private Sub LoadDataGridData(Optional ByVal orderID As Integer = -1)
        dgv_details.Enabled = False
        bgw_OrderLoader.RunWorkerAsync(orderID)
    End Sub
End Class