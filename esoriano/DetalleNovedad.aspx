<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="DetalleNovedad.aspx.vb" Inherits="Esoriano.DetalleNovedad" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
      <div align="center" > <asp:Button ID="Button1" runat="server" Text="Presione aqui pera  detalles  de la  Novedad" Width="505px" Font-Bold="True" Font-Size="Medium" Height="28px"  align="CENTER" ForeColor="#990000"  Visible="False" /></div>
         <asp:FormView ID="FormView1" runat="server" DataKeyNames="NOV_ID"  OnDataBound = "FormView1_DataBound"
                 Width="43%" Height="435px">
             <ItemTemplate >                                                                                                  
                <asp:ImageMap ID="ImageMap1"  runat="server" Width="520px" height="470"  imageurl='<%#String.Format("~/WebRepositorio/Esoriano/IMAGENES/{0}", Eval("NOV_IMAGEN"))%>' TabIndex='<%# ProcessMyDataItem(Eval("NOV_VIDEO")) %> '  hotspotmode="PostBack"
                     onclick="Button1_Click"   >
                    <asp:RectangleHotSpot          
                    top="0"
                    left="0"
                    bottom="530"
                    right="480"
                    postbackvalue="Yes"
                    alternatetext="Ver Mas">
                    </asp:RectangleHotSpot>
                </asp:ImageMap>
                 <asp:Label ID="lblCode" Text='<%#Eval("NOV_ID")%>' runat="server" />
                 
                    <%--     <img  src="WEB_Repositorio/Esoriano/IMAGENES/<%# Eval("NOV_IMAGEN")%>" hspace="10" vspace="0" border="1" align="CENTER" alt="" height="450" width="500"   />
                   --%>                 
              </ItemTemplate>
           </asp:FormView>

    </form>
</body>
</html>

