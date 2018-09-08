<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/Main.master" AutoEventWireup="true" CodeFile="View-Structure.aspx.cs" Inherits="Auth_View_Structure" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
    Add Structure 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
      <div class="col-md-12">
          
           <div class="form-group col-md-3">
          
               <asp:TextBox ID="txtregid" runat="server" class="form-control" placeholder="Enter Registration Id. "></asp:TextBox>
                <asp:Label ID="lblname" runat="server" Text=""></asp:Label>
          </div>
          <div class="form-group col-md-3">
                   <asp:Button CssClass="btn-default btn" ID="btnsubmit" runat="server" 
                       Text="Submit" onclick="btnsubmit_Click"/>
        </div>
           <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
          <div class="form-group col-md-3">
          
               <asp:TextBox ID="txtadreg" runat="server" OnTextChanged="txtadreg_TextChanged" AutoPostBack="true" class="form-control" placeholder="Enter Registration Id." ></asp:TextBox>
              <asp:Label ID="lblregname" runat="server" Text=""></asp:Label>
            
          </div>
                </ContentTemplate>
                </asp:UpdatePanel>
          <div class="form-group col-md-3">
                   <asp:Button CssClass="btn-primary btn" ID="btnsave" runat="server" 
                       Text="Save" onclick="btnsave_Click" Enabled="false"/>
        </div>
    </div>
     <div class="col-md-12">


         <table id="table1" class="table table-striped table-hover table-fw-widget">
                    <thead>
                <tr>
                    <th>Sr.No</th>
                    <th>Regno</th>
                    <th>AddInst</th>
                    <th>Product Name</th>
                    <th>Product Date</th>
                     <th>Name</th>
                    <th>joining</th>
                    <th>installments</th>
                    <th>LastPaid</th>
                    <th></th>
                </tr>
            </thead>
            <asp:ListView ID="gvpins" runat="server" OnItemDataBound="gvpins_ItemDataBound" OnItemCommand="gvpins_ItemCommand" EnableViewState="true">
                <ItemTemplate>
                    <tr>
                        <td><%# Container.DataItemIndex+1 %></td>

                        <td><%#Eval("regno") %></td>
                        <td>
                            <asp:TextBox ID="txtpaid" CssClass="form-control" runat="server"></asp:TextBox>
                        </td>
                          <td>
                            <asp:TextBox ID="txtproduct" CssClass="form-control" runat="server" Text='<%#Eval("productname") %>' ></asp:TextBox>
                        </td>
                         <td>
                             <%#Eval("productdate") %>
                          <%-- <asp:Label ID="lblpdate" runat="server" Text='<%# Convert.ToDateTime(Eval("productdate")).ToString("dd/MM/yyyy") %>'></asp:Label>--%>
                        </td>
                        <td><%#Eval("fname") %></td>
                        <td>
                            <asp:Label ID="lbldate" runat="server" Text='<%# Convert.ToDateTime(Eval("joined")).ToString("dd/MM/yyyy") %>'></asp:Label>

                        </td>

                        <td>
                            <asp:HiddenField ID="hfid" Value='<%#Eval("regno") %>' runat="server" />
                            <asp:Label ID="lbltotalinst" runat="server" Text="Label"></asp:Label></td>
                        <td>
                            <asp:Label ID="lbllastpaid" runat="server" Text="Label"></asp:Label>
                            
                        </td>
                        <td>
                            <asp:LinkButton ID="lnkdelete" runat="server" CssClass="label label-danger" OnClick="lnkdelete_Click" CommandArgument='<%#Eval("regno") %>'>Delete</asp:LinkButton>
                            <asp:LinkButton ID="lnkinst" CommandArgument='<%#Eval("regno") %>' OnClick="lnkinst_Click" runat="server">installment</asp:LinkButton>
                             <asp:LinkButton ID="lnksave" CommandArgument='<%#Eval("cregno") %>' CommandName="save" runat="server" CssClass="label label-primary">Submit</asp:LinkButton>
                        </td>


                </ItemTemplate>
            </asp:ListView>
        </table>


    </div>

     <div class="col-md-12">
          
           
          <div class="form-group col-md-3">
                   <asp:Button CssClass="btn-default btn" ID="btnpay" runat="server" 
                       Text="Pay Now" onclick="btnpay_Click"/>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

