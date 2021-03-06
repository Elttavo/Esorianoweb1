﻿Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports ClassLibrary1
Public Class AdministracionNovedades
    Inherits System.Web.UI.Page

    Protected Sub grnovedades_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grnovedades.RowCommand

        Dim currentCommand As String = e.CommandName
        Dim currentRowIndex As Integer = Int32.Parse(e.CommandArgument.ToString())
        'Fila que invocó el comando 
        Dim intFila As Integer = Convert.ToInt32(e.CommandArgument.ToString())

        'Obtener DataKey de la fila 
        Label1.Text = "Command: " & currentCommand
        Label2.Text = currentRowIndex.ToString
        If e.CommandName = "Eliminar" Then
            Label4.Text = (grnovedades.Rows(CInt(Label2.Text)).Cells(7).Text)
            Novedad.Deletenovedades_linea(Label4.Text)
        ElseIf e.CommandName = "Editar" Then
            Label4.Text = (grnovedades.Rows(CInt(Label2.Text)).Cells(7).Text)
            'Dirigire a la página editar 
            Response.Redirect("ABMNovedades.aspx?IdNovedad=" & Label4.Text)
        ElseIf e.CommandName = "Nuevo" Then

            Response.Redirect("ABMNovedades.aspx?IdNovedad=0 ")
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session.Item("ADMIN") Is Nothing Then
            Response.Redirect("default.aspx")
        End If
    End Sub

    Protected Sub grnovedades_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        grnovedades.PageIndex = e.NewPageIndex
        grnovedades.DataSource = Novedad.Selectnovedades_todas()
        grnovedades.DataBind()
    End Sub

    Private Sub AdministracionNovedades_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
        Try

            grnovedades.DataSource = Novedad.Selectnovedades_todas()
            grnovedades.DataBind()
            grnovedades.Columns("6").HeaderText = "Eliminar"
            grnovedades.Columns("0").HeaderText = "Editar"
            grnovedades.Columns("1").HeaderText = "Nuevo"
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
