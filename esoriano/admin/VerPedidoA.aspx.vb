Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO
Imports ClassLibrary1
Public Class VerPedidoA
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Try

            If Session.Item("ADMIN") Is Nothing Then
                Response.Redirect("default.aspx")
            End If
            GridView1.DataSource = Pedidosweb.SelectPedidosActivos
            GridView1.DataBind()
            GridView1.Font.Size = FontSize.Large
        Catch ex As Exception
            'Si hay alguna excepcion aqui se toma! ( Algun error)
        End Try

    End Sub


    Public pathdescarga As String = System.Configuration.ConfigurationManager.AppSettings("ubicacion_archivos_importar")
    Dim tipo As String
    Dim flag1 As String
    Dim prFont As New Font("Calibri", 9, FontStyle.Regular)


    Public Function ArchivoPlanoPedidosCliente(ByRef mPathExportacion As String) As String

        Const Prefijo As String = "Pedido"
        Const Extension As String = ".txt"
        Dim RecTemp As SqlDataReader
        Dim RecTemp1 As SqlDataReader
        Dim form As New Class1
        Dim Clientecab As String '* 6
        Dim Pedidocab As String  '* 8
        Dim CVTNOMBRE As String '*50
        Dim Identificadorcab As String '* 1
        Dim Ordencab As String '* 3
        Dim PedFechacab As String '* 10
        Dim FechaActListacab As String '* 10
        Dim NroSerieListacab As String '* 5
        Dim FechaActStockcab As String '* 10
        Dim NroSerieStockcab As String '* 5
        Dim xSep01cab As String = ";" '* 1
        Dim Pedidoped As String = 0 '* 8
        Dim Articuloped As String '* 15
        Dim Cantidadped As String ' * 12
        Dim Preciopedido As String ' * 12
        Dim xSep01ped As String = " " '* 1
        Dim artNombre As String '* 50
        Dim memo, texto, mArchivo1 As String
        Dim mCadena = New SqlCommand()
        Dim mCadena1 = New SqlCommand()
        Dim f1 As New DateTime
        Dim f2 As New DateTime
        Dim f3 As New DateTime
        Try


            'arma el nombre del archivo
            mArchivo1 = mPathExportacion & Prefijo & Extension

            If File.Exists(mArchivo1) Then
                File.Delete(mArchivo1)
                'Response.End()
            End If
            Dim fs As New FileInfo(mArchivo1)
            Using sw As New System.IO.StreamWriter(mArchivo1, True)


                RecTemp = Pedidosweb.SelectPedidosActivosR()
                'si no hay registros sale
                If RecTemp.HasRows Then
                    'comienza a generar el archvo
                    While RecTemp.Read()
                        'comienza por la cabecera

                        Clientecab = form.FormatearCadenaConCeros(RecTemp.Item("cli_codigo"), 6)
                        Pedidocab = form.FormatearCadenaConCeros(RecTemp.Item("ped_codigo"), 8)
                        Identificadorcab = CStr(1)
                        Ordencab = form.FormatearCadenaConCeros(1, 3)
                        PedFechacab = form.FormatearFecha((RecTemp.Item("ped_fecha")))
                        NroSerieListacab = form.FormatearCadenaConCeros(0, 5)
                        FechaActStockcab = form.FormatearFecha(Today)
                        NroSerieStockcab = form.FormatearCadenaConCeros(0, 5)
                        FechaActListacab = form.FormatearFecha(Today)
                        Articuloped = form.FormatearCadenaConEspaciosDer(RecTemp.Item("art_codigo"), 15)
                        artNombre = (RecTemp.Item("art_nombre"))
                        Cantidadped = form.FormatearCadenaConCeros(Replace(RecTemp.Item("lnp_cant_ped"), ".", ","), 12)
                        Preciopedido = form.FormatearCadenaConCeros(Replace(RecTemp.Item("LNP_PRECIO"), ".", ","), 12)
                        CVTNOMBRE = RecTemp.Item("CVT_NOMBRE")
                        memo = RecTemp.Item("MEMO")
                        texto = ""
                        texto = (Clientecab + xSep01cab + Pedidocab + xSep01cab + artNombre + xSep01cab + Articuloped + xSep01cab + Cantidadped + xSep01cab + Preciopedido + xSep01cab + CVTNOMBRE + xSep01cab + memo + xSep01cab + PedFechacab)
                        sw.WriteLine(texto)


                    End While
                    RecTemp.Close()
                    ArchivoPlanoPedidosCliente = Prefijo & Extension
                    sw.Close()
                    Response.Buffer = True
                    Response.ContentType = "text/plain"
                    Response.AddHeader("content-disposition", "attachment;filename= " & Prefijo & Extension)
                    Response.WriteFile(mArchivo1)
                    Response.Cache.SetCacheability(HttpCacheability.NoCache)


                    Label1.Text = " proceso terminado"

                    FileClose(0)
                    Response.End()
                    Exit Function
                Else
                    RecTemp = Nothing
                    RecTemp1 = Nothing
                    sw.Close()

                    ArchivoPlanoPedidosCliente = CStr(1)
                    Label1.Text = "no hay pedido para descargar"
                    FileClose(0)
                    Exit Function
                End If
            End Using
        Catch ex As Exception
            Select Case Err.Number
                Case Is = 76 : ArchivoPlanoPedidosCliente = CStr(2)
                Case Is = 53 : ArchivoPlanoPedidosCliente = CStr(3)
                Case Else : ArchivoPlanoPedidosCliente = Err.Description
            End Select

            FileClose(0)


        End Try

    End Function



    Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click
        ArchivoPlanoPedidosCliente(pathdescarga)
    End Sub

    Protected Sub ImageButton2_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton2.Click
        Response.Redirect("inicio.aspx")
    End Sub

    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridView1.PageIndex = e.NewPageIndex
        GridView1.DataSource = Pedidosweb.SelectPedidosActivos
        GridView1.DataBind()
    End Sub


End Class