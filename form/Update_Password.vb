Public Class Update_Password

    Private Sub btn_update_Click(sender As Object, e As EventArgs) Handles btn_update.Click
        Dim hashedOldPass As String = Security.Hash(txt_oldPass.Text, Session.salt.ToString)

        'Method.IsPassword(txt_newPass.Text)
        If hashedOldPass.CompareTo(Session.password) <> 0 Then
            MessageBox.Show("Old password did not match the existing password", "Password Update Failed")
            txt_oldPass.Clear()
        ElseIf txt_newPass.TextLength < 4 Then
            MessageBox.Show("Password must contain at least 4 characters", "Password Update Failed")
            txt_newPass.Clear()
            txt_retypePass.Clear()
        ElseIf Not Method.IsPassword(txt_newPass.Text) Then
            MessageBox.Show("New password contain invalid characters", "Password Update Failed")
            txt_newPass.Clear()
            txt_retypePass.Clear()
        ElseIf txt_newPass.Text.CompareTo(txt_retypePass.Text) <> 0 Then
            MessageBox.Show("New password did not match the retype password", "Password Update Failed")
            txt_retypePass.Clear()
        Else
            Dim newSalt As String = Security.GenerateSalt()
            Dim hashedNewPass As String = Security.Hash(txt_newPass.Text, newSalt)
            Dim update As New Dictionary(Of String, Object)

            update.Add(_USER.PASSWORD, hashedNewPass)
            update.Add(_USER.SALT, newSalt)
            update.Add(_USER.E_USER, Session.user_id)
            update.Add(_USER.E_DATE, DateTime.Now)

            If Database.Update(_TABLE.USER, {_USER.USER_ID, "=", Session.user_id}, update) Then
                Session.salt = newSalt
                Session.password = hashedNewPass
                MessageBox.Show("Your password has been successfully updated", "Password Update Success")
                Me.Close()
            Else
                MessageBox.Show("An error has occurred while updating password", "Password Update Failed")
            End If
        End If
    End Sub
End Class