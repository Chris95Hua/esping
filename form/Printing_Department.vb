﻿Public Class Printing_Department
    Private searchMode As Boolean = False

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        ' for admin
        If Session.department_id = _PROCESS.ADMIN Then
            Session.department_id = _PROCESS.PRINTING
        End If

        txt_welcome.Text = "Welcome: " + Session.first_name
        LoadDataGridData()
    End Sub

    ' Logout
    Private Sub btn_logout_Click(sender As Object, e As EventArgs) Handles btn_logout.Click
        Dim login As New Login
        login.Show()
        Me.Close()
    End Sub

    ' Update password
    Private Sub btn_passUpdate_Click(sender As Object, e As EventArgs) Handles btn_passUpdate.Click
        Dim passUpdateForm As New Update_Password
        passUpdateForm.ShowDialog()
    End Sub

    ' Clear search field
    Private Sub txt_Search_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_search.GotFocus
        txt_search.Text = ""
        txt_search.ForeColor = Color.Black
    End Sub

    ' Put place holder text in search field
    Private Sub btn_search_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_search.LostFocus
        If txt_search.Text = "" Then
            txt_search.Text = "Search Order"
            txt_search.ForeColor = Color.Gray
        End If
    End Sub

    ' Search event
    Private Sub txt_search_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_search.KeyDown
        If e.KeyCode = Keys.Enter Then
            If IsNumeric(txt_search.Text) Then
                searchMode = True
                LoadDataGridData(txt_search.Text)
            Else
                MessageBox.Show("Invalid order number", "Error")
            End If
        End If
    End Sub

    ' Get data for datagridview
    Private Sub bgw_PrintLoader_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgw_PrintLoader.DoWork
        If e.Argument <> -1 Then
            ' search
            Dim search As String = String.Concat("SELECT ",
                                              _ORDER_CUSTOMER.ORDER_NAME, ", ",
                                              _ORDER_CUSTOMER.CUSTOMER, ", ",
                                              _ORDER_CUSTOMER.FABRIC, ", ",
                                              _ORDER_CUSTOMER.COLLAR, ", ",
                                              _ORDER_CUSTOMER.CUFF, ", ",
                                              _ORDER_CUSTOMER.FRONT, ", ",
                                              _ORDER_CUSTOMER.BACK, ", ",
                                              _ORDER_CUSTOMER.ARTWORK, ", ",
                                              _ORDER_CUSTOMER.SIZE, ", ",
                                              _ORDER_CUSTOMER.MATERIAL, ", ",
                                              _ORDER_CUSTOMER.COLOUR, ", ",
                                              _ORDER_CUSTOMER.PACKAGING, ", ",
                                              _ORDER_CUSTOMER.ISSUE_DATE, ", ",
                                              _ORDER_CUSTOMER.DELIVERY_DATE, ", ",
                                              _ORDER_CUSTOMER.PAYMENT, ", ",
                                              _ORDER_CUSTOMER.PAYMENT_DOC, ", ",
                                              _ORDER_CUSTOMER.AMOUNT, ", ",
                                              _ORDER_CUSTOMER.PRINTING,
                                              " FROM ", _TABLE.ORDER_CUSTOMER,
                                              " WHERE ", _ORDER_CUSTOMER.ORDER_ID, " = ", e.Argument,
                                              " AND ", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.CUTTING, " = ", 2
                                        )

            e.Result = Database.ExecuteReader(search)
        Else
            ' get datagrid data
            Dim cuttingID As Integer = _PROCESS.CUTTING
            Dim printingID As Integer = _PROCESS.PRINTING

            Dim sqlStmt As String = String.Concat("SELECT ",
                                                  _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ORDER_ID, ", ",
                                                  _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.CUSTOMER, ", ",
                                                  _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ORDER_NAME, ", ",
                                                  "DATE_FORMAT(", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.DELIVERY_DATE, ", '%d/%m/%Y') As ", _ORDER_CUSTOMER.DELIVERY_DATE, ", ",
                                                  "CASE ", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.PRINTING, " WHEN 0 THEN '", _STATUS.PRINTING_0, "' WHEN 1 THEN '", _STATUS.PRINTING_1, "' WHEN 2 THEN '", _STATUS.PRINTING_2, "' END AS ", _ORDER_LOG.STATUS, ", ",
                                                  "DATE_FORMAT(", _TABLE.ORDER_LOG, ".", _ORDER_LOG.DATETIME, ", '%d/%m/%Y %h:%i:%s %p') As ", _ORDER_LOG.DATETIME, ", ",
                                                  _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.PRINTING,
                                                  " FROM ", _TABLE.ORDER_CUSTOMER, " INNER JOIN ", _TABLE.ORDER_LOG,
                                                  " ON ", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ORDER_ID,
                                                  "=", _TABLE.ORDER_LOG, ".", _ORDER_LOG.ORDER_ID,
                                                  " AND ", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.CUTTING, " = ", 2,
                                                  " AND ", _TABLE.ORDER_LOG, ".", _ORDER_LOG.DATETIME, " IN ",
                                                  " (SELECT MAX(", _ORDER_LOG.DATETIME, ") FROM ", _TABLE.ORDER_LOG,
                                                  " WHERE ", _ORDER_LOG.DEPARTMENT_ID, " IN (", cuttingID, ",", printingID, ")",
                                                  " GROUP BY ", _ORDER_LOG.ORDER_ID, ")",
                                                  " ORDER BY ", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ISSUE_DATE, " DESC"
                                            )

            e.Result = Database.GetDataTable(sqlStmt)
        End If
    End Sub

    ' Populate datagridview with data
    Private Sub bgw_PrintLoader_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw_PrintLoader.RunWorkerCompleted
        If (e.Error Is Nothing) Then
            If searchMode Then
                ' result from search, open details form
                Dim orderDetails As New List(Of Dictionary(Of String, Object))
                orderDetails = e.Result

                If orderDetails IsNot Nothing Then
                    Dim orderID As Integer = txt_search.Text
                    Dim details As New Order_Details(orderID, orderDetails.First, orderDetails.First.Item(_ORDER_CUSTOMER.PRINTING))

                    If details.ShowDialog() = DialogResult.OK Then
                        ' search the record in datagridview and update it
                        For Each row As DataGridViewRow In dgv_details.Rows
                            If row.Cells(0).Value = orderID Then
                                row.Cells(5).Value = details.updateDateTime.ToString("dd/MM/yyyy hh:mm:ss tt")
                                row.Cells(6).Value = details.status
                                Select Case details.status
                                    ' scanned in
                                    Case 1
                                        row.Cells(4).Value = _STATUS.PRINTING_1
                                    ' scanned out
                                    Case 2
                                        row.Cells(4).Value = _STATUS.PRINTING_2
                                End Select
                            End If
                        Next
                    End If
                Else
                    MessageBox.Show("Could not find matching order", "Error")
                End If

                searchMode = False
            Else
                ' populate datagridview
                dgv_details.DataSource = e.Result
            End If
        End If

        dgv_details.Enabled = True
    End Sub

    ' View order detail
    Private Sub dgv_details_CellMouseDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles dgv_details.CellMouseDoubleClick
        Dim orderID As Integer = dgv_details.SelectedCells(0).Value
        Dim status As Integer = dgv_details.SelectedCells(6).Value

        Dim details As New Order_Details(orderID, status)

        If details.ShowDialog() = DialogResult.OK Then
            dgv_details.SelectedCells(5).Value = details.updateDateTime.ToString("dd/MM/yyyy hh:mm:ss tt")
            dgv_details.SelectedCells(6).Value = details.status
            Select Case details.status
                ' scanned in
                Case 1
                    dgv_details.SelectedCells(4).Value = _STATUS.PRINTING_1
                ' scanned out
                Case 2
                    dgv_details.SelectedCells(4).Value = _STATUS.PRINTING_2
            End Select
        End If
    End Sub

    ' Reload datagridview data
    Private Sub btn_refresh_Click(sender As Object, e As EventArgs) Handles btn_refresh.Click
        LoadDataGridData()
    End Sub

    ' Start worker async
    Private Sub LoadDataGridData(Optional ByVal orderID As Integer = -1)
        dgv_details.Enabled = False
        bgw_PrintLoader.RunWorkerAsync(orderID)
    End Sub
End Class