<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterEsoriano.Master" CodeBehind="AdministracionNovedades.aspx.vb" Inherits="Esoriano.AdministracionNovedades" %>
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
              <div >
                     <asp:Label ID="Label1" runat="server" Text="2" Visible="False"></asp:Label>
                     <asp:textbox id="txtemp" runat ="server" height ="16px" width="48px" Visible="False"></asp:textbox>
                     <asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
              </div>
              <%--<asp:ImageButton ID="ImageButton9" runat="server" Height="29px" ImageUrl="~/admin/Imagenes/administracion/images/agregar_novedad.png" Width="110px" style="margin-top: 0px" ImageAlign="Top" />--%>
              <asp:Label ID="Label2" runat="server" Text="Label" Visible="False"></asp:Label>
              <asp:gridview runat ="server" id ="grnovedades"  CssClass="table table-xl table-striped " GridLines="None" Width="100%" AllowPaging="true" OnPageIndexChanging="grnovedades_PageIndexChanging">
                   <Columns>
                        <asp:ButtonField Text="Editar" CommandName="Editar"   />
                        <asp:ButtonField Text="Eliminar" CommandName="Eliminar" />
                       <asp:ButtonField Text="Nuevo" CommandName="Nuevo" />
                      <asp:BoundField Visible="False" />
                   </Columns>
              </asp:gridview>
        </div>
    </div>                 
</asp:Content>
