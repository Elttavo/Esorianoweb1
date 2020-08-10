<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="DetalleNovedadAgrandada.aspx.vb" Inherits="Esoriano.DetalleNovedadAgrandada" %>

<!DOCTYPE html>

<html lang="es">
  <head id="Head1" runat="server">
    <meta charset="UTF-8">
    <title>infosoriano</title>
    <meta name="generator" content="Serif WebPlus X7 (15,0,4,38)">
    <meta name="viewport" content="width=5200">
    <meta http-equiv="Refresh" content="300; url=http://www.esoriano.com.ar">
    <link rel="stylesheet" type="text/css" href="wpscripts/wpstyles.css">
    <style type="text/css">
      .OBJ-1,.OBJ-1:link,.OBJ-1:visited { background-image:url('wpimages/wp69945fff_06.png');background-repeat:no-repeat;background-position:0px 0px;text-decoration:none;display:block;position:absolute; }
      .OBJ-1:hover { background-position:0px -60px; }
      .OBJ-1:active,a:link.OBJ-1.Activated,a:link.OBJ-1.Down,a:visited.OBJ-1.Activated,a:visited.OBJ-1.Down,.OBJ-1.Activated,.OBJ-1.Down { background-position:0px -30px; }
      .OBJ-1:focus { outline-style:none; }
      button.OBJ-1 { background-color:transparent;border:none 0px;padding:0;display:inline-block;cursor:pointer; }
      button.OBJ-1:disabled { pointer-events:none; }
      .OBJ-1.Inline { display:inline-block;position:relative;line-height:normal; }
      .OBJ-1 span,.OBJ-1:link span,.OBJ-1:visited span { color:#666666;font-family:Tahoma,sans-serif;font-weight:normal;text-decoration:none;text-align:center;text-transform:none;font-style:normal;left:2px;top:9px;width:76px;height:13px;font-size:10px;display:block;position:absolute;cursor:pointer; }
      .OBJ-1.Disabled span,a:link.OBJ-1.Disabled span,a:visited.OBJ-1.Disabled span,a:hover.OBJ-1.Disabled span,a:active.OBJ-1.Disabled span { color:#cccccc; }
    </style>
    <script type="text/javascript" src="wpscripts/jquery.js"></script>
    <script type="text/javascript">
      $(document).ready(function() {
      $("a.ActiveButton").bind({ mousedown:function(){if ( $(this).attr('disabled') === undefined ) $(this).addClass('Activated');}, mouseleave:function(){ if ( $(this).attr('disabled') === undefined ) $(this).removeClass('Activated');}, mouseup:function(){ if ( $(this).attr('disabled') === undefined ) $(this).removeClass('Activated');}});
      });
    </script>
  </head>
  <body onLoad="window.moveTo(0,0);window.resizeTo(screen.availWidth, screen.availHeight);">
    <div id="divMain" style="background:transparent;margin-left:auto;margin-right:auto;position:relative;width:1200px;height:1000px;">
      <div style="position:absolute;left:0px;top:0px;width:960px;height:64px;">
        <a href="index.html" id="nav_34_B1" class="OBJ-1 ActiveButton Down" style="display:block;position:absolute;left:440px;top:0px;width:80px;height:30px;">
          <span>Home</span>
        </a>
      </div>
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
                         <asp:Image runat="server" alt="" style="position:absolute;left:2px;top:0px;width:1198px;height:996px;" ImageUrl='<%# DataBinder.Eval(Container, "DataItem.NOV_DETALLE", "~/WebRepositorio/Esoriano/Promo/{0}")%>'>    
                                                                                                  </asp:Image >
                                                
                       <td><%# Eval("NOV_DETALLE")%></td>  

                     </tr>  
                </ItemTemplate>  
            </asp:ListView>  

           
    </div>
  </body>
</html>

