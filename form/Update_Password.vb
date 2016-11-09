Public Class Update_Password

    Private Sub btn_update_Click(sender As Object, e As EventArgs) Handles btn_update.Click
        If Method.UpdatePassword(txt_oldPass.Text, txt_newPass.Text, txt_retypePass.Text) Then
            MessageBox.Show("Your password has been successfully updated")
            Me.Close()
        Else
            MessageBox.Show("Password did not match, please try again.")
            txt_newPass.Text = ""
            txt_oldPass.Text = ""
            txt_retypePass.Text = ""
        End If
    End Sub
End Class