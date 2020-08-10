Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.DataRowView
Imports Microsoft.VisualBasic
Imports System.DBNull

Public Class Lista
    Public Shared intEMP_CODIGO As Integer
    Private strART_CODIGO As String
    Private intLST_CODIGO As Integer
    Private intLST_PRECIO1 As Double
    Private intLST_PRECIO2 As Double
    Private intLST_PRECIO3 As Double
    Private intLST_PRECIO4 As Double
    Private intLST_PRECIO5 As Double
    Private strLST_FECHA_VIG As String
    Public Shared noborr As Integer = 1
    Public Property EMP_CODIGO() As Integer
        Get
            Return intEMP_CODIGO
        End Get
        Set(ByVal value As Integer)
            intEMP_CODIGO = value
        End Set
    End Property
    Public Property LST_PRECIO1() As Double
        Get
            Return intLST_PRECIO1
        End Get
        Set(ByVal value As Double)
            intLST_PRECIO1 = value
        End Set
    End Property
    Public Property LST_PRECIO2() As Double
        Get
            Return intLST_PRECIO2
        End Get
        Set(ByVal value As Double)
            intLST_PRECIO2 = value
        End Set
    End Property
    Public Property LST_PRECIO3() As Double
        Get
            Return intLST_PRECIO3
        End Get
        Set(ByVal value As Double)
            intLST_PRECIO3 = value
        End Set
    End Property
    Public Property LST_PRECIO4() As Double
        Get
            Return intLST_PRECIO4
        End Get
        Set(ByVal value As Double)
            intLST_PRECIO4 = value
        End Set
    End Property
    Public Property LST_PRECIO5() As Double
        Get
            Return intLST_PRECIO5
        End Get
        Set(ByVal value As Double)
            intLST_PRECIO5 = value
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
    Public Property LST_FECHA_VIG() As String
        Get
            Return strLST_FECHA_VIG
        End Get
        Set(ByVal value As String)
            strLST_FECHA_VIG = value
        End Set
    End Property

    Public Shared Function DeleteLista(ByVal LST_CODIGO As Integer) As Integer
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@LST_CODIGO ", LST_CODIGO))

        Dim retval As Integer = db.ExecuteNonQuery("DELETE FROM SorWeb.STK_LISTA_PRECIOS_ART WHERE LST_CODIGO<>@LST_CODIGO")
        If retval <> 1 Then
            Return -1
            Exit Function
        End If

        Return 1
    End Function

    Public Shared Function InsertLista(ByVal EMP_CODIGO As Integer, ByVal ART_CODIGO As String, ByVal LST_CODIGO As Integer, ByVal LST_PRECIO1 As Double, ByVal LST_PRECIO2 As Double, ByVal LST_PRECIO3 As Double, ByVal LST_PRECIO4 As Double, ByVal LST_PRECIO5 As Double, ByVal LST_FECHA_VIG As Date) As Integer
        Dim db As DBAccess = New DBAccess


        db.Parameters.Add(New SqlParameter("@EMP_CODIGO", EMP_CODIGO))
        db.Parameters.Add(New SqlParameter("@ART_CODIGO", ART_CODIGO))
        db.Parameters.Add(New SqlParameter("@LST_CODIGO", LST_CODIGO))
        db.Parameters.Add(New SqlParameter("@LST_PRECIO1", LST_PRECIO1))
        db.Parameters.Add(New SqlParameter("@LST_PRECIO2", LST_PRECIO2))
        db.Parameters.Add(New SqlParameter("@LST_PRECIO3", LST_PRECIO3))
        db.Parameters.Add(New SqlParameter("@LST_PRECIO4", LST_PRECIO4))
        db.Parameters.Add(New SqlParameter("@LST_PRECIO5", LST_PRECIO5))
        db.Parameters.Add(New SqlParameter("@LST_FECHA_VIG", LST_FECHA_VIG))

        Dim retval As Integer = db.ExecuteNonQuery("INSERT INTO SorWeb.STK_LISTA_PRECIOS_ART(EMP_CODIGO ,ART_CODIGO ,LST_CODIGO,LST_PRECIO1,LST_PRECIO2,LST_PRECIO3,LST_PRECIO4,LST_PRECIO5,LST_FECHA_VIG)VALUES(@EMP_CODIGO ,@ART_CODIGO ,@LST_CODIGO,@LST_PRECIO1,@LST_PRECIO2,@LST_PRECIO3,@LST_PRECIO4,@LST_PRECIO5,@LST_FECHA_VIG)")
        If retval = 1 Then
            Return 1
        Else
            Return -1
        End If
    End Function



End Class
