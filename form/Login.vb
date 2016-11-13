Public Class Login
    Private Sub LogIn_Click(sender As Object, e As EventArgs) Handles btn_login.Click
        Me.LogInFunction()
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Method.clearSession()
    End Sub

    Private Sub txt_password_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_password.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.LogInFunction()
        End If
    End Sub

    Private Sub LogInFunction()
        If Method.Login(txt_username.Text, txt_password.Text) Then
            ' open form
            '' TODO: open form based on department id
            Method.openForm()
            Me.Close()
        Else
            ' error
            MessageBox.Show("No such username available")
        End If
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub txt_username_TextChanged(sender As Object, e As EventArgs) Handles txt_username.TextChanged

    End Sub

    Private Sub txt_password_TextChanged(sender As Object, e As EventArgs) Handles txt_password.TextChanged

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class
