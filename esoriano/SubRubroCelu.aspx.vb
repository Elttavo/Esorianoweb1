Imports ClassLibrary1
Public Class SubRubroCelu
    Inherits System.Web.UI.Page
    Public sProductID As String
    Public rubro As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session.Item("USER") Is Nothing Then
            Response.Redirect("pedidos.aspx")
        End If
        If Not IsPostBack Then


            Session(sProductID) = True
            rubro = Request.QueryString("Rub")
            If rubro <> "" Then

                datalistSubRubros.DataSource = Rubros.GetSubRubros(Integer.Parse(rubro))
                datalistSubRubros.DataBind()
                FormViewPath1.DataSource = Rubros.RubroSubFW(rubro)
                FormViewPath1.DataBind()
            End If
        End If
    End Sub

End Class