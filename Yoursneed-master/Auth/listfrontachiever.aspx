<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/Main.master" AutoEventWireup="true" CodeFile="listfrontachiever.aspx.cs" Inherits="Auth_listfrontachiever" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
    <div class="col-md-12">
      <h4 style="margin-bottom: 20px;">Pins Received</h4>
  
        <table id="example" class="table table-striped table-bordered" cellspacing="0" width="100%">
        <thead>
            <tr>
                <th>Sr.No</th>
                <th>Image</th>
             
                <th></th>
              
            </tr>
        </thead>
            <asp:ListView ID="gvpins" runat="server">
            <ItemTemplate>
                <tr>
                   <td><%# Container.DataItemIndex+1 %></td>
                    <td><img src='../uploadimage/<%#Eval("image") %>' width="100" /></td>
                    
                     <td>
                         <asp:LinkButton ID="edit" CommandArgument='<%#Eval("id") %>' runat="server" OnClick="edit_Click">Edit</asp:LinkButton> |
                          <asp:LinkButton ID="delete" CommandArgument='<%#Eval("id") %>' runat="server" OnClick="delete_Click">Delete</asp:LinkButton>
                     </td>

                </tr>
              
            </ItemTemplate>
        </asp:ListView>
        </table>
        
   </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

