<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterEsoriano.Master" CodeBehind="ProductoRubroCelu.aspx.vb" Inherits="Esoriano.ProductoRubroCelu" %>
<%@ Register Src="~/WebControl/WebUserControlCabecera.ascx" TagName="Cabecera" TagPrefix="Cab" %>
<%@ Register Src="~/WebControl/WebUserControlNovedades.ascx" TagName="Novedades" TagPrefix="Nov" %>
<%@ Register Src="~/WebControl/WebUserControlNoveSL.ascx" TagName="NoveSL" TagPrefix="Nov" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
        .list-group a{
            text-decoration :none;
            color:darkred;
         }
        .breadcrumb-item a{
            font-weight: bold;
            text-decoration :none;
            color:black;
        }
       
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLogoPedidos" runat="server">
       <Cab:Cabecera ID="Cabecera" runat="server" />  
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <nav aria-label="breadcrumb">
          <ol class="breadcrumb">
            <li class="breadcrumb-item ">
               <a href="Pedidos.aspx">PEDIDOS</a>
            </li>
            <li class="breadcrumb-item disable" "><a href="#">TODOS LOS RUBROS</a></li>
          </ol>
        </nav>
        <div class="row">
            <div class="col-12  col-lg-6 ">
                <div class="list-group">
                    <a class="list-group-item disabled badge-dark " style="font-weight:bold;color:floralwhite;background-color:darkred"> Rubro Nombre </a>
                    <asp:DataList ID="DataListRubros" runat="server"  >
                       <ItemTemplate>
                          <a  href="SubRubroCelu.aspx?Rub=<%# Eval("RUB_CODIGO") %>" class="list-group-item  " id="list-home-list"  ><%# Eval("RUB_NOMBRE") %> 
                              <%--<asp:Image id="myImage"  runat="server"  Height="23"  ImageUrl='<%# DataBinder.Eval(Container, "DataItem.RUB_IMAGEN", "~/IMG/rubros/{0}")%>'>    
                              </asp:Image >--%>
                         </a>
                     
                       </ItemTemplate>
                   </asp:DataList>
               </div>
            </div>
         </div>
     </div>
</asp:Content>
