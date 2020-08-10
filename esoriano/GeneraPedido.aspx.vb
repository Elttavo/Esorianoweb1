Imports System.Data
Imports System.Data.DataRow
Imports System.Data.SqlClient
Imports System.Configuration
Imports ClassLibrary1

Partial Class GeneraPedido

    Inherits System.Web.UI.Page
    Public CartItem As CartItem
    Dim dTotal As Decimal = 0
    Public tabla_datos As New DataTable()
    Public Rubro, Subrubro, sProductID, cvt_v_nombre As String
    Public nom_cliente As String
    Private SelectedProduct As ArticulosCart
    Public codart As String
    Dim cant As Decimal
    Public canti As Decimal
    Public canti1 As Decimal
    Public comand As String
    Public prodid As String
    Public prodid1 As String
    Dim hoy As Date = DateTime.Now
    Dim CAR_EXPIRA As Date = hoy.AddDays(15)


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Response.Cache.SetCacheability(HttpCacheability.Private, "Community=DEV")
        'Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache)
        'Response.Cache.SetAllowResponseInBrowserHistory(False)
        'Response.Cache.SetNoStore()
        If Session.Item("USER") Is Nothing Then
            Response.Redirect("pedidos.aspx")
        End If

        If IsPostBack Then

            If Session("grab") <> 1 Then
                Response.Write("<script>alert('el Pedido ya fue Enviado con anterioridad  , genere uno nuevo para Continuar .');window.location='pedidos.aspx';</script>")
            End If

            cvt_v_nombre = cbocvt.SelectedItem.ToString()
            cvt_v_nombre = cbocvt.SelectedItem.Text()
        End If
        Dim cli As New Cliente
        Dim nom_cliente As String = CType(Session.Item("USER"), String)
        Dim lst_cod As Integer

        cli.LST_CODIGO = Cliente.SelectTipCli(nom_cliente)
        lst_cod = cli.LST_CODIGO
        If lst_cod = 1 Then
            cbocvt.DataSource = Cliente.SelectCondVta()
            cbocvt.DataTextField = "CVT_nombre"
            cbocvt.DataValueField = "CVT_codigo"
            cbocvt.DataBind()
        Else
            cbocvt.DataSource = Cliente.SelectCondVta()
            cbocvt.DataTextField = "CVT_nombre"
            cbocvt.DataValueField = "CVT_codigo"
            cbocvt.DataBind()
        End If

        If Not IsPostBack Then

            Session(sProductID) = True

            Dim ds As DataSet
            ds = ArticulosCart.SelectArtVerPedido(Cart.UltimoItemxCart(CType(Session.Item("USER"), Integer)))
            tabla_datos = ds.Tables(0)
            tabla_datos.Locale = System.Globalization.CultureInfo.InvariantCulture
            tabla_datos.Columns.Add("Cantidad")
            tabla_datos.Columns.Add("Total")

            Dim Cantidad As New BoundField
            Cantidad.DataField = "Cantidad"
            Cantidad.HeaderText = "Cantidad"
            Cantidad.ApplyFormatInEditMode = True
            Cantidad.HtmlEncode = False

            Dim Total As New BoundField
            Total.DataField = "Total"
            Total.HeaderText = "Total"
            Total.ReadOnly = True
            Total.ItemStyle.HorizontalAlign = HorizontalAlign.Right

            Dim Actualizar As New CommandField
            Actualizar.ButtonType = ButtonType.Button
            Actualizar.HeaderText = "Actualizar"
            Actualizar.ShowEditButton = True
            Actualizar.EditText = "Actualizar"

            Dim Eliminar As New CommandField
            Eliminar.ButtonType = ButtonType.Button
            Eliminar.HeaderText = "Eliminar"
            Eliminar.ShowDeleteButton = True
            Eliminar.EditText = "Eliminar Item"

            recorretabla(ds)

        End If

    End Sub
    Private Sub recorretabla(ds As DataSet)

        For Each dir As DataRow In ds.Tables(0).Rows

            prodid = dir("ART_CODIGO").ToString()
            canti = dir("LIC_CANTIDAD").ToString()

            For Each dr As DataRow In tabla_datos.Rows
                Dim precio As Decimal
                codart = dr("ART_CODIGO").ToString '
                codart = Trim(codart)
                precio = dr("LST_PRECIO1")
                Rubro = dr("RUB_CODIGO")
                Subrubro = dr("SRB_CODIGO")
                If codart = prodid Then
                    dr("Cantidad") = Int(canti)
                    dr("Total") = Int(canti) * precio
                End If

            Next
        Next
        Session(sProductID) = tabla_datos
        BindData()

    End Sub
    Private Sub BindData()
        GridView1.DataSource = Session(sProductID)
        GridView1.DataBind()
    End Sub
    Protected Sub GridView1_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GridView1.RowCancelingEdit
        GridView1.EditIndex = -1
        BindData()
    End Sub


    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If comand = "edit" Then  ' estano borrar
            Exit Sub
        Else
            If e.Row.RowType = DataControlRowType.DataRow Then

                If (DataBinder.Eval(e.Row.DataItem, "Total")).ToString <> "" Then
                    dTotal += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total"))
                End If
            End If
        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(4).Text = "Total:"
            e.Row.Cells(5).Text = dTotal.ToString("c")
            e.Row.CssClass = "FooterGridView"
        End If
    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        GridView1.EditIndex = e.NewEditIndex
        BindData()
    End Sub

    Private Sub AddToSession(ByVal sProductID As String, ByVal cant As Decimal)
        If Not Session(sProductID) Is Nothing Then
            Session.Add(sProductID, cant)
        End If
    End Sub
    Private Sub removeToSession(ByVal sProductID As String)
        Session.Remove(sProductID)
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


    Protected Sub ButtonConfPed_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonConfPed.Click
        Dim hoy As Date = Date.Now
        Dim nom_cliente As String = CType(Session.Item("USER"), String)
        Dim EST_CODIGO As Integer = 1
        Dim SEG_USUARIO As String = nom_cliente
        Dim CVT As Integer = cbocvt.SelectedValue
        Dim CVT1 As String = cvt_v_nombre
        Dim PED_MEMO As String = pedmemo.Text
        Dim seghora As Date = DateTime.Now.ToString("hh:mm:ss")
        Dim ultlinped1 As Integer
        ultlinped1 = Pedidosweb.UltimoLinPed()
        ultlinped1 = ultlinped1 + 1
        Dim ped As String = ultlinped1.ToString
        If GridView1.Rows.Count > 0 Then
            lblOutput.Visible = False
            If Pedidosweb.InsertPedidos(1, nom_cliente, hoy, EST_CODIGO, CVT, PED_MEMO, SEG_USUARIO, hoy, CVT1) = 1 Then
                Dim ultlinpedcod As Integer
                Dim precio As Decimal
                Dim ultlinped As Integer
                Dim undcons As String
                Dim cantii As String
                Dim ds As DataSet
                ds = ArticulosCart.SelectArtVerPedido(Cart.UltimoItemxCart(CType(Session.Item("USER"), Integer)))
                tabla_datos = ds.Tables(0)
                For Each dir As DataRow In ds.Tables(0).Rows

                    prodid = dir("ART_CODIGO").ToString()
                    cantii = dir("LIC_CANTIDAD").ToString()
                    undcons = dir("ART_UND_CONSUMO").ToString()
                    precio = dir("LST_PRECIO1").ToString()
                    ultlinped = Pedidosweb.UltimoLinPed()
                    prodid = Trim(prodid)
                    cant = CDec(cantii)
                    ultlinpedcod = Pedidosweb.UltimoLinCodPed(ultlinped)
                    Pedidosweb.InsertPedidosLinea(1, ultlinped, ultlinpedcod, cant, precio, prodid, undcons, SEG_USUARIO, hoy)
                    removeToSession(prodid)
                Next
            End If
            'creo un nuevo carrito 
            Cart.InsertCarrito(CAR_EXPIRA, hoy, nom_cliente, EST_CODIGO, SEG_USUARIO)
            'pongo gra en 2 para que no genere otro pedido con los mismos datos
            Session("grab") = 2
            Session.Remove("TotalLineas")
            Session.Remove("TotalGastos")

            Response.Write("<script>alert('Su pedido fue generado con exito.Número provisorio de confirmación: " & ped & " ');window.location='pedidos.aspx';</script>")
            Response.Redirect("pedidoTerminado.aspx?ped=" & ped)
        Else
            lblOutput.Visible = True
            lblOutput.Text = "No se pueden Generar Pedidos vacio , Verifique el contenido del mismo antes de querer enviarlo Nuevamente"

        End If

    End Sub

    Public Function MsgBox(ex As String, pg As Page, obj As Object) As Int16

        Dim s As String = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>"
        Dim cstype As Type = obj.GetType()
        Dim cs As ClientScriptManager = pg.ClientScript
        cs.RegisterClientScriptBlock(cstype, s, s.ToString())
        Return 1
    End Function

End Class