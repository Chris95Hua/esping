Public Class Update_Password

    Private Sub btn_update_Click(sender As Object, e As EventArgs) Handles btn_update.Click
        Dim hashedOldPass As String = Security.Hash(txt_oldPass.Text, Session.salt.ToString)

        If hashedOldPass.CompareTo(Session.password) = 0 And txt_newPass.Text = txt_retypePass.Text Then
            If txt_newPass.TextLength < 4 Then
                MessageBox.Show("Password must contain at least 4 characters", "Password Update Failed")
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
        Else
            MessageBox.Show("Password did not match. Please make sure all the fields are correct", "Password Update Failed")
            txt_newPass.Clear()
            txt_oldPass.Clear()
            txt_retypePass.Clear()
        End If
    End Sub
End Class