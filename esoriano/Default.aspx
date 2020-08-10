<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterEsoriano.Master" CodeBehind="Default.aspx.vb" Inherits="Esoriano._Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
  /* Make the image fully responsive */
  @media screen and (max-width: 600px) {

     .carousel img {
      width: 100% !important;
      min-width: 100px;
      min-height: 240px;
      margin-left: auto;
      margin-right: auto;
      display: block;
      }

      .carousel-item {
       height: auto;
       }

       .carousel {
        background-color: #292b2c;
        }
 }

</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%-- <h1 class="my-4">  </h1>--%>
     <header>

    <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
      <ol class="carousel-indicators">
        <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
        <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
        <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
      </ol>
      <div class="carousel-inner" role="listbox">
        <!-- Slide One - Set the background image for this slide in the line below -->
          
       - <div class="carousel-item active" style="background-image: url('/img/default/logoEsoriano.jpg')">
            <div class="carousel-caption d-none d-md-block">
            </div>
        </div>
        <div class="carousel-item" style="background-image: url('/img/default/home_banner_m_1.jpg')">
            <div class="carousel-caption d-none d-md-block">
            </div>
        </div>
        <div class="carousel-item" style="background-image: url('/img/default/home_banner_r_4.jpg')">
            <div class="carousel-caption d-none d-md-block">
            </div>
        </div>
        <div class="carousel-item" style="background-image: url('/img/default/home_banner_e_1.jpg')">
            <div class="carousel-caption d-none d-md-block">
            </div>
        </div>
        <div class="carousel-item" style="background-image: url('/img/default/home_banner_p_1.jpg')">
            <div class="carousel-caption d-none d-md-block">
            </div>
        </div>
        <div class="carousel-item" style="background-image: url('img/default/home_banner_e_2.jpg')">
            <div class="carousel-caption d-none d-md-block">
            </div>
        </div>
        <div class="carousel-item" style="background-image: url('img/default/home_banner_m_2.jpg')">
            <div class="carousel-caption d-none d-md-block">
            </div>
        </div>
        <div class="carousel-item" style="background-image: url('img/default/home_banner_r_1.jpg')">
            <div class="carousel-caption d-none d-md-block">
            </div>
        </div>
        <div class="carousel-item" style="background-image: url('img/default/home_banner_m_3.jpg')">
            <div class="carousel-caption d-none d-md-block">
            </div>
        </div>
        <div class="carousel-item" style="background-image: url('img/default/home_banner_r_2.jpg')">
            <div class="carousel-caption d-none d-md-block">
            </div>
        </div>
        <div class="carousel-item" style="background-image: url('img/default/home_banner_k_3 .jpg')">
            <div class="carousel-caption d-none d-md-block">
            </div>
        </div>
        <div class="carousel-item" style="background-image: url('img/default/home_banner_e_3.jpg')">
            <div class="carousel-caption d-none d-md-block">
            </div>
        </div>
        <div class="carousel-item" style="background-image: url('img/default/home_banner_r_3.jpg')">
            <div class="carousel-caption d-none d-md-block">
            </div>
        </div>
    </div>
      <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
        <span class="sr-only">Previous</span>
      </a>
      <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
        <span class="carousel-control-next-icon" aria-hidden="true"></span>
        <span class="sr-only">Next</span>
      </a>
    </div>

        
  </header>
  <div class="container col-10">
  

    <!-- Portfolio Section -->
    <h1>Nuestras Marcas</h1>

    <div class="row">
      <div class="col-lg-4 col-sm-6 portfolio-item">
        <div class="card h-100">
          <a href="https://rhein.com.ar/"><img class="card-img-top" src="img/default/rhein yard.jpg" alt=""></a>
          <div class="card-body">
            <h4 class="card-title">
              <a href="https://rhein.com.ar/">Rhein</a>
            </h4>
              <img class="card-img-top" src="img/default/rheinLineas.jpg" alt="">
             <%-- <ul>
                <li> Discos Diamantados .</li>
                <li>Discos de Corte y Desbaste.</li>
                <li>Discos Flap.</li>
                <li>Llaves Combinadas.</li>
                <li>Llaves "T" (Pulgadas y Milimétricas).</li>
                <li>Bocallaves (Pulgadas y Milimétricas) y Accesorios.</li>
                <li>Cepillos Circulares</li>
                <li>Sierras Circulares.</li>
                <li>Sierras Copa</li>
                <li>- Diente de Widia.</li>
                <li>- Bimetálica.</li>
                <li>- Carburo Tungsteno.</li>
             </ul>--%>
           </div>
        </div>
      </div>
      <div class="col-lg-4 col-sm-6 portfolio-item">
        <div class="card h-100">
          <a href="https://metz.com.ar/"><img class="card-img-top" src="img/default/metz.jpg" alt=""></a>
          <div class="card-body">
            <h4 class="card-title">
              <a href="#">Metz</a>
            </h4>
              <img class="card-img-top" src="img/default/metzLineas.jpg" alt="">
        <%--     <ul>
                <li>Pinzas “Cromadas” Pico de Loro </li>
                <li>-Pico de Loro (Tipo Knipex)</li>
                <li>-Rosario (Artesanos).</li>
                <li>-Universal</li>
                <li>Alicates “Cromados” </li>
                <li>-Corte Oblicuo</li>
                <li>-Media Caña</li>
                <li>-Punta Chata</li>
                <li>-Punta Curva</li>
                <li>Llaves Ajustables </li>
                <li>Tenazas (Armador y Carpintero) </li> 
                <li>Destornilladores;  </li>
                <li>-Punta Cónica Plana </li>
                <li>-Punta Philips </li>
                <li>-Punta Pozi Drive</li>
                <li>-Punta Torx</li>
                <li>-Punta Torx Tamper</li>
            </ul>--%>
          </div>
        </div>
      </div>
      <div class="col-lg-4 col-sm-6 portfolio-item">
        <div class="card h-100">
          <a href="https://koln.com.ar/"><img class="card-img-top" src="img/default/koln.jpg" alt=""></a>
          <div class="card-body">
            <h4 class="card-title">
              <a href="#">Köln</a>
            </h4>
              <img class="card-img-top" src="img/default/kolnLineas.jpg" alt="">
         <%--  <ul>
                <li> item Machos</li>
                <li>–   Tipo BSW Cono / Set</li>
                <li>–   Tipo NF Cono / Set</li>
                <li>–   Tipo M Cono / Set Traba</li>
                <li>–   Tipo NC Cono / Set</li>
                <li>–   Tipo BSP Cono / Set</li>
                </ul> 
                <ul>
                <li> Discos Abrasivos Esmeril (Oxido de Aluminio)</li>
                <li> Discos Abrasivos con Velcro.</li>
                <li> Hojas de Lija (Al Agua – Para Madera – Tela Esmeril). </li>
                <li> Discos de Respaldo (Goma – Plástico – Contratuerca – etc.) </li>
                
            </ul>--%>
          </div>
        </div>
      </div>
      <div class="col-lg-4 col-sm-6 portfolio-item">
        <div class="card h-100">
          <a href="https://proll.com.ar/"><img class="card-img-top" src="img/default/proll.jpg" alt=""></a>
          <div class="card-body">
            <h4 class="card-title">
              <a href="#">Pröll</a>
            </h4>
              <img class="card-img-top" src="img/default/prollLineas.jpg" alt="">
             <%-- <ul>
                <li> Candados Cromados “Doble Traba”.</li>
                <li> Candados de Bronce.</li>
                <li> Candados de Titanio “Doble Traba”</li>
                <li> Candados de Titanio “Doble Traba”</li>
                <li> Candados de Titanio “Doble Traba” (Arco Alto)</li>
                <li> Candados de Platino “Doble Traba”</li>
                <li> Candados de Platino “Doble Traba” (Arco Alto)</li>
                <li> Pasador con Traba “Zincado”.</li>
                <li> Pasador con Traba “Empavonado”.</li>
            </ul>--%>
          </div>
        </div>
      </div>
      <div class="col-lg-4 col-sm-6 portfolio-item">
        <div class="card h-100">
          <a href="https://plenalimas.com.ar/"><img class="card-img-top" src="img/default/plena.jpg" alt=""></a>
          <div class="card-body">
            <h4 class="card-title">
              <a href="#">Plena Limas</a>
            </h4>
              <img class="card-img-top" src="img/default/plena.Lineasjpg.jpg" alt="">
             <%-- <ul>
                <li> LIMA “PLENA” CUADRADA</li>
                <li>LIMA “PLENA” ESCOFINA</li>
                <li>LIMA “PLENA” MEDIA CAÑA.</li>
                <li>LIMA “PLENA” PARALELA.</li>
                <li>LIMA “PLENA” REDONDA</li>
                <li>LIMA “PLENA” REGULAR TAPER</li>
                <li>LIMA “PLENA” ROMBOIDAL</li>
                <li>LIMA “PLENA” SLIM TAPER</li>
                <li>LIMA “PLENA” TRIANGULO</li>
                <li>MANGOS  PLENAS </li>
             </ul>--%>
          </div>
        </div>
      </div>
      <div class="col-lg-4 col-sm-6 portfolio-item">
        <div class="card h-100">
          <a href="https://essamet.com.ar/"><img class="card-img-top" src="img/default/essamet.jpg" alt=""></a>
          <div class="card-body">
            <h4 class="card-title">
              <a href="#">Essamet</a>
            </h4>
              <img class="card-img-top" src="img/default/essametLineas.jpg" alt="">
         <%--  <ul>
                <li> Mechas de Acero Rápido  </li>
                <li> Mechas de Widia.</li>
                <li> Mechas tipo SDS Plus.</li>
                <li> Cintas Métricas</li>
                <li> Pinceles Profesionales de Cerda Blanca</li>
               
            </ul>--%>
          </div>
        </div>
      </div>
    </div>
    <!-- /.row -->

    <!-- Features Section -->
    <div class="row">
      <div class="col-lg-12">
        <h2>Expendedores</h2>
        <p>EXHIBICIONES DE APARADOR Y MOSTRADOR </p>
        
       <%-- <ul>

            . Algunas sugerencias para la colocación de los artículos son:
    <li>1. Es necesario que la línea de productos que se exhibe se mantenga siempre
