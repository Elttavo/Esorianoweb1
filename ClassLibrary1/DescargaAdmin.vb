Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.DataRowView
Imports Microsoft.VisualBasic
Imports System.DBNull
Public Class DescargaAdmin

    Public Shared Function exportarP(fecha As String, fecha1 As String) As IDataReader

        Dim db As DBAccess = New DBAccess
        db.AddParameter("@fecha", fecha)
        db.AddParameter("@fecha1", fecha1)

        Return db.ExecuteReader("Select SorWeb.STK_PEDIDOS.PED_MEMO, SorWeb.STK_PEDIDOS.ped_fecha, SorWeb.STK_PEDIDOS.cli_codigo, SorWeb.STK_PEDIDOS.PED_CODIGO, SorWeb.STK_PEDIDOS.CVT_NOMBRE from SorWeb.STK_PEDIDOS WHERE SorWeb.STK_PEDIDOS.est_CODIGO<> 5 And SorWeb.STK_PEDIDOS.PED_FECHA >=@fecha and SorWeb.STK_PEDIDOS.PED_FECHA <=@fecha1 order by SorWeb.STK_PEDIDOS.PED_CODIGO ")

    End Function
    Public Shared Function exportarPA() As IDataReader
        Dim db As DBAccess = New DBAccess

        Return db.ExecuteReader("SELECT SorWeb.STK_PEDIDOS.PED_MEMO,SorWeb.STK_PEDIDOS.ped_fecha,SorWeb.STK_PEDIDOS.cli_codigo ,SorWeb.STK_PEDIDOS.PED_CODIGO,SorWeb.STK_PEDIDOS.CVT_NOMBRE from SorWeb.STK_PEDIDOS WHERE SorWeb.STK_PEDIDOS.est_CODIGO<> 5 ")

    End Function
    Public Shared Function exportarPAF(fecha As String, fecha1 As String) As IDataReader
        Dim db As DBAccess = New DBAccess
        db.AddParameter("@fecha", fecha)
        db.AddParameter("@fecha1", fecha1)

        Return db.ExecuteReader("SELECT SorWeb.STK_PEDIDOS.PED_MEMO,SorWeb.STK_PEDIDOS.ped_fecha,SorWeb.STK_PEDIDOS.cli_codigo ,SorWeb.STK_PEDIDOS.PED_CODIGO,SorWeb.STK_PEDIDOS.CVT_NOMBRE from SorWeb.STK_PEDIDOS WHERE  SorWeb.STK_PEDIDOS.PED_FECHA >=@fecha and SorWeb.STK_PEDIDOS.PED_FECHA <=@fecha1 order by SorWeb.STK_PEDIDOS.PED_CODIGO ")
    End Function
End Class
