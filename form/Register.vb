Public Class Register
    Private loadingOverlay As Loading_Overlay

    Private Sub Registration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each dpmt In Database.SelectAllRows(_TABLE.DEPARTMENT, {"*"})
            cb_department.Items.Add(dpmt.Item(_DEPARTMENT.NAME))
        Next

        cb_department.SelectedIndex = 0
        cb_role.SelectedIndex = 0
    End Sub

    Private Sub btn_submit_Click(sender As Object, e As EventArgs) Handles btn_submit.Click
        If Not Method.IsName(txt_firstName.Text) Or Not Method.IsName(txt_lastName.Text) Then
            MessageBox.Show("Name fields cannot be empty and can only contain alphanumeric, space, single quote and hyphen", "Account Registration Failed")
        ElseIf Not Method.IsUsername(txt_userName.Text) Then
            MessageBox.Show("Username should be 3-12 characters long and can only contain alphanumeric, hyphen and underscore", "Account Registration Failed")
        ElseIf Not Method.IsPassword(txt_password.Text) Then
            MessageBox.Show("Password should be 4-12 characters long and cannot contain space and certain special characters like semicolon", "Account Registration Failed")
        Else
            Dim dataIn As New Dictionary(Of String, Object)
            Dim salt As String = Security.GenerateSalt()
            dataIn.Add(_USER.FIRST_NAME, txt_firstName.Text)
            dataIn.Add(_USER.LAST_NAME, txt_lastName.Text)
            dataIn.Add(_USER.USERNAME, txt_userName.Text)
            dataIn.Add(_USER.SALT, salt)
            dataIn.Add(_USER.PASSWORD, Security.Hash(txt_password.Text, salt))
            dataIn.Add(_USER.DEPARTMENT_ID, cb_department.SelectedIndex)
            dataIn.Add(_USER.ROLE, cb_role.SelectedIndex)
            dataIn.Add(_USER.C_USER, Session.user_id)
            dataIn.Add(_USER.C_DATE, DateTime.Now)

            bgw_register.RunWorkerAsync(dataIn)
            ShowLoadingOverlay(True)
        End If
    End Sub

    ' Register async work
    Private Sub bgw_register_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgw_register.DoWork
        Dim newUser As New Dictionary(Of String, Object)
        newUser = e.Argument

        If Database.SelectRows(_TABLE.USER, {_USER.USERNAME, "=", newUser.Item(_USER.USERNAME)}, _USER.USER_ID) Is Nothing Then
            If Database.Insert(_TABLE.USER, newUser) Then
                e.Result = 1
            Else
                e.Result = 0
            End If
        Else
            e.Result = -1
        End If

    End Sub

    ' Register complete
    Private Sub bgw_register_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw_register.RunWorkerCompleted
        ShowLoadingOverlay(False)

        Select Case e.Result
            Case 1
                MessageBox.Show("Account has been registered successfully", "Account Registration Success")
                Me.Close()
            Case 0
                MessageBox.Show("Unable to register user account", "Account Registration Failed")
            Case -1
                MessageBox.Show("Username already exist, please use a new name", "Account Registration Failed")
        End Select
    End Sub

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