Public Class profolio
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "all", "filterSelection('all');", True)
        End If

    End Sub

    Protected Sub btn_soriano_Click(sender As Object, e As EventArgs)
        ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "all", "filterSelection('all');", True)
    End Sub

    Protected Sub btn_Proll_Click(sender As Object, e As EventArgs)
        ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "all", "filterSelection('Proll');", True)
    End Sub

    Protected Sub btn_Rhein_Click(sender As Object, e As EventArgs)
        ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "all", "filterSelection('Rhein');", True)

    End Sub

    Protected Sub btn_Koln_Click(sender As Object, e As EventArgs)
        ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "all", "filterSelection('Koln');", True)
    End Sub

    Protected Sub btn_PlenaLimas_Click(sender As Object, e As EventArgs)
        ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "all", "filterSelection('PlenaLimas');", True)
    End Sub

    Protected Sub btm_Essamet_Click(sender As Object, e As EventArgs) Handles btm_Essamet.Click
        ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "all", "filterSelection('Essamet');", True)
    End Sub

    Protected Sub btn_Metz_Click(sender As Object, e As EventArgs)
        ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "all", "filterSelection('Metz');", True)
    End Sub
End Class