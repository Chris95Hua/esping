Public Class Sewing_Department
    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        txt_welcome.Text = "Welcome: " + Session.first_name
        bgw_SewingLoader.RunWorkerAsync()
    End Sub

    Private Sub btn_passUpdate_Click(sender As Object, e As EventArgs) Handles btn_passUpdate.Click
        Dim passUpdateForm = New Update_Password
        passUpdateForm.Show()
    End Sub

    Private Sub btn_logout_Click(sender As Object, e As EventArgs) Handles btn_logout.Click
        Dim login As New Login
        login.Show()
        Me.Close()
    End Sub

    Private Sub btn_refresh_Click(sender As Object, e As EventArgs) Handles btn_refresh.Click
        dgv_details.Enabled = False
        dgv_details = Nothing
        bgw_SewingLoader.RunWorkerAsync()
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

    Private Sub bgw_SewingLoader_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgw_SewingLoader.DoWork
        Dim sqlStmt As String = String.Concat("SELECT ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ORDER_ID, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.CUSTOMER, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ORDER_NAME, ", ",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.DELIVERY_DATE, ", ",
                                              " CASE ", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.EMBROIDERY, " WHEN 3 THEN 'CHECKED-IN' ELSE '-' END AS embroidery,",
                                              " CASE ", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.PRINTING, " WHEN 3 THEN 'CHECKED-IN' ELSE '-' END AS printing,",
                                              _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.SEWING,
                                              " FROM ", _TABLE.ORDER_CUSTOMER,
                                              " WHERE ", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.SEWING, " = 1"
                                        )
        e.Result = Database.GetDataTable(sqlStmt.ToString())
    End Sub

    Private Sub bgw_SewingLoader_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw_SewingLoader.RunWorkerCompleted
        If (e.Error Is Nothing) Then
            dgv_details.DataSource = e.Result
        End If

        dgv_details.Enabled = True
    End Sub

    Private Sub dgv_details_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_details.CellContentClick
        Dim details As New Order_Details(dgv_details.SelectedCells(0).Value, dgv_details.SelectedCells(6).Value)
        details.ShowDialog()
    End Sub
End Class