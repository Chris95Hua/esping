Public Class Admin_Form
    ' Form load
    Private Sub Admin_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txt_welcome.Text = "Welcome: " + Session.first_name
    End Sub

    ' Update password
    Private Sub btn_passUpdate_Click(sender As Object, e As EventArgs) Handles btn_passUpdate.Click
        Dim passUpdateForm As New Update_Password
        passUpdateForm.ShowDialog()
    End Sub

    ' Logout
    Private Sub btn_logout_Click(sender As Object, e As EventArgs) Handles btn_logout.Click
        Dim login As New Login
        login.Show()
        Me.Close()
    End Sub

    ' Register user
    Private Sub RegistrationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrationToolStripMenuItem.Click
        Session.department_id = _PROCESS.ADMIN
        Dim registerForm As New Register
        registerForm.ShowDialog()
    End Sub

    ' Manage order form
    Private Sub btn_ManageOrder_Click(sender As Object, e As EventArgs) Handles btn_ManageOrder.Click
        Session.department_id = _PROCESS.ADMIN
        Dim manageForm As New Manage_Order
        manageForm.ShowDialog()
    End Sub

    ' Approve order form
    Private Sub btn_ApproveOrder_Click(sender As Object, e As EventArgs) Handles btn_ApproveOrder.Click
        Session.department_id = _PROCESS.ADMIN
        Dim approveForm As New Approve_Order
        approveForm.ShowDialog()
    End Sub

    ' Inventory preparation form
    Private Sub btn_InventoryPreparation_Click(sender As Object, e As EventArgs) Handles btn_InventoryPreparation.Click
        Session.department_id = _PROCESS.ADMIN
        Dim inventoryForm As New Inventory_Preparation
        inventoryForm.ShowDialog()
    End Sub

    ' Cutting department form
    Private Sub btn_CuttingDepartment_Click(sender As Object, e As EventArgs) Handles btn_CuttingDepartment.Click
        Session.department_id = _PROCESS.ADMIN
        Dim cuttingForm As New Cutting_Department
        cuttingForm.ShowDialog()
    End Sub

    ' Embroidery department form
    Private Sub btn_EmbroideryDepartment_Click(sender As Object, e As EventArgs) Handles btn_EmbroideryDepartment.Click
        Session.department_id = _PROCESS.ADMIN
        Dim embroideryForm As New Embroidery_Department
        embroideryForm.ShowDialog()
    End Sub

    ' Printing department form
    Private Sub btn_printingDepartment_Click(sender As Object, e As EventArgs) Handles btn_printingDepartment.Click
        Session.department_id = _PROCESS.ADMIN
        Dim printingForm As New Printing_Department
        printingForm.ShowDialog()
    End Sub

    ' Sewing department form
    Private Sub btn_SewingDepartment_Click(sender As Object, e As EventArgs) Handles btn_SewingDepartment.Click
        Session.department_id = _PROCESS.ADMIN
        Dim sewingForm As New Sewing_Department
        sewingForm.ShowDialog()
    End Sub

    ' Live update report
    Private Sub btn_job_Click(sender As Object, e As EventArgs) Handles btn_job.Click
        Session.department_id = _PROCESS.ADMIN
        Dim jobForm As New Live_Update
        jobForm.ShowDialog()
    End Sub
End Class