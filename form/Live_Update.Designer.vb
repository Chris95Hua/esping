<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Live_Update
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.bgw_liveUpdate = New System.ComponentModel.BackgroundWorker()
        Me.crv_job = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'bgw_liveUpdate
        '
        '
        'crv_job
        '
        Me.crv_job.ActiveViewIndex = -1
        Me.crv_job.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crv_job.Cursor = System.Windows.Forms.Cursors.Default
        Me.crv_job.DisplayStatusBar = False
        Me.crv_job.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crv_job.Location = New System.Drawing.Point(0, 0)
        Me.crv_job.Name = "crv_job"
        Me.crv_job.Size = New System.Drawing.Size(672, 474)
        Me.crv_job.TabIndex = 0
        Me.crv_job.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'Live_Update
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(672, 474)
        Me.Controls.Add(Me.crv_job)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MinimumSize = New System.Drawing.Size(688, 513)
        Me.Name = "Live_Update"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Job Schedule"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents bgw_liveUpdate As System.ComponentModel.BackgroundWorker
    Friend WithEvents crv_job As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
