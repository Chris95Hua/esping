Public Class Generate_Barcode
    Private fontSizeNormal As Integer = 10                     ' normal font size (text below barcode)
    Private fontFamily As String = "arial"

    Dim orderID As String
    Dim barcodeImage As Image

    Sub New(ByVal orderID As String)
        ' This call is required by the designer.
        InitializeComponent()

        Dim scale As Integer = 2
        If orderID.Length > 4 Then
            scale = 1
        End If

        Me.orderID = orderID
        'Me.orderID = "121-2332311a"

        Dim barcode128 As Zen.Barcode.Code128BarcodeDraw = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum
        barcodeImage = barcode128.Draw(Me.orderID, 60, scale)

        ' Printer settings
        ' ===================================
        ' TODO: configure papersize
        pd_barcode.DefaultPageSettings.PaperSize = New Printing.PaperSize("Barcode Sticker", 189, 106)

        ppd_barcode.Document = pd_barcode
    End Sub

    Private Sub PrintBarcode(ByVal sender As Object, ByVal e As Printing.PrintPageEventArgs) Handles pd_barcode.PrintPage
        Dim xOrigin As Integer = Math.Floor((pd_barcode.DefaultPageSettings.PaperSize.Width() - pd_barcode.DefaultPageSettings.PrintableArea.Width()) / 2)
        Dim yOrigin As Integer = Math.Floor((pd_barcode.DefaultPageSettings.PaperSize.Height() - pd_barcode.DefaultPageSettings.PrintableArea.Height()) / 2)

        ' text format
        Dim formatCenter As New StringFormat()
        formatCenter.Alignment = StringAlignment.Center

        ' pen for drawing lines and rounded rectangle
        Dim linePen As New Pen(Color.Black, 2)

        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        ' scale barcode
        Dim scale As Double = 0.36
        Dim scaledBarcode As New Bitmap(barcodeImage, CInt(barcodeImage.Width * scale), CInt(barcodeImage.Height * scale))

        ' barcode
        Dim totalHeight As Integer = scaledBarcode.Height + 10 + fontSizeNormal
        Dim barcodeX As Integer = ((pd_barcode.DefaultPageSettings.PaperSize.Width() - scaledBarcode.Width) / 2) - 3
        Dim barcodeY As Integer = (pd_barcode.DefaultPageSettings.PaperSize.Height() - totalHeight) / 2

        e.Graphics.DrawImage(scaledBarcode, barcodeX, barcodeY)

        ' barcode text
        e.Graphics.DrawString(orderID, New Font(fontFamily, fontSizeNormal), New SolidBrush(Color.Black), pd_barcode.DefaultPageSettings.PaperSize.Width() / 2, barcodeY + scaledBarcode.Height + 10, formatCenter)

        linePen.Dispose()
    End Sub

    Private Sub btn_preview_Click(sender As Object, e As EventArgs) Handles btn_preview.Click
        ppd_barcode.ShowDialog()
    End Sub

    Private Sub btn_printer_Click(sender As Object, e As EventArgs) Handles btn_printer.Click
        pdg_settings.AllowPrintToFile = False

        If pdg_settings.ShowDialog = DialogResult.OK Then
            pd_barcode.PrinterSettings = pdg_settings.PrinterSettings
            pd_barcode.Print()
        End If
    End Sub

    Private Sub btn_print_Click(sender As Object, e As EventArgs) Handles btn_print.Click
        pd_barcode.Print()
    End Sub
End Class