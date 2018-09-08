<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/Main.master" AutoEventWireup="true" CodeFile="Serachpins.aspx.cs" Inherits="Auth_Serachpins" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
    Delete Pins
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
    <div class="form-group">
               <label> Enter Registration Id. </label>
               <asp:TextBox ID="txtregid" AutoPostBack="true" OnTextChanged="txtregid_TextChanged" runat="server" class="form-control" ></asp:TextBox>
               <asp:Label ID="lblname" runat="server" Text=""></asp:Label>
               
          </div>
        
    <div class="form-group">
               <label> Total Pins</label>

               <asp:Label ID="lbltotal" runat="server" Text='<%=total %>'><%=total %></asp:Label>
              
          </div>
                        </ContentTemplate>
         </asp:UpdatePanel>
    <div class="form-group">
               <label>Delete Pins</label>
               <asp:TextBox ID="txtdelete"  runat="server" class="form-control" ></asp:TextBox>
              
               
          </div>
        <div class="form-group">
                   <asp:Button CssClass="btn-success btn" ID="btnsubmit" runat="server" 
                       Text="Submit" onclick="btnsubmit_Click" />
        </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>
