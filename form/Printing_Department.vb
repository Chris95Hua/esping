Public Class Printing_Department

    Private Sub btn_passUpdate_Click(sender As Object, e As EventArgs) Handles btn_passUpdate.Click
        Dim passUpdateForm = New Update_Password
        passUpdateForm.Show()
    End Sub

    Private Sub Printing_Department_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bgw_PrintLoader.RunWorkerAsync()
    End Sub

    Private Sub bgw_PrintLoader_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgw_PrintLoader.DoWork
        Dim sqlStmt As String = String.Concat("SELECT ",
                                              TABLE.ORDER_CUSTOMER, ".", ORDER_CUSTOMER.ORDER_ID, ", ",
                                              TABLE.ORDER_CUSTOMER, ".", ORDER_CUSTOMER.CUSTOMER, ", ",
                                              TABLE.ORDER_CUSTOMER, ".", ORDER_CUSTOMER.ORDER_NAME, ", ",
                                              TABLE.ORDER_CUSTOMER, ".", ORDER_CUSTOMER.DELIVERY_DATE, ", ",
                                              TABLE.ORDER_LOG, ".", ORDER_LOG.STATUS, ", ",
                                              TABLE.ORDER_LOG, ".", ORDER_LOG.DATETIME, ", ",
                                              TABLE.ORDER_CUSTOMER, ".", ORDER_CUSTOMER.PRINTING,
                                              " FROM ", TABLE.ORDER_CUSTOMER, " INNER JOIN ", TABLE.ORDER_LOG,
                                              " ON ", TABLE.ORDER_CUSTOMER, ".", ORDER_CUSTOMER.ORDER_ID,
                                              "=", TABLE.ORDER_LOG, ".", ORDER_LOG.ORDER_ID,
                                              " WHERE ", TABLE.ORDER_LOG, ".", ORDER_LOG.DEPARTMENT_ID,
                                              " = ", Session.department_id,
                                              " AND ", TABLE.ORDER_LOG, ".", ORDER_LOG.DATETIME, " IN ",
                                              " (SELECT MAX(", ORDER_LOG.DATETIME, ") FROM ", TABLE.ORDER_LOG,
                                              " GROUP BY ", ORDER_LOG.ORDER_ID, ")",
                                              " ORDER BY ", TABLE.ORDER_CUSTOMER, ".", ORDER_CUSTOMER.ISSUE_DATE, " DESC"
                                        )

        e.Result = Database.GetDataTable(sqlStmt.ToString())
    End Sub

    Private Sub bgw_PrintLoader_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw_PrintLoader.RunWorkerCompleted
        If (e.Error Is Nothing) Then
            dgv_details.DataSource = e.Result
        End If
    End Sub

    Private Sub dgv_details_CellMouseDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles dgv_details.CellMouseDoubleClick
        Dim details As New Order_Details(dgv_details.SelectedCells(0).Value, dgv_details.SelectedCells(6).Value)
        details.ShowDialog()
    End Sub
End Class