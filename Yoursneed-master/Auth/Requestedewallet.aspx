<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="Requestedewallet.aspx.cs" Inherits="Auth_Requestedewallet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 44px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
        <div class="col-md-12 text-center">
       
   <h2> E-Wallet Requests</h2> 
    </div>
        <div class="col-md-12">

         <table id="table1" class="table table-striped table-hover table-fw-widget">
                    <thead>
                <tr>
                    <th class="auto-style1">Sr.No</th>
                    <th class="auto-style1">Reg No.</th>
                    <th class="auto-style1">Req. Amount</th>  
                    <th class="auto-style1">Transfer Type</th>
                    <th class="auto-style1">Reason</th> 
                    <th class="auto-style1">Req. Date</th> 
                    <th class="auto-style1">Status</th> 
                    <th class="auto-style1">Action Date</th> 
                    <th class="auto-style1">Action</th> 
                </tr>
            </thead>
            <asp:ListView ID="gvpins" runat="server" OnItemCommand="gvpins_ItemCommand">
                <ItemTemplate>
                    <tr>
                        <td><%# Container.DataItemIndex+1 %></td>

                        <td>
                           <%#Eval("regno") %></td>
  
                        <td>
                            <%#Eval("reqamount") %></td>
                       <td>
                            <%#Eval("transfertype") %></td>
                          <td>
                            <%#Eval("reason") %></td>
                        <td>
                      <asp:Label ID="lbldate" runat="server" Text='<%# Convert.ToDateTime(Eval("date")).ToString("dd/MM/yyyy") %>'></asp:Label></td>
                      
                
                          <td>
                           <%#Eval("approvalstatus") %></td>
                          <td>
                                <%#Eval("approvaldate") %>
                     <%-- <asp:Label ID="lblappdate" runat="server" Text='<%# Convert.ToDateTime(Eval("approvaldate")).ToString("dd/MM/yyyy") %>'></asp:Label></td>--%>
                          <td>
                         <asp:LinkButton ID="lnkapprove" CssClass="label label-primary" CommandName="approve" CommandArgument='<%#Eval("regno") %>' runat="server">Approve</asp:LinkButton>
                          &nbsp;  &nbsp;  &nbsp;  &nbsp;
                         <asp:LinkButton ID="lnkreject" CssClass="label label-danger" CommandName="reject" CommandArgument='<%#Eval("regno") %>' runat="server">Reject</asp:LinkButton>
                          </td>
                        </tr>
                </ItemTemplate>
            </asp:ListView>
        </table>

   
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

