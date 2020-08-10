<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterEsoriano.Master" CodeBehind="profolio.aspx.vb" Inherits="Esoriano.profolio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="Stylesheet" href="css/prof.css" />
    <script src="Scripts/porfolio.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!DOCTYPE html>

    <div class="main">
        <!-- MAIN (Center website) -->
        <div class="container">
            <!-- Page Heading/Breadcrumbs -->
            <h1 class="mt-4 mb-3">
                <small>Imágenes</small>
            </h1>

            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a href="Default.aspx">Home</a>
                </li>
                <li class="breadcrumb-item active">Portfolio</li>
            </ol>
            <div id="myBtnContainer">
              <asp:Button runat="server" Text="ESoriano " CssClass="btn active" ID="btn_soriano" Onclick="btn_soriano_Click" />
              <asp:Button runat="server" Text="Pröll" CssClass="btn" ID="btn_Proll" OnClick="btn_Proll_Click" />
              <asp:Button runat="server" Text="Rhein"  CssClass="btn" ID="btn_Rhein" OnClick="btn_Rhein_Click" />
              <asp:Button runat="server" Text="Köln"  CssClass="btn" ID="btn_Koln" OnClick="btn_Koln_Click" />
              <asp:Button runat="server" Text="PlenaLimas"  CssClass="btn" ID="btn_PlenaLimas" OnClick="btn_PlenaLimas_Click" />
              <asp:Button runat="server" Text="Essamet"  CssClass="btn" ID="btm_Essamet" OnClick="btm_Essamet_Click" />
              <asp:Button runat="server" Text="Metz"  CssClass="btn" ID="btn_Metz" OnClick="btn_Metz_Click" />
            </div>
            <!-- Portfolio Gallery Grid -->
      

            <div class="row">
              <div class="column Proll col-lg-4 col-sm-4 ">
                <div class="card h-100">
                  <img src="img/porfolio/proll2.jpg" alt="Pröll" style="width:100%">
               <%--   <h4>Importadora de Candados</h4>
                  <p>Lorem ipsum dolor..</p>--%>
                </div>
              </div>
              <div class="column Proll col-lg-4 col-sm-4 ">
                <div class="card h-100">
                  <img src="img/porfolio/proll1.jpg" alt="Pröll" style="width:100%">
                <%--  <h4>Importadora de Candado</h4>
                  <p>Lorem ipsum dolor..</p>--%>
                </div>
              </div>
              <div class="column Proll col-lg-4 col-sm-4 ">
                <div class="card h-100">
                  <img src="img/porfolio/proll3.jpg" alt="Pröll" style="width:100%">
             <%--     <h4>Importadora de Candado</h4>
                  <p>Lorem ipsum dolor..</p>--%>
                </div>
              </div>
              <div class="column Rhein col-lg-4 col-sm-4 ">
                <div class="card h-100">
                  <img src="img/porfolio/rhein2.jpg" alt="Rhein" style="width:100%">
             <%--     <h4>Tecnologia Alemana en herramientas</h4>
                  <p>Lorem ipsum dolor..</p>--%>
                </div>
              </div>
              <div class="column Rhein col-lg-4 col-sm-4 ">
                <div class="card h-100">
                  <img src="img/porfolio/rhein1.jpg" alt="Rhein" style="width:100%">
                  <%--<h4>Tecnologia Alemana en herramientas</h4>
                  <p>Lorem ipsum dolor..</p>--%>
                </div>
              </div>
              <div class="column Rhein col-lg-4 col-sm-4 ">
                <div class="card h-100">
                  <img src="img/porfolio/rhein3.jpg" alt="Rhein" style="width:100%">
                <%--  <h4>Tecnologia Alemana en herramientas</h4>
                  <p>Lorem ipsum dolor..</p>--%>
                </div>
              </div>
              <div class="column Koln col-lg-4 col-sm-4 ">
               <div class="card h-100">
                  <img src="img/porfolio/koln1.jpg" alt="Köln" style="width:100%">
                <%--  <h4>Importadora Discos y Lijas</h4>
                  <p>Lorem ipsum dolor..</p>--%>
                </div>
              </div>
              <div class="column Koln col-lg-4 col-sm-4 ">
                <div class="card h-100">
                  <img src="img/porfolio/koln2.jpg" alt="Köln" style="width:100%">
          <%--        <h4>Importadora Discos y Lijas</h4>
                  <p>Lorem ipsum dolor..</p>--%>
                </div>
              </div>
              <div class="column Koln col-lg-4 col-sm-4 ">
                  <div class="card h-100">
                    <img src="img/porfolio/koln3.jpg" alt="Köln" style="width:100%">
 <%--                   <h4>Importadora Discos y Lijas</h4>
                    <p>Lorem ipsum dolor..</p>--%>
                  </div>
              </div>
              <div class="column PlenaLimas col-lg-4 col-sm-4 ">
                <div class="card h-100">
                  <img src="img/porfolio/plena1.jpg" alt="PlenaLimas" style="width:100%">
    <%--              <h4>Linea Industrial</h4>
                  <p>Lorem ipsum dolor..</p>--%>
                </div>
              </div>
              <div class="column PlenaLimas col-lg-4 col-sm-4 ">
                <div class="card h-100">
                <img src="img/porfolio/plena2.jpg" alt="PlenaLimas" style="width:100%">
 <%--                 <h4>Linea Industrial</h4>
                  <p>Lorem ipsum dolor..</p>--%>
                </div>
              </div>
              <div class="column PlenaLimas col-lg-4 col-sm-4 ">
                <div class="card h-100">
                  <img src="img/porfolio/plena3.jpg" alt="PlenaLimas" style="width:100%">
        <%--          <h4>Linea Industrial</h4>
                  <p>Lorem ipsum dolor..</p>--%>
                </div>
              </div>
              <div class="column Essamet col-lg-4 col-sm-4 ">
                <div class="card h-100">
                <img src="img/porfolio/essamet2.jpg" alt="Essamet" style="width:100%">
  <%--                <h4>Cintas Pinceles y Mechas </h4>
                  <p>Lorem ipsum dolor..</p>--%>
                </div>
              </div>
              <div class="column Essamet col-lg-4 col-sm-4 ">
                <div class="card h-100">
                <img src="img/porfolio/essamet1.jpg" alt="Essamet" style="width:100%">
