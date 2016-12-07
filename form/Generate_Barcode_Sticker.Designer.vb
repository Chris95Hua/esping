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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Generate_Barcode_Sticker))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_print = New System.Windows.Forms.Button()
        Me.num_bags = New System.Windows.Forms.NumericUpDown()
        Me.pd_barcodeSticker = New System.Drawing.Printing.PrintDocument()
        Me.pdg_settings = New System.Windows.Forms.PrintDialog()
        Me.btn_printer = New System.Windows.Forms.Button()
        Me.ppd_preview = New System.Windows.Forms.PrintPreviewDialog()
        Me.btn_preview = New System.Windows.Forms.Button()
        Me.txt_add1 = New System.Windows.Forms.TextBox()
        Me.txt_add2 = New System.Windows.Forms.TextBox()
        Me.txt_add3 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.num_bags, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.btn_print.Location = New System.Drawing.Point(235, 175)
        Me.btn_print.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_print.Name = "btn_print"
        Me.btn_print.Size = New System.Drawing.Size(77, 27)
        Me.btn_print.TabIndex = 9
        Me.btn_print.Text = "Print"
        Me.btn_print.UseVisualStyleBackColor = True
        '
        'num_bags
        '
        Me.num_bags.Location = New System.Drawing.Point(140, 27)
        Me.num_bags.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.num_bags.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.num_bags.Name = "num_bags"
        Me.num_bags.Size = New System.Drawing.Size(134, 20)
        Me.num_bags.TabIndex = 3
        Me.num_bags.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'pd_barcodeSticker
        '
        '
        'pdg_settings
        '
        Me.pdg_settings.UseEXDialog = True
        '
        'btn_printer
        '
        Me.btn_printer.Location = New System.Drawing.Point(11, 175)
        Me.btn_printer.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_printer.Name = "btn_printer"
        Me.btn_printer.Size = New System.Drawing.Size(108, 27)
        Me.btn_printer.TabIndex = 7
        Me.btn_printer.Text = "Printer Settings"
        Me.btn_printer.UseVisualStyleBackColor = True
        '
        'ppd_preview
        '
        Me.ppd_preview.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ppd_preview.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ppd_preview.ClientSize = New System.Drawing.Size(400, 300)
        Me.ppd_preview.Enabled = True
        Me.ppd_preview.Icon = CType(resources.GetObject("ppd_preview.Icon"), System.Drawing.Icon)
        Me.ppd_preview.Name = "ppd_preview"
        Me.ppd_preview.Visible = False
        '
        'btn_preview
        '
        Me.btn_preview.Location = New System.Drawing.Point(124, 175)
        Me.btn_preview.Name = "btn_preview"
        Me.btn_preview.Size = New System.Drawing.Size(94, 27)
        Me.btn_preview.TabIndex = 8
        Me.btn_preview.Text = "Preview"
        Me.btn_preview.UseVisualStyleBackColor = True
        '
        'txt_add1
        '
        Me.txt_add1.Location = New System.Drawing.Point(140, 67)
        Me.txt_add1.MaxLength = 42
        Me.txt_add1.Name = "txt_add1"
        Me.txt_add1.Size = New System.Drawing.Size(134, 20)
        Me.txt_add1.TabIndex = 4
        '
        'txt_add2
        '
        Me.txt_add2.Location = New System.Drawing.Point(140, 93)
        Me.txt_add2.MaxLength = 42
        Me.txt_add2.Name = "txt_add2"
        Me.txt_add2.Size = New System.Drawing.Size(134, 20)
        Me.txt_add2.TabIndex = 5
        '
        'txt_add3
        '
        Me.txt_add3.Location = New System.Drawing.Point(140, 119)
        Me.txt_add3.MaxLength = 42
        Me.txt_add3.Name = "txt_add3"
        Me.txt_add3.Size = New System.Drawing.Size(134, 20)
        Me.txt_add3.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 70)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Address Line 1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 96)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Address Line 2"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 122)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Address Line 3"
        '
        'Generate_Barcode_Sticker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(323, 217)
        Me.Controls.Add(Me.txt_add3)
        Me.Controls.Add(Me.txt_add2)
        Me.Controls.Add(Me.txt_add1)
        Me.Controls.Add(Me.btn_preview)
        Me.Controls.Add(Me.num_bags)
        Me.Controls.Add(Me.btn_printer)
        Me.Controls.Add(Me.btn_print)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MinimumSize = New System.Drawing.Size(281, 172)
        Me.Name = "Generate_Barcode_Sticker"
        Me.Text = "Generate Barcode Sticker"
        CType(Me.num_bags, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_print As System.Windows.Forms.Button
    Friend WithEvents num_bags As NumericUpDown
    Friend WithEvents pd_barcodeSticker As Printing.PrintDocument
    Friend WithEvents pdg_settings As PrintDialog
    Friend WithEvents btn_printer As Button
    Friend WithEvents ppd_preview As PrintPreviewDialog
    Friend WithEvents btn_preview As Button
    Friend WithEvents txt_add1 As TextBox
    Friend WithEvents txt_add2 As TextBox
    Friend WithEvents txt_add3 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
End Class
