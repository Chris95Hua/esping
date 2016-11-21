Imports System.Text
Imports System.Net

''' <summary>
''' Generic class for housing all the reusable methods/models
''' </summary>
Public NotInheritable Class Method
    Private Sub New()
        ' prevent instantialization from anywhere else
    End Sub


    ''' <summary>
    ''' Get array of selected files
    ''' </summary>
    ''' <param name="type">Type of files to be selected</param>
    ''' <param name="multi">Enable multiselect (optional, default to false)</param>
    ''' <returns>Array of selected files</returns>
    Public Shared Function DialogGetFile(ByVal type As Integer, Optional ByVal multi As Boolean = False) As String()
        Dim files(0) As String

        Using openFileDialog As New OpenFileDialog()
            With openFileDialog
                .Title = "Open"

                Select Case type
                    Case _FILE.TYPE.ALL
                        .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                        .Filter = "All files (*.*)|*.*"
                    Case _FILE.TYPE.IMAGE
                        .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
                        .Filter = _FILE.FILTER.IMAGE
                    Case _FILE.TYPE.DOCUMENT
                        .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                        .Filter = _FILE.FILTER.DOCUMENT
                End Select

                .FilterIndex = 1
                .RestoreDirectory = True
                .Multiselect = multi

                If .ShowDialog() = DialogResult.OK Then
                    If multi Then
                        Return .FileNames
                    Else
                        files(0) = .FileName
                        Return files
                    End If
                End If

            End With
        End Using

        Return files
    End Function


    Public Shared Function FtpUpload(ByVal file As String, ByVal ParamArray saveDirectory() As String) As Boolean
        Dim ftpUri As New StringBuilder(_CONNECTION.FTP_URL)

        For Each directory In saveDirectory
            ftpUri.Append("/").Append(directory)
        Next

        Dim ftpRequest As FtpWebRequest = CType(WebRequest.Create(ftpUri.ToString()), FtpWebRequest)

        Try
            Dim bytes() As Byte = IO.File.ReadAllBytes(file)

            ftpRequest.Method = WebRequestMethods.Ftp.UploadFile
            ftpRequest.Credentials = New NetworkCredential(_CONNECTION.FTP_USER, _CONNECTION.FTP_PASSWORD)
            ftpRequest.UseBinary = True
            ftpRequest.ContentLength = bytes.Length()

            Using uploadStream As IO.Stream = ftpRequest.GetRequestStream()
                uploadStream.Write(bytes, 0, bytes.Length())
                uploadStream.Close()
            End Using

            Return True
        Catch ex As WebException
            MessageBox.Show(ex.Message.ToString(), "File Upload Error")
        End Try

        Return False
    End Function


    Public Shared Function FtpDownload(ByVal ParamArray filepath() As String) As IO.Stream
        Dim ftpUri As New StringBuilder(_CONNECTION.FTP_URL)

        For Each directory In filepath
            ftpUri.Append("/").Append(directory)
        Next

        Dim ftpRequest As FtpWebRequest = CType(WebRequest.Create(ftpUri.ToString()), FtpWebRequest)

        Try
            ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile
            ftpRequest.Credentials = New NetworkCredential(_CONNECTION.FTP_USER, _CONNECTION.FTP_PASSWORD)

            Return ftpRequest.GetResponse.GetResponseStream()
        Catch ex As WebException
            MessageBox.Show(ex.Message.ToString(), "File Download Error")
        End Try

        Return Nothing
    End Function


    Public Shared Function FtpDelete(ByVal ParamArray filepath() As String) As Boolean
        Dim ftpUri As New StringBuilder(_CONNECTION.FTP_URL)

        For Each directory In filepath
            ftpUri.Append("/").Append(directory)
        Next

        Try
            Dim ftpRequest As FtpWebRequest = CType(WebRequest.Create(ftpUri.ToString()), FtpWebRequest)
            ftpRequest.Method = WebRequestMethods.Ftp.DeleteFile

            Return True
        Catch ex As WebException
            MessageBox.Show(ex.Message.ToString(), "File Deletion Error")
        End Try

        Return False
    End Function


    Private Shared Function RoundedRectangle(ByVal rectangle As Rectangle, ByVal radius As Integer) As Drawing2D.GraphicsPath
        Dim path As New Drawing2D.GraphicsPath()
        Dim diameter As Integer = radius * 2

        path.AddLine(rectangle.Left + diameter, rectangle.Top, rectangle.Right - diameter, rectangle.Top)
        path.AddArc(Rectangle.FromLTRB(rectangle.Right - diameter, rectangle.Top, rectangle.Right, rectangle.Top + diameter), -90, 90)

        path.AddLine(rectangle.Right, rectangle.Top + diameter, rectangle.Right, rectangle.Bottom - diameter)
        path.AddArc(Rectangle.FromLTRB(rectangle.Right - diameter, rectangle.Bottom - diameter, rectangle.Right, rectangle.Bottom), 0, 90)

        path.AddLine(rectangle.Right - diameter, rectangle.Bottom, rectangle.Left + diameter, rectangle.Bottom)
        path.AddArc(Rectangle.FromLTRB(rectangle.Left, rectangle.Bottom - diameter, rectangle.Left + diameter, rectangle.Bottom), 90, 90)

        path.AddLine(rectangle.Left, rectangle.Bottom - diameter, rectangle.Left, rectangle.Top + diameter)
        path.AddArc(Rectangle.FromLTRB(rectangle.Left, rectangle.Top, rectangle.Left + diameter, rectangle.Top + diameter), 180, 90)

        path.CloseFigure()

        Return path
    End Function

    ' customer name, customer address (3 lines), order name, sizes, bags, barcode
    Public Shared Function GenerateBarcodeLabel(ByVal orders As Dictionary(Of String, Object)) As Image
        Dim mf As Imaging.Metafile

        ' settings
        Dim padding As Integer = 8
        Dim width As Integer = 400
        Dim height As Integer = 360
        Dim fontSizeTitle As Integer = 17
        Dim fontSizeNormal As Integer = 11
        Dim fontSizeSmall As Integer = 10
        Dim font As String = "arial"

        ' check arguments passed
        If orders.ContainsKey(_BADGE.ORDER) And
           orders.ContainsKey(_BADGE.ORDER_NAME) And
           orders.ContainsKey(_BADGE.CUSTOMER) And
           orders.ContainsKey(_BADGE.BAG) Then

            Dim bags As Integer = orders.Item(_BADGE.BAG)
            orders.Remove(_BADGE.BAG)

            ' construct rounded rectangle
            Dim border As Rectangle = Rectangle.Round(New RectangleF(0, 0, width, height + fontSizeTitle + 4))

            ' create metafile for drawing
            Using stream As New IO.MemoryStream()
                Using offScreenBufferGraphics As Graphics = Graphics.FromHwndInternal(IntPtr.Zero)
                    Dim deviceContextHandle As IntPtr = offScreenBufferGraphics.GetHdc()

                    mf = New Imaging.Metafile(
                                stream,
                                deviceContextHandle,
                                border,
                                Imaging.MetafileFrameUnit.Pixel,
                                Imaging.EmfType.EmfPlusOnly)
                    offScreenBufferGraphics.ReleaseHdc()
                End Using
            End Using


            ' generate barcode and label
            Dim barcode128 As Zen.Barcode.Code128BarcodeDraw = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum
            Dim barcode As Image = barcode128.Draw(orders.Item(_BADGE.ORDER), 60, 2)

            ' center
            Dim formatCenter As New StringFormat()
            formatCenter.Alignment = StringAlignment.Center

            Dim formatLeft As New StringFormat()
            formatLeft.Alignment = StringAlignment.Near

            ' pen for drawing lines and rounded rectangle
            Dim linePen As New Pen(Color.Black, 2)

            ' Y coordinates
            Dim yMarginFromTop As Integer = padding
            Dim yMarginFromBottom As Integer = height - fontSizeNormal - barcode.Height - (2 * padding)

            ' start drawing
            ' ========================================================================================
            Using graphic As Graphics = Graphics.FromImage(mf)
                ' graphic mode
                graphic.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

                ' draw border
                graphic.DrawPath(linePen, RoundedRectangle(border, 50))

                ' customer name
                graphic.DrawString(orders.Item(_BADGE.CUSTOMER), New Font(font, fontSizeTitle, FontStyle.Bold), New SolidBrush(Color.Black), width / 2, yMarginFromTop, formatCenter)
                orders.Remove(_BADGE.CUSTOMER)
                yMarginFromTop += (1.5 * padding) + fontSizeTitle

                If orders.ContainsKey(_BADGE.ADDRESS_1) Then
                    graphic.DrawString(orders.Item(_BADGE.ADDRESS_1), New Font(font, fontSizeNormal), New SolidBrush(Color.Black), width / 2, yMarginFromTop, formatCenter)
                    yMarginFromTop += padding + fontSizeNormal
                End If

                If orders.ContainsKey(_BADGE.ADDRESS_2) Then
                    graphic.DrawString(orders.Item(_BADGE.ADDRESS_2), New Font(font, fontSizeNormal), New SolidBrush(Color.Black), width / 2, yMarginFromTop, formatCenter)
                    yMarginFromTop += padding + fontSizeNormal
                End If

                If orders.ContainsKey(_BADGE.ADDRESS_3) Then
                    graphic.DrawString(orders.Item(_BADGE.ADDRESS_3), New Font(font, fontSizeNormal), New SolidBrush(Color.Black), width / 2, yMarginFromTop, formatCenter)
                End If

                ' separator (customer - order name)
                yMarginFromTop = (height / 4) + (2 * padding)
                graphic.DrawLine(linePen, New Point(0, yMarginFromTop), New Point(width, yMarginFromTop))

                ' order name
                yMarginFromTop += padding
                graphic.DrawString(orders.Item(_BADGE.ORDER_NAME), New Font(font, fontSizeTitle, FontStyle.Bold), New SolidBrush(Color.Black), width / 2, yMarginFromTop, formatCenter)
                orders.Remove(_BADGE.ORDER_NAME)

                ' separator (order name - details)
                yMarginFromTop += (2 * padding) + fontSizeTitle
                graphic.DrawLine(linePen, New Point(0, yMarginFromTop), New Point(width, yMarginFromTop))

                ' barcode
                Dim barcodeX As Integer = (width - barcode.Width) / 2
                Dim barcodeY As Integer = height - barcode.Height - padding - (padding / 2)

                graphic.DrawImage(barcode, barcodeX, barcodeY)

                ' barcode text
                graphic.DrawString(orders.Item(_BADGE.ORDER), New Font(font, fontSizeNormal), New SolidBrush(Color.Black), width / 2, height - padding, formatCenter)
                orders.Remove(_BADGE.ORDER)

                ' details separator
                graphic.DrawLine(linePen, New Point(width / 2, yMarginFromTop), New Point(width / 2, yMarginFromBottom))

                ' right details (quantity)
                graphic.DrawString("BAGS: " & bags & "/" & bags, New Font(font, fontSizeTitle, FontStyle.Bold), New SolidBrush(Color.Black), width / 4 * 3, yMarginFromTop - fontSizeTitle + (Math.Abs(yMarginFromBottom - yMarginFromTop) / 2), formatCenter)

                ' left details (sizes)
                Dim sizeOffset As Integer = 0
                Dim total As Integer
                For Each pair In orders
                    If sizeOffset > 6 Then
                        graphic.DrawString(String.Format("{0,-3}", pair.Key) & " - " & pair.Value, New Font(font, fontSizeSmall), New SolidBrush(Color.Black), width / 24 * 6, yMarginFromTop + padding + ((sizeOffset - 8) * fontSizeSmall), formatLeft)
                    Else
                        graphic.DrawString(String.Format("{0,-3}", pair.Key) & " - " & pair.Value, New Font(font, fontSizeSmall), New SolidBrush(Color.Black), width / 24, yMarginFromTop + padding + (sizeOffset * fontSizeSmall), formatLeft)
                    End If

                    total += pair.Value
                    sizeOffset += 2
                Next

                graphic.DrawString("TOTAL: " & total, New Font(font, fontSizeSmall), New SolidBrush(Color.Black), width / 24, yMarginFromBottom - (3 * padding), formatLeft)

                ' seperator (order detail - barcode)
                graphic.DrawLine(linePen, New Point(0, yMarginFromBottom), New Point(width, yMarginFromBottom))
            End Using
            ' ========================================================================================

            linePen.Dispose()

            ' return image
            Return mf
        End If

        Return Nothing
    End Function


    Public Shared Function CreateOrder(ByVal order As Dictionary(Of String, Object)) As Boolean
        Dim sqlStmt As New StringBuilder()
        Dim orderValues As New StringBuilder()
        Dim logValues As New StringBuilder("LAST_INSERT_ID()")
        Dim addComma As Boolean = False

        sqlStmt.Append("BEGIN; INSERT INTO ").Append(_TABLE.ORDER_CUSTOMER).Append(" (")

        For Each key In order.Keys
            If addComma Then
                sqlStmt.Append(", ")
                orderValues.Append(", ")
            End If

            sqlStmt.Append(key)
            orderValues.Append("@").Append(key)

            addComma = True
        Next

        With sqlStmt
            .Append(" ) VALUES (").Append(orderValues)
            .Append("); INSERT INTO ")
            .Append(_TABLE.ORDER_LOG).Append(" (").Append(_ORDER_LOG.ORDER_ID)
        End With

        ' add log
        Dim log As New Dictionary(Of String, Object)

        log.Add(_ORDER_LOG.DATETIME, DateTime.Now)
        log.Add(_ORDER_LOG.STATUS, _STATUS.APPROVAL_0)
        log.Add(_ORDER_LOG.C_USER, Session.user_id)
        log.Add(_ORDER_LOG.DEPARTMENT_ID, Session.department_id)

        For Each field In log
            sqlStmt.Append(", ")
            logValues.Append(", ")

            sqlStmt.Append(field.Key)
            logValues.Append("@").Append(field.Key)
            order.Add(field.Key, field.Value)
        Next

        sqlStmt.Append(") VALUES (").Append(logValues).Append("); COMMIT;")

        Return Database.ExecuteNonQuery(sqlStmt.ToString(), order) <> -1
    End Function

    Public Shared Sub OpenForm()
        Select Case Session.department_id
            Case _PROCESS.ADMIN
                Dim admin As New Manage_Order
                admin.Show()
            Case _PROCESS.APPROVAL
                Dim approve As New Approve_Order
                approve.Show()
            Case _PROCESS.CUTTING
                Dim cutting As New Cutting_Department
                cutting.Show()
            Case _PROCESS.EMBROIDERY
                Dim embroidery As New Embroidery_Department
                embroidery.Show()
            Case _PROCESS.INVENTORY
                Dim inventory As New Inventory_Preparation
                inventory.Show()
            Case _PROCESS.ORDER
                Dim order As New Manage_Order
                order.Show()
            Case _PROCESS.PRINTING
                Dim printing As New Printing_Department
                printing.Show()
            Case _PROCESS.SEWING
                Dim sewing As New Sewing_Department
                sewing.Show()
        End Select
    End Sub
End Class
