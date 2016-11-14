Public Class Printing_Department
    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        txt_welcome.Text = "Welcome: " + Session.first_name
        bgw_PrintLoader.RunWorkerAsync()
    End Sub

    Private Sub btn_passUpdate_Click(sender As Object, e As EventArgs) Handles btn_passUpdate.Click
        Dim passUpdateForm = New Update_Password
        passUpdateForm.Show()
    End Sub

    Private Sub bgw_PrintLoader_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgw_PrintLoader.DoWork
        Dim sqlStmt As String = String.Concat("SELECT ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ORDER_ID, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.CUSTOMER, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ORDER_NAME, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.DELIVERY_DATE, ", ",
                                              _TABLE.ORDER_LOG, ".", _ORDER_LOG.STATUS, ", ",
                                              _TABLE.ORDER_LOG, ".", _ORDER_LOG.DATETIME,
                                              " FROM ", _TABLE.ORDER_CUSTOMER, " INNER JOIN ", _TABLE.ORDER_LOG,
                                              " ON ", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ORDER_ID,
                                              "=", _TABLE.ORDER_LOG, ".", _ORDER_LOG.ORDER_ID,
                                              " WHERE ", _TABLE.ORDER_LOG, ".", _ORDER_LOG.DEPARTMENT_ID,
                                              " = ", Session.department_id,
                                              " AND ", _TABLE.ORDER_LOG, ".", _ORDER_LOG.DATETIME, " IN ",
                                              " (SELECT MAX(", _ORDER_LOG.DATETIME, ") FROM ", _TABLE.ORDER_LOG,
                                              " GROUP BY ", _ORDER_LOG.ORDER_ID, ")",
                                              " ORDER BY ", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ISSUE_DATE, " DESC"
                                        )
        e.Result = Database.GetDataTable(sqlStmt.ToString())
    End Sub

    Private Sub bgw_PrintLoader_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw_PrintLoader.RunWorkerCompleted
        If (e.Error Is Nothing) Then
            dgv_details.DataSource = e.Result
        End If
    End Sub

    Private Sub dgv_details_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        Dim details As New Order_Details(dgv_details.SelectedCells(0).Value)
        details.ShowDialog()
    End Sub

    Private Sub btn_logout_Click(sender As Object, e As EventArgs) Handles btn_logout.Click
        Dim login As New Login
        login.Show()
        Me.Close()
    End Sub

    Private Sub btn_refresh_Click(sender As Object, e As EventArgs) Handles btn_refresh.Click
        dgv_details = Nothing
        bgw_PrintLoader.RunWorkerAsync()
    End Sub
End Class