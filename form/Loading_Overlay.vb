Public Class Loading_Overlay
    Private Sub Loading_Overlay_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top += 11
        Dim imageSize As Integer = 70

        pb_loading.Width = imageSize
        pb_loading.Height = imageSize
        pb_loading.Location = New Point((Me.Width - imageSize) / 2, (Me.Height - (2 * imageSize)) / 2)
        lbl_loading.Location = New Point((Me.Width - lbl_loading.Width) / 2, (Me.Height - lbl_loading.Height + (imageSize / 2)) / 2)
    End Sub
End Class