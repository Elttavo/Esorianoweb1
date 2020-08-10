<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterEsorianoLogeado.Master" CodeBehind="Pedidos.aspx.vb" Inherits="Esoriano.Pedidos" %>
<%@ Register Src="~/WebControl/WebUserControlCabecera.ascx" TagName="Cabecera" TagPrefix="Cab" %>
<%@ Register Src="~/WebControl/WebUserControlNovedades.ascx" TagName="Novedades" TagPrefix="Nov" %>
<%@ Register Src="~/WebControl/WebUserControlNoveSL.ascx" TagName="NoveSL" TagPrefix="Nov" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .card-text{
            height:220px;
        }
  
        .panelmensaje {
    padding: 20px;
    margin: 20px;
    border: 1px solid #C0C0C0;
    background-color: #F2F2F2;
    text-align: center;
    }  
  
    </style>
</asp:Content>
<asp:Content ID="ContentLP" ContentPlaceHolderID="ContentPlaceHolderLogoPedidos" runat="server">
    <Cab:Cabecera ID="Cabecera" runat="server" />   

</asp:Content>

<asp:Content ID="ContentCuerpo" ContentPlaceHolderID="ContentPlaceHolderCuerpo" runat="server">
    <asp:Panel runat="server" ID="PanelUser" DefaultButton="ButtonLog" BorderColor="Black"  >       
     <div class="row">
       <div class="col-lg-4 col-sm-6 ">
            <img class="img-fluid rounded mb-4" src="img/ecommers/fingerprint.jpg" alt="">
      </div>
      <div class="col-lg-8 col-sm-6 " >
        <div runat="server" class="conteiner">
            <h1> Ingrese Usuario y Contraseña </h1>
            <div class="form-group">
                <label for="usuario" >Usuario:</label>
                <asp:TextBox type="text"  class="form-control" ID="TextBoxUser" runat="server" placeholder="Ingrese Usuario" name="TextBoxUser" FilterType="Numbers"></asp:TextBox>
                
            </div>
            <div class="form-group">
                <label for="pwd">Contraseña:</label>
                <asp:TextBox type="password" class="form-control" ID="TextBoxPass"  placeholder="Ingrese contraseña" name="TextBoxPass" runat="server" FilterType="Numbers"></asp:TextBox>
               
            </div>
            <div class="form-group form-check">
                <label class="form-check-label">
                    <asp:CheckBox ID="chkPassword" runat="server" class="form-check-input" type="checkbox" name="remember"/> Remember me  </label>
       </div>
            <div>
                <asp:Button ID="ButtonLog" runat="server"   Text="Iniciar Sesión" type="button" CssClass="btn btn-outline-danger btn-ls btn-block" OnClick="ButtonLog_Click1" />
            </div>
           <h4> <asp:Label ID="lblError" runat="server" Text="Label" Visible="False"></asp:Label></h4>
         </div>
      </div>
    </div>
   </asp:Panel>  
    
  <asp:Panel runat="server" ID="Panelbotones" >
   <div class="container-fluid text-center "> 
        <div class="container embed-responsive bg-dark text-white"  >
            <h3>  Opciones para poder trabajar con nosotros</h3>
        </div>
        <hr />
   </div>
   
 <div class="row">
    <div class="col-lg-4 col-sm-6 ">
        <div class="card h-100">
          <img src="img/cabecera/cabezalchico4.jpg" class="card-img-top" alt="todos los rubros">
            <div class="card-body">
                <h5 class="card-title">Productos por Rubros vista clásica</h5>
                <p class="card-text">Usted puede generar pedidos seleccionando artículos del catálogo, pudiendo consultar especificaciones de cada uno de los artículos y la imagen de los mismos.</p>
                <asp:Button runat="server" Text="Entrar " Onclick ="btn_por_rubros_Click"   CssClass="btn btn-outline-danger btn-ls btn-block" ID="btn_por_rubros"></asp:Button>
                 
            </div>
        </div>
    </div>
       
    <div class="col-lg-4 col-sm-6 ">
        <div class="card h-100">
          <img src="img/cabecera/cabezalchico4.jpg"" class="card-img-top" alt="todos los rubros">
            <div class="card-body">
                <h5 class="card-title">Productos por Rubro ideal para celular</h5>
                <p class="card-text"> Usted puede generar pedidos seleccionando artículos del catálogo ordenado por Rubros, pudiendo consultar especificaciones de cada uno de los artículos y la imagen de los mismos.</p>
                <asp:Button runat="server" Text="Entrar " Onclick ="btnRubrosCeluClick"  CssClass="btn btn-outline-danger btn-ls btn-block" ID="Button1"></asp:Button>
            </div>
        </div>
    </div>  
     <div class="col-lg-4 col-sm-6 ">
        <div class="card h-100">
          <img src="img/cabecera/cabezalchico2.jpg" class="card-img-top" alt="todos los rubros">
            <div class="card-body">
                <h5 class="card-title">Consulta de Pedidos generados</h5>
                <p class="card-text">Usted puede consultar los Pedidos ya generados y descargarlos para poder visualizarlos y realizar un control sobre los mismos. </p>
                <asp:Button runat="server" Text="Entrar " Onclick ="btnPedGen_Click"  CssClass="btn btn-outline-danger btn-ls btn-block" ID="btnPedGen"></asp:Button>
            </div>
        </div>
    </div>

       <div class="col-lg-4 col-sm-6 ">
        <div class="card h-100">
          <img src="img/cabecera/cabezalchico2.jpg" class="card-img-top" alt="todos los rubros">
            <div class="card-body">
                <h5 class="card-title">Borradores de pedidos</h5>
                <p class="card-text">Esta opción le permite recuperar pedidos que no se hayan podido guardar. Desde aquí los podrá retomar y continuar con los mismos.</p>
                <asp:Button runat="server" Text="Entrar " Onclick ="btnBorrador_Click"  CssClass="btn btn-outline-danger btn-ls btn-block" ID="btnBorrador"></asp:Button>
            </div>
        </div>
    </div>
        <div class="col-lg-4 col-sm-6 ">
        <div class="card h-100">
          <img src="img/cabecera/cabezalchico1.jpg" class="card-img-top" alt="todos los rubros">
            <div class="card-body">
                <h5 class="card-title">Condición de venta </h5>
                <p class="card-text">Mediante esta opción Usted puede consultar las diferentes condiciones de ventas autorizadas.</p>
                  <asp:Button runat="server" Text="Entrar " Onclick ="btnConVent_Click"  CssClass="btn btn-outline-danger btn-ls btn-block" ID="btnConVent"></asp:Button>
            </div>
        </div>
    </div>
       <div class="col-lg-4 col-sm-6 ">
        <div class="card h-100">
          <img src="img/cabecera/cabezalchico1.jpg" class="card-img-top" alt="todos los rubros">
            <div class="card-body">
                <h5 class="card-title">Facturas canceladas</h5>
                <p class="card-text">Mediante esta opción podrá ver y descargar todos los comprobantes cancelados.</p>
                 <asp:Button runat="server" Text="Entrar " Onclick ="btnFactura_Click"  CssClass="btn btn-outline-danger btn-ls btn-block" ID="btnFactura"></asp:Button>
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
