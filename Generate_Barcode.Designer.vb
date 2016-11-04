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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_front = New System.Windows.Forms.TextBox()
        Me.txt_back = New System.Windows.Forms.TextBox()
        Me.txt_sleeve = New System.Windows.Forms.TextBox()
        Me.btn_print = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.Label1.Location = New System.Drawing.Point(61, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(218, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Number of Bags"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(62, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Front: "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(62, 142)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 20)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Back: "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(62, 183)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 20)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Sleeve: "
        '
        'txt_front
        '
        Me.txt_front.Location = New System.Drawing.Point(133, 97)
        Me.txt_front.Name = "txt_front"
        Me.txt_front.Size = New System.Drawing.Size(140, 26)
        Me.txt_front.TabIndex = 2
        '
        'txt_back
        '
        Me.txt_back.Location = New System.Drawing.Point(133, 139)
        Me.txt_back.Name = "txt_back"
        Me.txt_back.Size = New System.Drawing.Size(140, 26)
        Me.txt_back.TabIndex = 2
        '
        'txt_sleeve
        '
        Me.txt_sleeve.Location = New System.Drawing.Point(133, 180)
        Me.txt_sleeve.Name = "txt_sleeve"
        Me.txt_sleeve.Size = New System.Drawing.Size(140, 26)
        Me.txt_sleeve.TabIndex = 2
        '
        'btn_print
        '
        Me.btn_print.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.btn_print.Location = New System.Drawing.Point(107, 250)
        Me.btn_print.Name = "btn_print"
        Me.btn_print.Size = New System.Drawing.Size(138, 55)
        Me.btn_print.TabIndex = 17
        Me.btn_print.Text = "PRINT"
        Me.btn_print.UseVisualStyleBackColor = True
        '
        'Generate_Barcode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(353, 337)
        Me.Controls.Add(Me.btn_print)
        Me.Controls.Add(Me.txt_sleeve)
        Me.Controls.Add(Me.txt_back)
        Me.Controls.Add(Me.txt_front)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Generate_Barcode"
        Me.Text = "Generate Barcode"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_front As System.Windows.Forms.TextBox
    Friend WithEvents txt_back As System.Windows.Forms.TextBox
    Friend WithEvents txt_sleeve As System.Windows.Forms.TextBox
    Friend WithEvents btn_print As System.Windows.Forms.Button
End Class
