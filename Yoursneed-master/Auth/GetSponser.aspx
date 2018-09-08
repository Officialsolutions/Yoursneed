<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/Main.master" AutoEventWireup="true" CodeFile="GetSponser.aspx.cs" Inherits="Auth_GetSponser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
    Get Sponser
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
    <div class="col-md-12">
          
           <div class="form-group col-md-3">
          
               <asp:TextBox ID="txtregid" runat="server" class="form-control" placeholder="Enter Registration Id. "></asp:TextBox>
           
          </div>
          <div class="form-group col-md-3">
                   <asp:Button CssClass="btn-default btn" ID="btnsubmit" runat="server" 
                       Text="Submit" onclick="btnsubmit_Click"/>
        </div>
    </div>
    <asp:Panel ID="Panel1" runat="server" Visible="false">
    <div class="col-md-12">
      <h4 style="margin-bottom: 20px;">SPONSORED IN LEFT</h4>

        <table id="example" class="table table-striped table-bordered" cellspacing="0" width="100%">
        <thead>
            <tr>
                <th>Sr.No</th>
                <th>Reg.Id</th>
                <th>Name</th>
                <th>Mobile</th>
                <th>Joining Date</th>
                <th>Installments</th>
              
            </tr>
        </thead>
        <asp:ListView ID="gvpins" runat="server">
            <ItemTemplate>
                <tr>
                    <td><%# Container.DataItemIndex+1 %></td>
                   
                    <td><%#Eval("regno") %></td>
                    <td><%#Eval("fname") %></td>
                    <td><%#Eval("mobile") %></td>
                    <td><asp:Label ID="lbldate" runat="server" Text='<%# Convert.ToDateTime(Eval("joined")).ToString("dd/MM/yyyy") %>'></asp:Label></td>
                    <td>   <%#Eval("cnt") %>
                        <%--<asp:LinkButton ID="lnkleft" CommandArgument='<%#Eval("regno") %>' OnClick="lnkleft_Click" runat="server">Installments</asp:LinkButton>--%>

                    </td>

                </tr>
              
            </ItemTemplate>
        </asp:ListView>
        </table>
        
   </div>
    
  <div class="col-md-12">
      <h4 style="margin-bottom: 20px;">SPONSORED IN RIGHT</h4>
      
        <table id="example2" class="table table-striped table-bordered" cellspacing="0" width="100%">
        <thead>
            <tr>
                <th>Sr.No</th>
                <th>Reg.Id</th>
                <th>Name</th>
                <th>Mobile</th>
                <th>Joining Date</th>
                <th>Installments</th>
              
            </tr>
        </thead>
            <asp:ListView ID="ListView1" runat="server">
            <ItemTemplate>
                <tr>
                    <td><%# Container.DataItemIndex+1 %></td>
                    
                    <td><%#Eval("regno") %></td>
                    <td><%#Eval("fname") %></td>
                    <td><%#Eval("mobile") %></td>
                    <td><asp:Label ID="lbldate" runat="server" Text='<%# Convert.ToDateTime(Eval("joined")).ToString("dd/MM/yyyy") %>'></asp:Label></td>
                    <td>
                        <%#Eval("cnt") %>
                       <%--<asp:LinkButton ID="lnkright" CommandArgument='<%#Eval("regno") %>' OnClick="lnkright_Click" runat="server">Installments</asp:LinkButton>--%>

                    </td>

                </tr>
              
            </ItemTemplate>
        </asp:ListView>
        </table>
        
   </div>
        </asp:Panel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

