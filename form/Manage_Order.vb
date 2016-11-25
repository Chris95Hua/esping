Public Class Manage_Order
    Private loadingOverlay As Loading_Overlay
    Private searchID As Integer = -1
    Private pageNumber As Integer = 1
    Private currentPageNumber As Integer = 1
    Private loadRowsFrom As Integer = 0

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        ' for admin
        If Session.department_id = _PROCESS.ADMIN Then
            Session.department_id = _PROCESS.ORDER
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
                searchID = txt_search.Text
                LoadDataGridData(txt_search.Text)
            Else
                MessageBox.Show("Invalid order number", "Error")
            End If
        End If
    End Sub

    ' New order
    Private Sub btn_newOrder_Click(sender As Object, e As EventArgs) Handles btn_newOrder.Click
        Dim newOrderForm As New new_order
        newOrderForm.ShowDialog()

        LoadDataGridData()
    End Sub

    ' Update delivery date
    Private Sub btn_edit_Click(sender As Object, e As EventArgs) Handles btn_edit.Click
        Dim editDeliveryForm As New Edit_Delivery_Date(Date.ParseExact(dgv_details.SelectedCells.Item(4).Value, "dd/MM/yyyy", Globalization.CultureInfo.InvariantCulture))


        If editDeliveryForm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim id As Integer = dgv_details.SelectedCells.Item(0).Value
            Dim newDate As Date = editDeliveryForm.d_newDeliveryDate.Value
            Dim update As New Dictionary(Of String, Object)

            update.Add(_ORDER_CUSTOMER.DELIVERY_DATE, newDate)

            ' TODO: use async task
            If Database.Update(_TABLE.ORDER_CUSTOMER, {_ORDER_CUSTOMER.ORDER_ID, "=", id}, update) Then
                dgv_details.SelectedCells.Item(4).Value = newDate.ToString("dd/MM/yyyy")
                MessageBox.Show("Delivery date updated successfully")
            Else
                MessageBox.Show("Update failed.")
            End If
        End If
    End Sub

    ' Delete order
    Private Sub btn_delete_Click(sender As Object, e As EventArgs) Handles btn_delete.Click
        Dim result As Integer = MessageBox.Show("Confirm deletion?", "Delete Order", MessageBoxButtons.YesNo)

        If result = DialogResult.Yes Then
            dgv_details.Enabled = False
            bgw_OrderDelete.RunWorkerAsync(dgv_details.SelectedCells.Item(0).Value)
            ShowLoadingOverlay(True)
        End If
    End Sub

    ' Get data for datagridview
    Private Sub bgw_OrderLoader_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgw_OrderLoader.DoWork
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
                                              _ORDER_CUSTOMER.DELIVERY_TYPE, ", ",
                                              _ORDER_CUSTOMER.PAYMENT, ", ",
                                              _ORDER_CUSTOMER.PAYMENT_DOC, ", ",
                                              _ORDER_CUSTOMER.REMARKS, ", ",
                                              _ORDER_CUSTOMER.INVENTORY_ORDER, ", ",
                                              _ORDER_CUSTOMER.PRODUCTION_PARTS, ", ",
                                              _ORDER_CUSTOMER.AMOUNT,
                                              " FROM ", _TABLE.ORDER_CUSTOMER,
                                              " WHERE ", _ORDER_CUSTOMER.ORDER_ID, " = ", e.Argument
                                        )

            e.Result = Database.ExecuteReader(search)
        Else
            CalculatePageNumber()
            loadRowsFrom = (currentPageNumber - 1) * My.Settings.PAGINATION_LIMIT

            ' get datagrid data
            Dim sqlStmt As String = String.Concat("SELECT ",
                                                  _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ORDER_ID, ", ",
                                                  _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.CUSTOMER, ", ",
                                                  _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ORDER_NAME, ", ",
                                                  "DATE_FORMAT(", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ISSUE_DATE, ", '%d/%m/%Y') As ", _ORDER_CUSTOMER.ISSUE_DATE, ", ",
                                                  "DATE_FORMAT(", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.DELIVERY_DATE, ", '%d/%m/%Y') As ", _ORDER_CUSTOMER.DELIVERY_DATE, ", ",
                                                  _TABLE.ORDER_LOG, ".", _ORDER_LOG.STATUS,
                                                  " FROM ", _TABLE.ORDER_CUSTOMER, " INNER JOIN ", _TABLE.ORDER_LOG,
                                                  " ON ", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ORDER_ID,
                                                  "=", _TABLE.ORDER_LOG, ".", _ORDER_LOG.ORDER_ID,
                                                  " WHERE ", _TABLE.ORDER_LOG, ".", _ORDER_LOG.DATETIME, " IN ",
                                                  " (SELECT MAX(", _ORDER_LOG.DATETIME, ") FROM ", _TABLE.ORDER_LOG,
                                                  " GROUP BY ", _ORDER_LOG.ORDER_ID, ")",
                                                  " ORDER BY ", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ORDER_ID, " DESC",
                                                  " LIMIT ", loadRowsFrom, ",", My.Settings.PAGINATION_LIMIT
                                            )

            e.Result = Database.GetDataTable(sqlStmt)
        End If
    End Sub

    ' Result
    Private Sub bgw_OrderLoader_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw_OrderLoader.RunWorkerCompleted
        ShowLoadingOverlay(False)

        If (e.Error Is Nothing) Then
            If searchID <> -1 Then
                ' result from search, open details form
                Dim orderDetails As New List(Of Dictionary(Of String, Object))
                orderDetails = e.Result

                If orderDetails IsNot Nothing Then
                    Dim details As New Order_Details(searchID, orderDetails.First, -1)
                    details.ShowDialog()
                Else
                    MessageBox.Show("Could not find matching order", "Error")
                End If

                searchID = -1
            Else
                ' populate datagridview
                dgv_details.DataSource = e.Result
            End If
        End If

        If currentPageNumber = pageNumber Then
            btn_next.Enabled = False
        Else
            btn_next.Enabled = True
        End If
        If currentPageNumber <= 1 Then
            btn_previous.Enabled = False
        Else
            btn_previous.Enabled = True
        End If
        lbl_page.Text = currentPageNumber.ToString + " / " + pageNumber.ToString

        dgv_details.Enabled = True
    End Sub

    ' Delete Async Work
    Private Sub bgw_OrderDelete_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgw_OrderDelete.DoWork
        Dim result As Boolean = False
        Dim id As Integer = e.Argument
        Dim ftpFiles As New Dictionary(Of String, Object)

        ftpFiles = Database.SelectRows(_TABLE.ORDER_CUSTOMER, {_ORDER_CUSTOMER.ORDER_ID, "=", id}, _ORDER_CUSTOMER.ARTWORK, _ORDER_CUSTOMER.PAYMENT_DOC).First

        If ftpFiles IsNot Nothing And Database.Delete(_TABLE.ORDER_CUSTOMER, {_ORDER_CUSTOMER.ORDER_ID, "=", id}) Then
            If Not IsDBNull(ftpFiles.Item(_ORDER_CUSTOMER.ARTWORK)) Then
                Method.FtpDelete(My.Settings.ARTWORK_DIR, ftpFiles.Item(_ORDER_CUSTOMER.ARTWORK))
            End If

            If Not IsDBNull(ftpFiles.Item(_ORDER_CUSTOMER.PAYMENT_DOC)) Then
                Method.FtpDelete(My.Settings.PAYMENT_DIR, ftpFiles.Item(_ORDER_CUSTOMER.PAYMENT_DOC))
            End If

            result = True
        End If

        e.Result = result
    End Sub

    ' Delete Async work
    Private Sub bgw_OrderDelete_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw_OrderDelete.RunWorkerCompleted
        ShowLoadingOverlay(False)

        If e.Result Then
            dgv_details.Rows.RemoveAt(dgv_details.SelectedRows(0).Index)
            MessageBox.Show("Order has been removed successfully", "Task Completed")
        Else
            MessageBox.Show("Failed to remove order", "Error")
        End If

        dgv_details.Enabled = True
    End Sub

    ' View order detail
    Private Sub dgv_details_CellMouseDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles dgv_details.CellMouseDoubleClick
        Dim orderID As Integer = dgv_details.SelectedCells(0).Value
        Dim details As New Order_Details(orderID, -1)
        details.ShowDialog()
    End Sub

    ' Reload datagridview data
    Private Sub btn_refresh_Click(sender As Object, e As EventArgs) Handles btn_refresh.Click
        LoadDataGridData()
    End Sub

    ' Start worker async
    Private Sub LoadDataGridData(Optional ByVal orderID As Integer = -1)
        dgv_details.Enabled = False
        bgw_OrderLoader.RunWorkerAsync(orderID)
        ShowLoadingOverlay(True)
    End Sub

    Private Sub ShowLoadingOverlay(ByVal show As Boolean)
        If show Then
            loadingOverlay = New Loading_Overlay
            loadingOverlay.Size = New Size(Me.Width - 16, Me.Height - 38)
            loadingOverlay.ShowDialog()
        Else
            loadingOverlay.Close()
        End If
    End Sub

    Private Sub btn_previous_Click(sender As Object, e As EventArgs) Handles btn_previous.Click
        currentPageNumber -= 1
        LoadDataGridData()
    End Sub

    Private Sub btn_next_Click(sender As Object, e As EventArgs) Handles btn_next.Click
        currentPageNumber += 1
        LoadDataGridData()
    End Sub

    Private Sub CalculatePageNumber()
        Dim sqlStmt As String = String.Concat("SELECT COUNT(",
                                                  _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ORDER_ID, ")",
                                                  " FROM ", _TABLE.ORDER_CUSTOMER, " INNER JOIN ", _TABLE.ORDER_LOG,
                                                  " ON ", _TABLE.ORDER_CUSTOMER, ".", _ORDER_CUSTOMER.ORDER_ID,
                                                  "=", _TABLE.ORDER_LOG, ".", _ORDER_LOG.ORDER_ID,
                                                  " WHERE ", _TABLE.ORDER_LOG, ".", _ORDER_LOG.DATETIME, " IN ",
                                                  " (SELECT MAX(", _ORDER_LOG.DATETIME, ") FROM ", _TABLE.ORDER_LOG,
                                                  " GROUP BY ", _ORDER_LOG.ORDER_ID, ")"
                                )
        pageNumber = Math.Ceiling(Database.countRows(sqlStmt) / My.Settings.PAGINATION_LIMIT)
    End Sub
End Class