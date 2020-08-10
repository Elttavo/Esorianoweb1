Public Class Inicio

    Inherits System.Web.UI.Page


    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session.Item("ADMIN") Is Nothing Then
            Response.Redirect("default.aspx")
        End If
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Response.Redirect("archivos.aspx")

    End Sub

    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
        Response.Redirect("exportacion.aspx")
    End Sub

    Protected Sub ImageButton3_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton3.Click
        Response.Redirect("AdministracionNovedades.aspx")
    End Sub

    Protected Sub ImageButton7_Click(sender As Object, e As ImageClickEventArgs)
        Response.Redirect("VerPedidoA.aspx")
    End Sub
End Class