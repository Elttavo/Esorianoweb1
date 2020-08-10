Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.DataRowView
Imports System.DBNull
Imports System.IO
Imports System.Text
Imports System.Text.Encoding
Imports System.Configuration

Public Class Administracion
    Public Shared Function carga(ByVal num As Integer, ByVal path As String, ByVal nombre As String) As String


        Dim I As Integer
        Dim vTexto As String = ""

        Dim vKeywords() As String
        Dim vValores() As String
        Dim fin As Integer
        Dim vFile As New FileInfo(path)
        Dim vLector As New StreamReader(path, Encoding.ASCII)
        carga = ""
        Try

            Select Case num 'UCase(Archivo)

                Case Is = 1
                    If vFile.Exists Then
                        vLector = vFile.OpenText()

                        vTexto = Administracion.quitaEntities((vLector.ReadToEnd))

                        vKeywords = Split(vTexto, vbCrLf)

                        fin = vKeywords.Length

                        Articulo.DeleteArticulo(0)
                        For I = 1 To fin - 2
                            vValores = vKeywords(I).Split(CChar(Chr(9)))
                            Articulo.InsertArticulos(vValores(0), vValores(1), vValores(2), vValores(3), vValores(4), vValores(5), vValores(6), vValores(7), vValores(8), vValores(9))
                        Next
                        vLector.Dispose()
                        vLector.Close()
                    Else
                        GoTo salir
                    End If

                Case Is = 2
                    If vFile.Exists Then
                        vLector = vFile.OpenText()
                        vTexto = Administracion.quitaEntities(vLector.ReadToEnd)
                        vKeywords = Split(vTexto, vbCrLf)
                        fin = vKeywords.Length
                        rubros.DeleteRubro(0)
                        For I = 1 To fin - 2
                            vValores = vKeywords(I).Split(CChar(Chr(9)))
                            rubros.InsertRubros(vValores(0), vValores(1), vValores(2), vValores(3))
                        Next
                        vLector.Dispose()
                        vLector.Close()
                    Else
                        GoTo salir
                    End If
                Case Is = 3
                    If vFile.Exists Then
                        vLector = vFile.OpenText()
                        vTexto = Administracion.quitaEntities(vLector.ReadToEnd)
                        vKeywords = Split(vTexto, vbCrLf)
                        fin = vKeywords.Length
                        Subrubros.DeleteSUBRubro(0)
                        For I = 1 To fin - 2
                            vValores = vKeywords(I).Split(CChar(Chr(9)))
                            Subrubros.InsertSUBRubros(vValores(0), vValores(1), vValores(2), vValores(3))
                        Next
                        vLector.Dispose()
                        vLector.Close()
                    Else
                        GoTo salir
                    End If
                Case Is = 4
                    If vFile.Exists Then
                        vLector = vFile.OpenText()
                        vTexto = Administracion.quitaEntities(vLector.ReadToEnd)
                        vKeywords = Split(vTexto, vbCrLf)
                        fin = vKeywords.Length
                        Unidad.DeleteUnidad(0)
                        For I = 1 To fin - 2
                            vValores = vKeywords(I).Split(CChar(Chr(9)))
                            Unidad.InsertUnidad(vValores(0), vValores(1), vValores(2))
                        Next
                        vLector.Dispose()
                        vLector.Close()
                    Else
                        GoTo salir
                    End If
                Case Is = 5
                    If vFile.Exists Then
                        vLector = vFile.OpenText()
                        vTexto = Administracion.quitaEntities(vLector.ReadToEnd)
                        vKeywords = Split(vTexto, vbCrLf)
                        fin = vKeywords.Length
                        Lista.DeleteLista(0)
                        For I = 1 To fin - 2
                            vValores = vKeywords(I).Split(CChar(Chr(9)))
                            Lista.InsertLista(vValores(0), vValores(1), vValores(2), vValores(3), vValores(4), vValores(5), vValores(6), vValores(7), vValores(8))
                        Next
                        vLector.Dispose()
                        vLector.Close()
                    Else
                        GoTo salir
                    End If

                Case Is = 6
                    If vFile.Exists Then
                        vLector = vFile.OpenText()
                        vTexto = Administracion.quitaEntities(vLector.ReadToEnd)
                        vKeywords = Split(vTexto, vbCrLf)
                        fin = vKeywords.Length
                        Cliente.DeleteCliente(0)
                        For I = 1 To fin - 2
                            vValores = vKeywords(I).Split(CChar(Chr(9)))
                            Cliente.InsertCliente(vValores(0), vValores(1), vValores(2), vValores(3), vValores(4), vValores(5), vValores(6))
                        Next
                        vLector.Dispose()
                        vLector.Close()
                    Else
                        GoTo salir
                    End If

            End Select
            Administracion.crear_indice()
            carga = " CARGA OK ... " & nombre
            Exit Function
