Imports CrystalDecisions.CrystalReports.Engine

Public Class Live_Update
    Private loadingOverlay As Loading_Overlay
    Private jobReport As New ReportDocument
    Private dataset As Job_Schedule = New Job_Schedule()

    Private firstLoad As Boolean = True
    Private filterType As Integer = -1
    Private filterText As String
    Private filterDateStart As Date
    Private filterDateEnd As Date
    Private reportLimit As Integer

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        ' init
        cmb_filter.SelectedIndex = 0
        reportLimit = num_record.Value
        dtp_start.Value = Date.Now()
        dtp_start.MaxDate = Date.Now()
        dtp_end.Value = Date.Now()
        dtp_end.MinDate = Date.Now()
        HideDateFilterControls()
        HideTextFilterControl()

        jobReport.Load("Job.rpt")
        jobReport.SetDataSource(dataset)
        crv_job.ReportSource = jobReport
    End Sub

    ' Clear filter field
    Private Sub txt_filter_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_filter.GotFocus
        txt_filter.Clear()
        txt_filter.ForeColor = Color.Black
    End Sub

    ' Put place holder text in filter field
    Private Sub btn_search_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_filter.LostFocus
        If txt_filter.Text = String.Empty Then
            PutPlaceHolderText()
        End If
    End Sub

    ' Filter start date value changed
    Private Sub dtp_start_ValueChanged(sender As Object, e As EventArgs) Handles dtp_start.ValueChanged
        dtp_end.MinDate = dtp_start.Value
    End Sub

    ' Filter end date value changed
    Private Sub dtp_end_ValueChanged(sender As Object, e As EventArgs) Handles dtp_end.ValueChanged
        dtp_start.MaxDate = dtp_end.Value
    End Sub

    ' Apply button clicked
    Private Sub btn_apply_Click(sender As Object, e As EventArgs) Handles btn_apply.Click
        filterText = txt_filter.Text
        filterDateStart = dtp_start.Value
        filterDateEnd = dtp_end.Value
        filterType = cmb_filter.SelectedIndex
        reportLimit = num_record.Value
        ReloadReport()
    End Sub

    ' Report num value changed
    Private Sub num_record_ValueChanged(sender As Object, e As EventArgs) Handles num_record.ValueChanged
        ' dont reload on first load
        If Not firstLoad Then
            reportLimit = num_record.Value
            ReloadReport()
        End If
    End Sub

    ' Combobox value changed
    Private Sub cmb_filter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_filter.SelectedIndexChanged
        txt_filter.Clear()
        PutPlaceHolderText()

        Dim showTextFilterControlsOnly As Integer() = {1, 2}
        Dim showDateFilterControlsOnly As Integer() = {3, 4}

        ' show/hide controls
        If showTextFilterControlsOnly.Contains(cmb_filter.SelectedIndex) Then
            btn_apply.Show()
            HideDateFilterControls()
            ShowTextFilterControl()
        ElseIf showDateFilterControlsOnly.Contains(cmb_filter.SelectedIndex) Then
            btn_apply.Show()
            ShowDateFilterControls()
            HideTextFilterControl()
        Else
            btn_apply.Hide()
            HideDateFilterControls()
            HideTextFilterControl()

            filterType = cmb_filter.SelectedIndex
            reportLimit = num_record.Value
            ReloadReport()
        End If
    End Sub

    ' Load data
    Private Sub bgw_liveUpdate_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgw_liveUpdate.DoWork
        Dim limitFilter As String = String.Empty
        Dim filter As String = String.Empty

        If reportLimit > 0 Then
            limitFilter = " LIMIT " & reportLimit
        End If

        Select Case filterType
            Case 1
                ' customer
                filter = String.Concat(" AND ", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.CUSTOMER, " = '", filterText, "'")
            Case 2
                ' sales person
                If IsNumeric(filterText) Then
                    filter = String.Concat(" AND ", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.SALESPERSON_ID, " = ", filterText)
                Else
                    filter = String.Concat(" AND ", _TABLE.USER, ".", _USER.FIRST_NAME, " = '", filterText, "'")
                End If
            Case 3
                ' issue date
                If DateDiff(DateInterval.Day, filterDateStart, filterDateEnd) = 0 Then
                    filter = String.Concat(" AND ", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ISSUE_DATE, " = '", filterDateStart.ToString("yyyy-MM-dd"), "'")
                Else
                    filter = String.Concat(" AND ", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ISSUE_DATE, " BETWEEN '", filterDateStart.ToString("yyyy-MM-dd"), "' AND '", filterDateEnd.ToString("yyyy-MM-dd"), "'")
                End If
            Case 4
                ' delivery date
                If DateDiff(DateInterval.Day, filterDateStart, filterDateEnd) = 0 Then
                    filter = String.Concat(" AND ", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.DELIVERY_DATE, " = '", filterDateStart.ToString("yyyy-MM-dd"), "'")
                Else
                    filter = String.Concat(" AND ", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.DELIVERY_DATE, " BETWEEN '", filterDateStart.ToString("yyyy-MM-dd"), "' AND '", filterDateEnd.ToString("yyyy-MM-dd"), "'")
                End If
            Case 5
                ' finished job
                filter = String.Concat(" AND ", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.SEWING, " = ", 2)
            Case 6
                ' ongoing job
                filter = String.Concat(" AND ", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.SEWING, " < ", 2)
        End Select

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
                                              " GROUP BY ", _ORDER_LOG.ORDER_ID, ")", filter,
                                              " ORDER BY ", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ORDER_ID, " DESC",
                                              limitFilter
)

        e.Result = Database.GetDataTable(sqlStmt)
    End Sub

    ' Result
    Private Sub bgw_liveUpdate_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw_liveUpdate.RunWorkerCompleted
        ShowLoadingOverlay(False)

        If (e.Error Is Nothing) Then
            firstLoad = False
            dataset.Tables("job_schedule").Clear()
            dataset.Tables("job_schedule").Merge(e.Result)
            crv_job.RefreshReport()
        End If
    End Sub

    ' Loading overlay
    Private Sub ShowLoadingOverlay(ByVal show As Boolean)
        If show Then
            loadingOverlay = New Loading_Overlay
            loadingOverlay.Size = New Size(Me.Width - 16, Me.Height - 38)
            loadingOverlay.ShowDialog()
        Else
            loadingOverlay.Close()
        End If
    End Sub

    ' Reload report
    Private Sub ReloadReport()
        bgw_liveUpdate.RunWorkerAsync()
        ShowLoadingOverlay(True)
    End Sub

    ' Put place holder text
    Private Sub PutPlaceHolderText()
        txt_filter.ForeColor = Color.Gray

        Select Case cmb_filter.SelectedIndex
            Case 1
                ' customer
                txt_filter.Text = "Enter customer name"
            Case 2
                ' sales person
                txt_filter.Text = "Enter sales person ID or first name"
        End Select
    End Sub

    Private Sub HideTextFilterControl()
        txt_filter.Hide()
    End Sub

    Private Sub ShowTextFilterControl()
        txt_filter.Show()
    End Sub

    Private Sub HideDateFilterControls()
        dtp_start.Hide()
        Label2.Hide()
        dtp_end.Hide()
    End Sub

    Private Sub ShowDateFilterControls()
        dtp_start.Show()
        Label2.Show()
        dtp_end.Show()
    End Sub
End Class