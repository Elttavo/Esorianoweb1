Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.DataSet
Imports ClassLibrary1
Imports System.Web.Security
Imports System.Data.DataRowView


Partial Class ConsConVent
        Inherits System.Web.UI.Page
        Public nom_cliente As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session.Item("USER") Is Nothing Then
            Response.Redirect("pedidos.aspx")
        End If
        Dim cli As New Cliente
        Dim nom_cliente As String = CType(Session.Item("USER"), String)
        Dim lst_cod As Integer
        Dim DS As DataSet
        cli.LST_CODIGO = Cliente.SelectTipCli(nom_cliente)
        lst_cod = cli.LST_CODIGO

        Panel1.Visible = True

        DS = Cliente.SelectCondVta(nom_cliente, lst_cod)
        BulletedList1.DataSource = DS.Tables(0)
        BulletedList1.DataTextField = "CVT_nombre"
        BulletedList1.DataValueField = "CVT_codigo"
        BulletedList1.DataBind()


    End Sub
End Class
