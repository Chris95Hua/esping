<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Generate_Barcode_Sticker
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_bags = New System.Windows.Forms.TextBox()
        Me.btn_print = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Numbers of Bags"
        '
        'txt_bags
        '
        Me.txt_bags.Location = New System.Drawing.Point(172, 39)
        Me.txt_bags.Name = "txt_bags"
        Me.txt_bags.Size = New System.Drawing.Size(169, 26)
        Me.txt_bags.TabIndex = 1
        '
        'btn_print
        '
        Me.btn_print.Location = New System.Drawing.Point(132, 109)
        Me.btn_print.Name = "btn_print"
        Me.btn_print.Size = New System.Drawing.Size(115, 41)
        Me.btn_print.TabIndex = 2
        Me.btn_print.Text = "PRINT"
        Me.btn_print.UseVisualStyleBackColor = True
        '
        'Generate_Barcode_Sticker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(391, 187)
        Me.Controls.Add(Me.btn_print)
        Me.Controls.Add(Me.txt_bags)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Generate_Barcode_Sticker"
        Me.Text = "Generate Barcode Sticker"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_bags As System.Windows.Forms.TextBox
    Friend WithEvents btn_print As System.Windows.Forms.Button
End Class
