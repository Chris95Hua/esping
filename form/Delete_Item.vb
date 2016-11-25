Public Class Delete_Item
    Private loadingOverlay As Loading_Overlay
    Private loadItems As Boolean = True

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        bgw_LoadDelete.RunWorkerAsync()
        ShowLoadingOverlay(True)
    End Sub

    ' Start async task
    Private Sub btn_delete_Click(sender As Object, e As EventArgs) Handles btn_delete.Click
        Dim Box As MsgBoxResult = MsgBox("Delete the selected item?", MsgBoxStyle.YesNo, "Confirm Deletion")

        If Box = MsgBoxResult.Yes Then
            bgw_LoadDelete.RunWorkerAsync(cb_itemName.SelectedItem)
            ShowLoadingOverlay(True)
        End If
    End Sub

    ' Start async task
    Private Sub bgw_LoadDelete_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgw_LoadDelete.DoWork
        If loadItems Then
            ' load inventory item
            e.Result = Database.SelectAllRows(_TABLE.INVENTORY, {"*"})
        Else
            ' remove inventory item
            e.Result = Database.Delete(_TABLE.INVENTORY, {_INVENTORY.ITEM, "=", e.Argument})
        End If
    End Sub

    ' Async task result
    Private Sub bgw_LoadDelete_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw_LoadDelete.RunWorkerCompleted
        ShowLoadingOverlay(False)

        If (e.Error Is Nothing) Then
            If loadItems Then
                ' load inventory item
                Dim itemlist As List(Of Dictionary(Of String, Object))
                itemlist = e.Result

                If itemlist IsNot Nothing Then
                    For Each itemName In itemlist
                        cb_itemName.Items.Add(itemName.Item(_INVENTORY.ITEM))
                    Next
                End If

                loadItems = False
            Else
                ' remove inventory item
                If e.Result Then
                    MessageBox.Show("Item deleted", "Delete Success")
                    cb_itemName.Items.Remove(cb_itemName.SelectedItem)
                Else
                    MessageBox.Show("Unable to delete item", "Delete Failed")
                End If
            End If

            If cb_itemName.Items.Count = 0 Then
                cb_itemName.Enabled = False
                btn_delete.Enabled = False
            Else
                cb_itemName.SelectedIndex = 0
            End If
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