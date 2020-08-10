<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterEsoriano.Master" CodeBehind="AbmNovedades.aspx.vb" Inherits="Esoriano.AbmNovedades" %>
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
          <div   style="right:200px;  margin:50px">
              <table class="table-borderless" >
                  <tr>
                  <th><asp:Label ID="Label2" runat="server" Text="Numero"></asp:Label> </th>
                 <th><asp:Label ID="Label5" runat="server" Text="Fecha" ></asp:Label></th>
                 <th><asp:Label ID="Label6" runat="server" Text="Imagen"></asp:Label></th>
                </tr>
                  <tr>  
                <td><asp:TextBox ID="TextBox1" runat="server" Width="141px" ></asp:TextBox></td>
                <td><asp:TextBox ID="TextBox5" runat="server" Width="141px" ></asp:TextBox></td>
                <td><asp:TextBox ID="TextBox6" runat="server" Width="238px" ></asp:TextBox></td>
                      </tr> 
         </table>
            <asp:Label ID="Label3" runat="server" Text="Titulo"></asp:Label>
                <p>
            <asp:TextBox ID="TextBox2" runat="server" Width="410px"></asp:TextBox>
                    <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
        </p>
            <asp:Label ID="Label1" runat="server" Text="Copete"></asp:Label>
        <p>
            <asp:TextBox ID="TextBox3" runat="server" Height="53px" Width="548px" 
                TextMode="MultiLine"></asp:TextBox>
        </p>
        <asp:Label ID="Label4" runat="server" Text="Cuerpo"></asp:Label>
        <p>
            <asp:TextBox ID="TextBox4" runat="server" Height="101px" Width="550px" 
                TextMode="MultiLine"></asp:TextBox>
        </p>
               <p>
                   <asp:Label ID="Label8" runat="server" Text="Nombre del Archivo Detalle de la Novedad (tanto Video como Imagen)"></asp:Label>
                   </p>
              <p>
                    <asp:TextBox ID="TxtDetalleVideo" runat="server" Height="33px" Width="348px" 
                                ></asp:TextBox>
                </p>
                <p style="height: 20px; ">Tildar para cargar Video o Imagen a la Novedad</p>
              <div> 
                <div>
                    <asp:RadioButton ID="RadioButton1" runat="server" Text="Video" GroupName="Controls" AutoPostBack="false"/>
                </div>
                <div >
                    <asp:RadioButton ID="RadioButton2" runat="server" Text="Imagen"  GroupName="Controls" AutoPostBack="false"/>
                </div>
                  </div>
              <div>
              <hr />
                <div style="float:left">
                <asp:Button ID="Button1" runat="server" Text="Volver a nov" />
                </div>
                <div style="float:right">
                <asp:Button ID="Button2" runat="server" Text="Grabar" Visible="False" Width="121px" />
                </div>
                  </div>
               
           </div>
            </div>
         </div>
</asp:Content>
