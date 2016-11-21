Public Class New_Inventory
    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        If txt_inventory.Text IsNot String.Empty Then

            Dim invList As List(Of Dictionary(Of String, Object))
            Dim itemName As New Dictionary(Of String, Object)
            itemName.Add(_INVENTORY.ITEM, txt_inventory.Text)

            invList = Database.SelectRows(_TABLE.INVENTORY, {_INVENTORY.ITEM, "=", txt_inventory.Text})

            If invList Is Nothing Then
                If Database.Insert(_TABLE.INVENTORY, itemName) Then
                    MessageBox.Show("New item has been added", "Operation Success")
                    txt_inventory.Text = Nothing
                Else
                    MessageBox.Show("Unable to add new item", "Operation Failed")
                End If
            End If
        Else
            MessageBox.Show("Please enter the name of the item", "Operation Failed")
        End If
    End Sub
End Class