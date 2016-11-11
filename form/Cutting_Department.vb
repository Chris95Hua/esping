Public Class Cutting_Department
    Private Sub Cutting_Department_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bgw_CutLoader.RunWorkerAsync()
    End Sub

    Private Sub txt_Search_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.GotFocus
        txt_search.Text = ""
    End Sub

    Private Sub btn_search_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.LostFocus
        If txt_search.Text = "" Then
            txt_search.Text = "Search"
        End If
    End Sub

    Private Sub btn_passUpdate_Click(sender As Object, e As EventArgs) Handles btn_passUpdate.Click
        Dim passUpdateForm = New Update_Password
        passUpdateForm.Show()
    End Sub

    Private Sub bgw_CutLoader_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgw_CutLoader.DoWork
        ' get argument
        'e.Argument
        ' load and pass data

        Dim sqlStmt As String = String.Concat("SELECT ",
                                              TABLE.ORDER_CUSTOMER, ".", ORDER_CUSTOMER.ORDER_ID, ", ",
                                              TABLE.ORDER_CUSTOMER, ".", ORDER_CUSTOMER.CUSTOMER, ", ",
                                              TABLE.ORDER_CUSTOMER, ".", ORDER_CUSTOMER.ORDER_NAME, ", ",
                                              TABLE.ORDER_CUSTOMER, ".", ORDER_CUSTOMER.DELIVERY_DATE, ", ",
                                              TABLE.ORDER_CUSTOMER, ".", ORDER_CUSTOMER.CUTTING, ", ",
                                              TABLE.ORDER_LOG, ".", ORDER_LOG.STATUS, ", ",
                                              TABLE.ORDER_LOG, ".", ORDER_LOG.DATETIME,
                                              " FROM ", TABLE.ORDER_CUSTOMER, " INNER JOIN ", TABLE.ORDER_LOG,
                                              " ON ", TABLE.ORDER_CUSTOMER, ".", ORDER_CUSTOMER.ORDER_ID,
                                              "=", TABLE.ORDER_LOG, ".", ORDER_LOG.LOG_ID,
                                              " WHERE ", TABLE.ORDER_LOG, ".", ORDER_LOG.DEPARTMENT_ID,
                                              " = ", Session.department_id,
                                              " AND ", TABLE.ORDER_LOG, ".", ORDER_LOG.DATETIME, " IN ",
                                              " (SELECT MAX(", ORDER_LOG.DATETIME, ") FROM ", TABLE.ORDER_LOG,
                                              " GROUP BY ", ORDER_LOG.ORDER_ID, ")",
                                              " ORDER BY ", TABLE.ORDER_CUSTOMER, ".", ORDER_CUSTOMER.ISSUE_DATE, " DESC"
                                        )

        ' use array as datasource and bind to it
        e.Result = Database.GetDataTable(sqlStmt.ToString())

    End Sub

    Private Sub bgw_CutLoader_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw_CutLoader.RunWorkerCompleted
        If (e.Error Is Nothing) Then
            dgv_details.DataSource = e.Result
        End If
    End Sub

    Private Sub dgv_details_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As DataGridViewCellMouseEventArgs)
        Dim details As New Order_Details(dgv_details.SelectedCells(0).Value, dgv_details.SelectedCells(7).Value)
        details.ShowDialog()
    End Sub
End Class