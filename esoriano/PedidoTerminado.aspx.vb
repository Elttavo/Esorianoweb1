Imports System.Net.Mail
Imports System.Net
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading
Imports ClassLibrary1
Partial Class PedidoTerminado
    Inherits System.Web.UI.Page
    Dim ped As String
    Dim num_cliente As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session.Item("USER") Is Nothing Then
            Response.Redirect("pedidos.aspx")
        End If
        Panel1.Visible = True
        LinkButton1.Visible = True

        lblerror.Visible = True
        ped = Request.QueryString("ped")
            Label2.Text = ped
        Textnumeropedido.Text = ped
        num_cliente = CType(Session.Item("USER"), String)
        Textnumerocliente.Text = Cliente.SelectNomCli(num_cliente)

    End Sub

        Public Function SendMessage(ByVal address As String, ByVal subject As String, ByVal body As String) As Integer
            Dim message As New System.Net.Mail.MailMessage()

            Try ' Dirección de destino
                message.[To].Add(address)
                ' Asunto 
                message.Subject = subject
                ' Mensaje 
                message.Body = body

                Dim smpt As New System.Net.Mail.SmtpClient()
                smpt.Send(message)
            Catch ex As Exception
                lblerror.Visible = True
                lblerror.Text = "Error en direccion de mail"
            End Try
            Return 1
        End Function

        Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

            Dim ped_numero As String

            Dim comen As String
            Dim dire As String
            Try

                If (Text_dire_mail.Text) = "" Then GoTo salir
                If (Textnumeropedido.Text) = "" Then GoTo salir
                ' If (Textnumeropedido0.Text) = "" Then GoTo salir


                dire = Text_dire_mail.Text
                ped_numero = Textnumeropedido.Text
                ' num_cliente = Textnumeropedido0.Text
                comen = Textnumeropedido1.Text

                Dim myhilo As New Thread(Sub() envioMasivo(dire, ped_numero, num_cliente, comen))
                myhilo.Priority = ThreadPriority.Lowest
                If myhilo.ThreadState <> Threading.ThreadState.Running Then
                    myhilo.Start()
                End If
                LinkButton1.Visible = True
                Panel2.Visible = True
                Imgcorreo.Visible = True
                Panel1.Visible = False

salir:
                lblerror.Visible = True
                lblerror.Text = "ingrese todos los datos correctamente "

            Catch ex As Exception
                lblerror.Visible = True
                lblerror.Text = ex.Message + "verifique datos"
            End Try

        End Sub

        Function EmailAddressCheck(ByVal emailAddress As String) As Boolean
            Dim pattern As String = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"

            Dim emailAddressMatch As Match = Regex.Match(emailAddress, pattern)

            If emailAddressMatch.Success Then

                EmailAddressCheck = True

            Else

                EmailAddressCheck = False

            End If



        End Function

        Private Sub envioMasivo(dire As String, ped_numero As String, num_cliente As String, comen As String)
            Dim vendedor As String
            Dim num As Integer
            Try
            vendedor = Cliente.SelectVendor(num_cliente)


            If EmailAddressCheck(dire) = True Then
                    num = SendMessage("ventas@esoriano.com.ar", " Esorianosa confirmacion de pedido Numero " + CStr(ped_numero) + " Correo: " + dire, " Numero de cliente " + CStr(num_cliente) + " Comentarios : " + comen)

                End If

                If EmailAddressCheck(vendedor) = True Then
                num = SendMessage(vendedor, " Esorianosa confirmacion de pedido Numero " + CStr(ped_numero) + " Correo: " + dire, "El cliente numero " + CStr(num_cliente) + " Realizo un pedido ,Comentarios : " + comen)

            End If
            Catch ex As Exception

            End Try


        End Sub
    End Class