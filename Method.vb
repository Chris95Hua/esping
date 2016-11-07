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
    ''' <returns>Integer array of login status and user role</returns>
    Public Shared Function Login(ByVal username As String, ByVal password As String) As Integer()
        Dim users As List(Of Dictionary(Of String, Object))
        users = Database.SelectRows(TABLE.USER, {USER.USERNAME, "=", username}, {USER.USER_ID, USER.FIRST_NAME, USER.LAST_NAME, USER.USERNAME, USER.PASSWORD, USER.SALT, USER.ROLE, USER.DEPARTMENT_ID})

        If users IsNot Nothing Then
            For Each user In users
                Dim hashedPassword As String = Security.Hash(password, user.Item("salt").ToString)
                If hashedPassword.CompareTo(user.Item("password").ToString) = 0 Then
                    userSession.user_id = user.Item("user_id")
                    userSession.first_name = user.Item("first_name")
                    userSession.last_name = user.Item("last_name")
                    userSession.username = user.Item("username")
                    userSession.password = user.Item("password")
                    userSession.salt = user.Item("salt")
                    userSession.role = user.Item("role")
                    userSession.department_id = user.Item("department_id")
                    Return {LOGIN_STATUS.SUCCESSED, user.Item("role")}
                End If
            Next
        End If
        Return {LOGIN_STATUS.FAILED, -1}
    End Function

    Public Shared Function passwordUpdate(ByVal old As String, ByVal newPass As String, ByVal retypePass As String) As Boolean
        Dim hashedOldPass As String = Security.Hash(old, userSession.salt.ToString)
        If hashedOldPass.CompareTo(userSession.password) = 0 And newPass = retypePass Then
            Dim hashedNewPass As String = Security.Hash(newPass, userSession.salt.ToString)
            Dim update As New Dictionary(Of String, Object)
            update.Add("password", hashedNewPass)
            If Database.Update(TABLE.USER, {USER.USER_ID, "=", userSession.user_id}, update) Then
                Return True
            End If
        End If
        Return False
    End Function
End Class
