<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="clientstructure.aspx.cs" Inherits="Auth_clientstructure" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
    <div class="col-md-12">


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
                        <td><%#Eval("cregno") %></td>
                        <td><%#Eval("fname") %></td>
                        <td><%#Eval("mobile") %></td>
                        <td><asp:Label ID="lbldate" runat="server" Text='<%# Convert.ToDateTime(Eval("joined")).ToString("dd/MM/yyyy") %>'></asp:Label></td>
                     </tr>
                </ItemTemplate>
            </asp:ListView>
        </table>


    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

