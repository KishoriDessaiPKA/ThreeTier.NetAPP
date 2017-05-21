<%@ Page Title="" Language="C#" MasterPageFile="~/Movie.Master" AutoEventWireup="true" CodeBehind="BookPage.aspx.cs" Inherits="MovieTicketBooking.BookPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <table id="bookPage">
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Movie" ForeColor="#CCFFFF"></asp:Label> 
            </td>
            <td>
                <asp:Label ID="lblMovie" runat="server" Text="Label" ForeColor="#FFFFFF"></asp:Label> 
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Theatre" ForeColor="#CCFFFF"></asp:Label> 
            </td>
            <td>
                <asp:Label ID="lblTheatre" runat="server" Text="Label" ForeColor="#FFFFFF"></asp:Label> 
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="City" ForeColor="#CCFFFF"></asp:Label> 
            </td>
            <td>
                <asp:Label ID="lblCity" runat="server" Text="Label" ForeColor="#FFFFFF"></asp:Label> 
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="Label8" runat="server" Text="Show Date" ForeColor="#CCFFFF"></asp:Label> 
            </td>
            <td>
                <asp:Label ID="lblDate" runat="server" Text="Label" ForeColor="#FFFFFF"></asp:Label> 
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="Label10" runat="server" Text="Show Time" ForeColor="#CCFFFF"></asp:Label> 
            </td>
            <td>
                <asp:Label ID="lblTime" runat="server" Text="Label" ForeColor="#FFFFFF"></asp:Label> 
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="Label12" runat="server" Text="Tickets Available" ForeColor="#CCFFFF"></asp:Label> 
            </td>
            <td>
                <asp:Label ID="lblTickets" runat="server" Text="Label" ForeColor="#FFFFFF"></asp:Label> 
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="Label14" runat="server" Text="Customer Name" ForeColor="#CCFFFF"></asp:Label> 
            </td>
            <td>
                <asp:TextBox ID="txtCustomerName" runat="server" placeholder="--Enter name here--"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="Label16" runat="server" Text="No. Of Tickets" ForeColor="#CCFFFF"></asp:Label> 
            </td>
            <td>
                <asp:TextBox ID="txtTicketCount" runat="server" placeholder="--Enter count here--"></asp:TextBox>             
            </td>
        </tr>
          <tr><td rowspan="3"></td></tr>
          <tr style="padding:20px;">
              <td colspan="2" style="text-align:center">
                  <asp:Button ID="btnBook" runat="server" Text="Book" OnClick="btnBook_Click" />
                  <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
              </td>
          </tr>
    </table>
    <div id="btnHomeDiv">
        <asp:Button ID="btnHome" runat="server" Text="Go Back" OnClick="btnCancel_Click"/>
    </div>
</asp:Content>
