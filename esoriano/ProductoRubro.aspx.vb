Imports System.Data.SqlClient
Imports System.Collections
Imports System.Configuration
Imports System.Web.Security
Imports ClassLibrary1

Public Class productos_por_rubro

    Inherits System.Web.UI.Page
    Public sProductID As String
    Public b As Integer = 1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session.Item("USER") Is Nothing Then
            Response.Redirect("pedidos.aspx")
        End If
        If Not Session.Item("USER") Is Nothing Then
            Session(sProductID) = True
            'Panel1.Visible = True
            Dim cli As New Cliente
            Dim nom_cliente As String = CType(Session.Item("USER"), String)
            Dim lst_cod As Integer
            Dim banner As String
            cli.LST_CODIGO = Cliente.SelectTipCli(nom_cliente)
            lst_cod = cli.LST_CODIGO
            If lst_cod = 1 Then
                'Label1.Visible = True
                banner = Cliente.SelectBanner(nom_cliente, lst_cod)
                'Label1.Text = banner
                'Label2.Visible = False
            Else
                'Label1.Visible = False
                'Label2.Visible = True
                banner = Cliente.SelectBanner(nom_cliente, lst_cod)
                'Label2.Text = banner

            End If
            If Not IsPostBack Then
                DataListA.DataSource = Rubros.GetRubrosxAbc
                DataListA.DataBind()
                DataListB.DataSource = Rubros.GetRubrosxB
                DataListB.DataBind()
                DataListC.DataSource = Rubros.GetRubrosxC
                DataListC.DataBind()
                DataListD.DataSource = Rubros.GetRubrosxD
                DataListD.DataBind()
                DataListL.DataSource = Rubros.GetRubrosxL
                DataListL.DataBind()
                DataListM.DataSource = Rubros.GetRubrosxM
                DataListM.DataBind()
                DataListP.DataSource = Rubros.GetRubrosxP
                DataListP.DataBind()
                DataListS.DataSource = Rubros.GetRubrosxS
                DataListS.DataBind()
                DataListT.DataSource = Rubros.GetRubrosxT
                DataListT.DataBind()





            End If
        End If
    End Sub



End Class