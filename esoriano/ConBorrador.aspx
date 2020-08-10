<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterEsorianoLogeado.Master" CodeBehind="ConBorrador.aspx.vb" Inherits="Esoriano.ConBorrador" %>
<%@ Register Src="~/WebControl/WebUserControlCabecera.ascx" TagName="Cabecera" TagPrefix="Cab" %>
<%@ Register Src="~/WebControl/WebUserControlNovedades.ascx" TagName="Novedades" TagPrefix="Nov" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLogoPedidos" runat="server">
        <Cab:Cabecera ID="Cabecera" runat="server" /> 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderCuerpo" runat="server">
            <div id="divh1">
                <h3>
                    <asp:Label ID="Label1" runat="server" Text="Consultar Borradores" />
                    <asp:Label ID="Label2" runat="server" Text="Detalle de Borrador Nº" />
                    <asp:Label ID="Label3" runat="server" /></h3>
            </div>
            <div class="row-cols-10">
            
            <div class="col-md-12">
                <div  class="table-responsive" align="center" >
                    <asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="False"
                       DataKeyNames="CAR_CODIGO" SkinID="Vista3" CssClass="table table-sm table-striped " GridLines="None"
                        Width="100%" AllowPaging="true"   OnPageIndexChanging="GridView1_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="CAR_CODIGO" HeaderText="Borrador N&#176;" SortExpression="CAR_CODIGO"
                                InsertVisible="False" ReadOnly="True"></asp:BoundField>
                            <asp:BoundField DataField="CAR_FECHA" HeaderText="Fecha" SortExpression="CAR_FECHA"
                                DataFormatString="{0:dd/MM/yyyy - HH:mm tt}"></asp:BoundField>
                            <asp:BoundField DataField="CAR_expira" HeaderText="Expira" SortExpression="CAR_expira"
                                DataFormatString="{0:dd/MM/yyyy - HH:mm tt}"></asp:BoundField>
                            <asp:BoundField DataField="EST_NOMBRE" HeaderText="Estado" SortExpression="EST_NOMBRE"
                                InsertVisible="False" ReadOnly="True"></asp:BoundField>
                            <asp:CommandField ShowSelectButton="True" HeaderText="Opciones">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:CommandField>
                        </Columns>
                    </asp:GridView>
                    
                    <asp:GridView ID="GridView2" runat="server" DataSourceID="ObjectDataSource1" Visible="False" DataKeyNames="CAR_CODIGO"
                        Width="100%" SkinID="Vista3" AutoGenerateColumns="False" ShowFooter="True" CssClass="table table-sm table-striped " GridLines="None">
                        <Columns>
                            <asp:BoundField DataField="ART_CODIGO" HeaderText="CODIGO" SortExpression="ART_CODIGO" />
                            <asp:BoundField DataField="ART_NOMBRE" HeaderText="NOMBRE" SortExpression="ART_NOMBRE" />
                            <asp:BoundField DataField="ART_UND_CONSUMO" HeaderText="UNIDAD" SortExpression="ART_UND_CONSUMO" />
                            <asp:BoundField DataField="LIC_CANTIDAD" HeaderText="CANTIDAD" SortExpression="LIC_CANTIDAD" />
                            <asp:BoundField DataField="LST_PRECIO1" HeaderText="PRECIO" SortExpression="LST_PRECIO1" />
                            <asp:BoundField DataField="TotalLinea" DataFormatString="{0:c}" HeaderText="TOTAL"
                                SortExpression="TotalLinea">
                                <ItemStyle HorizontalAlign="Right" />
                                <HeaderStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>

                    
                     <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="selectCarrito" TypeName="ClassLibrary1.cart">
        <SelectParameters>
            <asp:ControlParameter ControlID="GridView1" Name="CAR_CODIGO" PropertyName="SelectedValue" />
          </SelectParameters>
    </asp:ObjectDataSource>

                </div>
                <div align="center" style="padding-top: 15px">
                    <div id="div-Bot1">
                        <asp:LinkButton ID="LinkButtonVolverAtras" runat="server" PostBackUrl="~/pedidos.aspx"
                            CssClass="Bot-Linkbutton" Height="20px">Volver Atras...</asp:LinkButton>
                    </div>
                    <div id="div-Bot2">
                        <asp:Button ID="ButtonActivarPed" runat="server" Text="Activar como Pedido ACTUAL"
                            Font-Bold="True" Visible="False" OnClientClick="if(!confirm('Esta seguro que quiere activar el borrador como pedido?')){return false;};"
                            CssClass="espBot" />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="ButtonEliminarPed" runat="server"
                                Text="Eliminar Borrador" Font-Bold="True" Visible="False" OnClientClick="if(!confirm('Esta seguro que quiere eliminar el borrador?')){return false;};"
                                CssClass="espBot" />
                        <br />
                        <asp:Label ID="LabelBorrar" runat="server" Text="LabelBorrar" Visible="False"></asp:Label>
                    </div>
                    <div id="div-Bot3">
                        <asp:LinkButton ID="LinkButtonVolverBorradores" runat="server" Visible="False" PostBackUrl="~/ConBorrador.aspx"
                            CssClass="Bot-Linkbutton" Height="20px">Volver 'Selección de Borradores'...</asp:LinkButton>
                    </div>
                    <div id="div-Bot4">
                        <asp:ImageButton ID="imgPrint" runat="server" ImageUrl="~/img/variado/bprint_detalle_pedido.jpg"
                            PostBackUrl="JavaScript:window.print();" Visible="False" CssClass="espBot" Height="32px" /></div>
                </div>
            </div>
        </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderNovedades" runat="server">
     <Nov:Novedades ID="Novedades" runat="server" />
</asp:Content>
