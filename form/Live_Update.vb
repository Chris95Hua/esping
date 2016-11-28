Public Class Live_Update
    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        bgw_liveUpdate.RunWorkerAsync()
    End Sub

    Private Sub bgw_liveUpdate_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgw_liveUpdate.DoWork
        Dim countStmt As String = String.Concat("SELECT COUNT(", _ORDER_LOG.LOG_ID, ") FROM ", _TABLE.ORDER_LOG, " WHERE ", _ORDER_LOG.DEPARTMENT_ID, "=7")
        If Database.countRows(countStmt) = 2 Then
            Dim sqlStmt As String = String.Concat("SELECT ",
                                                      "CONCAT(", _TABLE.USER, ".", _USER.USER_ID, ",'-',", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ORDER_ID, ") AS job_sheet_no", ", ",
                                                      _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.CUSTOMER, ", ",
                                                      _TABLE.USER, ".", _USER.FIRST_NAME, ", ",
                                                      "DATE_FORMAT(", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ISSUE_DATE, ", '%d/%m/%Y') AS ", _ORDER_CUSTOMER.ISSUE_DATE, ", ",
                                                      "DATE_FORMAT(", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.DELIVERY_DATE, ", '%d/%m/%Y') AS ", _ORDER_CUSTOMER.DELIVERY_DATE, ", ",
                                                      _TABLE.ORDER_LOG, ".", _ORDER_LOG.STATUS, ", ",
                                                      "CONCAT(DATEDIFF(MAX(DATE_FORMAT(", _TABLE.ORDER_LOG, ".", _ORDER_LOG.DATETIME, ",'%Y/%m/%d')), DATE_FORMAT(NOW(), '%Y/%m/%d')), ' DAYS') AS duration, ",
                                                      _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.REMARKS,
                                                      " FROM ", _TABLE.ORDER_CUSTOMER, " INNER JOIN ", _TABLE.ORDER_LOG,
                                                      " ON ", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ORDER_ID,
                                                      "=", _TABLE.ORDER_LOG, ".", _ORDER_LOG.ORDER_ID,
                                                      " INNER JOIN ", _TABLE.USER, " ON ", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.SALESPERSON_ID,
                                                      "=", _TABLE.USER, ".", _USER.USER_ID,
                                                      " WHERE ", _TABLE.ORDER_LOG, ".", _ORDER_LOG.DATETIME, " IN ",
                                                      " (SELECT MAX(", _ORDER_LOG.DATETIME, ") FROM ", _TABLE.ORDER_LOG,
                                                      " GROUP BY ", _ORDER_LOG.ORDER_ID, ")",
                                                      " ORDER BY ", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ORDER_ID, " DESC"
                                                )
            e.Result = Database.GetDataTable(sqlStmt)
        Else
            Dim sqlStmt As String = String.Concat("SELECT ",
                                                      "CONCAT(", _TABLE.USER, ".", _USER.USER_ID, ",'-',", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ORDER_ID, ") AS job_sheet_no", ", ",
                                                      _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.CUSTOMER, ", ",
                                                      _TABLE.USER, ".", _USER.FIRST_NAME, ", ",
                                                      "DATE_FORMAT(", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ISSUE_DATE, ", '%d/%m/%Y') AS ", _ORDER_CUSTOMER.ISSUE_DATE, ", ",
                                                      "DATE_FORMAT(", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.DELIVERY_DATE, ", '%d/%m/%Y') AS ", _ORDER_CUSTOMER.DELIVERY_DATE, ", ",
                                                      _TABLE.ORDER_LOG, ".", _ORDER_LOG.STATUS, ", ",
                                                      "CONCAT(DATEDIFF(DATE_FORMAT(NOW(), '%Y/%m/%d'),", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ISSUE_DATE, "), ' DAYS') AS duration, ",
                                                      _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.REMARKS,
                                                      " FROM ", _TABLE.ORDER_CUSTOMER, " INNER JOIN ", _TABLE.ORDER_LOG,
                                                      " ON ", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ORDER_ID,
                                                      "=", _TABLE.ORDER_LOG, ".", _ORDER_LOG.ORDER_ID,
                                                      " INNER JOIN ", _TABLE.USER, " ON ", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.SALESPERSON_ID,
                                                      "=", _TABLE.USER, ".", _USER.USER_ID,
                                                      " WHERE ", _TABLE.ORDER_LOG, ".", _ORDER_LOG.DATETIME, " IN ",
                                                      " (SELECT MAX(", _ORDER_LOG.DATETIME, ") FROM ", _TABLE.ORDER_LOG,
                                                      " GROUP BY ", _ORDER_LOG.ORDER_ID, ")",
                                                      " ORDER BY ", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ORDER_ID, " DESC"
                                                )
            e.Result = Database.GetDataTable(sqlStmt)
        End If
    End Sub

    Private Sub bgw_liveUpdate_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw_liveUpdate.RunWorkerCompleted
        If (e.Error Is Nothing) Then
            dgv_liveInfo.DataSource = e.Result
        End If

        dgv_liveInfo.Enabled = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        bgw_liveUpdate.RunWorkerAsync()
    End Sub
End Class