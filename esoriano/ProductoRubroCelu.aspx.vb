Imports ClassLibrary1
Public Class ProductoRubroCelu
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session.Item("USER") Is Nothing Then
            Response.Redirect("pedidos.aspx")
        End If
        DataListRubros.DataSource = Rubros.GetRubros
        DataListRubros.DataBind()
    End Sub

End Class