Public Class Login
    Private Sub LogIn_Click(sender As Object, e As EventArgs) Handles btn_login.Click
        If Method.Login(txt_username.Text, txt_password.Text) Then
            ' open form
            '' TODO: open form based on user role
            Dim order As New Manage_Order
            order.Show()

            Me.Close()
        Else
            ' error
            MessageBox.Show("No such username available")
        End If
    End Sub
End Class
