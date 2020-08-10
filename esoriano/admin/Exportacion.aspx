<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterEsoriano.Master" CodeBehind="Exportacion.aspx.vb" Inherits="Esoriano.Exportacion" %>
<%@ Register Src="~/admin/WebControl/WebUserControlNavAdm.ascx" TagName="NavAdmin" TagPrefix="Nav" %>
<%@ Register Src="~/WebControl/WebUserControlCabecera.ascx" TagName="Cabecera" TagPrefix="Cab" %>

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
                    <td class="style5" valign ="top">
                        <div>
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="23px" 
                            ImageUrl="~/admin/Imagenes/exportacion/images/menues_01.jpg" />
                       </div>
          <div>               
                        <asp:ImageButton ID="ImageButton2" runat="server" Height="20px"
                            ImageUrl="~/admin/Imagenes/exportacion/botones/boton_rppn.jpg" />
                   </div>
          <div>    
                        <asp:ImageButton ID="ImageButton3" runat="server" Height="23px"  
                            ImageUrl="~/admin/Imagenes/exportacion/images/menues_02.jpg" />
               </div>
          <div>        
                        <asp:ImageButton ID="ImageButton4" runat="server" Height="23px"                     
                            
                            ImageUrl="~/admin/Imagenes/exportacion/botones/boton_ep.jpg" />
             </div>
          <div>          
                        <asp:ImageButton ID="ImageButton5" runat="server" Height="23px"

                            
                            ImageUrl="~/admin/Imagenes/exportacion/images/Menues07.jpg" 
                            style="margin-right: 4px" />
             </div>
          <div>           
                        <asp:ImageButton ID="ImageButton6" runat="server" Height="23px" 

                            
                            ImageUrl="~/admin/Imagenes/exportacion/images/menues_04.jpg" 
                            style="margin-left: 0px" />
             </div>
          <div>         
                        <asp:ImageButton ID="ImageButton7" runat="server" Height="23px" 
                            ImageUrl="~/admin/Imagenes/exportacion/images/menues_05.jpg" />
            </div>
                                     
               </td>
                 </tr>
            </table>
        </div>
    
            <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
              
        </div>
</asp:Content>
