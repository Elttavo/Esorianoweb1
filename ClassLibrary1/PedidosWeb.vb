Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.DataRowView
Imports Microsoft.VisualBasic
Imports System.DBNull

Public Class Pedidosweb
    Public Shared intEMP_CODIGO As Integer
    Private intPED_CODIGO As Integer
    Private intCLI_CODIGO As Integer
    Private fecPED_FECHA As Date
    Private intEST_CODIGO As Integer
    Private intCVT_CODIGO As Integer
    Private strPED_MEMO As String
    Private strSEG_USUARIO As String
    Private fecSEG_HORA As DateTime
    Private fecSEG_FECHA As DateTime
    Private intLNP_CODIGO As Integer
    Private intLNP_CANT_PED As Decimal
    Private intLNP_PRECIO As Decimal
    Private strART_CODIGO As String
    Private strUND_CODIGO As String
    Private strEST_NOMBRE As String



    Public Property EMP_CODIGO() As Integer
        Get
            Return intEMP_CODIGO
        End Get
        Set(ByVal value As Integer)
            intEMP_CODIGO = value
        End Set
    End Property
    Public Property PED_CODIGO() As Integer
        Get
            Return intPED_CODIGO
        End Get
        Set(ByVal value As Integer)
            intPED_CODIGO = value
        End Set
    End Property
    Public Property CLI_CODIGO() As Integer
        Get
            Return intCLI_CODIGO
        End Get
        Set(ByVal value As Integer)
            intCLI_CODIGO = value
        End Set
    End Property
    Public Property PED_FECHA() As Date
        Get
            Return fecPED_FECHA
        End Get
        Set(ByVal value As Date)
            fecPED_FECHA = value
        End Set
    End Property
    Public Property EST_CODIGO() As Integer
        Get
            Return intEST_CODIGO
        End Get
        Set(ByVal value As Integer)
            intEST_CODIGO = value
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
    Public Property PED_MEMO() As String
        Get
            Return strPED_MEMO
        End Get
        Set(ByVal value As String)
            strPED_MEMO = value
        End Set
    End Property
    Public Property SEG_USUARIO() As String
        Get
            Return strSEG_USUARIO
        End Get
        Set(ByVal value As String)
            strSEG_USUARIO = value
        End Set
    End Property
    Public Property SEG_FECHA() As DateTime
        Get
            Return fecSEG_FECHA
        End Get
        Set(ByVal value As DateTime)
            fecSEG_FECHA = value
        End Set
    End Property
    Public Property SEG_HORA() As DateTime
        Get
            Return fecSEG_HORA
        End Get
        Set(ByVal value As DateTime)
            fecSEG_HORA = value
        End Set
    End Property
    Public Property LNP_CODIGO() As Integer
        Get
            Return intLNP_CODIGO
        End Get
        Set(ByVal value As Integer)
            intLNP_CODIGO = value
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
    Public Property LNP_PRECIO() As Decimal
        Get
            Return intLNP_PRECIO
        End Get
        Set(ByVal value As Decimal)
            intLNP_PRECIO = value
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
    Public Property UND_CODIGO() As String
        Get
            Return strUND_CODIGO
        End Get
        Set(ByVal value As String)
            strUND_CODIGO = value
        End Set
    End Property
    Public Property EST_NOMBRE() As String
        Get
            Return strEST_NOMBRE
        End Get
        Set(ByVal value As String)
            strEST_NOMBRE = value
        End Set
    End Property
    Public Shared Function InsertPedidos(ByVal EMP_CODIGO As Integer, ByVal CLI_CODIGO As Integer, ByVal PED_FECHA As Date, ByVal EST_CODIGO As Integer, ByVal CVT_CODIGO As Integer, ByVal PED_MEMO As String, ByVal SEG_USUARIO As String, ByVal SEG_FECHA As Date, ByVal CVT_NOMBRE As String) As Integer
        Dim db As DBAccess = New DBAccess

        db.Parameters.Add(New SqlParameter("@EMP_CODIGO", EMP_CODIGO))
        db.Parameters.Add(New SqlParameter("@CLI_CODIGO", CLI_CODIGO))
        db.Parameters.Add(New SqlParameter("@PED_FECHA", PED_FECHA))
        db.Parameters.Add(New SqlParameter("@EST_CODIGO", EST_CODIGO))
        db.Parameters.Add(New SqlParameter("@CVT_CODIGO", CVT_CODIGO))
        db.Parameters.Add(New SqlParameter("@CVT_NOMBRE", CVT_NOMBRE))
        db.Parameters.Add(New SqlParameter("@PED_MEMO", PED_MEMO))
        db.Parameters.Add(New SqlParameter("@SEG_USUARIO", SEG_USUARIO))
        db.Parameters.Add(New SqlParameter("@SEG_FECHA", SEG_FECHA))


        Dim retval As Integer = db.ExecuteNonQuery("INSERT INTO SorWeb.STK_PEDIDOS(EMP_CODIGO,CLI_CODIGO,PED_FECHA,EST_CODIGO,CVT_CODIGO,CVT_NOMBRE,PED_MEMO,SEG_USUARIO,SEG_FECHA,SEG_HORA)VALUES(@EMP_CODIGO,@CLI_CODIGO,@PED_FECHA,@EST_CODIGO,@CVT_CODIGO,@CVT_NOMBRE,@PED_MEMO,@SEG_USUARIO,@SEG_FECHA,convert(datetime, convert(varchar, GETDATE(), 108), 108))")
        If retval = 1 Then
            Return 1
        Else
            Return -1
        End If
    End Function
    Public Shared Function InsertPedidosLinea(ByVal EMP_CODIGO As Integer, ByVal PED_CODIGO As Integer, ByVal LNP_CODIGO As Integer, ByVal LNP_CANT_PED As Decimal, ByVal LNP_PRECIO As Decimal, ByVal ART_CODIGO As String, ByVal UND_CODIGO As String, ByVal SEG_USUARIO As String, ByVal SEG_FECHA As Date) As Integer
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@EMP_CODIGO", EMP_CODIGO))
        db.Parameters.Add(New SqlParameter("@PED_CODIGO", PED_CODIGO))
        db.Parameters.Add(New SqlParameter("@LNP_CODIGO", LNP_CODIGO))
        db.Parameters.Add(New SqlParameter("@LNP_CANT_PED", LNP_CANT_PED))
        db.Parameters.Add(New SqlParameter("@LNP_PRECIO", LNP_PRECIO))
        db.Parameters.Add(New SqlParameter("@ART_CODIGO", ART_CODIGO))
        db.Parameters.Add(New SqlParameter("@UND_CODIGO", UND_CODIGO))
        db.Parameters.Add(New SqlParameter("@SEG_USUARIO", SEG_USUARIO))
        db.Parameters.Add(New SqlParameter("@SEG_FECHA", SEG_FECHA))
        'db.Parameters.Add(New SqlParameter("@SEG_HORA", SEG_HORA))
        'db.Parameters.Add(objParam)
        Dim retval As Integer = db.ExecuteNonQuery("INSERT INTO SorWeb.STK_PEDIDOS_LINEAS(EMP_CODIGO, PED_CODIGO, LNP_CODIGO,LNP_CANT_PED, LNP_PRECIO,ART_CODIGO,UND_CODIGO,SEG_USUARIO,SEG_FECHA, SEG_HORA)VALUES(@EMP_CODIGO,@PED_CODIGO,@LNP_CODIGO,@LNP_CANT_PED,@LNP_PRECIO,@ART_CODIGO,@UND_CODIGO,@SEG_USUARIO,@SEG_FECHA,convert(datetime, convert(varchar, GETDATE(), 108), 108))")
        If retval = 1 Then
            'Return Integer.Parse(objParam.Value.ToString)
            Return 1
        Else
            Return -1
        End If
    End Function

    Public Shared Function cvt() As DataSet
        Dim db As DBAccess = New DBAccess
        Return db.ExecuteDataSet("SELECT * from SorWeb.VTS_V_CONDVTA")
    End Function
    Public Shared Function UltimoLinPed() As Integer
        Dim db As DBAccess = New DBAccess
        Dim c As Integer
        If IsDBNull(db.ExecuteScalar("SELECT MAX(SorWeb.STK_PEDIDOS.PED_CODIGO)from SorWeb.STK_PEDIDOS")) Then

            Return 1
        Else
            c = CType(db.ExecuteScalar("SELECT MAX(SorWeb.STK_PEDIDOS.PED_CODIGO)from SorWeb.STK_PEDIDOS"), Integer)

            Return c
        End If
    End Function
    Public Shared Function UltimoLinCodPed(ByVal PED_CODIGO As Integer) As Integer
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@PED_CODIGO", PED_CODIGO))
        Dim c As Integer
        If IsDBNull(db.ExecuteScalar("SELECT MAX(SorWeb.STK_PEDIDOS_LINEAS.LNP_CODIGO)from SorWeb.STK_PEDIDOS_LINEAS WHERE SorWeb.STK_PEDIDOS_LINEAS.PED_CODIGO=@PED_CODIGO")) Then

            Return 1
        Else
            c = CType(db.ExecuteScalar("SELECT MAX(SorWeb.STK_PEDIDOS_LINEAS.LNP_CODIGO)from SorWeb.STK_PEDIDOS_LINEAS WHERE SorWeb.STK_PEDIDOS_LINEAS.PED_CODIGO=@PED_CODIGO"), Integer)
            c = c + 1
            Return c
        End If
    End Function
    Public Shared Function SelectVisPedidosDetalle(ByVal PED_CODIGO As Integer) As DataSet
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@PED_CODIGO", PED_CODIGO))
        Return db.ExecuteDataSet("Select t1.PED_CODIGO, ROUND(CAST(t2.LNP_CANT_PED As Decimal (6, 0)), 0)As LNP_CANT_PED,t2.LNP_PRECIO,t2.ART_CODIGO,t3.ART_NOMBRE,t2.UND_CODIGO,t3.UND_NOMBRE,t2.LNP_CANT_PED * t2.LNP_PRECIO As TotalLinea ,t1.EST_CODIGO from SorWeb.STK_PEDIDOS  t1 INNER JOIN SorWeb.STK_PEDIDOS_LINEAS  t2 On t1.PED_CODIGO=t2.PED_CODIGO  INNER JOIN SorWeb.STK_V_ARTICULOS  t3 On t2.ART_CODIGO=t3.ART_CODIGO where t1.PED_CODIGO = @PED_CODIGO And t3.LST_CODIGO=2 order by t1.PED_CODIGO,t2.ART_CODIGO")


    End Function

    Public Shared Function SelectVisPedidos(ByVal SEG_USUARIO As Integer) As DataSet
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@SEG_USUARIO", SEG_USUARIO))
        Return db.ExecuteDataSet("Select SorWeb.STK_V_PEDIDOS.* From SorWeb.STK_V_PEDIDOS Where SorWeb.STK_V_PEDIDOS.SEG_USUARIO =@SEG_USUARIO Order By PED_CODIGO DESC ")

    End Function
    Public Shared Function SelectpedFechaMemo(ByVal PED_CODIGO As Integer) As DataSet
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@PED_CODIGO", PED_CODIGO))

        Return db.ExecuteDataSet("SELECT SorWeb.STK_PEDIDOS.CLI_CODIGO,SorWeb.STK_PEDIDOS.PED_CODIGO,SorWeb.STK_PEDIDOS.PED_FECHA,SorWeb.STK_PEDIDOS.PED_MEMO FROM SorWeb.STK_PEDIDOS  WHERE SorWeb.STK_PEDIDOS.PED_CODIGO=@PED_CODIGO")

    End Function
    Public Shared Function Selectpedcliente(ByVal PED_CODIGO As Integer) As DataSet
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@PED_CODIGO", PED_CODIGO))

        Return db.ExecuteDataSet("SELECT SorWeb.STK_PEDIDOS.CLI_CODIGO,SorWeb.STK_PEDIDOS_LINEAS.PED_CODIGO,SorWeb.STK_ARTICULOS.ART_CODIGO,SorWeb.STK_PEDIDOS_LINEAS.LNP_CANT_PED FROM SorWeb.STK_PEDIDOS INNER JOIN SorWeb.STK_PEDIDOS_LINEAS ON SorWeb.STK_PEDIDOS.PED_CODIGO=SorWeb.STK_PEDIDOS_LINEAS.PED_CODIGO INNER JOIN SorWeb.STK_ARTICULOS ON SorWeb.STK_PEDIDOS_LINEAS.ART_CODIGO=SorWeb.STK_ARTICULOS.ART_CODIGO WHERE SorWeb.STK_PEDIDOS_LINEAS.PED_CODIGO=@PED_CODIGO")

    End Function
    Public Shared Function Selectpedidos(ByVal PED_CODIGO As Integer) As DataSet
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@PED_CODIGO", PED_CODIGO))

        Return db.ExecuteDataSet("Select PED_MEMO , CVT_NOMBRE FROM SorWeb.STK_V_PEDIDOS1 WHERE (PED_CODIGO = @PED_CODIGO) ")

    End Function
    Public Shared Function SelectPedidosActivos() As DataSet
        Dim db As DBAccess = New DBAccess
        Return db.ExecuteDataSet("Select  t1.PED_CODIGO,t3.[CLI_NOMBRE],t3.CLI_CODIGO,t1.CVT_NOMBRE,REPLACE(REPLACE(REPLACE(cast(t1.[PED_MEMO] As nvarchar(max)),Char(10),' ') ,CHaR(13),' ') ,'  ',' ')   as memo,t2.[LNP_CODIGO],t2.LNP_CANT_PED,t2.LNP_PRECIO,t2.ART_CODIGO,t4.ART_NOMBRE,t1.SEG_FECHA from [SorWeb].[STK_PEDIDOS] as t1 inner join [SorWeb].[STK_PEDIDOS_LINEAS] as t2 On t1.ped_codigo=t2.PED_CODIGO inner join [SorWeb].[VTS_CLIENTES] as t3 on t1.CLI_CODIGO =t3.cli_codigo inner join [SorWeb].[STK_ARTICULOS] t4 on t2.ART_CODIGO =t4.ART_CODIGO where EST_CODIGO = 1 order by t1.PED_CODIGO, t2.LNP_CODIGO  ")

    End Function
    Public Shared Function SelectPedidosActivosR() As IDataReader
        Dim db As DBAccess = New DBAccess
        Return db.ExecuteReader("Select  t1.PED_CODIGO,t3.[CLI_NOMBRE],t3.CLI_CODIGO,t1.CVT_NOMBRE,REPLACE(REPLACE(REPLACE(cast(t1.[PED_MEMO] As nvarchar(max)),Char(10),' ') ,CHaR(13),' ') ,'  ',' ')   as memo,t2.[LNP_CODIGO],t2.LNP_CANT_PED,t2.LNP_PRECIO,t2.ART_CODIGO,t4.ART_NOMBRE,t1.ped_FECHA from [SorWeb].[STK_PEDIDOS] as t1 inner join [SorWeb].[STK_PEDIDOS_LINEAS] as t2 On t1.ped_codigo=t2.PED_CODIGO inner join [SorWeb].[VTS_CLIENTES] as t3 on t1.CLI_CODIGO =t3.cli_codigo inner join [SorWeb].[STK_ARTICULOS] t4 on t2.ART_CODIGO =t4.ART_CODIGO where EST_CODIGO = 1 order by t1.PED_CODIGO, t2.LNP_CODIGO  ")

    End Function
    Public Shared Function SelectpedidosLinea(PedCodigo As String) As IDataReader
        Dim db As DBAccess = New DBAccess
        db.AddParameter(New SqlParameter("@PedCodigo", PedCodigo))
        Return db.ExecuteReader("SELECT * FROM sorweb.stk_pedidos_lineas WHERE ped_codigo =@PedCodigo ")
    End Function

    Public Shared Function Updatepedidos(ByVal PED_CODIGO As String) As Integer
        Dim db As DBAccess = New DBAccess

        db.Parameters.Add(New SqlParameter("@PED_CODIGO", PED_CODIGO))

        Dim retval As Integer = db.ExecuteNonQuery("update SorWeb.STK_pedidos set EST_CODIGO = 5 WHERE SorWeb.STK_PEDIDOS.PED_CODIGO=@PED_CODIGO")
        If retval = 1 Then
            Return 1
        Else
            Return -1
        End If
    End Function
    Public Shared Function Updatepedidos_numeros(ByVal cod1 As String) As Integer
        Dim db As DBAccess = New DBAccess
        Dim form As New Class1
        db.Parameters.Add(New SqlParameter("@cod1", cod1))

        Dim retval As Integer = db.ExecuteNonQuery("update SorWeb.STK_pedidos set EST_CODIGO = 1 WHERE SorWeb.STK_PEDIDOS.PED_codigo =@cod1")
        If retval = 1 Then
            Return 1
        Else
            Return -1
        End If
    End Function
    Public Shared Function Updatepedidos_Fechas(ByVal f1 As Date, ByVal f2 As Date) As Integer
        Dim db As DBAccess = New DBAccess
        Dim form As New Class1
        db.Parameters.Add(New SqlParameter("@f1", f1))
        db.Parameters.Add(New SqlParameter("@f2", f2))

        Dim retval As Integer = db.ExecuteNonQuery("update SorWeb.STK_pedidos set EST_CODIGO = 1 WHERE SorWeb.STK_PEDIDOS.PED_FECHA >='" & form.FormatearFechaFS(f1) & "' and SorWeb.STK_PEDIDOS.PED_FECHA <= '" & form.FormatearFechaFS(f2) & "'")
        If retval = 1 Then
            Return 1
        Else
            Return -1
        End If
    End Function
End Class

