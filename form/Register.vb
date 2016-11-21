Public Class Register

    Private Sub Registration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each dpmt In Database.SelectAllRows(_TABLE.DEPARTMENT, {"*"})
            cb_department.Items.Add(dpmt.Item(_DEPARTMENT.NAME))
        Next

        cb_department.SelectedIndex = 0
        cb_role.SelectedIndex = 0
    End Sub

    Private Sub btn_submit_Click(sender As Object, e As EventArgs) Handles btn_submit.Click
        If txt_firstName.Text = "" Or txt_lastName.Text = "" Then
            MessageBox.Show("Please fill in all the information", "Account Registration Failed")
        ElseIf txt_password.TextLength < 4 Or txt_userName.TextLength < 4 Then
            MessageBox.Show("Password and username must contain at least 4 characters", "Account Registration Failed")
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

            If Database.Insert(_TABLE.USER, dataIn) Then
                MessageBox.Show("Account has been registered successfully", "Account Registration Success")
                Me.Close()
            Else
                MessageBox.Show("Unable to register user account", "Account Registration Failed")
            End If
        End If
    End Sub
End Class