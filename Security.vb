Imports System.Security.Cryptography
Imports System.Text

''' <summary>
''' Security operations
''' </summary>
Public NotInheritable Class Security
    Private Sub New()
        ' prevent instantialization from anywhere else
    End Sub

    ''' <summary>
    ''' Hash password using salt
    ''' </summary>
    ''' <param name="password">Password string</param>
    ''' <param name="salt">Salt string</param>
    ''' <returns>Hashed string</returns>
    Public Shared Function Hash(ByVal password As String, ByVal salt As String) As String
        Dim saltedPassBytes As Byte() = Encoding.UTF8.GetBytes(password & salt)
        Dim sha256 As New SHA256Managed()
        Dim hashBytes As Byte() = sha256.ComputeHash(saltedPassBytes)

        Return Convert.ToBase64String(hashBytes) ' 44 size
    End Function

    ''' <summary>
    ''' Generate random string of salt
    ''' </summary>
    ''' <param name="size">Byte size to be used when generating salt (optional)</param>
    ''' <returns>String of salt</returns>
    Public Shared Function GenerateSalt(Optional ByVal size As Integer = 32) As String
        Using rng As New RNGCryptoServiceProvider
            Dim bytes As Byte() = New Byte(size) {}
            rng.GetBytes(bytes)

            Return Convert.ToBase64String(bytes) ' 44 size
        End Using
    End Function

End Class
