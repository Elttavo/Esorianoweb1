<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MasterEsoriano.Master" CodeBehind="Descarga.aspx.vb" Inherits="Esoriano.Descarga" %>
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
            <div class="col-md-12">
                <div  class="table">  
             <h4>Selecione</h4> 
               <span id="descarga" 
                            style="font-family: font-size: 25x;
                            font-weight: lighter; font-family: 'Times New Roman', Times, serif;"> Descarga
                        </span>
              <asp:Label ID="Label2" runat="server" Text="Numero de pedido" 
               Visible="false"></asp:Label>
              <hr />
              <table style="margin-top: 0px; margin-bottom: 100px;">
            <asp:LinkButton ID="LinkButton2" runat="server">fecha Desde</asp:LinkButton>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <div  >
                <asp:Calendar ID="Calendar1" runat="server" BackColor="White" 
                    BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" 
                    Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" 
                    Width="254px" Visible="False">
                 <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                 <NextPrevStyle VerticalAlign="Bottom" />
                 <OtherMonthDayStyle ForeColor="#808080" />
                 <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                 <SelectorStyle BackColor="#CCCCCC" />
                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <WeekendDayStyle BackColor="#FFFFCC" />
                    </asp:Calendar>
               </div>
                <div >

                <asp:LinkButton ID="LinkButton1" runat="server">Fecha Hasta</asp:LinkButton>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <asp:Calendar ID="Calendar2" runat="server" BackColor="White" 
                BorderColor="#999999" CellPadding="4" DayNameFormat="FirstLetter" 
                Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="72px" 
                Width="120px" Visible="False">
                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="False" Font-Size="7pt" 
                        Font-Italic="True" />
                <NextPrevStyle VerticalAlign="Bottom" />
                <OtherMonthDayStyle ForeColor="#808080" />
                <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                <SelectorStyle BackColor="#CCCCCC" />
                <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Center" />
                <WeekendDayStyle BackColor="#FFFFCC" />
                </asp:Calendar>
                     
                <asp:Button ID="Button1" runat="server" Text="Aceptar" onclick="Button1_Click" />
  </div>
        <p>
        
            <asp:Label ID="Label1" runat="server" Font-Bold="True"></asp:Label>
            <asp:Label ID="lblError" runat="server" Visible="False"></asp:Label>
       </p>
                    </table>
      </div>

    </div>

  </div>
</asp:Content>
