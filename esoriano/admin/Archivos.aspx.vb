Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Imports System.Text.Encoding
Imports ClassLibrary1
Public Class Archivos
    Inherits System.Web.UI.Page
    Public pathIMPORT As String = System.Configuration.ConfigurationManager.AppSettings("ubicacion_archivos_importar")

    Protected Sub crear_indice()

        Dim RecTemp As SqlDataReader
        'Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString)
        'Dim mCadena = New SqlCommand()
        Dim i As Integer

        Try
            'mCadena.CommandText = ("select * from SorWeb.STK_ARTICULOS  order by SorWeb.STK_ARTICULOS.ART_CODIGO ")
            'mCadena.Connection = cn
            'cn.Open()
            'RecTemp = mCadena.ExecuteReader()
            RecTemp = Articulo.selectArti_indice
            'si no hay registros sale
            If RecTemp.HasRows Then
                i = 0
                'comienza a generar el archvo
                While RecTemp.Read()
                    'comienza por la cabecera

                    Articulo.Updatearticulos(RecTemp.Item("art_codigo"), i)
                    i = i + 1
                End While
                RecTemp.Close()
                'cn.Close()
            End If
            RecTemp = Nothing
        Catch ex As Exception
            Label1.Text = "ERROR EN CARGA... "
        End Try

    End Sub
    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Label1.Text = Administracion.insertar(1, pathIMPORT + "STOCK.TXT", "Articulos")

    End Sub
    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
        Label1.Text = Administracion.insertar(2, pathIMPORT + "RUBROS.TXT", "Rubros")
        'realizar(2, pathIMPORT + "RUBROS.TXT", "Rubros")
    End Sub
    Protected Sub ImageButton3_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton3.Click
        Label1.Text = Administracion.insertar(3, pathIMPORT + "SUBRUBRO.TXT", "subrubros")

    End Sub
    Protected Sub ImageButton4_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton4.Click
        Label1.Text = Administracion.insertar(4, pathIMPORT + "UNIDAD.TXT", "Unidad")

    End Sub
    Protected Sub ImageButton5_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton5.Click
        Label1.Text = Administracion.insertar(5, pathIMPORT + "LISTA.TXT", "Listas")

    End Sub
    Protected Sub ImageButton6_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton6.Click
        Label1.Text = Administracion.insertar(6, pathIMPORT + "CLIENTE.TXT", "Cliente/Seg")

    End Sub
    Protected Sub ImageButton8_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton8.Click
        Label1.Text = Administracion.insertar(8, pathIMPORT + "vendedores.TXT", "Vendedores")

    End Sub

    Protected Sub ImageButton9_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton9.Click
        Label1.Text = Administracion.insertar(9, pathIMPORT + "facturas.TXT", "Factura")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session.Item("ADMIN") Is Nothing Then
            Response.Redirect("default.aspx")
        End If

    End Sub
    Protected Function quitaEntities(ByVal texto As String) As String
        texto = Replace(texto, "¡", "&iexcl;")
        texto = Replace(texto, "¿", "&iquest;")
        texto = Replace(texto, "á", "&aacute;")
        texto = Replace(texto, "é", "&eacute;")
        texto = Replace(texto, "í", "&iacute;")
        texto = Replace(texto, "ó", "&oacute;")
        texto = Replace(texto, "ú", "&uacute;")
        texto = Replace(texto, "ñ", "&ntilde")
        texto = Replace(texto, "ñ", "U+00F1")
        texto = Replace(texto, "Ç", "&ccedil;")
        texto = Replace(texto, "Á", "&Aacute;")
        texto = Replace(texto, "É", "&Eacute;")
        texto = Replace(texto, "Í", "&Iacute;")
        texto = Replace(texto, "Ó", "&Oacute;")
        texto = Replace(texto, "Ú", "&Uacute;")
        texto = Replace(texto, "Ñ", "&Ntilde;")
        texto = Replace(texto, "Ç", "&Ccedil;")
        texto = Replace(texto, "à", "&agrave;")
        texto = Replace(texto, "è", "&egrave;")
        texto = Replace(texto, "ì", "&igrave;")
        texto = Replace(texto, "ò", "&ograve;")
        texto = Replace(texto, "ù", "&ugrave;")
        texto = Replace(texto, "À", "&Agrave;")
        texto = Replace(texto, "È", "&Egrave;")
        texto = Replace(texto, "Ì", "&Igrave;")
        texto = Replace(texto, "Ò", "&Ograve;")
        texto = Replace(texto, "Ù", "&Ugrave;")
        texto = Replace(texto, "ä", "&auml;")
        texto = Replace(texto, "ë", "&euml;")
        texto = Replace(texto, "ï", "&iuml;")
        texto = Replace(texto, "ö", "&ouml")
        texto = Replace(texto, "ö", "U+00F6")
        texto = Replace(texto, "ü", "&uuml;")
        texto = Replace(texto, "Ä", "&Auml;")
        texto = Replace(texto, "Ë", "&Euml;")
        texto = Replace(texto, "Ï", "&Iuml;")
        texto = Replace(texto, "Ö", "&Ouml;")
        texto = Replace(texto, "Ü", "&Uuml;")
        texto = Replace(texto, "â", "&acirc;")
        texto = Replace(texto, "ê", "&ecirc;")
        texto = Replace(texto, "î", "&icirc;")
        texto = Replace(texto, "ô", "&ocirc;")
        texto = Replace(texto, "û", "&ucirc;")
        texto = Replace(texto, "Â", "&Acirc;")
        texto = Replace(texto, "Ê", "&Ecirc;")
        texto = Replace(texto, "Î", "&Icirc;")
        texto = Replace(texto, "Ô", "&Ocirc;")
        texto = Replace(texto, "Û", "&Ucirc;")
        texto = Replace(texto, "K�LN", "KÖLN")
        texto = Replace(texto, "PR�LL", "PRÖLL")
        texto = Replace(texto, "alba�il", "albañil")
        texto = Replace(texto, "ca�o", "caño")
        texto = Replace(texto, "ALBA�IL", "ALBAÑIL")
        texto = Replace(texto, "p/CA�O", "p/CAÑO")
        texto = Replace(texto, "P/CA�O", "P/CAÑO")
        texto = Replace(texto, "CA�A", "CAÑA")
        texto = Replace(texto, "GUADA�AS", "GUADAÑAS")
        texto = Replace(texto, "�", "º")
        quitaEntities = texto
    End Function



End Class