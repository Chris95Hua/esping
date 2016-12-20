Public Class Edit_Delivery_Date
    Sub New(ByVal oldDate As Date, ByVal issueDate As Date)
        ' This call is required by the designer.
        InitializeComponent()

        d_newDeliveryDate.MinDate = issueDate
        d_newDeliveryDate.Value = oldDate
    End Sub

    ' Return result to Order Management form
    Private Sub btn_update_Click(sender As Object, e As EventArgs) Handles btn_update.Click
        Me.DialogResult = DialogResult.OK
    End Sub
End Class