Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.DataRowView
Imports Microsoft.VisualBasic
Imports System.DBNull

Public Class Cliente
    Public Shared strEMP_CODIGO As String
    Public Shared strCLI_CODIGO As String
    Public Shared intLST_CODIGO As Integer
    Public Shared intCVT_CODIGO As Integer
    Public Shared intTIP_CODIGO As Integer
    Public Shared strCLI_NOMBRE As String
    Public Shared strUSU_NOMBRE As String
    Public Shared strCVT_NOMBRE As String
    Public Shared strUSU_PSS As String
    Public Shared strBAN_TEXTO As String
    Public Shared strVEN_CODIGO As String

    Public Property EMP_CODIGO() As String
        Get
            Return strEMP_CODIGO
        End Get
        Set(ByVal value As String)
            strEMP_CODIGO = value
        End Set
    End Property
    Public Property CLI_CODIGO() As String
        Get
            Return strCLI_CODIGO
        End Get
        Set(ByVal value As String)
            strCLI_CODIGO = value
        End Set
    End Property
    Public Property VEN_CODIGO() As String
        Get
            Return strVEN_CODIGO
        End Get
        Set(ByVal value As String)
            strVEN_CODIGO = value
        End Set
    End Property
    Public Property CLI_NOMBRE() As String
        Get
            Return strCLI_NOMBRE
        End Get
        Set(ByVal value As String)
            strCLI_NOMBRE = value
        End Set
    End Property
    Public Property USU_NOMBRE() As String
        Get
            Return strUSU_NOMBRE
        End Get
        Set(ByVal value As String)
            strUSU_NOMBRE = value
        End Set
    End Property
    Public Property USU_PSS() As String
        Get
            Return strUSU_PSS
        End Get
        Set(ByVal value As String)
            strUSU_PSS = value
        End Set
    End Property
    Public Property LST_CODIGO() As Integer
        Get
            Return intLST_CODIGO
        End Get
        Set(ByVal value As Integer)
            intLST_CODIGO = value
        End Set
    End Property
    Public Property CVT_CODIGO() As Integer
        Get
            Return intCVT_CODIGO
        End Get
        Set(ByVal value As Integer)
            intCVT_CODIGO = value
        End Set
    End Property
    Public Property CVT_NOMBRE() As String
        Get
            Return strCVT_NOMBRE
        End Get
        Set(ByVal value As String)
            strCVT_NOMBRE = value
        End Set
    End Property
    Public Property BAN_TEXTO() As String
        Get
            Return strBAN_TEXTO
        End Get
        Set(ByVal value As String)
            strBAN_TEXTO = value
        End Set
    End Property
    Public Property TIP_CODIGO() As Integer
        Get
            Return intTIP_CODIGO
        End Get
        Set(ByVal value As Integer)
            intTIP_CODIGO = value
        End Set
    End Property
    Public Shared Function SelectNomCli(ByVal CLI_CODIGO As VariantType) As String
        Dim db As DBAccess = New DBAccess
        Dim c As String
        db.AddParameter("@CLI_CODIGO", CLI_CODIGO)

        c = CType(db.ExecuteScalar("SELECT CLI_NOMBRE from SorWeb.VTS_CLIENTES WHERE CLI_CODIGO=@CLI_CODIGO"), String)
        Return c
    End Function
    Public Shared Function SelectTipCli(ByVal CLI_CODIGO As Integer) As String
        Dim db As DBAccess = New DBAccess
        Dim c As String
        db.AddParameter("@CLI_CODIGO", CLI_CODIGO)

        c = CType(db.ExecuteScalar("SELECT LST_CODIGO from SorWeb.VTS_CLIENTES WHERE CLI_CODIGO=@CLI_CODIGO"), String)
        Return c
    End Function
    Public Shared Function SelectCondVta(ByVal CLI_CODIGO As Integer, ByVal LST_CODIGO As Integer) As DataSet
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@CLI_CODIGO", CLI_CODIGO))
        db.Parameters.Add(New SqlParameter("@LST_CODIGO", LST_CODIGO))


        Return db.ExecuteDataSet("SELECT SorWeb.VTS_CONDICION_VENTA.CVT_nombre,SorWeb.VTS_CONDICION_VENTA.CVT_codigo  FROM SorWeb.VTS_CONDICION_VENTA INNER JOIN SorWeb.VTS_REL_LST_CVT ON SorWeb.VTS_CONDICION_VENTA.CVT_codigo = SorWeb.VTS_REL_LST_CVT.CVT_codigo INNER JOIN SorWeb.VTS_CLIENTES ON SorWeb.VTS_REL_LST_CVT.LST_CODIGO = SorWeb.VTS_CLIENTES.LST_CODIGO WHERE (SorWeb.VTS_CLIENTES.CLI_CODIGO = @CLI_CODIGO) AND (SorWeb.VTS_CLIENTES.LST_CODIGO = @LST_CODIGO)")

    End Function
    Public Shared Function SelectCondVta() As DataSet
        Dim db As DBAccess = New DBAccess

        Return db.ExecuteDataSet("Select SorWeb.VTS_CONDICION_VENTA.* From SorWeb.VTS_CONDICION_VENTA Where SorWeb.VTS_CONDICION_VENTA.CVT_CODIGO <> 100")

    End Function

    Public Shared Function SelectBanner(ByVal CLI_CODIGO As Integer, ByVal LST_CODIGO As Integer) As String
        Dim db As DBAccess = New DBAccess
        Dim c As String
        db.Parameters.Add(New SqlParameter("@CLI_CODIGO", CLI_CODIGO))
        db.Parameters.Add(New SqlParameter("@LST_CODIGO", LST_CODIGO))

        c = CType(db.ExecuteScalar("SELECT SorWeb.WEB_BANNER.BAN_TEXTO FROM SorWeb.WEB_BANNER INNER JOIN SorWeb.VTS_CLIENTES ON SorWeb.WEB_BANNER.TIP_CODIGO = SorWeb.VTS_CLIENTES.LST_CODIGO WHERE (SorWeb.VTS_CLIENTES.CLI_CODIGO =@CLI_CODIGO) AND (SorWeb.VTS_CLIENTES.LST_CODIGO = @LST_CODIGO)"), String)
        Return c


    End Function
    Public Shared Function SelectVendor(ByVal CLI_CODIGO As Integer) As String
        Dim db As DBAccess = New DBAccess
        Dim c As String
        db.Parameters.Add(New SqlParameter("@CLI_CODIGO", CLI_CODIGO))


        c = CType(db.ExecuteScalar("select t2.EMAIL from SorWeb.VTS_CLIENTES t1 inner join SorWeb.VTS_VENDEDORES t2 on t1.VEN_CODIGO=t2.VEN_CODIGO  WHERE t1.CLI_CODIGO =@CLI_CODIGO"), String)

        Return c


    End Function
    Public Shared Function DeleteCliente(ByVal cli_codigo As Integer) As Integer
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@cli_codigo", cli_codigo))

        Dim retval As Integer = db.ExecuteNonQuery("DELETE FROM SorWeb.VTS_CLIENTES WHERE cli_codigo<>@cli_codigo")
        If retval <> 1 Then
            Return -1
            Exit Function
        End If

        Return 1
    End Function
    Public Shared Function InsertCliente(ByVal EMP_CODIGO As String, ByVal CLI_CODIGO As String, ByVal CLI_NOMBRE As String, ByVal LST_CODIGO As Integer, ByVal USU_NOMBRE As String, ByVal USU_PSS As String, ByVal VEN_CODIGO As String) As Integer
        Dim db As DBAccess = New DBAccess

        db.Parameters.Add(New SqlParameter("@EMP_CODIGO", EMP_CODIGO))
        db.Parameters.Add(New SqlParameter("@CLI_CODIGO", CLI_CODIGO))
        db.Parameters.Add(New SqlParameter("@CLI_NOMBRE", CLI_NOMBRE))
        db.Parameters.Add(New SqlParameter("@LST_CODIGO", LST_CODIGO))
        db.Parameters.Add(New SqlParameter("@USU_NOMBRE", USU_NOMBRE))
        db.Parameters.Add(New SqlParameter("@USU_PSS", USU_PSS))
        db.Parameters.Add(New SqlParameter("@VEN_CODIGO", VEN_CODIGO))



        Dim retval As Integer = db.ExecuteNonQuery("INSERT INTO SorWeb.VTS_CLIENTES(EMP_CODIGO ,CLI_CODIGO ,CLI_NOMBRE,LST_CODIGO,USU_NOMBRE, USU_PSS,VEN_CODIGO)VALUES(@EMP_CODIGO ,@CLI_CODIGO ,@CLI_NOMBRE,@LST_CODIGO,@USU_NOMBRE, @USU_PSS,@VEN_CODIGO) ")
        If retval = 1 Then
            Return 1
        Else
            Return -1
        End If
    End Function
End Class

