Imports CrystalDecisions.CrystalReports.Engine

Public Class Live_Update
    Private loadingOverlay As Loading_Overlay
    Dim jobReport As New ReportDocument

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        bgw_liveUpdate.RunWorkerAsync()
        ShowLoadingOverlay(True)

        'Dim ds As Char = IO.Path.DirectorySeparatorChar
        'jobReport.Load(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData & ds & "form" & ds & "Job.rpt")

        jobReport.Load(My.Settings.REPORT_DIR & "Job.rpt")
        'jobReport.SetDataSource()

        crv_job.ReportSource = jobReport
    End Sub

    Private Sub bgw_liveUpdate_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgw_liveUpdate.DoWork
        Dim sqlStmt As String = String.Concat("SELECT CONCAT_WS('", _FORMAT.ORDER_DELIMITER, "', ",
                                              _TABLE.USER, ".", _USER.USER_ID, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ORDER_ID, ") AS job_sheet_no", ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.CUSTOMER, ", ",
                                              _TABLE.USER, ".", _USER.FIRST_NAME, ", ",
                                              "DATE_FORMAT(", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ISSUE_DATE, ", '", _FORMAT.DATE_FORMAT, "') AS ", _ORDER_CUSTOMER.ISSUE_DATE, ", ",
                                              "DATE_FORMAT(", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.DELIVERY_DATE, ", '", _FORMAT.DATE_FORMAT, "') AS ", _ORDER_CUSTOMER.DELIVERY_DATE, ", ",
                                              _TABLE.ORDER_LOG, ".", _ORDER_LOG.STATUS, ", ",
                                              "CASE WHEN ", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.SEWING, " = 2 THEN ",
                                              "CONCAT(DATEDIFF(DATE_FORMAT(", _TABLE.ORDER_LOG, ".", _ORDER_LOG.DATETIME, ", '%Y/%m/%d'),", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ISSUE_DATE, "), ' DAYS') ELSE ",
                                              "CONCAT(DATEDIFF(DATE_FORMAT(NOW(), '%Y/%m/%d'),", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ISSUE_DATE, "), ' DAYS') END AS duration, ",
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
    End Sub

    Private Sub bgw_liveUpdate_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw_liveUpdate.RunWorkerCompleted
        ShowLoadingOverlay(False)

        If (e.Error Is Nothing) Then
            'dgv_liveInfo.DataSource = e.Result
        End If
    End Sub

    Private Sub ShowLoadingOverlay(ByVal show As Boolean)
        If show Then
            loadingOverlay = New Loading_Overlay
            loadingOverlay.Size = New Size(Me.Width - 16, Me.Height - 38)
            loadingOverlay.ShowDialog()
        Else
            loadingOverlay.Close()
        End If
    End Sub

End Class