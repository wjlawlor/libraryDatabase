<%@ Page Title="Library List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LibraryList.aspx.cs" Inherits="Library.Project.Library.LibraryList" %>

<%@ import namespace="System.Data" %>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

<h2>Libraries</h2>

<div>
    <asp:hyperlink runat="server" navigateurl="~/Project/Library/LibraryAdd.aspx">Add New Library</asp:hyperlink>
</div>

<asp:repeater id="Libraries" runat="server" itemtype="DataRow">
    <headertemplate>
        <table>
            <tr>
                <th>ID</th>
                <th>Name</th>
                <th>Address Line 1</th>
                <th>City</th>
                <th>State</th>
                <th>Postal Code</th>
                <th>&nbsp;</th>
            </tr>
    </headertemplate>
    <itemtemplate>
        <tr>
            <td><%# Item.Field<int>("Id") %></td>
            <td><%# Item.Field<string>("Name") %></td>
            <td><%# Item.Field<string>("AddrLine1") %></td>
            <td><%# Item.Field<string>("City") %></td>
            <td><%# Item.Field<string>("State") %></td>
            <td><%# Item.Field<string>("PostalCode") %></td>
            <td><asp:hyperlink runat="server" navigateurl='<%# string.Format("~/Project/Library/LibraryEdit.aspx?ID={0}", Item.Field<int>("Id")) %>' text="Edit" /></td>
        </tr>
    </itemtemplate>
    <footertemplate>
        </table>
    </footertemplate>
</asp:repeater>

</asp:Content>
