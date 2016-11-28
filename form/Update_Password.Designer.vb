<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Update_Password
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
        Me.bgw_update = New System.ComponentModel.BackgroundWorker()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 14)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Old Password"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 40)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "New Password"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 67)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(115, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Retype New Password"
        '
        'txt_retypePass
        '
        Me.txt_retypePass.Location = New System.Drawing.Point(149, 64)
        Me.txt_retypePass.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_retypePass.Name = "txt_retypePass"
        Me.txt_retypePass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_retypePass.Size = New System.Drawing.Size(185, 20)
        Me.txt_retypePass.TabIndex = 1
        '
        'txt_newPass
        '
        Me.txt_newPass.Location = New System.Drawing.Point(149, 37)
        Me.txt_newPass.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_newPass.Name = "txt_newPass"
        Me.txt_newPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_newPass.Size = New System.Drawing.Size(185, 20)
        Me.txt_newPass.TabIndex = 1
        '
        'txt_oldPass
        '
        Me.txt_oldPass.Location = New System.Drawing.Point(149, 11)
        Me.txt_oldPass.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_oldPass.Name = "txt_oldPass"
        Me.txt_oldPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_oldPass.Size = New System.Drawing.Size(185, 20)
        Me.txt_oldPass.TabIndex = 1
        '
        'btn_update
        '
        Me.btn_update.Location = New System.Drawing.Point(138, 114)
        Me.btn_update.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_update.Name = "btn_update"
        Me.btn_update.Size = New System.Drawing.Size(78, 28)
        Me.btn_update.TabIndex = 4
        Me.btn_update.Text = "Update"
        Me.btn_update.UseVisualStyleBackColor = True
        '
        'Update_Password
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(355, 153)
        Me.Controls.Add(Me.btn_update)
        Me.Controls.Add(Me.txt_oldPass)
        Me.Controls.Add(Me.txt_newPass)
        Me.Controls.Add(Me.txt_retypePass)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Update_Password"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Update Password"
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
    Friend WithEvents bgw_update As System.ComponentModel.BackgroundWorker
End Class
