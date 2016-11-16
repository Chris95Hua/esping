' Database settings
Public NotInheritable Class _CONNECTION
    Public Const DB_HOST As String = "127.0.0.1"
    Public Const DB_USER As String = "root"
    Public Const DB_PASSWORD As String = ""
    Public Const DB_NAME As String = "espring"

    Public Const FTP_URL As String = "ftp://192.168.1.23/espring"
    Public Const FTP_USER As String = "espring"
    Public Const FTP_PASSWORD As String = "1234"
End Class


Public NotInheritable Class _FTP_DIRECTORY
    Public Const PAYMENT As String = "payment"
    Public Const ARTWORK As String = "artwork"
End Class


' List of table available in the database
Public NotInheritable Class _TABLE
    Public Const USER As String = "user"
    Public Const ROLE As String = "role"
    Public Const ORDER_CUSTOMER As String = "order_customer"
    Public Const ORDER_LOG As String = "order_log"
    Public Const DEPARTMENT As String = "department"
    Public Const INVENTORY As String = "inventory"
    Public Const STATUS As String = "status"
End Class


' List of columns available in "user" table
Public NotInheritable Class _USER
    Public Const USER_ID As String = "user_id"
    Public Const FIRST_NAME As String = "first_name"
    Public Const LAST_NAME As String = "last_name"
    Public Const USERNAME As String = "username"
    Public Const PASSWORD As String = "password"
    Public Const SALT As String = "salt"
    Public Const ROLE As String = "role"
    Public Const DEPARTMENT_ID As String = "department_id"
    Public Const C_USER As String = "c_user"
    Public Const C_DATE As String = "c_date"
    Public Const E_USER As String = "e_user"
    Public Const E_DATE As String = "e_date"
End Class


' List of columns available in "role" table
Public NotInheritable Class _ROLE
    Public Const ROLE_ID As String = "role_id"
    Public Const TITLE As String = "title"
    Public Const C_USER As String = "c_user"
    Public Const C_DATE As String = "c_date"
    Public Const E_USER As String = "e_user"
    Public Const E_DATE As String = "e_date"
End Class


' List of columns available in "order_customer" table
Public NotInheritable Class _ORDER_CUSTOMER
    Public Const ORDER_ID As String = "order_id"
    Public Const ORDER_NAME As String = "order_name"
    Public Const SALESPERSON_ID As String = "salesperson_id"
    Public Const CUSTOMER As String = "customer"
    Public Const FABRIC As String = "fabric"
    Public Const COLLAR As String = "collar"
    Public Const CUFF As String = "cuff"
    Public Const FRONT As String = "front"
    Public Const BACK As String = "back"
    Public Const ARTWORK As String = "artwork"
    Public Const SIZE As String = "size"
    Public Const MATERIAL As String = "material"
    Public Const COLOUR As String = "colour"
    Public Const PACKAGING As String = "packaging"
    Public Const ISSUE_DATE As String = "issue_date"
    Public Const DELIVERY_DATE As String = "delivery_date"
    Public Const PAYMENT As String = "payment"
    Public Const PAYMENT_DOC As String = "payment_doc"
    Public Const AMOUNT As String = "amount"
    Public Const REMARKS As String = "remarks"
    Public Const inventory_order As String = "inventory_order"
    Public Const APPROVAL As String = "approval"
    Public Const INVENTORY As String = "inventory"
    Public Const CUTTING As String = "cutting"
    Public Const EMBROIDERY As String = "embroidery"
    Public Const PRINTING As String = "printing"
    Public Const SEWING As String = "sewing"
    Public Const E_USER As String = "e_user"
    Public Const E_DATE As String = "e_date"
End Class


