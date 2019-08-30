<%@ Page Title="Book Copy List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookCopyList.aspx.cs" Inherits="Library.Project.BookCopy.BookCopyList" %>

<%@ import namespace="System.Data" %>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

    <h2>Book Copys</h2>

<div>
    <asp:hyperlink runat="server" class="btn btn-primary mb-2" navigateurl="~/Project/BookCopy/BookCopyAdd.aspx">Add New Book Copy</asp:hyperlink>
</div>

<div class="form-group row">
    <div class="col-xs-2 ml-3">
        <asp:Label ID="LibraryDropDownLabel" runat="server" AssociatedControlId="LibraryDropDown" Text="View Books from a Specific Library: " />
        <asp:DropDownList ID="LibraryDropDown" class="custom-select mr-sm-2" runat="server" AppendDataBoundItems="True" DataTextField="LibraryName" DataValueField="Id" AutoPostBack="True">
            <asp:ListItem Value="" Text ="---ALL LIBRARIES---" />
        </asp:DropDownList>
    </div>
</div>

<asp:repeater id="BookCopys" runat="server" itemtype="DataRow">
    <headertemplate>
        <table class="table border table-sm">
            <thead class="thead-dark">
                <tr>
                    <th>ID</th>
                    <th>Book Title</th>
                    <th>Book ISBN</th>
                    <th>Location</th>
                    <th>Available?</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                </tr>
            </thead>
    </headertemplate>
    <itemtemplate>
        <tbody>
            <tr>
                <td><%# Item.Field<int>("Id") %></td>
                <td><%# Item.Field<string>("Title") %></td>
                <td><%# Item.Field<string>("ISBN") %></td>
                <td><%# Item.Field<string>("Name") %></td>
                <td><%# Item.Field<bool>("Available") %></td>
                <td><asp:hyperlink runat="server" navigateurl='<%# string.Format("~/Project/BookCopy/BookCopyEdit.aspx?ID={0}", Item.Field<int>("Id")) %>' text="Edit" /></td>
                <td><asp:hyperlink runat="server" class="btn btn-secondary btn-sm" navigateurl='<%# string.Format("~/Project/BookCheckout/BookCheckout.aspx?ID={0}", Item.Field<int>("Id")) %>' text="Checkout" /></td>
            </tr>
        </tbody>
    </itemtemplate>
    <footertemplate>
        </table>
    </footertemplate>
</asp:repeater>

</asp:Content>
