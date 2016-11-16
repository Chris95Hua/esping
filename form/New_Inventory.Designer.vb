<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class New_Inventory
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
        Me.btn_add = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_inventory = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btn_add
        '
        Me.btn_add.Location = New System.Drawing.Point(113, 97)
        Me.btn_add.Name = "btn_add"
        Me.btn_add.Size = New System.Drawing.Size(129, 46)
        Me.btn_add.TabIndex = 5
        Me.btn_add.Text = "Add"
        Me.btn_add.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 20)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Name"
        '
        'txt_inventory
        '
        Me.txt_inventory.Location = New System.Drawing.Point(90, 30)
        Me.txt_inventory.Name = "txt_inventory"
        Me.txt_inventory.Size = New System.Drawing.Size(220, 26)
        Me.txt_inventory.TabIndex = 3
        '
        'New_Inventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(348, 173)
        Me.Controls.Add(Me.btn_add)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_inventory)
        Me.MinimumSize = New System.Drawing.Size(370, 229)
        Me.Name = "New_Inventory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "New Inventory"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_add As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_inventory As System.Windows.Forms.TextBox
End Class
