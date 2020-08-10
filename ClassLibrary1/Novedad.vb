Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.DataRowView
Imports System.DBNull

Public Class Novedad

    Public Shared intEMP_CODIGO As Integer
    Public Shared intNOV_ID As String
    Public Shared strNOV_TITULO As String
    Public Shared strNOV_CUERPO As String
    Public Shared strNOV_COPETE As String
    Public Shared strNOV_FECHA As Date
    Public Shared strNOV_IMAGEN As String
    Public Shared strNOV_VIDEO As String

    Public Property EMP_CODIGO() As Integer
        Get
            Return intEMP_CODIGO
        End Get
        Set(ByVal value As Integer)
            intEMP_CODIGO = value
        End Set
    End Property
    Public Property NOV_ID() As String
        Get
            Return intNOV_ID
        End Get
        Set(ByVal value As String)
            intNOV_ID = value
        End Set
    End Property
    Public Property NOV_VIDEO() As String
        Get
            Return strNOV_VIDEO
        End Get
        Set(ByVal value As String)
            strNOV_VIDEO = value
        End Set
    End Property

    Public Property NOV_TITULO() As String
        Get
            Return strNOV_TITULO
        End Get
        Set(ByVal value As String)
            strNOV_TITULO = value
        End Set
    End Property
    Public Property NOV_CUERPO() As String
        Get
            Return strNOV_CUERPO
        End Get
        Set(ByVal value As String)
            strNOV_CUERPO = value
        End Set
    End Property
    Public Property NOV_COPETE() As String
        Get
            Return strNOV_COPETE
        End Get
        Set(ByVal value As String)
            strNOV_COPETE = value
        End Set
    End Property
    Public Property NOV_FECHA() As Date
        Get
            Return strNOV_FECHA
        End Get
        Set(ByVal value As Date)
            strNOV_FECHA = value
        End Set
    End Property
    Public Property NOV_IMAGEN() As String
        Get
            Return strNOV_IMAGEN
        End Get
        Set(ByVal value As String)
            strNOV_IMAGEN = value
        End Set
    End Property

    Public Shared Function Selectnovedades_4linea(ByVal NOV_ID As String) As DataSet
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@NOV_ID", NOV_ID))

        Return db.ExecuteDataSet("SELECT  TOP 4 NOV_ID,NOV_FECHA, NOV_TITULO, NOV_CUERPO, NOV_IMAGEN,NOV_VIDEO,NOV_DETALLE FROM SorWeb.WEB_NOVEDADES WHERE NOV_ID=@NOV_ID ")

    End Function
    Public Shared Function Deletenovedades_linea(ByVal NOV_ID As String) As Integer
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@NOV_ID", NOV_ID))

        Dim retval As Integer = db.ExecuteNonQuery("DELETE FROM SorWeb.WEB_NOVEDADES WHERE NOV_ID=@NOV_ID")
        If retval <> 1 Then
            Return -1
            Exit Function
        End If

        Return 1
    End Function

    Public Shared Function Insertnovedades(ByVal EMP_CODIGO As String, ByVal NOV_TITULO As String, ByVal NOV_CUERPO As String, ByVal NOV_COPETE As String, ByVal NOV_FECHA As Date, ByVal NOV_IMAGEN As String, ByVal NOV_VIDEO As String, ByVal NOV_DETALLE As String) As Integer
        Dim db As DBAccess = New DBAccess

        db.Parameters.Add(New SqlParameter("@EMP_CODIGO", EMP_CODIGO))
        db.Parameters.Add(New SqlParameter("@NOV_TITULO", NOV_TITULO))
        db.Parameters.Add(New SqlParameter("@NOV_CUERPO", NOV_CUERPO))
        db.Parameters.Add(New SqlParameter("@NOV_COPETE", NOV_COPETE))
        db.Parameters.Add(New SqlParameter("@NOV_FECHA", NOV_FECHA))
        db.Parameters.Add(New SqlParameter("@NOV_IMAGEN", NOV_IMAGEN))
        db.Parameters.Add(New SqlParameter("@NOV_VIDEO", NOV_VIDEO))
        db.Parameters.Add(New SqlParameter("@NOV_DETALLE", NOV_DETALLE))

        Dim retval As Integer = db.ExecuteNonQuery("INSERT INTO SorWeb.WEB_NOVEDADES(EMP_CODIGO ,NOV_TITULO ,NOV_CUERPO ,NOV_COPETE ,NOV_FECHA ,NOV_IMAGEN,NOV_VIDEO,NOV_DETALLE)VALUES(@EMP_CODIGO ,@NOV_TITULO ,@NOV_CUERPO,@NOV_COPETE ,@NOV_FECHA ,@NOV_IMAGEN,@NOV_VIDEO,@NOV_DETALLE)")

        If retval = 1 Then
            Return 1
        Else
            Return -1
        End If

    End Function
    Public Shared Function Updatearticulos(ByVal NOV_ID As String, ByVal NOV_CUERPO As String, ByVal NOV_COPETE As String, ByVal NOV_TITULO As String, ByVal NOV_fecha As Date, ByVal NOV_imagen As String, ByVal NOV_VIDEO As String, ByVal NOV_DETALLE As String) As Integer
        Dim db As DBAccess = New DBAccess

        db.Parameters.Add(New SqlParameter("@NOV_ID", NOV_ID))
        db.Parameters.Add(New SqlParameter("@NOV_CUERPO", NOV_CUERPO))
        db.Parameters.Add(New SqlParameter("@NOV_COPETE", NOV_COPETE))
        db.Parameters.Add(New SqlParameter("@NOV_TITULO", NOV_TITULO))
        db.Parameters.Add(New SqlParameter("@NOV_fecha", NOV_fecha))
        db.Parameters.Add(New SqlParameter("@NOV_imagen", NOV_imagen))
        db.Parameters.Add(New SqlParameter("@NOV_VIDEO", NOV_VIDEO))
        db.Parameters.Add(New SqlParameter("@NOV_DETALLE", NOV_DETALLE))

        Dim retval As Integer = db.ExecuteNonQuery("update SorWeb.WEB_NOVEDADES set NOV_CUERPO = @NOV_CUERPO,NOV_COPETE = @NOV_COPETE ,NOV_TITULO= @NOV_TITULO,NOV_fecha= @NOV_FECHA,NOV_imagen =@NOV_IMAGEN,NOV_VIDEO=@NOV_VIDEO,NOV_DETALLE=@NOV_DETALLE WHERE SorWeb.WEB_NOVEDADES.NOV_ID=@NOV_ID")
        If retval = 1 Then
            Return 1
        Else
            Return -1
        End If
    End Function
    Public Shared Function SelectNovedades() As DataSet
        Dim db As DBAccess = New DBAccess
        Return db.ExecuteDataSet("SELECT TOP (1) NOV_ID, NOV_FECHA, NOV_TITULO, NOV_CUERPO, NOV_IMAGEN,NOV_VIDEO,NOV_DETALLE FROM SorWeb.WEB_NOVEDADES ORDER BY NOV_FECHA DESC ")
    End Function

    Public Shared Function Selectnovedades_2L() As DataSet
        Dim db As DBAccess = New DBAccess

        Return db.ExecuteDataSet("SELECT  TOP 2 * FROM SorWeb.WEB_NOVEDADES ORDER BY NOV_FECHA DESC ")

    End Function
    Public Shared Function Selectnovedades_todas() As DataSet
        Dim db As DBAccess = New DBAccess

        Return db.ExecuteDataSet("Select  NOV_FECHA,NOV_TITULO,NOV_COPETE,nov_id FROM SorWeb.WEB_NOVEDADES order by nov_id desc ")

    End Function


End Class