salir:
            carga = " Sin archivo txtpara la CARGA... " & nombre
            Exit Function

        Catch ex As Exception
            carga = " ERROR EN CARGA... " & nombre
        End Try


    End Function
    Public Shared Function crear_indice() As Integer

        Dim RecTemp As SqlDataReader
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString)
        Dim mCadena = New SqlCommand()
        Dim i As Integer


        Try

            mCadena.CommandText = ("select * from SorWeb.STK_ARTICULOS  order by SorWeb.STK_ARTICULOS.ART_CODIGO ")


            mCadena.Connection = cn
            cn.Open()
            RecTemp = mCadena.ExecuteReader()
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
                cn.Close()
            End If


            RecTemp = Nothing
            Return 0
        Catch ex As Exception
            Return 1
        End Try

    End Function

    Public Shared Function quitaEntities(ByVal texto As String) As String
        texto = Replace(texto, "¡", "&iexcl;")
        texto = Replace(texto, "¿", "&iquest;") '<- Esta no funciona

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
    Public Shared Function insertar(ByVal num As Integer, ByVal path As String, ByVal nombre As String) As String

        Dim I As Integer
        Dim vTexto As String = ""
        Dim vKeywords() As String
        Dim vValores() As String
        Dim fin As Integer
        Dim vFile As New FileInfo(path)
        Dim vLector As New StreamReader(path, Encoding.ASCII)

        Try

            Select Case num
                Case Is = 1
                    If vFile.Exists Then
                        vLector = vFile.OpenText()
                        vTexto = quitaEntities((vLector.ReadToEnd))
                        vKeywords = Split(vTexto, vbCrLf)
                        fin = vKeywords.Length
                        Articulo.DeleteArticulo(0)
                        For I = 1 To fin - 2
                            vValores = vKeywords(I).Split(CChar(Chr(9)))
                            Articulo.InsertArticulos(vValores(0), vValores(1), vValores(2), vValores(3), vValores(4), vValores(5), vValores(6), vValores(7), vValores(8), vValores(9))
                        Next
                        vLector.Close()
                    Else
                        GoTo salir
                    End If
                    crear_indice()
                Case Is = 2
                    If vFile.Exists Then
                        vLector = vFile.OpenText()
                        vTexto = quitaEntities(vLector.ReadToEnd)
                        vKeywords = Split(vTexto, vbCrLf)
                        fin = vKeywords.Length
                        rubros.DeleteRubro(0)
                        For I = 1 To fin - 2
                            vValores = vKeywords(I).Split(CChar(Chr(9)))
                            rubros.InsertRubros(vValores(0), vValores(1), vValores(2), vValores(3))
                        Next
                        vLector.Close()
                    Else
                        GoTo salir
                    End If
                Case Is = 3
                    If vFile.Exists Then
                        vLector = vFile.OpenText()
                        vTexto = quitaEntities(vLector.ReadToEnd)
                        vKeywords = Split(vTexto, vbCrLf)
                        fin = vKeywords.Length
                        Subrubros.DeleteSUBRubro(0)
                        For I = 1 To fin - 2
                            vValores = vKeywords(I).Split(CChar(Chr(9)))
                            Subrubros.InsertSUBRubros(vValores(0), vValores(1), vValores(2), vValores(3))
                        Next
                        vLector.Close()
                    Else
                        GoTo salir
                    End If
                Case Is = 4
                    If vFile.Exists Then
                        vLector = vFile.OpenText()
                        vTexto = quitaEntities(vLector.ReadToEnd)
                        vKeywords = Split(vTexto, vbCrLf)
                        fin = vKeywords.Length
                        Unidad.DeleteUnidad(0)
                        For I = 1 To fin - 2
                            vValores = vKeywords(I).Split(CChar(Chr(9)))
                            Unidad.InsertUnidad(vValores(0), vValores(1), vValores(2))
                        Next
                        vLector.Close()
                    Else
                        GoTo salir
                    End If
                Case Is = 5
                    If vFile.Exists Then
                        vLector = vFile.OpenText()
                        vTexto = quitaEntities(vLector.ReadToEnd)
                        vKeywords = Split(vTexto, vbCrLf)
                        fin = vKeywords.Length
                        Lista.DeleteLista(0)
                        For I = 1 To fin - 2
                            vValores = vKeywords(I).Split(CChar(Chr(9)))
                            Lista.InsertLista(vValores(0), vValores(1), vValores(2), vValores(3), vValores(4), vValores(5), vValores(6), vValores(7), vValores(8))
                        Next
                        vLector.Close()
                    Else
                        GoTo salir
                    End If

                Case Is = 6
                    If vFile.Exists Then
                        vLector = vFile.OpenText()
                        vTexto = quitaEntities(vLector.ReadToEnd)
                        vKeywords = Split(vTexto, vbCrLf)
                        fin = vKeywords.Length
                        Cliente.DeleteCliente(0)
                        For I = 1 To fin - 2
                            vValores = vKeywords(I).Split(CChar(Chr(9)))
                            Cliente.InsertCliente(vValores(0), vValores(1), vValores(2), vValores(3), vValores(4), vValores(5), vValores(6))
                        Next
                        vLector.Close()
                    Else
                        GoTo salir
                    End If
                Case Is = 8
                    If vFile.Exists Then
                        vLector = vFile.OpenText()
                        vTexto = quitaEntities(vLector.ReadToEnd)
                        vKeywords = Split(vTexto, vbCrLf)
                        fin = vKeywords.Length
                        Vendedores.DeleteVendedores(0)
                        For I = 1 To fin - 2
                            vValores = vKeywords(I).Split(CChar(Chr(9)))

                            Vendedores.InsertVendedores(vValores(0), vValores(1), vValores(2), vValores(3))
                        Next
                        vLector.Close()
                    Else
                        GoTo salir
                    End If
                Case Is = 9
                    If vFile.Exists Then
                        vLector = vFile.OpenText()
                        vTexto = quitaEntities(vLector.ReadToEnd)
                        vKeywords = Split(vTexto, vbCrLf)
                        fin = vKeywords.Length
                        Factura.DeleteFactura(0)
                        For I = 1 To fin - 2
                            vValores = vKeywords(I).Split(CChar(Chr(9)))
                            Factura.InsertFactura(vValores(0), vValores(1), vValores(2), vValores(3), vValores(4), vValores(5), vValores(6), vValores(7))
                        Next
                        vLector.Close()
                    Else
                        GoTo salir
                    End If

            End Select

            Return " CARGA OK ... " & nombre
            Exit Function
