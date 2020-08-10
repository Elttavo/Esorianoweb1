<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterEsoriano.Master" CodeBehind="SubRubroCelu.aspx.vb" Inherits="Esoriano.SubRubroCelu" %>
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

          <asp:FormView runat="server" ID="FormViewPath1" EnableModelValidation="True"  Width="100%"   >
         <ItemTemplate>
            <ol class="breadcrumb">
                 <li class="breadcrumb-item ">
                    <a href="Pedidos.aspx">PEDIDOS</a>
                </li>
                <li class="breadcrumb-item ">
                    <a href="ProductoRubroCelu.aspx">RUBROS</a>
                </li>
                <li class="breadcrumb-item ">
                     <a > <%# Eval("RUB_NOMBRE")%></a>
                </li>
            </ol>
        </ItemTemplate>
      </asp:FormView>
      <div class="row">
      <div class="col-12  col-lg-6 ">
        <div class="list-group">
             <a class="list-group-item disabled badge-dark " style="font-weight:bold;color:floralwhite;background-color:darkred">Sub.Rub Nombre </a>
            <asp:DataList ID="datalistSubRubros" runat="server" >
                <ItemTemplate>
                     <a  href="RubroCelu.aspx?Rub=<%# Eval("RUB_CODIGO") %> &amp;Sub=<%# Eval("SRB_CODIGO") %> " class="list-group-item  " id="list-home-list"  ><%# Eval("SRB_NOMBRE")%></a>
               </ItemTemplate>
                   
            </asp:DataList>   
        </div>
      </div>
    </div>
 </div>
</asp:Content>
