Imports System.Text
Imports System.Text.RegularExpressions
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
        Dim ftpUri As New StringBuilder(My.Settings.FTP_URL)

        For Each directory In saveDirectory
            ftpUri.Append("/").Append(directory)
        Next

        Dim ftpRequest As FtpWebRequest = CType(WebRequest.Create(ftpUri.ToString()), FtpWebRequest)

        Try
            Dim bytes() As Byte = IO.File.ReadAllBytes(file)

            ftpRequest.Method = WebRequestMethods.Ftp.UploadFile
            ftpRequest.Credentials = New NetworkCredential(My.Settings.FTP_USER, My.Settings.FTP_PASSWORD)
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
        Dim ftpUri As New StringBuilder(My.Settings.FTP_URL)

        For Each directory In filepath
            ftpUri.Append("/").Append(directory)
        Next

        Dim ftpRequest As FtpWebRequest = CType(WebRequest.Create(ftpUri.ToString()), FtpWebRequest)

        Try
            ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile
            ftpRequest.Credentials = New NetworkCredential(My.Settings.FTP_USER, My.Settings.FTP_PASSWORD)

            Return ftpRequest.GetResponse.GetResponseStream()
        Catch ex As WebException
            MessageBox.Show(ex.Message.ToString(), "File Download Error")
        End Try

        Return Nothing
    End Function


    Public Shared Function FtpDelete(ByVal ParamArray filepath() As String) As Boolean
        Dim ftpUri As New StringBuilder(My.Settings.FTP_URL)

        For Each directory In filepath
            ftpUri.Append("/").Append(directory)
        Next

        Try
            Dim ftpRequest As FtpWebRequest = CType(WebRequest.Create(ftpUri.ToString()), FtpWebRequest)
            ftpRequest.Method = WebRequestMethods.Ftp.DeleteFile
            ftpRequest.Credentials = New NetworkCredential(My.Settings.FTP_USER, My.Settings.FTP_PASSWORD)
            ftpRequest.GetResponse()

            Return True
        Catch ex As WebException
            MessageBox.Show(ex.Message.ToString(), "File Deletion Error")
        End Try

        Return False
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

    Public Shared Function GetOrderID(ByVal jobString As String) As Integer
        Dim delimiter As Char = _FORMAT.ORDER_DELIMITER
        Dim parts As String() = jobString.Split(New Char() {delimiter})
        Dim orderID As Integer = parts(1)
        Return orderID
    End Function

    Public Shared Function GetDept(ByVal OrderID As Integer, ByVal Dept As String) As String
        Dim itemList As List(Of Dictionary(Of String, Object))
        itemList = Database.SelectRows(_TABLE.ORDER_CUSTOMER, {_ORDER_CUSTOMER.ORDER_ID, "=", OrderID}, Dept)
        Select Case itemList(0).Item(Dept)
            Case _OPTIONAL_DEPT.PRINTING
                Return _DEPARTMENT_BARCODE.TO_PRINTING
            Case _OPTIONAL_DEPT.EMBROIDERY
                Return _DEPARTMENT_BARCODE.TO_EMBROIDERY
            Case _OPTIONAL_DEPT.PRINTING_EMBROIDERY
                Return _DEPARTMENT_BARCODE.TO_PRINT_EMBROIDERY
        End Select
        Return "N"
    End Function

    Public Shared Function IsOrderFormat(ByVal jobString As String, Optional ByVal FormatType As Integer = Nothing) As Boolean
        If FormatType = 1 Then
            Dim regexFormat As String = String.Concat("^([0-9]*", _FORMAT.ORDER_DELIMITER, "[0-9]", _FORMAT.ORDER_DELIMITER, "[a-zA-Z0-9]*){1}$")
            Return Regex.Match(jobString, regexFormat).Success
        ElseIf FormatType = 2 Then
            Dim regexFormat As String = String.Concat("[a-zA-Z]")
            Return Regex.Match(jobString, regexFormat).Success
        Else
            Dim regexFormat As String = String.Concat("^([0-9]*", _FORMAT.ORDER_DELIMITER, "[0-9]*){1}$")
            Return Regex.Match(jobString, regexFormat).Success
        End If
    End Function

    ' Regex for password
    ' numerical characters, letters, limited special characters only
    Public Shared Function IsPassword(ByVal password As String) As Boolean
        Return Regex.Match(password, "^([a-zA-Z0-9!@#$%^&*=+'()\\-`.+,/\""]{4,12})$").Success
    End Function

    ' Regex for name
    ' no special character apart from hyphen (-), single quote (') and letters only (no numerical character), space
    Public Shared Function IsName(ByVal name As String) As Boolean
        Return Regex.Match(name, "^([a-zA-Z' -]+)$").Success
    End Function

    ' Regex for username
    ' alphanumeric, hyphen and underscore only
    Public Shared Function IsUsername(ByVal username As String) As Boolean
        Return Regex.Match(username, "^([a-zA-Z0-9_-]{3,12})$").Success
    End Function

    ' Regex for inventory item
    ' numerical characters and letters only, brackets () and space
    Public Shared Function IsItemName(ByVal item As String) As Boolean
        Return Regex.Match(item, "^([a-zA-Z0-9_\\(\\) '&-]+)$").Success
    End Function
End Class
