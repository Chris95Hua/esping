''' <summary>
''' Constants
''' </summary>
Public Module Constant
    '' Login
    Public Enum LOGIN_STATUS
        FAILED = 0
        SUCCESSED = 1
    End Enum

    '' List of table available in the database
    Public Structure TABLE
        Const USER As String = "user"
        Const ROLE As String = "role"
        Const ORDER_CUSTOMER As String = "order_customer"
        Const ORDER_LOG As String = "order_log"
        Const DEPARTMENT As String = "department"
    End Structure

    '' List of columns available in "user" table
    Public Structure USER
        Const USER_ID As String = "user_id"
        Const FIRST_NAME As String = "first_name"
        Const LAST_NAME As String = "last_name"
        Const USERNAME As String = "username"
        Const PASSWORD As String = "password"
        Const SALT As String = "salt"
        Const ROLE As String = "role"
        Const DEPARTMENT_ID As String = "department_id"
        Const C_USER As String = "c_user"
        Const C_DATE As String = "c_date"
        Const E_USER As String = "e_user"
        Const E_DATE As String = "e_date"
    End Structure

    '' List of columns available in "role" table
    Public Structure ROLE
        Const ROLE_ID As String = "role_id"
        Const TITLE As String = "title"
        Const C_USER As String = "c_user"
        Const C_DATE As String = "c_date"
        Const E_USER As String = "e_user"
        Const E_DATE As String = "e_date"
    End Structure

    '' List of columns available in "order_customer" table
    Public Structure ORDER_CUSTOMER
        Const ORDER_ID As String = "order_id"
        Const ORDER_NAME As String = "order_name"
        Const SALESPERSON_ID As String = "salesperson_id"
        Const CUSTOMER As String = "customer"
        Const FABRIC As String = "fabric"
        Const COLLAR As String = "collar"
        Const CUFF As String = "cuff"
        Const FRONT As String = "front"
        Const BACK As String = "back"
        Const ARTWORK As String = "artwork"
        Const SIZE As String = "size"
        Const MATERIAL As String = "material"
        Const COLOUR As String = "colour"
        Const PACKAGING As String = "packaging"
        Const ISSUE_DATE As String = "issue_date"
        Const DELIVERY_DATE As String = "delivery_date"
        Const PAYMENT As String = "payment"
        Const REMARKS As String = "remarks"
        Const APPROVAL As String = "approval"
        Const C_USER As String = "c_user"
        Const C_DATE As String = "c_date"
        Const E_USER As String = "e_user"
        Const E_DATE As String = "e_date"
    End Structure

    '' List of columns available in "order_log" table
    Public Structure ORDER_LOG
        Const LOG_ID As String = "log_id"
        Const ORDER_ID As String = "order_id"
        Const DATETIME As String = "datetime"
        Const STATUS As String = "status"
        Const C_USER As String = "c_user"
        Const E_USER As String = "e_user"
        Const E_DATE As String = "e_date"
    End Structure

    '' List of columns available in "department" table
    Public Structure DEPARTMENT
        Const DEPARTMENT_ID As String = "department_id"
        Const NAME As String = "name"
        Const C_USER As String = "c_user"
        Const C_DATE As String = "c_date"
        Const E_USER As String = "e_user"
        Const E_DATE As String = "e_date"
    End Structure
End Module


'' BARCODE USAGE
'Dim barcode128 As Zen.Barcode.Code128BarcodeDraw = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum
' return image file
' text, height, scale
'pic_barcode.Image = barcode128.Draw(txt_barcodeText.Text, 40, 2)


'' DB USAGE
' ADD
'Dim asd As Integer = Constant.LOGIN.FAILED
'Dim salt As String = Security.GenerateSalt()
'Dim test As New Dictionary(Of String, Object)
'test.Add("username", "dikur")
'test.Add("password", Security.Hash("123456", salt))
'test.Add("salt", salt)
'Database.Insert("user", test)


' UPDATE
'Dim update As New Dictionary(Of String, Object)
'update.Add("username", "    chye yee")
'Database.Update("user", "user_id", 11, update)


' DELETE
' Database.Delete("user", "user_id", 5)


' SELECT MULTIPLE
'Dim dictionaries As New List(Of Dictionary(Of String, Object))
'dictionaries = Database.SelectFromTable("user", "username")
'dictionaries = Database.SelectRows("user", "username", "chye")

' printing
'For Each dictionary In dictionaries
'For Each pair In dictionary
'Console.WriteLine(pair.Key & ": " & pair.Value)
'Next
'Next


' SELECT SINGLE
'Dim dictionary As New Dictionary(Of String, Object)
'Dictionary = Database.SelectRow("user", "username", "chyee")
'If dictionary Is Nothing Then
'Console.WriteLine("null")
'Else
'For Each pair In dictionary
'Console.WriteLine(pair.Key & ": " & pair.Value)
'Next
'End If