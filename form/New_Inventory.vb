Public Class New_Inventory
    Private loadingOverlay As Loading_Overlay

    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        If txt_inventory.Text Is String.Empty Then
            MessageBox.Show("Please enter the name of the item", "Operation Failed")
        ElseIf Not Method.IsItemName(txt_inventory.Text) Then
            MessageBox.Show("Item name can only contain alphanumeric, space, underscore, hyphen, brackets, single quote and ampersand", "Operation Failed")
        Else
            bgw_InsertItem.RunWorkerAsync(txt_inventory.Text)
            ShowLoadingOverlay(True)
        End If
    End Sub

    Private Sub bgw_InsertItem_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgw_InsertItem.DoWork
        Dim invList As List(Of Dictionary(Of String, Object))

        invList = Database.SelectRows(_TABLE.INVENTORY, {_INVENTORY.ITEM, "=", e.Argument})

        If invList Is Nothing Then
            Dim itemName As New Dictionary(Of String, Object)
            itemName.Add(_INVENTORY.ITEM, e.Argument)

            If Database.Insert(_TABLE.INVENTORY, itemName) Then
                e.Result = 1
            Else
                e.Result = 0
            End If
        Else
            e.Result = -1
        End If
    End Sub

    Private Sub bgw_InsertItem_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw_InsertItem.RunWorkerCompleted
        ShowLoadingOverlay(False)

        If (e.Error Is Nothing) Then
            Select Case e.Result
                Case -1
                    MessageBox.Show("Item already exist", "Operation Failed")
                Case 0
                    MessageBox.Show("Unable to add new item", "Operation Failed")
                Case 1
                    MessageBox.Show("New item has been added", "Operation Success")
                    txt_inventory.Clear()
            End Select
        End If
    End Sub

    Private Sub ShowLoadingOverlay(ByVal show As Boolean)
        If show Then
            loadingOverlay = New Loading_Overlay
            loadingOverlay.Size = New Size(Me.Width - 16, Me.Height - 38)
            loadingOverlay.ShowDialog()
        Else
            loadingOverlay.Close()
        End If
    End Sub
End Class