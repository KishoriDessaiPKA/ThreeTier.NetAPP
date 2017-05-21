<%@ Page Title="" Language="C#" MasterPageFile="~/Movie.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MovieTicketBooking.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:ScriptManager ID="ScriptManager1" runat="server"> </asp:ScriptManager>
            <asp:UpdatePanel id="updaPanel" runat="server">
                 <ContentTemplate>
                      <div id="formHolder">
            <table>
            <tr> 
                <td> City : 
                    <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="True" OnDataBound="ddlCity_SelectedIndexChanged" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged"></asp:DropDownList>
                </td>
            
                <td> Theatre : 
                    <asp:DropDownList ID="ddlTheatre" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTheatre_SelectedIndexChanged" OnDataBound="ddlTheatre_SelectedIndexChanged"></asp:DropDownList>
                </td>
            
                <td> Movie : 
                    <asp:DropDownList ID="ddlMovie" runat="server"></asp:DropDownList>
                </td>
            
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="Search" OnClick="Button1_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                </td>
            </tr>
            </table> 
             

    </div>
    <div id="dataHolder">
        <asp:GridView ID="gvwMovieList" runat="server" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="2" OnRowEditing="gvwMovieList_RowEditing">
            <Columns>
                <asp:CommandField ButtonType="Button" EditText="Book Ticket" ShowCancelButton="False" ShowEditButton="True" ShowHeader="True" />
            </Columns>
            <FooterStyle HorizontalAlign="Center" ForeColor="White" />
            <PagerStyle ForeColor="White" />
        </asp:GridView>        
    </div>
                      </ContentTemplate>
             <Triggers>

<asp:PostBackTrigger ControlID = "gvwMovieList"/>
</Triggers>
      </asp:UpdatePanel> 
</asp:Content>
