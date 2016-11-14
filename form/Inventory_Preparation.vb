Public Class Inventory_Preparation
    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        txt_welcome.Text = "Welcome: " + Session.first_name
    End Sub


    Private Sub btn_logout_Click(sender As Object, e As EventArgs) Handles btn_logout.Click
        Dim login As New Login
        login.Show()
        Me.Close()
    End Sub
End Class