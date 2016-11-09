Public Class Approval_Department

    Private Sub Approval_Department_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bgw_ApprovalLoader.RunWorkerAsync()
    End Sub

    Private Sub btn_passUpdate_Click(sender As Object, e As EventArgs) Handles btn_passUpdate.Click
        Dim passUpdateForm As New Password_Update
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

    Private Sub dgv_details_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv_details.CellMouseDoubleClick
        Session.temp_pageID = dgv_details.SelectedCells(0).Value
        Check_Details.ShowDialog()
    End Sub
End Class