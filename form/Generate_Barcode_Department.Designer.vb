<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Generate_Barcode_Department
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
        Me.btn_print = New System.Windows.Forms.Button()
        Me.bgw_generateBarcode = New System.ComponentModel.BackgroundWorker()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.packageName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.department = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.numberofbags = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btn_add = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cb_department = New System.Windows.Forms.ComboBox()
        Me.txt_packageName = New System.Windows.Forms.TextBox()
        Me.num_bag = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_delete = New System.Windows.Forms.Button()
        CType(Me.num_bag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_print
        '
        Me.btn_print.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.btn_print.Location = New System.Drawing.Point(242, 265)
        Me.btn_print.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_print.Name = "btn_print"
        Me.btn_print.Size = New System.Drawing.Size(92, 27)
        Me.btn_print.TabIndex = 31
        Me.btn_print.Text = "PRINT"
        Me.btn_print.UseVisualStyleBackColor = True
        '
        'bgw_generateBarcode
        '
        '
        'ListView1
        '
        Me.ListView1.AllowColumnReorder = True
        Me.ListView1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.packageName, Me.department, Me.numberofbags})
        Me.ListView1.FullRowSelect = True
        Me.ListView1.Location = New System.Drawing.Point(179, 15)
        Me.ListView1.Margin = New System.Windows.Forms.Padding(2)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(367, 227)
        Me.ListView1.TabIndex = 38
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'packageName
        '
        Me.packageName.Text = "Package Name"
        Me.packageName.Width = 155
        '
        'department
        '
        Me.department.Text = "Department"
        Me.department.Width = 120
        '
        'numberofbags
        '
        Me.numberofbags.Text = "No. of Bags"
        Me.numberofbags.Width = 90
        '
        'btn_add
        '
        Me.btn_add.Location = New System.Drawing.Point(32, 191)
        Me.btn_add.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_add.Name = "btn_add"
        Me.btn_add.Size = New System.Drawing.Size(131, 22)
        Me.btn_add.TabIndex = 36
        Me.btn_add.Text = "Add >>"
        Me.btn_add.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(30, 105)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "Department"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(30, 15)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 13)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "Package Name"
        '
        'cb_department
        '
        Me.cb_department.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_department.FormattingEnabled = True
        Me.cb_department.Items.AddRange(New Object() {"Embroidery", "Printing", "Sewing", "Embroidery & Printing"})
        Me.cb_department.Location = New System.Drawing.Point(32, 120)
        Me.cb_department.Margin = New System.Windows.Forms.Padding(2)
        Me.cb_department.Name = "cb_department"
        Me.cb_department.Size = New System.Drawing.Size(132, 21)
        Me.cb_department.TabIndex = 33
        '
        'txt_packageName
        '
        Me.txt_packageName.Location = New System.Drawing.Point(32, 30)
        Me.txt_packageName.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_packageName.Name = "txt_packageName"
        Me.txt_packageName.Size = New System.Drawing.Size(132, 20)
        Me.txt_packageName.TabIndex = 32
        '
        'num_bag
        '
        Me.num_bag.Location = New System.Drawing.Point(32, 74)
        Me.num_bag.Margin = New System.Windows.Forms.Padding(2)
        Me.num_bag.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.num_bag.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.num_bag.Name = "num_bag"
        Me.num_bag.Size = New System.Drawing.Size(131, 20)
        Me.num_bag.TabIndex = 40
        Me.num_bag.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(30, 59)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "Number Of Bag"
        '
        'btn_delete
        '
        Me.btn_delete.Enabled = False
        Me.btn_delete.Location = New System.Drawing.Point(32, 218)
        Me.btn_delete.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_delete.Name = "btn_delete"
        Me.btn_delete.Size = New System.Drawing.Size(131, 22)
        Me.btn_delete.TabIndex = 37
        Me.btn_delete.Text = "Delete"
        Me.btn_delete.UseVisualStyleBackColor = True
        '
        'Generate_Barcode_Department
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(577, 306)
        Me.Controls.Add(Me.btn_print)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.btn_add)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cb_department)
        Me.Controls.Add(Me.txt_packageName)
        Me.Controls.Add(Me.num_bag)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_delete)
        Me.MaximumSize = New System.Drawing.Size(593, 345)
        Me.MinimumSize = New System.Drawing.Size(593, 345)
        Me.Name = "Generate_Barcode_Department"
        Me.Text = "Generate Barcode"
        CType(Me.num_bag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_print As Button
    Friend WithEvents bgw_generateBarcode As System.ComponentModel.BackgroundWorker
    Friend WithEvents ListView1 As ListView
    Friend WithEvents packageName As ColumnHeader
    Friend WithEvents department As ColumnHeader
    Friend WithEvents numberofbags As ColumnHeader
    Friend WithEvents btn_add As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cb_department As ComboBox
    Friend WithEvents txt_packageName As TextBox
    Friend WithEvents num_bag As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents btn_delete As Button
End Class
