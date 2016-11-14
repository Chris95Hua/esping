Public Class Sewing_Department
    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        txt_welcome.Text = "Welcome: " + Session.first_name
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
        dgv_details = Nothing
        ' run background worker async
    End Sub
End Class