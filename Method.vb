Imports System.Text
Imports System.Net

''' <summary>
''' Generic class for housing all the methods/models
''' </summary>
Public NotInheritable Class Method
    Private Sub New()
        ' prevent instantialization from anywhere else
    End Sub

    ''' <summary>
    ''' Login using username and password
    ''' </summary>
    ''' <param name="username">Username string</param>
    ''' <param name="password">Password string</param>
    ''' <returns>True if success, else false</returns>
    Public Shared Function Login(ByVal username As String, ByVal password As String) As Boolean
        Dim users As List(Of Dictionary(Of String, Object))
        users = Database.SelectRows(_TABLE.USER, {_USER.USERNAME, "=", username})

        If users IsNot Nothing Then
            For Each user In users
                Dim hashedPassword As String = Security.Hash(password, user.Item(_USER.SALT).ToString())

                If hashedPassword.CompareTo(user.Item(_USER.PASSWORD).ToString()) = 0 Then
                    Session.user_id = user.Item(_USER.USER_ID)
                    Session.first_name = user.Item(_USER.FIRST_NAME)
                    Session.last_name = user.Item(_USER.LAST_NAME)
                    Session.username = user.Item(_USER.USERNAME)
                    Session.password = user.Item(_USER.PASSWORD)
                    Session.salt = user.Item(_USER.SALT)
                    Session.role = user.Item(_USER.ROLE)
                    Session.department_id = user.Item(_USER.DEPARTMENT_ID)
                    Return True
                End If
            Next
        End If

        Return False
    End Function

    ''' <summary>
    ''' Update user password
    ''' </summary>
    ''' <param name="oldPass">Old password</param>
    ''' <param name="newPass">New password</param>
    ''' <param name="retypePass">Retyped password</param>
    ''' <returns>True if success, else false</returns>
    Public Shared Function UpdatePassword(ByVal oldPass As String, ByVal newPass As String, ByVal retypePass As String) As Boolean
        Dim hashedOldPass As String = Security.Hash(oldPass, Session.salt.ToString)

        If hashedOldPass.CompareTo(Session.password) = 0 And newPass = retypePass Then
            Dim newSalt As String = Security.GenerateSalt()
            Dim hashedNewPass As String = Security.Hash(newPass, newSalt)
            Dim update As New Dictionary(Of String, Object)

            update.Add(_USER.PASSWORD, hashedNewPass)
            update.Add(_USER.SALT, newSalt)
            update.Add(_USER.E_USER, Session.user_id)
            update.Add(_USER.E_DATE, DateTime.Now)
            Session.salt = newSalt
            Session.password = hashedNewPass

            If Database.Update(_TABLE.USER, {_USER.USER_ID, "=", Session.user_id}, update) Then
                Return True
            End If
        End If

        Return False
    End Function

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
        log.Add(_ORDER_LOG.STATUS, "Processing")
        log.Add(_ORDER_LOG.C_USER, Session.user_id)

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

    Public Shared Function Registration(ByVal firstName As String, ByVal lastName As String, ByVal department As Integer, ByVal role As Integer, ByVal username As String, ByVal password As String) As Boolean
        Dim users As List(Of Dictionary(Of String, Object))
        Dim dataIn As New Dictionary(Of String, Object)
        Dim salt As String = Security.GenerateSalt()
        dataIn.Add(_USER.FIRST_NAME, firstName)
        dataIn.Add(_USER.LAST_NAME, lastName)
        dataIn.Add(_USER.USERNAME, username)
        dataIn.Add(_USER.SALT, salt)
        dataIn.Add(_USER.PASSWORD, Security.Hash(password, salt))
        dataIn.Add(_USER.DEPARTMENT_ID, department)
        dataIn.Add(_USER.ROLE, role)
        dataIn.Add(_USER.C_USER, Session.user_id)
        dataIn.Add(_USER.C_DATE, DateTime.Now)

        users = Database.SelectRows(_TABLE.USER, {_USER.USERNAME, "=", username})
        If users Is Nothing Then
            If Database.Insert(_TABLE.USER, dataIn) Then
                Return True
            End If
        End If
        Return False
    End Function

    Public Shared Sub OpenForm()
        If Session.department_id = _PROCESS.APPROVAL Then
            'Approve Order
            Dim approve As New Manage_Order
            'Dim approve As New Approve_Order
            approve.Show()
        ElseIf Session.department_id = _PROCESS.CUTTING Then
            'Cutting Department
            Dim cutting As New Cutting_Department
            cutting.Show()
        ElseIf Session.department_id = _PROCESS.EMBROIDERY Then
            'Embroidery Department
            Dim embroidery As New Embroidery_Department
            embroidery.Show()
        ElseIf Session.department_id = _PROCESS.INVENTORY Then
            'Inventory Preparation
            Dim inventory As New Inventory_Preparation
            inventory.Show()
        ElseIf Session.department_id = _PROCESS.ORDER Then
            'Manage Order 
            Dim order As New Manage_Order
            order.Show()
        ElseIf Session.department_id = _PROCESS.PRINTING Then
            'Printing Department
            Dim printing As New Printing_Department
            printing.Show()
        ElseIf Session.department_id = _PROCESS.SEWING Then
            'Sewing Department
            Dim sewing As New Sewing_Department
            sewing.Show()
        End If
    End Sub

    Public Shared Function addInventory(ByVal inventory_name As String) As Boolean
        Dim invList As List(Of Dictionary(Of String, Object))
        Dim itemName As New Dictionary(Of String, Object)
        itemName.Add(_INVENTORY.ITEM, inventory_name)

        invList = Database.SelectRows(_TABLE.INVENTORY, {_INVENTORY.ITEM, "=", inventory_name})
        If invList Is Nothing Then
            If Database.Insert(_TABLE.INVENTORY, itemName) Then
                Return True
            End If
        End If
        Return False
    End Function
End Class
