<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Manage_Order
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Manage_Order))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btn_newOrder = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_passUpdate = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_logout = New System.Windows.Forms.ToolStripMenuItem()
        Me.txt_welcome = New System.Windows.Forms.ToolStripMenuItem()
        Me.txt_search = New System.Windows.Forms.TextBox()
        Me.dgv_details = New System.Windows.Forms.DataGridView()
        Me.order_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.customer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.order_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.issue_date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.delivery_date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btn_edit = New System.Windows.Forms.Button()
        Me.btn_delete = New System.Windows.Forms.Button()
        Me.bgw_OrderLoader = New System.ComponentModel.BackgroundWorker()
        Me.btn_refresh = New System.Windows.Forms.Button()
        Me.bgw_OrderDelete = New System.ComponentModel.BackgroundWorker()
        Me.lbl_page = New System.Windows.Forms.Label()
        Me.btn_next = New System.Windows.Forms.Button()
        Me.btn_previous = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgv_details, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_newOrder, Me.btn_passUpdate, Me.btn_logout, Me.txt_welcome})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1008, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'btn_newOrder
        '
        Me.btn_newOrder.Name = "btn_newOrder"
        Me.btn_newOrder.Size = New System.Drawing.Size(87, 20)
        Me.btn_newOrder.Text = "+ New Order"
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
        'txt_search
        '
        Me.txt_search.ForeColor = System.Drawing.SystemColors.GrayText
        Me.txt_search.Location = New System.Drawing.Point(15, 47)
        Me.txt_search.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.txt_search.MaxLength = 10
        Me.txt_search.Name = "txt_search"
        Me.txt_search.Size = New System.Drawing.Size(309, 20)
        Me.txt_search.TabIndex = 1
        Me.txt_search.Text = "Search"
        '
        'dgv_details
        '
        Me.dgv_details.AllowUserToAddRows = False
        Me.dgv_details.AllowUserToDeleteRows = False
        Me.dgv_details.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_details.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv_details.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_details.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.order_id, Me.customer, Me.order_name, Me.issue_date, Me.delivery_date, Me.status})
        Me.dgv_details.Enabled = False
        Me.dgv_details.Location = New System.Drawing.Point(12, 85)
        Me.dgv_details.MultiSelect = False
        Me.dgv_details.Name = "dgv_details"
        Me.dgv_details.ReadOnly = True
        Me.dgv_details.RowTemplate.Height = 28
        Me.dgv_details.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_details.Size = New System.Drawing.Size(978, 569)
        Me.dgv_details.TabIndex = 3
        '
        'order_id
        '
        Me.order_id.DataPropertyName = "order_id"
        Me.order_id.HeaderText = "Job Sheet No."
        Me.order_id.Name = "order_id"
        Me.order_id.ReadOnly = True
        '
        'customer
        '
        Me.customer.DataPropertyName = "customer"
        Me.customer.HeaderText = "Customer Name"
        Me.customer.Name = "customer"
        Me.customer.ReadOnly = True
        '
        'order_name
        '
        Me.order_name.DataPropertyName = "order_name"
        Me.order_name.HeaderText = "Order Name"
        Me.order_name.Name = "order_name"
        Me.order_name.ReadOnly = True
        '
        'issue_date
        '
        Me.issue_date.DataPropertyName = "issue_date"
        Me.issue_date.HeaderText = "Issue Date"
        Me.issue_date.Name = "issue_date"
        Me.issue_date.ReadOnly = True
        '
        'delivery_date
        '
        Me.delivery_date.DataPropertyName = "delivery_date"
        Me.delivery_date.HeaderText = "Delivery Date"
        Me.delivery_date.Name = "delivery_date"
        Me.delivery_date.ReadOnly = True
        '
        'status
        '
        Me.status.DataPropertyName = "status"
        Me.status.HeaderText = "Status"
        Me.status.Name = "status"
        Me.status.ReadOnly = True
        '
        'btn_edit
        '
        Me.btn_edit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_edit.Location = New System.Drawing.Point(703, 667)
        Me.btn_edit.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.btn_edit.Name = "btn_edit"
        Me.btn_edit.Size = New System.Drawing.Size(136, 28)
        Me.btn_edit.TabIndex = 6
        Me.btn_edit.Text = "Edit"
        Me.btn_edit.UseVisualStyleBackColor = True
        '
        'btn_delete
        '
        Me.btn_delete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_delete.Location = New System.Drawing.Point(851, 667)
        Me.btn_delete.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.btn_delete.Name = "btn_delete"
        Me.btn_delete.Size = New System.Drawing.Size(136, 28)
        Me.btn_delete.TabIndex = 7
        Me.btn_delete.Text = "Delete"
        Me.btn_delete.UseVisualStyleBackColor = True
        '
        'bgw_OrderLoader
        '
        '
        'btn_refresh
        '
        Me.btn_refresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_refresh.Location = New System.Drawing.Point(878, 38)
        Me.btn_refresh.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btn_refresh.Name = "btn_refresh"
        Me.btn_refresh.Size = New System.Drawing.Size(111, 39)
        Me.btn_refresh.TabIndex = 2
        Me.btn_refresh.Text = "Refresh"
        Me.btn_refresh.UseVisualStyleBackColor = True
        '
        'bgw_OrderDelete
        '
        '
        'lbl_page
        '
        Me.lbl_page.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_page.AutoSize = True
        Me.lbl_page.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_page.Location = New System.Drawing.Point(174, 673)
        Me.lbl_page.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_page.MinimumSize = New System.Drawing.Size(100, 0)
        Me.lbl_page.Name = "lbl_page"
        Me.lbl_page.Size = New System.Drawing.Size(100, 17)
        Me.lbl_page.TabIndex = 9
        Me.lbl_page.Text = "Label1"
        Me.lbl_page.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_next
        '
        Me.btn_next.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_next.Enabled = False
        Me.btn_next.Location = New System.Drawing.Point(292, 667)
        Me.btn_next.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btn_next.Name = "btn_next"
        Me.btn_next.Size = New System.Drawing.Size(136, 31)
        Me.btn_next.TabIndex = 5
        Me.btn_next.Text = "Next"
        Me.btn_next.UseVisualStyleBackColor = True
        '
        'btn_previous
        '
        Me.btn_previous.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_previous.Enabled = False
        Me.btn_previous.Location = New System.Drawing.Point(13, 667)
        Me.btn_previous.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btn_previous.Name = "btn_previous"
        Me.btn_previous.Size = New System.Drawing.Size(136, 31)
        Me.btn_previous.TabIndex = 4
        Me.btn_previous.Text = "Previous"
        Me.btn_previous.UseVisualStyleBackColor = True
        '
        'Manage_Order
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.lbl_page)
        Me.Controls.Add(Me.btn_next)
        Me.Controls.Add(Me.btn_previous)
        Me.Controls.Add(Me.btn_refresh)
        Me.Controls.Add(Me.btn_delete)
        Me.Controls.Add(Me.btn_edit)
        Me.Controls.Add(Me.dgv_details)
        Me.Controls.Add(Me.txt_search)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(21, 28, 21, 28)
        Me.MinimumSize = New System.Drawing.Size(1024, 768)
        Me.Name = "Manage_Order"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manage Order"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgv_details, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents btn_newOrder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn_passUpdate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn_logout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txt_welcome As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txt_search As System.Windows.Forms.TextBox
    Friend WithEvents dgv_details As System.Windows.Forms.DataGridView
    Friend WithEvents btn_edit As System.Windows.Forms.Button
    Friend WithEvents btn_delete As System.Windows.Forms.Button
    Friend WithEvents bgw_OrderLoader As System.ComponentModel.BackgroundWorker
    Friend WithEvents order_id As DataGridViewTextBoxColumn
    Friend WithEvents customer As DataGridViewTextBoxColumn
    Friend WithEvents order_name As DataGridViewTextBoxColumn
    Friend WithEvents issue_date As DataGridViewTextBoxColumn
    Friend WithEvents delivery_date As DataGridViewTextBoxColumn
    Friend WithEvents status As DataGridViewTextBoxColumn
    Friend WithEvents btn_refresh As Button
    Friend WithEvents bgw_OrderDelete As System.ComponentModel.BackgroundWorker
    Friend WithEvents lbl_page As System.Windows.Forms.Label
    Friend WithEvents btn_next As System.Windows.Forms.Button
    Friend WithEvents btn_previous As System.Windows.Forms.Button
End Class
