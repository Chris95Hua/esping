Public Class Inventory_Preparation
    Private loadingOverlay As Loading_Overlay
    Private loadItems As Boolean = True

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        If Session.department_id = _PROCESS.ADMIN Then
            btn_logout.Visible = False
        End If

        txt_welcome.Text = "Welcome: " + Session.first_name
        loadInventoryList()

        'set ListView column width
        With ListView1
            .Columns(0).Width = CInt(.Width * 0.6)
            .Columns(1).Width = CInt(.Width * 0.2)
            .Columns(2).Width = CInt(.Width * 0.2)
        End With

        btn_delete.Enabled = False
    End Sub

    ' Logout
    Private Sub btn_logout_Click(sender As Object, e As EventArgs) Handles btn_logout.Click
        Dim login As New Login
        login.Show()
        Me.Close()
    End Sub

    ' Open New Inventory form
    Private Sub btn_newInventorty_Click(sender As Object, e As EventArgs) Handles btn_newInventorty.Click
        Dim newInventory_form As New New_Inventory
        newInventory_form.ShowDialog()
        loadItems = True
        loadInventoryList()
    End Sub

    ' Open Delete Inventory item form
    Private Sub btn_deleteItem_Click(sender As Object, e As EventArgs) Handles btn_deleteItem.Click
        Dim deleteInventory_form As New Delete_Item
        deleteInventory_form.ShowDialog()
        loadItems = True
        loadInventoryList()

        If ListView1.Items.Count = 0 Then
            btn_delete.Enabled = False
        Else
            btn_delete.Enabled = True
        End If
    End Sub

    ' Load inventory items from database
    Private Sub loadInventoryList()
        ListBox1.Items.Clear()

        bgw_LoadSubmit.RunWorkerAsync()
        ShowLoadingOverlay(True)
    End Sub

    ' Add inventory to list
    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        If txt_measurement.Text = String.Empty Then
            MessageBox.Show("Please fill in the unit of measurement", "Error")
        Else
            Dim findItem = ListView1.FindItemWithText(ListBox1.SelectedItem)
            Dim findMeasure = ListView1.FindItemWithText(txt_measurement.Text)
            Dim tempListView As ListViewItem

            If findItem Is Nothing Or findMeasure Is Nothing Then
                tempListView = ListView1.Items.Add(ListBox1.SelectedItem)
                tempListView.SubItems.Add(nud_quantity.Value)
                tempListView.SubItems.Add(txt_measurement.Text)
            Else
                Dim curCount As Integer = findMeasure.SubItems(1).Text
                findMeasure.SubItems(1).Text = curCount + nud_quantity.Value
            End If

            btn_delete.Enabled = True
        End If
    End Sub

    ' Delete inventory from list
    Private Sub btn_delete_Click(sender As Object, e As EventArgs) Handles btn_delete.Click
        If ListView1.SelectedItems.Count > 0 Then
            ListView1.Items.RemoveAt(ListView1.SelectedIndices(0))
        End If
    End Sub

    ' Reset quantity
    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        nud_quantity.Value = 1
    End Sub

    ' Assign item to order
    Private Sub btn_submit_Click(sender As Object, e As EventArgs) Handles btn_submit.Click
        If txt_barcode.Text Is String.Empty Then
            MessageBox.Show("Please enter job sheet number", "Operation Failed")
        ElseIf Not Method.IsOrderFormat(txt_barcode.Text) Then
            MessageBox.Show("Invalid order number", "Operation Failed")
        ElseIf ListView1.Items.Count = 0 Then
            MessageBox.Show("Please add at least 1 item", "Operation Failed")
        Else
            Dim inventoryList As New Dictionary(Of String, String())
            Dim invList As New Dictionary(Of String, Object)

            For index As Integer = 0 To ListView1.Items.Count - 1
                inventoryList.Add(index, {ListView1.Items(index).SubItems(0).Text, ListView1.Items(index).SubItems(1).Text, ListView1.Items(index).SubItems(2).Text})
            Next

            invList.Add(_ORDER_CUSTOMER.INVENTORY_ORDER, Newtonsoft.Json.JsonConvert.SerializeObject(inventoryList))
            If rtb_remarks.Text IsNot String.Empty Then
                invList.Add(_ORDER_CUSTOMER.REMARKS, rtb_remarks.Text)
            End If

            invList.Add(_ORDER_CUSTOMER.ORDER_ID, Method.GetOrderID(txt_barcode.Text))

            bgw_LoadSubmit.RunWorkerAsync(invList)
            ShowLoadingOverlay(True)
        End If

    End Sub

    ' Load existing items/Insert item to order
    Private Sub bgw_LoadSubmit_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgw_LoadSubmit.DoWork
        If loadItems Then
            e.Result = Database.SelectAllRows(_TABLE.INVENTORY, {"*"})
        Else
            Dim order As New Dictionary(Of String, Object)
            order = e.Argument

            Dim orderID As Integer = order.Item(_ORDER_CUSTOMER.ORDER_ID)
            order.Remove(_ORDER_CUSTOMER.ORDER_ID)

            e.Result = Database.Update(_TABLE.ORDER_CUSTOMER, {_ORDER_CUSTOMER.ORDER_ID, "=", orderID}, order)
        End If
    End Sub

    ' Result of async task
    Private Sub bgw_LoadSubmit_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw_LoadSubmit.RunWorkerCompleted
        ShowLoadingOverlay(False)

        If (e.Error Is Nothing) Then
            If loadItems Then
                ' load items
                Dim itemlist As List(Of Dictionary(Of String, Object))
                itemlist = e.Result

                If itemlist IsNot Nothing Then
                    For Each itemName In itemlist
                        ListBox1.Items.Add(itemName.Item(_INVENTORY.ITEM))
                    Next

                    ListBox1.SelectedIndex = 0
                End If

                loadItems = False
            Else
                ' insert items
                If e.Result Then
                    MessageBox.Show("Items submitted", "Operation Success")
                    txt_barcode.Clear()
                    ListView1.Items.Clear()
                    rtb_remarks.Clear()
                    txt_measurement.Clear()
                Else
                    MessageBox.Show("An error has occurred while adding the items", "Operation Failed")
                End If
            End If
        End If
    End Sub

    ' Loading overlay
    Private Sub ShowLoadingOverlay(ByVal show As Boolean)
        If show Then
            loadingOverlay = New Loading_Overlay
            loadingOverlay.Size = New Size(Me.Width - 16, Me.Height - 38)
            loadingOverlay.ShowDialog()
        Else
            loadingOverlay.Close()
        End If
    End Sub

    ' Update password
    Private Sub btn_passUpdate_Click(sender As Object, e As EventArgs) Handles btn_passUpdate.Click
        Dim passUpdateForm As New Update_Password
        passUpdateForm.ShowDialog()
    End Sub
End Class