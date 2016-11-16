Public Class Inventory_Preparation
    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        txt_welcome.Text = "Welcome: " + Session.first_name
        loadInventoryList()
    End Sub

    Private Sub btn_logout_Click(sender As Object, e As EventArgs) Handles btn_logout.Click
        Dim login As New Login
        login.Show()
        Me.Close()
    End Sub

    Private Sub btn_newInventorty_Click(sender As Object, e As EventArgs) Handles btn_newInventorty.Click
        Dim newInventory_form As New New_Inventory
        newInventory_form.ShowDialog()
        loadInventoryList()
    End Sub

    Private Sub btn_deleteItem_Click(sender As Object, e As EventArgs) Handles btn_deleteItem.Click
        Dim deleteInventory_form As New Delete_Item
        deleteInventory_form.ShowDialog()
    End Sub

    Private Sub loadInventoryList()
        ListBox1.Items.Clear()

        Dim itemlist As List(Of Dictionary(Of String, Object))
        itemlist = Database.SelectAllRows(_TABLE.INVENTORY, {"*"})
        If itemlist IsNot Nothing Then
            For Each itemName In itemlist
                ListBox1.Items.Add(itemName.Item(_INVENTORY.ITEM))
            Next
            ListBox1.SelectedIndex = 0
        End If
    End Sub

    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        If Not ListBox2.Items.Contains(ListBox1.SelectedItem) Then
            ListBox2.Items.Add(ListBox1.SelectedItem)
        Else
            MessageBox.Show("Item already existed.")
        End If
    End Sub

    Private Sub btn_delete_Click(sender As Object, e As EventArgs) Handles btn_delete.Click
        ListBox2.Items.Remove(ListBox2.SelectedItem)
    End Sub
End Class