<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html lang="en">


<!-- Mirrored from themes.potenzaglobalsolutions.com/html/seohub-seo-marketing-social-media-multipurpose-html5-template/error-404.html by HTTrack Website Copier/3.x [XR&CO'2014], Tue, 27 Feb 2018 05:55:46 GMT -->
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="keywords" content="HTML5 Template" />
    <meta name="description" content="YoursNeed" />
    <meta name="author" content="potenzaglobalsolutions.com" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <title>Yours Need</title>
    <!-- Favicon -->
    <link rel="shortcut icon" href="images/favicon.ico" />

    <!-- bootstrap -->
    <link rel="stylesheet" type="text/css" href="css/bootstrap.min.css" />

    <!-- mega menu -->
    <link rel="stylesheet" type="text/css" href="css/mega-menu/mega_menu.css" />

    <!-- font awesome -->
    <link rel="stylesheet" type="text/css" href="css/font-awesome.min.css" />

    <!-- Themify icons -->
    <link rel="stylesheet" type="text/css" href="css/themify-icons.css" />

    <!-- main style -->
    <link rel="stylesheet" type="text/css" href="css/style.css" />

    <!-- Responsive style -->
    <link rel="stylesheet" type="text/css" href="css/responsive.css" />

    <!-- Style customizer -->
    <link rel="stylesheet" href="#" data-style="styles">
    <link rel="stylesheet" type="text/css" href="css/style-customizer.css" />
    <link href="css/responsiveslides.css" rel="stylesheet" />

    <style>
        #mask {
            position: absolute;
            left: 0;
            top: 0;
            z-index: 9000;
            background-color: #26262c;
            display: none;
        }

        #boxes .window {
            position: absolute;
            left: 0;
            top: 0;
            width: 340px;
            height: 850px;
            display: none;
            z-index: 9999;
            padding: 20px;
            border-radius: 5px;
            text-align: center;
        }

        #boxes #dialog {
            width: 350px;
            height: auto;
            padding: 10px 10px 10px 10px;
            background-color: #ffffff;
            font-size: 15pt;
        }

        .agree:hover {
            background-color: #D1D1D1;
        }

        .popupoption:hover {
            background-color: #D1D1D1;
            color: green;
        }

        .popupoption2:hover {
            color: red;
        }
    </style>
</head>

<body runat="server">
    <form runat="server">
        <div id="boxes">
            <div style="top: 50%; left: 50%; display: none;" id="dialog" class="window">
                <div id="san">
                    <a href="#" class="close agree">
                        <img src="Auth/img/cross.png" width="35" style="float: right; margin-right: -20px; margin-top: -20px;" class="img-responsive" /></a>
                    <ul class="rslides">

                        <asp:ListView ID="ListView2" runat="server">
                            <ItemTemplate>
                                <li>
                                    <img src='uploadimage/<%# Eval("image") %>' class="img-responsive">
                                </li>
                            </ItemTemplate>
                        </asp:ListView>

                    </ul>
                </div>
            </div>
            <div style="font-size: 32pt; color: white; height: 1990px; display: none; opacity: 0.4;" id="mask"></div>
        </div>
        <%-- <div style="width: 2478px; font-size: 32pt; color: white; height: 1202px; display: none; opacity: 0.4;" id="mask"></div>--%>
        <div id="loading">
            <div id="loading-center">
                <img src="images/loader.gif" alt="">
            </div>
        </div>
        <header id="header" class="default">
            <div class="topbar">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-4 col-md-4">
                            <div class="topbar-left text-left">
                                <ul class="list-inline">
                                    <li><i class="ti-location-pin"></i>Makhu</li>
                                    <li><i class="ti-headphone-alt"></i>077078 20955</li>
                                </ul>
                            </div>
                        </div>
                        <div class="col-lg-8 col-md-8">
                            <div class="topbar-right text-right">
                                <ul class="list-inline">

                                    <li><a href="#">Support & FAQ</a></li>
                                    <li><a href="Login.aspx">Login </a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!--=================================
    mega menu -->

            <div class="menu">
                <!-- menu start -->
                <nav id="menu" class="mega-menu">
                    <!-- menu list items container -->
                    <section class="menu-list-items">
                        <div class="container">
                            <div class="row">
                                <div class="col-lg-12 col-md-12">
                                    <!-- menu logo -->
                                    <ul class="menu-logo">
                                        <li>
                                            <a href="Default.aspx">
                                                <img id="logo_img" src="images/logo-dark.png" alt="logo">
                                            </a>
                                        </li>
                                    </ul>
                                    <!-- menu links -->
                                    <ul class="menu-links">

                                        <li><a href="Default.aspx">Home </a>
                                            <!-- drop down multilevel  -->

                                        </li>

                                        <li><a href="#">About </a>
                                            <!-- drop down multilevel  -->

                                        </li>
                                        <!-- active class -->
                                        <li class="active"><a href="javascript:void(0)">Products </a></li>
                                        <li><a href="javascript:void(0)">Oppertunity </a></li>
                                        <li><a href="Legal.aspx">Legal </a></li>
                                        <li><a href="javascript:void(0)">Gallery </a></li>
                                        <li><a href="ContactUs.aspx">Contact </a></li>
                                        <li>
                                            <asp:LinkButton ID="LinkButton1" OnClick="lnklogin_Click" runat="server">Login</asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton2" OnClick="lnklogout_Click" runat="server" Visible="false">Logout</asp:LinkButton>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </section>
                </nav>
                <!-- menu end -->
            </div>
        </header>
        <!--=================================
