<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterEsorianoLogeado.Master" CodeBehind="PedidoTerminado.aspx.vb" Inherits="Esoriano.PedidoTerminado" %>
<%@ Register Src="~/WebControl/WebUserControlCabecera.ascx" TagName="Cabecera" TagPrefix="Cab" %>
<%@ Register Src="~/WebControl/WebUserControlNovedades.ascx" TagName="Novedades" TagPrefix="Nov" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .labelpedido
        {
            Font-Size:55px;
           color:snow;
           background-color:brown;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLogoPedidos" runat="server">
      <Cab:Cabecera ID="Cabecera" runat="server" />   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderCuerpo" runat="server">
     <div class="row-cols-10 ">
     
        <div id="divbody">
            <div id="divh1">
                <h2>
                    Pedido generado con éxito</h2>
            </div>
            <div class="nav-justified">
                <asp:Panel ID="PanelPdeidoGen" runat="server"  HorizontalAlign="Center" >
                     <hr />
                    <div style="font-weight: bold">Número provisorio de confirmación:
                        <hr />
                        <asp:Label ID="Label2"  class="labelpedido" runat="server" Text="Label" /></div><br />
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="Bot-Linkbutton" Height="20px"
                        PostBackUrl="~/pedidos.aspx" Visible="False">Continuar</asp:LinkButton>
                <hr />
                </asp:Panel>
                <div id="mail">
                    <asp:Panel ID="Panel1" runat="server" 
                        CssClass="panelmensaje" Height="317px"  HorizontalAlign="Center" >
                    <p class="style9"><strong><span class="style8">Envíe un mail para dar aviso de su pedido a la Empresa</span></strong></p>

                            <table id= "tabla1" class="table table-sl table-striped">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text="Label">Dirección de mail del cliente   </asp:Label>
                                    </td>
                                    <td >
                                        <asp:TextBox ID="Text_dire_mail"  Width="80%" runat="server" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="Label">Número de pedido   </asp:Label>
                                    </td>
                                    <td class="style11">
                                        <asp:TextBox ID="Textnumeropedido" runat="server"  Width="80%" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                  <td>  Número de cliente</td>
                                    <td >
                                        <asp:TextBox ID="Textnumerocliente" runat="server" Width="80%" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td >
                                        </td>
                                    <td class="auto-style6">
                                        <asp:TextBox ID="Textnumeropedido1" runat="server" Height="46px" 
                                            Width="173px" TextMode="MultiLine" Enabled="False" Visible="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td ">
                                        <asp:Button ID="Button1" runat="server" Class="btn btn-outline-danger" Text="Enviar" Width="74px" 
                                            />
                                    </td>
                                    <td >
                                          <asp:Label ID="lblerror" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                    </asp:Panel>
                
        </div>
            </div>
            <asp:Panel ID="Panel2" runat="server" HorizontalAlign="Center"
                        CssClass="panelmensaje" Height="100px" Visible="False" >
                        <asp:Image ID="Imgcorreo" runat="server" Height="100px" 
                            ImageUrl="~/img/correo/correos.jpeg" Visible="False" />
                </asp:Panel>       
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderNovedades" runat="server">
  
    <Nov:Novedades ID="Novedades" runat="server" />
</asp:Content>
