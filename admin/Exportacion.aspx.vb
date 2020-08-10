
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections
Imports System.Configuration
Imports System.IO
Imports System
Imports System.Text
Imports ClassLibrary1

Partial Class Exportacion
        Inherits System.Web.UI.Page
        Public tipo As Integer

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Session.Item("ADMIN") Is Nothing Then
                Response.Redirect("default.aspx")
            End If
        End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click

        Response.Redirect("descarga.aspx? flag = reactivarPedido ")

    End Sub

    Protected Sub ImageButton3_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton3.Click


        Response.Redirect("descarga.aspx? flag = exportarP ")
        'Response.Redirect("descarga.aspx")

    End Sub

        Protected Sub ImageButton4_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton4.Click

        Response.Redirect("descarga.aspx? flag = exportarPA ")
        'Response.Redirect("descarga.aspx")
    End Sub

    Protected Sub ImageButton5_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton5.Click
        Response.Redirect("descarga.aspx? flag = exportarPAF")
    End Sub

    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click

        Response.Redirect("descarga.aspx? flag = reactivarPedidoN ")
    End Sub


End Class
