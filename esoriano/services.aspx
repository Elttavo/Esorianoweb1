<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterEsoriano.Master" CodeBehind="services.aspx.vb" Inherits="Esoriano.services" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <title>servios Esoriano</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Navigation -->


  <!-- Page Content -->
  <div class="container">

    <!-- Page Heading/Breadcrumbs -->
    <h3 class="mt-4 mb-3">Servicios</h3>

    <ol class="breadcrumb">
      <li class="breadcrumb-item">
        <a href="Default.aspx">Home</a>
      </li>
      <li class="breadcrumb-item active">Servicios</li>
    </ol>

    <!-- Image Header -->

       <div class="row">
      <div class="col-lg-4 col-sm-6 portfolio-item">
        <img class="card-img-top" src="img/servicios/servicios_1-300x199.jpg" alt="">
      </div>
      <div class="col-lg-4 col-sm-6 portfolio-item">
        <img class="card-img-top" src="img/servicios/interconectados.jpg" alt="">
      </div>
      <div class="col-lg-4 col-sm-6 portfolio-item">
        <img class="card-img-top" src="img/servicios/garantia.jpg" alt="">
      </div>
      
    </div> 
   
    <div class="row">
      <div class="col-lg-4 mb-4">
        <div class="card h-100">
          <h4 class="card-header">Stock  </h4>
          <div class="card-body">
              <p class="card-text">Stock permanente de todos nuestro productos. No inmovilice stock en su depósito: haga pedidos con la frecuencia que Usted requiera. Recuerde que la inmovilización de stock le ocasiona gastos financieros..</p>
                      </div>
          <div class="card-footer">
            <img class="img-thumbnail" src="img/servicios/logos ES horizontal txt negro.png" alt="esoriano" style="width:40% ; height:100%">
          </div>
        </div>
      </div>
      <div class="col-lg-4 mb-4">
        <div class="card h-100">
          <h4 class="card-header">E-commerce y Distribución</h4>
          <div class="card-body">
             <p class="card-text">Carrito de compra en Internet. Entre a nuestra página <a href="https://www.esoriano.com.ar" style:"color:red;">www.esoriano.com.ar</a>  <a href="#"> www.esorianosa.com.ar</a> </p>
             <p class="card-text">Nuestros sitios se actualizan diariamente; en ellos podrá consultar  nuestro catálogo, ver sus facturas y hacer sus pedidos para un despacho inmediato..</p>
          </div>
          <div class="card-footer">
          <img class="img-thumbnail" src="img/servicios/logos ES horizontal txt negro.png" alt="esoriano" style="width:40% ; height:100%">
          </div>
        </div>
      </div>
      <div class="col-lg-4 mb-4">
        <div class="card h-100">
          <h4 class="card-header">Garantía </h4>
          <div class="card-body">
            <p class="card-text"> Todos nuestros productos están garantizados.</p>
            <p>Gran Diversidad de artículos. Aseguramos continuidad en la entrega de todas nuestras líneas de artículos reduciendo su tiempo de compra, lo que le permite mayor enfoque en su tarea de vender</p>
          </div>
          <div class="card-footer">
              <img class="img-thumbnail" src="img/servicios/logos ES horizontal txt negro.png" alt="esoriano" style="width:40% ; height:100%">
            
          </div>
        </div>
      </div>
    </div>
    <!-- /.row -->

  </div>

</asp:Content>
