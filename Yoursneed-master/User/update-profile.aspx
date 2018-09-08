<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.master" AutoEventWireup="true" CodeFile="update-profile.aspx.cs" Inherits="User_update_profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cptitle" runat="Server">
    <h3 class="text-white">Profile</h3>
    <ul class="breadcrumb mt-10">
        <li class="breadcrumb-item"><a href="#">Home</a></li>

        <li class="breadcrumb-item active">Profile</li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpmain" runat="Server">
    <div class="col-md-8 col-md-offset-2">
        <table style="width: 100%;" class="table table-bordered">
            <tr>
                <td>Sponser Id:</td>
                <td>
                    <asp:Label ID="lblspon" runat="server" Text=""></asp:Label></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>RegId</td>
                <td>
                    <asp:Label ID="lblreg" runat="server" Text="Label"></asp:Label></td>
                <td>Pan</td>
                <td>
                    <asp:TextBox ID="lblpan" runat="server"></asp:TextBox>
                 <%--   <asp:Label ID="lblpan" runat="server" Text="Label"></asp:Label>--%></td>
            </tr>
            <tr>
                <td>First Name</td>
                <td>
                    <asp:Label ID="lblname" runat="server" Text=""></asp:Label></td>
                <td>Of</td>
                <td>
                    <asp:TextBox ID="lblfather" runat="server"></asp:TextBox>
                   <%-- <asp:Label ID="lblfather" runat="server" Text=""></asp:Label>--%></td>
            </tr>
            <tr>
                <td>Address</td>
                <td>
                    <asp:TextBox ID="lblads" runat="server"></asp:TextBox>
                    <%--<asp:Label ID="lblads" runat="server" Text=""></asp:Label>--%></td>
                <td></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>City</td>
                <td>
                    <asp:TextBox ID="lblcity" runat="server"></asp:TextBox>
                   <%-- <asp:Label ID="lblcity" runat="server" Text=""></asp:Label>--%></td>
                <td>PIN</td>
                <td>
                    <asp:TextBox ID="lblpin" runat="server"></asp:TextBox>
                    <%--<asp:Label ID="lblpin" runat="server" Text=""></asp:Label>--%></td>
            </tr>
            <tr>
                <td>State</td>
                <td>
                    <asp:TextBox ID="lblstate" runat="server"></asp:TextBox>
                   <%-- <asp:Label ID="lblstate" runat="server" Text=""></asp:Label>--%></td>
                <td>Country</td>
                <td>
                    <asp:TextBox ID="lblcountry" runat="server"></asp:TextBox>
                    <%--<asp:Label ID="lblcountry" runat="server" Text=""></asp:Label>--%></td>
            </tr>
            <tr>
                <td>Phone(Office)</td>
                <td>
                    <asp:Label ID="lblphone" runat="server" Text=""></asp:Label></td>
                <td>Phone(Resi)</td>
                <td>
                    <asp:Label ID="lblphpone2" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Mobile</td>
                <td>
                     <asp:TextBox ID="lblmon" runat="server"></asp:TextBox>
                    <%--<asp:Label ID="lblmon" runat="server" Text=""></asp:Label>--%></td>
               
                <td>Email</td>
                <td>
                    <asp:TextBox ID="lblemail" runat="server"></asp:TextBox>
                    <%--<asp:Label ID="lblemail" runat="server" Text=""></asp:Label>--%></td>
            </tr>
            <tr>
                <td>Bank Account</td>
                <td>
                    <asp:Label ID="lblbankac" runat="server" Text=""></asp:Label></td>
                <td>Bank Name</td>
                <td>
                    <asp:Label ID="lblbank" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Nominee</td>
                <td>
                    <asp:TextBox ID="lblnomiee" runat="server"></asp:TextBox>
                    <%--<asp:Label ID="lblnomiee" runat="server" Text=""></asp:Label>--%></td>
                <td>Relation</td>
                <td>
                    <asp:TextBox ID="lblrelation" runat="server"></asp:TextBox>
                    <%--<asp:Label ID="lblrelation" runat="server" Text=""></asp:Label>--%></td>
            </tr>
            <tr>
                <td>Nomiee Address</td>
                <td>
                  
                    <asp:Label ID="lblnomads" runat="server" Text=""></asp:Label></td>
                <td>Nominee Phone</td>
                <td>
                    <asp:Label ID="lblnomieephone" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnsubmit" runat="server" Text="Submit" css="btn" OnClick="btnsubmit_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpfotter" runat="Server">
</asp:Content>

