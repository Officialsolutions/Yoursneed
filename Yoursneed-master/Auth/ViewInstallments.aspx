<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/Main.master" AutoEventWireup="true" CodeFile="ViewInstallments.aspx.cs" Inherits="Auth_ViewInstallments" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" runat="Server">
    Installments
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" runat="Server">
    <div class="col-md-12">

        <div class="form-group col-md-3">

            <asp:TextBox ID="txtregid" runat="server" class="form-control" placeholder="Enter Registration Id. "></asp:TextBox>
            <asp:Label ID="lblname" runat="server" Text="0" CssClass="btn btn-danger"></asp:Label>

        </div>
        <div class="form-group col-md-3">
            <asp:Button CssClass="btn-default btn" ID="btnsubmit" runat="server"
                Text="Submit" OnClick="btnsubmit_Click" />
        </div>
    </div>
    <div class="col-md-12 count">
        <div class="col-md-3">
            <strong>Total Installments</strong> :
           
            <asp:Label ID="lbltotal" runat="server" Text="" CssClass="btn btn-primary "></asp:Label>
        </div>
        <div class="col-md-3">
            <strong>Paid Installments</strong> :
           
            <asp:Label ID="lblpaid" runat="server" Text="0" CssClass="btn btn-success"></asp:Label>
        </div>
        <div class="col-md-3">
            <strong>Pending Installments</strong> :
           
            <asp:Label ID="lblpending" runat="server" Text="0" CssClass="btn btn-danger"></asp:Label>
        </div>
        <div class="col-md-3">
            <strong>Mobile</strong> :
           
            <asp:Label ID="lblmobile" runat="server" Text="0" CssClass="btn btn-danger"></asp:Label>
        </div>
    </div>
    <div class="col-md-12">

        <asp:GridView ID="gvpins" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered " Width="100%"  CellPadding="6" OnRowEditing="gvpins_RowEditing" OnRowUpdating="gvpins_RowUpdating" OnRowCancelingEdit="gvpins_RowCancelingEdit"> 
            <Columns>

                <asp:TemplateField HeaderText="Sr.No">
                    <ItemTemplate>
                      <%# Container.DataItemIndex+1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Amount">
                    <ItemTemplate>
                      <%# Container.DataItemIndex+1 %>
                         <asp:Label ID="lblid" runat="server" Text='<%#Eval("serial") %>' Visible="false"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date">
                    <ItemTemplate>
                       <asp:Label ID="lbldate" runat="server" Text='<%# Convert.ToDateTime(Eval("dated")).ToString("dd-MM-yyyy") %>'></asp:Label>
                    </ItemTemplate>
                      <EditItemTemplate>  
                        <asp:TextBox ID="txtdate" runat="server" Text='<%# Convert.ToDateTime(Eval("dated")).ToString("dd-MM-yyyy") %>' ReadOnly="true"></asp:TextBox>  
                          <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtdate" Format="dd-MM-yyyy" />
                    </EditItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                         <asp:LinkButton ID="delete" OnClick="delete_Click" runat="server" CommandArgument='<%#Eval("serial") %>'>Delete</asp:LinkButton>
                          <asp:Button ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit" />  
                    </ItemTemplate>
                      <EditItemTemplate>  
                        <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update"/>  
                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel"/>  
                    </EditItemTemplate>  
                </asp:TemplateField>
            </Columns>
           
        </asp:GridView>

        <%--         <table id="table1" class="table table-striped table-hover table-fw-widget">
                    <thead>
                <tr>
                    <th>Sr.No</th>
                    <th>Amount</th>
                    <th>Date</th>
                    <th>Action</th>

                </tr>
            </thead>
            <asp:ListView ID="gvpins" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Container.DataItemIndex+1 %></td>

                        <td><%# Container.DataItemIndex+1 %></td>
                        <td>
                            <asp:Label ID="lbldate" runat="server" Text='<%# Convert.ToDateTime(Eval("dated")).ToString("dd/MM/yyyy") %>'></asp:Label></td>
                        <td>
                      
                            <asp:LinkButton ID="delete" OnClick="delete_Click" runat="server" CommandArgument='<%#Eval("serial") %>'>Delete</asp:LinkButton>
                        </td>


                </ItemTemplate>
            </asp:ListView>
        </table>--%>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" runat="Server">
</asp:Content>

