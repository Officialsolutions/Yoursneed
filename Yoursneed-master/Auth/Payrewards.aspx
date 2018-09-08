<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/Main.master" AutoEventWireup="true" CodeFile="Payrewards.aspx.cs" Inherits="Auth_Payrewards" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
    Name: <asp:Label ID="lblname" runat="server" Text=""></asp:Label>
    ID: <asp:Label ID="lblid" runat="server" Text=""></asp:Label>
     <div class="col-md-12">
        <div class="col-md-3">
            Current Left Joinings : <asp:Label ID="lblleft" runat="server" Text=""></asp:Label>
        </div>
        <div class="col-md-3">
            Current Right Joinings : <asp:Label ID="lblright" runat="server" Text=""></asp:Label>
        </div>
    </div>
     <div class="col-md-12">


        <table id="table1" class="table table-striped table-hover table-fw-widget">
                    <thead>
                <tr>
                    <th>Sr.No</th>
                    <th>Pins</th>
                    <th>Rewards</th>  
                     <th>Level</th>
                    <th>Payout</th>
                    
                </tr>
            </thead>
            <asp:ListView ID="gvpins" runat="server" OnItemDataBound="gvpins_ItemDataBound">
                <ItemTemplate>
                    <tr>
                        <td><%# Container.DataItemIndex+1 %></td>

                        <td>
                            <asp:HiddenField ID="hfid" Value='<%#Eval("id") %>' runat="server" />
                            <asp:Label ID="lblpins" runat="server" Text='<%#Eval("pins") %>'><%#Eval("pins") %></asp:Label></td>
                        
                        <td>
                            <%#Eval("rewards") %></td>
                     
                       <td>
                           <asp:LinkButton ID="lnklevel" runat="server">Pending</asp:LinkButton>
                       </td>
                       <td>
                           <asp:LinkButton ID="lnkpay" CommandArgument='<%#Eval("id") %>' runat="server" OnClick="lnkpay_Click">Pay</asp:LinkButton>
                       </td>
                          <td>
                           <asp:LinkButton ID="lnkSalary" CommandArgument='<%#Eval("id") %>' runat="server" OnClick="lnkSalary_Click" Visible="false">Salary</asp:LinkButton>
                       </td>

                </ItemTemplate>
            </asp:ListView>
        </table>


    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

