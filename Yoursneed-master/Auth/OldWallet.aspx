<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="OldWallet.aspx.cs" Inherits="Auth_OldWallet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 187px;
        }
        .auto-style4 {
            width: 130px;
        }
        .auto-style5 {
            width: 187px;
            height: 19px;
        }
        .auto-style7 {
            height: 19px;
        }
        .auto-style8 {
            width: 130px;
            height: 19px;
        }
        .auto-style11 {
            width: 172px;
        }
        .auto-style12 {
            width: 172px;
            height: 19px;
        }
        .auto-style13 {
            width: 138px;
        }
        .auto-style14 {
            width: 138px;
            height: 19px;
        }
        table#ctl00_cpmain_RadioButtonList1 tbody tr {
    display: inline;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
    Payout
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
    <div class="col-md-12">
        <div class="form-group col-md-3">

            <asp:TextBox ID="txtregid" runat="server" class="form-control" placeholder="Enter Registration Id. "></asp:TextBox>
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
        <div class="form-group col-md-3">
            <asp:Button CssClass="btn-default btn" ID="btnsubmit" runat="server"
                Text="Submit" OnClick="btnsubmit_Click" />
        </div>
    </div>
    <asp:Panel ID="Panel1" runat="server" Visible="false">
    <div class="col-md-12">
        <h4 style="margin-bottom: 20px;">Income Details</h4>
    
            <table style="width: 100%;" class="table table-bordered">
            <tr>
                <td><strong>Name : <asp:Label ID="lblname" runat="server" Text="Label"></asp:Label></strong></td>
                <td><strong>Reg Id : <asp:Label ID="lblregno" runat="server" Text="Label"></asp:Label></strong></td>
               
            </tr>
            <tr>
                <td colspan="2">
                    <table style="width: 100%;" class="table table-bordered">
                        <tr>
                            <td class="auto-style2">&nbsp;</td>
                            <td class="auto-style11">&nbsp;</td>
                            <td class="auto-style13">&nbsp;</td>
                            <td class="auto-style4">&nbsp;</td>
                            <td><strong>Direct Income</strong></td>
                        </tr>
                        <tr>
                            <td class="auto-style5"><strong>Total Sponser</strong></td>
                            <td class="auto-style12"><%=sponser %></td>
                            <td class="auto-style14"><span style="color: rgb(52, 73, 94); font-family: Arial, Helvetica, sans-serif; font-size: 12px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 700; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Income per Sponsor</span></td>
                            <td class="auto-style8"><asp:Label ID="lblsincome" runat="server" Text="400"></asp:Label></td>
                            <td class="auto-style7"><asp:Label ID="lblstotal" runat="server" Text="0"></asp:Label></td>
                        </tr>
                        <tr >
                            <td class="auto-style2"><strong>Total Proposers</strong></td>
                            <td class="auto-style11"><%=proposer %></td>
                            <td class="auto-style13"><span style="color: rgb(52, 73, 94); font-family: Arial, Helvetica, sans-serif; font-size: 12px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 700; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Income per Proposer</span></td>
                            <td class="auto-style4"><asp:Label ID="lblpincome" runat="server" Text="100"></asp:Label></td>
                            <td><asp:Label ID="lblptotal" runat="server" Text="0"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="auto-style2">&nbsp;</td>
                            <td class="auto-style11">&nbsp;</td>
                            <td class="auto-style13">&nbsp;</td>
                            <td class="auto-style4">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style2">&nbsp;</td>
                            <td class="auto-style11">&nbsp;</td>
                            <td class="auto-style13">&nbsp;</td>
                            <td class="auto-style4"><strong Class="text-primary">Total Income</strong></td>
                            <td>
                                <asp:Label ID="lbltotal" runat="server" Text="0" ></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="auto-style2">&nbsp;</td>
                            <td class="auto-style11">&nbsp;</td>
                            <td class="auto-style13">&nbsp;</td>
                            <td class="auto-style4"><strong Class="text-danger">TDS @ 10%</strong></td>
                            <td>
                                <asp:Label ID="lbltds" runat="server" Text="0" ></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="auto-style2">&nbsp;</td>
                            <td class="auto-style11">&nbsp;</td>
                            <td class="auto-style13">&nbsp;</td>
                            <td class="auto-style4"><strong Class="text-success">Payable</strong></td>
                            <td>
                                <asp:Label ID="lblnet" runat="server" Text="0" ></asp:Label></td>
                        </tr>
                    </table>
                </td>
               
            </tr>
          
        </table>
        </div>
        <div class="col-md-12">
            <h4 style="margin-bottom: 20px;">Withdrawls</h4>
            <table id="example2" class="table-bordered" cellspacing="0" width="100%">
        <thead>
            <tr>
                <th>Sr.No</th>
                <th>Dated</th>
                <th>Amount</th>
                <th>Reason of Payment</th>
                <th>Mode</th>
                <th>Action</th>
              
            </tr>
        </thead>
            <asp:ListView ID="ListView1" runat="server" OnItemDataBound="ListView1_ItemDataBound">
            <ItemTemplate>
                <tr>
                    <td><%# Container.DataItemIndex+1 %></td>
                    
                    <td><asp:Label ID="lbldate" runat="server" Text='<%# Convert.ToDateTime(Eval("dated")).ToString("dd/MM/yyyy") %>'></asp:Label></td>
                    <td>
                        <asp:Label ID="lblamt" runat="server" Text='<%#Eval("amount") %>'><%#Eval("amount") %></asp:Label></td>
                    <td><%#Eval("remarks") %></td>
                    <td><%#Eval("cash") %></td>
                    <td>
                        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click" CommandArgument='<%#Eval("serial") %>' CssClass="label label-info">Edit</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click"  CommandArgument='<%#Eval("serial") %>' CssClass="label label-danger" runat="server">Delete</asp:LinkButton>
                    </td>
                    
                </tr>
              
            </ItemTemplate>
        </asp:ListView>
        </table>
            <div class="col-md-12 text-center">
               <strong> Balance : <%=bal %> </strong>
            </div>
        </div>
        <div class="col-md-12">
            <h4 class="text-center text-capitalize">Upload Payout Details</h4>
                <hr />
            <div class="form-group col-md-2">

                <asp:TextBox ID="txtreg" runat="server" class="form-control" placeholder="Enter Registration Id. "></asp:TextBox>
                <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            </div>
            <div class="form-group col-md-2">

                <asp:TextBox ID="txtmnt" runat="server" class="form-control" placeholder="Amt. Paid "></asp:TextBox>
            </div>

            <div class="form-group col-md-3">

                <asp:TextBox ID="txtreason" runat="server" class="form-control" placeholder="Reason of Payment"></asp:TextBox>
            </div>
            <div class="form-group col-md-3">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                    <asp:ListItem Selected="True" >Cash</asp:ListItem>
                    <asp:ListItem>Cheque</asp:ListItem>
                    <asp:ListItem>Pins</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="form-group col-md-2">
                <asp:Button CssClass="btn-primary btn" ID="btnpaid" runat="server"
                    Text="Payout" OnClick="btnpaid_Click" />
            </div>
        </div>

      </asp:Panel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

