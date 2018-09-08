<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/Main.master" AutoEventWireup="true" CodeFile="sendpassword.aspx.cs" Inherits="Auth_sendpassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
    Send User's Password
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
    <div class="form-group">
       
        <asp:TextBox ID="txtpin" AutoPostBack="true" OnTextChanged="txtpin_TextChanged" runat="server" class="form-control"></asp:TextBox>
        
       <asp:Panel ID="pnldata" runat="server" Visible="false">
        Name: <asp:Label ID="lblname" runat="server" Text=""></asp:Label>
        Password: <asp:Label ID="lblpass" runat="server" Text=""></asp:Label>
        Mobile: <asp:Label ID="lblmob" runat="server" Text=""></asp:Label>
           </asp:Panel> 
    </div>
                </ContentTemplate>
         </asp:UpdatePanel>
    <div class="form-group">
        <asp:Button CssClass="btn-success" ID="btnsubmit" runat="server"
            Text="Submit" OnClick="btnsubmit_Click" />
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

