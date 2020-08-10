<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterEsorianoLogeado.Master" CodeBehind="GeneraPedido.aspx.vb" Inherits="Esoriano.GeneraPedido" %>
<%@ Register Src="~/WebControl/WebUserControlCabecera.ascx" TagName="Cabecera" TagPrefix="Cab" %>
<%@ Register Src="~/WebControl/WebUserControlNovedades.ascx" TagName="Novedades" TagPrefix="Nov" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
     function clickOnce(btn, msg) {
         btn.value = msg;
         btn.disabled = true;
         return true;
     }
     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLogoPedidos" runat="server">
        <Cab:Cabecera ID="Cabecera" runat="server" /> 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderCuerpo" runat="server">
     <div id="divprincipal">
     
        <div class="row-cols-10">
            <div id="divh1">
                <h2>Confirmar pedido</h2>
            </div>
            <div id="divtexto">
                <div align="center">
                    <p>Comentario del pedido: </p>
                    <asp:TextBox ID="pedmemo" runat="server" BorderStyle="Solid" Height="80px" TextMode="MultiLine"
                        Width="100%"></asp:TextBox></div>
                <div align="center" style="padding-top: 10px">
                   <%-- Condicion de Venta:--%>
			            <h3> Seleccione forma de pago</h3> 
                    	<asp:DropDownList ID="cbocvt" runat="server" Width="277px"  >
                    	</asp:DropDownList>
                 </div>
                <div align="center" style="padding-top: 15px">
                    <div id="div-Bot1">
                        <asp:Button ID="ButtonConfPed" runat="server" Font-Bold="True" Text="Confirmar pedido"
                           OnClientClick="clickOnce(this, 'Procesando pedido aguarde...')"
                            ValidationGroup="Procesar" UseSubmitBehavior="false"
                            CssClass="espBot" />
                             <%--OnClientClick="if(!confirm('Esta seguro que quiere generar el pedido?')){return false();}"--%>
                    </div>
                    <div id="div-Bot2">
                        <asp:LinkButton ID="LinkButtonVolverRubros" runat="server" PostBackUrl="ProductoRubro.aspx"
                            CssClass="Bot-Linkbutton" Height="20px">Volver a 'Todos los rubros'...</asp:LinkButton>
                    </div>
                    <div id="div-Bot3">
                        <asp:LinkButton ID="LinkButtonVolverPed" runat="server" PostBackUrl="ProductoRubrocelu.aspx"
                            CssClass="Bot-Linkbutton" Height="20px">Volver a 'Pedido en Curso'...</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <asp:GridView ID="GridView1" runat="server" Visible="False">
        </asp:GridView>
        <asp:Label ID="lblOutput" runat="server" Font-Size="Larger" ForeColor="Red" left="50px"
            Height="26px" Visible="False" ></asp:Label>
         <br />
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderNovedades" runat="server">
    <Nov:Novedades ID="Novedades" runat="server" />
</asp:Content>
