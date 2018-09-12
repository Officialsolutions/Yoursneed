<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpbread" runat="Server">
    <h3 class="text-white">Login</h3>
    <ul class="breadcrumb mt-10">
        <li class="breadcrumb-item"><a href="#">Home</a></li>

        <li class="breadcrumb-item active">Login</li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpmain" runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-md-9">
                <h4>Login To Your Account</h4>
                <form class="gray-form mt-20 clearfix">
                    <div class="form-group">
                        <label for="name">User name* </label>
                        <asp:TextBox ID="txtuser" class="form-control" placeholder="User name" runat="server" required></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                            ControlToValidate="txtuser" ErrorMessage="enter numeric value only"
                            ValidationExpression="\d+" ValidationGroup="g"></asp:RegularExpressionValidator>
                    </div>
                    <div class="form-group">
                        <label for="Password">Password* </label>
                        <asp:TextBox ID="txtpass" TextMode="Password" class="form-control" placeholder="Password" runat="server"></asp:TextBox>
                    </div>

                    <asp:Button ID="btnlogin" OnClick="btnlogin_Click" class="button" runat="server" Text="Log in" ValidationGroup="g" />
                    <asp:ValidationSummary
                        HeaderText="You must enter a value in the following fields:"
                        DisplayMode="BulletList"
                        EnableClientScript="true" ValidationGroup="g"
                        runat="server" />
                </form>
            </div>
            <div class="col-md-3">
                <div class="login-social">
                    <h4>Social media</h4>
                    <ul>
                        <li><a class="fb" href="https://www.facebook.com/groups/2083184438421516/"><i class="fa fa-facebook"></i>Facebook</a></li>
                        <li><a class="fb" href="https://www.youtube.com/channel/UCxXtvOY--DGS5miNaSqeAzA/"><i class="fa fa-youtube"></i>Youtube</a></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpfooter" runat="Server">
</asp:Content>

