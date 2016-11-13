Public Class Manage_Order
    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

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

            update.Add(ORDER_CUSTOMER.DELIVERY_DATE, newDate)

            If Database.Update(TABLE.ORDER_CUSTOMER, {ORDER_CUSTOMER.ORDER_ID, "=", id}, update) Then
                dgv_details.SelectedCells.Item(4).Value = newDate.ToString("dd/MM/yyyy")
                MessageBox.Show("Delivery date updated successfully")
            Else
                MessageBox.Show("Update failed.")
            End If
        End If
    End Sub

    ' background worker thread
    ' load data for order
    Private Sub bgw_OrderLoader_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgw_OrderLoader.DoWork
        Dim sqlStmt As String = String.Concat("SELECT ",
                                              TABLE.ORDER_CUSTOMER, ".", ORDER_CUSTOMER.ORDER_ID, ", ",
                                              TABLE.ORDER_CUSTOMER, ".", ORDER_CUSTOMER.CUSTOMER, ", ",
                                              TABLE.ORDER_CUSTOMER, ".", ORDER_CUSTOMER.ORDER_NAME, ", ",
                                              TABLE.ORDER_CUSTOMER, ".", ORDER_CUSTOMER.ISSUE_DATE, ", ",
                                              TABLE.ORDER_CUSTOMER, ".", ORDER_CUSTOMER.DELIVERY_DATE, ", ",
                                              TABLE.ORDER_LOG, ".", ORDER_LOG.STATUS,
                                              " FROM ", TABLE.ORDER_CUSTOMER, " INNER JOIN ", TABLE.ORDER_LOG,
                                              " ON ", TABLE.ORDER_CUSTOMER, ".", ORDER_CUSTOMER.ORDER_ID,
                                              "=", TABLE.ORDER_LOG, ".", ORDER_LOG.LOG_ID,
                                              " WHERE ", TABLE.ORDER_LOG, ".", ORDER_LOG.DATETIME, " IN ",
                                              " (SELECT MAX(", ORDER_LOG.DATETIME, ") FROM ", TABLE.ORDER_LOG,
                                              " GROUP BY ", ORDER_LOG.ORDER_ID, ")",
                                              " ORDER BY ", TABLE.ORDER_CUSTOMER, ".", ORDER_CUSTOMER.ISSUE_DATE, " DESC"
                                        )

        e.Result = Database.GetDataTable(sqlStmt.ToString())

    End Sub

    Private Sub bgw_OrderLoader_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw_OrderLoader.RunWorkerCompleted
        If (e.Error Is Nothing) Then
            dgv_details.DataSource = e.Result
        End If
    End Sub

    Private Sub btn_delete_Click(sender As Object, e As EventArgs) Handles btn_delete.Click
        Dim id As Integer = dgv_details.SelectedCells.Item(0).Value
        Dim result As Integer = MessageBox.Show("Confirm deletion?", "Delete Order", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            If Database.Delete(TABLE.ORDER_CUSTOMER, {ORDER_CUSTOMER.ORDER_ID, "=", id}) Then
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

    Private Sub Manage_Order_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txt_welcome.Text = "Welcome: " + Session.first_name
    End Sub
End Class