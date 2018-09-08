<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.master" AutoEventWireup="true" CodeFile="Life-Time-Rewards.aspx.cs" Inherits="User_Life_Time_Rewards" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cptitle" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpmain" runat="Server">
    <div class="col-md-12" style="margin-bottom:20px;">
         <div class="col-md-3">
          
            <asp:Label ID="lblname" runat="server" Text=""></asp:Label>
        </div>
        <div class="col-md-3">
            Current Left Joinings :
            <asp:Label ID="lblleft" runat="server" Text=""></asp:Label>
        </div>
        <div class="col-md-3">
            Current Right Joinings :
            <asp:Label ID="lblright" runat="server" Text=""></asp:Label>
        </div>
         
    </div>
    <div class="col-md-12">


        <table id="example" class="table table-striped table-bordered " cellspacing="0" width="100%">
            <thead>
                <tr>
                    <th>Sr.No</th>
                    <th>Pins</th>
                    <th>Rewards</th>
                    <th>Date</th>
                    <th>Level</th>

                </tr>
            </thead>
            <asp:ListView ID="gvpins" runat="server" OnItemDataBound="gvpins_ItemDataBound">
                <ItemTemplate>
                    <tr>
                        <td><%# Container.DataItemIndex+1 %></td>

                        <td>
                            <asp:Label ID="lblpins" runat="server" Text='<%#Eval("pins") %>' Enabled="false"><%#Eval("pins") %></asp:Label></td>

                        <td>
                            <asp:Label ID="lblrew" runat="server" Text='<%#Eval("rewards") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lbldate" runat="server" Text=""></asp:Label></td>
                        <td>
                            <asp:LinkButton ID="lnklevel" runat="server" Enabled="false">Pending</asp:LinkButton>
                        </td>
                </ItemTemplate>
            </asp:ListView>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpfotter" runat="Server">
</asp:Content>

