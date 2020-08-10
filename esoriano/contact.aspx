<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterEsoriano.Master" CodeBehind="contact.aspx.vb" Inherits="Esoriano.contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <title>ESORIANO_CONTACTO</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      
  <!-- Page Content -->
  <div class="container">

    <!-- Page Heading/Breadcrumbs -->
    <h3 class="mt-4 mb-3">Contactos </h3>

    <ol class="breadcrumb">
      <li class="breadcrumb-item">
        <a href="Default.aspx">Home</a>
      </li>
      <li class="breadcrumb-item active">Contactos</li>
    </ol>

    <div class="row">
      <!-- Map Column -->
      <div class="col-lg-6 mb-4">
        <!-- Embedded Google Map -->
        <img class="img-fluid rounded mb-4" src="img/contacto/llamando.jpg" alt="">

         <p> Ingrese a los sitios web de la Empresa y realice pedidos, consultas al catálogo, listas de precios, facturas emitidas, promociones, novedades y más </P>
          <br />
          <a href="https://www.esoriano.com.ar">www.esoriano.com.ar</a>
          <br />
          <a href="https://www.esorianosa.com.ar">www.esorianosa.com.ar</a>

      </div>
        <div class="col-lg-6 mb-4">
        <h3>Envíe su Mensaje</h3>
         
              <div class="form-row">
                <div class="form-group col-md-6">
                  <label for="inputEmail4">E-mail</label>
                  <asp:textbox  runat="server" type="email" class="form-control" id="inputEmail4" placeholder="Email@esoriano.com.ar"/>
                </div>
                <div class="form-group col-md-6">
                  <label for="inputPassword4">Nombre del contacto</label>
                  <asp:textbox runat="server" type="text" class="form-control" id="inputnNombre" placeholder="Enrique Soriano"/>
                </div>
  
              <div class="form-group col-md-3">
                <label for="inputAddress"> Empresa</label>
                <asp:textbox runat="server" type="text" class="form-control" id="inputEmpresa" placeholder="Enrique Sorino S.A."/>
              </div>
              <div class="form-group col-md-3">
                <label for="inputAddress2">Dirección</label>
                <asp:textbox runat="server"  type="text" class="form-control" id="inputAddress" placeholder="Gral Paz ...."/>
              </div>

                  <div class="form-group col-md-3">
                  <label for="inputState">Tipo de empresa</label>
                  <select name="Provincia" id="inputtipoEmpresa" class="form-control" runat="server">
                  <option value="">Seleccione tipo de empresa</option>
                  <option value="Ferretero">Ferretero</option>
                  <option value="Mayorista">Mayorista</option>
                  <option value="Representante de Ventas">Representante de Ventas</option>
                  <option value="Corredor">Corredor</option>
                </select>
                </div>

                <div class="form-group col-md-3">
                  <label for="inputState">Provincia</label>
                    <select name="Provincia" id="inputState" class="form-control" runat="server">
	                <option value="">Seleccione Provincia</option>    
	                      <option value="1-Buenos Aires">Buenos Aires</option>
	                      <option value="2-Buenos Aires Capital">Buenos Aires Capital</option>
	                      <option value="3-Catamarca">Catamarca</option>
	                      <option value="4-Chaco">Chaco</option>
	                      <option value="5-Chubut">Chubut</option>
	                      <option value="6-Córdoba">Córdoba</option>
	                      <option value="7-Corrientes">Corrientes</option>
	                      <option value="8-Entre Ríos">Entre Ríos</option>
	                      <option value="9-Formosa">Formosa</option>
	                      <option value="10-Jujuy">Jujuy</option>
	                      <option value="11-La Pampa">La Pampa</option>
	                      <option value="12-La Rioja">La Rioja</option>
	                      <option value="13-Mendoza">Mendoza</option>
	                      <option value="14-Misiones">Misiones</option>
	                      <option value="15-Neuquen">Neuquen</option>
	                      <option value="16-Río Negro">Río Negro</option>
	                      <option value="17-Salta">Salta</option>
	                      <option value="18-San Juan">San Juan</option>
	                      <option value="19-San Luis">San Luis</option>
	                      <option value="20-Santa Cruz">Santa Cruz</option>
	                      <option value="21-Santa Fe">Santa Fe</option>
	                      <option value="22-Santiago del Estero">Santiago del Estero</option>
	                      <option value="23-Tucumán<">Tucumán</option>
	                      </select>	 

                </div>
      
                <div class="form-group col-md-3 ">
                  <label for="inputCity">Localidad</label>
                  <asp:textbox runat="server"  type="text" class="form-control" id="inputCity"/>
                </div>

                <div class="form-group col-md-3">
                  <label for="inputCP">Código postal</label>
                  <asp:textbox runat="server" type="text" class="form-control" id="inputCodPostal"/>
                </div>
              </div>
              <div class="mb-3">
                <label for="validationTextarea">Comentarios</label>
                <asp:textbox runat="server" class="form-control" id="validationTextarea" placeholder="Envíe un comentario" ></asp:textbox>
                <div class="invalid-feedback">
                  Comentarios
                </div>
              </div>
              <div class="form-group">
                <div class="form-check">
                  <input class="form-check-input" type="checkbox" id="gridCheck">
                  <label class="form-check-label" for="gridCheck">
                    Check me out
                  </label>
                </div>
              </div>

   <div>
            <table>
                <tr>
                    <td>
                        <asp:Image ID="imgCaptcha" runat="server" 
                            ImageUrl="~/CreateCaptcha.aspx?New=1" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtCaptcha" runat="server">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMessage" runat="server">
                        </asp:Label>
                    </td>
                </tr>
              <%--  <tr>
                    <td>
                        <asp:Button ID="btnCaptcha" runat="server" 
                            Text="Validar captcha" OnClick="btnMandarMail_Click" />
                    </td>
                </tr>--%>
            </table>
        </div>
      
            <asp:Button type="submit" class="btn btn-danger " runat="server" Text="Enviar" ID="btnMandarMail" OnClick="btnMandarMail_Click"></asp:Button>
            <asp:Label ID="lblerror" runat="server" />
      </div>
      <!-- Contact Details Column -->
      
    </div>

    <div class="row">
      
        <div class="col-lg-6 mb-4">
        <h3> Nuestra ubicación </h3>
            <p>
                Provincia de  Buenos Aires
                <br>
                Partido de Avellaneda
            </p>
         
       <h3>
            <p title="Phone"> Teléfono </p>   </h3>
                <p >(011) 4201-5233</p>
     
      
           </div>
           <div class="col-lg-6 mb-4">
           <h3>
            <p title="Email"> E-mail </p>  </h3>
               <a href="mailto:ventas@esoriano.com.ar">ventas@esoriano.com.ar</a>
           <h3>
            <p title="Hours"> Horario de atención </p>   </h3> 
                <p >Lunes a Viernes de 7:00 a 15:00 Horas </p>
      </div>
    </div>
  

  <script src="js/jqBootstrapValidation.js"></script>
  <script src="js/contact_me.js"></script>
</div>
</asp:Content>
