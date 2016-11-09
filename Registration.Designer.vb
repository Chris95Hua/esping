<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Registration
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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_firstName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_lastName = New System.Windows.Forms.TextBox()
        Me.txt_userName = New System.Windows.Forms.TextBox()
        Me.txt_password = New System.Windows.Forms.TextBox()
        Me.cb_department = New System.Windows.Forms.ComboBox()
        Me.cb_role = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btn_submit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(59, 144)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "First Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(59, 206)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Last Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(59, 268)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 20)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Department"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(59, 330)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 20)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Role"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(59, 392)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 20)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Username"
        '
        'txt_firstName
        '
        Me.txt_firstName.Location = New System.Drawing.Point(180, 141)
        Me.txt_firstName.Name = "txt_firstName"
        Me.txt_firstName.Size = New System.Drawing.Size(187, 26)
        Me.txt_firstName.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(59, 454)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 20)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Password"
        '
        'txt_lastName
        '
        Me.txt_lastName.Location = New System.Drawing.Point(180, 203)
        Me.txt_lastName.Name = "txt_lastName"
        Me.txt_lastName.Size = New System.Drawing.Size(187, 26)
        Me.txt_lastName.TabIndex = 2
        '
        'txt_userName
        '
        Me.txt_userName.Location = New System.Drawing.Point(180, 389)
        Me.txt_userName.Name = "txt_userName"
        Me.txt_userName.Size = New System.Drawing.Size(187, 26)
        Me.txt_userName.TabIndex = 5
        '
        'txt_password
        '
        Me.txt_password.Location = New System.Drawing.Point(180, 451)
        Me.txt_password.Name = "txt_password"
        Me.txt_password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_password.Size = New System.Drawing.Size(187, 26)
        Me.txt_password.TabIndex = 6
        '
        'cb_department
        '
        Me.cb_department.DisplayMember = "0"
        Me.cb_department.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_department.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cb_department.FormattingEnabled = True
        Me.cb_department.Location = New System.Drawing.Point(180, 265)
        Me.cb_department.MinimumSize = New System.Drawing.Size(187, 0)
        Me.cb_department.Name = "cb_department"
        Me.cb_department.Size = New System.Drawing.Size(187, 28)
        Me.cb_department.TabIndex = 3
        '
        'cb_role
        '
        Me.cb_role.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_role.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cb_role.FormattingEnabled = True
        Me.cb_role.Items.AddRange(New Object() {"Admin", "Staff"})
        Me.cb_role.Location = New System.Drawing.Point(180, 327)
        Me.cb_role.Name = "cb_role"
        Me.cb_role.Size = New System.Drawing.Size(187, 28)
        Me.cb_role.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(56, 31)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(330, 46)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "REGISTRATION"
        '
        'btn_submit
        '
        Me.btn_submit.Location = New System.Drawing.Point(165, 552)
        Me.btn_submit.Name = "btn_submit"
        Me.btn_submit.Size = New System.Drawing.Size(119, 48)
        Me.btn_submit.TabIndex = 7
        Me.btn_submit.Text = "SUBMIT"
        Me.btn_submit.UseVisualStyleBackColor = True
        '
        'Registration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(449, 647)
        Me.Controls.Add(Me.btn_submit)
        Me.Controls.Add(Me.cb_role)
        Me.Controls.Add(Me.cb_department)
        Me.Controls.Add(Me.txt_password)
        Me.Controls.Add(Me.txt_userName)
        Me.Controls.Add(Me.txt_lastName)
        Me.Controls.Add(Me.txt_firstName)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Registration"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registration"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_firstName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_lastName As System.Windows.Forms.TextBox
    Friend WithEvents txt_userName As System.Windows.Forms.TextBox
    Friend WithEvents txt_password As System.Windows.Forms.TextBox
    Friend WithEvents cb_role As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btn_submit As System.Windows.Forms.Button
    Friend WithEvents cb_department As System.Windows.Forms.ComboBox
End Class