<%--                  <h4>Cintas Pinceles y Mechas</h4>
                  <p>Lorem ipsum dolor..</p>--%>
                </div>
                </div>
              <div class="column Essamet col-lg-4 col-sm-4 ">
                <div class="card h-100">
                    <img src="img/porfolio/essamet3.jpg" alt="Essamet" style="width:100%">
    <%--                <h4>Cintas Pinceles y Mechas </h4>
                    <p>Lorem ipsum dolor..</p>--%>
                </div>
              </div>
              <div class="column Metz col-lg-4 col-sm-4 ">
                <div class="content">
                <img src="img/porfolio/metz1.jpg" alt="Metz" style="width:100%">
 <%--                 <h4>Tecnologia Francesa</h4>
                  <p>Lorem ipsum dolor..</p>--%>
                </div>
              </div> 
              <div class="column Metz col-lg-4 col-sm-4 ">
                <div class="content">
                    <img src="img/porfolio/metz2.jpg" alt="Metz" style="width:100%">
        <%--            <h4>Tecnologia Francesa</h4>
                    <p>Lorem ipsum dolor..</p>--%>
                </div>
              </div>
              <div class="column Metz col-lg-4 col-sm-4 ">
                <div class="content">
                  <img src="img/porfolio/metz3.jpg" alt="Metz" style="width:100%">
           <%--       <h4>Tecnologia Francesa</h4>
                  <p>Lorem ipsum dolor..</p>--%>
                </div>
              </div>
            <!-- END GRID -->
            </div>
       </div>
       <!-- END MAIN -->
    </div>
</asp:Content>

