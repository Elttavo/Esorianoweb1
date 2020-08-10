Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.DataRowView
Imports Microsoft.VisualBasic
Imports System.DBNull

Public Class Rubros
    Public Shared intEMP_CODIGO As Integer
    Private intRUB_CODIGO As Integer
    Private strRUB_NOMBRE As String
    Private strRUB_IMAGEN As String
    Private strSRB_NOMBRE As String
    Public Shared noborr As Integer = 1
    Public Property EMP_CODIGO() As Integer
        Get
            Return intEMP_CODIGO
        End Get
        Set(ByVal value As Integer)
            intEMP_CODIGO = value
        End Set
    End Property
    Public Property RUB_CODIGO() As Integer
        Get
            Return intRUB_CODIGO
        End Get
        Set(ByVal value As Integer)
            intRUB_CODIGO = value
        End Set
    End Property
    Public Property RUB_IMAGEN() As String
        Get
            Return strRUB_IMAGEN
        End Get
        Set(ByVal value As String)
            strRUB_IMAGEN = value
        End Set
    End Property
    Public Property RUB_NOMBRE() As String
        Get
            Return strRUB_NOMBRE
        End Get
        Set(ByVal value As String)
            strRUB_NOMBRE = value
        End Set
    End Property
    Public Property SRB_NOMBRE() As String
        Get
            Return strSRB_NOMBRE
        End Get
        Set(ByVal value As String)
            strSRB_NOMBRE = value
        End Set
    End Property
    Public Shared Function GetRubros() As DataSet
        Dim db As DBAccess = New DBAccess
        Return db.ExecuteDataSet("SELECT  RUB_CODIGO,RUB_NOMBRE,RUB_IMAGEN FROM SorWeb.STK_RUBROS  order by RUB_NOMBRE  ")

    End Function
    Public Shared Function GetSubRubros(ByVal RUB_CODIGO As Integer) As DataSet
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@RUB_CODIGO", RUB_CODIGO))

        Return db.ExecuteDataSet("SELECT SR.RUB_CODIGO,R.RUB_NOMBRE,SR.SRB_CODIGO,SR.SRB_NOMBRE FROM SORWEB.STK_SUBRUBROS SR INNER JOIN  SORWEB.STK_RUBROS R ON  SR.RUB_CODIGO=R.RUB_CODIGO WHERE R.RUB_CODIGO=@RUB_CODIGO  order by SR.SRB_NOMBRE ")
    End Function
    Public Shared Function GetRubrosxAbc() As DataSet
        Dim db As DBAccess = New DBAccess
        Return db.ExecuteDataSet("SELECT RUB_CODIGO,RUB_NOMBRE,RUB_IMAGEN FROM SorWeb.STK_RUBROS WHERE RUB_NOMBRE LIKE 'A' + '%' order by RUB_NOMBRE ")

    End Function
    Public Shared Function GetRubrosxAbcB(ByVal RUB_CODIGO As Integer) As DataSet
        Dim db As DBAccess = New DBAccess
        Return db.ExecuteDataSet("SELECT RUB_CODIGO,RUB_NOMBRE,RUB_IMAGEN FROM SorWeb.STK_RUBROS WHERE RUB_NOMBRE LIKE 'B' + '%'order by RUB_NOMBRE")

    End Function
    Public Shared Function GetSubRubrosxAbc(ByVal RUB_CODIGO As Integer) As DataSet
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@RUB_CODIGO", RUB_CODIGO))
        Return db.ExecuteDataSet("SELECT SR.RUB_CODIGO,R.RUB_NOMBRE,SR.SRB_CODIGO,SR.SRB_NOMBRE FROM SORWEB.STK_SUBRUBROS SR INNER JOIN  SORWEB.STK_RUBROS R ON  SR.RUB_CODIGO=R.RUB_CODIGO WHERE R.RUB_NOMBRE LIKE 'A' + '%' AND R.RUB_CODIGO=@RUB_CODIGO order by SR.SRB_NOMBRE ")
    End Function
    Public Shared Function GetRubrosxB() As DataSet
        Dim db As DBAccess = New DBAccess
        Return db.ExecuteDataSet("SELECT RUB_CODIGO,RUB_NOMBRE,RUB_IMAGEN FROM SorWeb.STK_RUBROS WHERE RUB_NOMBRE LIKE 'B' + '%'")
    End Function
    Public Shared Function GetSubRubrosxB(ByVal RUB_CODIGO As Integer) As DataSet
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@RUB_CODIGO", RUB_CODIGO))
        Return db.ExecuteDataSet("SELECT SR.RUB_CODIGO,R.RUB_NOMBRE,SR.SRB_CODIGO,SR.SRB_NOMBRE FROM SORWEB.STK_SUBRUBROS SR INNER JOIN  SORWEB.STK_RUBROS R ON  SR.RUB_CODIGO=R.RUB_CODIGO WHERE R.RUB_NOMBRE LIKE 'B' + '%'  AND R.RUB_CODIGO=@RUB_CODIGO order by SR.SRB_NOMBRE ")
    End Function
    Public Shared Function GetRubrosxC() As DataSet
        Dim db As DBAccess = New DBAccess
        Return db.ExecuteDataSet("SELECT RUB_CODIGO,RUB_NOMBRE,RUB_IMAGEN FROM SorWeb.STK_RUBROS WHERE RUB_NOMBRE LIKE 'C' + '%'")
    End Function
    Public Shared Function GetSubRubrosxC(ByVal RUB_CODIGO As Integer) As DataSet
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@RUB_CODIGO", RUB_CODIGO))
        Return db.ExecuteDataSet("SELECT SR.RUB_CODIGO,R.RUB_NOMBRE,SR.SRB_CODIGO,SR.SRB_NOMBRE FROM SORWEB.STK_SUBRUBROS SR INNER JOIN  SORWEB.STK_RUBROS R ON  SR.RUB_CODIGO=R.RUB_CODIGO WHERE R.RUB_NOMBRE LIKE 'C' + '%'  AND R.RUB_CODIGO=@RUB_CODIGO order by SR.SRB_NOMBRE ")
    End Function
    Public Shared Function GetRubrosxD() As DataSet
        Dim db As DBAccess = New DBAccess
        Return db.ExecuteDataSet("SELECT RUB_CODIGO,RUB_NOMBRE,RUB_IMAGEN FROM SorWeb.STK_RUBROS WHERE RUB_NOMBRE LIKE 'D' + '%'")
    End Function
    Public Shared Function GetSubRubrosxD(ByVal RUB_CODIGO As Integer) As DataSet
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@RUB_CODIGO", RUB_CODIGO))
        Return db.ExecuteDataSet("SELECT SR.RUB_CODIGO,R.RUB_NOMBRE,SR.SRB_CODIGO,SR.SRB_NOMBRE FROM SORWEB.STK_SUBRUBROS SR INNER JOIN  SORWEB.STK_RUBROS R ON  SR.RUB_CODIGO=R.RUB_CODIGO WHERE R.RUB_NOMBRE LIKE 'D' + '%'  AND R.RUB_CODIGO=@RUB_CODIGO order by SR.SRB_NOMBRE ")
    End Function
    Public Shared Function GetRubrosxE() As DataSet
        Dim db As DBAccess = New DBAccess
        Return db.ExecuteDataSet("SELECT RUB_CODIGO,RUB_NOMBRE,RUB_IMAGEN FROM SorWeb.STK_RUBROS WHERE RUB_NOMBRE LIKE 'E' + '%'")
    End Function
    Public Shared Function GetSubRubrosxE(ByVal RUB_CODIGO As Integer) As DataSet
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@RUB_CODIGO", RUB_CODIGO))
        Return db.ExecuteDataSet("SELECT SR.RUB_CODIGO,R.RUB_NOMBRE,SR.SRB_CODIGO,SR.SRB_NOMBRE FROM SORWEB.STK_SUBRUBROS SR INNER JOIN  SORWEB.STK_RUBROS R ON  SR.RUB_CODIGO=R.RUB_CODIGO WHERE R.RUB_NOMBRE LIKE 'E' + '%'  AND R.RUB_CODIGO=@RUB_CODIGO order by SR.SRB_NOMBRE ")
    End Function
    Public Shared Function GetRubrosxF() As DataSet
        Dim db As DBAccess = New DBAccess
        Return db.ExecuteDataSet("SELECT RUB_CODIGO,RUB_NOMBRE,RUB_IMAGEN FROM SorWeb.STK_RUBROS WHERE RUB_NOMBRE LIKE 'F' + '%'")
    End Function
    Public Shared Function GetSubRubrosxF(ByVal RUB_CODIGO As Integer) As DataSet
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@RUB_CODIGO", RUB_CODIGO))
        Return db.ExecuteDataSet("SELECT SR.RUB_CODIGO,R.RUB_NOMBRE,SR.SRB_CODIGO,SR.SRB_NOMBRE FROM SORWEB.STK_SUBRUBROS SR INNER JOIN  SORWEB.STK_RUBROS R ON  SR.RUB_CODIGO=R.RUB_CODIGO WHERE R.RUB_NOMBRE LIKE 'F' + '%'  AND R.RUB_CODIGO=@RUB_CODIGO order by SR.SRB_NOMBRE ")
    End Function
    Public Shared Function GetRubrosxG() As DataSet
        Dim db As DBAccess = New DBAccess
        Return db.ExecuteDataSet("SELECT RUB_CODIGO,RUB_NOMBRE,RUB_IMAGEN FROM SorWeb.STK_RUBROS WHERE RUB_NOMBRE LIKE 'G' + '%'")
    End Function
    Public Shared Function GetSubRubrosxG(ByVal RUB_CODIGO As Integer) As DataSet
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@RUB_CODIGO", RUB_CODIGO))
        Return db.ExecuteDataSet("SELECT SR.RUB_CODIGO,R.RUB_NOMBRE,SR.SRB_CODIGO,SR.SRB_NOMBRE FROM SORWEB.STK_SUBRUBROS SR INNER JOIN  SORWEB.STK_RUBROS R ON  SR.RUB_CODIGO=R.RUB_CODIGO WHERE R.RUB_NOMBRE LIKE 'G' + '%'  AND R.RUB_CODIGO=@RUB_CODIGO order by SR.SRB_NOMBRE ")
    End Function
    Public Shared Function GetRubrosxH() As DataSet
        Dim db As DBAccess = New DBAccess
        Return db.ExecuteDataSet("SELECT RUB_CODIGO,RUB_NOMBRE,RUB_IMAGEN FROM SorWeb.STK_RUBROS WHERE RUB_NOMBRE LIKE 'H' + '%'")
    End Function
    Public Shared Function GetSubRubrosxH(ByVal RUB_CODIGO As Integer) As DataSet
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@RUB_CODIGO", RUB_CODIGO))
        Return db.ExecuteDataSet("SELECT SR.RUB_CODIGO,R.RUB_NOMBRE,SR.SRB_CODIGO,SR.SRB_NOMBRE FROM SORWEB.STK_SUBRUBROS SR INNER JOIN  SORWEB.STK_RUBROS R ON  SR.RUB_CODIGO=R.RUB_CODIGO WHERE R.RUB_NOMBRE LIKE 'H' + '%'  AND R.RUB_CODIGO=@RUB_CODIGO order by SR.SRB_NOMBRE ")
    End Function
    Public Shared Function GetRubrosxL() As DataSet
        Dim db As DBAccess = New DBAccess
        Return db.ExecuteDataSet("SELECT RUB_CODIGO,RUB_NOMBRE,RUB_IMAGEN FROM SorWeb.STK_RUBROS WHERE RUB_NOMBRE LIKE 'L' + '%'")
    End Function
    Public Shared Function GetSubRubrosxL(ByVal RUB_CODIGO As Integer) As DataSet
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@RUB_CODIGO", RUB_CODIGO))
        Return db.ExecuteDataSet("SELECT SR.RUB_CODIGO,R.RUB_NOMBRE,SR.SRB_CODIGO,SR.SRB_NOMBRE FROM SORWEB.STK_SUBRUBROS SR INNER JOIN  SORWEB.STK_RUBROS R ON  SR.RUB_CODIGO=R.RUB_CODIGO WHERE R.RUB_NOMBRE LIKE 'L' + '%'  AND R.RUB_CODIGO=@RUB_CODIGO order by SR.SRB_NOMBRE ")
    End Function
    Public Shared Function GetRubrosxM() As DataSet
        Dim db As DBAccess = New DBAccess
        Return db.ExecuteDataSet("SELECT RUB_CODIGO,RUB_NOMBRE,RUB_IMAGEN FROM SorWeb.STK_RUBROS WHERE RUB_NOMBRE LIKE 'M' + '%'")
    End Function
    Public Shared Function GetSubRubrosxM(ByVal RUB_CODIGO As Integer) As DataSet
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@RUB_CODIGO", RUB_CODIGO))
        Return db.ExecuteDataSet("SELECT SR.RUB_CODIGO,R.RUB_NOMBRE,SR.SRB_CODIGO,SR.SRB_NOMBRE FROM SORWEB.STK_SUBRUBROS SR INNER JOIN  SORWEB.STK_RUBROS R ON  SR.RUB_CODIGO=R.RUB_CODIGO WHERE R.RUB_NOMBRE LIKE 'M' + '%'  AND R.RUB_CODIGO=@RUB_CODIGO order by SR.SRB_NOMBRE ")
    End Function
    Public Shared Function GetRubrosxN() As DataSet
        Dim db As DBAccess = New DBAccess
        Return db.ExecuteDataSet("SELECT RUB_CODIGO,RUB_NOMBRE,RUB_IMAGEN FROM SorWeb.STK_RUBROS WHERE RUB_NOMBRE LIKE 'N' + '%'")
    End Function
    Public Shared Function GetSubRubrosxN(ByVal RUB_CODIGO As Integer) As DataSet
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@RUB_CODIGO", RUB_CODIGO))
        Return db.ExecuteDataSet("SELECT SR.RUB_CODIGO,R.RUB_NOMBRE,SR.SRB_CODIGO,SR.SRB_NOMBRE FROM SORWEB.STK_SUBRUBROS SR INNER JOIN  SORWEB.STK_RUBROS R ON  SR.RUB_CODIGO=R.RUB_CODIGO WHERE R.RUB_NOMBRE LIKE 'N' + '%'  AND R.RUB_CODIGO=@RUB_CODIGO order by SR.SRB_NOMBRE ")
    End Function
    Public Shared Function GetRubrosxP() As DataSet
        Dim db As DBAccess = New DBAccess
        Return db.ExecuteDataSet("SELECT RUB_CODIGO,RUB_NOMBRE,RUB_IMAGEN FROM SorWeb.STK_RUBROS WHERE RUB_NOMBRE LIKE 'P' + '%'")
    End Function
    Public Shared Function GetSubRubrosxP(ByVal RUB_CODIGO As Integer) As DataSet
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@RUB_CODIGO", RUB_CODIGO))
        Return db.ExecuteDataSet("SELECT SR.RUB_CODIGO,R.RUB_NOMBRE,SR.SRB_CODIGO,SR.SRB_NOMBRE FROM SORWEB.STK_SUBRUBROS SR INNER JOIN  SORWEB.STK_RUBROS R ON  SR.RUB_CODIGO=R.RUB_CODIGO WHERE R.RUB_NOMBRE LIKE 'P' + '%'  AND R.RUB_CODIGO=@RUB_CODIGO order by SR.SRB_NOMBRE ")
    End Function
    Public Shared Function GetRubrosxR() As DataSet
        Dim db As DBAccess = New DBAccess
        Return db.ExecuteDataSet("SELECT RUB_CODIGO,RUB_NOMBRE,RUB_IMAGEN FROM SorWeb.STK_RUBROS WHERE RUB_NOMBRE LIKE 'R' + '%'")
    End Function
    Public Shared Function GetSubRubrosxR(ByVal RUB_CODIGO As Integer) As DataSet
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@RUB_CODIGO", RUB_CODIGO))
        Return db.ExecuteDataSet("SELECT SR.RUB_CODIGO,R.RUB_NOMBRE,SR.SRB_CODIGO,SR.SRB_NOMBRE FROM SORWEB.STK_SUBRUBROS SR INNER JOIN  SORWEB.STK_RUBROS R ON  SR.RUB_CODIGO=R.RUB_CODIGO WHERE R.RUB_NOMBRE LIKE 'R' + '%'  AND R.RUB_CODIGO=@RUB_CODIGO order by SR.SRB_NOMBRE ")
    End Function
    Public Shared Function GetRubrosxS() As DataSet
        Dim db As DBAccess = New DBAccess
        Return db.ExecuteDataSet("SELECT RUB_CODIGO,RUB_NOMBRE,RUB_IMAGEN FROM SorWeb.STK_RUBROS WHERE RUB_NOMBRE LIKE 'S' + '%'")
    End Function
    Public Shared Function GetSubRubrosxS(ByVal RUB_CODIGO As Integer) As DataSet
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@RUB_CODIGO", RUB_CODIGO))
        Return db.ExecuteDataSet("SELECT SR.RUB_CODIGO,R.RUB_NOMBRE,SR.SRB_CODIGO,SR.SRB_NOMBRE FROM SORWEB.STK_SUBRUBROS SR INNER JOIN  SORWEB.STK_RUBROS R ON  SR.RUB_CODIGO=R.RUB_CODIGO WHERE R.RUB_NOMBRE LIKE 'S' + '%'  AND R.RUB_CODIGO=@RUB_CODIGO order by SR.SRB_NOMBRE ")
    End Function
    Public Shared Function GetRubrosxT() As DataSet
        Dim db As DBAccess = New DBAccess
        Return db.ExecuteDataSet("SELECT RUB_CODIGO,RUB_NOMBRE,RUB_IMAGEN FROM SorWeb.STK_RUBROS WHERE RUB_NOMBRE LIKE 'T' + '%'")
    End Function
    Public Shared Function GetSubRubrosxT(ByVal RUB_CODIGO As Integer) As DataSet
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@RUB_CODIGO", RUB_CODIGO))
        Return db.ExecuteDataSet("SELECT SR.RUB_CODIGO,R.RUB_NOMBRE,SR.SRB_CODIGO,SR.SRB_NOMBRE FROM SORWEB.STK_SUBRUBROS SR INNER JOIN  SORWEB.STK_RUBROS R ON  SR.RUB_CODIGO=R.RUB_CODIGO WHERE R.RUB_NOMBRE LIKE 'T' + '%'  AND R.RUB_CODIGO=@RUB_CODIGO order by SR.SRB_NOMBRE ")
    End Function
    Public Shared Function GetRubrosxV() As DataSet
        Dim db As DBAccess = New DBAccess
        Return db.ExecuteDataSet("SELECT RUB_CODIGO,RUB_NOMBRE,RUB_IMAGEN FROM SorWeb.STK_RUBROS WHERE RUB_NOMBRE LIKE 'V' + '%'")
    End Function
    Public Shared Function GetSubRubrosxV(ByVal RUB_CODIGO As Integer) As DataSet
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@RUB_CODIGO", RUB_CODIGO))
        Return db.ExecuteDataSet("SELECT SR.RUB_CODIGO,R.RUB_NOMBRE,SR.SRB_CODIGO,SR.SRB_NOMBRE FROM SORWEB.STK_SUBRUBROS SR INNER JOIN  SORWEB.STK_RUBROS R ON  SR.RUB_CODIGO=R.RUB_CODIGO WHERE R.RUB_NOMBRE LIKE 'V' + '%'  AND R.RUB_CODIGO=@RUB_CODIGO order by SR.SRB_NOMBRE ")
    End Function
    Public Shared Function GetRubrosxZ() As DataSet
        Dim db As DBAccess = New DBAccess
        Return db.ExecuteDataSet("SELECT RUB_CODIGO,RUB_NOMBRE,RUB_IMAGEN FROM SorWeb.STK_RUBROS WHERE RUB_NOMBRE LIKE 'Z' + '%'")
    End Function
    Public Shared Function GetSubRubrosxZ(ByVal RUB_CODIGO As Integer) As DataSet
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@RUB_CODIGO", RUB_CODIGO))
        Return db.ExecuteDataSet("SELECT SR.RUB_CODIGO,R.RUB_NOMBRE,SR.SRB_CODIGO,SR.SRB_NOMBRE FROM SORWEB.STK_SUBRUBROS SR INNER JOIN  SORWEB.STK_RUBROS R ON  SR.RUB_CODIGO=R.RUB_CODIGO WHERE R.RUB_NOMBRE LIKE 'Z' + '%'  AND R.RUB_CODIGO=@RUB_CODIGO order by SR.SRB_NOMBRE ")
    End Function
    Public Shared Function DeleteRubro(ByVal RUB_CODIGO As Integer) As Integer
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@RUB_CODIGO", RUB_CODIGO))

        Dim retval As Integer = db.ExecuteNonQuery("DELETE FROM SorWeb.STK_RUBROS WHERE RUB_codigo<>@RUB_CODIGO")
        If retval <> 1 Then
            Return -1
            Exit Function
        End If

        Return 1
    End Function
    Public Shared Function RubroSubFW(ByVal rubro As String, ByVal subrubro As String) As DataSet
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@rubro", rubro))
        db.Parameters.Add(New SqlParameter("@subrubro", subrubro))
        Return db.ExecuteDataSet("Select SorWeb.STK_RUBROS.RUB_NOMBRE, SorWeb.STK_SUBRUBROS.SRB_NOMBRE, SorWeb.STK_SUBRUBROS.RUB_CODIGO, SorWeb.STK_SUBRUBROS.SRB_CODIGO  FROM SorWeb.STK_SUBRUBROS INNER JOIN SorWeb.STK_RUBROS On SorWeb.STK_SUBRUBROS.RUB_CODIGO = SorWeb.STK_RUBROS.RUB_CODIGO  WHERE sorweb.STK_RUBROS.RUB_CODIGO = " + rubro + " And sorweb.STK_SUBRUBROS.SRB_CODIGO = " + subrubro + " order by SorWeb.STK_RUBROS.RUB_NOMBRE,SorWeb.STK_SUBRUBROS.SRB_NOMBRE ")

    End Function
    Public Shared Function RubroSubFW(ByVal rubro As String) As DataSet
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@rubro", rubro))

        Return db.ExecuteDataSet("Select SorWeb.STK_RUBROS.RUB_NOMBRE  FROM SorWeb.STK_RUBROS  WHERE sorweb.STK_RUBROS.RUB_CODIGO = " + rubro + "  order by SorWeb.STK_RUBROS.RUB_NOMBRE ")

    End Function
    Public Shared Function InsertRubros(ByVal EMP_CODIGO As String, ByVal RUB_CODIGO As String, ByVal RUB_NOMBRE As String, ByVal RUB_IMAGEN As String) As Integer
        Dim db As DBAccess = New DBAccess

        db.Parameters.Add(New SqlParameter("@EMP_CODIGO", EMP_CODIGO))
        db.Parameters.Add(New SqlParameter("@RUB_CODIGO", RUB_CODIGO))
        db.Parameters.Add(New SqlParameter("@RUB_NOMBRE", RUB_NOMBRE))
        db.Parameters.Add(New SqlParameter("@RUB_IMAGEN", RUB_IMAGEN))

        Dim retval As Integer = db.ExecuteNonQuery("INSERT INTO SorWeb.STK_RUBROS(EMP_CODIGO ,RUB_CODIGO ,RUB_NOMBRE,RUB_IMAGEN)VALUES(@EMP_CODIGO ,@RUB_CODIGO ,@RUB_NOMBRE,@RUB_IMAGEN) ")
        If retval = 1 Then
            Return 1
        Else
            Return -1
        End If
    End Function

End Class

