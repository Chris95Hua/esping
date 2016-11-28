<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_Form
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.RegistrationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_passUpdate = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_logout = New System.Windows.Forms.ToolStripMenuItem()
        Me.txt_welcome = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_ManageOrder = New System.Windows.Forms.Button()
        Me.btn_ApproveOrder = New System.Windows.Forms.Button()
        Me.btn_InventoryPreparation = New System.Windows.Forms.Button()
        Me.btn_SewingDepartment = New System.Windows.Forms.Button()
        Me.btn_CuttingDepartment = New System.Windows.Forms.Button()
        Me.btn_printingDepartment = New System.Windows.Forms.Button()
        Me.btn_EmbroideryDepartment = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btn_job = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegistrationToolStripMenuItem, Me.btn_passUpdate, Me.btn_logout, Me.txt_welcome})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(672, 24)
        Me.MenuStrip1.TabIndex = 6
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'RegistrationToolStripMenuItem
        '
        Me.RegistrationToolStripMenuItem.Name = "RegistrationToolStripMenuItem"
        Me.RegistrationToolStripMenuItem.Size = New System.Drawing.Size(80, 20)
        Me.RegistrationToolStripMenuItem.Text = "+ New User"
        '
        'btn_passUpdate
        '
        Me.btn_passUpdate.Name = "btn_passUpdate"
        Me.btn_passUpdate.Size = New System.Drawing.Size(110, 20)
        Me.btn_passUpdate.Text = "Password Update"
        '
        'btn_logout
        '
        Me.btn_logout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btn_logout.BackColor = System.Drawing.Color.DarkOrange
        Me.btn_logout.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_logout.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_logout.Margin = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.btn_logout.Name = "btn_logout"
        Me.btn_logout.Size = New System.Drawing.Size(58, 20)
        Me.btn_logout.Text = "Logout"
        Me.btn_logout.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        '
        'txt_welcome
        '
        Me.txt_welcome.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.txt_welcome.Enabled = False
        Me.txt_welcome.Name = "txt_welcome"
        Me.txt_welcome.Size = New System.Drawing.Size(112, 20)
        Me.txt_welcome.Text = "Welcome: Nelson"
        '
        'btn_ManageOrder
        '
        Me.btn_ManageOrder.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_ManageOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ManageOrder.Location = New System.Drawing.Point(20, 19)
        Me.btn_ManageOrder.Margin = New System.Windows.Forms.Padding(20, 19, 20, 19)
        Me.btn_ManageOrder.Name = "btn_ManageOrder"
        Me.btn_ManageOrder.Size = New System.Drawing.Size(177, 102)
        Me.btn_ManageOrder.TabIndex = 1
        Me.btn_ManageOrder.Text = "Manage Order"
        Me.btn_ManageOrder.UseVisualStyleBackColor = True
        '
        'btn_ApproveOrder
        '
        Me.btn_ApproveOrder.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_ApproveOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ApproveOrder.Location = New System.Drawing.Point(237, 19)
        Me.btn_ApproveOrder.Margin = New System.Windows.Forms.Padding(20, 19, 20, 19)
        Me.btn_ApproveOrder.Name = "btn_ApproveOrder"
        Me.btn_ApproveOrder.Size = New System.Drawing.Size(177, 102)
        Me.btn_ApproveOrder.TabIndex = 2
        Me.btn_ApproveOrder.Text = "Approve Order"
        Me.btn_ApproveOrder.UseVisualStyleBackColor = True
        '
        'btn_InventoryPreparation
        '
        Me.btn_InventoryPreparation.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_InventoryPreparation.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_InventoryPreparation.Location = New System.Drawing.Point(454, 19)
        Me.btn_InventoryPreparation.Margin = New System.Windows.Forms.Padding(20, 19, 20, 19)
        Me.btn_InventoryPreparation.Name = "btn_InventoryPreparation"
        Me.btn_InventoryPreparation.Size = New System.Drawing.Size(178, 102)
        Me.btn_InventoryPreparation.TabIndex = 3
        Me.btn_InventoryPreparation.Text = "Inventory Preparation"
        Me.btn_InventoryPreparation.UseVisualStyleBackColor = True
        '
        'btn_SewingDepartment
        '
        Me.btn_SewingDepartment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_SewingDepartment.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_SewingDepartment.Location = New System.Drawing.Point(20, 299)
        Me.btn_SewingDepartment.Margin = New System.Windows.Forms.Padding(20, 19, 20, 19)
        Me.btn_SewingDepartment.Name = "btn_SewingDepartment"
        Me.btn_SewingDepartment.Size = New System.Drawing.Size(177, 103)
        Me.btn_SewingDepartment.TabIndex = 7
        Me.btn_SewingDepartment.Text = "Sewing Department"
        Me.btn_SewingDepartment.UseVisualStyleBackColor = True
        '
        'btn_CuttingDepartment
        '
        Me.btn_CuttingDepartment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_CuttingDepartment.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_CuttingDepartment.Location = New System.Drawing.Point(20, 159)
        Me.btn_CuttingDepartment.Margin = New System.Windows.Forms.Padding(20, 19, 20, 19)
        Me.btn_CuttingDepartment.Name = "btn_CuttingDepartment"
        Me.btn_CuttingDepartment.Size = New System.Drawing.Size(177, 102)
        Me.btn_CuttingDepartment.TabIndex = 4
        Me.btn_CuttingDepartment.Text = "Cutting Department"
        Me.btn_CuttingDepartment.UseVisualStyleBackColor = True
        '
        'btn_printingDepartment
        '
        Me.btn_printingDepartment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_printingDepartment.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_printingDepartment.Location = New System.Drawing.Point(454, 159)
        Me.btn_printingDepartment.Margin = New System.Windows.Forms.Padding(20, 19, 20, 19)
        Me.btn_printingDepartment.Name = "btn_printingDepartment"
        Me.btn_printingDepartment.Size = New System.Drawing.Size(178, 102)
        Me.btn_printingDepartment.TabIndex = 6
        Me.btn_printingDepartment.Text = "Printing Department"
        Me.btn_printingDepartment.UseVisualStyleBackColor = True
        '
        'btn_EmbroideryDepartment
        '
        Me.btn_EmbroideryDepartment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_EmbroideryDepartment.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_EmbroideryDepartment.Location = New System.Drawing.Point(237, 159)
        Me.btn_EmbroideryDepartment.Margin = New System.Windows.Forms.Padding(20, 19, 20, 19)
        Me.btn_EmbroideryDepartment.Name = "btn_EmbroideryDepartment"
        Me.btn_EmbroideryDepartment.Size = New System.Drawing.Size(177, 102)
        Me.btn_EmbroideryDepartment.TabIndex = 5
        Me.btn_EmbroideryDepartment.Text = "Embroidery Department"
        Me.btn_EmbroideryDepartment.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel1.Controls.Add(Me.btn_ManageOrder, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_ApproveOrder, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_InventoryPreparation, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_SewingDepartment, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_CuttingDepartment, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_printingDepartment, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_EmbroideryDepartment, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_job, 1, 2)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(8, 38)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(652, 421)
        Me.TableLayoutPanel1.TabIndex = 7
        '
        'btn_job
        '
        Me.btn_job.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_job.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_job.Location = New System.Drawing.Point(237, 299)
        Me.btn_job.Margin = New System.Windows.Forms.Padding(20, 19, 20, 19)
        Me.btn_job.Name = "btn_job"
        Me.btn_job.Size = New System.Drawing.Size(177, 103)
        Me.btn_job.TabIndex = 7
        Me.btn_job.Text = "Job Schedule"
        Me.btn_job.UseVisualStyleBackColor = True
        '
        'Admin_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(672, 474)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.MinimumSize = New System.Drawing.Size(688, 513)
        Me.Name = "Admin_Form"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Admin Form"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents RegistrationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn_passUpdate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn_logout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txt_welcome As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn_ManageOrder As System.Windows.Forms.Button
    Friend WithEvents btn_ApproveOrder As System.Windows.Forms.Button
    Friend WithEvents btn_InventoryPreparation As System.Windows.Forms.Button
    Friend WithEvents btn_SewingDepartment As System.Windows.Forms.Button
    Friend WithEvents btn_CuttingDepartment As System.Windows.Forms.Button
    Friend WithEvents btn_printingDepartment As System.Windows.Forms.Button
    Friend WithEvents btn_EmbroideryDepartment As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btn_job As Button
End Class
