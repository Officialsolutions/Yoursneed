<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="Pinhistory.aspx.cs" Inherits="Auth_Pinhistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
    Pin History
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
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
            <strong>Mobile</strong> :
            <asp:Label ID="lblmobile" runat="server" Text="0" CssClass="btn btn-danger"></asp:Label>
        </div>
    </div>
    <div class="col-md-12">

        <h3>Unused Pins</h3>
         <table id="table1" class="table table-striped table-hover table-fw-widget">
                    <thead>
                <tr>
                    <th>Sr.No</th>
                     <th>Pin</th>
                    <th>Pintype</th>
                     <th>Status</th>
                    <th>Created Date</th>
                   

                </tr>
            </thead>
            <asp:ListView ID="gvpinsnew" runat="server">
                <ItemTemplate>
                    <tr>
                         <td><%# Container.DataItemIndex+1 %></td>
                         <td> <%#Eval("pin") %></td>
                         <td> <%#Eval("pintype") %></td>
                         <td> <%#Eval("status") %></td>
                         <td> <asp:Label ID="lbldate" runat="server" Text='<%# Convert.ToDateTime(Eval("datecreate")).ToString("dd/MM/yyyy") %>'></asp:Label></td>
                      </tr>
                </ItemTemplate>
            </asp:ListView>
        </table>

       

    </div>
    <div class="col-md-12">

         <h3>Used Pins</h3>
         <table id="table2" class="table table-striped table-hover table-fw-widget">
                    <thead>
                <tr>
                     <th>Sr.No</th>
                     <th>Pin</th>
                     <th>Pintype</th>
                     <th>Status</th>
                     <th>Created Date</th>

                </tr>
            </thead>
            <asp:ListView ID="gvpinsallow" runat="server">
                <ItemTemplate>
                     <tr>
                         <td><%# Container.DataItemIndex+1 %></td>
                         <td> <%#Eval("pin") %></td>
                         <td> <%#Eval("pintype") %></td>
                         <td> <%#Eval("status") %></td>
                         <td> <asp:Label ID="lbldate" runat="server" Text='<%# Convert.ToDateTime(Eval("datecreate")).ToString("dd/MM/yyyy") %>'></asp:Label></td>
                      </tr>

                </ItemTemplate>
            </asp:ListView>
        </table>

       

    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

