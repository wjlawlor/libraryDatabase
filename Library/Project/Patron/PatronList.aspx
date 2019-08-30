<%@ Page Title="Patron List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PatronList.aspx.cs" Inherits="Library.Project.Patron.PatronList" %>

<%@ import namespace="System.Data" %>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

<h2>Patrons</h2>

<div>
    <asp:hyperlink runat="server" class="btn btn-primary mb-2" navigateurl="~/Project/Patron/PatronAdd.aspx">Add New Patron</asp:hyperlink>
</div>

<asp:repeater id="Patrons" runat="server" itemtype="DataRow">
    <headertemplate>
        <table class="table border table-sm">
            <thead class="thead-dark">
                <tr>
                    <th>Id</th>
                    <th>Library Card Number</th>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>Address</th>
                    <th>&nbsp;</th>
                    <th>City</th>
                    <th>State</th>
                    <th>Postal Code</th>
                    <th>&nbsp;</th>
                </tr>
            </thead>
    </headertemplate>
    <itemtemplate>
        <tbody>
            <tr>
                <td><%# Item.Field<int>("Id") %></td>
                <td><%# Item.Field<string>("LibraryCardNumber") %></td>
                <td><%# Item.Field<string>("FirstName") %></td>
                <td><%# Item.Field<string>("LastName") %></td>
                <td><%# Item.Field<string>("AddrLine1") %></td>
                <td><%# Item.Field<string>("AddrLine2") %></td>
                <td><%# Item.Field<string>("City") %></td>
                <td><%# Item.Field<string>("State") %></td>
                <td><%# Item.Field<string>("PostalCode") %></td>
                <td><asp:hyperlink runat="server" navigateurl='<%# string.Format("~/Project/Patron/PatronEdit.aspx?ID={0}", Item.Field<int>("Id")) %>' text="Edit" /></td>
            </tr>
        </tbody>
    </itemtemplate>
    <footertemplate>
    </table>
    </footertemplate>
</asp:repeater>

</asp:Content>
