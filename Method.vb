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
        users = Database.SelectRows(TABLE.USER, {USER.USERNAME, "=", username}, {USER.USERNAME, USER.PASSWORD, USER.SALT, USER.ROLE})

        If users IsNot Nothing Then
            For Each user In users
                Dim hashedPassword As String = Security.Hash(password, user.Item("salt").ToString)

                If hashedPassword.CompareTo(user.Item("password").ToString) = 0 Then
                    Return {LOGIN_STATUS.SUCCESSED, user.Item("role")}
                End If
            Next
        End If

        Return {LOGIN_STATUS.FAILED, -1}
    End Function
End Class
