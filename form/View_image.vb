Public Class View_image
    Private imgDir As String
    Private imgFilePath As String

    Sub New(ByVal dir As String, ByVal filePath As String)
        ' This call is required by the designer.
        InitializeComponent()

        Me.imgDir = dir
        Me.imgFilePath = filePath
    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        bgw_ImgLoader.RunWorkerAsync()
    End Sub

    Private Sub bgw_ImgLoader_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgw_ImgLoader.DoWork
        e.Result = Method.FtpDownload(Dir, imgFilePath)
    End Sub

    Private Sub bgw_ImgLoader_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw_ImgLoader.RunWorkerCompleted
        If (e.Error Is Nothing) Then
            PictureBox1.Image = Image.FromStream(e.Result)
        End If
    End Sub
End Class