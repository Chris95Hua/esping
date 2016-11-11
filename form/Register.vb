Public Class Register

    Private Sub Registration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dpmts As List(Of Dictionary(Of String, Object))
        dpmts = Database.SelectAllRows(TABLE.DEPARTMENT, {"*"})
        For Each dpmt In dpmts
            cb_department.Items.Add(dpmt.Item(DEPARTMENT.NAME))
        Next
        cb_department.SelectedIndex = 0
        cb_role.SelectedIndex = 0
    End Sub

    Private Sub btn_submit_Click(sender As Object, e As EventArgs) Handles btn_submit.Click
        If txt_firstName.Text = "" Or txt_lastName.Text = "" Or txt_password.Text = "" Or txt_userName.Text = "" Then
            MessageBox.Show("Please fill in all the information.")
        Else
            Dim newUser As New Dictionary(Of String, Object)
            Dim salt As String = Security.GenerateSalt()

            newUser.Add(USER.FIRST_NAME, txt_firstName.Text)
            newUser.Add(USER.LAST_NAME, txt_lastName.Text)
            newUser.Add(USER.USERNAME, txt_userName.Text)
            newUser.Add(USER.SALT, salt)
            newUser.Add(USER.PASSWORD, Security.Hash(txt_password.Text, salt))
            newUser.Add(USER.DEPARTMENT_ID, cb_department.SelectedIndex)
            newUser.Add(USER.ROLE, cb_role.SelectedIndex)
            newUser.Add(USER.C_USER, Session.user_id)
            newUser.Add(USER.C_DATE, DateTime.Now)

            If Database.Insert(TABLE.USER, newUser) Then
                MessageBox.Show("You have successfully registered")
                Me.Close()
            Else
                MessageBox.Show("Username already existed.")
            End If
        End If
    End Sub
End Class