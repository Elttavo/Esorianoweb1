
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Collections
Imports ClassLibrary1
Imports System.Object
Imports System.EventArgs
Imports System.Web.UI.WebControls


Partial Class RubroCelu
    Inherits System.Web.UI.Page
    Public rubro, subRubro, sProductID, prodid, txt, codart As String
    Private selectArt As ArticulosCart
    Dim cont As Integer
    Dim cant, precio, cantidadgrabada, dTotal As Decimal
    Public dato As String
    Dim txtBox As TextBox



    Protected Sub btn_cantidad_combo_Click(sender As Object, e As ImageClickEventArgs)
        For Each item As DataListItem In DataListArtLogin.Items


            dato = CType(item.FindControl("DropDownList1"), DropDownList).Text + CType(item.FindControl("DropDownList2"), DropDownList).Text + CType(item.FindControl("DropDownList3"), DropDownList).Text + CType(item.FindControl("DropDownList4"), DropDownList).Text
            If dato <> 0 Then
                txtBox = CType(item.FindControl("TextCanti"), TextBox)
                'si ya tiene un valor grabado 

                txtBox.Text = Integer.Parse(dato)

            End If
            dato = 0
        Next
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Session.Item("USER") Is Nothing Then
            Response.Redirect("pedidos.aspx")
        End If

        rubro = Request.QueryString("Rub")
        subRubro = Request.QueryString("Sub")
        If Not IsPostBack Then

            If Not Session.Item("USER") Is Nothing Then

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
                DataListArtLogin.DataSource = ArticulosCart.SelectArt(rubro, subRubro)
                DataListArtLogin.DataBind()

                FormViewPath1.DataSource = Rubros.RubroSubFW(rubro, subRubro)
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
            sProductID = selectArt.ART_CODIGO
            precio = selectArt.LST_PRECIO1
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
            If totalgastos.Text <> "" Then
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
        ArtCart = ArticulosCart.SelectArtInd(codart)
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
        Dim Indiceactual As Integer
        Dim index2 As Integer
        Try
            If Not IsPostBack Then
                index2 = -1
            End If

            For Each item As DataListItem In DataListArtLogin.Items

                Indiceactual = item.ItemIndex()
                Dim td As HtmlGenericControl = New HtmlGenericControl()
                td = CType(item.FindControl("codart"), HtmlGenericControl)
                codart = td.InnerText
                codart = codart.Trim
                cantidadgrabada = 0
                cantidadgrabada = RecuperarSession(codart)


                txtBox = CType(item.FindControl("TextCanti"), TextBox)
                'si ya tiene un valor grabado 
                If cantidadgrabada <> 0 Then
                    txtBox.Text = cantidadgrabada
                    index2 = item.ItemIndex()
                    txtBox.BackColor = Drawing.Color.LightGray
                    txtBox.ReadOnly = True
                End If
                'si no tiene ningun valor grabado 
                If cantidadgrabada = 0 Then

                    If txtBox.Text <> "" And txtBox.Text <> "0" Then
                        txt = txtBox.Text
                        txt = txt.Replace(",", ".")
                        cant = CDec(txt)
                    Else
                        txtBox.Text = ""
                    End If
                End If
                'si tiene un valor nuevo
                If cant <> 0 And cantidadgrabada = 0 Then
                    selectArt = Me.GetSelectArtInd()
                    sProductID = selectArt.ART_CODIGO
                    precio = selectArt.LST_PRECIO1
                    Me.AddToSession(sProductID, cant)
                    index2 = item.ItemIndex()
                    txtBox.BackColor = Drawing.Color.LightGray
                    txtBox.ReadOnly = True
                    cant = 0
                End If
                'pongo el cursor uno despues de la ultima actualizacion index2 + 1 
                If index2 = Indiceactual Then
                    txtBox.Focus()
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
