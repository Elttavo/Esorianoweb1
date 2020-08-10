Imports System.Data
Imports System.Data.SqlClient
Imports ClassLibrary1
Imports System.Web.Security
Imports System.Object
Imports System.IO
Imports System.Web.UI.WebControls.Calendar

Partial Class Descarga
    Inherits System.Web.UI.Page
    Public pathdescarga As String = System.Configuration.ConfigurationManager.AppSettings("ubicacion_archivos_importar")
    Dim tipo As String
    Dim flag1 As String

    Public Function ReactivarPedidoclientes() As String

        Dim f1 As New DateTime
        Dim f2 As New DateTime
        If TextBox2.Text = "" Then
            lblError.Visible = True
            lblError.Text = "Error ingrese datos "
            Return 0
            Exit Function
        Else
            lblError.Visible = False
            f1 = TextBox2.Text
        End If
        f2 = f1.AddDays(1)
        If TextBox1.Text = "" Then
            lblError.Visible = True
            lblError.Text = "Error ingrese datos "
            Return 0
            Exit Function
        Else
            lblError.Visible = False
            f1 = CDate(TextBox1.Text)
        End If
        f1 = CDate(TextBox1.Text)

        If Pedidosweb.Updatepedidos_Fechas(f1, f2) = 1 Then
            Label1.Text = "no se realizo la activacion de los pedido "
        Else
            Label1.Text = "activacion de pedido ok"
        End If

        Return 1
    End Function
    Public Function ReactivarPedidonumero() As String

        Dim cod1 As String
        TextBox2.Visible = False
        Calendar2.Visible = False
        Calendar1.Visible = False
        LinkButton1.Visible = False
        lblError.Visible = False
        cod1 = TextBox1.Text

        If Pedidosweb.Updatepedidos_numeros(cod1) = 1 Then
            Label1.Text = "no se realizo la activacion de los pedido "
        Else
            Label1.Text = "activacion de pedido ok"

        End If

        Return 1
    End Function

    Public Function ArchivoPlanoPedidosCliente(ByRef mPathExportacion As String) As String

        Const Prefijo As String = "Pedido"
        Const Extension As String = ".txt"
        Dim R As Short
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
        Dim xSep01cab As String '* 1
        Dim Clienteped As String '* 6
        Dim Pedidoped As String = 0 '* 8
        Dim Identificadorped As String '* 1
        Dim Ordenped As String '* 3
        Dim Articuloped As String '* 15
        Dim Cantidadped As String ' * 12
        Dim xSep01ped As String '* 1
        Dim Fillerped As String '* 332
        Dim Comentarioped As String
        Dim memo, texto, mArchivo1 As String
        Dim f1 As New DateTime
        Dim f2 As New DateTime
        Dim f3 As New DateTime

        Try
            'arma el nombre del archivo
            mArchivo1 = mPathExportacion & Prefijo & Extension

            If File.Exists(mArchivo1) Then
                File.Delete(mArchivo1)
            End If
            Dim fs As New FileInfo(mArchivo1)
            Using sw As New System.IO.StreamWriter(mArchivo1, True)

                If Trim(flag1) <> "exportarPA" Then
                    If TextBox1.Text = "" Then
                        TextBox1.Text = DateTime.Now.ToShortDateString()
                        lblError.Visible = True
                        lblError.Text = "Error ingrese datos "

                    Else
                        lblError.Visible = False
                        f3 = CDate(TextBox1.Text)
                    End If
                End If
                If Trim(flag1) = "exportarP" Then
                    If TextBox2.Text = "" Then
                        TextBox2.Text = DateTime.Now.ToShortDateString()
                        lblError.Visible = True
                        lblError.Text = "Error ingrese datos "

                    Else
                        f1 = CDate(TextBox2.Text)
                        f2 = f1.AddDays(1)
                    End If
                    RecTemp = DescargaAdmin.exportarP(form.FormatearFechaFS(f3), form.FormatearFechaFS(f2))

                ElseIf Trim(flag1) = "exportarPA" Then
                    RecTemp = DescargaAdmin.exportarPA()

                ElseIf trim(flag1) = "exportarPAF" Then
                    If TextBox2.Text = "" Then
                        TextBox2.Text = DateTime.Now.ToShortDateString()
                        lblError.Visible = True
                        lblError.Text = "Error ingrese datos "

                    Else
                        lblError.Visible = False
                        f1 = CDate(TextBox2.Text)
                    End If

                    f2 = f1.AddDays(1)
                    RecTemp = DescargaAdmin.exportarPAF(form.FormatearFechaFS(f3), form.FormatearFechaFS(f2))
                Else
                    Label1.Text = "error de flag  ........."

                End If

                'si no hay registros sale
                If RecTemp.HasRows Then
                    'comienza a generar el archvo
                    While RecTemp.Read()
                        'comienza por la cabecera
                        xSep01cab = " "
                        Clientecab = form.FormatearCadenaConCeros(RecTemp.Item("cli_codigo"), 6)
                        Pedidocab = form.FormatearCadenaConCeros(RecTemp.Item("ped_codigo"), 8)
                        CVTNOMBRE = RecTemp.Item("CVT_NOMBRE")
                        Identificadorcab = CStr(1)
                        Ordencab = form.FormatearCadenaConCeros(1, 3)
                        PedFechacab = form.FormatearFecha((RecTemp.Item("ped_fecha")))
                        NroSerieListacab = form.FormatearCadenaConCeros(0, 5)
                        FechaActStockcab = form.FormatearFecha(Today)
                        NroSerieStockcab = form.FormatearCadenaConCeros(0, 5)
                        FechaActListacab = form.FormatearFecha(Today)
                        texto = ""
                        texto = (Clientecab + xSep01cab + Pedidocab + xSep01cab + Identificadorcab + xSep01cab + Ordencab + xSep01cab + PedFechacab + xSep01cab + FechaActListacab + xSep01cab + NroSerieListacab + xSep01cab + FechaActStockcab + xSep01cab + NroSerieStockcab + xSep01cab + CVTNOMBRE)
                        sw.WriteLine(texto)

                        RecTemp1 = Pedidosweb.SelectpedidosLinea(Pedidocab)

                        R = 1

                        While RecTemp1.Read()
                            xSep01ped = " "
                            Clienteped = form.FormatearCadenaConCeros((Clientecab), 6)
                            Pedidoped = form.FormatearCadenaConCeros(RecTemp1.Item("ped_codigo"), 8)
                            Identificadorped = CStr(2)
                            Ordenped = form.FormatearCadenaConCeros(CStr(R), 3)
                            Articuloped = form.FormatearCadenaConEspaciosDer(RecTemp1.Item("art_codigo"), 15)
                            Cantidadped = form.FormatearCadenaConCeros(RecTemp1.Item("lnp_cant_ped"), 12)
                            texto = ""
                            texto = Clienteped & xSep01ped & Pedidoped & xSep01ped & Identificadorped & xSep01ped & Ordenped & xSep01ped & Articuloped & xSep01ped & Cantidadped & xSep01ped & Fillerped
                            sw.WriteLine(texto)
                            R = R + 1

                        End While
                        Dim Aux, Cadena As String
                        Dim Pos As Integer

                        memo = RecTemp.Item("PED_MEMO") & xSep01ped & RecTemp.Item("CVT_NOMBRE")

                        If Len(memo) > 0 Then

                            Identificadorped = CStr(3)
                            Ordenped = form.FormatearCadenaConCeros(1, 3)
                            Aux = RecTemp.Item("PED_MEMO") & xSep01ped & RecTemp.Item("CVT_NOMBRE")
                            Cadena = ""
                            Do While Len(Aux) > 0
                                Pos = InStr(1, Aux, Chr(13))
                                If Pos = 0 Then
                                    Cadena = Cadena & Aux
                                    Aux = ""
                                Else
                                    Cadena = Cadena & Mid(Aux, 1, Pos - 1) & " "
                                    Aux = Mid(Aux, Pos + 2)
                                End If
                            Loop
                            Comentarioped = Cadena
                            'escribe la linea
                            texto = Clienteped & xSep01ped & Pedidoped & xSep01ped & Identificadorped & xSep01ped & Ordenped & xSep01ped & Comentarioped & xSep01ped & Fillerped
                            sw.WriteLine(texto)

                        End If
                        Pedidosweb.Updatepedidos(form.FormatearCadenaConCeros(Pedidocab, 8))

                        RecTemp1.Close()
                        RecTemp1 = Nothing

                    End While
                    RecTemp.Close()

                    ArchivoPlanoPedidosCliente = Prefijo & Extension
                    sw.Close()
                    FileClose(0)
                    Label1.Text = "proceso terminado"

                Else
                    RecTemp = Nothing
                    RecTemp1 = Nothing
                    sw.Close()

                    ArchivoPlanoPedidosCliente = CStr(1)
                    Label1.Text = "no hay pedido para descargar"
                    FileClose(0)
                End If

            End Using

            Response.Clear()
            Response.Buffer = True
            Response.ContentType = "text/plain"
            Response.AddHeader("content-disposition", "attachment;filename= " & Prefijo & Extension)
            Response.WriteFile(mArchivo1)
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            Response.End()
            Exit Function
        Catch ex As Exception
            Select Case Err.Number
                Case Is = 76 : ArchivoPlanoPedidosCliente = CStr(2)
                Case Is = 53 : ArchivoPlanoPedidosCliente = CStr(3)
                Case Else : ArchivoPlanoPedidosCliente = Err.Description
            End Select

            FileClose(0)

            Label1.Text = "error en descarga "
        End Try


    End Function


    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click

        Calendar1.Visible = True
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click

        Calendar2.Visible = True
    End Sub


    Protected Sub Calendar1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Calendar1.SelectionChanged
        TextBox1.Text = Calendar1.SelectedDate.Date
        Calendar1.Visible = False
    End Sub

    Protected Sub Calendar2_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Calendar2.SelectionChanged
        TextBox2.Text = Calendar2.SelectedDate.Date
        Calendar2.Visible = False
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Trim(flag1) = "reactivarPedido" Then
            ReactivarPedidoclientes()
            Label1.Text = "se activaron los  pedido para descargar"
        ElseIf trim(flag1) = "reactivarPedidoN" Then
            ReactivarPedidonumero()
            Label1.Text = "se activo el pedido para descargar"
        Else
            ArchivoPlanoPedidosCliente(pathdescarga)
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            If (Request.QueryString(" flag ").ToString) <> Nothing Then
                flag1 = Trim(Request.QueryString(" flag ").ToString)
                If Session.Item("ADMIN") Is Nothing Then
                    Response.Redirect("default.aspx")
                End If
                If flag1 = "exportarPA" Then
                    Calendar1.Visible = False
                    Calendar2.Visible = False
                    LinkButton1.Visible = False
                    LinkButton2.Visible = False
                    TextBox1.Visible = False
                    TextBox2.Visible = False
                End If
                If flag1 = "reactivarPedidoN" Then
                    Calendar1.Visible = False
                    Calendar2.Visible = False
                    LinkButton1.Visible = False
                    LinkButton2.Visible = False
                    TextBox1.Visible = True
                    TextBox2.Visible = False
                    Label2.Visible = True
                End If
            End If
        Catch ex As Exception
            'Si hay alguna excepcion aqui se toma! ( Algun error)
        End Try
    End Sub

End Class
