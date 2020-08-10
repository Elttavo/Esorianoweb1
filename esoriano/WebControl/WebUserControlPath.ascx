<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="~/WebControl/WebUserControlPath.ascx.vb" Inherits="Esoriano.WebUserControlPath" %>
<div id="magenpath">
    <asp:SiteMapPath ID="SiteMapPath1" runat="server" SiteMapProvider="smProvider1" ParentLevelsDisplayed="1"
        Font-Names="Arial" Font-Size="8pt" Height="30px" PathSeparator=" ">
        <PathSeparatorStyle Height="34px" />
        <CurrentNodeStyle ForeColor="Black" Height="30" CssClass="Path" />
        <NodeStyle Font-Bold="True" ForeColor="Black" Height="30" CssClass="Path" />
        <RootNodeStyle Font-Bold="True" ForeColor="Black" Height="30" />
        <PathSeparatorTemplate>
            <asp:Image ID="Image1" runat="Server" Width="8" Height="34" ImageUrl="~/images/separador.gif" />
        </PathSeparatorTemplate>
    </asp:SiteMapPath>
</div>