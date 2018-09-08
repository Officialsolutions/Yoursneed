<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.master" AutoEventWireup="true" CodeFile="ewalletdetail.aspx.cs" Inherits="User_ewalletdetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cptitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpmain" Runat="Server">

    <div class="col-md-12" style="margin-bottom: 20px;">
        <h4 style="margin-bottom: 20px;">Request For Transfer</h4>
    
           <div class="col-lg-3">
               <strong>Name : <asp:Label ID="lblname" runat="server" Text="Label"></asp:Label></strong>
           </div>
        <div class="col-lg-3">
               <strong>Reg Id  : <asp:Label ID="lblregno" runat="server" Text="Label"></asp:Label></strong>
           </div>
              <div class="col-lg-3">
               <strong>Mobile  : <asp:Label ID="lblmobile" runat="server" Text="Label"></asp:Label></strong>
           </div>
           <div class="col-lg-3">
               <strong>Total Wallet Amount  : <asp:Label ID="lbltotal" runat="server" Text="Label"></asp:Label></strong>
           </div>
        
        </div>
        <div class="col-md-12" style="margin-bottom: 20px;">
            <div class="col-md-4">
                Transfer To
               <asp:RadioButtonList ID="rdotype" runat="server">
                   <asp:ListItem Selected="True">Pin</asp:ListItem>
                   <asp:ListItem>Amount</asp:ListItem>
                   <asp:ListItem>Installment</asp:ListItem>
               </asp:RadioButtonList>
            </div>
             <div class="col-md-4">
                 Amount
                <asp:TextBox ID="txtamount" runat="server" required ></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression="^\d+$" ControlToValidate="txtamount" ErrorMessage="enter Numeric value only"></asp:RegularExpressionValidator>
            </div>
             <div class="col-md-4">
                 Reason
                <asp:TextBox ID="txtreason" runat="server" required></asp:TextBox>
            </div>
            </div>

        <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="button mt-30" OnClick="btnsubmit_Click"/>
     
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

