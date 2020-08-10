<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterEsoriano.Master" CodeBehind="Rubro.aspx.vb" Inherits="Esoriano.Rubro" %>
<%@ Register Src="~/WebControl/WebUserControlCabecera.ascx" TagName="Cabecera" TagPrefix="Cab" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <style>  
.fixed-top-2 {
    margin-top: 55px;
}


body {
    padding-top: 220px;
}
.art_imputcant
{
    font-family: Tahoma;
    font-size: 9pt;
    color: #000000;
  
}
@media screen and (max-width: 600px) {
        table {
           width:90%;
       }
       thead {
           display: none;
       }
       tr:nth-of-type(2n) {
           background-color: inherit;
       }
       tr td:first-child {
           background: black;
           font-weight:bold;
           font-size:1em;
           color:aliceblue;
       }
       tbody td {
           display: block;
           text-align:center;
       }
       tbody td:before {
           content: attr(data-th);
           display: block;
           text-align:center;
       }
       

}

</style>
    <script type="text/javascript">

                //window.location.href = "pedidos.aspx";
         

        window.onload = function () {
            noBack();
       }
        function noBack() {
            
            window.history.forward();
       }
    </script>
</asp:Content>

<asp:Content ID="content2" ContentPlaceHolderID="ContentPlaceHolderLogoPedidos" runat="server">
        <div class="fixed-top fixed-top-2">
            <Cab:Cabecera ID="cab" runat="server" />
        </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container col-10">
        <asp:FormView runat="server" ID="FormViewPath1" EnableModelValidation="True"  Width="100%"   >
            <ItemTemplate>
                <ol class="breadcrumb">
                    <li class="breadcrumb-item">
                        <a href="Pedidos.aspx">PEDIDOS</a>
                    </li>
                    <li class="breadcrumb-item">
                        <a href="productoRubro.aspx"><%# Eval("RUB_NOMBRE")%></a>
                    </li>
                     <li class="breadcrumb-item active"><%# Eval("SRB_NOMBRE")%>
                     <li>
                </ol>
            </ItemTemplate>
        </asp:FormView>
    <!-- Image Header -->
        <asp:Panel ID="Panel1" runat="server" Visible="TRUE">
            <div  align="center" >
                <asp:ImageButton ID="ImageButton5" runat="server" 
                            ImageUrl="~/img/botones/upload.jpg" Width="48px"  
                            height="22px" ImageAlign="Right" />
                 
             </div>
             <br />
         </asp:Panel>
         <div class="row">
	        <div class="col">         
                <table class="table ">
                    <thead  class="table-dark">
                        <tr>
                            <th >Articulos</th>
                            <th > Nombre</th>
                            <th > U.Env.</th>
                            <th >U. Bulto</th>
                            <th >Unidad</th>
                            <th >Precio</th>
                            <th >Cantidad</th>
                            <%--<th scope="col"">Opciones</th>--%>
                        </tr>
                    </thead>
                    <asp:DataList runat="server" ID="DataListArtLogin" SkinID="Producto1" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="row" >
                        <ItemTemplate>
                            <tbody class="table table-secondary " >                           
                                <tr >
                                    <td runat="server" id="codart" >
                                        <%# Eval("ART_CODIGO") %>
                                    </td>
                                    <td >
                                        <%# Eval("ART_NOMBRE") %>
                                    </td>
                                    <td >
                                         <%# Eval("ART_ENVASE") %>
                                    </td>
                                    <td>
                                         <%# Eval("ART_UND_BULTO") %>
                                    </td>
                                    <td>
                                         <%# Eval("UND_NOMBRE") %>
                                    </td>
                                    <td>
                                        $ <%# Eval("LST_PRECIO1") %>
                                    </td>
                                    <td>
                                       <asp:TextBox runat="server" ID="txtCantidad" CssClass="art_imputcant" 
                                                    Text='<%# BIND("CANTIDAD") %>' Width="33%"  />
                                                    <asp:RegularExpressionValidator id="valida_Cantidad" runat="SERVER" 
                                                    ControlToValidate="txtCantidad" ErrorMessage="Solo Num." ValidationExpression="\d*\.?\d*" Font-Size="XX-Small">
                                       </asp:RegularExpressionValidator> 
                                    </td>
                                
                            <%--    <td  style="padding-right: 5px">
                                    <img src="images/enter.gif" alt=""/>
                                </td>
                                <td align="center" hidefocus="hidefocus" tabindex="-1">
                                    <a href="imagen.aspx?art_codigo=<%# Eval("ART_CODIGO") %>&amp;rub=<%# Eval("RUB_CODIGO") %>&amp;srb=<%# Eval("SRB_CODIGO")%> "
                                        class="art_link" tabindex="-1">Imagen</a>
                                </td>--%>
                                
                              </tr>
                            </tbody>
                        </ItemTemplate>
                        <FooterTemplate>
                            <table >
                              <tr>
                                  <th style="width:90%" >
                                      Cantidad de Artículos:
                                      <asp:Label runat="server" ID="Contador2" />
                                </th>
                            </tr>
                          </table>
                        </FooterTemplate>
                    </asp:DataList>
                </table> 
            </div>
        </div>
    </div>

    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="SelectArtall" TypeName="ClassLibrary1.ArticulosCart">
    </asp:ObjectDataSource>
  
</asp:Content>