' List of columns available in "order_log" table
Public NotInheritable Class _ORDER_LOG
    Public Const LOG_ID As String = "log_id"
    Public Const ORDER_ID As String = "order_id"
    Public Const DATETIME As String = "datetime"
    Public Const DEPARTMENT_ID As String = "department_id"
    Public Const STATUS As String = "status"
    Public Const C_USER As String = "c_user"
    Public Const E_USER As String = "e_user"
    Public Const E_DATE As String = "e_date"
End Class


' List of columns available in "department" table
Public NotInheritable Class _DEPARTMENT
    Public Const DEPARTMENT_ID As String = "department_id"
    Public Const NAME As String = "name"
    Public Const C_USER As String = "c_user"
    Public Const C_DATE As String = "c_date"
    Public Const E_USER As String = "e_user"
    Public Const E_DATE As String = "e_date"
End Class


' List of columns available in "inventory" table
Public NotInheritable Class _INVENTORY
    Public Const INVENTORY_ID As String = "inventory_id"
    Public Const ITEM As String = "item"
    Public Const QUANTITY As String = "quantity"
    Public Const C_USER As String = "c_user"
    Public Const C_DATE As String = "c_date"
    Public Const E_USER As String = "e_user"
    Public Const E_DATE As String = "e_date"
End Class


' List of columns available in "status" table
Public NotInheritable Class _STATUS
    Public Const CHECK_ID As String = "check_id"
    Public Const STATUS_ID As String = "status_id"
    Public Const STATUS As String = "status"
End Class


' Json fields
Public NotInheritable Class _JSON_FIELD
    Public Const FABRIC As String = "fabric"
    Public Const SPLIT As String = "split"

    Public Const PRINTING As String = "printing"
    Public Const HEAT As String = "heat"
    Public Const EMBROIDERY As String = "embroidery"
    Public Const PLAIN As String = "plain"

    Public Const XS As String = "xs"
    Public Const S As String = "s"
    Public Const M As String = "m"
    Public Const L As String = "l"
    Public Const XL As String = "xl"
    Public Const XXL As String = "2xl"
    Public Const XXXL As String = "3xl"

    Public Const NO_PACKAGE As String = "no"
    Public Const NORMAL_PACKAGE As String = "normal"
    Public Const SUGARBAG_PACKAGE As String = "sugerbag"
    Public Const FOLLOW_PACKAGE As String = "follow"

    Public Const CASH As String = "cash"
    Public Const CHEQUE As String = "cheque"
End Class


' Department/process
Public Enum _PROCESS
    APPROVAL = 1
    CUTTING = 2
    EMBROIDERY = 3
    INVENTORY = 4
    ORDER = 5
    PRINTING = 6
    SEWING = 7
End Enum


' File config/constant when opening/saving images/files
Public NotInheritable Class _FILE
    ' File action (for OpenFileDialog)
    Public Enum TYPE
        ALL = 100
        IMAGE = 101
        AUDIO = 102
        VIDEO = 103
        DOCUMENT = 104
    End Enum

    ' File filter (for OpenFileDialog)
    Public Structure FILTER
        Const IMAGE As String = "All Files|*.*|Bitmap (*.bmp;*.dip)|*.bmp;*.dip|PNG (*.png)|*.png|JPEG (*.jpg;*.jpeg;*.jpe;*.jfif)|*.jpg;*.jpeg;*.jpe;*.jfif|GIF (*.gif)|*.gif|TIFF (*.tif;*.tiff)|*.tif;*.tiff"
        Const DOCUMENT As String = "All Files|*.*|Word Document (*.docx))|*.docx|Word 97-2004 Document (*.doc)|*.doc|Excel 97-2003 Worksheet (*.xls)|*.xls|Excel workbook (*.xlsx)|*.xlsx|PDF (*.pdf)|*.pdf"
    End Structure
End Class



'' BARCODE USAGE
'Dim barcode128 As Zen.Barcode.Code128BarcodeDraw = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum
' return image file
' text, height, scale
'pic_barcode.Image = barcode128.Draw(txt_barcodeText.Text, 40, 2)


'' DB USAGE
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