completa.</li>
<li>2. Colocar los productos a la altura de los ojos.</li>
<li>3. Los anuncios de los precios también deben colocarse a la altura de los ojos del
consumidor.</li>
<li>4. Es conveniente que las mercancías estén ordenadas, de manera que faciliten su
manejo al comprador.</li>
<li>5. El promotor debe de colocar cerca de cada exhibición un cartel. El impacto
provocado por el colorido del material impreso se refuerza por la repetición de la
marca.</li>
<li>6. Los diseños de las envolturas deben provocar el mayor impacto posible en el
consumidor incitando su deseo de compra.</li>

        </ul>--%>
        
      </div>
        <div class="col-lg-6">
         <img class="img-fluid rounded" src="img/default/expendedor.jpg" alt="">     
      </div>
      <div class="col-lg-6">
        <img class="img-fluid rounded" src="img/default/expendedores.jpg" alt="">
      </div>
    </div>
    <!-- /.row -->

    <hr>

    <!-- Call to Action Section -->
    <div class="row mb-4">
      <div class="col-md-8">
          <h4 style="text-align:center;">
                                        <img src="img/footer/footer_facebook.png" alt="Facebook">
                                        <img src="img/footer/footer_gplus.png" alt="Google Plus">
                                        <img src="img/footer/footer_twitter.png" alt="Twitter">
                                        <img src="img/footer/footer_youtube.png" alt="Youtube">
                                        <samp class="copy">
                                            <a href="http://qr.afip.gob.ar/?qr=HCsLZQkuH3_dzEMx3LODcQ,," target="_F960AFIPInfo">
                                            <img src="https://www.afip.gob.ar/images/f960/DATAWEB.jpg" border="0" alt="0" align="bottom" style="height: 54px; width: 38px ;margin-left:5px"></a>
                                        </samp>
                                  </h4>
      </div>
      <div class="col-md-4">
        <a class="btn btn-lg btn-secondary btn-block" href="Pedidos.aspx">Haga su Pedido</a>
      </div>
    </div>
</div>
  
</asp:Content>

