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
            If Method.Registration(txt_firstName.Text, txt_lastName.Text, cb_department.SelectedIndex, cb_role.SelectedIndex, txt_userName.Text, txt_password.Text) Then
                MessageBox.Show("You have successfully registered")
                Me.Close()
            Else
                MessageBox.Show("Username already existed.")
            End If
        End If
    End Sub
End Class