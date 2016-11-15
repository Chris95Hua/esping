Public Class Job_Log
    Dim orderID As Integer

    Sub New(ByVal orderID As Integer)
        ' This call is required by the designer.
        InitializeComponent()
        Me.orderID = orderID
    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        Dim orderDetails As List(Of Dictionary(Of String, Object))
        orderDetails = Database.SelectRows(_TABLE.ORDER_CUSTOMER, {_ORDER_CUSTOMER.ORDER_ID, "=", Me.orderID})
        If orderDetails IsNot Nothing Then
            lbl_customer.Text = orderDetails.Item(_ORDER_CUSTOMER.CUSTOMER).ToString
            lbl_orderName.Text = orderDetails.Item(_ORDER_CUSTOMER.ORDER_NAME).ToString
            bgw_JobLogLoader.RunWorkerAsync()
        End If

    End Sub

    Private Sub bgw_JobLogLoader_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgw_JobLogLoader.DoWork
        Dim sqlStmt As String = String.Concat("SELECT ",
                                              _TABLE.ORDER_LOG, ".", _ORDER_LOG.DATETIME, ", ",
                                              _TABLE.ORDER_LOG, ".", _ORDER_LOG.STATUS, ", ",
                                              _TABLE.DEPARTMENT, ".", _DEPARTMENT.NAME,
                                              " FROM ", _TABLE.ORDER_LOG, " INNER JOIN ", _TABLE.DEPARTMENT,
                                              " ON ", _TABLE.ORDER_LOG, ".", _ORDER_LOG.DEPARTMENT_ID,
                                              " = ", _TABLE.DEPARTMENT, ".", _DEPARTMENT.DEPARTMENT_ID,
                                              " WHERE ", _TABLE.ORDER_LOG, ".", _ORDER_LOG.ORDER_ID,
                                              " = ", Me.orderID,
                                              " ORDER BY ", _TABLE.ORDER_LOG, ".", _ORDER_LOG.DATETIME, " DESC"
                                        )
        e.Result = Database.GetDataTable(sqlStmt.ToString())
    End Sub

    Private Sub bgw_JobLogLoader_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw_JobLogLoader.RunWorkerCompleted
        If (e.Error Is Nothing) Then
            dgv_job_log.DataSource = e.Result
        End If

        dgv_job_log.Enabled = True
    End Sub

    Private Sub btn_refresh_Click(sender As Object, e As EventArgs) Handles btn_refresh.Click
        dgv_job_log.Enabled = False
        dgv_job_log.DataSource = Nothing
        bgw_JobLogLoader.RunWorkerAsync()
    End Sub

    Private Sub Job_Log_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class