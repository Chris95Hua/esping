<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Generate_Barcode_Sticker
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_print = New System.Windows.Forms.Button()
        Me.num_bags = New System.Windows.Forms.NumericUpDown()
        Me.pd_barcodeSticker = New System.Drawing.Printing.PrintDocument()
        Me.ppc_preview = New System.Windows.Forms.PrintPreviewControl()
        Me.num_preview = New System.Windows.Forms.NumericUpDown()
        Me.pdg_settings = New System.Windows.Forms.PrintDialog()
        Me.btn_printer = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.num_bags, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_preview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 29)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Numbers of Bags"
        '
        'btn_print
        '
        Me.btn_print.Location = New System.Drawing.Point(183, 528)
        Me.btn_print.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_print.Name = "btn_print"
        Me.btn_print.Size = New System.Drawing.Size(77, 27)
        Me.btn_print.TabIndex = 2
        Me.btn_print.Text = "PRINT"
        Me.btn_print.UseVisualStyleBackColor = True
        '
        'num_bags
        '
        Me.num_bags.Location = New System.Drawing.Point(140, 27)
        Me.num_bags.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.num_bags.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.num_bags.Name = "num_bags"
        Me.num_bags.Size = New System.Drawing.Size(120, 20)
        Me.num_bags.TabIndex = 3
        Me.num_bags.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'pd_barcodeSticker
        '
        '
        'ppc_preview
        '
        Me.ppc_preview.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ppc_preview.Location = New System.Drawing.Point(281, 0)
        Me.ppc_preview.Name = "ppc_preview"
        Me.ppc_preview.Size = New System.Drawing.Size(437, 567)
        Me.ppc_preview.TabIndex = 4
        '
        'num_preview
        '
        Me.num_preview.Location = New System.Drawing.Point(140, 381)
        Me.num_preview.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.num_preview.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.num_preview.Name = "num_preview"
        Me.num_preview.Size = New System.Drawing.Size(53, 20)
        Me.num_preview.TabIndex = 3
        Me.num_preview.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'pdg_settings
        '
        Me.pdg_settings.UseEXDialog = True
        '
        'btn_printer
        '
        Me.btn_printer.Location = New System.Drawing.Point(11, 528)
        Me.btn_printer.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_printer.Name = "btn_printer"
        Me.btn_printer.Size = New System.Drawing.Size(108, 27)
        Me.btn_printer.TabIndex = 2
        Me.btn_printer.Text = "Printer Settings"
        Me.btn_printer.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(38, 383)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Page Preview"
        '
        'Generate_Barcode_Sticker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(718, 567)
        Me.Controls.Add(Me.ppc_preview)
        Me.Controls.Add(Me.num_preview)
        Me.Controls.Add(Me.num_bags)
        Me.Controls.Add(Me.btn_printer)
        Me.Controls.Add(Me.btn_print)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MinimumSize = New System.Drawing.Size(281, 172)
        Me.Name = "Generate_Barcode_Sticker"
        Me.Text = "Generate Barcode Sticker"
        CType(Me.num_bags, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_preview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_print As System.Windows.Forms.Button
    Friend WithEvents num_bags As NumericUpDown
    Friend WithEvents pd_barcodeSticker As Printing.PrintDocument
    Friend WithEvents ppc_preview As PrintPreviewControl
    Friend WithEvents num_preview As NumericUpDown
    Friend WithEvents pdg_settings As PrintDialog
    Friend WithEvents btn_printer As Button
    Friend WithEvents Label2 As Label
End Class
