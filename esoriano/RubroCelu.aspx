<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterEsoriano.Master" CodeBehind="RubroCelu.aspx.vb" Inherits="Esoriano.RubroCelu" %>
<%@ Register Src="~/WebControl/WebUserControlCabecera.ascx" TagName="Cabecera" TagPrefix="Cab" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   

    <script type="text/javascript">

                //window.location.href = "pedidos.aspx";
         

        window.onload = function () {
            noBack();
       }
        function noBack() {
            
            window.history.forward();
       }
    </script>


 <style>
.fixed-top-2 {
    margin-top: 54px;
}

body {
    padding-top: 230px;
}

.card-header
{
font-weight:bold;
 color:floralwhite;
 background-color:darkred;
 text-align:center;
 }
.font-italic {
 font-size:13px;
font-weight:bold;

  }
.breadcrumb-item a{
     font-weight: bold;
    text-decoration :none;
   color:black;
   
 }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLogoPedidos" runat="server">
         <div class="fixed-top fixed-top-2">
            <Cab:Cabecera ID="cab" runat="server" />
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <div class="container col-10">
     <asp:FormView runat="server" ID="FormViewPath1" EnableModelValidation="True"  Width="100%"   >
         <ItemTemplate>
            <ol class="breadcrumb">
               <li class="breadcrumb-item ">
                    <a href="Pedidos.aspx">PEDIDOS</a>
                </li>
                <li class="breadcrumb-item">
                    <a href="ProductoRubroCelu.aspx">RUBROS</a>
                </li>
                <li class="breadcrumb-item">
                     <a href="SubRubroCelu.aspx?Rub=<%# Eval("RUB_CODIGO") %>"><%# Eval("RUB_NOMBRE")%></a>
                </li>
                  <li class="breadcrumb-item active"><%# Eval("SRB_NOMBRE")%>
                </li>
            </ol>
        </ItemTemplate>
      </asp:FormView>
      <asp:Panel ID="Panel1" runat="server" Visible="TRUE">
        <div  align="center" >
            <asp:ImageButton ID="ImageButton5" runat="server" 
                            ImageUrl="~/img/botones/upload.jpg" Width="48px"  
                            height="22px" ImageAlign="Right" />
                 
        </div>
        <br />
       </asp:Panel>
       <div class="row " >
         <asp:DataList ID="DataListArtLogin" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="row">
          <ItemTemplate>
             <div class="col" >
                <div class="card-header"  >
                    <h3> <p  runat="server" id="codart"><%# Eval("art_CODIGO") %></p></h3>
                    <hr />
                </div>
                <div class="card-body">
                <div class="display-3">$<%# Eval("LST_PRECIO1") %></div>
                <div class="font-italic" ><%# Eval("ART_NOMBRE") %></div>
             </div>
             <ul class="list-group list-group-flush">
             <li class="list-group-item">U.Env : <a><%# Eval("ART_UND_CONSUMO") %></a></li>
             <li class="list-group-item">Unidad : <a><%# Eval("UND_NOMBRE") %></a></li>
             <li class="list-group-item">U.Bulto : <a><%# Eval("ART_UND_BULTO") %></a></li>
             <li class="list-group-item">
                <asp:TextBox runat="server" ID="TextCanti" CssClass="art_imputcant"  
                                        Text='<%# BIND("CANTIDAD") %>' Width="50%" />
                                        <asp:RegularExpressionValidator id="valida_Cantidad" runat="SERVER" 
                                        ControlToValidate="TextCanti" ErrorMessage="Solo Num." ValidationExpression="\d*\.?\d*" Font-Size="XX-Small">
                                        </asp:RegularExpressionValidator> 
             </li>
             
             <li class="list-group-item">
                 
                  <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem Text="0" Value="0"></asp:ListItem>
                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                        <asp:ListItem Text="8" Value="8"></asp:ListItem>
                        <asp:ListItem Text="9" Value="9"></asp:ListItem>
                   </asp:DropDownList>
                   <asp:DropDownList ID="DropDownList2" runat="server">
                        <asp:ListItem Text="0" Value="0"></asp:ListItem>
                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                        <asp:ListItem Text="8" Value="8"></asp:ListItem>
                        <asp:ListItem Text="9" Value="9"></asp:ListItem>
                   </asp:DropDownList>
                   <asp:DropDownList ID="DropDownList3" runat="server" >
                        <asp:ListItem Text="0" Value="0"></asp:ListItem>
                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                        <asp:ListItem Text="8" Value="8"></asp:ListItem>
                        <asp:ListItem Text="9" Value="9"></asp:ListItem>
                   </asp:DropDownList>
                  <asp:DropDownList ID="DropDownList4" runat="server"  >
                        <asp:ListItem Text="0" Value="0"></asp:ListItem>
                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                        <asp:ListItem Text="8" Value="8"></asp:ListItem>
                        <asp:ListItem Text="9" Value="9"></asp:ListItem>
                   </asp:DropDownList>
                   <asp:ImageButton ImageAlign="Right" runat="server" ID="btn_cantidad_combo" OnClick="btn_cantidad_combo_Click" ImageUrl="~/img/botones/upload.jpg" Height="25px"  />
                </li>
              </ul>
           </div>
         </ItemTemplate>
       </asp:DataList>
    </div>
  </div>
</asp:Content>
