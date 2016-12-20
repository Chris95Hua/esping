Public Class Update_Password
    Private loadingOverlay As Loading_Overlay
    Private newSalt As String
    Private hashedNewPass As String

    ' check password
    Private Sub btn_update_Click(sender As Object, e As EventArgs) Handles btn_update.Click
        Dim hashedOldPass As String = Security.Hash(txt_oldPass.Text, Session.salt.ToString)

        If hashedOldPass.CompareTo(Session.password) <> 0 Then
            MessageBox.Show("Old password did not match the existing password", "Password Update Failed")
            txt_oldPass.Clear()
        ElseIf Not Method.IsPassword(txt_newPass.Text) Then
            MessageBox.Show("Password should be 4-12 characters long and cannot contain space and certain special characters like semicolon", "Password Update Failed")
            txt_newPass.Clear()
            txt_retypePass.Clear()
        ElseIf txt_newPass.Text.CompareTo(txt_retypePass.Text) <> 0 Then
            MessageBox.Show("New password did not match the retype password", "Password Update Failed")
            txt_retypePass.Clear()
        Else
            bgw_update.RunWorkerAsync()
            ShowLoadingOverlay(True)
        End If
    End Sub

    ' Update Async work
    Private Sub bgw_update_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgw_update.DoWork
        newSalt = Security.GenerateSalt()
        hashedNewPass = Security.Hash(txt_newPass.Text, newSalt)
        Dim update As New Dictionary(Of String, Object)

        update.Add(_USER.PASSWORD, hashedNewPass)
        update.Add(_USER.SALT, newSalt)
        update.Add(_USER.E_USER, Session.user_id)
        update.Add(_USER.E_DATE, DateTime.Now)

        e.Result = Database.Update(_TABLE.USER, {_USER.USER_ID, "=", Session.user_id}, Update)
    End Sub

    ' Update completed
    Private Sub bgw_update_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw_update.RunWorkerCompleted
        ShowLoadingOverlay(False)

        If e.Result Then
            Session.salt = newSalt
            Session.password = hashedNewPass
            MessageBox.Show("Your password has been successfully updated", "Password Update Success")
            Me.Close()
        Else
            MessageBox.Show("An error has occurred while updating password", "Password Update Failed")
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
End Class