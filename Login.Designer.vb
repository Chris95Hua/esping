<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
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
        Me.txt_barcodeText = New System.Windows.Forms.TextBox()
        Me.btn_generateBarcode = New System.Windows.Forms.Button()
        Me.pic_barcode = New System.Windows.Forms.PictureBox()
        Me.btn_login = New System.Windows.Forms.Button()
        CType(Me.pic_barcode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_barcodeText
        '
        Me.txt_barcodeText.Location = New System.Drawing.Point(220, 192)
        Me.txt_barcodeText.Name = "txt_barcodeText"
        Me.txt_barcodeText.Size = New System.Drawing.Size(280, 26)
        Me.txt_barcodeText.TabIndex = 0
        '
        'btn_generateBarcode
        '
        Me.btn_generateBarcode.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.btn_generateBarcode.Location = New System.Drawing.Point(559, 188)
        Me.btn_generateBarcode.Name = "btn_generateBarcode"
        Me.btn_generateBarcode.Size = New System.Drawing.Size(109, 34)
        Me.btn_generateBarcode.TabIndex = 1
        Me.btn_generateBarcode.Text = "Generate"
        Me.btn_generateBarcode.UseVisualStyleBackColor = True
        '
        'pic_barcode
        '
        Me.pic_barcode.Location = New System.Drawing.Point(220, 47)
        Me.pic_barcode.Name = "pic_barcode"
        Me.pic_barcode.Size = New System.Drawing.Size(280, 88)
        Me.pic_barcode.TabIndex = 2
        Me.pic_barcode.TabStop = False
        '
        'btn_login
        '
        Me.btn_login.Cursor = System.Windows.Forms.Cursors.Default
        Me.btn_login.Location = New System.Drawing.Point(31, 281)
        Me.btn_login.Name = "btn_login"
        Me.btn_login.Size = New System.Drawing.Size(109, 34)
        Me.btn_login.TabIndex = 1
        Me.btn_login.Text = "Login"
        Me.btn_login.UseVisualStyleBackColor = True
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(814, 592)
        Me.Controls.Add(Me.pic_barcode)
        Me.Controls.Add(Me.btn_login)
        Me.Controls.Add(Me.btn_generateBarcode)
        Me.Controls.Add(Me.txt_barcodeText)
        Me.Name = "Login"
        Me.Text = "Login"
        CType(Me.pic_barcode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_barcodeText As System.Windows.Forms.TextBox
    Friend WithEvents btn_generateBarcode As System.Windows.Forms.Button
    Friend WithEvents pic_barcode As System.Windows.Forms.PictureBox
    Friend WithEvents btn_login As System.Windows.Forms.Button

End Class
