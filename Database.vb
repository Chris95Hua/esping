Imports MySql.Data.MySqlClient
Imports System.Text

''' <summary>
''' Database operations
''' </summary>
Public NotInheritable Class Database
    ' constants
    Private Const connectionString As String = "host=127.0.0.1; user=root; password=; database=espring; convert zero datetime=True"


    Private Sub New()
        ' prevent instantialization from anywhere else
    End Sub


    ''' <summary>
    ''' Execute non query (insert, update, delete)
    ''' </summary>
    ''' <param name="sqlCommand">SQL statement</param>
    ''' <param name="values">Parameters</param>
    ''' <returns>Number of rows affected</returns>
    Public Shared Function ExecuteNonQuery(ByVal sqlCommand As String, ByVal values As Dictionary(Of String, Object)) As Integer
        Dim conn As New MySqlConnection(connectionString)
        Dim cmd As New MySqlCommand(sqlCommand, conn)

        ' substitute parameters with values
        For Each pair In values
            ' remove leading and trailing whitespace
            ''TODO: add sqldatatype
            ''.Parameters.Add("@" & pair.Key, MySqlDbType.Int16).Value = pair.Value
            If TypeOf pair.Value Is String Then
                cmd.Parameters.AddWithValue("@" & pair.Key, pair.Value.Trim())
            Else
                cmd.Parameters.AddWithValue("@" & pair.Key, pair.Value)
            End If
        Next

        Try
            conn.Open()
            Return cmd.ExecuteNonQuery()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message.ToString(), "Database Error")
        Finally
            conn.Dispose()
        End Try

        Return -1
    End Function


    ''' <summary>
    ''' Read rows from table (select)
    ''' </summary>
    ''' <param name="sqlCommand">SQL statement</param>
    ''' <param name="values">Conditions (optional)</param>
    ''' <returns>List of dictionary which consists of column name and its data</returns>
    Public Shared Function ExecuteReader(ByVal sqlCommand As String, Optional ByVal values As Dictionary(Of String, Object) = Nothing) As List(Of Dictionary(Of String, Object))
        Dim conn As New MySqlConnection(connectionString)
        Dim cmd As New MySqlCommand(sqlCommand, conn)
        Dim reader As MySqlDataReader
        Dim data As New List(Of Dictionary(Of String, Object))

        ' substitute parameters with values
        If values IsNot Nothing Then
            For Each pair In values
                ''TODO: add sqldatatype
                ''.Parameters.Add("@" & pair.Key, MySqlDbType.Int16).Value = pair.Value
                cmd.Parameters.AddWithValue("@" & pair.Key, pair.Value)
            Next
        End If

        Try
            conn.Open()
            reader = cmd.ExecuteReader()

            ' populate and return dictionary list if contain results
            If reader.HasRows Then
                While (reader.Read())
                    Dim pair As New Dictionary(Of String, Object)
                    For colIndex As Integer = 0 To reader.FieldCount - 1
                        pair.Add(reader.GetName(colIndex), reader.GetValue(colIndex))
                    Next

                    data.Add(pair)
                End While

                Return data
            End If

        Catch ex As MySqlException
            MessageBox.Show(ex.Message.ToString(), "Database Error")
        Finally
            conn.Dispose()
        End Try

        Return data
    End Function


    ''' <summary>
    ''' Get data from table in DataTable
    ''' </summary>
    ''' <param name="sqlCommand">SQL statement</param>
    ''' <param name="values">Parameters</param>
    ''' <returns>DataTable of selected rows</returns>
    Public Shared Function GetDataTable(ByVal sqlCommand As String, Optional ByVal values As Dictionary(Of String, Object) = Nothing) As DataTable
        Dim conn As New MySqlConnection(connectionString)
        Dim cmd As New MySqlCommand(sqlCommand, conn)
        Dim dt As New DataTable()

        If values IsNot Nothing Then
            For Each pair In values
                If TypeOf pair.Value Is String Then
                    cmd.Parameters.AddWithValue("@" & pair.Key, pair.Value.Trim())
                Else
                    cmd.Parameters.AddWithValue("@" & pair.Key, pair.Value)
                End If
            Next
        End If

        Try
            conn.Open()

            Dim adapter As New MySqlDataAdapter(cmd)
            adapter.Fill(dt)

            Return dt
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Database Error")
        Finally
            conn.Dispose()
        End Try

        Return dt
    End Function


    ''' <summary>
    ''' Check if condition is valid
    ''' </summary>
    ''' <param name="condition">Condition passed</param>
    ''' <returns>True if the condition is valid, else false</returns>
    Private Shared Function IsConditionValid(ByVal condition() As Object) As Boolean
        Dim operations() As String = {"=", ">", "<", ">=", "<="}

        If condition.Length = 3 And operations.Contains(condition(1)) Then
            Return True
        End If

        Return False
    End Function


    ''' <summary>
    ''' Insert a new record into table
    ''' </summary>
    ''' <param name="table">Name of the table</param>
    ''' <param name="data">Column names and values</param>
    ''' <remarks>
    ''' This function does not accept or use any conditions when performing 
    ''' insertion, use ExecuteNonQuery() for conditional insert instead
    ''' </remarks>
    ''' <returns>True if success or false otherwise</returns>
    Public Shared Function Insert(ByVal table As String, ByVal data As Dictionary(Of String, Object)) As Boolean
        Dim sqlStmt As New StringBuilder()
        Dim values As New StringBuilder()
        Dim addComma As Boolean = False

        sqlStmt.Append("INSERT INTO ").Append(table).Append(" (")

        For Each key In data.Keys
            ' add comma
            If addComma Then
                sqlStmt.Append(", ")
                values.Append(", ")
            End If

            ' put in table fields and parameter
            sqlStmt.Append(key)
            values.Append("@").Append(key)

            ' skip the first field and value
            addComma = True
        Next

        ' append all strings
        sqlStmt.Append(") VALUES (").Append(values).Append(")")

        If ExecuteNonQuery(sqlStmt.ToString(), data) <> -1 Then
            Return True
        End If

        Return False
    End Function


    ''' <summary>
    ''' Update single record in table using ID
    ''' </summary>
    ''' <param name="table">Name of the table</param>
    ''' <param name="condition">Condition used when updating (e.g: "id", "=", "5")</param>
    ''' <param name="data">Column names and values</param>
    ''' <returns>True if success or false otherwise</returns>
    Public Shared Function Update(ByVal table As String, ByVal condition() As Object, ByVal data As Dictionary(Of String, Object)) As Boolean
        If IsConditionValid(condition) Then
            Dim sqlStmt As New StringBuilder()
            Dim addComma As Boolean = False

            ' construct sql statement
            sqlStmt.Append("UPDATE ").Append(table).Append(" SET ")

            For Each key In data.Keys
                ' add comma
                If addComma Then
                    sqlStmt.Append(", ")
                End If

                ' put in table fields and parameter
                sqlStmt.AppendFormat("{0} = @{0}", key)

                ' skip the first field and value
                addComma = True
            Next

            ' append all strings
            sqlStmt.Append(" WHERE ").Append(condition(0)).Append(condition(1)).Append("@").Append(condition(0))

            data.Add(condition(0), condition(2))

            ' update record
            If ExecuteNonQuery(sqlStmt.ToString(), data) <> -1 Then
                Return True
            End If
        End If

        Return False
    End Function


    ''' <summary>
    ''' Delete single record from table using ID
    ''' </summary>
    ''' <param name="table">Name of the table</param>
    ''' <param name="condition">Condition used when deleting (e.g: "id", "=", "5")</param>
    ''' <returns>True if success or false otherwise</returns>
    Public Shared Function Delete(ByVal table As String, ByVal condition() As Object) As Boolean
        If IsConditionValid(condition) Then
            Dim sqlStmt As String = String.Concat("DELETE FROM ", table, " WHERE ", condition(0), condition(1), "@", condition(0))
            Dim pair As New Dictionary(Of String, Object)

            pair.Add(condition(0), condition(2))

            If ExecuteNonQuery(sqlStmt, pair) <> -1 Then
                Return True
            End If
        End If

        Return False
    End Function

    ''' <summary>
    ''' Determine columns to return
    ''' </summary>
    ''' <param name="returnColumns">Columns to be returned</param>
    ''' <returns>Columns to return in string</returns>
    Private Shared Function ColumnsToReturn(ByVal returnColumns() As String) As String
        Dim selectedColumns As New StringBuilder()
        Dim addComma As Boolean = False

        If returnColumns.Count = 0 Then
            ' select all
            selectedColumns.Append("*")
        Else
            ' select certain columns only
            For Each returnColumn In returnColumns
                If addComma Then
                    selectedColumns.Append(", ")
                End If

                selectedColumns.Append(returnColumn)

                addComma = True
            Next
        End If

        Return selectedColumns.ToString()
    End Function

    ''' <summary>
    ''' Return all rows from table
    ''' </summary>
    ''' <param name="table">Name of the table</param>
    ''' <param name="returnColumns">Columns to be returned (optional)</param>
    ''' <remarks>
    ''' This function does not accept or use any conditions when selecting 
    ''' from database, use ExecuteReader() for conditional selection instead
    ''' </remarks>
    ''' <returns>List of dictionary which consists of column name and its data</returns>
    Public Shared Function SelectAllRows(ByVal table As String, ByVal ParamArray returnColumns() As String) As List(Of Dictionary(Of String, Object))
        Dim sqlStmt As New StringBuilder("SELECT ")

        sqlStmt.Append(ColumnsToReturn(returnColumns)).Append(" FROM ").Append(table)

        Return ExecuteReader(sqlStmt.ToString())
    End Function


    ''' <summary>
    ''' Return all rows from table. Return null (nothing) if no records can be found
    ''' </summary>
    ''' <param name="table">Name of the table</param>
    ''' <param name="condition">Condition used when selecting (e.g: "id", "=", "5")</param>
    ''' <param name="returnColumns">Columns to be returned (optional)</param>
    ''' <returns>List of dictionary which consists of column name and its data</returns>
    Public Shared Function SelectRows(ByVal table As String, ByVal condition() As Object, ByVal ParamArray returnColumns() As String) As List(Of Dictionary(Of String, Object))
        If IsConditionValid(condition) Then
            Dim sqlStmt As New StringBuilder("SELECT ")
            Dim pair As New Dictionary(Of String, Object)

            pair.Add(condition(0), condition(2))

            sqlStmt.Append(ColumnsToReturn(returnColumns)).Append(" FROM ").Append(table).Append(" WHERE BINARY ").Append(condition(0)).Append(condition(1)).Append("@").Append(condition(0))

            Return ExecuteReader(sqlStmt.ToString(), pair)
        End If

        Return Nothing
    End Function

End Class
