Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.DataRowView
Imports Microsoft.VisualBasic
Imports System.DBNull


Public Class CartItem
    Public Shared noborr As Integer = 1
    Public ArtCart As New ArticulosCart
    Public Quantity As Integer

    Public Function Display() As String
        Return ArtCart.ART_CODIGO + Quantity.ToString() + FormatCurrency(ArtCart.LST_PRECIO1)

    End Function

End Class
