Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.DataRowView
Imports Microsoft.VisualBasic
Imports System.DBNull


Public Class Cart
    Public Shared intEMP_CODIGO As Integer
    Public Shared intCAR_CODIGO As Integer

    Private fecCAR_EXPIRA As Date
    Private fecCAR_FECHA As Date
    Private intCLI_CODIGO As Integer
    Private intEST_CODIGO As Integer
    Private strSEG_USUARIO As String
    Private fecseg_fecha As Date
    Private intLIC_CODIGO As Integer
    Private intLIC_CANTIDAD As Decimal
    Private intLNP_PRECIO As Double
    Private strART_CODIGO As String
    Private strUND_CODIGO As String
    Private strEST_NOMBRE As String
    Public Shared noborr As Integer = 1

    Public Property EMP_CODIGO() As Integer
        Get
            Return intEMP_CODIGO
        End Get
        Set(ByVal value As Integer)
            intEMP_CODIGO = value
        End Set
    End Property
    Public Property CAR_CODIGO() As Integer
        Get
            Return intCAR_CODIGO
        End Get
        Set(ByVal value As Integer)
            intCAR_CODIGO = value
        End Set
    End Property
    Public Property CAR_EXPIRA() As Date
        Get
            Return fecCAR_EXPIRA
        End Get
        Set(ByVal value As Date)
            fecCAR_EXPIRA = value
        End Set
    End Property
    Public Property CAR_FECHA() As Date
        Get
            Return fecCAR_FECHA
        End Get
        Set(ByVal value As Date)
            fecCAR_FECHA = value
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
    Public Property EST_CODIGO() As Integer
        Get
            Return intEST_CODIGO
        End Get
        Set(ByVal value As Integer)
            intEST_CODIGO = value
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
            Return fecseg_fecha
        End Get
        Set(ByVal value As DateTime)
            fecseg_fecha = value
        End Set
    End Property
    Public Property LIC_CODIGO() As Integer
        Get
            Return intLIC_CODIGO
        End Get
        Set(ByVal value As Integer)
            intLIC_CODIGO = value
        End Set
    End Property
    Public Property LIC_CANTIDAD() As Decimal
        Get
            Return intLIC_CANTIDAD
        End Get
        Set(ByVal value As Decimal)
            intLIC_CANTIDAD = value
        End Set
    End Property
    Public Property LNP_PRECIO() As Double
        Get
            Return intLNP_PRECIO
        End Get
        Set(ByVal value As Double)
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
    Public Shared Function CantidadLineas(ByVal CAR_CODIGO As String) As String
        Dim db As DBAccess = New DBAccess
        Dim c As String
        db.Parameters.Add(New SqlParameter("@CAR_CODIGO", CAR_CODIGO))
        If IsDBNull(db.ExecuteScalar("select count(*) from [SorWeb].[STK_CARRITO_LINEAS] where CAR_CODIGO= @CAR_CODIGO ")) Then

            Return 0
        Else
            c = CType(db.ExecuteScalar("select count(*) from [SorWeb].[STK_CARRITO_LINEAS] where CAR_CODIGO= @CAR_CODIGO "), String)

            Return c
        End If
    End Function

    Public Shared Function selectCarritoCli(ByVal CLI_CODIGO As Int32) As DataSet
        Dim db As DBAccess = New DBAccess

        db.Parameters.Add(New SqlParameter("@CLI_CODIGO", CLI_CODIGO))

        Return db.ExecuteDataSet("Select distinct t1.CAR_CODIGO, t1.CAR_FECHA, t1.CAR_expira, t1.CLI_CODIGO, t1.est_CODIGO, t1.EST_NOMBRE FROM SorWeb.STK_V_CARRITO t1 inner join [SorWeb].[STK_CARRITO_LINEAS] t2 on t1.CAR_CODIGO=t2.CAR_CODIGO WHERE (CLI_CODIGO = @CLI_CODIGO) And (EST_CODIGO=2 Or EST_CODIGO=1)  And (DATEDIFF(DAY, CAR_FECHA, GETDATE()) <= 15)   and est_CODIGO<>0 ORDER BY CAR_CODIGO DESC ")

    End Function
    Public Shared Function selectCarrito(ByVal CAR_CODIGO As Int32) As DataSet
        Dim db As DBAccess = New DBAccess

        db.Parameters.Add(New SqlParameter("@CAR_CODIGO", CAR_CODIGO))

        Return db.ExecuteDataSet("SELECT CL.ART_CODIGO, CL.ART_NOMBRE, CL.ART_UND_CONSUMO, ROUND(CAST (CL.LIC_CANTIDAD AS decimal (6,0)),0)as LIC_CANTIDAD, CL.LST_PRECIO1, CL.TotalLinea, CL.CAR_CODIGO  FROM SorWeb.STK_V_CARRITO C INNER JOIN SorWeb.STK_V_CARRITO_LINEAS CL ON C.CAR_CODIGO = CL.CAR_CODIGO AND (C.est_CODIGO = 2 OR C.EST_CODIGO=1) WHERE (CL.CAR_CODIGO = @CAR_CODIGO) GROUP BY CL.ART_CODIGO, CL.ART_NOMBRE, CL.ART_UND_CONSUMO, CL.LIC_CANTIDAD, CL.LST_PRECIO1, CL.TotalLinea, CL.CAR_CODIGO")

    End Function

    Public Shared Function PasarBorradorPedido(ByVal Car_CodigoBcargado As String, ByVal Car_CodigoActual As String) As Integer
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@Car_CodigoBcargado", Car_CodigoBcargado))
        db.Parameters.Add(New SqlParameter("@Car_CodigoActual", Car_CodigoActual))

        Dim retval As Integer = db.ExecuteNonQuery("INSERT INTO [SorWeb].[STK_CARRITO_LINEAS] (CAR_CODIGO , ART_CODIGO, LIC_CANTIDAD) SELECT @Car_CodigoActual, [ART_CODIGO], [LIC_CANTIDAD] FROM [SorWeb].[STK_CARRITO_LINEAS] t2 WHERE t2.CAR_CODIGO=@Car_CodigoBcargado")
        If retval = 1 Then
            Return 1
        Else
            Return -1
        End If
    End Function
    Public Shared Function InsertCarrito(ByVal CAR_EXPIRA As Date, ByVal CAR_FECHA As Date, ByVal CLI_CODIGO As Integer, ByVal EST_CODIGO As Integer, ByVal SEG_USUARIO As String) As Integer
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@CAR_EXPIRA", CAR_EXPIRA))
        db.Parameters.Add(New SqlParameter("@CAR_FECHA", CAR_FECHA))
        db.Parameters.Add(New SqlParameter("@CLI_CODIGO", CLI_CODIGO))
        db.Parameters.Add(New SqlParameter("@EST_CODIGO", EST_CODIGO))
        db.Parameters.Add(New SqlParameter("@SEG_USUARIO", SEG_USUARIO))
        Dim retval As Integer = db.ExecuteNonQuery("INSERT INTO SorWeb.STK_CARRITO(CAR_EXPIRA,CAR_FECHA,CLI_CODIGO,EST_CODIGO,SEG_USUARIO)VALUES(@CAR_EXPIRA,@CAR_FECHA,@CLI_CODIGO,@EST_CODIGO,@SEG_USUARIO)")
        If retval = 1 Then
            Return 1
        Else
            Return -1
        End If
    End Function
    Public Shared Function InsertCarritoLinea(ByVal CAR_CODIGO As Integer, ByVal ART_CODIGO As String, ByVal LIC_CANTIDAD As Decimal) As Integer
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@CAR_CODIGO", CAR_CODIGO))
        db.Parameters.Add(New SqlParameter("@ART_CODIGO", ART_CODIGO))
        db.Parameters.Add(New SqlParameter("@LIC_CANTIDAD", LIC_CANTIDAD))

        Dim retval As Integer = db.ExecuteNonQuery("INSERT INTO SorWeb.STK_CARRITO_LINEAS(CAR_CODIGO,ART_CODIGO,LIC_CANTIDAD)VALUES(@CAR_CODIGO,@ART_CODIGO,@LIC_CANTIDAD)")
        If retval <> 1 Then
            Return -1
            Exit Function
        End If

        Return 1
    End Function
    Public Shared Function UltimoItemxCart(ByVal CLI_CODIGO As Integer) As Integer
        Dim db As DBAccess = New DBAccess
        Dim c As Integer
        db.Parameters.Add(New SqlParameter("@CLI_CODIGO", CLI_CODIGO))
        If IsDBNull(db.ExecuteScalar("SELECT MAX(SorWeb.STK_CARRITO.CAR_CODIGO)from SorWeb.STK_CARRITO WHERE (cli_codigo = @CLI_CODIGO)")) Then

            Return 1
        Else
            c = CType(db.ExecuteScalar("SELECT MAX(SorWeb.STK_CARRITO.CAR_CODIGO)from SorWeb.STK_CARRITO WHERE (cli_codigo = @CLI_CODIGO)"), Integer)

            Return c
        End If
    End Function
    Public Shared Function UpdateCarritoLinea(ByVal CAR_CODIGO As Integer, ByVal ART_CODIGO As String, ByVal LIC_CANTIDAD As Decimal) As Integer
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@CAR_CODIGO", CAR_CODIGO))
        db.Parameters.Add(New SqlParameter("@ART_CODIGO", ART_CODIGO))
        db.Parameters.Add(New SqlParameter("@LIC_CANTIDAD", LIC_CANTIDAD))

        Dim retval As Integer = db.ExecuteNonQuery("UPDATE SorWeb.STK_CARRITO_LINEAS SET LIC_CANTIDAD=@LIC_CANTIDAD WHERE CAR_CODIGO=@CAR_CODIGO AND ART_CODIGO=@ART_CODIGO")
        If retval <> 1 Then
            Return -1
            Exit Function
        End If
        Return 1
    End Function
    Public Shared Function UpdateCarrito(ByVal CAR_CODIGO As Integer, ByVal EST_CODIGO As Integer) As Integer
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@CAR_CODIGO", CAR_CODIGO))
        db.Parameters.Add(New SqlParameter("@EST_CODIGO", EST_CODIGO))

        Dim retval As Integer = db.ExecuteNonQuery("UPDATE SorWeb.STK_CARRITO SET EST_CODIGO=@EST_CODIGO WHERE CAR_CODIGO=@CAR_CODIGO")
        If retval <> 1 Then
            Return -1
            Exit Function
        End If

        Return 1

    End Function
    Public Shared Function DeleteCarrito(ByVal CAR_CODIGO As Integer) As Integer
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@CAR_CODIGO", CAR_CODIGO))

        Dim retval As Integer = db.ExecuteNonQuery("DELETE FROM SorWeb.STK_CARRITO WHERE CAR_CODIGO=@CAR_CODIGO")
        If retval <> 1 Then
            Return -1
            Exit Function
        End If

        Return 1
    End Function
    Public Shared Function DeleteLineaCarrito(ByVal CAR_CODIGO As Integer) As Integer
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@CAR_CODIGO", CAR_CODIGO))

        Dim retval As Integer = db.ExecuteNonQuery("DELETE FROM SorWeb.STK_CARRITO_LINEAS WHERE CAR_CODIGO=@CAR_CODIGO")
        If retval < 1 Then
            Return -1
            Exit Function
        End If

        Return 1
    End Function
End Class

