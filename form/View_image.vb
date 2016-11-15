Public Class View_image
    Private imgFilePath As String

    Sub New(ByVal imgFilePath As String)
        ' This call is required by the designer.
        InitializeComponent()
        Me.imgFilePath = imgFilePath
    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        PictureBox1.Image = Method.FtpDownloadImage(imgFilePath)
    End Sub
End Class