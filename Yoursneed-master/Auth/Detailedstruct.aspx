<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="Detailedstruct.aspx.cs" Inherits="Auth_Detailedstruct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" runat="Server">
    <div class="col-md-12">
        <h3>Structure of
            <asp:Label ID="lblreg" runat="server" Text=""></asp:Label></h3>

        <table id="table1" class="table table-striped table-hover table-fw-widget">
            <thead>
                <tr>
                    <th>Sr.No</th>
                    <th>Regno</th>
                    <th>Name</th>
                    <th>Mobile</th>
                    <th>Joining Date</th>
                </tr>
            </thead>
            <asp:ListView ID="gvpins" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Container.DataItemIndex+1 %></td>
                        <td><%#Eval("Cregno") %></td>
                        <td><%#Eval("fname") %></td>
                        <td><%#Eval("mobile") %></td>
                        <td>
                            <asp:Label ID="lbldate" runat="server" Text='<%# Convert.ToDateTime(Eval("joined")).ToString("dd/MM/yyyy") %>'></asp:Label></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" runat="Server">
</asp:Content>

