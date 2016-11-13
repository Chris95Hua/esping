Public Class Job_Log
    Dim orderID As Integer

    Sub New(ByVal orderID As Integer)
        ' This call is required by the designer.
        InitializeComponent()
        Me.orderID = orderID
    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        bgw_JobLogLoader.RunWorkerAsync()
    End Sub

    Private Sub bgw_JobLogLoader_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgw_JobLogLoader.DoWork
        Dim sqlStmt As String = String.Concat("SELECT ",
                                              TABLE.ORDER_LOG, ".", ORDER_LOG.DATETIME, ", ",
                                              TABLE.ORDER_LOG, ".", ORDER_LOG.STATUS, ", ",
                                              TABLE.DEPARTMENT, ".", DEPARTMENT.NAME,
                                              " FROM ", TABLE.ORDER_LOG, " INNER JOIN ", TABLE.DEPARTMENT,
                                              " ON ", TABLE.ORDER_LOG, ".", ORDER_LOG.DEPARTMENT_ID,
                                              " = ", TABLE.DEPARTMENT, ".", DEPARTMENT.DEPARTMENT_ID,
                                              " WHERE ", TABLE.ORDER_LOG, ".", ORDER_LOG.ORDER_ID,
                                              " = ", Me.orderID,
                                              " ORDER BY ", TABLE.ORDER_LOG, ".", ORDER_LOG.DATETIME, " DESC"
                                        )
        e.Result = Database.GetDataTable(sqlStmt.ToString())
    End Sub

    Private Sub bgw_JobLogLoader_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw_JobLogLoader.RunWorkerCompleted
        If (e.Error Is Nothing) Then
            dgv_job_log.DataSource = e.Result
        End If
    End Sub
End Class