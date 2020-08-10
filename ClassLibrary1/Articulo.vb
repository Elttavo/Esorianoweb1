Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.DataRowView
Imports System.DBNull
Imports System.Configuration
Public Class Articulo
    Public Shared intEMP_CODIGO As Integer
    Public Shared strART_CODIGO As String
    Public Shared strART_NOMBRE As String
    Public Shared intRUB_CODIGO As Integer
    Public Shared intSRB_CODIGO As Integer
    Public Shared strART_UND_CONSUMO As String
    Public Shared intART_UND_BULTO As Integer
    Public Shared intART_ENVASE As Integer
    Public Shared intLST_CODIGO As Integer
    Public Shared intLST_PRECIO1 As Decimal
    Public Shared intLNP_CANT_PED As Decimal
    Public Shared noborr As Integer = 1


    Public Property EMP_CODIGO() As Integer
        Get
            Return intEMP_CODIGO
        End Get
        Set(ByVal value As Integer)
            intEMP_CODIGO = value
        End Set
    End Property
    Public Property ART_CODIGO() As String
        Get
            Return strART_CODIGO
        End Get
        Set(ByVal value As String)
            strART_CODIGO = value
        End Set
    End Property

    Public Property ART_NOMBRE() As String
        Get
            Return strART_NOMBRE
        End Get
        Set(ByVal value As String)
            strART_NOMBRE = value
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
    Public Property SRB_CODIGO() As Integer
        Get
            Return intSRB_CODIGO
        End Get
        Set(ByVal value As Integer)
            intSRB_CODIGO = value
        End Set
    End Property
    Public Property ART_UND_CONSUMO() As String
        Get
            Return strART_UND_CONSUMO
        End Get
        Set(ByVal value As String)
            strART_UND_CONSUMO = value
        End Set
    End Property
    Public Property ART_UND_BULTO() As Integer
        Get
            Return intART_UND_BULTO
        End Get
        Set(ByVal value As Integer)
            intART_UND_BULTO = value
        End Set
    End Property
    Public Property ART_ENVASE() As Integer
        Get
            Return intART_ENVASE
        End Get
        Set(ByVal value As Integer)
            intART_ENVASE = value
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
    Public Property LST_PRECIO1() As Decimal
        Get
            Return intLST_PRECIO1
        End Get
        Set(ByVal value As Decimal)
            intLST_PRECIO1 = value
        End Set
    End Property
    Public Property LNP_CANT_PED() As Decimal
        Get
            Return intLNP_CANT_PED
        End Get
        Set(ByVal value As Decimal)
            intLNP_CANT_PED = value
        End Set
    End Property
    Public Shared Function DeleteArticulo_linea(ByVal art_codigo As String) As Integer
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@art_codigo", art_codigo))

        Dim retval As Integer = db.ExecuteNonQuery("DELETE FROM SorWeb.STK_articulo WHERE art_codigo=@art_codigo")
        If retval <> 1 Then
            Return -1
            Exit Function
        End If

        Return 1
    End Function
    Public Shared Function DeleteArticulo(ByVal art_codigo As String) As Integer
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@art_codigo", art_codigo))

        Dim retval As Integer = db.ExecuteNonQuery("DELETE FROM SorWeb.STK_ARTICULOS WHERE art_codigo<>@art_codigo")
        If retval <> 1 Then
            Return -1
            Exit Function
        End If

        Return 1
    End Function
    Public Shared Function SelectArticulos() As DataSet
        Dim db As DBAccess = New DBAccess

        Return db.ExecuteDataSet("SELECT SorWeb.STK_ARTICULOS.ART_CODIGO, SorWeb.STK_ARTICULOS.ART_NOMBRE, SorWeb.STK_ARTICULOS.ART_UND_CONSUMO,  SorWeb.STK_UNIDADES.UND_NOMBRE, SorWeb.STK_LISTA_PRECIOS_ART.LST_PRECIO1, SorWeb.STK_ARTICULOS.ART_UND_BULTO / 100 AS ART_UND_BULTO,SorWeb.STK_ARTICULOS.ART_ENVASE / 100 AS ART_ENVASE,  CAST(0 AS int) AS CANTIDAD FROM SorWeb.STK_LISTA_PRECIOS_ART INNER JOIN SorWeb.STK_UNIDADES INNER JOIN SorWeb.STK_RUBROS INNER JOIN SorWeb.STK_SUBRUBROS ON SorWeb.STK_RUBROS.EMP_CODIGO = SorWeb.STK_SUBRUBROS.EMP_CODIGO AND SorWeb.STK_RUBROS.RUB_CODIGO = SorWeb.STK_SUBRUBROS.RUB_CODIGO INNER JOIN SorWeb.STK_ARTICULOS ON SorWeb.STK_SUBRUBROS.EMP_CODIGO = SorWeb.STK_ARTICULOS.EMP_CODIGO AND SorWeb.STK_SUBRUBROS.RUB_CODIGO = SorWeb.STK_ARTICULOS.RUB_CODIGO AND SorWeb.STK_SUBRUBROS.SRB_CODIGO = SorWeb.STK_ARTICULOS.SRB_CODIGO ON SorWeb.STK_UNIDADES.UND_CODIGO = SorWeb.STK_ARTICULOS.ART_UND_CONSUMO AND SorWeb.STK_UNIDADES.EMP_CODIGO = SorWeb.STK_ARTICULOS.EMP_CODIGO ON SorWeb.STK_LISTA_PRECIOS_ART.EMP_CODIGO = SorWeb.STK_ARTICULOS.EMP_CODIGO AND SorWeb.STK_LISTA_PRECIOS_ART.ART_CODIGO = SorWeb.STK_ARTICULOS.ART_CODIGO INNER JOIN SorWeb.STK_PEDIDOS_LINEAS ON SorWeb.STK_ARTICULOS.ART_CODIGO = SorWeb.STK_PEDIDOS_LINEAS.ART_CODIGO WHERE(SorWeb.STK_LISTA_PRECIOS_ART.LST_CODIGO = 2) GROUP BY SorWeb.STK_ARTICULOS.ART_CODIGO, SorWeb.STK_ARTICULOS.ART_NOMBRE, SorWeb.STK_ARTICULOS.ART_UND_CONSUMO,SorWeb.STK_UNIDADES.UND_NOMBRE, SorWeb.STK_LISTA_PRECIOS_ART.LST_PRECIO1, SorWeb.STK_ARTICULOS.ART_UND_BULTO,SorWeb.STK_ARTICULOS.ART_ENVASE ORDER BY SorWeb.STK_ARTICULOS.ART_NOMBRE")

    End Function

    Public Shared Function selectArti_indice() As SqlDataReader
        Dim RecTemp As SqlDataReader
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString)
        Dim mCadena = New SqlCommand()

        Try

            mCadena.CommandText = ("select * from SorWeb.STK_ARTICULOS  order by SorWeb.STK_ARTICULOS.ART_CODIGO ")
            mCadena.Connection = cn
            cn.Open()
            RecTemp = mCadena.ExecuteReader()
            Return RecTemp
        Catch ex As Exception
            Return Nothing
        End Try

    End Function


    Public Shared Function InsertArticulos(ByVal EMP_CODIGO As String, ByVal ART_CODIGO As String, ByVal RUB_CODIGO As String, ByVal SRB_CODIGO As String, ByVal ART_NOMBRE As String, ByVal ART_PLAZO_ENTREGA As String, ByVal ART_UND_CONSUMO As String, ByVal ART_IMPORTADO As String, ByVal ART_ENVASE As String, ByVal ART_UND_BULTO As String) As Integer
        Dim db As DBAccess = New DBAccess

        db.Parameters.Add(New SqlParameter("@EMP_CODIGO", EMP_CODIGO))
        db.Parameters.Add(New SqlParameter("@ART_CODIGO", ART_CODIGO))
        db.Parameters.Add(New SqlParameter("@ART_NOMBRE", ART_NOMBRE))
        db.Parameters.Add(New SqlParameter("@RUB_CODIGO", RUB_CODIGO))
        db.Parameters.Add(New SqlParameter("@SRB_CODIGO", SRB_CODIGO))
        db.Parameters.Add(New SqlParameter("@ART_PLAZO_ENTREGA", ART_PLAZO_ENTREGA))
        db.Parameters.Add(New SqlParameter("@ART_UND_CONSUMO", ART_UND_CONSUMO))
        db.Parameters.Add(New SqlParameter("@ART_IMPORTADO", ART_IMPORTADO))
        db.Parameters.Add(New SqlParameter("@ART_ENVASE", ART_ENVASE))
        db.Parameters.Add(New SqlParameter("@ART_UND_BULTO", ART_UND_BULTO))

        Dim retval As Integer = db.ExecuteNonQuery("INSERT INTO SorWeb.STK_articulos(EMP_CODIGO ,ART_CODIGO ,ART_NOMBRE ,RUB_CODIGO ,SRB_CODIGO ,ART_PLAZO_ENTREGA ,ART_UND_CONSUMO ,ART_IMPORTADO ,ART_ENVASE ,ART_UND_BULTO)VALUES(@EMP_CODIGO ,@ART_CODIGO ,@ART_NOMBRE ,@RUB_CODIGO ,@SRB_CODIGO ,@ART_PLAZO_ENTREGA ,@ART_UND_CONSUMO ,@ART_IMPORTADO ,@ART_ENVASE ,@ART_UND_BULTO)")

        If retval = 1 Then
            Return 1
        Else
            Return -1
        End If

    End Function
    Public Shared Function Updatearticulos(ByVal ART_CODIGO As String, ByVal ART_indice As Integer) As Integer
        Dim db As DBAccess = New DBAccess

        db.Parameters.Add(New SqlParameter("@ART_CODIGO", ART_CODIGO))
        db.Parameters.Add(New SqlParameter("@ART_indice", ART_indice))
        Dim retval As Integer = db.ExecuteNonQuery("update SorWeb.stk_articulos set ART_indice = @ART_indice WHERE SorWeb.STK_articulos.ART_CODIGO=@ART_CODIGO")
        If retval = 1 Then
            Return 1
        Else
            Return -1
        End If
    End Function


End Class

