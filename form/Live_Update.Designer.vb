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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Live_Update))
        Me.bgw_liveUpdate = New System.ComponentModel.BackgroundWorker()
        Me.crv_job = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.bs_job = New System.Windows.Forms.BindingSource(Me.components)
        Me.ds_job = New espring.Job_Schedule()
        Me.num_record = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txt_filter = New System.Windows.Forms.TextBox()
        Me.btn_apply = New System.Windows.Forms.Button()
        Me.cmb_filter = New System.Windows.Forms.ComboBox()
        Me.dtp_end = New System.Windows.Forms.DateTimePicker()
        Me.dtp_start = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.bs_job, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ds_job, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_record, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'bgw_liveUpdate
        '
        '
        'crv_job
        '
        Me.crv_job.ActiveViewIndex = -1
        Me.crv_job.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.crv_job.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crv_job.Cursor = System.Windows.Forms.Cursors.Default
        Me.crv_job.DisplayStatusBar = False
        Me.crv_job.Location = New System.Drawing.Point(0, 33)
        Me.crv_job.Name = "crv_job"
        Me.crv_job.Size = New System.Drawing.Size(672, 441)
        Me.crv_job.TabIndex = 0
        Me.crv_job.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'ds_job
        '
        Me.ds_job.DataSetName = "Job_Schedule"
        Me.ds_job.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'num_record
        '
        Me.num_record.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.num_record.Location = New System.Drawing.Point(567, 8)
        Me.num_record.Maximum = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.num_record.Name = "num_record"
        Me.num_record.Size = New System.Drawing.Size(98, 20)
        Me.num_record.TabIndex = 4
        Me.num_record.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(487, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "No. of records"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.txt_filter)
        Me.Panel1.Controls.Add(Me.btn_apply)
        Me.Panel1.Controls.Add(Me.cmb_filter)
        Me.Panel1.Controls.Add(Me.dtp_end)
        Me.Panel1.Controls.Add(Me.dtp_start)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.num_record)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(672, 36)
        Me.Panel1.TabIndex = 3
        '
        'txt_filter
        '
        Me.txt_filter.Location = New System.Drawing.Point(164, 8)
        Me.txt_filter.Name = "txt_filter"
        Me.txt_filter.Size = New System.Drawing.Size(194, 20)
        Me.txt_filter.TabIndex = 4
        '
        'btn_apply
        '
        Me.btn_apply.Location = New System.Drawing.Point(410, 6)
        Me.btn_apply.Name = "btn_apply"
        Me.btn_apply.Size = New System.Drawing.Size(65, 23)
        Me.btn_apply.TabIndex = 5
        Me.btn_apply.Text = "Apply"
        Me.btn_apply.UseVisualStyleBackColor = True
        '
        'cmb_filter
        '
        Me.cmb_filter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_filter.FormattingEnabled = True
        Me.cmb_filter.Items.AddRange(New Object() {"None", "Customer", "Sales Person", "Issue Date", "Delivery Date", "Finished Job", "Ongoing Job"})
        Me.cmb_filter.Location = New System.Drawing.Point(41, 7)
        Me.cmb_filter.Name = "cmb_filter"
        Me.cmb_filter.Size = New System.Drawing.Size(106, 21)
        Me.cmb_filter.TabIndex = 1
        '
        'dtp_end
        '
        Me.dtp_end.CustomFormat = "dd/MM/yyyy"
        Me.dtp_end.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_end.Location = New System.Drawing.Point(294, 8)
        Me.dtp_end.Name = "dtp_end"
        Me.dtp_end.Size = New System.Drawing.Size(106, 20)
        Me.dtp_end.TabIndex = 3
        '
        'dtp_start
        '
        Me.dtp_start.CustomFormat = "dd/MM/yyyy"
        Me.dtp_start.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_start.Location = New System.Drawing.Point(164, 8)
        Me.dtp_start.Name = "dtp_start"
        Me.dtp_start.Size = New System.Drawing.Size(106, 20)
        Me.dtp_start.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(276, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(16, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "to"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Filter"
        '
        'Live_Update
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(672, 474)
        Me.Controls.Add(Me.crv_job)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MinimumSize = New System.Drawing.Size(688, 513)
        Me.Name = "Live_Update"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Job Schedule"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.bs_job, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ds_job, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_record, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents bgw_liveUpdate As System.ComponentModel.BackgroundWorker
    Friend WithEvents crv_job As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents bs_job As BindingSource
    Friend WithEvents ds_job As Job_Schedule
    Friend WithEvents num_record As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents dtp_start As DateTimePicker
    Friend WithEvents dtp_end As DateTimePicker
    Friend WithEvents cmb_filter As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btn_apply As Button
    Friend WithEvents txt_filter As TextBox
End Class
