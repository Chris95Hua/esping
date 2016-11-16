Public Class New_Inventory
    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        If txt_inventory.Text IsNot Nothing Then
            If Method.addInventory(txt_inventory.Text) Then
                MessageBox.Show("New item is added.")
                txt_inventory.Text = Nothing
            Else
                MessageBox.Show("Unable to add new item.")
            End If
        End If
    End Sub
End Class