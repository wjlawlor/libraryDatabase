<%@ Page Title="Library Homepage" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Library.Default" %>


<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <h1>Homepage</h1>

    <div>
        <asp:hyperlink runat="server" navigateurl="~/Project/Author/AuthorList.aspx">Author Stuff</asp:hyperlink>
    </div>

    <div>
        <asp:hyperlink runat="server" navigateurl="~/Project/Book/BookList.aspx">Book Stuff</asp:hyperlink>
    </div>

    <div>
        <asp:hyperlink runat="server" navigateurl="~/Project/BookCopy/BookCopyList.aspx">Book Copy Stuff</asp:hyperlink>
    </div>

    <div>
        <asp:hyperlink runat="server" navigateurl="~/Project/Library/LibraryList.aspx">Library Stuff</asp:hyperlink>
    </div>

    <div>
        <asp:hyperlink runat="server" navigateurl="~/Project/Patron/PatronList.aspx">Patron Stuff</asp:hyperlink>
    </div>

    <div>
        <asp:hyperlink runat="server" navigateurl="~/Project/Librarian/LibrarianList.aspx">Librarian Stuff</asp:hyperlink>
    </div>

    <div>
        <asp:hyperlink runat="server" navigateurl="~/Project/BookCheckout/BookCheckoutList.aspx">Checkout Stuff</asp:hyperlink>
    </div>
</asp:Content>
