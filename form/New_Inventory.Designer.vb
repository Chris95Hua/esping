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
        Me.bgw_InsertItem = New System.ComponentModel.BackgroundWorker()
        Me.SuspendLayout()
        '
        'btn_add
        '
        Me.btn_add.Location = New System.Drawing.Point(75, 63)
        Me.btn_add.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btn_add.Name = "btn_add"
        Me.btn_add.Size = New System.Drawing.Size(86, 30)
        Me.btn_add.TabIndex = 5
        Me.btn_add.Text = "Add"
        Me.btn_add.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 21)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Name"
        '
        'txt_inventory
        '
        Me.txt_inventory.Location = New System.Drawing.Point(60, 19)
        Me.txt_inventory.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txt_inventory.Name = "txt_inventory"
        Me.txt_inventory.Size = New System.Drawing.Size(148, 20)
        Me.txt_inventory.TabIndex = 3
        '
        'bgw_InsertItem
        '
        '
        'New_Inventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(236, 123)
        Me.Controls.Add(Me.btn_add)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_inventory)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.MinimumSize = New System.Drawing.Size(252, 162)
        Me.Name = "New_Inventory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "New Inventory"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_add As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_inventory As System.Windows.Forms.TextBox
    Friend WithEvents bgw_InsertItem As System.ComponentModel.BackgroundWorker
End Class
