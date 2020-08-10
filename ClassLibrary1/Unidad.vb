Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.DataRowView
Imports Microsoft.VisualBasic
Imports System.DBNull

Public Class Unidad
    Public Shared intEMP_CODIGO As Integer
    Private intUNDCODIGO As Integer
    Private strUNDNOMBRE As String
    Public Shared noborr As Integer = 1
    Public Property EMP_CODIGO() As Integer
        Get
            Return intEMP_CODIGO
        End Get
        Set(ByVal value As Integer)
            intEMP_CODIGO = value
        End Set
    End Property
    Public Property UNDCODIGO() As Integer
        Get
            Return intUNDCODIGO
        End Get
        Set(ByVal value As Integer)
            intUNDCODIGO = value
        End Set
    End Property
    Public Property UNDNOMBRE() As String
        Get
            Return strUNDNOMBRE
        End Get
        Set(ByVal value As String)
            strUNDNOMBRE = value
        End Set
    End Property
    Public Shared Function DeleteUnidad(ByVal UND_CODIGO As Integer) As Integer
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@UND_CODIGO", UND_CODIGO))

        Dim retval As Integer = db.ExecuteNonQuery("DELETE FROM SorWeb.STK_UNIDADES WHERE RUB_codigo<>@UND_CODIGO")
        If retval <> 1 Then
            Return -1
            Exit Function
        End If

        Return 1
    End Function

    Public Shared Function InsertUnidad(ByVal EMP_CODIGO As String, ByVal UND_CODIGO As String, ByVal UND_NOMBRE As String) As Integer
        Dim db As DBAccess = New DBAccess

        db.Parameters.Add(New SqlParameter("@EMP_CODIGO", EMP_CODIGO))
        db.Parameters.Add(New SqlParameter("@UND_CODIGO", UND_CODIGO))
        db.Parameters.Add(New SqlParameter("@UND_NOMBRE", UND_NOMBRE))

        Dim retval As Integer = db.ExecuteNonQuery("INSERT INTO SorWeb.STK_UNIDADES(EMP_CODIGO ,UND_CODIGO ,UND_NOMBRE)VALUES(@EMP_CODIGO ,@UND_CODIGO ,@UND_NOMBRE) ")
        If retval = 1 Then
            Return 1
        Else
            Return -1
        End If
    End Function

End Class
