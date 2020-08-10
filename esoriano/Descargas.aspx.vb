Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Security
Imports ClassLibrary1
Public Class Descargas
    Inherits System.Web.UI.Page

    Public nom_cliente As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session.Item("USER") Is Nothing Then

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

                Response.Redirect("Descargas.aspx")


            Else
                lblError.Text = "Error en usuario y contraseña ..."
            End If
        Catch ex As Exception 'Se produce error en el uso del procedimiento
            lblError.Visible = True
            lblError.Text = "Error al intentar identificar al usuario: "
            lblError.Text &= ex.Message
        End Try
        Return 0
    End Function

    Protected Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        If Not Session.Item("USER") Is Nothing And Session.Item("Entro") = 0 Then
            Dim vtn As String = "window.open('DetalleNovedad.aspx', 'windowOpenTab', 'scrollbars=1,resizable=1,width=550,height=500,left=200, top=150');"

            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", vtn, True)
            Session("Entro") = 1
        End If
    End Sub


    Protected Sub ButtonLog_Click(sender As Object, e As EventArgs) Handles ButtonLog.Click
        If IsValid Then
            If Len(Me.TextBoxPass.Text) <> 6 Then
                lblError.Visible = True
                lblError.Text = "Error al intentar identificar al usuario: "
            Else

                If DBAuthenticate(TextBoxUser.Text, TextBoxPass.Text) > 0 Then
                    System.Web.Security.FormsAuthentication.RedirectFromLoginPage(TextBoxUser.Text, chkPassword.Checked)

                End If

            End If
        End If
    End Sub

    Protected Sub btn_catalogo_Click(sender As Object, e As EventArgs)
        Response.Redirect("WEBRepositorio/esoriano/Catalogo/Esoriano.pdf")
    End Sub

    Protected Sub btn_lista_excel_Click(sender As Object, e As EventArgs)
        Response.Redirect("WEBRepositorio/esoriano/Listas/LISTAS1C.XLS")
    End Sub

    Protected Sub btnInstructivo_Click(sender As Object, e As EventArgs)
        Response.Redirect("WEBRepositorio/esoriano/Instructivo/manual.pdf")

    End Sub
End Class