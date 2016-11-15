Public Class Manage_Order
    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        txt_welcome.Text = "Welcome: " + Session.first_name
        bgw_OrderLoader.RunWorkerAsync()
    End Sub

    Private Sub btn_logout_Click(sender As Object, e As EventArgs) Handles btn_logout.Click
        Dim login As New Login
        login.Show()
        Me.Close()
    End Sub

    Private Sub btn_newOrder_Click(sender As Object, e As EventArgs) Handles btn_newOrder.Click
        Dim newOrderForm As New new_order
        newOrderForm.Show()
    End Sub

    Private Sub txt_Search_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.GotFocus
        txt_search.Text = ""
        txt_search.ForeColor = Color.Black
    End Sub

    Private Sub btn_search_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.LostFocus
        If txt_search.Text = "" Then
            txt_search.Text = "Search"
            txt_search.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub btn_passUpdate_Click(sender As Object, e As EventArgs) Handles btn_passUpdate.Click
        Dim passUpdateForm As New Update_Password
        passUpdateForm.ShowDialog()
    End Sub

    Private Sub btn_edit_Click(sender As Object, e As EventArgs) Handles btn_edit.Click
        Dim editDeliveryForm As New Edit_Delivery_Date
        If editDeliveryForm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim id As Integer = dgv_details.SelectedCells.Item(0).Value
            Dim update As New Dictionary(Of String, Object)
            Dim newDate As Date = editDeliveryForm.d_newDeliveryDate.Value

            update.Add(_ORDER_CUSTOMER.DELIVERY_DATE, newDate)

            If Database.Update(_TABLE.ORDER_CUSTOMER, {_ORDER_CUSTOMER.ORDER_ID, "=", id}, update) Then
                dgv_details.SelectedCells.Item(4).Value = newDate.ToString("dd/MM/yyyy")
                MessageBox.Show("Delivery date updated successfully")
            Else
                MessageBox.Show("Update failed.")
            End If
        End If
    End Sub

    Private Sub bgw_OrderLoader_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgw_OrderLoader.DoWork
        Dim sqlStmt As String = String.Concat("SELECT ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ORDER_ID, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.CUSTOMER, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ORDER_NAME, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ISSUE_DATE, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.DELIVERY_DATE, ", ",
                                              _TABLE.ORDER_LOG, ".", _ORDER_LOG.STATUS,
                                              " FROM ", _TABLE.ORDER_CUSTOMER, " INNER JOIN ", _TABLE.ORDER_LOG,
                                              " ON ", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ORDER_ID,
                                              "=", _TABLE.ORDER_LOG, ".", _ORDER_LOG.ORDER_ID,
                                              " WHERE ", _TABLE.ORDER_LOG, ".", _ORDER_LOG.DATETIME, " IN ",
                                              " (SELECT MAX(", _ORDER_LOG.DATETIME, ") FROM ", _TABLE.ORDER_LOG,
                                              " GROUP BY ", _ORDER_LOG.ORDER_ID, ")",
                                              " ORDER BY ", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ISSUE_DATE, " DESC"
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
        Dim id As Integer = dgv_details.SelectedCells.Item(0).Value
        Dim result As Integer = MessageBox.Show("Confirm deletion?", "Delete Order", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            If Database.Delete(_TABLE.ORDER_CUSTOMER, {_ORDER_CUSTOMER.ORDER_ID, "=", id}) Then
                dgv_details.Rows.RemoveAt(dgv_details.SelectedRows(0).Index)
            Else
                MessageBox.Show("Delete failed")
            End If
        End If
    End Sub

    Private Sub dgv_details_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As DataGridViewCellMouseEventArgs) Handles dgv_details.CellMouseDoubleClick
        Dim details As New Order_Details(dgv_details.SelectedCells(0).Value)
        details.ShowDialog()
    End Sub

    Private Sub btn_refresh_Click(sender As Object, e As EventArgs) Handles btn_refresh.Click
        dgv_details.Enabled = False
        dgv_details.DataSource = Nothing
        bgw_OrderLoader.RunWorkerAsync()
    End Sub
End Class