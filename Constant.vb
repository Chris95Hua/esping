''' <summary>
''' Constants
''' </summary>
Module Constant
    '' Login
    Enum LOGIN
        FAILED = 0
        SUCCESSED = 1
        USER_NOT_AVAILABLE = -1
    End Enum

    '' List of table available in the database
    Structure TABLE
        Const USER As String = "user"
        Const DEPARTMENT As String = "department"
    End Structure

    '' List of columns available in User table
    Structure USER
        Const ID As String = "user_id"
    End Structure
End Module