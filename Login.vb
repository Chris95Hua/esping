Public Class Login
    Private Sub GenerateBarcode_Click(sender As Object, e As EventArgs) Handles btn_generateBarcode.Click
        Dim barcode128 As Zen.Barcode.Code128BarcodeDraw = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum
        ' return image file
        ' text, height, scale
        pic_barcode.Image = barcode128.Draw(txt_barcodeText.Text, 40, 2)
    End Sub


    Private Sub LogIn_Click(sender As Object, e As EventArgs) Handles btn_login.Click
        ' ADD
        Dim asd As Integer = Constant.LOGIN.FAILED
        Dim salt As String = Security.GenerateSalt()
        Dim test As New Dictionary(Of String, Object)
        test.Add("username", "dikur")
        test.Add("password", Security.Hash("123456", salt))
        test.Add("salt", salt)
        'Database.Insert("user", test)


        ' UPDATE
        Dim update As New Dictionary(Of String, Object)
        update.Add("username", "    chye yee")
        'Database.Update("user", "user_id", 11, update)


        ' DELETE
        ' Database.Delete("user", "user_id", 5)


        ' SELECT MULTIPLE
        Dim dictionaries As New List(Of Dictionary(Of String, Object))
        'dictionaries = Database.SelectFromTable("user", "username")
        'dictionaries = Database.SelectRows("user", "username", "chye")

        ' printing
        'For Each dictionary In dictionaries
        'For Each pair In dictionary
        'Console.WriteLine(pair.Key & ": " & pair.Value)
        'Next
        'Next


        ' SELECT SINGLE
        'Dim dictionary As New Dictionary(Of String, Object)
        'Dictionary = Database.SelectRow("user", "username", "chyee")
        'If dictionary Is Nothing Then
        'Console.WriteLine("null")
        'Else
        'For Each pair In dictionary
        'Console.WriteLine(pair.Key & ": " & pair.Value)
        'Next
        'End If

        ''Method.Login("chye Yee", "123456")

    End Sub
End Class
