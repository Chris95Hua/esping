Public Class Generate_Barcode
    Dim orderID As Integer

    Sub New(ByVal orderID As Integer)
        InitializeComponent()

        Me.orderID = orderID
    End Sub

    Private Sub btn_print_Click(sender As Object, e As EventArgs) Handles btn_print.Click
        ' insert data into database
        Dim bags As New Dictionary(Of String, Object)
        If txt_back.Text IsNot Nothing Then
            bags.Add(_JSON_FIELD.BACK, txt_back.Text)
        End If

        If txt_front.Text IsNot Nothing Then
            bags.Add(_JSON_FIELD.FRONT, txt_front.Text)
        End If

        If txt_sleeve.Text IsNot Nothing Then
            bags.Add(_JSON_FIELD.SLEEVE, txt_sleeve.Text)
        End If

        Dim order As New Dictionary(Of String, Object)
        order.Add(_ORDER_CUSTOMER.PRODUCTION_PARTS, Newtonsoft.Json.JsonConvert.SerializeObject(bags))

        Database.Update(_TABLE.ORDER_CUSTOMER, {_ORDER_CUSTOMER.ORDER_ID, "=", orderID}, order)

        ' generate barcode
        Dim barcode128 As Zen.Barcode.Code128BarcodeDraw = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum
        Dim barcode As Image = barcode128.Draw(orderID, 60, 2)
    End Sub
End Class