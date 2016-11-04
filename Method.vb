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
    ''' <returns>Login status</returns>
    Public Shared Function Login(ByVal username As String, ByVal password As String) As Integer

        ' DUPLICATE USERNAME
        Dim users As List(Of Dictionary(Of String, Object))

        users = Database.SelectRows("user", {"username", "=", username})

        If users IsNot Nothing Then
            For Each user In users
                Dim hashedPassword As String = Security.Hash(password, user.Item("salt").ToString)

                If hashedPassword.CompareTo(user.Item("password").ToString) = 0 Then
                    MessageBox.Show("Login successed")
                    Return Constant.LOGIN.SUCCESSED
                End If
            Next

            MessageBox.Show("Login failed")
            Return Constant.LOGIN.FAILED
        End If

        MessageBox.Show("No such username available")
        Return Constant.LOGIN.USER_NOT_AVAILABLE



        ' ATOMIC USERNAME
        'Dim user As Dictionary(Of String, Object)

        'user = Database.SelectRow("user", "username", username)

        'If user IsNot Nothing Then
        '    Dim hashedPassword As String = Security.Hash(password, user.Item("salt").ToString)

        '    If hashedPassword.CompareTo(user.Item("password").ToString) = 0 Then
        '        MessageBox.Show("Login successed")
        '        Return Constant.LOGIN.SUCCESSED
        '    Else
        '        MessageBox.Show("Login failed")
        '        Return Constant.LOGIN.FAILED
        '    End If
        'Else
        '    MessageBox.Show("No such username available")
        '    Return Constant.LOGIN.USER_NOT_AVAILABLE
        'End If
    End Function
End Class
