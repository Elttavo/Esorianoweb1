<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterEsoriano.Master" CodeBehind="Inicio.aspx.vb" Inherits="Esoriano.Inicio" %>
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
       
        
                   
              <table style="margin-top: 0px; margin-bottom: 100px;">
                  <tr>
                    <td class="style3" valign ="top">
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="23px" 
                            
                            ImageUrl="~/admin/Imagenes/administracion/images/menues_01.jpg" />
                                      <br />
                        <asp:ImageButton ID="ImageButton2" runat="server" Height="23px" 
                            
                            ImageUrl="~/admin/Imagenes/administracion/images/menues_02.jpg" />
                                      <br />
                        <asp:ImageButton ID="ImageButton3" runat="server" Height="23px" 
                            
                            ImageUrl="~/admin/Imagenes/administracion/images/menues_03.jpg" />
                                      <br />
                        <asp:ImageButton ID="ImageButton4" runat="server" Height="23px" 
                            
                            ImageUrl="~/admin/Imagenes/administracion/images/menues_04.jpg" />
                                      <br />
                        <asp:ImageButton ID="ImageButton5" runat="server" Height="23px" 
                            
                            ImageUrl="~/admin/Imagenes/administracion/images/menues_05.jpg" />
                                      <br />
                        <asp:ImageButton ID="ImageButton6" runat="server" Height="23px"  
                            
                            ImageUrl="~/admin/Imagenes/administracion/images/menues_06.jpg" />
                                      <br />
                                  
                       <asp:ImageButton ID="ImageButton7" runat="server" Height="23px"   OnClick="ImageButton7_Click"
                            
                            ImageUrl="~/admin/Imagenes/administracion/images/menues_08.jpg" />
                                      <br />
                                  
                                  
                     </td>
                     </tr>  
                     </table>
                <br />
               </div>
            </div>
</asp:Content>
