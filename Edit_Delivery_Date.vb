Public Class Edit_Delivery_Date
    Private Sub form_load(sender As Object, e As System.EventArgs) Handles Me.Load
        d_newDeliveryDate.Value = DateTime.Now
    End Sub

    Private Sub btn_update_Click(sender As Object, e As EventArgs) Handles btn_update.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class