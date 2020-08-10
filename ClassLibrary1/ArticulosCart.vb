Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.DataRowView
Imports Microsoft.VisualBasic
Imports System.DBNull


Public Class ArticulosCart
    Public Shared intEMP_CODIGO As Integer
    Public Shared strART_CODIGO As String
    Public Shared strART_NOMBRE As String
    Public Shared intRUB_CODIGO As Integer
    Public Shared intSRB_CODIGO As Integer
    Public Shared strART_UND_CONSUMO As String
    Public Shared intART_UND_BULTO As Integer
    Public Shared intART_ENVASE As Integer
    Public Shared intLST_CODIGO As Integer
    Public Shared intLST_PRECIO1 As Decimal
    Public Shared intLNP_CANT_PED As Decimal
    Public Shared noborr As Integer = 1
    Public Shared int_pagin As Integer = 0

    Public Property pagin() As Integer
        Get
            Return int_pagin
        End Get
        Set(ByVal value As Integer)
            int_pagin = value
        End Set
    End Property
    Public Property EMP_CODIGO() As Integer
        Get
            Return intEMP_CODIGO
        End Get
        Set(ByVal value As Integer)
            intEMP_CODIGO = value
        End Set
    End Property
    Public Property ART_CODIGO() As String
        Get
            Return strART_CODIGO
        End Get
        Set(ByVal value As String)
            strART_CODIGO = value
        End Set
    End Property

    Public Property ART_NOMBRE() As String
        Get
            Return strART_NOMBRE
        End Get
        Set(ByVal value As String)
            strART_NOMBRE = value
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
    Public Property SRB_CODIGO() As Integer
        Get
            Return intSRB_CODIGO
        End Get
        Set(ByVal value As Integer)
            intSRB_CODIGO = value
        End Set
    End Property
    Public Property ART_UND_CONSUMO() As String
        Get
            Return strART_UND_CONSUMO
        End Get
        Set(ByVal value As String)
            strART_UND_CONSUMO = value
        End Set
    End Property
    Public Property ART_UND_BULTO() As Integer
        Get
            Return intART_UND_BULTO
        End Get
        Set(ByVal value As Integer)
            intART_UND_BULTO = value
        End Set
    End Property
    Public Property ART_ENVASE() As Integer
        Get
            Return intART_ENVASE
        End Get
        Set(ByVal value As Integer)
            intART_ENVASE = value
        End Set
    End Property
    Public Property LST_CODIGO() As Integer
        Get
            Return intLST_CODIGO
        End Get
        Set(ByVal value As Integer)
            intLST_CODIGO = value
        End Set
    End Property
    Public Property LST_PRECIO1() As Decimal
        Get
            Return intLST_PRECIO1
        End Get
        Set(ByVal value As Decimal)
            intLST_PRECIO1 = value
        End Set
    End Property
    Public Property LNP_CANT_PED() As Decimal
        Get
            Return intLNP_CANT_PED
        End Get
        Set(ByVal value As Decimal)
            intLNP_CANT_PED = value
        End Set
    End Property
    Public Shared Function SelectArt(ByVal rubro As String, ByVal subrubro As String) As DataSet
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@rubro", rubro))
        db.Parameters.Add(New SqlParameter("@subrubro", subrubro))
        Return db.ExecuteDataSet("SELECT sorweb.STK_ARTICULOS.EMP_CODIGO, sorweb.STK_ARTICULOS.ART_CODIGO, sorweb.STK_ARTICULOS.ART_NOMBRE, sorweb.STK_ARTICULOS.RUB_CODIGO, sorweb.STK_ARTICULOS.SRB_CODIGO, sorweb.STK_ARTICULOS.ART_UND_CONSUMO, sorweb.STK_ARTICULOS.ART_UND_BULTO / 100 AS ART_UND_BULTO, sorweb.STK_ARTICULOS.ART_ENVASE  / 100 AS ART_ENVASE,SorWeb.STK_UNIDADES.UND_NOMBRE,sorweb.STK_LISTA_PRECIOS_ART.LST_CODIGO,sorweb.STK_LISTA_PRECIOS_ART.LST_PRECIO1, CAST(0 AS int) AS CANTIDAD FROM sorweb.STK_LISTA_PRECIOS_ART INNER JOIN (sorweb.STK_UNIDADES INNER JOIN ((sorweb.STK_RUBROS INNER JOIN sorweb.STK_SUBRUBROS ON (sorweb.STK_RUBROS.EMP_CODIGO = sorweb.STK_SUBRUBROS.EMP_CODIGO) AND (sorweb.STK_RUBROS.RUB_CODIGO = sorweb.STK_SUBRUBROS.RUB_CODIGO)) INNER JOIN sorweb.STK_ARTICULOS ON (sorweb.STK_SUBRUBROS.EMP_CODIGO = sorweb.STK_ARTICULOS.EMP_CODIGO) AND (sorweb.STK_SUBRUBROS.RUB_CODIGO = sorweb.STK_ARTICULOS.RUB_CODIGO) AND (sorweb.STK_SUBRUBROS.SRB_CODIGO = sorweb.STK_ARTICULOS.SRB_CODIGO)) ON (sorweb.STK_UNIDADES.UND_CODIGO = sorweb.STK_ARTICULOS.ART_UND_CONSUMO) AND (sorweb.STK_UNIDADES.EMP_CODIGO = sorweb.STK_ARTICULOS.EMP_CODIGO)) ON (sorweb.STK_LISTA_PRECIOS_ART.EMP_CODIGO = sorweb.STK_ARTICULOS.EMP_CODIGO) AND (sorweb.STK_LISTA_PRECIOS_ART.ART_CODIGO = sorweb.STK_ARTICULOS.ART_CODIGO)WHERE sorweb.STK_RUBROS.RUB_CODIGO = " + rubro + " AND sorweb.STK_SUBRUBROS.SRB_CODIGO = " + subrubro + " AND  sorweb.STK_LISTA_PRECIOS_ART.LST_CODIGO= 2 GROUP BY SorWeb.STK_ARTICULOS.EMP_CODIGO, SorWeb.STK_ARTICULOS.ART_CODIGO, SorWeb.STK_ARTICULOS.ART_REFERENCIA,SorWeb.STK_ARTICULOS.ART_NOMBRE, SorWeb.STK_ARTICULOS.RUB_CODIGO, SorWeb.STK_RUBROS.RUB_NOMBRE, SorWeb.STK_ARTICULOS.SRB_CODIGO,SorWeb.STK_SUBRUBROS.SRB_NOMBRE, SorWeb.STK_ARTICULOS.ART_UND_CONSUMO, SorWeb.STK_UNIDADES.UND_NOMBRE,SorWeb.STK_LISTA_PRECIOS_ART.LST_PRECIO1, SorWeb.STK_ARTICULOS.ART_PUBLICO, SorWeb.STK_LISTA_PRECIOS_ART.LST_CODIGO,SorWeb.STK_ARTICULOS.ART_UND_BULTO, SorWeb.STK_ARTICULOS.ART_ENVASE order by sorweb.STK_ARTICULOS.ART_CODIGO")

    End Function
    Public Shared Function SelectArtVerPedido(ByVal codipedido As String) As DataSet
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@codipedido", codipedido))
        Return db.ExecuteDataSet(" Select  A.ART_CODIGO,A.ART_NOMBRE,A.RUB_CODIGO,A.SRB_CODIGO,A.ART_UND_CONSUMO,PA.LST_PRECIO1 ,LIC_CANTIDAD From SorWeb.STK_ARTICULOS A INNER Join SorWeb.STK_LISTA_PRECIOS_ART PA ON A.ART_CODIGO=PA.ART_CODIGO And PA.LST_CODIGO=2 inner Join [SorWeb].[STK_CARRITO_LINEAS] t1 on a.ART_CODIGO=t1.ART_CODIGO   WHERE [CAR_CODIGO] = " + codipedido + " And A.ART_CODIGO in(select ART_CODIGO from [SorWeb].[STK_CARRITO_LINEAS] where[CAR_CODIGO]=" + codipedido + ") order by a.ART_NOMBRE ")

    End Function


    Public Shared Function SelectArtInd(ByVal rubro As String, ByVal subrubro As String, ByVal codart As String) As ArticulosCart
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@rubro", rubro))
        db.Parameters.Add(New SqlParameter("@subrubro", subrubro))
        db.Parameters.Add(New SqlParameter("@codart", codart))

        Dim dr As SqlDataReader = CType(db.ExecuteReader("Select  SorWeb.STK_ARTICULOS.EMP_CODIGO, SorWeb.STK_ARTICULOS.ART_CODIGO, SorWeb.STK_ARTICULOS.ART_NOMBRE, SorWeb.STK_ARTICULOS.RUB_CODIGO,SorWeb.STK_ARTICULOS.SRB_CODIGO, SorWeb.STK_ARTICULOS.ART_UND_CONSUMO, SorWeb.STK_ARTICULOS.ART_UND_BULTO / 100 As ART_UND_BULTO,SorWeb.STK_ARTICULOS.ART_ENVASE  / 100 As ART_ENVASE, SorWeb.STK_LISTA_PRECIOS_ART.LST_CODIGO, SorWeb.STK_LISTA_PRECIOS_ART.LST_PRECIO1, CAST(0 As int) As CANTIDAD FROM SorWeb.STK_LISTA_PRECIOS_ART INNER JOIN SorWeb.STK_UNIDADES INNER JOIN SorWeb.STK_RUBROS INNER JOIN SorWeb.STK_SUBRUBROS On SorWeb.STK_RUBROS.EMP_CODIGO = SorWeb.STK_SUBRUBROS.EMP_CODIGO And SorWeb.STK_RUBROS.RUB_CODIGO = SorWeb.STK_SUBRUBROS.RUB_CODIGO INNER JOIN SorWeb.STK_ARTICULOS On SorWeb.STK_SUBRUBROS.EMP_CODIGO = SorWeb.STK_ARTICULOS.EMP_CODIGO And SorWeb.STK_SUBRUBROS.RUB_CODIGO = SorWeb.STK_ARTICULOS.RUB_CODIGO And SorWeb.STK_SUBRUBROS.SRB_CODIGO = SorWeb.STK_ARTICULOS.SRB_CODIGO On SorWeb.STK_UNIDADES.UND_CODIGO = SorWeb.STK_ARTICULOS.ART_UND_CONSUMO And SorWeb.STK_UNIDADES.EMP_CODIGO = SorWeb.STK_ARTICULOS.EMP_CODIGO On SorWeb.STK_LISTA_PRECIOS_ART.EMP_CODIGO = SorWeb.STK_ARTICULOS.EMP_CODIGO And SorWeb.STK_LISTA_PRECIOS_ART.ART_CODIGO = SorWeb.STK_ARTICULOS.ART_CODIGO WHERE     (SorWeb.STK_RUBROS.RUB_CODIGO =" + rubro + ") And (SorWeb.STK_SUBRUBROS.SRB_CODIGO = " + subrubro + ") And (SorWeb.STK_LISTA_PRECIOS_ART.LST_CODIGO = 2) And (SorWeb.STK_ARTICULOS.ART_CODIGO = " + "'" + codart + "'" + ")GROUP BY SorWeb.STK_ARTICULOS.EMP_CODIGO, SorWeb.STK_ARTICULOS.ART_CODIGO, SorWeb.STK_ARTICULOS.ART_NOMBRE, SorWeb.STK_ARTICULOS.RUB_CODIGO, SorWeb.STK_ARTICULOS.SRB_CODIGO, SorWeb.STK_ARTICULOS.ART_UND_CONSUMO, SorWeb.STK_ARTICULOS.ART_UND_BULTO, SorWeb.STK_ARTICULOS.ART_ENVASE, SorWeb.STK_LISTA_PRECIOS_ART.LST_CODIGO, SorWeb.STK_LISTA_PRECIOS_ART.LST_PRECIO1 ORDER BY SorWeb.STK_ARTICULOS.EMP_CODIGO, SorWeb.STK_ARTICULOS.ART_CODIGO, SorWeb.STK_ARTICULOS.ART_NOMBRE,SorWeb.STK_ARTICULOS.RUB_CODIGO, SorWeb.STK_ARTICULOS.SRB_CODIGO, SorWeb.STK_ARTICULOS.ART_UND_CONSUMO, SorWeb.STK_ARTICULOS.ART_UND_BULTO, SorWeb.STK_ARTICULOS.ART_ENVASE, SorWeb.STK_LISTA_PRECIOS_ART.LST_CODIGO, SorWeb.STK_LISTA_PRECIOS_ART.LST_PRECIO1"), SqlDataReader)


        If dr.HasRows Then
            Dim objCart As ArticulosCart = New ArticulosCart
            While dr.Read
                objCart.EMP_CODIGO = dr.GetInt16(dr.GetOrdinal("EMP_CODIGO"))
                objCart.ART_CODIGO = dr.GetString(dr.GetOrdinal("ART_CODIGO"))
                If Not dr.IsDBNull(dr.GetOrdinal("ART_NOMBRE")) Then
                    objCart.ART_NOMBRE = dr.GetString(dr.GetOrdinal("ART_NOMBRE"))
                End If
                If Not dr.IsDBNull(dr.GetOrdinal("RUB_CODIGO")) Then
                    objCart.RUB_CODIGO = dr.GetInt16(dr.GetOrdinal("RUB_CODIGO"))
                End If
                If Not dr.IsDBNull(dr.GetOrdinal("SRB_CODIGO")) Then
                    objCart.SRB_CODIGO = dr.GetInt16(dr.GetOrdinal("SRB_CODIGO"))
                End If
                If Not dr.IsDBNull(dr.GetOrdinal("ART_UND_CONSUMO")) Then
                    objCart.ART_UND_CONSUMO = dr.GetString(dr.GetOrdinal("ART_UND_CONSUMO"))
                End If
                If Not dr.IsDBNull(dr.GetOrdinal("ART_UND_BULTO")) Then
                    objCart.ART_UND_BULTO = dr.GetInt32(dr.GetOrdinal("ART_UND_BULTO"))
                End If
                If Not dr.IsDBNull(dr.GetOrdinal("ART_ENVASE")) Then
                    objCart.ART_ENVASE = dr.GetInt32(dr.GetOrdinal("ART_ENVASE"))
                End If
                If Not dr.IsDBNull(dr.GetOrdinal("LST_CODIGO")) Then
                    objCart.LST_CODIGO = dr.GetInt16(dr.GetOrdinal("LST_CODIGO"))
                End If
                If Not dr.IsDBNull(dr.GetOrdinal("LST_PRECIO1")) Then
                    objCart.LST_PRECIO1 = dr.GetDecimal(dr.GetOrdinal("LST_PRECIO1"))
                End If


            End While

            dr.Close()
            Return objCart
        Else
            dr.Close()
            Return New ArticulosCart
        End If
    End Function



    Public Shared Function SelectArtInd(ByVal codart As String) As ArticulosCart
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@codart", codart))

        Dim dr As SqlDataReader = CType(db.ExecuteReader("SELECT SorWeb.STK_ARTICULOS.EMP_CODIGO, SorWeb.STK_ARTICULOS.ART_CODIGO, SorWeb.STK_ARTICULOS.ART_NOMBRE, SorWeb.STK_ARTICULOS.RUB_CODIGO,SorWeb.STK_ARTICULOS.SRB_CODIGO, SorWeb.STK_ARTICULOS.ART_UND_CONSUMO, SorWeb.STK_ARTICULOS.ART_UND_BULTO / 100 AS ART_UND_BULTO,SorWeb.STK_ARTICULOS.ART_ENVASE  / 100 AS ART_ENVASE, SorWeb.STK_LISTA_PRECIOS_ART.LST_CODIGO, SorWeb.STK_LISTA_PRECIOS_ART.LST_PRECIO1, CAST(0 AS int) AS CANTIDAD FROM SorWeb.STK_LISTA_PRECIOS_ART INNER JOIN SorWeb.STK_UNIDADES INNER JOIN SorWeb.STK_RUBROS INNER JOIN SorWeb.STK_SUBRUBROS ON SorWeb.STK_RUBROS.EMP_CODIGO = SorWeb.STK_SUBRUBROS.EMP_CODIGO AND SorWeb.STK_RUBROS.RUB_CODIGO = SorWeb.STK_SUBRUBROS.RUB_CODIGO INNER JOIN SorWeb.STK_ARTICULOS ON SorWeb.STK_SUBRUBROS.EMP_CODIGO = SorWeb.STK_ARTICULOS.EMP_CODIGO AND SorWeb.STK_SUBRUBROS.RUB_CODIGO = SorWeb.STK_ARTICULOS.RUB_CODIGO AND SorWeb.STK_SUBRUBROS.SRB_CODIGO = SorWeb.STK_ARTICULOS.SRB_CODIGO ON SorWeb.STK_UNIDADES.UND_CODIGO = SorWeb.STK_ARTICULOS.ART_UND_CONSUMO AND SorWeb.STK_UNIDADES.EMP_CODIGO = SorWeb.STK_ARTICULOS.EMP_CODIGO ON SorWeb.STK_LISTA_PRECIOS_ART.EMP_CODIGO = SorWeb.STK_ARTICULOS.EMP_CODIGO AND SorWeb.STK_LISTA_PRECIOS_ART.ART_CODIGO = SorWeb.STK_ARTICULOS.ART_CODIGO WHERE (SorWeb.STK_LISTA_PRECIOS_ART.LST_CODIGO = 2) AND (SorWeb.STK_ARTICULOS.ART_CODIGO = " + "'" + codart + "'" + ")GROUP BY SorWeb.STK_ARTICULOS.EMP_CODIGO, SorWeb.STK_ARTICULOS.ART_CODIGO, SorWeb.STK_ARTICULOS.ART_NOMBRE, SorWeb.STK_ARTICULOS.RUB_CODIGO, SorWeb.STK_ARTICULOS.SRB_CODIGO, SorWeb.STK_ARTICULOS.ART_UND_CONSUMO, SorWeb.STK_ARTICULOS.ART_UND_BULTO, SorWeb.STK_ARTICULOS.ART_ENVASE, SorWeb.STK_LISTA_PRECIOS_ART.LST_CODIGO, SorWeb.STK_LISTA_PRECIOS_ART.LST_PRECIO1 ORDER BY SorWeb.STK_ARTICULOS.ART_CODIGO "), SqlDataReader)

        If dr.HasRows Then
            Dim objCart As ArticulosCart = New ArticulosCart
            While dr.Read
                objCart.EMP_CODIGO = dr.GetInt16(dr.GetOrdinal("EMP_CODIGO"))
                objCart.ART_CODIGO = dr.GetString(dr.GetOrdinal("ART_CODIGO"))
                If Not dr.IsDBNull(dr.GetOrdinal("ART_NOMBRE")) Then
                    objCart.ART_NOMBRE = dr.GetString(dr.GetOrdinal("ART_NOMBRE"))
                End If
                If Not dr.IsDBNull(dr.GetOrdinal("RUB_CODIGO")) Then
                    objCart.RUB_CODIGO = dr.GetInt16(dr.GetOrdinal("RUB_CODIGO"))
                End If
                If Not dr.IsDBNull(dr.GetOrdinal("SRB_CODIGO")) Then
                    objCart.SRB_CODIGO = dr.GetInt16(dr.GetOrdinal("SRB_CODIGO"))
                End If
                If Not dr.IsDBNull(dr.GetOrdinal("ART_UND_CONSUMO")) Then
                    objCart.ART_UND_CONSUMO = dr.GetString(dr.GetOrdinal("ART_UND_CONSUMO"))
                End If
                If Not dr.IsDBNull(dr.GetOrdinal("ART_UND_BULTO")) Then
                    objCart.ART_UND_BULTO = dr.GetInt32(dr.GetOrdinal("ART_UND_BULTO"))
                End If
                If Not dr.IsDBNull(dr.GetOrdinal("ART_ENVASE")) Then
                    objCart.ART_ENVASE = dr.GetInt32(dr.GetOrdinal("ART_ENVASE"))
                End If
                If Not dr.IsDBNull(dr.GetOrdinal("LST_CODIGO")) Then
                    objCart.LST_CODIGO = dr.GetInt16(dr.GetOrdinal("LST_CODIGO"))
                End If
                If Not dr.IsDBNull(dr.GetOrdinal("LST_PRECIO1")) Then
                    objCart.LST_PRECIO1 = dr.GetDecimal(dr.GetOrdinal("LST_PRECIO1"))
                End If


            End While

            dr.Close()
            Return objCart
        Else
            dr.Close()
            Return New ArticulosCart
        End If
    End Function

    Public Shared Function SelectArticulos() As DataSet
        Dim db As DBAccess = New DBAccess


        Return db.ExecuteDataSet("select t1.ART_CODIGO,t1.ART_NOMBRE,t1.ART_UND_CONSUMO,t2.UND_NOMBRE,t3.LST_PRECIO1,t1.ART_UND_BULTO / 100 AS ART_UND_BULTO ,t1.ART_ENVASE / 100 AS ART_ENVASE,CAST(0 AS int) AS CANTIDAD  from SorWeb.STK_ARTICULOS t1 inner join SorWeb.STK_UNIDADES t2 " &
                                 " ON t1.ART_UND_CONSUMO  = t2.UND_CODIGO inner join SorWeb.STK_LISTA_PRECIOS_ART t3 " &
                                 " ON t1.art_codigo  = t3.art_codigo where t3.lst_codigo=2  and t1.ART_indice >=0 and t1.ART_indice <= 500 order by t1.ART_CODIGO ")
    End Function
    Public Shared Function SelectArticulos1() As DataSet
        Dim db As DBAccess = New DBAccess

        Return db.ExecuteDataSet(" select t1.ART_CODIGO,t1.ART_NOMBRE,t1.ART_UND_CONSUMO,t2.UND_NOMBRE,t3.LST_PRECIO1,t1.ART_UND_BULTO / 100 AS ART_UND_BULTO ,t1.ART_ENVASE / 100 AS ART_ENVASE,CAST(0 AS int) AS CANTIDAD  from SorWeb.STK_ARTICULOS t1 inner join SorWeb.STK_UNIDADES t2 " &
                                 " ON t1.ART_UND_CONSUMO  = t2.UND_CODIGO inner join SorWeb.STK_LISTA_PRECIOS_ART t3 " &
                                 " ON t1.art_codigo  = t3.art_codigo where t3.lst_codigo=2 and t1.ART_indice >500 and t1.ART_indice <= 1000  order by t1.ART_CODIGO ")
    End Function
    Public Shared Function SelectArticulos2() As DataSet
        Dim db As DBAccess = New DBAccess

        'Return db.ExecuteDataSet("SELECT SorWeb.STK_ARTICULOS.ART_CODIGO, SorWeb.STK_ARTICULOS.ART_NOMBRE, SorWeb.STK_ARTICULOS.ART_UND_CONSUMO,  SorWeb.STK_UNIDADES.UND_NOMBRE, SorWeb.STK_LISTA_PRECIOS_ART.LST_PRECIO1, SorWeb.STK_ARTICULOS.ART_UND_BULTO / 100 AS ART_UND_BULTO,SorWeb.STK_ARTICULOS.ART_ENVASE / 100 AS ART_ENVASE,  CAST(0 AS int) AS CANTIDAD FROM SorWeb.STK_LISTA_PRECIOS_ART INNER JOIN SorWeb.STK_UNIDADES INNER JOIN SorWeb.STK_RUBROS INNER JOIN SorWeb.STK_SUBRUBROS ON SorWeb.STK_RUBROS.EMP_CODIGO = SorWeb.STK_SUBRUBROS.EMP_CODIGO AND SorWeb.STK_RUBROS.RUB_CODIGO = SorWeb.STK_SUBRUBROS.RUB_CODIGO INNER JOIN SorWeb.STK_ARTICULOS ON SorWeb.STK_SUBRUBROS.EMP_CODIGO = SorWeb.STK_ARTICULOS.EMP_CODIGO AND SorWeb.STK_SUBRUBROS.RUB_CODIGO = SorWeb.STK_ARTICULOS.RUB_CODIGO AND SorWeb.STK_SUBRUBROS.SRB_CODIGO = SorWeb.STK_ARTICULOS.SRB_CODIGO ON SorWeb.STK_UNIDADES.UND_CODIGO = SorWeb.STK_ARTICULOS.ART_UND_CONSUMO AND SorWeb.STK_UNIDADES.EMP_CODIGO = SorWeb.STK_ARTICULOS.EMP_CODIGO ON SorWeb.STK_LISTA_PRECIOS_ART.EMP_CODIGO = SorWeb.STK_ARTICULOS.EMP_CODIGO AND SorWeb.STK_LISTA_PRECIOS_ART.ART_CODIGO = SorWeb.STK_ARTICULOS.ART_CODIGO INNER JOIN SorWeb.STK_PEDIDOS_LINEAS ON SorWeb.STK_ARTICULOS.ART_CODIGO = SorWeb.STK_PEDIDOS_LINEAS.ART_CODIGO WHERE(SorWeb.STK_LISTA_PRECIOS_ART.LST_CODIGO = 2) GROUP BY SorWeb.STK_ARTICULOS.ART_CODIGO, SorWeb.STK_ARTICULOS.ART_NOMBRE, SorWeb.STK_ARTICULOS.ART_UND_CONSUMO,SorWeb.STK_UNIDADES.UND_NOMBRE, SorWeb.STK_LISTA_PRECIOS_ART.LST_PRECIO1, SorWeb.STK_ARTICULOS.ART_UND_BULTO,SorWeb.STK_ARTICULOS.ART_ENVASE ORDER BY SorWeb.STK_ARTICULOS.ART_NOMBRE")
        Return db.ExecuteDataSet(" select t1.ART_CODIGO,t1.ART_NOMBRE,t1.ART_UND_CONSUMO,t2.UND_NOMBRE,t3.LST_PRECIO1,t1.ART_UND_BULTO / 100 AS ART_UND_BULTO ,t1.ART_ENVASE / 100 AS ART_ENVASE,CAST(0 AS int) AS CANTIDAD  from SorWeb.STK_ARTICULOS t1 inner join SorWeb.STK_UNIDADES t2 " &
                               " ON t1.ART_UND_CONSUMO  = t2.UND_CODIGO inner join SorWeb.STK_LISTA_PRECIOS_ART t3 " &
                               " ON t1.art_codigo  = t3.art_codigo where t3.lst_codigo=2 and t1.ART_indice >1000 and t1.ART_indice <= 1500  order by t1.ART_CODIGO ")
    End Function
    Public Shared Function SelectArticulos3() As DataSet
        Dim db As DBAccess = New DBAccess

        'Return db.ExecuteDataSet("SELECT SorWeb.STK_ARTICULOS.ART_CODIGO, SorWeb.STK_ARTICULOS.ART_NOMBRE, SorWeb.STK_ARTICULOS.ART_UND_CONSUMO,  SorWeb.STK_UNIDADES.UND_NOMBRE, SorWeb.STK_LISTA_PRECIOS_ART.LST_PRECIO1, SorWeb.STK_ARTICULOS.ART_UND_BULTO / 100 AS ART_UND_BULTO,SorWeb.STK_ARTICULOS.ART_ENVASE / 100 AS ART_ENVASE,  CAST(0 AS int) AS CANTIDAD FROM SorWeb.STK_LISTA_PRECIOS_ART INNER JOIN SorWeb.STK_UNIDADES INNER JOIN SorWeb.STK_RUBROS INNER JOIN SorWeb.STK_SUBRUBROS ON SorWeb.STK_RUBROS.EMP_CODIGO = SorWeb.STK_SUBRUBROS.EMP_CODIGO AND SorWeb.STK_RUBROS.RUB_CODIGO = SorWeb.STK_SUBRUBROS.RUB_CODIGO INNER JOIN SorWeb.STK_ARTICULOS ON SorWeb.STK_SUBRUBROS.EMP_CODIGO = SorWeb.STK_ARTICULOS.EMP_CODIGO AND SorWeb.STK_SUBRUBROS.RUB_CODIGO = SorWeb.STK_ARTICULOS.RUB_CODIGO AND SorWeb.STK_SUBRUBROS.SRB_CODIGO = SorWeb.STK_ARTICULOS.SRB_CODIGO ON SorWeb.STK_UNIDADES.UND_CODIGO = SorWeb.STK_ARTICULOS.ART_UND_CONSUMO AND SorWeb.STK_UNIDADES.EMP_CODIGO = SorWeb.STK_ARTICULOS.EMP_CODIGO ON SorWeb.STK_LISTA_PRECIOS_ART.EMP_CODIGO = SorWeb.STK_ARTICULOS.EMP_CODIGO AND SorWeb.STK_LISTA_PRECIOS_ART.ART_CODIGO = SorWeb.STK_ARTICULOS.ART_CODIGO INNER JOIN SorWeb.STK_PEDIDOS_LINEAS ON SorWeb.STK_ARTICULOS.ART_CODIGO = SorWeb.STK_PEDIDOS_LINEAS.ART_CODIGO WHERE(SorWeb.STK_LISTA_PRECIOS_ART.LST_CODIGO = 2) GROUP BY SorWeb.STK_ARTICULOS.ART_CODIGO, SorWeb.STK_ARTICULOS.ART_NOMBRE, SorWeb.STK_ARTICULOS.ART_UND_CONSUMO,SorWeb.STK_UNIDADES.UND_NOMBRE, SorWeb.STK_LISTA_PRECIOS_ART.LST_PRECIO1, SorWeb.STK_ARTICULOS.ART_UND_BULTO,SorWeb.STK_ARTICULOS.ART_ENVASE ORDER BY SorWeb.STK_ARTICULOS.ART_NOMBRE")
        Return db.ExecuteDataSet(" select t1.ART_CODIGO,t1.ART_NOMBRE,t1.ART_UND_CONSUMO,t2.UND_NOMBRE,t3.LST_PRECIO1,t1.ART_UND_BULTO / 100 AS ART_UND_BULTO ,t1.ART_ENVASE / 100 AS ART_ENVASE,CAST(0 AS int) AS CANTIDAD  from SorWeb.STK_ARTICULOS t1 inner join SorWeb.STK_UNIDADES t2 " &
                                   " ON t1.ART_UND_CONSUMO  = t2.UND_CODIGO inner join SorWeb.STK_LISTA_PRECIOS_ART t3 " &
                                   " ON t1.art_codigo  = t3.art_codigo where t3.lst_codigo=2 and t1.ART_indice >1500 order by t1.ART_CODIGO ")
    End Function
    Public Shared Function DeleteArticuloCarro(ByVal art_codigo As String, CAR_CODIGO As String) As Integer
        Dim db As DBAccess = New DBAccess
        db.Parameters.Add(New SqlParameter("@art_codigo", art_codigo))
        db.Parameters.Add(New SqlParameter("@CAR_CODIGO", CAR_CODIGO))

        Dim retval As Integer = db.ExecuteNonQuery("DELETE FROM SorWeb.STK_CARRITO_LINEAS WHERE art_codigo=@art_codigo and CAR_CODIGO=@CAR_CODIGO ")
        If retval <> 1 Then
            Return -1
            Exit Function
        End If

        Return 1
    End Function
End Class
