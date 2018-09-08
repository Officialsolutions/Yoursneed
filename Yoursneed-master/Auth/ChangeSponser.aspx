<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/Main.master" AutoEventWireup="true" CodeFile="ChangeSponser.aspx.cs" Inherits="Auth_ChangeSponser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
    Create Sponser
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <div class="col-md-8">
       
             
            
           <div class="form-group">
               <label> Enter Registration Id. </label>
               <asp:TextBox ID="txtregid" AutoPostBack="true" OnTextChanged="txtregid_TextChanged" runat="server" class="form-control" ></asp:TextBox>
               <asp:Label ID="lblname" runat="server" Text=""></asp:Label>
               <asp:Label ID="lblna" runat="server" Text=""></asp:Label>
          </div>
        <div class="form-group">
               <label> Sponsor </label>
               <asp:TextBox ID="txtsponser" AutoPostBack="true" OnTextChanged="txtsponser_TextChanged" runat="server" class="form-control" ></asp:TextBox>
               <asp:Label ID="lblsponser" runat="server" Text=""></asp:Label>
     
          </div>
          <div class="form-group">
                   <asp:Button CssClass="btn-success" ID="btnsubmit" runat="server" 
                       Text="Submit" onclick="btnsubmit_Click" />
        </div>
    </div>
    <div class="col-md-4">
       
                    
    </div>
             </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>
