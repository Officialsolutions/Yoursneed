<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/Main.master" AutoEventWireup="true" CodeFile="DeletePins.aspx.cs" Inherits="Auth_DeletePins" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
    Delete Pins
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
    <div class="form-group">
               <label> Total Pins</label>
               <asp:TextBox ID="txtregid" AutoPostBack="true" OnTextChanged="txtregid_TextChanged" runat="server" class="form-control" ></asp:TextBox>
               <asp:Label ID="lblname" runat="server" Text=""></asp:Label>
               
          </div>
    <div class="form-group">
               <label> Enter Registration Id. </label>
               <asp:TextBox ID="TextBox1" AutoPostBack="true" OnTextChanged="txtregid_TextChanged" runat="server" class="form-control" ></asp:TextBox>
               <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
               
          </div>
    <div class="form-group">
               <label> Enter Registration Id. </label>
               <asp:TextBox ID="TextBox2" AutoPostBack="true" OnTextChanged="txtregid_TextChanged" runat="server" class="form-control" ></asp:TextBox>
               <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
               
          </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

