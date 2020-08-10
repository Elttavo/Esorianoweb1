
Imports System.Data.SqlClient
Imports System.Collections
Imports System.Configuration
Imports ClassLibrary1

Partial Class ConsFactura
        Inherits System.Web.UI.Page
        Dim dTotal As Decimal = 0
        Dim codped As Integer
        Public tot As Decimal
        Dim cant As Decimal
        Public sProductID As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session.Item("USER") Is Nothing Then
            Response.Redirect("pedidos.aspx")
        End If
        Dim CLI_CODIGO As String = CType(Session.Item("USER"), String)
        GridView1.Visible = True
        LinkButtonVolverAtras.Visible = True
        Label1.Visible = True
        Label2.Visible = False
        Label3.Visible = False
        GridView1.DataSource = Factura.SelectFactura(CLI_CODIGO)
        GridView1.DataBind()
    End Sub
    Public Shared Function KeepActiveSession() As Boolean
            If HttpContext.Current.Session.IsNewSession Then
                Return False
            Else
                Return True
            End If
        End Function
        Public Shared Sub SessionAbandon()
            HttpContext.Current.Session.Abandon()
        End Sub

        Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound

            If (e.Row.RowType = DataControlRowType.DataRow) Then

            Dim Download As HyperLink = DirectCast(e.Row.FindControl("Download"), HyperLink)
            Dim Directorio As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "fac_numero"))
                Directorio = Directorio & " " & Convert.ToString(DataBinder.Eval(e.Row.DataItem, "COM_CODIGO"))
                If Directorio <> "" Then
                    Try
                        Download.NavigateUrl = (Convert.ToString("https://esorianosa.com.ar/web_Repositorio/factura/") & Directorio & ".pdf")
                    Catch ex As Exception

                    End Try
                End If
            End If

        End Sub

        Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Label1.Visible = False
        Label2.Visible = True
        Label3.Visible = True


        Dim row As GridViewRow = GridView1.SelectedRow
        codped = row.Cells(0).Text
        Label3.Text = codped
        GridView1.Visible = False

        LinkButtonVolverAtras.Visible = False

        End Sub


        Public Sub Alert(ByVal msg As String, ByRef P As Page)
            Dim strScript As String
            strScript = "<script language=javascript> alert('" + msg + ".');</script>"
            P.ClientScript.RegisterStartupScript(Me.GetType, "Alert", strScript)
        End Sub


    End Class


