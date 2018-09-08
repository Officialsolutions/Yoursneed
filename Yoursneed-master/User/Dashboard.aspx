<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="User_Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cptitle" runat="Server">
    <style>
        .Dash {
            padding: 20px;
            background: menu;
            margin: 10px;
        }

        .blue {
            background: #3498db;
        }

        .yellow {
            background: #ffc61d;
        }

        .green {
            background: #27ae60;
        }

        .contact-info h5 {
            color: white;
            font-weight: bold;
        }

        .red {
            background-color: orchid;
        }

        .pink {
            background-color: #ff00009e;
        }

        .contact-info h6 {
            color: white;
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpmain" runat="Server">
    <div class="col-md-12" style="margin-bottom: 20px; align-items: center; color: black;">
        <div class="col-lg-3 col-sm-3 bottom-m3 Dash blue">
            <div class="contact-box">
                <div class="contact-icon">
                    <span class="fa fa-unlink"></span>
                </div>
                <div class="contact-info">
                    <h5>Unused Pins </h5>
                    <h6>
                        <asp:Label ID="lblnew" runat="server" Text=""></asp:Label></h6>
                </div>
            </div>
        </div>
        <div class="col-lg-3 col-sm-3 bottom-m3 Dash yellow">
            <div class="contact-box">
                <div class="contact-icon">
                    <span class="fa fa-link"></span>
                </div>
                <div class="contact-info">
                    <h5>Used Pins</h5>

                    <h6>
                        <asp:Label ID="lblused" runat="server" Text=""></asp:Label></h6>
                </div>
            </div>
        </div>
        <div class="col-lg-3 col-sm-3 bottom-m3 Dash red">
            <div class="contact-box">
                <div class="contact-icon">
                    <span class="fa fa-forward"></span>
                </div>
                <div class="contact-info">
                    <h5>Transfer Pins </h5>
                    <h6>
                        <asp:Label ID="lbltrans" runat="server" Text=""></asp:Label></h6>
                </div>
            </div>
        </div>
        <div class="col-lg-3 col-sm-3 bottom-m3 Dash green">
            <div class="contact-box">
                <div class="contact-icon">
                    <span class="fa fa-user"></span>
                </div>
                <div class="contact-info">
                    <h5>Direct Id's </h5>
                    <h6>Left :
                        <asp:Label ID="leftdr" runat="server" Text=""></asp:Label>
                        Right :
                        <asp:Label ID="rightdr" runat="server" Text=""></asp:Label></h6>

                </div>
            </div>
        </div>
        <div class="col-lg-3 col-sm-3 bottom-m3 Dash pink">
            <div class="contact-box">
                <div class="contact-icon">
                    <span class="fa fa-user"></span>
                </div>
                <div class="contact-info">
                    <h5>Team Id's</h5>
                    <h6>Left :
                        <asp:Label ID="teaml" runat="server" Text=""></asp:Label>
                        Right :
                        <asp:Label ID="teamr" runat="server" Text=""></asp:Label></h6>

                </div>
            </div>
        </div>
       <%-- <div class="col-lg-3 col-sm-3 bottom-m3 Dash pink">
            <div class="contact-box">
                <div class="contact-icon">
                    <span class="fa fa-user"></span>
                </div>
                <div class="contact-info">
                    <h5>Creteria Id's </h5>
                    <h6>Left :
                        <asp:Label ID="lblleft" runat="server" Text=""></asp:Label>
                        Right :
                        <asp:Label ID="lblright" runat="server" Text=""></asp:Label></h6>
                </div>
            </div>
        </div>--%>
        <div class="col-lg-3 col-sm-3 bottom-m3 Dash blue">
            <div class="contact-box">
                <div class="contact-icon">
                    <span class="fa fa-bank"></span>
                </div>
                <div class="contact-info">

                    <h5>Installments </h5>
                    <h6>
                        <asp:Label ID="lblins" runat="server" Text=""></asp:Label>
                    </h6>
                </div>
            </div>
        </div>
        <div class="col-lg-3 col-sm-3 bottom-m3 Dash yellow">
            <div class="contact-box">
                <div class="contact-icon">
                    <span class="fa fa-inr"></span>
                </div>
                <div class="contact-info">
                    <h5>Wallet Amount </h5>
                    <h6>
                        <asp:Label ID="lblwallet" runat="server" Text=""></asp:Label></h6>
                </div>
            </div>
        </div>
        <div class="col-lg-3 col-sm-3 bottom-m3 Dash green">
            <div class="contact-box">
                <div class="contact-icon">
                    <span class="fa fa-inr"></span>
                </div>
                <div class="contact-info">
                    <h5>Payout</h5>
                    <h6>
                        <asp:Label ID="lblclear" runat="server" Text=""></asp:Label>
                    </h6>
                </div>
            </div>
        </div>
    </div>
    <div class="col-md-12">
        <div class="col-md-10">
            <div class="alert alert-success" role="alert">
                Two Direct Compulsary Id's (One Left and On Right)
   
            </div>
        </div>
        <div class="col-md-2"></div>
    </div>
    <div class="col-md-12">
        Welcome <%=name %>
    </div>
    <div class="col-md-6 col-md-offset-3">
        <table style="width: 100%;" class="table table-bordered">
            <tr>
                <td colspan="2">
                    <b>Member Details</b>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Registration Id</td>
                <td><%=regno %></td>
            </tr>
            <tr>
                <td class="auto-style1">First Name</td>
                <td><%=name %></td>
            </tr>
            <tr>
                <td class="auto-style1">S/o,W/o,D/o</td>
                <td><%=father %>;</td>
            </tr>
            <tr>
                <td class="auto-style1">Joining Date</td>
                <td><%=date %></td>
            </tr>
            <tr>
                <td class="auto-style1">Address</td>
                <td><%=address %></td>
            </tr>
            <tr>
                <td class="auto-style1">Gender</td>
                <td><%=gender %></td>
            </tr>
            <tr>
                <td class="auto-style1">Mobileno.</td>
                <td><%=phn %></td>
            </tr>
            <tr>
                <td class="auto-style1">Marital Status</td>
                <td><%=marital %></td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpfotter" runat="Server">
</asp:Content>

