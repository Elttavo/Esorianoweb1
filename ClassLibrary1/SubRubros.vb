Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.DataRowView
Imports Microsoft.VisualBasic
Imports System.DBNull

Public Class SubRubros
    Public Shared intEMP_CODIGO As Integer
    Private intRUB_CODIGO As Integer
    Private strRUB_NOMBRE As String
    Private intSRB_CODIGO As Integer
    Private strSRB_NOMBRE As String
    Public Shared noborr As Integer = 1
    Dim intSBR_CODIGO As Integer

    Public Property EMP_CODIGO() As Integer
        Get
            Return intEMP_CODIGO
        End Get
        Set(ByVal value As Integer)
            intEMP_CODIGO = value
        End Set
    End Property
    Public Property RUB_CODIGO() As Integer
        Get
            Return intRUB_CODIGO
        End Get
        Set(ByVal value As Integer)
            intRUB_CODIGO = value
        End Set
    End Property
    Public Property RUB_NOMBRE() As String
        Get
            Return strRUB_NOMBRE
        End Get
        Set(ByVal value As String)
            strRUB_NOMBRE = value
        End Set
    End Property
    Public Property SRB_CODIGO() As Integer
        Get
            Return intSRB_CODIGO
        End Get
        Set(ByVal value As Integer)
            intSRB_CODIGO = value
        End Set
    End Property
    Public Property SRB_NOMBRE() As String
        Get
            Return strSRB_NOMBRE
        End Get
        Set(ByVal value As String)
            strSRB_NOMBRE = value
        End Set
    End Property

    Public Shared Function DeleteSUBRubro(ByVal SRB_CODIGO As Integer) As Integer
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@SRB_CODIGO", SRB_CODIGO))

        Dim retval As Integer = db.ExecuteNonQuery("DELETE FROM SorWeb.STK_SUBRUBROS WHERE SRB_codigo<>@SRB_CODIGO")
        If retval <> 1 Then
            Return -1
            Exit Function
        End If

        Return 1
    End Function

    Public Shared Function InsertSUBRubros(ByVal EMP_CODIGO As String, ByVal RUB_CODIGO As String, ByVal SRB_CODIGO As String, ByVal SRB_NOMBRE As String) As Integer
        Dim db As DBAccess = New DBAccess

        db.Parameters.Add(New SqlParameter("@EMP_CODIGO", EMP_CODIGO))
        db.Parameters.Add(New SqlParameter("@RUB_CODIGO", RUB_CODIGO))
        db.Parameters.Add(New SqlParameter("@SRB_CODIGO", SRB_CODIGO))
        db.Parameters.Add(New SqlParameter("@SRB_NOMBRE", SRB_NOMBRE))

        Dim retval As Integer = db.ExecuteNonQuery("INSERT INTO SorWeb.STK_SUBRUBROS(EMP_CODIGO ,RUB_CODIGO ,SRB_CODIGO,SRB_NOMBRE)VALUES(@EMP_CODIGO ,@RUB_CODIGO ,@SRB_CODIGO,@SRB_NOMBRE ) ")
        If retval = 1 Then
            Return 1
        Else
            Return -1
        End If
    End Function
End Class

