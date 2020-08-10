Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections
Imports System.Configuration
Imports ClassLibrary1
Public Class ConPedidoGen
    Inherits System.Web.UI.Page


    Public SEG_USUARIO As String
    Dim dTotal As Decimal = 0
    Dim codped As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session.Item("USER") Is Nothing Then
            Response.Redirect("pedidos.aspx")
        End If
        Dim SEG_USUARIO As String = CType(Session.Item("USER"), String)
        GridView1.DataSource = Pedidosweb.SelectVisPedidos(SEG_USUARIO)
        GridView1.DataBind()
        GridView1.Visible = True
        LinkButtonVolverAtras.Visible = True
        Label1.Visible = True
        Label2.Visible = False
        Label3.Visible = False
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

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand

        If e.CommandName = "Page" Or e.CommandName = "Select" Then
        Else
            Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)

            codped = CType(row.Cells(0), DataControlFieldCell).Text

            Dim ds As New DataSet()
            Dim ds1 As New DataSet

            ds1 = Pedidosweb.SelectpedFechaMemo(codped)
            ds = Pedidosweb.Selectpedcliente(codped)
            Dim str As New StringBuilder()
            Dim k As Integer
            For k = 0 To ds1.Tables(0).Rows.Count - 1
                Dim l As Integer
                For l = 0 To ds1.Tables(0).Columns.Count - 1
                    str.Append(ds1.Tables(0).Rows(k)(l).ToString() & "  ")
                Next l
                str.AppendLine()
            Next k
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                Dim j As Integer
                For j = 0 To ds.Tables(0).Columns.Count - 1
                    str.Append(ds.Tables(0).Rows(i)(j).ToString() & "  ")
                Next j
                str.AppendLine()
            Next i

            Response.Clear()
            Response.AddHeader("content-disposition", "attachment;filename=FileName.txt")
            Response.Charset = "UTF-8"
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            Response.ContentType = "application/vnd.text"

            Dim stringWrite As New System.IO.StringWriter()
            Dim htmlWrite = New HtmlTextWriter(stringWrite)

            Response.Write(str.ToString())
            Response.End()

        End If
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(4).Text = "CANTIDAD: " + GridView1.Rows.Count.ToString() + "&nbsp;&nbsp;"
            'e.Row.Cells(4).HorizontalAlign = HorizontalAlign.Right
            'e.Row.Font.Bold = True
            e.Row.CssClass = "FooterGridView"
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
        GridView2.Visible = True
        GridView3.Visible = True
        LinkButtonVolverAtras.Visible = False
        LinkButtonSelecPedidos.Visible = True
        imgPrint.Visible = True
    End Sub

    Protected Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            If (DataBinder.Eval(e.Row.DataItem, "TotalLinea")).ToString <> "" Then
                dTotal += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TotalLinea"))
            End If
        End If

        If e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(4).Text = "Total:"
            e.Row.Cells(5).Text = dTotal.ToString("c")
            e.Row.Cells(5).HorizontalAlign = HorizontalAlign.Left
            e.Row.Font.Bold = True
        End If
    End Sub

    Protected Sub LinkButtonSelecPedidos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButtonSelecPedidos.Click
        LinkButtonVolverAtras.Visible = True
        LinkButtonSelecPedidos.Visible = False
        imgPrint.Visible = False
        GridView1.Visible = True
        GridView2.Visible = False
        GridView3.Visible = False
    End Sub

End Class