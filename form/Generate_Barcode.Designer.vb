<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Generate_Barcode
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Generate_Barcode))
        Me.btn_preview = New System.Windows.Forms.Button()
        Me.num_bags = New System.Windows.Forms.NumericUpDown()
        Me.btn_printer = New System.Windows.Forms.Button()
        Me.btn_print = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pd_barcode = New System.Drawing.Printing.PrintDocument()
        Me.ppd_barcode = New System.Windows.Forms.PrintPreviewDialog()
        Me.pdg_settings = New System.Windows.Forms.PrintDialog()
        CType(Me.num_bags, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_preview
        '
        Me.btn_preview.Location = New System.Drawing.Point(128, 89)
        Me.btn_preview.Name = "btn_preview"
        Me.btn_preview.Size = New System.Drawing.Size(94, 27)
        Me.btn_preview.TabIndex = 13
        Me.btn_preview.Text = "Preview"
        Me.btn_preview.UseVisualStyleBackColor = True
        '
        'num_bags
        '
        Me.num_bags.Location = New System.Drawing.Point(154, 28)
        Me.num_bags.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.num_bags.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.num_bags.Name = "num_bags"
        Me.num_bags.Size = New System.Drawing.Size(134, 20)
        Me.num_bags.TabIndex = 11
        Me.num_bags.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'btn_printer
        '
        Me.btn_printer.Location = New System.Drawing.Point(15, 89)
        Me.btn_printer.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_printer.Name = "btn_printer"
        Me.btn_printer.Size = New System.Drawing.Size(108, 27)
        Me.btn_printer.TabIndex = 12
        Me.btn_printer.Text = "Printer Settings"
        Me.btn_printer.UseVisualStyleBackColor = True
        '
        'btn_print
        '
        Me.btn_print.Location = New System.Drawing.Point(239, 89)
        Me.btn_print.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_print.Name = "btn_print"
        Me.btn_print.Size = New System.Drawing.Size(77, 27)
        Me.btn_print.TabIndex = 14
        Me.btn_print.Text = "Print"
        Me.btn_print.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 30)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Number of copies"
        '
        'pd_barcode
        '
        '
        'ppd_barcode
        '
        Me.ppd_barcode.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ppd_barcode.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ppd_barcode.ClientSize = New System.Drawing.Size(400, 300)
        Me.ppd_barcode.Enabled = True
        Me.ppd_barcode.Icon = CType(resources.GetObject("ppd_barcode.Icon"), System.Drawing.Icon)
        Me.ppd_barcode.Name = "ppd_barcode"
        Me.ppd_barcode.Visible = False
        '
        'pdg_settings
        '
        Me.pdg_settings.UseEXDialog = True
        '
        'Generate_Barcode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(336, 132)
        Me.Controls.Add(Me.btn_preview)
        Me.Controls.Add(Me.num_bags)
        Me.Controls.Add(Me.btn_printer)
        Me.Controls.Add(Me.btn_print)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Generate_Barcode"
        Me.Text = "Generate_Barcode"
        CType(Me.num_bags, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_preview As Button
    Friend WithEvents num_bags As NumericUpDown
    Friend WithEvents btn_printer As Button
    Friend WithEvents btn_print As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents pd_barcode As Printing.PrintDocument
    Friend WithEvents ppd_barcode As PrintPreviewDialog
    Friend WithEvents pdg_settings As PrintDialog
End Class
