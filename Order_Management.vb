Public Class Order_Management

    Private Sub btn_logout_Click(sender As Object, e As EventArgs) Handles btn_logout.Click

    End Sub

    Private Sub btn_newOrder_Click(sender As Object, e As EventArgs) Handles btn_newOrder.Click
        Dim newOrderForm = New new_order
        newOrderForm.Show()
    End Sub

    Private Sub txt_Search_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.GotFocus
        txt_search.Text = ""
    End Sub

    Private Sub btn_search_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.LostFocus
        If txt_search.Text = "" Then
            txt_search.Text = "Search"
        End If
    End Sub

    Private Sub dgv_details_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btn_passUpdate_Click(sender As Object, e As EventArgs) Handles btn_passUpdate.Click
        Dim passUpdateForm = New Password_Update
        passUpdateForm.Show()
    End Sub

    Private Sub btn_edit_Click(sender As Object, e As EventArgs) Handles btn_edit.Click
        Dim editDeliveryForm = New Edit_Delivery_Date
        editDeliveryForm.Show()
    End Sub
End Class