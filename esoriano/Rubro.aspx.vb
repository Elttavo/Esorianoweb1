Imports ClassLibrary1

Public Class Rubro

    Inherits System.Web.UI.Page

    Public Rubro As String
    Public Subrubro As String
    Private SelectedArt As ArticulosCart
    Public tabla_datos As New Data.DataTable()
    Dim cont As Integer
    Dim cant As Decimal
    Public sProductID As String
    Public precio As Decimal
    Public codart As String
    Dim dTotal As Decimal
    Public cantidadgrabada As Decimal
    Public canti1 As Decimal
    Public comand As String
    Public prodid As String
    Dim txt As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Session.Item("USER") Is Nothing Then
            Response.Redirect("pedidos.aspx")
        End If

        Rubro = Request.QueryString("Rub")
        Subrubro = Request.QueryString("Sub")
        If Not IsPostBack Then
            If Not Session.Item("USER") Is Nothing Then
                Panel1.Visible = True
                Dim cli As New Cliente
                Dim nom_cliente As String = CType(Session.Item("USER"), String)
                Dim lst_cod As Integer
                Dim banner As String
                cli.LST_CODIGO = Cliente.SelectTipCli(nom_cliente)
                lst_cod = cli.LST_CODIGO
                If lst_cod = 1 Then
                    banner = Cliente.SelectBanner(nom_cliente, lst_cod)
                Else
                    banner = Cliente.SelectBanner(nom_cliente, lst_cod)
                End If
                DataListArtLogin.Visible = True
                DataListArtLogin.DataSource = ArticulosCart.SelectArt(Rubro, Subrubro)
                DataListArtLogin.DataBind()

                FormViewPath1.DataSource = Rubros.RubroSubFW(Rubro, Subrubro)
                FormViewPath1.DataBind()
            End If
        End If


    End Sub
    Private Sub AddToSession(ByVal sProductID As String, ByVal cant As Decimal)

        If Not Session(sProductID) Is Nothing Then
            Session.Add(sProductID, 0 + cant)
        Else
            Dim totallineas As Label = DirectCast(Me.cab.FindControl("Items"), Label)
            Dim totalgastos As Label = DirectCast(Me.cab.FindControl("Total"), Label)
            Dim total As Decimal
            Dim ult_cod_carr As Integer
            sProductID = SelectedArt.ART_CODIGO
            precio = SelectedArt.LST_PRECIO1
            total = cant * precio
            sProductID = RTrim(sProductID)
            cont = totallineas.Text
            If cont = 0 Then
                ult_cod_carr = Cart.UltimoItemxCart(CType(Session.Item("USER"), Integer))
                Cart.UpdateCarrito(ult_cod_carr, 1)
            End If
            cont = cont + 1
            Session.Add(sProductID, cant)
            prodid = sProductID
            ult_cod_carr = Cart.UltimoItemxCart(CType(Session.Item("USER"), Integer))
            Cart.InsertCarritoLinea(ult_cod_carr, prodid, cant)
            If totalgastos.Text = "" Then
            Else
                dTotal = CDec(totalgastos.Text)
            End If
            totallineas.Text = cont
            Session("TotalLineas") = totallineas.Text
            dTotal = dTotal + total
            totalgastos.Text = dTotal
            Session("TotalGastos") = totalgastos.Text
        End If
    End Sub
    Private Function GetSelectArtInd() As ArticulosCart
        Dim ArtCart As New ArticulosCart
        ArtCart = ArticulosCart.SelectArtInd(Rubro, Subrubro, codart)
        ArtCart.EMP_CODIGO = ArticulosCart.intEMP_CODIGO
        ArtCart.ART_CODIGO = ArticulosCart.strART_CODIGO
        ArtCart.ART_NOMBRE = ArticulosCart.strART_NOMBRE
        ArtCart.ART_UND_BULTO = ArticulosCart.intART_UND_BULTO
        ArtCart.LST_PRECIO1 = ArticulosCart.intLST_PRECIO1
        Return ArtCart
    End Function
    Protected Sub DataListArtLogin_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles DataListArtLogin.ItemDataBound
        If e.Item.ItemType = ListItemType.Footer Then
            CType(e.Item.FindControl("Contador2"), Label).Text = DataListArtLogin.Items.Count.ToString()
        End If
    End Sub
    Protected Sub DataListArtLogin_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataListArtLogin.PreRender
        Try
            Rubro = Request.QueryString("Rub")
            Subrubro = Request.QueryString("Sub")
            For Each item As DataListItem In DataListArtLogin.Items
                Dim index As Integer
                Dim INDEX1 As Integer
                Dim index2 As Integer
                INDEX1 = item.ItemIndex()
                index = DataListArtLogin.Items.Count
                Dim td As HtmlTableCell = New HtmlTableCell()
                td = CType(item.FindControl("codart"), HtmlTableCell)
                codart = td.InnerText
                codart = codart.Trim

                cantidadgrabada = 0
                cantidadgrabada = RecuperarSession(codart)
                Dim txtBox As TextBox
                txtBox = CType(item.FindControl("txtCantidad"), TextBox)
                If cantidadgrabada <> 0 Then
                    txtBox.Text = cantidadgrabada
                    index2 = item.ItemIndex()
                    txtBox.BackColor = Drawing.Color.LightGray
                    txtBox.ReadOnly = True
                End If
                If INDEX1 = 0 And txtBox.Text <> "" Then
                    txtBox.Focus()
                End If
                If INDEX1 = 1 And txtBox.Text <> "0" Then
                    txtBox.Focus()
                End If

                If index2 <> 0 Then
                    txtBox.Focus()
                    index2 = 0
                End If
                If txtBox.Text <> "" And cantidadgrabada = 0 Then
                    Dim txt As String
                    txt = txtBox.Text
                    txt = CDbl(txt)
                    txt = txt.Replace(",", ".")

                    cant = CDec(txt)

                End If

                If cant <> 0 And txtBox.Text <> "" And cantidadgrabada = 0 Then
                    SelectedArt = Me.GetSelectArtInd()
                    sProductID = SelectedArt.ART_CODIGO
                    precio = SelectedArt.LST_PRECIO1
                    Me.AddToSession(sProductID, cant)
                    index2 = item.ItemIndex()
                    txtBox.BackColor = Drawing.Color.LightGray
                    txtBox.ReadOnly = True
                End If
                If txtBox.Text = "0" Then
                    txtBox.Text = ""
                End If
            Next
        Catch

            MsgBox("Error al introducir el número" & ControlChars.CrLf & "el valor" & txt & " es incorrecto")

        End Try

    End Sub
    Function RecuperarSession(ByVal sProductID As String) As Decimal

        If Not Session(sProductID) Is Nothing Then

            cantidadgrabada = Session(sProductID)

        End If
        Return cantidadgrabada
    End Function

    Public Shared Function KeepActiveSession() As Boolean
        If HttpContext.Current.Session.IsNewSession Then
            Return False
        Else
            Return True
        End If

    End Function

    Public Sub SessionAbandon()
        HttpContext.Current.Session.Abandon()
        Response.Redirect("pedidos.aspx")
    End Sub

End Class