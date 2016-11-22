Public Class Admin_Form

    Private Sub btn_passUpdate_Click(sender As Object, e As EventArgs) Handles btn_passUpdate.Click
        Dim passUpdateForm As New Update_Password
        passUpdateForm.ShowDialog()
    End Sub

    Private Sub btn_logout_Click(sender As Object, e As EventArgs) Handles btn_logout.Click
        Dim login As New Login
        login.Show()
        Me.Close()
    End Sub

    Private Sub Admin_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txt_welcome.Text = "Welcome: " + Session.first_name
    End Sub

    Private Sub RegistrationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrationToolStripMenuItem.Click
        Session.department_id = _PROCESS.ADMIN
        Dim registerForm As New Register
        registerForm.ShowDialog()
    End Sub

    Private Sub btn_ManageOrder_Click(sender As Object, e As EventArgs) Handles btn_ManageOrder.Click
        Session.department_id = _PROCESS.ADMIN
        Dim ManageForm As New Manage_Order
        ManageForm.ShowDialog()
    End Sub

    Private Sub btn_ApproveOrder_Click(sender As Object, e As EventArgs) Handles btn_ApproveOrder.Click
        Session.department_id = _PROCESS.ADMIN
        Dim ApproveForm As New Approve_Order
        ApproveForm.ShowDialog()
    End Sub

    Private Sub btn_InventoryPreparation_Click(sender As Object, e As EventArgs) Handles btn_InventoryPreparation.Click
        Session.department_id = _PROCESS.ADMIN
        Dim InventoryForm As New Inventory_Preparation
        InventoryForm.ShowDialog()
    End Sub

    Private Sub btn_CuttingDepartment_Click(sender As Object, e As EventArgs) Handles btn_CuttingDepartment.Click
        Session.department_id = _PROCESS.ADMIN
        Dim CuttingForm As New Cutting_Department
        CuttingForm.ShowDialog()
    End Sub

    Private Sub btn_EmbroideryDepartment_Click(sender As Object, e As EventArgs) Handles btn_EmbroideryDepartment.Click
        Session.department_id = _PROCESS.ADMIN
        Dim EmbroideryForm As New Embroidery_Department
        EmbroideryForm.ShowDialog()
    End Sub

    Private Sub btn_printingDepartment_Click(sender As Object, e As EventArgs) Handles btn_printingDepartment.Click
        Session.department_id = _PROCESS.ADMIN
        Dim PrintingForm As New Printing_Department
        PrintingForm.ShowDialog()
    End Sub

    Private Sub btn_SewingDepartment_Click(sender As Object, e As EventArgs) Handles btn_SewingDepartment.Click
        Session.department_id = _PROCESS.ADMIN
        Dim SewingForm As New Sewing_Department
        SewingForm.ShowDialog()
    End Sub
End Class