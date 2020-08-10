Imports System.Data.SqlClient
Imports ClassLibrary1
Public Class NovedadesTodas
    Inherits System.Web.UI.Page

    Protected Sub grnovedades_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grnovedades.RowCommand

        Dim currentCommand As String = e.CommandName
        Dim currentRowIndex As Integer = Int32.Parse(e.CommandArgument.ToString())
        'Fila que invocó el comando 
        Dim intFila As Integer = Convert.ToInt32(e.CommandArgument.ToString())

        'Obtener DataKey de la fila 
        Label1.Text = "Command: " & currentCommand
        Label2.Text = currentRowIndex.ToString
        If e.CommandName = "Ver" Then

            Label4.Text = (grnovedades.Rows(CInt(Label2.Text)).Cells(5).Text)
            'Dirigire a la página editar 
            Response.Redirect("Novedades.aspx?Nov_id=" & Label4.Text)
        End If
    End Sub

    Protected Sub grnovedades_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grnovedades.RowDataBound

        Try
            If e.Row.RowType <> ListItemType.Header And e.Row.RowType <> ListItemType.Footer Then
                e.Row.Cells(1).Attributes.Add("onClick", "javascript:return ConfirmDel();")
            End If
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub grnovedades_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grnovedades.SelectedIndexChanged
        Dim gvRow As GridViewRow = CType(CType(sender, Control).Parent.Parent, GridViewRow)

        Dim index As Integer = gvRow.RowIndex
        Label1.Text = index

    End Sub

    Protected Sub grnovedades_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        grnovedades.PageIndex = e.NewPageIndex
        grnovedades.DataSource = Novedad.Selectnovedades_todas
        grnovedades.DataBind()
    End Sub

    Private Sub grnovedades_PreRender(sender As Object, e As EventArgs) Handles grnovedades.PreRender

        Try

            'LinkButton1.Attributes.Add("onclick", "return confirm('Seguro?');")
            Dim oCargaGrid As New NovedadesTodas()
            Dim iIdEmp As Integer = Convert.ToInt32(txtemp.Text = String.Empty)

            grnovedades.DataSource = Novedad.Selectnovedades_todas
            grnovedades.DataBind()

            grnovedades.Columns("0").HeaderText = "Ver"
            grnovedades.DataBind()
            grnovedades.HeaderRow.Cells(2).Text = "Fecha"
            grnovedades.HeaderRow.Cells(3).Text = "Titulo"
            grnovedades.HeaderRow.Cells(4).Text = "Copete"
            grnovedades.HeaderRow.Cells(5).Text = "Detalle"


        Catch ex As Exception
            Dim sScript As String = " "
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Error Grid", sScript)

        End Try
    End Sub

End Class