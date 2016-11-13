Public Class Inventory_Preparation

    Private Sub btn_logout_Click(sender As Object, e As EventArgs) Handles btn_logout.Click
        Dim login As New Login
        login.Show()
        Me.Close()
    End Sub

    Private Sub Inventory_Preparation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txt_welcome.Text = "Welcome: " + Session.first_name
    End Sub
End Class