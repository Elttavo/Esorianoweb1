<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WebUserControlNavAdm.ascx.vb" Inherits="Esoriano.WebUserControlNavAdm" %>

<div>
     <nav class="navbar  navbar-expand-lg navbar-dark bg-dark nav-justified">
    <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>   
      <div class="collapse navbar-collapse" id="navbarResponsive">
        <ul class="navbar-nav">
             <li class="nav-item" style="margin-left:10%;">
            <a class="nav-link" href="inicio.aspx">Administracion</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="archivos.aspx">Importacion</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="exportacion.aspx">Exportacion </a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="AdministracionNovedades.aspx">Novedades </a>
          </li>
             <li class="nav-item">
            <a class="nav-link" href="VerPedidoA.aspx">PedidosActivo </a>
          </li>
              <li class="nav-item">
            <a class="nav-link" href="/default.aspx">salir </a>
          </li>
        
        </ul>
      </div>
     </nav>
 </div>
