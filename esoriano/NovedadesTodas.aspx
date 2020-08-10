<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterEsorianoLogeado.Master" CodeBehind="NovedadesTodas.aspx.vb" Inherits="Esoriano.NovedadesTodas" %>
<%@ Register Src="~/WebControl/WebUserControlCabecera.ascx" TagName="Cabecera" TagPrefix="Cab" %>
<%@ Register Src="~/WebControl/WebUserControlNovedades.ascx" TagName="Novedades" TagPrefix="Nov" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLogoPedidos" runat="server">
        <Cab:Cabecera ID="Cabecera" runat="server" /> 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderCuerpo" runat="server">
   <div class="container">


        <table border="0" style="width: 207%">
        </table>
        <table style=" height: 17px;">
         <tr>
        <td style="border-bottom: 1px groove #999999; padding-left: 30px;" 
            class="style3">
            <span style="font-family: Tahoma; font-size: 18px;
                             padding-left: 10px; color: #000000;"> Menú de Novedades
            </span>
        </td>
               
      </tr>
    </table>
        <div >
                <asp:Label ID="Label1" runat="server" Text="" Visible="False"></asp:Label>
                <asp:textbox id="txtemp" runat ="server" height ="16px" width="48px"  Visible="False"></asp:textbox>
                <asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
                <asp:Label ID="Label2" runat="server" Text="Label" Visible="False"></asp:Label>
                <asp:gridview runat ="server" id ="grnovedades" CellPadding="4" BackColor="White" Width="100%" CssClass="table table-sm table-striped "  
                 AllowPaging="true"  OnPageIndexChanging="grnovedades_PageIndexChanging" >
                    <Columns>
                        <asp:ButtonField Text="Ver" CommandName="Ver"   />
                        <asp:BoundField Visible="False" />
                    </Columns>
                </asp:gridview>
            </div>  
</div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderNovedades" runat="server">
    <Nov:Novedades ID="Novedades" runat="server" />
</asp:Content>
