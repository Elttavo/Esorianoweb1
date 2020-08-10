Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class Factura

    Public Shared intCLI_CODIGO As Integer
    Public Shared intEMP_CODIGO As Integer
    Public Shared strCLI_NOMBRE As String
    Public Shared strFAC_LETRA As String
    Public Shared fecFAC_FECHA As Date
    Public Shared intFAC_NUMERO As Integer
    Public Shared intFAC_IMP_neto As Decimal
    Public Shared intFAC_SUC As Integer
    Public Shared intCOM_CODIGO As Integer

    Public Property EMP_CODIGO() As Integer
        Get
            Return intEMP_CODIGO
        End Get
        Set(ByVal value As Integer)
            intEMP_CODIGO = value
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
    Public Property CLI_CODIGO() As Integer
        Get
            Return intCLI_CODIGO
        End Get
        Set(ByVal value As Integer)
            intCLI_CODIGO = value
        End Set
    End Property
    Public Property FAC_LETRA() As String
        Get
            Return strFAC_LETRA
        End Get
        Set(ByVal value As String)
            strFAC_LETRA = value
        End Set
    End Property

    Public Property FAC_FECHA() As Date
        Get
            Return fecFAC_FECHA
        End Get
        Set(ByVal value As Date)
            fecFAC_FECHA = value
        End Set
    End Property
    Public Property FAC_NUMERO() As Integer
        Get
            Return intFAC_NUMERO
        End Get
        Set(ByVal value As Integer)
            intFAC_NUMERO = value
        End Set
    End Property
    Public Property FAC_IMP_neto() As Decimal
        Get
            Return intFAC_IMP_neto
        End Get
        Set(ByVal value As Decimal)
            intFAC_IMP_neto = value
        End Set
    End Property
    Public Property FAC_SUC() As Integer
        Get
            Return intFAC_SUC
        End Get
        Set(ByVal value As Integer)
            intFAC_SUC = value
        End Set
    End Property

    Public Property COM_CODIGO() As Integer
        Get
            Return intCOM_CODIGO
        End Get
        Set(ByVal value As Integer)
            intCOM_CODIGO = value
        End Set
    End Property


    Public Shared Function SelectFactura(ByVal CLI_CODIGO As Integer) As DataSet
        Dim db As DBAccess = New DBAccess
        db.AddParameter("@CLI_CODIGO", CLI_CODIGO)

        Return db.ExecuteDataSet("SELECT FAC_NUMERO, FAC_FECHA, FAC_IMP_neto, CLI_NOMBRE, FAC_LETRA, FAC_SUC, COM_CODIGO FROM SorWeb.STK_V_FACTURA WHERE (CLI_CODIGO = @CLI_CODIGO )and fac_letra <> 'X' ORDER BY FAC_FECHA DESC")

    End Function

    Public Shared Function InsertFactura(ByVal EMP_CODIGO As Integer, ByVal FAC_NUMERO As Integer, ByVal FAC_LETRA As String, ByVal CLI_CODIGO As Integer, ByVal FAC_FECHA As Date, ByVal COM_CODIGO As Integer, ByVal FAC_SUC As Integer, ByVal FAC_IMP_neto As Decimal) As Integer
        Dim db As DBAccess = New DBAccess


        db.Parameters.Add(New SqlParameter("@EMP_CODIGO", EMP_CODIGO))
        db.Parameters.Add(New SqlParameter("@FAC_NUMERO", FAC_NUMERO))
        db.Parameters.Add(New SqlParameter("@FAC_LETRA", FAC_LETRA))
        db.Parameters.Add(New SqlParameter("@CLI_CODIGO", CLI_CODIGO))
        db.Parameters.Add(New SqlParameter("@FAC_FECHA", FAC_FECHA))
        db.Parameters.Add(New SqlParameter("@COM_CODIGO", COM_CODIGO))
        db.Parameters.Add(New SqlParameter("@FAC_SUC", FAC_SUC))
        db.Parameters.Add(New SqlParameter("@FAC_IMP_neto", FAC_IMP_neto))


        Dim retval As Integer = db.ExecuteNonQuery("INSERT INTO SorWeb.STK_Factura (EMP_CODIGO ,FAC_NUMERO ,FAC_LETRA, CLI_CODIGO ,FAC_FECHA,COM_CODIGO,fac_suc,FAC_IMP_neto)VALUES(@EMP_CODIGO ,@FAC_NUMERO ,@FAC_LETRA, @CLI_CODIGO ,@FAC_FECHA ,@COM_CODIGO ,@fac_suc ,@FAC_IMP_neto) ")
        If retval = 1 Then
            Return 1
        Else
            Return -1
        End If
    End Function
    Public Shared Function DeleteFactura(ByVal FAC_NUMERO As Integer) As Integer
        Dim db As DBAccess = New DBAccess

        db.Parameters.Add(New SqlParameter("@FAC_NUMERO", FAC_NUMERO))



        Dim retval As Integer = db.ExecuteNonQuery("delete from SorWeb.STK_Factura where FAC_NUMERO <> @FAC_NUMERO ")
        If retval = 1 Then
            Return 1
        Else
            Return -1
        End If
    End Function

End Class

