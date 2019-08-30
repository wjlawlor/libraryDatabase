<%@ Page Title="Book Checkout" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookCheckout.aspx.cs" Inherits="Library.Project.BookCheckout.BookCheckout" %>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

<h2>Book Checkout</h2>

<div class="form-group row">
    <div class="col-auto">
        <asp:Label ID="BookCopyLabel" runat="server" AssociatedControlId="BookCopy" Text="Book: " />
        <asp:Textbox ID="BookCopy" class="form-control" runat="server" Text="" Disabled="True" />
    </div>
</div>

<div class="form-group row">
    <div class="col-xs-3 ml-3">
        <asp:Label ID="PatronDropDownLabel" runat="server" AssociatedControlId="PatronDropDown" Text="Patron: " />
        <asp:DropDownList ID="PatronDropDown" class="custom-select mr-sm-2" runat="server" AppendDataBoundItems="True" DataTextField="PatronName" DataValueField="Id">
            <asp:ListItem Value="" Text =" " />
        </asp:DropDownList>
    </div>
</div>

<div class="form-group row">
    <div class="col-xs-3 ml-3">
        <asp:Label ID="LibrarianDropDownLabel" runat="server" AssociatedControlId="LibrarianDropDown" Text="Librarian: " />
        <asp:DropDownList ID="LibrarianDropDown" class="custom-select mr-sm-2" runat="server" AppendDataBoundItems="True" DataTextField="LibrarianName" DataValueField="Id">
            <asp:ListItem Value="" Text =" " />
        </asp:DropDownList>
    </div>
</div>

<div>
    <asp:button id="Save" class="btn btn-success btn-lg" runat="server" text="Save" onclick="Save_Click" />
    <asp:button ID="Cancel" class="btn btn-outline-danger btn-lg" runat="server" Text="Cancel" OnClick="Cancel_Click" />
</div>

</asp:Content>
