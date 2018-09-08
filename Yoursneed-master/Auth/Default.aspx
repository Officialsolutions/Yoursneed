<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/Main.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Auth_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" runat="Server">
    <style>
        .Dash {
            padding: 20px;
            background: menu;
            margin: 10px;
            width:357px;
            color:white;
            text-align:center;
        
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

        .contact-info h3 {
            color: white;
            font-weight: bold;
        }

        .red {
            background-color:orchid;
          
        }

        .pink {
            background-color:#ff00009e;
          
        }
        .contact-info span{
                font-size:18px;
        }
        .contact-info a{
            color:white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" runat="Server">
    <div class="col-md-12" style="margin-bottom: 20px;color: black;">
        <div class="col-lg-3 col-sm-4 bottom-m3 Dash green">
            <div class="contact-box">
              <%--  <div class="contact-icon">
                    <i class="fa fa-inr"></i>
                </div>--%>
                <div class="contact-info" >
                    
                      <span >
                          [<asp:Label ID="lbltoday" runat="server" Text=""></asp:Label>]</span>

                    <h3>Today Joining </h3>
                   
                    <a href="LastJoining.aspx" >Click All View</a>
                </div>
            </div>
        </div>
        <div class="col-lg-3 col-sm-4 bottom-m3 Dash green">
            <div class="contact-box">
            
                <div class="contact-info">
                          [<span>
                            <asp:Label ID="lbltotal" runat="server" Text=""></asp:Label></span>]
                    <h3>Total User </h3>
                 <a href="LastJoining.aspx" >Click All View</a>
                </div>
            </div>
        </div>
      <%--  <div class="col-lg-3 col-sm-4 bottom-m3 Dash green">
            <div class="contact-box">
                <div class="contact-icon">
                    <i class="fa fa-user"></i>
                </div>
                <div class="contact-info">
                    <h4>Total User :
                   
                        <span>
                            <asp:Label ID="lbltotal" runat="server" Text=""></asp:Label></span></h4>
                </div>
            </div>
        </div>--%>
        <div class="col-lg-3 col-sm-4 bottom-m3 Dash green">
            <div class="contact-box">
            
                <div class="contact-info">
                    <span > [ <asp:Label ID="lblblock" runat="server" Text=""></asp:Label>]</span>
                    <h3>Blocked User </h3>
                     <a href="ActiveId.aspx" >Click All View</a>
                </div>
            </div>
        </div>
        <div class="col-lg-3 col-sm-4 bottom-m3 Dash green">
            <div class="contact-box">
                <div class="contact-info">
                      <span >
                          [<asp:Label ID="lblunblock" runat="server" Text=""></asp:Label>]</span>
                    <h3>UN-Blocked User </h3>
                      <a href="Unblock.aspx" >Click All View</a>
                </div>
            </div>
        </div>
        <div class="col-lg-3 col-sm-4 bottom-m3 Dash green">
            <div class="contact-box">
     <%--           <div class="contact-icon">
                    <i class="fa fa-unlock"></i>
                </div>--%>
                <div class="contact-info">
                     <span >
                          [ <asp:Label ID="lblused" runat="server" Text=""></asp:Label>]</span>
                    <h3>Used Pins </h3>
                  <a href="UsedPins.aspx" >Click All View</a>
                </div>
            </div>
        </div>
        <div class="col-lg-3 col-sm-4 bottom-m3 Dash green">
            <div class="contact-box">
               <%-- <div class="contact-icon">
                    <i class="fa fa-lock"></i>
                </div>--%>
                <div class="contact-info">
                      <span >
                          [ <asp:Label ID="lblunused" runat="server" Text=""></asp:Label> ]</span>
                    <h3>UN-Used Pins   </h3>
                       <a href="unusedpinstatus.aspx" >Click All View</a>
                </div>
            </div>
        </div>
        <div class="col-lg-3 col-sm-4 bottom-m3 Dash green">
            <div class="contact-box">
              <%--  <div class="contact-icon">
                    <i class="fa fa-check-square"></i>
                </div>--%>
                <div class="contact-info">
                       <span>[ <asp:Label ID="lblinstall" runat="server" Text=""></asp:Label>  ]</span>
                   <h3>Today's Installments </h3>
                     <a href="ViewInstallments.aspx" >Click All View</a>
                </div>
            </div>
        </div>
        <div class="col-lg-3 col-sm-4 bottom-m3 Dash green">
            <div class="contact-box">
                <%--<div class="contact-icon">
                    <i class="fa fa-bank"></i>
                </div>--%>
                <div class="contact-info">
                     <span >[ <asp:Label ID="lblmonth" runat="server" Text=""></asp:Label> ]</span>
                       <h3> <%=monthname %> Installments  </h3>
                        <a href="ViewInstallments.aspx" >Click All View</a>
                </div>
            </div>
        </div>
        <div class="col-lg-3 col-sm-4 bottom-m3 Dash green">
            <div class="contact-box">
                <%--<div class="contact-icon">
                    <i class="fa fa-bell"></i>
                </div>--%>
                <div class="contact-info">
                     <span >[ <%--  <asp:Label ID="lblreward" runat="server" Text=""></asp:Label>--%>  ]</span>
                    <h3>Reward Alert</h3>
                        <a href="Achiever.aspx" >Click All View</a>
                </div>
            </div>
        </div>
          <div class="col-lg-3 col-sm-4 bottom-m3 Dash green">
            <div class="contact-box">
                <%--<div class="contact-icon">
                    <i class="fa fa-link"></i>
                </div>--%>
                <div class="contact-info">
                     <span >[ <asp:Label ID="lblstruct" runat="server" Text=""></asp:Label> ]</span>
                     <h3>Total Structure </h3>
                     <a href="clientstructure.aspx" >Click All View</a>
                  
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" runat="Server">
</asp:Content>

