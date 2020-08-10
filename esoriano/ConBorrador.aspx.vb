Imports System.Data.SqlClient
Imports System.Collections
Imports System.Configuration
Imports ClassLibrary1

Partial Class ConBorrador
        Inherits System.Web.UI.Page
        Dim dTotal As Decimal = 0
        Dim codped As Integer
        Public tot As Decimal
        Dim cant As Decimal
    Public sProductID As String
    Public CLI_CODIGO As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session.Item("USER") Is Nothing Then
            Response.Redirect("pedidos.aspx")
        End If
        CLI_CODIGO = CType(Session.Item("USER"), String)
        GridView1.Visible = True
        LinkButtonVolverAtras.Visible = True
        Label1.Visible = True
        Label2.Visible = False
        Label3.Visible = False
        GridView1.DataSource = Cart.selectCarritoCli(CLI_CODIGO)
        GridView1.DataBind()

    End Sub
        Public Shared Function KeepActiveSession() As Boolean
            If HttpContext.Current.Session.IsNewSession Then
                Return False
            Else
                Return True
            End If
        End Function
        Public Shared Sub SessionAbandon()
            HttpContext.Current.Session.Abandon()
        End Sub

        Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
            If e.Row.RowType = DataControlRowType.Footer Then
                e.Row.Cells(4).Text = "CANTIDAD:" + GridView1.Rows.Count.ToString() + "&nbsp;&nbsp;"
                'e.Row.Cells(4).HorizontalAlign = HorizontalAlign.Right
                'e.Row.Font.Bold = True
                e.Row.CssClass = "FooterGridView"
            End If
        End Sub

        Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
            Label1.Visible = False
            Label2.Visible = True
            Label3.Visible = True
            ButtonActivarPed.Visible = True
            ButtonEliminarPed.Visible = True
            imgPrint.Visible = True

        Dim row As GridViewRow = GridView1.SelectedRow
            codped = row.Cells(0).Text
            Label3.Text = codped
            GridView1.Visible = False
            GridView2.Visible = True
            LinkButtonVolverAtras.Visible = False
            LinkButtonVolverBorradores.Visible = True


        End Sub

        Protected Sub LinkButtonVolverBorradores_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButtonVolverBorradores.Click
            LinkButtonVolverAtras.Visible = True
            LinkButtonVolverBorradores.Visible = False
            ButtonActivarPed.Visible = False
            imgPrint.Visible = False
            ButtonEliminarPed.Visible = False
            GridView1.Visible = True
            GridView2.Visible = False
        End Sub
        Protected Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowDataBound
            If e.Row.RowType = DataControlRowType.DataRow Then

                If (DataBinder.Eval(e.Row.DataItem, "TotalLinea")).ToString <> "" Then
                    dTotal += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TotalLinea"))
                End If
            End If

            If e.Row.RowType = DataControlRowType.Footer Then
                e.Row.Cells(4).Text = "Total:"
                e.Row.Cells(5).Text = dTotal.ToString("c")
            e.Row.CssClass = "FooterGridView"
        End If

        End Sub

        Protected Sub ButtonActivarPed_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonActivarPed.Click
        Dim totallineas As Label = DirectCast(Me.Cabecera.FindControl("Items"), Label)
        Dim totalgastos As Label = DirectCast(Me.Cabecera.FindControl("Total"), Label)
        Dim items As Integer
        Dim carCod As String
        Dim CLI_CODIGO As String = CType(Session.Item("USER"), String)
        carCod = Label3.Text
        items = GridView2.Rows.Count

        If items = 0 Then
            Alert("Su borrador fue eliminado y no se puede Activar como pedido", Me)
            ' Response.Redirect("borrad-pedido.aspx")
        Else
            If Cart.CantidadLineas(Cart.UltimoItemxCart(CLI_CODIGO)) = 0 Then
                totallineas.Text = items
                Session("TotalLineas") = totallineas.Text
                Session("TotalGastos") = dTotal
                totalgastos.Text = Session("TotalGastos")
                For Each dr As GridViewRow In GridView2.Rows
                    sProductID = dr.Cells(0).Text
                    Dim cantii As String
                    cantii = dr.Cells(3).Text
                    sProductID = Trim(sProductID)
                    cant = CDec(cantii)
                    Session.Add(sProductID, cant)

                Next
                Cart.PasarBorradorPedido(Label3.Text, Cart.UltimoItemxCart(CLI_CODIGO))

                Response.Redirect("VerPedido.aspx")


            Else
                LabelBorrar.Visible = True
                LabelBorrar.Text = "para activar un borrador a pedido actual no deben haber lines cargadas en el carrito de compra "
                GridView1.Visible = False
                GridView2.Visible = False
            End If
        End If
    End Sub

    Protected Sub ButtonEliminarPed_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonEliminarPed.Click
        Dim ultArtCart As New Cart
        Dim ult_cod_carr As Integer
        Dim hoy As Date = DateTime.Now
        Dim CAR_EXPIRA As Date = hoy.AddDays(15)
        Dim nom_cliente As String = CType(Session.Item("USER"), String)
        Dim EST_CODIGO As Integer = 0
        Dim SEG_USUARIO As String = nom_cliente

        ult_cod_carr = Cart.UltimoItemxCart(CType(Session.Item("USER"), Integer))

        If Cart.DeleteCarrito(Label3.Text) = 1 And Cart.DeleteLineaCarrito(Label3.Text) = 1 Then
            Alert("Su borrador fue eliminado", Me)
        End If
        If ult_cod_carr = Label3.Text Then
            Cart.InsertCarrito(CAR_EXPIRA, hoy, nom_cliente, EST_CODIGO, SEG_USUARIO)
        End If

        Dim CLI_CODIGO As String = CType(Session.Item("USER"), String)
        GridView1.Visible = True
        GridView2.Visible = False

        LinkButtonVolverAtras.Visible = True
        Label1.Visible = True
        Label2.Visible = False
        Label3.Visible = False
        ButtonActivarPed.Visible = False
        ButtonEliminarPed.Visible = False
        imgPrint.Visible = True
        LinkButtonVolverBorradores.Visible = False
        GridView1.DataSource = Cart.selectCarritoCli(CLI_CODIGO)
        GridView1.DataBind()
        GridView2.DataBind()
    End Sub
    Public Sub Alert(ByVal msg As String, ByRef P As Page)
            Dim strScript As String
            strScript = "<script language=javascript> alert('" + msg + ".');</script>"
            P.ClientScript.RegisterStartupScript(Me.GetType, "Alert", strScript)
        End Sub

    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridView1.PageIndex = e.NewPageIndex
        GridView1.DataSource = Cart.selectCarritoCli(CLI_CODIGO)
        GridView1.DataBind()
    End Sub
End Class
