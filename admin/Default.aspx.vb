Imports System.Data
Imports System.Data.SqlClient
Imports ClassLibrary1
Imports Esoriano
Imports System.Web.Security
Imports System.Object
Imports System.IO

Public Class _Default1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub ButtonLog_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonLog.Click
        Try

            If IsValid Then


                If Len(Me.TextBoxPass.Text) <> 6 Or Len(Me.TextBoxUser.Text) <> 6 Then
                    lblError.Visible = True
                    lblError.Text = "Error al intentar identificar al usuario: "
                Else

                    If Administracion.DBAuthenticate(TextBoxUser.Text, TextBoxPass.Text) > 0 Then
                        System.Web.Security.FormsAuthentication.RedirectFromLoginPage(TextBoxUser.Text, chkPassword.Checked)


                        lblError.Text = ""
                        FormsAuthentication.SetAuthCookie(TextBoxUser.Text, True)
                        Session("ADMIN") = TextBoxUser.Text

                        Response.Redirect("inicio.aspx")
                    Else
                        lblError.Visible = True
                        lblError.Text = "Error de ususario o contraseña ... "

                    End If
                End If
            End If
        Catch ex As Exception 'Se produce error en el uso del procedimiento
            lblError.Visible = True
                lblError.Text = "Error al intentar identificar al usuario: "
                lblError.Text &= ex.Message

            End Try




        End Sub

    End Class