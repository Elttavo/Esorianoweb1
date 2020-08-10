Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Microsoft.VisualBasic

Public Class GridViewTemplate
    Implements ITemplate

    Private templateType As DataControlRowType
    Private columnName As String

    Sub New(ByVal type As DataControlRowType, ByVal colname As String)

        templateType = type
        columnName = colname

    End Sub

    Sub InstantiateIn(ByVal container As System.Web.UI.Control) _
      Implements ITemplate.InstantiateIn

        ' Create the content for the different row types.
        Select Case templateType

            Case DataControlRowType.Header
                ' Create the controls to put in the header
                ' section and set their properties.
                Dim lc As New Literal
                lc.Text = "<b>" & columnName & "</b>"

                ' Add the controls to the Controls collection
                ' of the container.
                container.Controls.Add(lc)

            Case DataControlRowType.DataRow
                ' Create the controls to put in a data row
                ' section and set their properties.
                Dim Cantidad As New TextBox

                Dim spacer = New Literal
                spacer.Text = " "

                ' To support data binding, register the event-handling methods
                ' to perform the data binding. Each control needs its own event
                ' handler.
                AddHandler Cantidad.DataBinding, AddressOf Cantidad_DataBinding

                ' Add the controls to the Controls collection
                ' of the container.
                container.Controls.Add(Cantidad)
                container.Controls.Add(spacer)

                ' Insert cases to create the content for the other 
                ' row types, if desired.

            Case Else

                ' Insert code to handle unexpected values. 

        End Select

    End Sub

    Private Sub Cantidad_DataBinding(ByVal sender As Object, ByVal e As EventArgs)

        ' Get the Label control to bind the value. The Label control
        ' is contained in the object that raised the DataBinding 
        ' event (the sender parameter).
        Dim Cantidad As TextBox = CType(sender, TextBox)

        ' Get the GridViewRow object that contains the Label control. 
        Dim row As GridViewRow = CType(Cantidad.NamingContainer, GridViewRow)

        ' Get the field value from the GridViewRow object and 
        ' assign it to the Text property of the Label control.
        Cantidad.Text = DataBinder.Eval(row.DataItem, "Cantidad").ToString()

    End Sub



End Class


