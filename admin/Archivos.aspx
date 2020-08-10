<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterEsoriano.Master" CodeBehind="Archivos.aspx.vb" Inherits="Esoriano.Archivos" %>
<%@ Register Src="~/WebControl/WebUserControlCabecera.ascx" TagName="Cabecera" TagPrefix="Cab" %>
<%@ Register Src="~/admin/WebControl/WebUserControlNavAdm.ascx" TagName="NavAdmin" TagPrefix="Nav" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLogoPedidos" runat="server">
      
    <Cab:Cabecera ID="Cabecera" runat="server" /> 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="row-cols-10">
            <div>
                <Nav:NavAdmin  ID="NavAdmin" runat="server"  /> 
            </div>
     <div class="col-md-10">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
            <asp:UpdateProgress runat="server" id="PageUpdateProgress" AssociatedUpdatePanelID="up">
                <ProgressTemplate>
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/admin/Imagenes/archivos/ajax-loader.gif" />
                </ProgressTemplate>
            </asp:UpdateProgress>
        <asp:UpdatePanel runat="server" ID="up">
            <ContentTemplate>
                <div>
                    <asp:ImageButton ID="ImageButton1"  runat="server" Height="23px" onclick="ImageButton1_Click"
                    ImageUrl="~/admin/Imagenes/archivos/menues_art.jpg" />
                </div>
                <div>
                    <asp:ImageButton ID="ImageButton2"   runat="server" Height="23px"  
                    ImageUrl="~/admin/Imagenes/archivos/menues_ru.jpg" />
                </div>
                <div>
                    <asp:ImageButton ID="ImageButton3"  runat="server" Height="23px"
                    ImageUrl="~/admin/Imagenes/archivos/menues_sub.jpg" />
                </div>
                <div>
                    <asp:ImageButton ID="ImageButton4"  runat="server" Height="23px"
                    ImageUrl="~/admin/Imagenes/archivos/menues_uni.jpg" />
                </div>
                <div>
                    <asp:ImageButton ID="ImageButton5" runat="server" Height="23px" Width="295px" 
                    ImageUrl="~/admin/Imagenes/archivos/menues_list.jpg" />
                </div>
                <div>
                    <asp:ImageButton ID="ImageButton6" runat="server" Height="23px" Width="295px" 
                    ImageUrl="~/admin/Imagenes/archivos/menues_cli_seg.jpg" />
               </div>
                <div>
                    <asp:ImageButton ID="ImageButton8" runat="server" Height="23px" Width="295px" 
                    ImageUrl="~/admin/Imagenes/archivos/vendedores.jpg" />
                </div>
                <div>
                    <asp:ImageButton ID="ImageButton9" runat="server" Height="23px"  
                    ImageUrl="~/admin/Imagenes/archivos/factura.jpg" Width="295px" />
                </div>
                <asp:Label ID="Label1" runat="server"></asp:Label> 
             </ContentTemplate>
         </asp:UpdatePanel>
     </div>
  </div>    
</asp:Content>
