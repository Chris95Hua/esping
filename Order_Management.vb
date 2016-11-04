Public Class Order_Management

    Private Sub btn_passUpdate_Click(sender As Object, e As EventArgs) Handles btn_passUpdate.Click

    End Sub

    Private Sub btn_logout_Click(sender As Object, e As EventArgs) Handles btn_logout.Click

    End Sub

    Private Sub btn_newOrder_Click(sender As Object, e As EventArgs) Handles btn_newOrder.Click

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
End Class