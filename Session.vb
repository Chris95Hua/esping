Public Class Session
    Public Shared Property user_id As Integer
    Public Shared Property first_name As String
    Public Shared Property last_name As String
    Public Shared Property username As String
    Public Shared Property password As String
    Public Shared Property salt As String
    Public Shared Property role As Integer
    Public Shared Property department_id As Integer

    Public Shared Sub Clear()
        Session.department_id = Nothing
        Session.first_name = Nothing
        Session.last_name = Nothing
        Session.password = Nothing
        Session.role = Nothing
        Session.salt = Nothing
        Session.user_id = Nothing
        Session.username = Nothing
    End Sub
End Class