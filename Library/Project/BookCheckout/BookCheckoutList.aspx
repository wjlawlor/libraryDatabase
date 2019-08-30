<%@ Page Title="Checkout Catalog" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookCheckoutList.aspx.cs" Inherits="Library.Project.BookCheckout.BookCheckoutList" %>

<%@ import namespace="System.Data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">

<h2>Checkout Catalog</h2>

<div class="form-group row">
    <div class="col-xs-2 ml-3">
        <asp:Label ID="LibraryDropDownLabel" runat="server" AssociatedControlId="LibraryDropDown" Text="View Books from a Specific Library: " />
        <asp:DropDownList ID="LibraryDropDown" class="custom-select mr-sm-2" runat="server" AppendDataBoundItems="True" DataTextField="LibraryName" DataValueField="Id" AutoPostBack="True">
            <asp:ListItem Value="" Text ="---ALL LIBRARIES---" />
        </asp:DropDownList>
    </div>
</div>

<asp:repeater id="CheckoutIDs" runat="server" itemtype="DataRow">
    <headertemplate>
        <table class="table border table-sm">
            <thead class="thead-dark">
                <tr>
                    <th>ID</th>
                    <th>Library</th>
                    <th>Book Title</th>
                    <th>Book ISBN</th>
                    <th>Patron Name</th>
                    <th>Librarian Name</th>
                    <th>Checkout Date</th>
                    <th>Return Date</th>
                    <th>Due Date</th>
                    <th>&nbsp;</th>
                </tr>
            </thead>
    </headertemplate>
    <itemtemplate>
        <tbody>
            <tr>
                <td><%# Item.Field<int>("Id") %></td>
                <td><%# Item.Field<string>("Name") %></td>
                <td><%# Item.Field<string>("Title") %></td>
                <td><%# Item.Field<string>("ISBN") %></td>
                <td><%# Item.Field<string>("LentTo") %></td>
                <td><%# Item.Field<string>("FromLibrarian") %></td>
                <td><%# Item.Field<DateTime>("CheckoutDate").ToShortDateString() %></td>
                <td><%# Item.Field<DateTime?>("ReturnDate") != null ? Item.Field<DateTime?>("ReturnDate").Value.ToShortDateString() : string.Empty %></td>
                <td><%# Item.Field<DateTime>("DueDate").ToShortDateString() %></td>
                <td><asp:Button runat="server" OnClick="Returned_Click" CommandArgument='<%# Item.Field<int>("Id") %>' Text="Return" /></td>                
            </tr>
        </tbody>
    </itemtemplate>
    <footertemplate>
    </table>
    </footertemplate>
</asp:repeater>

</asp:Content>
