<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Edit_Delivery_Date
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Edit_Delivery_Date))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.d_newDeliveryDate = New System.Windows.Forms.DateTimePicker()
        Me.btn_update = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 22)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Delivery Date"
        '
        'd_newDeliveryDate
        '
        Me.d_newDeliveryDate.CustomFormat = "dd/MM/yyyy"
        Me.d_newDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.d_newDeliveryDate.Location = New System.Drawing.Point(97, 19)
        Me.d_newDeliveryDate.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.d_newDeliveryDate.Name = "d_newDeliveryDate"
        Me.d_newDeliveryDate.Size = New System.Drawing.Size(202, 20)
        Me.d_newDeliveryDate.TabIndex = 1
        '
        'btn_update
        '
        Me.btn_update.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_update.Location = New System.Drawing.Point(126, 64)
        Me.btn_update.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btn_update.Name = "btn_update"
        Me.btn_update.Size = New System.Drawing.Size(85, 33)
        Me.btn_update.TabIndex = 4
        Me.btn_update.Text = "Update"
        Me.btn_update.UseVisualStyleBackColor = True
        '
        'Edit_Delivery_Date
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(338, 121)
        Me.Controls.Add(Me.btn_update)
        Me.Controls.Add(Me.d_newDeliveryDate)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(354, 160)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(354, 160)
        Me.Name = "Edit_Delivery_Date"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Delivery Date"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents d_newDeliveryDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_update As System.Windows.Forms.Button
End Class
