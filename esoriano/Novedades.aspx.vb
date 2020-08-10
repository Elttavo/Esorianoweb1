
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports ClassLibrary1
Partial Class Novedades
    Inherits System.Web.UI.Page
    Dim NOV_ID, idnovedad As String

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Response.Redirect("NovedadesTodas.aspx")
    End Sub

    Private Sub novedades_Load(sender As Object, e As EventArgs) Handles Me.Load

        idnovedad = Request.QueryString("NOV_ID")
            FormView1.DataSource = Novedad.Selectnovedades_4linea(idnovedad)
            FormView1.DataBind()


    End Sub
    Public Function ProcessMyDataItem(ByVal myValue As Object) As String
            Try
                If myValue Is Nothing Then
                    Return 0

                Else
                    Novedad.strNOV_VIDEO = myValue

                End If
            Catch ex As Exception
                Return 0

            End Try
            Return 0

        End Function

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If (Novedad.strNOV_VIDEO) = True Then
            Response.Redirect("video.aspx?NOV_ID=" + NOV_ID)
        Else
            Response.Redirect("DetalleNovedadAgrandada.aspx?NOV_ID=" + NOV_ID)
        End If

    End Sub

    Protected Sub FormView1_DataBound(sender As Object, e As EventArgs)

        Dim DataRow As DataRowView = (FormView1.DataItem)
        Dim lbl As Label = CType(FormView1.FindControl("lblCode"), Label)
        NOV_ID = lbl.Text
    End Sub
End Class
