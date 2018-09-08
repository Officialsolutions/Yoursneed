<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="Unblock.aspx.cs" Inherits="Auth_Unblock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
   UnBlock Id
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
   <div class="col-md-12">
      <h4 style="margin-bottom: 20px;">Pins Received</h4>
  
         <table id="table1" class="table table-striped table-hover table-fw-widget">
                    <thead>
            <tr>
                <th>Sr.No</th>
                <th>Regno</th>
                <th>Lname</th>
                <th>Sponser</th>
                <th>Address</th>
                <th></th>
              
            </tr>
        </thead>
            <asp:ListView ID="gvpins" runat="server">
            <ItemTemplate>
                <tr>
                   <td><%# Container.DataItemIndex+1 %></td>
                    <td><%#Eval("regno") %></td>
                    <td> <%#Eval("lname") %></td>
                    <td><%#Eval("sregno") %></td>
                    <td><%#Eval("add1") %></td>
                     <td>
                         <asp:LinkButton ID="lnkstatus" CssClass="label label-danger" OnClick="lnkstatus_Click" CommandArgument='<%#Eval("regno") %>' runat="server">UnBlock</asp:LinkButton></td>

                </tr>
              
            </ItemTemplate>
        </asp:ListView>
        </table>
        
   </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>



