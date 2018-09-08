<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.master" AutoEventWireup="true" CodeFile="OldWalletReq.aspx.cs" Inherits="User_OldWalletReq" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cptitle" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpmain" runat="Server">

    <div class="col-md-12">
        <h4 style="margin-bottom: 20px;">Old Requests</h4>

        <table id="example" class="table table-striped table-bordered" cellspacing="0" width="100%">
            <thead>
                <tr>
                    <th>Sr.No</th>
                    <th>Amount</th>
                    <th>Transfer To</th>
                    <th>Reason</th>
                    <th>Date</th>
                    <th>Approval Status</th>
                    <th>Action Date</th>
                </tr>
            </thead>
            <asp:ListView ID="gvpins" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Container.DataItemIndex+1 %></td>

                        <%--<td><%#Eval("regno") %></td>--%>
                        <td><%#Eval("reqamount") %></td>
                        <td><%#Eval("transfertype") %></td>
                        <td><%#Eval("reason") %></td>
                        <td>
                            <asp:Label ID="lbldate" runat="server" Text='<%# Convert.ToDateTime(Eval("date")).ToString("dd/MM/yyyy") %>'></asp:Label></td>
                        <td><%#Eval("approvalstatus") %></td>
                        <%--<td><asp:Label ID="lblapp" runat="server" Text='<%# Convert.ToDateTime(Eval("approvaldate")).ToString("dd/MM/yyyy") %>'></asp:Label></td>--%>
                        <td><%#Eval("approvaldate") %></td>
                    </tr>

                </ItemTemplate>
            </asp:ListView>
        </table>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpfotter" runat="Server">
</asp:Content>

