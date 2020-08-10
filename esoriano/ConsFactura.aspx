<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterEsorianoLogeado.Master" CodeBehind="ConsFactura.aspx.vb" Inherits="Esoriano.ConsFactura" %>
<%@ Register Src="~/WebControl/WebUserControlCabecera.ascx" TagName="Cabecera" TagPrefix="Cab" %>
<%@ Register Src="~/WebControl/WebUserControlNovedades.ascx" TagName="Novedades" TagPrefix="Nov" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLogoPedidos" runat="server">
    <Cab:Cabecera ID="Cabecera" runat="server" />   

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderCuerpo" runat="server">
     
          <div id="divh1">
                <h1>
                    <asp:Label ID="Label2" runat="server" Text="Detalle de Factura Nº" />
                    <asp:Label ID="Label3" runat="server" />
                    <asp:Label ID="Label1"  runat="server" Text="Consultar Factura" />
                </h1>
            </div>
         <div class="row-cols-10">
            
            <div class="col-md-12">
                <div  class="table-responsive">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                         SkinID="Vista3" Width="100%" ShowFooter="True" GridLines="None" CssClass="table table-sm table-striped ">
                         <Columns>
                            <asp:BoundField DataField="FAC_NUMERO" HeaderText="NUMERO" SortExpression="FAC_NUMERO" />
                            <asp:BoundField DataField="FAC_FECHA" HeaderText="FECHA" SortExpression="FAC_FECHA" DataFormatString="{0:d}"/>
                            <asp:BoundField DataField="FAC_IMP_neto" HeaderText="IMPORTE" SortExpression="FAC_IMP_neto" >
                                <FooterStyle HorizontalAlign="Center" Width="20px" Wrap="False" />
                                <HeaderStyle HorizontalAlign="Center" Width="20px" Wrap="False" />
                                <ItemStyle HorizontalAlign="Center" Width="100px" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CLI_NOMBRE" HeaderText="NOMBRE" SortExpression="CLI_NOMBRE" >
                                <FooterStyle HorizontalAlign="Center" Width="20px" Wrap="False" />
                                <HeaderStyle HorizontalAlign="Center" Width="20px" Wrap="False" />
                                <ItemStyle HorizontalAlign="Center" Width="220px" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FAC_LETRA" HeaderText="LETRA" SortExpression="FAC_LETRA" />
                            <asp:BoundField DataField="FAC_SUC" HeaderText="SUC" SortExpression="FAC_SUC" />
                            <asp:BoundField DataField="COM_CODIGO" HeaderText="CODIGO" SortExpression="FAC_TIPO" />
                            <asp:TemplateField HeaderText="Descarga" >
			                    <ItemTemplate>
				                        <asp:HyperLink ID="Download" text = "Download" runat="server">
				                </asp:HyperLink>
			                    </ItemTemplate>
		                    </asp:TemplateField>
                        </Columns>
                      
                    </asp:GridView>
                 </div>
                <div align="center" style="padding-top: 15px">
                    <div id="div-Bot1">
                        <asp:LinkButton ID="LinkButtonVolverAtras" runat="server" PostBackUrl="~/pedidos.aspx"
                            CssClass="Bot-Linkbutton" Height="20px">Volver Atras...</asp:LinkButton>
                    </div>
                    <div id="div-Bot2">
                        </div>
                </div>
            </div>
           
        </div>
         
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderNovedades" runat="server">
    <Nov:Novedades ID="Novedades" runat="server" />
</asp:Content>
