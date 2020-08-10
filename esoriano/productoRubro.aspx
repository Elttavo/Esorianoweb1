<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterEsoriano.Master" CodeBehind="ProductoRubro.aspx.vb" Inherits="Esoriano.productos_por_rubro" %>
<%@ Register Src="~/WebControl/WebUserControlCabecera.ascx" TagName="Cabecera" TagPrefix="Cab" %>
<%@ Register Src="~/WebControl/WebUserControlPath.ascx" TagName="Path" TagPrefix="Pat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <script src="Content/lib/SimpleHorizontalScroll.js" type="text/javascript"></script>
    <script src="Content/lib/prototype.js" type="text/javascript"></script>
    <script src="Content/scr/scriptaculous.js" type="text/javascript"></script>
    <script src="Content/scr/unittest.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <Cab:Cabecera ID="Cabecera" runat="server" />  
 <div class="container col-12 ">

    <!-- Page Heading/Breadcrumbs -->
    <h1 class="mt-4 mb-3">
      <small>Pedidos por Rubros</small>
    </h1>

    <ol class="breadcrumb">
      <li class="breadcrumb-item">
        <a href="Pedidos.aspx">PEDIDOS</a>
      </li>
      <li class="breadcrumb-item active">POR RUBROS</li>
    </ol>

    <!-- Image Header -->

   <div class="container col-10">
  <div class="row">
   <div class="col">
     <table >
         <tr>
             <th class="auto-style5" >
                 <a name='#a' id='#a'>A</a>
              </th>
            </tr>
         <tr>
              <td class="auto-style6">
                  <asp:DataList ID="DataListA" runat="server"  Font-Size="9pt"  RepeatColumns="1" BorderStyle="None" CellPadding="0" Font-Names="Arial">
                                                <ItemStyle VerticalAlign="Top" />
                                                <ItemTemplate>
                                                    <table >
                                                        <tr>
                                                            <td >
                                                                <table >
                                                                    <tr>
                                                                        <td >
                                                                            <table >
                                                                                <tr>
                                                                                    <td style="padding-right: 2px" width="10">
                                                                                        <img alt="" src="images/vineta_princ.gif" width="8" />
                                                                                    </td>
                                                                                    <td>
                                                                                         <a href="#" onclick="Effect.toggle('d<%# Eval("RUB_CODIGO") %>','slide'); return false;"
                                                                                            class="Linkp">
                                                                                          <%--<%#Eval("RUB_NOMBRE")%>--%>
                                                                                             <asp:Image id="myImage"  runat="server"  Height="23"  ImageUrl='<%# DataBinder.Eval(Container, "DataItem.RUB_IMAGEN", "~/IMG/rubros/{0}")%>'>    
                                                                                                  </asp:Image > 
                                                                                        </a>
                                                                                                                                                                                                                                        
                                                                                                                                                                                                                                                                                                                                
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td >
                                                                            <div id="d<%# Eval("RUB_CODIGO") %>" style="display: none;" class="tdsec">
                                                                                <table >
                                                                                    <tr>
                                                                                        <td style="padding: 5px;">
                                                                                            <asp:DataList ID="DataList2" runat="server" DataSourceID="ObjectDataSource3">
                                                                                                <ItemTemplate>
                                                                                                    <table >
                                                                                                        <tr>
                                                                                                            <td class="td3">
                                                                                                                <img alt="" src="images/vineta_sec.gif" width="8" />
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                <a href="rubro.aspx?Rub=<%# Eval("RUB_CODIGO") %>&amp;Sub=<%# Eval("SRB_CODIGO") %>"
                                                                                                                     class="text-dark" ">
                                                                                                                    <%# Eval("SRB_NOMBRE") %></a>
                                                                                                               
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                    
                                                                                                </ItemTemplate>
                                                                                            </asp:DataList>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetSubRubrosxAbc"
                                                                                    TypeName="ClassLibrary1.Rubros">
                                                                                    <SelectParameters>
                                                                                        <asp:ControlParameter ControlID="HiddenField1" Name="RUB_CODIGO" PropertyName="Value" Type="Int32" />
                                                                                    </SelectParameters>
                                                                                </asp:ObjectDataSource>
                                                                                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("RUB_CODIGO") %>' />
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                                <SelectedItemStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                   </asp:DataList>
              </td>
         </tr>
         <tr>
                                        <th class="auto-style5">
                                            <a name='#b' id='b'>B</a>
                                        </th>
                                    </tr>
         <tr>
                                        <td >
                                              <asp:DataList ID="DataListB" runat="server"  Font-Size="9pt"
                                                RepeatColumns="1" BorderStyle="None" CellPadding="0" Font-Names="Arial" >
                                                <ItemStyle VerticalAlign="Top" />
                                                <ItemTemplate>
                                                    <table >
                                                        <tr>
                                                            <td class="td1">
                                                                <table >
                                                                    <tr>
                                                                        <td valign="top" >
                                                                            <table >
                                                                                <tr>
                                                                                    <td style="padding-right: 2px" width="10">
                                                                                        <img alt="" src="images/vineta_princ.gif" width="8" />
                                                                                    </td>
                                                                                    <td>  
                                                                                        <a href="#" onclick="Effect.toggle('d<%# Eval("RUB_CODIGO") %>','slide'); return false;"
                                                                                            class="Linkp">
                                                                                           <asp:Image id="myImage"  runat="server" Height="23"   ImageUrl='<%# DataBinder.Eval(Container, "DataItem.RUB_IMAGEN", "~/IMG/rubros/{0}")%>'>    
                                                                                                  </asp:Image > 
                                                                                      
                                                                                            <%--<%#Eval("RUB_NOMBRE")%>--%>
                                                                                        </a>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top">
                                                                            <div id="d<%# Eval("RUB_CODIGO") %>" style="display: none;" class="tdsec">
                                                                                <table >
                                                                                    <tr>
                                                                                        <td style="padding: 5px;">
                                                                                            <asp:DataList ID="DataList2" runat="server" DataSourceID="ObjectDataSource3">
                                                                                                <ItemTemplate>
                                                                                                    <table >
                                                                                                        <tr>
                                                                                                            <td class="td3">
                                                                                                                <img alt="" src="images/vineta_sec.gif" width="8" />
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                <a href="rubro.aspx?Rub=<%# Eval("RUB_CODIGO") %>&amp;Sub=<%# Eval("SRB_CODIGO") %>"
                                                                                                                    class="text-dark" >
                                                                                                                    <%# Eval("SRB_NOMBRE") %></a>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </ItemTemplate>
                                                                                            </asp:DataList>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetSubRubrosxB"
                                                                                    TypeName="ClassLibrary1.Rubros">
                                                                                    <SelectParameters>
                                                                                        <asp:ControlParameter ControlID="HiddenField1" Name="RUB_CODIGO" PropertyName="Value"
                                                                                            Type="Int32" />
                                                                                    </SelectParameters>
                                                                                </asp:ObjectDataSource>
                                                                                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("RUB_CODIGO") %>' />
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:DataList>
                                        </td>
                                    </tr>
         <tr>
                                        <th class="auto-style5">
                                            <a name='#c' id='c'>C</a>
                                        </th>
                                    </tr>
         <tr>
                                        <td class="auto-style6">
                                            <asp:DataList ID="DataListC" runat="server" Font-Size="9pt"
                                                RepeatColumns="1" BorderStyle="None" CellPadding="0" Font-Names="Arial" Width="100%">
                                                <ItemStyle VerticalAlign="Top" />
                                                <ItemTemplate>
                                                    <table >
                                                        <tr>
                                                            <td >
                                                                <table >
                                                                    <tr>
                                                                        <td valign="top" >
                                                                            <table >
                                                                                <tr>
                                                                                    <td style="padding-right: 2px" width="10">
                                                                                        <img alt="" src="images/vineta_princ.gif" width="8" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <a href="#" onclick="Effect.toggle('d<%# Eval("RUB_CODIGO") %>','slide'); return false;"
                                                                                            class="Linkp">
                                                                                           <asp:Image id="myImage"  runat="server"  Height="23"  ImageUrl='<%# DataBinder.Eval(Container, "DataItem.RUB_IMAGEN", "~/IMG/rubros/{0}")%>'>    
                                                                                                  </asp:Image > 
                                                                                        
                                                                                           <%--<%#Eval("RUB_NOMBRE")%>--%>
                                                                                        </a>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td >
                                                                            <div id="d<%# Eval("RUB_CODIGO") %>" style="display: none;" class="tdsec">
                                                                                <table >
                                                                                    <tr>
                                                                                        <td style="padding: 5px;">
                                                                                            <asp:DataList ID="DataList2" runat="server" DataSourceID="ObjectDataSource3">
                                                                                                <ItemTemplate>
                                                                                                    <table >
                                                                                                        <tr>
                                                                                                            <td class="td3">
                                                                                                                <img alt="" src="images/vineta_sec.gif" width="8" />
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                <a href="rubro.aspx?Rub=<%# Eval("RUB_CODIGO") %>&amp;Sub=<%# Eval("SRB_CODIGO") %>"
                                                                                                                    class="text-dark" >
                                                                                                                    <%# Eval("SRB_NOMBRE") %></a>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </ItemTemplate>
                                                                                            </asp:DataList>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetSubRubrosxC"
                                                                                    TypeName="ClassLibrary1.Rubros">
                                                                                    <SelectParameters>
                                                                                        <asp:ControlParameter ControlID="HiddenField1" Name="RUB_CODIGO" PropertyName="Value"
                                                                                            Type="Int32" />
                                                                                    </SelectParameters>
                                                                                </asp:ObjectDataSource>
                                                                                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("RUB_CODIGO") %>' />
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:DataList>
                                        </td>
                                    </tr>

     </table>
    </div>
    <div class="col">
      <table   >
                              
        <tr>
                                        <th class="Letra">
                                            <a name='#d' id='d'>D</a>
                                        </th>
                                    </tr>
        <tr>
                                        <td>
                                            <asp:DataList ID="DataListD" runat="server" Font-Size="9pt"
                                                RepeatColumns="1" BorderStyle="None" CellPadding="0" Font-Names="Arial" Width="100%">
                                                <ItemStyle VerticalAlign="Top" />
                                                <ItemTemplate>
                                                    <table >
                                                        <tr>
                                                            <td >
                                                                <table >
                                                                    <tr>
                                                                        <td valign="top" >
                                                                            <table >
                                                                                <tr>
                                                                                    <td style="padding-right: 2px" width="10">
                                                                                        <img alt="" src="images/vineta_princ.gif" width="8" />
                                                                                    </td>
                                                                                    <td>
                                                                                         <a href="#" onclick="Effect.toggle('d<%# Eval("RUB_CODIGO") %>','slide'); return false;"
                                                                                            class="Linkp">
                                                                                           <asp:Image id="myImage"  runat="server"  Height="23"   ImageUrl='<%# DataBinder.Eval(Container, "DataItem.RUB_IMAGEN", "~/IMG/rubros/{0}")%>'>    
                                                                                                  </asp:Image > 

                                                                                           <%--<%#Eval("RUB_NOMBRE")%>--%>
                                                                                        </a>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td >
                                                                            <div id='d<%# Eval("RUB_CODIGO") %>' style="display: none;" class="tdsec">
                                                                                <table >
                                                                                    <tr>
                                                                                        <td style="padding: 5px;">
                                                                                            <asp:DataList ID="DataList2" runat="server" DataSourceID="ObjectDataSource3">
                                                                                                <ItemTemplate>
                                                                                                    <table >
                                                                                                        <tr>
                                                                                                            <td class="td3">
                                                                                                                <img alt="" src="images/vineta_sec.gif" width="8" />
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                <a href="rubro.aspx?Rub=<%# Eval("RUB_CODIGO") %>&amp;Sub=<%# Eval("SRB_CODIGO") %>"
                                                                                                                    class="text-dark" >
                                                                                                                    <%# Eval("SRB_NOMBRE") %></a>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </ItemTemplate>
                                                                                            </asp:DataList>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetSubRubrosxD"
                                                                                    TypeName="ClassLibrary1.Rubros">
                                                                                    <SelectParameters>
                                                                                        <asp:ControlParameter ControlID="HiddenField1" Name="RUB_CODIGO" PropertyName="Value"
                                                                                            Type="Int32" />
                                                                                    </SelectParameters>
                                                                                </asp:ObjectDataSource>
                                                                                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("RUB_CODIGO") %>' />
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:DataList>
                                        </td>
                                    </tr>
        <tr>
                                         <th class="Letra" style="width: 268px">
                                            <a name='#l' id='l'>L</a>
                                        </th>
                                    </tr>
        <tr>
                                        <td style="width: 268px">
                                            <asp:DataList ID="DataListL" runat="server" Font-Size="9pt"
                                                RepeatColumns="1" BorderStyle="None" CellPadding="0" Font-Names="Arial" Width="100%">
                                                <ItemStyle VerticalAlign="Top" />
                                                <ItemTemplate>
                                                    <table >
                                                        <tr>
                                                            <td >
                                                                <table >
                                                                    <tr>
                                                                        <td valign="top" >
                                                                            <table >
                                                                                <tr>
                                                                                    <td style="padding-right: 2px" width="10">
                                                                                        <img alt="" src="images/vineta_princ.gif" width="8" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <a href="#" onclick="Effect.toggle('d<%# Eval("RUB_CODIGO") %>','slide'); return false;"
                                                                                            class="Linkp">
                                                                                           <asp:Image id="myImage"  runat="server"  Height="23"   ImageUrl='<%# DataBinder.Eval(Container, "DataItem.RUB_IMAGEN", "~/IMG/rubros/{0}")%>'>    
                                                                                                  </asp:Image > 
                                                                                        
                                                                                             <%--<%#Eval("RUB_NOMBRE")%>--%>
                                                                                        </a>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top">
                                                                            <div id="d<%# Eval("RUB_CODIGO") %>" style="display: none;" class="tdsec">
                                                                                <table >
                                                                                    <tr>
                                                                                        <td style="padding: 5px;">
                                                                                            <asp:DataList ID="DataList2" runat="server" DataSourceID="ObjectDataSource3">
                                                                                                <ItemTemplate>
                                                                                                    <table >
                                                                                                        <tr>
                                                                                                            <td class="td3">
                                                                                                                <img alt="" src="images/vineta_sec.gif" width="8" />
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                <a href="rubro.aspx?Rub=<%# Eval("RUB_CODIGO") %>&amp;Sub=<%# Eval("SRB_CODIGO") %>"
                                                                                                                    class="text-dark" >
                                                                                                                    <%# Eval("SRB_NOMBRE") %></a>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </ItemTemplate>
                                                                                            </asp:DataList>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetSubRubrosxL"
                                                                                    TypeName="ClassLibrary1.Rubros">
                                                                                    <SelectParameters>
                                                                                        <asp:ControlParameter ControlID="HiddenField1" Name="RUB_CODIGO" PropertyName="Value"
                                                                                            Type="Int32" />
                                                                                    </SelectParameters>
                                                                                </asp:ObjectDataSource>
                                                                                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("RUB_CODIGO") %>' />
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:DataList>
                                        </td>
                                    </tr>
        <tr>
                                        <th class="Letra" >
                                            <a name='#m' id='m'>M</a>
                                        </th>
                                    </tr>
        <tr>
                                        <td style="width: 268px">
                                            <asp:DataList ID="DataListM" runat="server"  Font-Size="9pt"
                                                RepeatColumns="1" BorderStyle="None" CellPadding="0" Font-Names="Arial" Width="100%">
                                                <ItemStyle VerticalAlign="Top" />
                                                <ItemTemplate>
                                                    <table >
                                                        <tr>
                                                            <td >
                                                                <table >
                                                                    <tr>
                                                                        <td valign="top" >
                                                                            <table >
                                                                                <tr>
                                                                                    <td style="padding-right: 2px" width="10">
                                                                                        <img alt="" src="images/vineta_princ.gif" width="8" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <a href="#" onclick="Effect.toggle('d<%# Eval("RUB_CODIGO") %>','slide'); return false;"
                                                                                            class="Linkp">
                                                                                           <asp:Image id="myImage"  runat="server"  Height="23"  ImageUrl='<%# DataBinder.Eval(Container, "DataItem.RUB_IMAGEN", "~/IMG/rubros/{0}")%>'>    
                                                                                                  </asp:Image > 
                                                                                        
                                                                                            <%--<%#Eval("RUB_NOMBRE")%>--%>
                                                                                        </a>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top">
                                                                            <div id="d<%# Eval("RUB_CODIGO") %>" style="display: none;" class="tdsec">
                                                                                <table ">
                                                                                    <tr>
                                                                                        <td style="padding: 5px;">
                                                                                            <asp:DataList ID="DataList2" runat="server" DataSourceID="ObjectDataSource3">
                                                                                                <ItemTemplate>
                                                                                                    <table >
                                                                                                        <tr>
                                                                                                            <td class="td3">
                                                                                                                <img alt="" src="images/vineta_sec.gif" width="8" />
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                <a href="rubro.aspx?Rub=<%# Eval("RUB_CODIGO") %>&amp;Sub=<%# Eval("SRB_CODIGO") %>"
                                                                                                                   class="text-dark" >
                                                                                                                    <%# Eval("SRB_NOMBRE") %></a>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </ItemTemplate>
                                                                                            </asp:DataList>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetSubRubrosxM"
                                                                                    TypeName="ClassLibrary1.Rubros">
                                                                                    <SelectParameters>
                                                                                        <asp:ControlParameter ControlID="HiddenField1" Name="RUB_CODIGO" PropertyName="Value"
                                                                                            Type="Int32" />
                                                                                    </SelectParameters>
                                                                                </asp:ObjectDataSource>
                                                                                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("RUB_CODIGO") %>' />
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:DataList>
                                        </td>
                                    </tr>
    
     </table>
    </div>
    <div class="col">
     <table   >
                                    <tr>
                                        <th class="Letra" style="text-align:left">
                                            <a name='#p' id='p'>P</a>
                                        </th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DataList ID="DataListP" runat="server"  Font-Size="9pt"
                                                RepeatColumns="1" BorderStyle="None" CellPadding="0" Font-Names="Arial" Width="100%">
                                                <ItemStyle VerticalAlign="Top" />
                                                <ItemTemplate>
                                                    <table >
                                                        <tr>
                                                            <td >
                                                                <table >
                                                                    <tr>
                                                                        <td >
                                                                            <table >
                                                                                <tr>
                                                                                    <td style="padding-right: 2px" width="10">
                                                                                        <img alt="" src="images/vineta_princ.gif" width="8" />
                                                                                    </td>
                                                                                    <td>
                                                                                         <a href="#" onclick="Effect.toggle('d<%# Eval("RUB_CODIGO") %>','slide'); return false;"
                                                                                            class="Linkp">
                                                                                           <asp:Image id="myImage"  runat="server"  Height="23"  ImageUrl='<%# DataBinder.Eval(Container, "DataItem.RUB_IMAGEN", "~/IMG/rubros/{0}")%>'>    
                                                                                                  </asp:Image > 
                                                                                       
                                                                                            <%--<%#Eval("RUB_NOMBRE")%>--%>
                                                                                        </a>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td >
                                                                            <div id="d<%# Eval("RUB_CODIGO") %>" style="display: none;" class="tdsec">
                                                                                <table >
                                                                                    <tr>
                                                                                        <td style="padding: 5px;">
                                                                                            <asp:DataList ID="DataList2" runat="server" DataSourceID="ObjectDataSource3">
                                                                                                <ItemTemplate>
                                                                                                    <table >
                                                                                                        <tr>
                                                                                                            <td class="td3">
                                                                                                                <img alt="" src="images/vineta_sec.gif" width="8" />
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                <a href="rubro.aspx?Rub=<%# Eval("RUB_CODIGO") %>&amp;Sub=<%# Eval("SRB_CODIGO") %>"
                                                                                                                    class="text-dark" >
                                                                                                                    <%# Eval("SRB_NOMBRE") %></a>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </ItemTemplate>
                                                                                            </asp:DataList>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetSubRubrosxP"
                                                                                    TypeName="ClassLibrary1.Rubros">
                                                                                    <SelectParameters>
                                                                                        <asp:ControlParameter ControlID="HiddenField1" Name="RUB_CODIGO" PropertyName="Value"
                                                                                            Type="Int32" />
                                                                                    </SelectParameters>
                                                                                </asp:ObjectDataSource>
                                                                                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("RUB_CODIGO") %>' />
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:DataList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="Letra">
                                            <a name='#s' id='s'>S</a>
                                        </th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DataList ID="DataListS" runat="server"  Font-Size="9pt"
                                                RepeatColumns="1" BorderStyle="None" CellPadding="0" Font-Names="Arial" Width="100%">
                                                <ItemStyle VerticalAlign="Top" />
                                                <ItemTemplate>
                                                    <table >
                                                        <tr>
                                                            <td >
                                                                <table >
                                                                    <tr>
                                                                        <td >
                                                                            <table >
                                                                                <tr>
                                                                                    <td style="padding-right: 2px" width="10">
                                                                                        <img alt="" src="images/vineta_princ.gif" width="8" />
                                                                                    </td>
                                                                                    <td>
                                                                                         <a href="#" onclick="Effect.toggle('d<%# Eval("RUB_CODIGO") %>','slide'); return false;"
                                                                                            class="Linkp">
                                                                                           <asp:Image id="myImage"  runat="server"  Height="23"  ImageUrl='<%# DataBinder.Eval(Container, "DataItem.RUB_IMAGEN", "~/IMG/rubros/{0}")%>'>    
                                                                                                  </asp:Image > 
                                                                                       
                                                                                           <%--<%#Eval("RUB_NOMBRE")%>--%>
                                                                                        </a>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td >
                                                                            <div id="d<%# Eval("RUB_CODIGO") %>" style="display: none;" class="tdsec">
                                                                                <table >
                                                                                    <tr>
                                                                                        <td style="padding: 5px;">
                                                                                            <asp:DataList ID="DataList2" runat="server" DataSourceID="ObjectDataSource3">
                                                                                                <ItemTemplate>
                                                                                                    <table >
                                                                                                        <tr>
                                                                                                            <td class="td3">
                                                                                                                <img alt="" src="images/vineta_sec.gif" width="8" />
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                <a href="rubro.aspx?Rub=<%# Eval("RUB_CODIGO") %>&amp;Sub=<%# Eval("SRB_CODIGO") %>"
                                                                                                                    class="text-dark" >
                                                                                                                    <%# Eval("SRB_NOMBRE") %></a>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </ItemTemplate>
                                                                                            </asp:DataList>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetSubRubrosxS"
                                                                                    TypeName="ClassLibrary1.Rubros">
                                                                                    <SelectParameters>
                                                                                        <asp:ControlParameter ControlID="HiddenField1" Name="RUB_CODIGO" PropertyName="Value"
                                                                                            Type="Int32" />
                                                                                    </SelectParameters>
                                                                                </asp:ObjectDataSource>
                                                                                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("RUB_CODIGO") %>' />
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:DataList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="Letra">
                                            <a name='#t' id='t'>T</a>
                                        </th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DataList ID="DataListT" runat="server"  Font-Size="9pt"
                                                RepeatColumns="1" BorderStyle="None" CellPadding="0" Font-Names="Arial" Width="100%">
                                                <ItemStyle VerticalAlign="Top" />
                                                <ItemTemplate>
                                                    <table >
                                                        <tr>
                                                            <td class="td1">
                                                                <table >
                                                                    <tr>
                                                                        <td >
                                                                            <table >
                                                                                <tr>
                                                                                    <td style="padding-right: 2px" width="10">
                                                                                        <img alt="" src="images/vineta_princ.gif" width="8" />
                                                                                    </td>
                                                                                    <td>
                                                                                         <a href="#" onclick="Effect.toggle('d<%# Eval("RUB_CODIGO") %>','slide'); return false;"
                                                                                            class="Linkp">
                                                                                           <asp:Image id="myImage"  runat="server"  Height="23"  ImageUrl='<%# DataBinder.Eval(Container, "DataItem.RUB_IMAGEN", "~/IMG/rubros/{0}")%>'>    
                                                                                                  </asp:Image > 
                                                                                       
                                                                                            <%--<%#Eval("RUB_NOMBRE")%>--%>
                                                                                        </a>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td >
                                                                            <div id="d<%# Eval("RUB_CODIGO") %>" style="display: none;" class="tdsec">
                                                                                <table >
                                                                                    <tr>
                                                                                        <td style="padding: 5px;">
                                                                                            <asp:DataList ID="DataList2" runat="server" DataSourceID="ObjectDataSource3">
                                                                                                <ItemTemplate>
                                                                                                    <table>
                                                                                                        <tr>
                                                                                                            <td class="td3">
                                                                                                                <img alt="" src="images/vineta_sec.gif" width="8" />
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                <a href="rubro.aspx?Rub=<%# Eval("RUB_CODIGO") %>&amp;Sub=<%# Eval("SRB_CODIGO") %>"
                                                                                                                    class="text-dark" >
                                                                                                                    <%# Eval("SRB_NOMBRE") %></a>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </ItemTemplate>
                                                                                            </asp:DataList>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetSubRubrosxT"
                                                                                    TypeName="ClassLibrary1.Rubros">
                                                                                    <SelectParameters>
                                                                                        <asp:ControlParameter ControlID="HiddenField1" Name="RUB_CODIGO" PropertyName="Value"
                                                                                            Type="Int32" />
                                                                                    </SelectParameters>
                                                                                </asp:ObjectDataSource>
                                                                                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("RUB_CODIGO") %>' />
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:DataList>
                                        </td>
                                    </tr>
          
                                </table>
    </div>
            
       
       </div>
    </div>
 </div>
         
    </div>
    </div>
    </div>
</asp:Content>

