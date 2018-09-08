<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/Main.master" AutoEventWireup="true" CodeFile="front-achiever.aspx.cs" Inherits="Auth_front_achiever" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
    Upload Achiever
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
        <div class="form-group">
               <label>Image</label>
            <asp:FileUpload ID="FileUpload1" runat="server" />
               
          </div>
        <div class="form-group">
                   <asp:Button CssClass="btn-success btn" ID="btnsubmit" runat="server" 
                       Text="Submit" onclick="btnsubmit_Click" />
        </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

