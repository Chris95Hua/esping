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
        Me.btn_print = New System.Windows.Forms.Button()
        Me.num_bags = New System.Windows.Forms.NumericUpDown()
        CType(Me.num_bags, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 27)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Numbers of Bags"
        '
        'btn_print
        '
        Me.btn_print.Location = New System.Drawing.Point(88, 71)
        Me.btn_print.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_print.Name = "btn_print"
        Me.btn_print.Size = New System.Drawing.Size(77, 27)
        Me.btn_print.TabIndex = 2
        Me.btn_print.Text = "PRINT"
        Me.btn_print.UseVisualStyleBackColor = True
        '
        'num_bags
        '
        Me.num_bags.Location = New System.Drawing.Point(116, 27)
        Me.num_bags.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.num_bags.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.num_bags.Name = "num_bags"
        Me.num_bags.Size = New System.Drawing.Size(120, 20)
        Me.num_bags.TabIndex = 3
        Me.num_bags.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Generate_Barcode_Sticker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(261, 122)
        Me.Controls.Add(Me.num_bags)
        Me.Controls.Add(Me.btn_print)
        Me.Controls.Add(Me.Label1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Generate_Barcode_Sticker"
        Me.Text = "Generate Barcode Sticker"
        CType(Me.num_bags, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_print As System.Windows.Forms.Button
    Friend WithEvents num_bags As NumericUpDown
End Class
