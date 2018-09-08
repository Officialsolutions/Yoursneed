<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="Creteria-List.aspx.cs" Inherits="Auth_Creteria_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" runat="Server">
    Criteria
  <%--  <%=cl %>
    <%=single %><br />

    <%=single2 %><br />
    <br />--%>
    <%--  <%=single3 %><br />--%>
    Count=<%=checkdatas %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" runat="Server">
    <div class="col-md-12">
        <div class="col-md-3">
        </div>
        <div class="col-md-6">
            <h4><b>
                <asp:Label ID="lblname" runat="server" Text="Label"></asp:Label><br />
                <asp:Label ID="lblreg" runat="server" Text="Label"></asp:Label><br />
                <asp:Label ID="lblstatus" runat="server" Text="Status Level"></asp:Label></b>
            </h4>

        </div>
    </div>
    <div class="col-md-12">
        <div class="col-md-2">
        </div>

        <div class="col-md-8">
            <h3>
                <b style="background-color: #34bf31; font-size: large;">Your Team Structure</b>
            </h3>
        </div>
    </div>
    <br />
    <br />
    <br />
    <div class="col-md-12">
        <div class="col-md-2">
        </div>

        <div class="col-md-8">
            <table class="table table-striped table-bordered ">
                <thead>
                    <tr style="background-color: #34bf31; font-size: medium">
                        <th>Sides</th>
                        <th>Direct ID's</th>
                        <th>Team ID's</th>
                        <th>Criteria ID's</th>
                    </tr>
                    <tr>
                        <td>Left Side
                        </td>
                        <td>
                            <asp:Label ID="leftdr" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="teaml" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblleft" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Right Side
                        </td>
                        <td>
                            <asp:Label ID="rightdr" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="teamr" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblright" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                </thead>
            </table>
        </div>
    </div>

    <%-- <p>Current Left Criteria Joinings : <asp:Label ID="lblleft" runat="server" Text="0"></asp:Label></p>
     <p>Current Right Criteria Joinings : <asp:Label ID="lblright" runat="server" Text="0"></asp:Label></p>
     <div class="col-md-12">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
        <AlternatingRowStyle />
        <Columns>
              <asp:TemplateField HeaderText="RegNo">
                <ItemTemplate>
                     <%#Eval("regno") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <%#Eval("fname") %>
                </ItemTemplate>
            </asp:TemplateField>
              <asp:TemplateField HeaderText="Left leg">
                <ItemTemplate>
                     <%#Eval("leftleg") %>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Left Direct Leg">
                <ItemTemplate>
                     <%#Eval("leftdirect") %>
                </ItemTemplate>
            </asp:TemplateField>
           
        </Columns>

    </asp:GridView>--%>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" runat="Server">
</asp:Content>

