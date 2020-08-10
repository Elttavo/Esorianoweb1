Imports System.Web
Imports System.Web.UI
Namespace shoppingCart1

    Public Class [Global]

        Inherits System.Web.HttpApplication



        Public Sub New()
            MyBase.New()

            'This call is required by the Component Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call

        End Sub

        'Required by the Component Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Component Designer
        'It can be modified using the Component Designer.
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            components = New System.ComponentModel.Container()
        End Sub



        Private Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)



        End Sub


        ' Fires when the application is started


        Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
            Session.Clear()

            'FormsAuthentication.SignOut()
        End Sub

        Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
            ' Fires at the beginning of each request
        End Sub

        Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
            ' Fires upon attempting to authenticate the use
        End Sub

        Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)

        End Sub

        Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
            Session.Clear()

            Web.HttpContext.Current.Session.Abandon()
            FormsAuthentication.SignOut()
            Response.Redirect("pedidos.apsx")

        End Sub

        Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
            Session.Clear()
            HttpContext.Current.Session.Abandon()
            FormsAuthentication.SignOut()

        End Sub

    End Class
End Namespace