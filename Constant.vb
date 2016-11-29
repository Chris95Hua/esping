Public NotInheritable Class _FORMAT
    Public Const DATE_FORMAT As String = "%d/%m/%Y"
    Public Const DATETIME_FORMAT As String = "%d/%m/%Y %h:%i:%s %p"

    Public Const ORDER_DELIMITER As String = "-"
End Class

' List of table available in the database
Public NotInheritable Class _TABLE
    Public Const USER As String = "user"
    Public Const ROLE As String = "role"
    Public Const ORDER_CUSTOMER As String = "order_customer"
    Public Const ORDER_LOG As String = "order_log"
    Public Const DEPARTMENT As String = "department"
    Public Const INVENTORY As String = "inventory"
End Class
'SELECT CONCAT_WS("-", order_customer.salesperson_id, LPAD(order_customer.order_id, 13, '0')) As "job" FROM order_customer

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
    Public Const DELIVERY_TYPE As String = "delivery_type"
    Public Const PAYMENT As String = "payment"
    Public Const PAYMENT_DOC As String = "payment_doc"
    Public Const AMOUNT As String = "amount"
    Public Const REMARKS As String = "remarks"
    Public Const INVENTORY_ORDER As String = "inventory_order"
    Public Const PRODUCTION_PARTS As String = "production_parts"
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
    Public Const APPROVAL_0 As String = "Processing"
    Public Const APPROVAL_1 As String = "Approved"
    Public Const INVENTORY_0 As String = "Pending inventory details"
    Public Const INVENTORY_1 As String = "Collar and Cuff Department"
    Public Const CUTTING_0 As String = "Pending for action in Cutting Department"
    Public Const CUTTING_1 As String = "Cutting Department - Scan in"
    Public Const CUTTING_2 As String = "Cutting Department - Scan out and transferred goods to Printing and Embroidery"
    Public Const EMBROIDERY_0 As String = "Pending for action in Embroidery"
    Public Const EMBROIDERY_1 As String = "Embroidery Department - Scanned in"
    Public Const EMBROIDERY_2 As String = "Embroidery Department - Scanned out"
    Public Const PRINTING_0 As String = "Pending for action in Printing"
    Public Const PRINTING_1 As String = "Printing Department - Scanned in"
    Public Const PRINTING_2 As String = "Printing Department - Scanned out and transferred goods to Printing"
    Public Const SEWING_01 As String = "Pending for action in Printing and Embroidery"
    Public Const SEWING_02 As String = "Pending for action in Printing"
    Public Const SEWING_03 As String = "Pending for action in Embroidery"
    Public Const SEWING_0 As String = "Pending for action in Sewing Department"
    Public Const SEWING_1 As String = "Sewing Department - Scanned in"
    Public Const SEWING_2 As String = "Sewing Department - Scanned out and transferred goods to Logistic Department"
End Class


' Delivery type
Public Enum _DELIVERY_TYPE
    PICKUP = 0
    DELIVER = 1
End Enum


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

    Public Const FRONT As String = "front"
    Public Const BACK As String = "back"
    Public Const SLEEVE As String = "sleeve"
End Class


' Bagdge Label
Public NotInheritable Class _BADGE
    Public Const CUSTOMER As String = "customer"
    Public Const ADDRESS_1 As String = "add1"
    Public Const ADDRESS_2 As String = "add2"
    Public Const ADDRESS_3 As String = "add3"
    Public Const ORDER_NAME As String = "name"
    Public Const ORDER As String = "order"
    Public Const BAG As String = "bag"

    Public Const XS As String = "xs"
    Public Const S As String = "s"
    Public Const M As String = "m"
    Public Const L As String = "l"
    Public Const XL As String = "xl"
    Public Const XXL As String = "2xl"
    Public Const XXXL As String = "3xl"
End Class


' Department/process
Public Enum _PROCESS
    ADMIN = 0
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
        Const IMAGE As String = "All Supported Format|*.bmp;*.dip;*.png;*.jpg;*.jpeg;*.jpe;*.jfif;*.gif;*.tif;*.tiff|Bitmap (*.bmp;*.dip)|*.bmp;*.dip|PNG (*.png)|*.png|JPEG (*.jpg;*.jpeg;*.jpe;*.jfif)|*.jpg;*.jpeg;*.jpe;*.jfif|GIF (*.gif)|*.gif|TIFF (*.tif;*.tiff)|*.tif;*.tiff"
        Const DOCUMENT As String = "All Files|*.*|Word Document (*.docx))|*.docx|Word 97-2004 Document (*.doc)|*.doc|Excel 97-2003 Worksheet (*.xls)|*.xls|Excel workbook (*.xlsx)|*.xlsx|PDF (*.pdf)|*.pdf"
    End Structure
End Class