search and side menu content -->

        <div class="search-overlay"></div>
        <div class="menu-overlay"></div>
        <div id="search" class="search">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12 col-md-12">
                        <input type="search" placeholder="Type and hit enter...">
                    </div>
                </div>
            </div>
        </div>
        <div class="side-content" id="scrollbar">
            <div class="side-content-info">
                <div class="menu-toggle-hamburger menu-close"><span class="ti-close"></span></div>
                <div class="side-logo">
                    <img class="img-responsive mb-30" src="images/logo-dark.png" alt="">
                    <p>Culpa molestias mollitia natus labore perspiciatis ipsa lorem ipsum dolor sit amet, consectetur adipisicing elit. Sit aut explicabo mollitia, sed, eos, magni quos laborum dolores ab distinctio voluptates quae ipsam.</p>
                    <hr class="mt-20 mb-30" />
                </div>
                <div class="contact-address">
                    <div class="address-title mb-30">
                        <h4 class="mb-15">Office 01</h4>
                        <p>mollitia omnis fuga, nihil suscipit lorem ipsum dolor sit amet, consectetur adipisicing elit. Deleniti sit quos.</p>
                    </div>
                    <div class="contact-box mb-20">
                        <div class="contact-icon">
                            <i class="ti-direction-alt text-blue"></i>
                        </div>
                        <div class="contact-info">
                            <div class="text-left">
                                <h6>25, King St. 20170</h6>
                                <span>Melbourne Australia</span>
                            </div>
                        </div>
                    </div>
                    <div class="contact-box mb-20">
                        <div class="contact-icon">
                            <i class="ti-headphone-alt text-blue"></i>
                        </div>
                        <div class="contact-info">
                            <div class="text-left">
                                <h6>0011 234 56789</h6>
                                <span>Mon-Fri 8:30am-6:30pm</span>
                            </div>
                        </div>
                    </div>
                    <div class="contact-box mb-20">
                        <div class="contact-icon">
                            <i class="ti-email text-blue"></i>
                        </div>
                        <div class="contact-info">
                            <div class="text-left">
                                <h6>info@yoursite.com</h6>
                                <span>24 X 7 online support</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="side-content-image">
                <img class="img-responsive center-block" src="images/bg-element/04.png" alt="">
            </div>
        </div>
        <section>
            <ul class="rslides">
                <li>
                    <img src="images/slider1.jpg" alt=""></li>
                <li>
                    <img src="images/slider2.jpg" alt=""></li>

            </ul>
        </section>
        <section class="page-section-ptb">
            <div class="container">
                <div class="row">
                    <div class="col-lg-6 col-md-6">
                        <h3 class="mb-20">GROW YOUR BUSINESS WITH US</h3>
                        <p class="mb-30">We are on a mission to build, grow and maintain loyal communities at every touchpoint. This means you can accomplish your business goals through digital marketing</p>
                        <div class="accordion icon">
                            <div class="acd-group acd-active">
                                <a href="#" class="acd-heading"><span class="ti-bar-chart-alt text-blue"></span>We always Support within one business day.</a>
                                <div class="acd-des">Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem.</div>
                            </div>
                            <div class="acd-group">
                                <a href="#" class="acd-heading text-black"><span class="ti-pulse text-blue"></span>We deliver Top Rankings.</a>
                                <div class="acd-des">Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem.</div>
                            </div>
                            <div class="acd-group">
                                <a href="#" class="acd-heading text-black"><span class="ti-shield text-blue"></span>High customer retention rate.</a>
                                <div class="acd-des">Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem.</div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-3 text-center" style="height: 346px; overflow: hidden">
                        <h3 class="mb-20" style="background: #05b901; color: white;">Achievers</h3>
                        <marquee direction="up" style="height: 346px" scrollamount="3" onmouseover="this.stop();" onmouseout="this.start();">
                      <asp:ListView ID="lvac" runat="server">
                          <ItemTemplate>
                              <div class=" row">
                          <img src="uploadimage/<%#Eval("image") %>" class="img-responsive" style="padding: 15px;" />
                      </div>
                          </ItemTemplate>
                      </asp:ListView>
                      
                  </marquee>
                    </div>
                    <div class="col-lg-3 col-md-3 text-center">
                        <h3 class="mb-20" style="background: #05b901; color: white;">News & Events</h3>
                        <marquee direction="up" style="height: 346px" scrollamount="3" onmouseover="this.stop();" onmouseout="this.start();">
                      <asp:ListView ID="ListView1" runat="server">
                          <ItemTemplate>
                              <div class=" row">
                          <img src="uploadimage/<%#Eval("image") %>" class="img-responsive" style="padding: 15px;" />
                      </div>
                          </ItemTemplate>
                      </asp:ListView>
                      
                  </marquee>
                    </div>
                </div>
            </div>
        </section>
        <footer class="footer footer-topbar page-section-pt">
            <div class="container">


                <div class="row mt-80">
                    <div class="col-lg-4 col-sm-4 bottom-m3">
                        <div class="contact-box">
                            <div class="contact-icon">
                                <i class="ti-direction-alt"></i>
                            </div>
                            <div class="contact-info">
                                <h5>Near Railway Fatak, Makhu</h5>
                                <span>Teh. Zira, Dist. Ferozpur ( PB ) </span>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-sm-4 bottom-m3">
                        <div class="contact-box">
                            <div class="contact-icon">
                                <i class="ti-headphone-alt"></i>
                            </div>
                            <div class="contact-info">
                                <h5>077078 26373</h5>
                                <span>Mon-Fri 8:30am-6:30pm</span>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-sm-4">
                        <div class="contact-box">
                            <div class="contact-icon">
                                <i class="ti-email"></i>
                            </div>
                            <div class="contact-info">
                                <h5>info@yoursneed.com</h5>
                                <span>24 X 7 online support</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="copyright mt-60">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-6 col-sm-6">
                            <ul class="list-inline text-left">
                                <li>Powered By: <a href="http://www.officialsolutions.in">Official Solutions </a>&nbsp;&nbsp;&nbsp;|</li>

                            </ul>
                        </div>
                        <div class="col-lg-6 col-sm-6">
                            <div class="text-right">
                                <p>Copyright © 2017 Yours Need. All Rights Reserved.</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </footer>
        <!--=================================
