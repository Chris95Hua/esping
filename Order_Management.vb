Public Class Order_Management
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

    Private Sub dgv_details_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' use async task
        '' pass argument, ID perhaps?
        bgw_OrderLoader.RunWorkerAsync()
    End Sub

    Private Sub btn_passUpdate_Click(sender As Object, e As EventArgs) Handles btn_passUpdate.Click
        Dim passUpdateForm = New Password_Update
        passUpdateForm.Show()
    End Sub

    Private Sub btn_edit_Click(sender As Object, e As EventArgs) Handles btn_edit.Click
        Dim editDeliveryForm As New Edit_Delivery_Date
        editDeliveryForm.Show()
    End Sub

    ' background worker thread
    ' load data for order
    Private Sub bgw_OrderLoader_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgw_OrderLoader.DoWork
        ' get argument
        'e.Argument
        ' load and pass data

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

        ' use array as datasource and bind to it
        e.Result = Database.GetDataTable(sqlStmt.ToString())

    End Sub

    Private Sub bgw_OrderLoader_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw_OrderLoader.RunWorkerCompleted

        ' First, handle the case where an exception was thrown.
        If (e.Error Is Nothing) Then
            dgv_details.DataSource = e.Result
        End If
    End Sub
End Class