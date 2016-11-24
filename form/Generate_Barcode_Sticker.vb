Public Class Generate_Barcode_Sticker
    Private order As New Dictionary(Of String, Object)

    Sub New(ByVal orderDetails As Dictionary(Of String, Object))
        ' This call is required by the designer.
        InitializeComponent()

        order = orderDetails
        ' get order from order details/sewing department
    End Sub

    Private Sub btn_print_Click(sender As Object, e As EventArgs) Handles btn_print.Click
        ' generate sticker

        order.Add(_BADGE.BAG, num_bags.Value)

        ' max 26 barcode digit for default size
        'PictureBox1.Image = Method.GenerateBarcodeLabel(order)
    End Sub
End Class