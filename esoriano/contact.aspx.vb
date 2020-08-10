Imports System.Drawing
Imports System.Threading

Public Class contact
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            imgCaptcha.ImageUrl = "~/Captcha.aspx?New=1"
        End If
    End Sub



    Private Sub envioMasivo(dire As String, nombre As String, empresa As String, direccionCliente As String, tipoEmpresa As String, provincia As String, localidad As String, codPostal As String, comen As String)

        Dim num As Integer
        Try



            If EmailAddressCheck(dire) = True Then
                num = SendMessage("ventas@esoriano.com.ar", " Esorianosa pedido de informacion del Correo:  " + dire, " nombre :" + nombre + " Empresa " + empresa + "direccion :" + direccionCliente +
                                  "tipo se empresa :" + tipoEmpresa + "Provincia : " + provincia + "Localidad " + localidad + "codigo Postal" + codPostal + " Comentarios : " + comen)

            End If


        Catch ex As Exception

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

    Protected Sub btnMandarMail_Click(sender As Object, e As EventArgs)
        Dim dire, nombre, empresa, direccionCliente, tipoEmpresa, provincia, localidad, codPostal, comen As String

        Try



            imgCaptcha.ImageUrl = "~/CreateCaptcha.aspx?New=0"
            If Session("CaptchaCode") IsNot Nothing AndAlso
            txtCaptcha.Text = Session("CaptchaCode").ToString() Then
                lblMessage.Text = ""
                lblMessage.Visible = False
                If (inputEmail4.Text) = "" Then GoTo salir
                If (inputnNombre.Text) = "" Then GoTo salir
                ' If (Textnumeropedido0.Text) = "" Then GoTo salir


                dire = inputEmail4.Text
                nombre = inputnNombre.Text
                empresa = inputEmpresa.Text
                direccionCliente = inputAddress.Text
                tipoEmpresa = inputtipoEmpresa.Items(inputtipoEmpresa.SelectedIndex).Text
                provincia = inputState.Items(inputState.SelectedIndex).Text
                localidad = inputCity.Text
                codPostal = inputCodPostal.Text
                comen = validationTextarea.Text


                Dim myhilo As New Thread(Sub() envioMasivo(dire, nombre, empresa, direccionCliente, tipoEmpresa, provincia, localidad, codPostal, comen))
                myhilo.Priority = ThreadPriority.Lowest
                If myhilo.ThreadState <> Threading.ThreadState.Running Then
                    myhilo.Start()
                End If


            Else
                lblMessage.ForeColor = Color.Red
                lblMessage.Visible = True
                lblMessage.Text = "Código Captcha erroneo, intentelo nuevamente!!"
                imgCaptcha.ImageUrl = "~/Captcha.aspx?New=1"
            End If




            Exit Sub

salir:
            lblerror.Visible = True
            lblerror.Text = "ingrese todos los datos del formulario correctamente (verifique direccion de mail o nombre de contacto ) "
            imgCaptcha.ImageUrl = "~/Captcha.aspx?New=1"

        Catch ex As Exception
            lblerror.Visible = True
            lblerror.Text = ex.Message + "verifique datos"
        End Try
    End Sub
End Class