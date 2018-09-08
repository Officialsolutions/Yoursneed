<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/Main.master" AutoEventWireup="true" CodeFile="AddInstallments.aspx.cs" Inherits="Auth_AddInstallments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
    <div class="col-md-8">
       
             
            
           <div class="form-group">
               <label> Enter Registration Id. </label>
               <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                   <ContentTemplate>
               <asp:TextBox ID="txtregid" AutoPostBack="true" OnTextChanged="txtregid_TextChanged" runat="server" class="form-control" ></asp:TextBox>
               <asp:Label ID="lblname" runat="server" Text=""></asp:Label>
                       </ContentTemplate>
               </asp:UpdatePanel>
          </div>
        <div class="form-group">
               <label> Installment Amount</label>
               <asp:TextBox ID="txtamnt" AutoPostBack="true" Text="1000" Enabled="false" runat="server" class="form-control" ></asp:TextBox>
              
          </div>
        <div class="form-group">
               <label>   Select No. of Installments </label>
            <asp:DropDownList ID="ddlinst" runat="server" CssClass="form-control">

                <asp:ListItem Value="1" Selected="true">1</asp:ListItem>
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
            </asp:DropDownList>
          </div>
          <div class="form-group">
                   <asp:Button CssClass="btn-success" ID="btnsubmit" runat="server" 
                       Text="Submit" onclick="btnsubmit_Click" />
        </div>
    </div>
    <div class="col-md-4">
       
                    
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

