<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/Main.master" AutoEventWireup="true" CodeFile="LastJoining.aspx.cs" Inherits="Auth_LastJoining" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" runat="Server">
    Check Datewise Joining
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" runat="Server">
    <div class="col-md-12">
        <div class="col-md-12">
            <div class="alert alert-info" role="alert" style="color:black !important">
                Last Joining is <asp:Label ID="lblid" runat="server" Text=""></asp:Label> on <asp:Label ID="lbldate" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="form-group col-md-3">

            <asp:DropDownList ID="ddlday" runat="server" class="form-control">

                <asp:ListItem Value="Day">Day</asp:ListItem>
                <asp:ListItem Value="1">1</asp:ListItem>
                <asp:ListItem Value="2">2</asp:ListItem>
                <asp:ListItem Value="3">3</asp:ListItem>
                <asp:ListItem Value="4">4</asp:ListItem>
                <asp:ListItem Value="5">5</asp:ListItem>
                <asp:ListItem Value="6">6</asp:ListItem>
                <asp:ListItem Value="7">7</asp:ListItem>
                <asp:ListItem Value="8">8</asp:ListItem>
                <asp:ListItem Value="9">9</asp:ListItem>
                <asp:ListItem Value="10">10</asp:ListItem>
                <asp:ListItem Value="11">11</asp:ListItem>
                <asp:ListItem Value="12">12</asp:ListItem>
                <asp:ListItem Value="13">13</asp:ListItem>
                <asp:ListItem Value="14">14</asp:ListItem>
                <asp:ListItem Value="15">15</asp:ListItem>
                <asp:ListItem Value="16">16</asp:ListItem>
                <asp:ListItem Value="17">17</asp:ListItem>
                <asp:ListItem Value="18">18</asp:ListItem>
                <asp:ListItem Value="19">19</asp:ListItem>
                <asp:ListItem Value="20">20</asp:ListItem>
                <asp:ListItem Value="21">21</asp:ListItem>
                <asp:ListItem Value="22">22</asp:ListItem>
                <asp:ListItem Value="23">23</asp:ListItem>
                <asp:ListItem Value="24">24</asp:ListItem>
                <asp:ListItem Value="25">25</asp:ListItem>
                <asp:ListItem Value="26">26</asp:ListItem>
                <asp:ListItem Value="27">27</asp:ListItem>
                <asp:ListItem Value="28">28</asp:ListItem>
                <asp:ListItem Value="29">29</asp:ListItem>
                <asp:ListItem Value="30">30</asp:ListItem>
                <asp:ListItem Value="31">31</asp:ListItem>
            </asp:DropDownList>

        </div>
        <div class="form-group col-sm-3">
            <div class="selected-box auto-hight">
                <asp:DropDownList ID="ddlmonth" runat="server" class="form-control">
                    <asp:ListItem Value="Month">Month</asp:ListItem>
                    <asp:ListItem Value="1">1</asp:ListItem>
                    <asp:ListItem Value="2">2</asp:ListItem>
                    <asp:ListItem Value="3">3</asp:ListItem>
                    <asp:ListItem Value="4">4</asp:ListItem>
                    <asp:ListItem Value="5">5</asp:ListItem>
                    <asp:ListItem Value="6">6</asp:ListItem>
                    <asp:ListItem Value="7">7</asp:ListItem>
                    <asp:ListItem Value="8">8</asp:ListItem>
                    <asp:ListItem Value="9">9</asp:ListItem>
                    <asp:ListItem Value="10">10</asp:ListItem>
                    <asp:ListItem Value="11">11</asp:ListItem>
                    <asp:ListItem Value="12">12</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group col-sm-3">
            <div class="selected-box auto-hight">
                <asp:DropDownList ID="ddlyear" runat="server" class="form-control">
                    <asp:ListItem Value="Year">Year</asp:ListItem>
                    <asp:ListItem Value="2017">2017</asp:ListItem>
                    <asp:ListItem Value="2018">2018</asp:ListItem>
                    <asp:ListItem Value="2019">2019</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <div class="form-group col-md-3">
            <asp:Button CssClass="btn btn-success" ID="btnsubmit" runat="server"
                Text="Submit" OnClick="btnsubmit_Click" />
        </div>
        <div class="col-md-12">
             <table id="table1" class="table table-striped table-hover table-fw-widget">
                    <thead>
                    <tr>
                        <th>Sr.No</th>
                        <th>Reg.Id</th>
                        <th>Name</th>
                        <th>Sponsor Id</th>
                        <th>Mobile</th>



                    </tr>
                </thead>
                <asp:ListView ID="gvpins" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Container.DataItemIndex+1 %></td>

                            <td><%#Eval("regno") %></td>
                            <td><%#Eval("fname") %></td>
                            <td><%#Eval("spillsregno") %></td>
                            <td><%#Eval("mobile") %></td>


                        </tr>

                    </ItemTemplate>
                </asp:ListView>
            </table>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" runat="Server">
</asp:Content>

