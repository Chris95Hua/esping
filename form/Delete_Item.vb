Public Class Delete_Item

    Private Sub Delete_Item_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadInventoryItem()
    End Sub

    Private Sub btn_delete_Click(sender As Object, e As EventArgs) Handles btn_delete.Click
        Dim Box As MsgBoxResult = MsgBox("Delete the selected item?", "Confirm Deletion", MsgBoxStyle.YesNo)

        If Box = MsgBoxResult.Yes Then
            If Database.Delete(_TABLE.INVENTORY, {_INVENTORY.ITEM, "=", cb_itemName.SelectedItem}) Then
                MessageBox.Show("Item deleted", "Delete Success")
                loadInventoryItem()
            Else
                MessageBox.Show("Unable to delete item", "Delete Failed")
            End If
        End If
    End Sub

    Private Sub loadInventoryItem()
        cb_itemName.Items.Clear()

        Dim itemlist As List(Of Dictionary(Of String, Object))
        itemlist = Database.SelectAllRows(_TABLE.INVENTORY, {"*"})
        If itemlist IsNot Nothing Then
            For Each itemName In itemlist
                cb_itemName.Items.Add(itemName.Item(_INVENTORY.ITEM))
            Next
            cb_itemName.SelectedIndex = 0
        End If
    End Sub
End Class