<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterEsoriano.Master" CodeBehind="VerPedidoA.aspx.vb" Inherits="Esoriano.VerPedidoA" %>
<%@ Register Src="~/WebControl/WebUserControlCabecera.ascx" TagName="Cabecera" TagPrefix="Cab" %>
<%@ Register Src="~/admin/WebControl/WebUserControlNavAdm.ascx" TagName="NavAdmin" TagPrefix="Nav" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLogoPedidos" runat="server">
        <Cab:Cabecera ID="Cabecera" runat="server" /> 

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
                <Nav:NavAdmin ID="NavAdmin1" runat="server"  /> 
            </div>
    <div class="container">
         
    <div class="row-cols-10">
          
            <div class="col-md-12">
                <div  class="table">  

                     <asp:Label ID="Label1" runat="server" ></asp:Label>
        
         <div>
            
              <asp:ImageButton ID="ImageButton1" runat="server" Height="36px" ImageUrl="~/admin/Imagenes/administracion/images/descarga (1).jpg" Width="49px" AlternateText="descargar" ImageAlign="Middle" />
               Presione aqui para descargar el archivo
        </div>
        <div>
            <table>
                <tr>
                    
                    <td><asp:GridView ID="GridView1" runat="server"  CssClass="table table-xl table-striped " GridLines="None"
                        Width="100%" AllowPaging="true"   OnPageIndexChanging="GridView1_PageIndexChanging">
                        </asp:GridView>

                    </td>
                    
                </tr>
            </table>
         </div>
   
       
        <asp:ImageButton ID="ImageButton2" runat="server" Height="36px" ImageUrl="~/admin/Imagenes/administracion/images/regresar.png" Width="42px" OnClick="ImageButton2_Click" />
   

                    </div>
                </div>
        </div>
        </div>
</asp:Content>

