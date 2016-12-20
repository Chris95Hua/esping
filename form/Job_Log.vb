Public Class Job_Log
    Private loadingOverlay As Loading_Overlay
    Private orderID As Integer

    Sub New(ByVal orderID As Integer)
        ' This call is required by the designer.
        InitializeComponent()
        Me.orderID = orderID
    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        ' TODO: use async task
        Dim orderDetails As Dictionary(Of String, Object)
        orderDetails = Database.SelectRows(_TABLE.ORDER_CUSTOMER, {_ORDER_CUSTOMER.ORDER_ID, "=", Me.orderID}).First

        If orderDetails IsNot Nothing Then
            lbl_customer.Text = orderDetails.Item(_ORDER_CUSTOMER.CUSTOMER).ToString()
            lbl_orderName.Text = orderDetails.Item(_ORDER_CUSTOMER.ORDER_NAME).ToString()
            LoadDataGridData()
        End If

    End Sub

    ' Load the log
    Private Sub bgw_JobLogLoader_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgw_JobLogLoader.DoWork
        Dim sqlStmt As String = String.Concat("SELECT ",
                                              _TABLE.ORDER_LOG, ".", _ORDER_LOG.DATETIME, ", ",
                                              _TABLE.ORDER_LOG, ".", _ORDER_LOG.STATUS,
                                              " FROM ", _TABLE.ORDER_LOG,
                                              " WHERE ", _TABLE.ORDER_LOG, ".", _ORDER_LOG.ORDER_ID,
                                              " = ", Me.orderID,
                                              " ORDER BY ", _TABLE.ORDER_LOG, ".", _ORDER_LOG.DATETIME, " ASC"
                                        )

        e.Result = Database.GetDataTable(sqlStmt.ToString())
    End Sub

    ' Result
    Private Sub bgw_JobLogLoader_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw_JobLogLoader.RunWorkerCompleted
        ShowLoadingOverlay(False)

        If (e.Error Is Nothing) Then
            dgv_job_log.DataSource = e.Result
        End If

        dgv_job_log.Enabled = True
    End Sub

    ' Refresh
    Private Sub btn_refresh_Click(sender As Object, e As EventArgs) Handles btn_refresh.Click
        LoadDataGridData()
    End Sub

    ' Load datagrid's data
    Private Sub LoadDataGridData()
        dgv_job_log.Enabled = False
        bgw_JobLogLoader.RunWorkerAsync()
        ShowLoadingOverlay(True)
    End Sub

    ' Loading overlay
    Private Sub ShowLoadingOverlay(ByVal show As Boolean)
        If show Then
            loadingOverlay = New Loading_Overlay
            loadingOverlay.Size = New Size(Me.Width - 16, Me.Height - 38)
            loadingOverlay.ShowDialog()
        Else
            loadingOverlay.Close()
        End If
    End Sub
End Class