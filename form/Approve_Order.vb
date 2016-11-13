Public Class Approve_Order
    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        bgw_ApprovalLoader.RunWorkerAsync()
    End Sub

    Private Sub btn_passUpdate_Click(sender As Object, e As EventArgs) Handles btn_passUpdate.Click
        Dim passUpdateForm As New Update_Password
        passUpdateForm.ShowDialog()
    End Sub

    Private Sub bgw_ApprovalLoader_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgw_ApprovalLoader.DoWork
        Dim sqlStmt As String = String.Concat("SELECT ",
                                              TABLE.ORDER_CUSTOMER, ".", ORDER_CUSTOMER.ORDER_ID, ", ",
                                              TABLE.ORDER_CUSTOMER, ".", ORDER_CUSTOMER.CUSTOMER, ", ",
                                              TABLE.ORDER_CUSTOMER, ".", ORDER_CUSTOMER.ORDER_NAME, ", ",
                                              TABLE.ORDER_CUSTOMER, ".", ORDER_CUSTOMER.ISSUE_DATE, ", ",
                                              TABLE.ORDER_CUSTOMER, ".", ORDER_CUSTOMER.DELIVERY_DATE, ", ",
                                              TABLE.STATUS, ".", APPROVAL.STATUS, ", ",
                                              TABLE.ORDER_CUSTOMER, ".", ORDER_CUSTOMER.E_DATE,
                                              " FROM ", TABLE.ORDER_CUSTOMER, " INNER JOIN ", TABLE.STATUS,
                                              " ON ", TABLE.ORDER_CUSTOMER, ".", ORDER_CUSTOMER.APPROVAL,
                                              " = ", TABLE.STATUS, ".", APPROVAL.STATUS_ID,
                                              " ORDER BY ", TABLE.ORDER_CUSTOMER, ".", ORDER_CUSTOMER.APPROVAL,
                                              " ASC, ", TABLE.ORDER_CUSTOMER, ".", ORDER_CUSTOMER.E_DATE, " DESC"
                                        )
        e.Result = Database.GetDataTable(sqlStmt.ToString())
    End Sub

    Private Sub bgw_ApprovalLoader_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw_ApprovalLoader.RunWorkerCompleted
        If (e.Error Is Nothing) Then
            dgv_details.DataSource = e.Result
        End If
    End Sub

    Private Sub dgv_details_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As DataGridViewCellMouseEventArgs) Handles dgv_details.CellMouseDoubleClick
        Dim details As New Order_Details(dgv_details.SelectedCells(0).Value)
        details.ShowDialog()
    End Sub

    Private Sub btn_logout_Click(sender As Object, e As EventArgs) Handles btn_logout.Click
        Dim login As New Login
        login.Show()
        Me.Close()
    End Sub

    Private Sub Approve_Order_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txt_welcome.Text = "Welcome: " + Session.first_name
    End Sub
End Class