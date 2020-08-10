<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterEsorianoLogeado.Master" CodeBehind="ConsConVent.aspx.vb" Inherits="Esoriano.ConsConVent" %>
<%@ Register Src="~/WebControl/WebUserControlCabecera.ascx" TagName="Cabecera" TagPrefix="Cab" %>
<%@ Register Src="~/WebControl/WebUserControlNovedades.ascx" TagName="Novedades" TagPrefix="Nov" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLogoPedidos" runat="server">
        <Cab:Cabecera ID="Cabecera" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderCuerpo" runat="server">
  <div class="row-cols-10">
            
            <div class="col-md-12">
                <h3>
                    Condición de Pagos</h3>
            </div>
      <hr />
            <div  class="table-responsive" style="padding-top: 40px" >
                <asp:Panel ID="Panel1" runat="server">
                    <table Class="table table-sm table-striped " >
                        <tr>
                            <td  align="center" >
                                <asp:BulletedList ID="BulletedList1" runat="server" Font-Bold="True" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
               
                <div style="padding-top: 40px ; text-align-last:center" >
                <asp:LinkButton ID="LinkButtonVolverRubros" runat="server" PostBackUrl="~/pedidos.aspx"
                      Height="20px">Volver atras...</asp:LinkButton></div>
            </div>
        </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderNovedades" runat="server">
      <Nov:Novedades ID="Novedades" runat="server" />
</asp:Content>
