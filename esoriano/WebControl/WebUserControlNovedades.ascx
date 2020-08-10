<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="~/WebControl/WebUserControlNovedades.ascx.vb" Inherits="Esoriano.WebUserControlNovedades" %>
<div class="table">
<table class="table   ">
    <thead class="thead-dark">
        <tr>
            <th>
                <img src="../img/novedades/vineta2.gif" />
                NOVEDADES
            </th>
        </tr>
    </thead>
    <tr>
        <td >
            <asp:DataList runat="server" ID="DataListNov">
                <ItemTemplate>
                    <table class="table table-borderless" >
                        <thead class="thead-light">
                            <th>
                                 <img src="../img/novedades/vineta_sec.gif" />
                                Detalles
                            </th>
                        </thead>
                           <tr>
                            <td >
                               <asp:Image ID="ImageMap1" width="150px" height="100px" runat="server" class="img-responsive" imageurl='<%#String.Format("~/WebRepositorio/Esoriano/IMAGENES/{0}", Eval("NOV_IMAGEN"))%>'  hotspotmode="PostBack" >
                             </asp:Image >
                         <td/>
                        <tr/>

                        <tr>
                            <td class="Novfecha">
                                <%#Eval("NOV_FECHA", "{0:dd.MM.yyyy}")%>
                            </td>
                        </tr>
                        <tr>
                            <td class="Novtitulo">
                                <%#Eval("NOV_TITULO")%>
                            </td>
                        </tr>
                        <tr>
                            <td class="Novcopete" style="height: 19px">
                                <%#Eval("NOV_COPETE")%>
                            </td>
                        </tr>
                        <tr>
                            <td >
                                <a Class="btn btn-outline-danger"  href="Novedades.aspx?NOV_ID=<%# Eval("NOV_ID")%>">Ampliar Información</a>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </td>
    </tr>
   </table>
 </div>
