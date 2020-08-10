Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Security
Imports ClassLibrary1

Public Class Pedidos
    Inherits System.Web.UI.Page
    Public nom_cliente As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Session.Item("USER") Is Nothing Then
            lblError.Text = ""
            lblError.Visible = False
            PanelUser.Visible = False
            Panelbotones.Visible = True
            NoveSL.Visible = False
            Novedades.Visible = True

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

        Else
            PanelUser.Visible = True
            Panelbotones.Visible = False
            NoveSL.Visible = True
            Novedades.Visible = False

        End If


    End Sub

    Function DBAuthenticate(ByVal strUsername As String, ByVal strPassword As String) As Integer

        Try
            Dim intresult As Integer = Administracion.DBAuthenticateCli(strUsername, strPassword)
            If intresult > 0 Then
                lblError.Text = ""
                FormsAuthentication.SetAuthCookie(TextBoxUser.Text, True)
                Session("USER") = TextBoxUser.Text
                Session("Entro") = 0
                Dim hoy As Date = DateTime.Now
                Dim CAR_EXPIRA As Date = hoy.AddDays(15)
                Dim nom_cliente As String = CType(Session.Item("USER"), String)
                Dim EST_CODIGO As Integer = 0
                Dim SEG_USUARIO As String = nom_cliente
                cart.InsertCarrito(CAR_EXPIRA, hoy, nom_cliente, EST_CODIGO, SEG_USUARIO)

                Response.Redirect("pedidos.aspx")


            Else
                lblError.Visible = True
                lblError.Text = " Verifique los Datos de Usuario y Contraseña y  vuelva a intentarlo ..."
            End If
        Catch ex As Exception 'Se produce error en el uso del procedimiento
            lblError.Visible = True
            lblError.Text = " Verifique los Datos de Usuario y Contraseña y  vuelva a intentarlo ... "
            lblError.Text &= ex.Message
        End Try
        Return 0
    End Function

    Protected Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        If Not Session.Item("USER") Is Nothing And Session.Item("Entro") = 0 Then
            Dim vtn As String = "window.open('DetalleNovedad.aspx', 'windowOpenTab', 'scrollbars=1,resizable=1,width=550,height=500,left=200, top=150');"
            '" window.open('DetalleSolicitud.aspx','open_window','menubar, toolbar, location, directories, status, scrollbars, resizable, dependent, width = 440, height =280, Left() = 0, top = 0 ')"
            '
            '' "window.open('DetalleSolicitud.aspx','Dates','scrollbars=yes,resizable=yes','height=200', 'width=100')"

            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", vtn, True)
            Session("Entro") = 1
        End If
    End Sub


    Protected Sub ButtonLog_Click1(sender As Object, e As EventArgs) Handles ButtonLog.Click
        If IsValid Then
            If Len(Me.TextBoxPass.Text) <> 6 Or Len(Me.TextBoxUser.Text) <> 6 Then
                lblError.Visible = True
                lblError.Text = "Error al intentar identificar al usuario: "
            Else
                If Not IsNumeric(Me.TextBoxUser.Text) Then
                    Me.lblError.Text = "Usuario Incorrecto"
                    Exit Sub
                End If
                If Not IsNumeric(Me.TextBoxPass.Text) Then
                    Me.lblError.Text = "Contraseña Incorrecta"
                    Exit Sub
                End If
                If DBAuthenticate(TextBoxUser.Text, TextBoxPass.Text) > 0 Then
                    System.Web.Security.FormsAuthentication.RedirectFromLoginPage(TextBoxUser.Text, chkPassword.Checked)

                End If

            End If
        End If
    End Sub


    Protected Sub btn_por_rubros_Click(sender As Object, e As EventArgs)
        Response.Redirect("ProductoRubro.aspx")
    End Sub

    Protected Sub btnRubrosCeluClick(sender As Object, e As EventArgs)
        Response.Redirect("ProductoRubroCelu.aspx")
    End Sub

    Protected Sub btnPedGen_Click(sender As Object, e As EventArgs)
        Response.Redirect("ConPedidoGen.aspx")

    End Sub

    Protected Sub btnFactura_Click(sender As Object, e As EventArgs)
        Response.Redirect("ConsFactura.aspx")
    End Sub

    Protected Sub btnConVent_Click(sender As Object, e As EventArgs)
        Response.Redirect("ConsConVent.aspx")
    End Sub

    Protected Sub btnBorrador_Click(sender As Object, e As EventArgs)
        Response.Redirect("ConBorrador.aspx")
    End Sub
End Class


