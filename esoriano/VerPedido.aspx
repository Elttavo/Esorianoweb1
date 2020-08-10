<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterEsorianoLogeado.Master" CodeBehind="VerPedido.aspx.vb" Inherits="Esoriano.VerPedido" %>
<%@ Register Src="~/WebControl/WebUserControlCabecera.ascx" TagName="Cabecera" TagPrefix="Cab" %>
<%@ Register Src="~/WebControl/WebUserControlNovedades.ascx" TagName="Novedades" TagPrefix="Nov" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .Bot-Linkbutton {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12pt;
            color: #003399;
            padding-bottom: 0em;
            margin-bottom: 0.5em;
            font-weight: normal;
            padding-left: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLogoPedidos" runat="server">
          <Cab:Cabecera ID="Cabecera" runat="server" />   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderCuerpo" runat="server">
     <div id="divh1">
                <h4>
                    Orden de Pedido</h4>
            </div>
    <hr />
    <div class="row-cols-10 ">
        
      
        <div id="col-md-10">
           
            <div class="table-responsive">
                <asp:GridView ID="GridView1" AutoGenerateColumns="False" DataKeyNames="ART_CODIGO"
                    OnRowEditing="GridView1_RowEditing" runat="server" SkinID="Vista1" Width="100%"
                    ShowFooter="True" CssClass="table table-md table-striped" GridLines="none">
                    <RowStyle Font-Size="8pt" />
                    <Columns>
                        <asp:BoundField DataField="ART_CODIGO" HeaderText="Art&#237;culo" ReadOnly="True" />
                        <asp:BoundField DataField="ART_NOMBRE" HeaderText="Nombre" ReadOnly="True" />
                        <asp:BoundField DataField="ART_UND_CONSUMO" HeaderText="Unidad" ReadOnly="True" 
                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" >
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="LST_PRECIO1" HeaderText="Precio" ReadOnly="True" 
                            DataFormatString="{0:C}" HeaderStyle-HorizontalAlign="Right" 
                            ItemStyle-HorizontalAlign="Right" >
                        <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </div>
            <div align="center" style="padding-top: 15px">
                <div id="div-Bot1">
                    <asp:Button ID="carrito" runat="server" Text="Grabar Borrador" CssClass="espBot"
                        Font-Bold="True" OnClick="Carrito_Click" OnClientClick="if(!confirm('Esta seguro de grabar el borrador?')){return false;};" />
                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="ButtonGenerarPed" runat="server" Text="Generar Pedido"
                        Font-Bold="True"  CssClass="espBot" />
                </div>
                <div id="div-Bot2">
                    <asp:LinkButton ID="LinkButtonVolverRubros" runat="server" PostBackUrl="ProductoRubro.aspx"
                        CssClass="Bot-Linkbutton" Height="20px">Volver a 'Todos los Rubros'...</asp:LinkButton>
                </div>
                  <div id="div1_Bot4">
                    <asp:LinkButton ID="LinkButtonVolverArticulos" runat="server" PostBackUrl="ProductoRubroCelu.aspx"
                        CssClass="Bot-Linkbutton" Height="20px">Volver a 'Todos los Rubros Celu'...</asp:LinkButton>
                </div>
                <div id="div-Bot3">
                    <asp:ImageButton ID="imgPrint" runat="server" ImageUrl="~/img/variado/bprint_detalle_pedido.jpg"
                        PostBackUrl="JavaScript:window.print();" Height="32px" CssClass="espBot" />
                </div>
            </div>
        </div>
</div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderNovedades" runat="server">
     <Nov:Novedades ID="Novedades" runat="server" />
</asp:Content>
