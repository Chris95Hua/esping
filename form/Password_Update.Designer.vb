<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Password_Update
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
        Me.txt_retypePass = New System.Windows.Forms.TextBox()
        Me.txt_newPass = New System.Windows.Forms.TextBox()
        Me.txt_oldPass = New System.Windows.Forms.TextBox()
        Me.btn_update = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Old Password"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "New Password"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(133, 20)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Retype Password"
        '
        'txt_retypePass
        '
        Me.txt_retypePass.Location = New System.Drawing.Point(186, 100)
        Me.txt_retypePass.Name = "txt_retypePass"
        Me.txt_retypePass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_retypePass.Size = New System.Drawing.Size(275, 26)
        Me.txt_retypePass.TabIndex = 1
        '
        'txt_newPass
        '
        Me.txt_newPass.Location = New System.Drawing.Point(186, 59)
        Me.txt_newPass.Name = "txt_newPass"
        Me.txt_newPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_newPass.Size = New System.Drawing.Size(275, 26)
        Me.txt_newPass.TabIndex = 1
        '
        'txt_oldPass
        '
        Me.txt_oldPass.Location = New System.Drawing.Point(186, 18)
        Me.txt_oldPass.Name = "txt_oldPass"
        Me.txt_oldPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_oldPass.Size = New System.Drawing.Size(275, 26)
        Me.txt_oldPass.TabIndex = 1
        '
        'btn_update
        '
        Me.btn_update.Location = New System.Drawing.Point(194, 167)
        Me.btn_update.Name = "btn_update"
        Me.btn_update.Size = New System.Drawing.Size(117, 43)
        Me.btn_update.TabIndex = 4
        Me.btn_update.Text = "Update"
        Me.btn_update.UseVisualStyleBackColor = True
        '
        'Password_Update
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(493, 236)
        Me.Controls.Add(Me.btn_update)
        Me.Controls.Add(Me.txt_oldPass)
        Me.Controls.Add(Me.txt_newPass)
        Me.Controls.Add(Me.txt_retypePass)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Password_Update"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Password Update"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_retypePass As System.Windows.Forms.TextBox
    Friend WithEvents txt_newPass As System.Windows.Forms.TextBox
    Friend WithEvents txt_oldPass As System.Windows.Forms.TextBox
    Friend WithEvents btn_update As System.Windows.Forms.Button
End Class
