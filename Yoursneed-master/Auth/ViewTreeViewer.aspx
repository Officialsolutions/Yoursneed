<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/Main.master" AutoEventWireup="true" CodeFile="ViewTreeViewer.aspx.cs" Inherits="Auth_ViewTreeViewer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
    <div class="col-md-12">
      <h4 style="margin-bottom: 20px;">Pins Received</h4>
  
        <table id="table1" class="table table-striped table-hover table-fw-widget">
                    <thead>
            <tr>
                <th>Sr.No</th>
                <th>Regno</th>
                <th></th>
              
            </tr>
        </thead>
            <asp:ListView ID="gvpins" runat="server">
            <ItemTemplate>
                <tr>
                   <td><%# Container.DataItemIndex+1 %></td>
                    <td><%#Eval("regno") %></td>
                   <td>
                       <asp:LinkButton ID="edit" OnClick="edit_Click" CommandArgument='<%#Eval("id") %>' runat="server">Edit</asp:LinkButton> |
                       <asp:LinkButton ID="delete" OnClick="delete_Click" CommandArgument='<%#Eval("id") %>' runat="server">Delete</asp:LinkButton>
                   </td>

                </tr>
              
            </ItemTemplate>
        </asp:ListView>
        </table>
        
   </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

