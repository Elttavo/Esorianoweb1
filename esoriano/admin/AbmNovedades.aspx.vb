Imports ClassLibrary1
Imports System
    Imports System.Data
    Imports System.Data.SqlClient
    Imports System.Configuration
Public Class AbmNovedades
    Inherits System.Web.UI.Page
    Public IdNovedad As Integer
    Public copete As String
    Public detalle As String



    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Response.Redirect("AdministracionNovedades.aspx")
    End Sub


    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim param0 As String
        Dim param1 As String
        Dim param2 As String
        Dim param3 As String
        Dim param4 As String
        Dim param5 As String
        Dim param6 As String
        Dim param7 As String
        param0 = TextBox1.Text
        param1 = TextBox4.Text
        param2 = TextBox3.Text
        param3 = TextBox2.Text
        param4 = TextBox5.Text
        param5 = TextBox6.Text
        param6 = RadioButton1.Checked
        param7 = TxtDetalleVideo.Text
        ' Try
        If IdNovedad = 0 Then
            Novedad.Insertnovedades(2, param3, param2, param1, param4, param5, param6, param7)
            Response.Redirect("AdministracionNovedades.aspx")
        Else

            Novedad.Updatearticulos(param0, param1, param2, param3, param4, param5, param6, param7)

            Response.Redirect("AdministracionNovedades.aspx")

        End If
        'Catch ex As Exception

        ' MsgBox("error en carga de datos" & vbCrLf & ex.Message)
        ' End Try
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session.Item("ADMIN") Is Nothing Then
            Response.Redirect("default.aspx")
        End If
        IdNovedad = Request.QueryString("IdNovedad")
        Dim sqlcon As SqlConnection
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Try

            If IdNovedad <> 0 Then
                sqlcon = New SqlConnection(connectionString)
                Dim da As SqlDataAdapter = New SqlDataAdapter("SELECT NOV_FECHA,NOV_TITULO,NOV_COPETE,nov_id,nov_cuerpo,NOV_IMAGEN,nov_video,NOV_DETALLE FROM SorWeb.WEB_NOVEDADES where nov_id =" & IdNovedad, sqlcon)
                da.SelectCommand.CommandTimeout = 0
                da.SelectCommand.CommandType = CommandType.Text

                Dim ds As DataSet = New DataSet()

                da.Fill(ds)
                da.Dispose()
                TextBox1.Text = IdNovedad
                If Not IsPostBack Then
                    TextBox2.Text = ds.Tables(0).Rows(0).Item(1)
                    TextBox3.Text = ds.Tables(0).Rows(0).Item(2)
                    TextBox4.Text = ds.Tables(0).Rows(0).Item(4)
                    TextBox5.Text = ds.Tables(0).Rows(0).Item(0)
                    TextBox6.Text = ds.Tables(0).Rows(0).Item(5)
                    TxtDetalleVideo.Text = ds.Tables(0).Rows(0).Item(7)
                    RadioButton1.Checked = ds.Tables(0).Rows(0).Item(6)
                End If
                If RadioButton1.Checked = False Then
                    RadioButton2.Checked = True
                End If
                If RadioButton1.Checked = True Then
                    RadioButton2.Checked = False
                End If
                Button2.Visible = True
                Return
                sqlcon.Close()
            Else
                sqlcon = New SqlConnection(connectionString)
                Dim da As SqlDataAdapter = New SqlDataAdapter("SELECT max(nov_id) FROM SorWeb.WEB_NOVEDADES ", sqlcon)
                da.SelectCommand.CommandTimeout = 0
                da.SelectCommand.CommandType = CommandType.Text

                Dim ds As DataSet = New DataSet()

                da.Fill(ds)
                da.Dispose()
                ''VerificationAttribute este postback
                If Not IsPostBack Then
                    TextBox1.Text = CDbl(ds.Tables(0).Rows(0).Item(0)) + 1
                    TextBox2.Text = ""
                    TextBox3.Text = ""
                    TextBox4.Text = ""
                    TextBox5.Text = ""
                    TextBox6.Text = ""
                End If
                Button2.Visible = True
                sqlcon.Close()
            End If
        Catch ex As Exception

        End Try

        Return
    End Sub

End Class
