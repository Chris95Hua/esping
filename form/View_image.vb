Public Class View_image
    Private loadingOverlay As Loading_Overlay
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
        ShowLoadingOverlay(True)
    End Sub

    Private Sub bgw_ImgLoader_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgw_ImgLoader.DoWork
        e.Result = Method.FtpDownload(imgDir, imgFilePath)
    End Sub

    Private Sub bgw_ImgLoader_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw_ImgLoader.RunWorkerCompleted
        ShowLoadingOverlay(False)

        If (e.Error Is Nothing) Then
            If e.Result IsNot Nothing Then
                PictureBox1.Image = Image.FromStream(e.Result)
            Else
                MessageBox.Show("No image found", "Error")
                Me.Close()
            End If
        End If
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