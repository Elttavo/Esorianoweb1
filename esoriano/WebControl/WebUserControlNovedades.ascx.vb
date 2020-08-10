Imports ClassLibrary1
Public Class WebUserControlNovedades
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        DataListNov.DataSource = Novedad.Selectnovedades_2L
        DataListNov.DataBind()
    End Sub

End Class