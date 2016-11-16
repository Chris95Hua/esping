<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Delete_Item
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
        Me.btn_delete = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cb_itemName = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'btn_delete
        '
        Me.btn_delete.Location = New System.Drawing.Point(108, 96)
        Me.btn_delete.Name = "btn_delete"
        Me.btn_delete.Size = New System.Drawing.Size(129, 46)
        Me.btn_delete.TabIndex = 6
        Me.btn_delete.Text = "Delete"
        Me.btn_delete.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 20)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Item"
        '
        'cb_itemName
        '
        Me.cb_itemName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_itemName.FormattingEnabled = True
        Me.cb_itemName.Location = New System.Drawing.Point(80, 30)
        Me.cb_itemName.Name = "cb_itemName"
        Me.cb_itemName.Size = New System.Drawing.Size(220, 28)
        Me.cb_itemName.TabIndex = 4
        '
        'Delete_Item
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(348, 173)
        Me.Controls.Add(Me.btn_delete)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cb_itemName)
        Me.MinimumSize = New System.Drawing.Size(370, 229)
        Me.Name = "Delete_Item"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Delete Item"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_delete As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cb_itemName As System.Windows.Forms.ComboBox
End Class
