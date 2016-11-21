Public Class Approve_Order
    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        If Session.department_id = _PROCESS.ADMIN Then
            Session.department_id = _PROCESS.APPROVAL
        End If

        txt_welcome.Text = "Welcome: " + Session.first_name
        bgw_ApprovalLoader.RunWorkerAsync()
    End Sub

    Private Sub btn_passUpdate_Click(sender As Object, e As EventArgs) Handles btn_passUpdate.Click
        Dim passUpdateForm As New Update_Password
        passUpdateForm.ShowDialog()
    End Sub

    Private Sub bgw_ApprovalLoader_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgw_ApprovalLoader.DoWork
        Dim approvalID As Integer = _PROCESS.APPROVAL
        Dim orderID As Integer = _PROCESS.ORDER

        Dim sqlStmt As String = String.Concat("SELECT ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ORDER_ID, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.CUSTOMER, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ORDER_NAME, ", ",
                                              "DATE_FORMAT(", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ISSUE_DATE, ", '%d/%m/%Y') As ", _ORDER_CUSTOMER.ISSUE_DATE, ", ",
                                              "DATE_FORMAT(", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.DELIVERY_DATE, ", '%d/%m/%Y') As ", _ORDER_CUSTOMER.DELIVERY_DATE, ", ",
                                              "CASE ", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.APPROVAL, " WHEN 0 THEN '", _STATUS.APPROVAL_0, "' ELSE '", _STATUS.APPROVAL_1, "' END AS ", _ORDER_LOG.STATUS, ", ",
                                              "DATE_FORMAT(", _TABLE.ORDER_LOG, ".", _ORDER_LOG.DATETIME, ", '%d/%m/%Y %h:%i:%s %p') As ", _ORDER_LOG.DATETIME, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.APPROVAL,
                                              " FROM ", _TABLE.ORDER_CUSTOMER, " INNER JOIN ", _TABLE.ORDER_LOG,
                                              " ON ", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ORDER_ID,
                                              "=", _TABLE.ORDER_LOG, ".", _ORDER_LOG.ORDER_ID,
                                              " WHERE ", _TABLE.ORDER_LOG, ".", _ORDER_LOG.DATETIME, " IN ",
                                              " (SELECT MAX(", _ORDER_LOG.DATETIME, ") FROM ", _TABLE.ORDER_LOG,
                                              " WHERE ", _ORDER_LOG.DEPARTMENT_ID, " IN (", approvalID, ",", orderID, ")",
                                              " GROUP BY ", _ORDER_LOG.ORDER_ID, ")",
                                              " ORDER BY ", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.APPROVAL, " ASC, ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.E_DATE, " DESC"
                                        )

        e.Result = Database.GetDataTable(sqlStmt.ToString())
    End Sub

    Private Sub bgw_ApprovalLoader_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw_ApprovalLoader.RunWorkerCompleted
        If (e.Error Is Nothing) Then
            dgv_details.DataSource = e.Result
        End If

        dgv_details.Enabled = True
    End Sub

    Private Sub dgv_details_CellMouseDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles dgv_details.CellMouseDoubleClick
        Dim details As New Order_Details(dgv_details.SelectedCells(0).Value, dgv_details.SelectedCells(7).Value)

        ' approved
        If details.ShowDialog() = DialogResult.OK Then
            dgv_details.SelectedCells(5).Value = _STATUS.APPROVAL_1
            dgv_details.SelectedCells(6).Value = details.updateDateTime.ToString("dd/MM/yyyy hh:mm:ss tt")
            dgv_details.SelectedCells(7).Value = details.status
        End If
    End Sub

    Private Sub btn_logout_Click(sender As Object, e As EventArgs) Handles btn_logout.Click
        Dim login As New Login
        login.Show()
        Me.Close()
    End Sub

    Private Sub btn_refresh_Click(sender As Object, e As EventArgs) Handles btn_refresh.Click
        dgv_details.Enabled = False
        bgw_ApprovalLoader.RunWorkerAsync()
    End Sub

    Private Sub txt_Search_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_search.GotFocus
        txt_search.Text = ""
        txt_search.ForeColor = Color.Black
    End Sub

    Private Sub btn_search_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_search.LostFocus
        If txt_search.Text = "" Then
            txt_search.Text = "Search"
            txt_search.ForeColor = Color.Gray
        End If
    End Sub
End Class