<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterEsorianoLogeado.Master" CodeBehind="Novedades.aspx.vb" Inherits="Esoriano.Novedades" %>
<%@ Register Src="~/WebControl/WebUserControlCabecera.ascx" TagName="Cabecera" TagPrefix="Cab" %>
<%@ Register Src="~/WebControl/WebUserControlNovedades.ascx" TagName="Novedades" TagPrefix="Nov" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLogoPedidos" runat="server">
        <Cab:Cabecera ID="Cabecera" runat="server" /> 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderCuerpo" runat="server">
 <div id="divh1">
     <h3> Novedades</h3>
  </div>
  <div class="row-cols-10">
        <div class="col-md-12">
            <div  class="table-responsive" align="center" >
                <div> <asp:Button ID="Button1" runat="server" Text="Presione aqui pera  detalles  de la  Novedad"  Font-Bold="True" Font-Size="Medium" Height="28px"  align="CENTER" ForeColor="#990000"  Visible="False" /></div>
                <asp:FormView ID="FormView1" runat="server" DataKeyNames="NOV_ID" OnDataBound = "FormView1_DataBound"
                    Width="100%">

                    <ItemTemplate>
                        <h2>
                            <%#Eval("NOV_TITULO")%></h2>
                        <span class="Novfecha">
                            <%#Eval("NOV_FECHA")%></span>
                        <p>
                            <%#Eval("NOV_CUERPO")%></p>
                        <%#Eval("NOV_IMAGEN")%>
                         <tr>
                            <td aling="center">
                             <asp:ImageMap ID="ImageMap1"  runat="server"  imageurl='<%#String.Format("WebRepositorio\Esoriano\IMAGENES/{0}", Eval("NOV_IMAGEN"))%>' TabIndex='<%# ProcessMyDataItem(Eval("NOV_VIDEO")) %> '  hotspotmode="PostBack"
                                     onclick="Button1_Click"  class="img-fluid" alt="Responsive image" >
                                 <asp:RectangleHotSpot          
                                    top="0"
                                    left="0"
                                    bottom="500"
                                    right="500"
                                    postbackvalue="Yes"
                                    alternatetext="Ver Mas">
                                </asp:RectangleHotSpot>
                            </asp:ImageMap>
                                  <asp:Label ID="lblCode" Text='<%#Eval("NOV_ID")%>' runat="server" />
                         <td/>
                        <tr/>
                    </ItemTemplate>
                </asp:FormView>
        
      </div>
    </div>
 </div>
    
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderNovedades" runat="server">
     <Nov:Novedades ID="Novedades" runat="server" />
          <asp:LinkButton ID="LinkButton1" runat="server" BorderColor="Red">Ver Todas las novedades</asp:LinkButton>
</asp:Content>
