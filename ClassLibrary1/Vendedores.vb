Imports Microsoft.VisualBasic

Imports System.Data.SqlClient

Public Class Vendedores
    Public Shared intEMP_CODIGO As Integer
    Public Shared intVen_CODIGO As Integer
    Public Shared strVen_NOMBRE As String
    Public Shared strEmail As String

    Public Property EMP_CODIGO() As Integer
        Get
            Return intEMP_CODIGO
        End Get
        Set(ByVal value As Integer)
            intEMP_CODIGO = value
        End Set
    End Property

    Public Property Ven_codigo() As Integer
        Get
            Return intVen_CODIGO
        End Get
        Set(value As Integer)
            intVen_CODIGO = value
        End Set
    End Property
    Public Property Ven_NOMBRE() As String
        Get
            Return strVen_NOMBRE
        End Get
        Set(ByVal value As String)
            strVen_NOMBRE = value
        End Set
    End Property
    Public Property Email() As String

        Get
            Return strEmail
        End Get
        Set(value As String)
            strEmail = value
        End Set
    End Property

    Public Shared Function InsertVendedores(ByVal EMP_CODIGO As String, ByVal VEN_CODIGO As String, ByVal VEN_NOMBRE As String, ByVal EMAIL As String) As Integer
        Dim db As DBAccess = New DBAccess

        db.Parameters.Add(New SqlParameter("@EMP_CODIGO", EMP_CODIGO))
        db.Parameters.Add(New SqlParameter("@VEN_CODIGO", VEN_CODIGO))
        db.Parameters.Add(New SqlParameter("@VEN_NOMBRE", VEN_NOMBRE))
        db.Parameters.Add(New SqlParameter("@EMAIL", EMAIL))



        Dim retval As Integer = db.ExecuteNonQuery("INSERT INTO SorWeb.VTS_VENDEDORES(EMP_CODIGO ,VEN_CODIGO,VEN_NOMBRE ,EMAIL) values (@EMP_CODIGO ,@VEN_CODIGO ,@VEN_NOMBRE,@EMAIL) ")
        If retval = 1 Then
            Return 1
        Else
            Return -1
        End If
    End Function


    Public Shared Function SelectVendedores(ByVal VEN_CODIGO As String) As String
        Dim db As DBAccess = New DBAccess
        Dim c As String

        db.Parameters.Add(New SqlParameter("@VEN_CODIGO", VEN_CODIGO))

        c = CType(db.ExecuteScalar("SELECT SorWeb.VTS_VENDEDORES.EMAIL FROM SorWeb.VTS_VENDEDORES WHERE SorWeb.VTS_VENDEDORES.VEN_CODIGO =@VEN_CODIGO"), String)
        Return c

    End Function
    Public Shared Function DeleteVendedores(ByVal ven_codigo As Integer) As Integer
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@ven_codigo", ven_codigo))

        Dim retval As Integer = db.ExecuteNonQuery("DELETE FROM SorWeb.VTS_VENDEDORES WHERE ven_codigo<>@ven_codigo")
        If retval <> 1 Then
            Return -1
            Exit Function
        End If

        Return 1
    End Function
End Class

