Imports ClassLibrary1
Public Class DetalleNovedadAgrandada
    Inherits System.Web.UI.Page
    Dim idnovedad As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        idnovedad = Request.QueryString("NOV_ID")
        ListViewVideo.DataSource = Novedad.Selectnovedades_4linea(idnovedad)
        ListViewVideo.DataBind()
    End Sub

End Class