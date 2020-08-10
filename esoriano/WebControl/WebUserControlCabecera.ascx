<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="~/WebControl/WebUserControlCabecera.ascx" Inherits="Esoriano.WebUserControlCabecera" %>
<style type="text/css">
    .auto-style1 {
        width: 445px;
    }
    .mytable{
        background-image: url('../img/cabecera/cabeza03.jpg');
        background-repeat:no-repeat;
        height: 159px;
        width:100%;
        }
    .caja{
     
      padding-bottom:10px;
    }
 
@media screen and (max-width: 800px) {
  .mytable {
      background-image:none;
    background-color: black;

  }
  .caja{
      padding-bottom:10px;

  }
}
</style>
<div class="caja">

    <table class="mytable">
        <tr>
              <td align="right"class="auto-style1" >
                                <asp:Panel ID="PanelCarritoUser" runat="server">
                                        
                                    <table>
                                        <tr>                                              
                                            <td align="right"  class="items" style="padding-right: 5px; padding-left: 5px;">
                                                <asp:Label ID="Label1" runat="server" Text="Total Gastos:" ForeColor="#FFFFFF "></asp:Label>
                                                <asp:Label ID="Labelpesos" runat="server" Text="$" ForeColor="#FFFFFF "></asp:Label>
                                                <asp:Label ID="Total" runat="server" CssClass="itemscarro" ForeColor="#FFFFFF" Text="0.00"></asp:Label>
                                               <asp:Image ImageUrl= "../img/cabecera/sep.gif" border="0" alt="sep" runat="server" ID="Img1" />
                                               <asp:Label ID="Label2" runat="server" ForeColor="#FFFFFF" Text="Total Líneas:"></asp:Label>
                                               <asp:Label ID="Items" runat="server" CssClass="itemscarro" ForeColor="#FFFFFF" Text="0" />
                                               <asp:Image ImageUrl="../img/cabecera/sep.gif" border="0" alt="sep" runat="server" ID="Img2" />
                                                </td>
                                         </tr> 
                                        <tr>
                                            <td>
                                               <asp:Label ID="ClienteL" runat="server" CssClass="itemscliente" ForeColor="#FFFFFF" />
                                                <asp:Image ImageUrl= "../img/cabecera/sep.gif" border="0" alt="sep" runat="server" ID="Image1" />
                                               <asp:Image ID="Image2" runat="server" ImageUrl="~/img/cabecera/carro.gif" />
                                               <asp:Image ImageUrl= "../img/cabecera/sep.gif" border="0" alt="sep" runat="server" ID="Image3" />
                                         </td>
                                         </tr>    
        
                                </table>
                                </asp:Panel>
                                
                            </td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style1">
                            <asp:Panel ID="PanelCarritoBot" runat="server" >
                                <table >
                                    <tr>
                                        <td >
                                            <asp:LinkButton runat="server" CssClass="btn btn-outline-danger" ID="LinkButtonPedido" OnClick="LinkButtonPedido_Click"
                                                        PostBackUrl="~/verPedido.aspx">Ver Pedido</asp:LinkButton>
                                              <asp:Image ImageUrl= "../img/cabecera/sep.gif" border="0" alt="sep" runat="server" ID="Image4" />
                                          </td>
                                        <td >
                                            <asp:LinkButton runat="server" CssClass="btn btn-outline-danger" ID="LinkButtonDesc"  OnClick="LinkButtonDesc_Click"
                                                        onclientclick="if(!confirm('Está por desconectarse del sitio. Si no grabo los pedidos estos se perderán, si los grabo pasarán a borrador ¿desea continuar?')){return false;};">Desconectar</asp:LinkButton>
                                              <asp:Image ImageUrl= "../img/cabecera/sep.gif" border="0" alt="sep" runat="server" ID="Image5" />
                                        </td>
                                     </tr>
                                </table>
                             </asp:Panel>
                          </td>
                     </tr>
        </table>
</div>
