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
        loadInventoryList()
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
        Dim findText = ListView1.FindItemWithText(ListBox1.SelectedItem)
        If findText Is Nothing Then
            Dim tempListView As ListViewItem
            tempListView = ListView1.Items.Add(ListBox1.SelectedItem)
            tempListView.SubItems.Add(nud_quantity.Value).ToString()
        Else
            MessageBox.Show("Item already existed.")
        End If
    End Sub

    Private Sub btn_delete_Click(sender As Object, e As EventArgs) Handles btn_delete.Click
        ListView1.Items.RemoveAt(ListView1.SelectedIndices(0))
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        nud_quantity.Value = 1
    End Sub

    Private Sub btn_submit_Click(sender As Object, e As EventArgs) Handles btn_submit.Click
        Dim inventoryList As New Dictionary(Of String, Object)
        If ListView1.Items.Count > 0 Then
            For index As Integer = 0 To ListView1.Items.Count - 1
                inventoryList.Add(ListView1.Items(index).SubItems(0).Text, ListView1.Items(index).SubItems(1).Text)
            Next
            Dim invList As New Dictionary(Of String, Object)
            invList.Add(_ORDER_CUSTOMER.INVENTORY_ORDER, Newtonsoft.Json.JsonConvert.SerializeObject(inventoryList))
            If Database.Update(_TABLE.ORDER_CUSTOMER, {_ORDER_CUSTOMER.ORDER_ID, "=", txt_barcode.Text}, invList) Then
                MessageBox.Show("Items submitted.")
                txt_barcode.Text = ""
                ListView1.Items.Clear()
            Else
                MessageBox.Show("Unable to submit the items.")
            End If
        End If
    End Sub
End Class