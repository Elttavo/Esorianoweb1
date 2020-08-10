<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterEsorianoLogeado.Master" CodeBehind="Descargas.aspx.vb" Inherits="Esoriano.Descargas" %>
<%@ Register Src="~/WebControl/WebUserControlCabecera.ascx" TagName="Cabecera" TagPrefix="Cab" %>
<%@ Register Src="~/WebControl/WebUserControlNovedades.ascx" TagName="Novedades" TagPrefix="Nov" %>
<%@ Register Src="~/WebControl/WebUserControlNoveSL.ascx" TagName="NoveSL" TagPrefix="Nov" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
          .card-text{
            height:150px;
        }
    </style>
</asp:Content>
<asp:Content ID="ContentLP" ContentPlaceHolderID="ContentPlaceHolderLogoPedidos" runat="server">
    <Cab:Cabecera ID="Cabecera" runat="server" />   

</asp:Content>

<asp:Content ID="ContentCuerpo" ContentPlaceHolderID="ContentPlaceHolderCuerpo" runat="server">
    <asp:Panel runat="server" ID="PanelUser" DefaultButton="ButtonLog"  >       
     <div class="row">
        <div class="col-lg-4 col-sm-6 ">
            <img class="img-fluid rounded mb-4" src="img/ecommers/fingerprint.jpg" alt="">
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
    
  <asp:Panel runat="server" ID="Panelbotones" >
   <div class="container-fluid text-center"> 
        <div class="container p-0 my-0 bg-dark text-white">
            <h1>Descargas</h1>
            <p>Elija una de las siguientes opciones para poder trabajar con nosotros </p>
        </div>
   </div>
    
 <div class="row col-12">
    <div class="col-lg-4 col-sm-6  ">
        <div class="card h-100">
          <img src="img/cabecera/cabezaPeque.jpg" class="card-img-top" alt="todos los rubros">
            <div class="card-body">
                <h5 class="card-title">Catálogo para clientes</h5>
                <img src="img/descargas/Catalogo.jpg" class="img-fluid" alt="Responsive image" />
                <p class="card-text">Descargue el catálogo para clientes con la información de nuestras marcas y productos</p>
                <asp:Button runat="server" Text="Download" Onclick ="btn_catalogo_Click"  CssClass="btn btn-outline-danger btn-ls btn-block" ID="btn_catalogo"></asp:Button>
                 
            </div>
        </div>
    </div>
       
     <div class="col-lg-4 col-sm-6 ">
        <div class="card h-100">
          <img src="img/cabecera/cabezaPeque.jpg" class="card-img-top" alt="todos los rubros">
            <div class="card-body">
                <h5 class="card-title"> Lista de precios excel</h5>
                <img src="img/descargas/Listas.jpg" class="img-fluid" alt="Responsive image"/>
                <p class="card-text">Descargue nuestra lista en formato excel que le permitirá fácilmente adaptarla a su formato de trabajo </p>

                 <asp:Button runat="server" Text="Download" Onclick ="btn_lista_excel_Click"  CssClass="btn btn-outline-danger btn-ls btn-block" ID="btn_lista_excel"></asp:Button>
            </div>
        </div>
    </div>
       <div class="col-lg-4 col-sm-6 ">
        <div class="card h-100">
          <img src="img/cabecera/cabezaPeque.jpg" class="card-img-top" alt="todos los rubros">
            <div class="card-body">
                <h5 class="card-title">Instructivo de compras</h5>
                <img src="img/descargas/Instructivo.jpg" class="img-fluid" alt="Responsive image"/>
                <p class="card-text">Descargue nuestro instructivo para poder aprovechar al máximo nuestro sitio de compras  </p>

                 <asp:Button runat="server" Text="Download" Onclick ="btnInstructivo_Click"  CssClass="btn btn-outline-danger btn-ls btn-block" ID="btnInstructivo"></asp:Button>
            </div>
        </div>
    </div>

      


</div>
  
</asp:Panel>
</asp:Content>

<asp:Content ID="contentNove" ContentPlaceHolderID="ContentPlaceHolderNovedades" runat="server">
    
     
    <Nov:NoveSL ID="NoveSL" runat="server" />
    <Nov:Novedades ID="Novedades" runat="server" />
       
</asp:Content>
