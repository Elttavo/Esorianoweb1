Imports Microsoft.VisualBasic

Public Class Class1

    Public Function FormatearCadenaConCeros(ByRef Cad As Object, ByRef LargoCadenaTotal As Short) As String
        Dim i As Short


        For i = 1 To LargoCadenaTotal - Len(RTrim(Cad))

            Cad = "0" & RTrim(Cad)
        Next i

        FormatearCadenaConCeros = Cad

    End Function

    Public Function FormatearCadenaConEspacios(ByRef Cad As Object, ByRef LargoCadenaTotal As Short) As String
        Dim i As Short


        Cad = LTrim(Cad)

        Cad = RTrim(Cad)

        For i = 1 To LargoCadenaTotal - Len(Cad)

            Cad = " " & Cad
        Next i


        FormatearCadenaConEspacios = Cad

    End Function

    Public Function FormatearCadenaConEspaciosDer(ByRef Cad As Object, ByRef LargoCadenaTotal As Short) As String
        Dim i As Short


        Cad = LTrim(Cad)

        Cad = RTrim(Cad)

        For i = 1 To LargoCadenaTotal - Len(Cad)

            Cad = Cad & " "
        Next i


        FormatearCadenaConEspaciosDer = Cad

    End Function
    Public Function FormatearFecha(ByVal Fecha As Date) As String
        If Not IsDate(Fecha) Then
            FormatearFecha = vbNullString
        Else

            FormatearFecha = String.Format(Fecha, "MM/DD/YY")

        End If

    End Function
    Public Function FormatearFechaFS(ByVal Fecha As Date) As String
        If Not IsDate(Fecha) Then
            FormatearFechaFS = vbNullString
        Else

            FormatearFechaFS = Fecha.ToString("MM/dd/yyyy")
            'FormatearFechaFS = String.Format(Fecha, "DD/MM/YYYY")
            'FormatearFechaFS = String.Format(Fecha, "yyyymmdd")

        End If

    End Function


End Class