footer -->
        <!--=================================
 color customizer -->

        <div class="style-customizer closed">
            <div class="buy-button"><a class="opener" href="#"><i class="fa fa-cog fa-spin"></i></a></div>
            <div class="clearfix content-chooser">
                <a target="_blank" class="button" href="https://themeforest.net/item/car-dealer-the-best-car-dealer-automotive-responsive-html5-template/19226545?ref=Potenzaglobalsolutions">purchase now</a>
                <h3>Color Schemes</h3>
                <p>Which theme color you want to use? Here are some predefined colors.</p>
                <ul class="styleChange clearfix">
                    <li class="skin-default selected" title="Default" data-style="skin-default"></li>
                    <li class="skin-blue" title="Blue" data-style="skin-blue"></li>
                    <li class="skin-orange" title="Orange" data-style="skin-orange"></li>
                    <li class="skin-purple" title="purple" data-style="skin-purple"></li>
                    <li class="skin-gold" title="gold" data-style="skin-gold"></li>
                    <li class="skin-green" title="green" data-style="skin-green"></li>
                    <li class="skin-red" title="red" data-style="skin-red"></li>
                    <li class="skin-yellow" title="Yellow" data-style="skin-yellow"></li>
                </ul>
                <ul class="resetAll">
                    <li><a class="button button-reset" href="#">Reset All</a></li>
                </ul>
            </div>
        </div>

        <!--=================================
 color customizer -->


        <!--=================================
back to top -->
        <div class="back-to-top">
            <span>
                <img src="images/rocket.png" data-src="images/rocket.png" data-hover="images/rocket.gif" alt=""></span>
        </div>
        <!--=================================
back to top -->
        <!-- jquery  -->
        <script type="text/javascript" src="js/jquery.min.js"></script>

        <!-- bootstrap -->
        <script type="text/javascript" src="js/bootstrap.min.js"></script>

        <!-- mega-menu -->
        <script type="text/javascript" src="js/mega-menu/mega_menu.js"></script>

        <!-- style customizer  -->
        <%-- <script type="text/javascript" src="js/style-customizer.js"></script>--%>

        <!-- custom -->
        <script type="text/javascript" src="js/custom.js"></script>
        <script src="css/responsiveslides.js"></script>
        <script>
            $(function () {
                $(".rslides").responsiveSlides();
            });
        </script>
        <script>
            $(document).ready(function () {
                var id = '#dialog';
                var maskHeight = $(document).height();
                var maskWidth = $(window).width();
                $('#mask').css({ 'width': maskWidth, 'height': maskHeight });
                $('#mask').fadeIn(500);
                $('#mask').fadeTo("slow", 0.9);
                var winH = $(window).height();
                var winW = $(window).width();
                $(id).css('top', winH / 2 - $(id).height() / 2);
                $(id).css('left', winW / 2 - $(id).width() / 2);
                $(id).fadeIn(2000);
                $('.window .close').click(function (e) {
                    e.preventDefault();
                    $('#mask').hide();
                    $('.window').hide();
                });
                $('#mask').click(function () {
                    $(this).hide();
                    $('.window').hide();
                });

            });
        </script>
        <script src="js/responsiveslides.min.js"></script>
        <%--   <script>
            $(function () {
                $(".rslides").responsiveSlides();
            });
        </script>--%>
    </form>
</body>

</html>
