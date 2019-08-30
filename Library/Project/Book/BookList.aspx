<%@ Page Title="Book List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookList.aspx.cs" Inherits="Library.BookList" %>

<%@ import namespace="System.Data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">

<h2>Books</h2>

<div>
    <asp:hyperlink runat="server" class="btn btn-primary mb-2" navigateurl="~/Project/Book/BookAdd.aspx">Add New Book</asp:hyperlink>
</div>

<asp:repeater id="Books" runat="server" itemtype="DataRow">
    <headertemplate>
        <table class="table border table-sm">
            <thead class="thead-dark">
                <tr>
                    <th>ID</th>
                    <th>Author</th>
                    <th>&nbsp;</th>
                    <th>Title</th>
                    <th>ISBN</th>
                    <th>&nbsp;</th>
                </tr>
            </thead>
    </headertemplate>
    <itemtemplate>
        <tbody>
            <tr>
                <td><%# Item.Field<int>("Id") %></td>
                <td><%# Item.Field<string>("FirstName") %></td>
                <td><%# Item.Field<string>("LastName") %></td>
                <td><%# Item.Field<string>("Title") %></td>
                <td><%# Item.Field<string>("ISBN") %></td>
                <td><asp:hyperlink runat="server" navigateurl='<%# string.Format("~/Project/Book/BookEdit.aspx?ID={0}", Item.Field<int>("Id")) %>' text="Edit" /></td>
            </tr>
        </tbody>
    </itemtemplate>
    <footertemplate>
    </table>
    </footertemplate>
</asp:repeater>

</asp:Content>
