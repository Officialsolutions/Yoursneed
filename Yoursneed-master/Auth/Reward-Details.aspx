<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/Main.master" AutoEventWireup="true" CodeFile="Reward-Details.aspx.cs" Inherits="Auth_Reward_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
     
    <div class="col-md-8">
       
           <div class="form-group">
               <label> Pairs</label>
               <asp:TextBox ID="txtpair" runat="server" class="form-control" ></asp:TextBox>
              
          </div>
        <div class="form-group">
               <label> Rewards </label>
               <asp:TextBox ID="txtrewards" runat="server" class="form-control" ></asp:TextBox>
              
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

