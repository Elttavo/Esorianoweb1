<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterEsorianoLogeado.Master" CodeBehind="ConPedidoGen.aspx.vb" Inherits="Esoriano.ConPedidoGen" %>
<%@ Register Src="~/WebControl/WebUserControlCabecera.ascx" TagName="Cabecera" TagPrefix="Cab" %>
<%@ Register Src="~/WebControl/WebUserControlNovedades.ascx" TagName="Novedades" TagPrefix="Nov" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLogoPedidos" runat="server">
        <Cab:Cabecera ID="Cabecera" runat="server" />   

</asp:Content>
<asp:Content ID="ContentCuerpo" ContentPlaceHolderID="ContentPlaceHolderCuerpo" runat="server">
     <div id="divh1">
                <h4>
                    <asp:Label ID="Label1" runat="server" Text="Consultar Pedidos Generados" />
                    <asp:Label ID="Label2" runat="server" Text="Detalle de Pedido Nº" />
                    <asp:Label ID="Label3" runat="server" /></h4>
            </div>
      <div class="row-cols-10">
            
            <div class="col-md-12">
                <div  class="table-responsive" align="center" >
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                         DataKeyNames="PED_CODIGO" Visible="False" AllowSorting="True"
                        SkinID="Vista3" Width="100%" ShowFooter="True" CssClass="table table-sm table-striped " GridLines="None">
                        <Columns>
                            <asp:BoundField DataField="PED_CODIGO" HeaderText="PEDIDO" InsertVisible="False"
                                ReadOnly="True" SortExpression="PED_CODIGO"></asp:BoundField>
                            <asp:BoundField DataField="PED_FECHA" HeaderText="FECHA" SortExpression="PED_FECHA" 
                                DataFormatString="{0:dd-MM-yyyy}"></asp:BoundField>
                            <asp:BoundField DataField="EST_NOMBRE" HeaderText="ESTADO" SortExpression="EST_NOMBRE">
                            </asp:BoundField>
                            <asp:CommandField ShowSelectButton="True" HeaderText="Opciones">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:CommandField>
                            <asp:TemplateField ShowHeader="False" HeaderText="Exportar TXT" ItemStyle-Width="159">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server">Exportar</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="159px"></ItemStyle>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"  DataSourceID="SqlDataSource2" DataKeyNames="PED_CODIGO"   Visible="False" SkinID="Vista3"  ShowFooter="True" CssClass="table table-sm table-striped " GridLines="None">
                        <Columns>
                            <asp:BoundField DataField="ART_CODIGO" HeaderText="ARTICULO" SortExpression="ART_CODIGO">
                            </asp:BoundField>
                            <asp:BoundField DataField="ART_NOMBRE" HeaderText="NOMBRE" SortExpression="ART_NOMBRE"  >
                            </asp:BoundField>
                            <asp:BoundField DataField="UND_CODIGO" HeaderText="UNIDAD" SortExpression="UND_CODIGO"  >
                            </asp:BoundField>
                            <asp:BoundField DataField="LNP_CANT_PED" HeaderText="CANTIDAD" SortExpression="LNP_CANT_PED" >
                            </asp:BoundField>
                            <asp:BoundField DataField="LNP_PRECIO" HeaderText="PRECIO" SortExpression="LNP_PRECIO" >
                            </asp:BoundField>
                            <asp:BoundField DataField="TotalLinea" HeaderText="TOTAL" ReadOnly="True" SortExpression="TotalLinea"
                                DataFormatString="{0:c}"  HeaderStyle-CssClass="total"   >
                               
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div align="center" style="padding-top: 15px; ">
                    <br />

                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False"  DataSourceID="SqlDataSource3"   Visible="False" SkinID="Vista3" Width="100%" ShowFooter="True"  CssClass="table table-sm table-striped " GridLines="None">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="PED_MEMO" HeaderText="Mensaje" SortExpression="PED_MEMO">
                            </asp:BoundField>
                             <asp:BoundField DataField="CVT_NOMBRE" HeaderText="Cond de Pago" SortExpression="CVT_NOMBRE">
                            </asp:BoundField>
                        </Columns>
                    
                    </asp:GridView>
                    <asp:LinkButton ID="LinkButtonVolverAtras" runat="server" SkinID="LinkButton1" PostBackUrl="~/pedidos.aspx">Volver Atras...</asp:LinkButton>
                    <br />
                    <br />
                    <asp:ImageButton ID="imgPrint" runat="server" ImageUrl="~/img/variado/bprint_detalle_pedido.jpg"
                        PostBackUrl="JavaScript:window.print();" Visible="False" />
                    <br />
                    <br />
                    <asp:LinkButton ID="LinkButtonSelecPedidos" runat="server" SkinID="LinkButton1" PostBackUrl="~/conPedidoGen.aspx"
                        Visible="False">Volver a 'Selección de Pedidos'...</asp:LinkButton>
                </div>
            </div>
        </div>
    
    <asp:ObjectDataSource id="SqlDataSource2" runat="server"  SelectMethod="SelectVisPedidosDetalle" TypeName="ClassLibrary1.Pedidosweb">
 <SelectParameters>
            <asp:ControlParameter ControlID="GridView1" Name="PED_CODIGO" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="SqlDataSource3" runat="server" SelectMethod="Selectpedidos" TypeName="ClassLibrary1.Pedidosweb">
         <SelectParameters>
            <asp:ControlParameter ControlID="GridView1" Name="PED_CODIGO" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:ObjectDataSource>
    
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderNovedades" runat="server">
      <Nov:Novedades ID="Novedades" runat="server" />
</asp:Content>
