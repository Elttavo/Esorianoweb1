
Imports System.Data
Imports System.Data.SqlClient
Imports ClassLibrary1
Imports System
Imports System.Data.DataRow
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Web.Security

Partial Class WebUserControlCabecera
    Inherits System.Web.UI.UserControl
    Public sProductID As String
    Private SelectedProduct As ArticulosCart
    Public Rubro As String
    Public Subrubro As String
    Public CartItem As CartItem
    Dim intI As Integer
    Dim dTotal As Decimal = 0
    Public tabla_datos As New DataTable()
    Public s As String
    Public nom_cliente As String
    Public codart As String
    Dim cant As Integer
    Public canti As Integer
    Public canti1 As Integer
    Public comand As String
    Public prodid As String
    Public prodid1 As String
    Public cont As Integer
    Dim b As Integer
    Public Property nomCliente() As String
        Get
            Return ClienteL.Text
        End Get
        Set(ByVal value As String)
            ClienteL.Text = value
        End Set
    End Property



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session.Item("USER") Is Nothing Then
            'PanelCarritoUser.Visible = false
            'PanelCarritoBot.Visible = False
            LinkButtonPedido.Visible = False
            LinkButtonDesc.Visible = False
            Total.Visible = False
            Items.Visible = False
            Img1.Visible = False
            Img2.Visible = False
            Image3.Visible = False
            Image1.Visible = False
            Image2.Visible = False
            Label1.Visible = False
            Label2.Visible = False
            Labelpesos.Visible = False


        Else
            'PanelCarritoUser.Visible = True
            'PanelCarritoBot.Visible = True
            LinkButtonPedido.Visible = True
            LinkButtonDesc.Visible = True
            Total.Visible = True
            Items.Visible = True
            Img1.Visible = True
            Img2.Visible = True
            Image3.Visible = True
            Image1.Visible = True
            Image2.Visible = True
            Label1.Visible = True
            Label2.Visible = True
            Labelpesos.Visible = True
            Dim nom_cliente As String = CType(Session.Item("USER"), String)
            Dim cli As New Cliente
            cli.CLI_NOMBRE = Cliente.SelectNomCli(nom_cliente)
            nom_cliente = cli.CLI_NOMBRE
            ClienteL.Text = nom_cliente
        End If

        If Session.Item("TotalLineas") Is Nothing Then
        Else
            Dim num_lineas As String = CType(Session.Item("TotalLineas"), String)
            Items.Text = num_lineas
        End If
        If Session.Item("TotalGastos") Is Nothing Then
        Else
            Dim num_gastos As String = CType(Session.Item("TotalGastos"), String)
            Total.Text = num_gastos
        End If
        'DisableEnterKeyPress(Me)
    End Sub

    'Protected Sub LinkButtonDesc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButtonDesc.Click

    '    HttpContext.Current.Session.Abandon()
    '    FormsAuthentication.SignOut()
    '    Response.Redirect("default.aspx")
    'End Sub


    'Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    PanelCarritoUser.Visible = True
    'End Sub

    'Protected Sub ImageButtonPedido1_Click1(sender As Object, e As ImageClickEventArgs) Handles ImageButtonPedido1.Click
    '    Response.Redirect("ver-pedido.aspx")
    'End Sub
    'Private Sub DisableEnterKeyPress(ByVal control As Control)
    '    For Each ctl In control.Controls
    '        If ctl.HasControls Then
    '            DisableEnterKeyPress(ctl)
    '        ElseIf TypeOf ctl Is Button Then
    '            ctl.UseSubmitBehavior = False
    '        End If
    '    Next
    'End Sub

    Protected Sub LinkButtonPedido_Click(sender As Object, e As EventArgs) Handles LinkButtonPedido.Click
        Response.Redirect("VerPedido.aspx")
    End Sub

    Protected Sub LinkButtonDesc_Click(sender As Object, e As EventArgs) Handles LinkButtonDesc.Click
        HttpContext.Current.Session.Abandon()
        FormsAuthentication.SignOut()
        Response.Redirect("default.aspx")
    End Sub
End Class
