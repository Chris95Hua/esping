Public Class Edit_Delivery_Date
    Sub New(ByVal oldDate As Date)
        ' This call is required by the designer.
        InitializeComponent()

        d_newDeliveryDate.Value = oldDate
    End Sub

    Private Sub btn_update_Click(sender As Object, e As EventArgs) Handles btn_update.Click
        Me.DialogResult = DialogResult.OK
    End Sub
End Class