salir:
            Return " Sin archivo txtpara la CARGA... " & nombre
            Exit Function

        Catch ex As Exception
            Return " ERROR EN CARGA... " & nombre
        End Try

    End Function

    Public Shared Function DBAuthenticate(strUsernamea As String, ByVal strPassworda As String) As Integer
        Dim sqlcon As SqlConnection

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString

        sqlcon = New SqlConnection(connectionString)

        Dim cmdSelect As SqlCommand


        cmdSelect = New SqlCommand("SELECT count(*) FROM SorWeb.ADM_USUARIOS WHERE USU_NOMBRE=@username AND USU_PSS=@password", sqlcon)
        cmdSelect.CommandType = CommandType.Text


        cmdSelect.Parameters.Add(New SqlParameter("@username", strUsernamea))
        cmdSelect.Parameters.Add(New SqlParameter("@password", strPassworda))


        Try 'Control de errores
            sqlcon.Open()


            Dim intresult As Integer = cmdSelect.ExecuteScalar()

            'Cerramos conexión
            sqlcon.Close()

            If intresult > 0 Then

                Return 1
            Else

                Return 0
            End If
        Catch ex As Exception 'Se produce error en el uso del procedimiento

            Return 0
        End Try


    End Function

    Public Shared Function DBAuthenticateCli(strUsernamea As String, ByVal strPassworda As String) As Integer
        Dim sqlcon As SqlConnection

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString

        sqlcon = New SqlConnection(connectionString)

        Dim cmdSelect As SqlCommand


        cmdSelect = New SqlCommand("SELECT count(*) FROM SorWeb.VTS_CLIENTES WHERE USU_NOMBRE=@username AND USU_PSS=@password", sqlcon)
        cmdSelect.CommandType = CommandType.Text

        'parmReturnValue = cmdSelect.Parameters.Add("RETURN_VALUE", SqlDbType.Int)
        'parmReturnValue.Direction = ParameterDirection.ReturnValue
        'Asignamos valores a los parámetros del procedimiento almacenado.

        cmdSelect.Parameters.Add(New SqlParameter("@username", strUsernamea))
        cmdSelect.Parameters.Add(New SqlParameter("@password", strPassworda))

        Try 'Control de errores
            sqlcon.Open()
            'Ejecutamos el Procedimiento almacenado

            Dim intresult As Integer = cmdSelect.ExecuteScalar()
            'Recogemos el resultado del Procedimiento almacenado.


            'Cerramos conexión
            sqlcon.Close()

            If intresult > 0 Then
                'lblError.Text = ""
                'FormsAuthentication.SetAuthCookie(TextBoxUser.Text, True)
                'Session("ADMIN") = strUsernamea 'TextBoxUser.Text

                'Response.Redirect("inicio.aspx")
                Return 1
            Else
                'lblError.Text = "Error de ususario o contraseña ... "
                Return 0
            End If
        Catch ex As Exception 'Se produce error en el uso del procedimiento
            'lblError.Visible = True
            'lblError.Text = "Error al intentar identificar al usuario: "
            'lblError.Text &= ex.Message
            Return 0
        End Try


    End Function





End Class

