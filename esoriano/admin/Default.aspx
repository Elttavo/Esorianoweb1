<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterEsoriano.Master" CodeBehind="Default.aspx.vb" Inherits="Esoriano._Default1" %>
<%@ Register Src="~/WebControl/WebUserControlCabecera.ascx" TagName="Cabecera" TagPrefix="Cab" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLogoPedidos" runat="server">
        <Cab:Cabecera ID="Cabecera" runat="server" /> 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Panel runat="server" ID="Panel1" DefaultButton="ButtonLog"  >       
     <div class="row">
       <div class="col-lg-4 col-sm-6 ">
            <img class="img-fluid rounded mb-4" src="../img/ecommers/fingerprint.jpg" alt="">
      </div>
      <div class="col-lg-8 col-sm-6 " >
        <div runat="server" class="conteiner">
            <h1> Ingrese Usuario y Contraseña </h1>
            <div class="form-group">
                <label for="usuario" >Usuario:</label>
                <asp:TextBox type="text"  class="form-control" ID="TextBoxUser" runat="server" placeholder="Ingrese Usuario" name="TextBoxUser"></asp:TextBox>
                
            </div>
            <div class="form-group">
                <label for="pwd">Contraseña:</label>
                <asp:TextBox type="password" class="form-control" ID="TextBoxPass"  placeholder="Ingrese contraseña" name="TextBoxPass" runat="server"></asp:TextBox>
               
            </div>
            <div class="form-group form-check">
                <label class="form-check-label">
                    <asp:CheckBox ID="chkPassword" runat="server" class="form-check-input" type="checkbox" name="remember"/> Remember me  </label>
       </div>
            <div>
                <asp:Button ID="ButtonLog" runat="server"  Text="Iniciar Sesión" type="button" CssClass="btn btn-outline-danger btn-ls btn-block" OnClick="ButtonLog_Click" />
            </div>
           <h4> <asp:Label ID="lblError" runat="server" Text="Label" Visible="False"></asp:Label></h4>
         </div>
      </div>
    </div>
   </asp:Panel>  


</asp:Content>
