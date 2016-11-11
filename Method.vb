Imports System.Text

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
        users = Database.SelectRows(TABLE.USER, {USER.USERNAME, "=", username})

        If users IsNot Nothing Then
            For Each user In users
                Dim hashedPassword As String = Security.Hash(password, user.Item(Constant.USER.SALT).ToString())

                If hashedPassword.CompareTo(user.Item(Constant.USER.PASSWORD).ToString()) = 0 Then
                    Session.user_id = user.Item(Constant.USER.USER_ID)
                    Session.first_name = user.Item(Constant.USER.FIRST_NAME)
                    Session.last_name = user.Item(Constant.USER.LAST_NAME)
                    Session.username = user.Item(Constant.USER.USERNAME)
                    Session.password = user.Item(Constant.USER.PASSWORD)
                    Session.salt = user.Item(Constant.USER.SALT)
                    Session.role = user.Item(Constant.USER.ROLE)
                    Session.department_id = user.Item(Constant.USER.DEPARTMENT_ID)

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

            update.Add(USER.PASSWORD, hashedNewPass)
            update.Add(USER.SALT, newSalt)
            update.Add(USER.E_USER, Session.user_id)
            update.Add(USER.E_DATE, DateTime.Now)
            Session.salt = newSalt
            Session.password = hashedNewPass

            If Database.Update(TABLE.USER, {USER.USER_ID, "=", Session.user_id}, update) Then
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
                    Case FILETYPE.ALL
                        .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                        .Filter = "All files (*.*)|*.*"
                    Case FILETYPE.IMAGE
                        .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
                        .Filter = FILE_FILTER.IMAGE
                    Case FILETYPE.DOCUMENT
                        .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                        .Filter = FILE_FILTER.DOCUMENT
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

    Public Shared Function CreateOrder(ByVal order As Dictionary(Of String, Object)) As Boolean
        Dim sqlStmt As New StringBuilder()
        Dim orderValues As New StringBuilder()
        Dim logValues As New StringBuilder("LAST_INSERT_ID()")
        Dim addComma As Boolean = False

        sqlStmt.Append("BEGIN; INSERT INTO ").Append(TABLE.ORDER_CUSTOMER).Append(" (")

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
            .Append(TABLE.ORDER_LOG).Append(" (").Append(ORDER_LOG.ORDER_ID)
        End With

        ' add log
        Dim log As New Dictionary(Of String, Object)

        log.Add(ORDER_LOG.DATETIME, DateTime.Now)
        log.Add(ORDER_LOG.STATUS, "Processing")
        log.Add(ORDER_LOG.C_USER, Session.user_id)

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
End Class
