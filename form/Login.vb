Public Class Login
    Private Sub LogIn_Click(sender As Object, e As EventArgs) Handles btn_login.Click
        Me.LogInFunction()
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Session.Clear()
    End Sub

    Private Sub txt_password_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_password.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.LogInFunction()
        End If
    End Sub

    Private Sub LogInFunction()
        If Method.Login(txt_username.Text, txt_password.Text) Then
            ' open form
            Method.OpenForm()
            Me.Close()
        Else
            ' error
            MessageBox.Show("No such username available")
        End If
    End Sub
End Class
