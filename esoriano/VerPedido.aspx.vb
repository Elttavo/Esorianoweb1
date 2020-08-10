Imports System.Data
Imports System.Data.DataRow
Imports System.Data.SqlClient
Imports System.Configuration
Imports ClassLibrary1

Public Class VerPedido
    Inherits System.Web.UI.Page

    Public CartItem As CartItem
    Dim intI As Integer
    Dim dTotal As Decimal = 0
    Public tabla_datos As New DataTable()
    Public Rubro As String
    Public Subrubro As String
    Public s As String
    Public nom_cliente As String
    Private SelectedProduct As ArticulosCart
    Public codart As String
    Dim cant As Decimal
    Public sProductID As String
    Public canti As Decimal
    Public canti1 As Decimal
    Public comand As String
    Public prodid As String
    Public prodid1 As String
    Public grab As Integer = 1
    Protected widestData As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session.Item("USER") Is Nothing Then
            Response.Redirect("Pedidos.aspx")
        Else

            If Not IsPostBack Then
                Session(sProductID) = True
                widestData = 0
                Dim ds As DataSet
                ds = ArticulosCart.SelectArtVerPedido(Cart.UltimoItemxCart(CType(Session.Item("USER"), Integer)))
                tabla_datos = ds.Tables(0)
                tabla_datos.Locale = System.Globalization.CultureInfo.InvariantCulture
                GridView1.Visible = True
                tabla_datos.Columns.Add("Cantidad")
                tabla_datos.Columns.Add("Total")

                Dim Cantidad As New BoundField
                Cantidad.DataField = "Cantidad"
                Cantidad.ItemStyle.HorizontalAlign = HorizontalAlign.Right 'Agrege esta linea
                Cantidad.HeaderText = "Cant."
                Cantidad.HeaderStyle.HorizontalAlign = HorizontalAlign.Right
                Cantidad.ControlStyle.Width = "40"

                Dim Total As New BoundField
                Total.DataField = "Total"
                Total.HeaderText = "Total"
                Total.HeaderStyle.HorizontalAlign = HorizontalAlign.Right
                Total.ReadOnly = True
                Total.ItemStyle.HorizontalAlign = HorizontalAlign.Right

                Dim Actualizar As New CommandField
                Actualizar.ButtonType = ButtonType.Button
                Actualizar.HeaderText = "Modificar"
                Actualizar.ShowEditButton = True
                Actualizar.EditText = "Modif. Cantidad"
                Actualizar.ItemStyle.Width = "80"


                Dim Eliminar As New CommandField
                Eliminar.ButtonType = ButtonType.Button
                Eliminar.HeaderText = "Eliminar"
                Eliminar.ShowDeleteButton = True
                Eliminar.EditText = "Eliminar"
                Eliminar.ItemStyle.Width = "70"


                GridView1.Columns.Add(Cantidad)
                'GridView1.Columns(4).ItemStyle.Width = 30
                GridView1.Columns.Add(Total)
                GridView1.Columns.Add(Actualizar)
                GridView1.Columns.Add(Eliminar)
                recorretabla(ds)

            End If
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

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Session(sProductID) = True
        widestData = 0
        Dim ds As DataSet
        ds = ArticulosCart.SelectArtVerPedido(Cart.UltimoItemxCart(CType(Session.Item("USER"), Integer)))
        tabla_datos = ds.Tables(0)
        tabla_datos.Locale = System.Globalization.CultureInfo.InvariantCulture
        GridView1.Visible = True
        GridView1.DataSource = tabla_datos

        If e.CommandName = "Edit" Then

            tabla_datos.Columns.Add("Cantidad")
            tabla_datos.Columns.Add("Total")
            recorretabla(ds)
            Session(sProductID) = tabla_datos
            comand = "edit"
        ElseIf e.CommandName = "Cancel" Then

            tabla_datos.Columns.Add("Cantidad")
            tabla_datos.Columns.Add("Total")
            recorretabla(ds)
            Session(sProductID) = tabla_datos
        ElseIf e.CommandName = "Update" Then

            tabla_datos.Columns.Add("Cantidad")
            tabla_datos.Columns.Add("Total")

        End If
    End Sub
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If comand = "edit" Then
            Dim drv As System.Data.DataRowView
            drv = CType(e.Row.DataItem, System.Data.DataRowView)
            If e.Row.RowType = DataControlRowType.DataRow Then
                If drv IsNot Nothing Then
                End If
            End If

            Exit Sub
        Else
            If e.Row.RowType = DataControlRowType.DataRow Then
                If (DataBinder.Eval(e.Row.DataItem, "Total")).ToString <> "" Then
                    dTotal += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total"))
                End If
            End If
        End If
        Dim totalgastos As Label = DirectCast(Me.Cabecera.FindControl("Total"), Label)

        totalgastos.Text = dTotal
        Session("TotalGastos") = totalgastos.Text
        If e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(4).Text = "Total:"
            e.Row.Cells(4).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(5).Text = dTotal.ToString("c")
            e.Row.Cells(5).HorizontalAlign = HorizontalAlign.Right
            e.Row.Font.Bold = True
        End If
    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim index As Integer
        Dim fila As GridViewRow = GridView1.Rows(e.RowIndex)
        index = GridView1.Rows.Count
        prodid = fila.Cells(0).Text
        prodid = Trim(prodid)
        removeToSession(prodid)
        ArticulosCart.DeleteArticuloCarro(prodid, Cart.UltimoItemxCart(CType(Session.Item("USER"), Integer)))
        Session(sProductID) = True
        widestData = 0
        Dim ds As DataSet
        ds = ArticulosCart.SelectArtVerPedido(Cart.UltimoItemxCart(CType(Session.Item("USER"), Integer)))
        tabla_datos = ds.Tables(0)
        tabla_datos.Locale = System.Globalization.CultureInfo.InvariantCulture
        GridView1.Visible = True
        tabla_datos.Columns.Add("Cantidad")
        tabla_datos.Columns.Add("Total")
        recorretabla(ds)

        Dim totallineas As Label = DirectCast(Me.Cabecera.FindControl("Items"), Label)
        'Dim total As Decimal
        Dim cont As Integer
        cont = totallineas.Text
        totallineas.Text = cont - 1
        Session("TotalLineas") = totallineas.Text
        Session(sProductID) = tabla_datos
        GridView1.EditIndex = -1
        If totallineas.Text = 0 Then
            Dim totalgastos As Label = DirectCast(Me.Cabecera.FindControl("Total"), Label)
            totalgastos.Text = CDbl(0)
            Session("TotalGastos") = CDbl(0)
        End If

    End Sub
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        GridView1.EditIndex = e.NewEditIndex
        BindData()
    End Sub
    Protected Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView1.RowUpdating
        Dim index As Integer
        Dim dTotal As Decimal
        Dim fila As GridViewRow = GridView1.Rows(e.RowIndex)
        index = GridView1.Rows.Count
        prodid = fila.Cells(0).Text
        Dim cantii As String
        cantii = CType(fila.Cells(4).Controls(0), TextBox).Text
        prodid = Trim(prodid)
        cant = CDec(cantii)
        AddToSession(prodid, cant)
        For Me.intI = 0 To Convert.ToInt16(Session.Count() - 1)
            prodid = Session.Keys(intI)
            canti = CDec(Session(prodid))
            For Each dr As DataRow In tabla_datos.Rows
                Dim precio As Decimal
                codart = dr("ART_CODIGO").ToString
                codart = Trim(codart)
                precio = dr("LST_PRECIO1")
                If codart = prodid Then
                    dr("Cantidad") = canti
                    dr("Total") = canti * precio
                    dTotal = dr("Total").ToString
                    Dim ultArtCart As New cart
                    Dim ult_cod_carr As Integer
                    ult_cod_carr = cart.UltimoItemxCart(CType(Session.Item("USER"), Integer))
                    cart.UpdateCarritoLinea(ult_cod_carr, codart, canti)
                    Dim totalgastos As Label = DirectCast(Me.Cabecera.FindControl("Total"), Label)
                    totalgastos.Text = dTotal
                    Session("TotalGastos") = totalgastos.Text
                End If
            Next
        Next
        Session(sProductID) = tabla_datos
        GridView1.EditIndex = -1
        BindData()

    End Sub
    Private Sub AddToSession(ByVal sProductID As String, ByVal cant As Decimal)
        If Not Session(sProductID) Is Nothing Then
            Session.Add(sProductID, cant)
        End If
    End Sub
    Private Sub removeToSession1()
        Dim index As Integer

        For index = 0 To GridView1.Rows.Count - 1
            Dim fila As GridViewRow = GridView1.Rows(index)
            prodid = fila.Cells(0).Text
            prodid = Trim(prodid)
            removeToSession(prodid)

        Next
        Dim tabla_datos As DataTable = Nothing
        Session(sProductID) = tabla_datos
        Session().Remove(sProductID)
        GridView1.DataSource = tabla_datos
        GridView1.DataBind()

    End Sub

    Private Sub removeToSession(ByVal sProductID As String)

        Session.Remove(prodid)

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

    Protected Sub carrito_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles carrito.Click

        Dim ultArtCart As New Cart
        Dim ult_cod_carr As Integer
        Dim EST_CODIGO As Integer = 1
        Dim SEG_USUARIO As String = Session.Item("USER")
        Dim hoy As Date = DateTime.Now
        Dim CAR_EXPIRA As Date = hoy.AddDays(15)
        ult_cod_carr = cart.UltimoItemxCart(CType(Session.Item("USER"), Integer))

        cart.UpdateCarrito(ult_cod_carr, 2)
        Alert("Borrador grabado correctamente", Me)

        Session.Remove("TotalLineas")
        Session.Remove("TotalGastos")
        removeToSession1()
        'creo un nuevo carrito 
        Cart.InsertCarrito(CAR_EXPIRA, hoy, SEG_USUARIO, EST_CODIGO, SEG_USUARIO)
        Response.Redirect("pedidos.aspx")

    End Sub

    Public Sub Alert(ByVal msg As String, ByRef P As Page)
        Dim strScript As String
        strScript = "<script language=javascript> alert('" + msg + ".');</script>"
        P.ClientScript.RegisterStartupScript(Me.GetType(), "Alert", strScript)
        grab = 2
    End Sub

    Protected Sub ButtonGenerarPed_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonGenerarPed.Click
        Session("grab") = 1
        Response.Redirect("GeneraPedido.aspx")
    End Sub


End Class