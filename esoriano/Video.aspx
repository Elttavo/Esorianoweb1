<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Video.aspx.vb" Inherits="Esoriano.video" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>


<body style:" height="450" width="500">
    <form id="form1" runat="server"  height="450" width="500">
        <div>
            
                <asp:ListView ID="ListViewVideo" runat="server" >
                     <LayoutTemplate>  
                    <table class="table table-bordered table-striped">  
                        <tr class="bg-danger text-white">  
                            <th>Nombre del video </th>  
                             
                        </tr>  
                        <tbody>  
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />  
                        </tbody>  
                    </table>  
                </LayoutTemplate>  
                <ItemTemplate>  
                    <tr>  
                        <video  height="440" width= "490"  autoplay="autoplay" muted="muted" loop="loop"controls="controls"  id="myvideo"   >
                           <source src='<%# DataBinder.Eval(Container, "DataItem.NOV_DETALLE", "WebRepositorio/Esoriano/Promo/video/{0}")%>'> 
                              <a href="WEBRepositorio/Esoriano/PROMO/video/Video.mp4">download video</a> 
                                    Your browser does not support the video tag.
                         </video> 
                       <td><%# Eval("NOV_DETALLE")%></td>  
                     </tr>  
                </ItemTemplate>  
            </asp:ListView>  
        </div>
    </form>
</body>
</html>