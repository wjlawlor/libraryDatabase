<%@ Page Title="Edit Book Copy" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookCopyEdit.aspx.cs" Inherits="Library.Project.BookCopy.BookCopyEdit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

    <h2>Edit Book Copy</h2>

    <fieldset>
        <div>
            <asp:Label ID="BookLabel" runat="server" AssociatedControlId="Book" Text="Book: " />
            <asp:DropDownList ID="Book" runat="server" AppendDataBoundItems="True" DataTextField="BookTitle" DataValueField="Id">
                <asp:ListItem Value="" Text =" " />
            </asp:DropDownList>
        </div>
        <div>
            <asp:Label ID="LibraryLabel" runat="server" AssociatedControlId="LibraryName" Text="Location: " />
            <asp:DropDownList ID="LibraryName" runat="server" AppendDataBoundItems="True" DataTextField="LibraryName" DataValueField="Id">
                <asp:ListItem Value="" Text =" " />
            </asp:DropDownList>
        </div>
        <div>
            <asp:Label ID="Available" runat="server" AssociatedControlID="isAvailable" Text="Available?: " />
            <asp:RadioButton ID="isAvailable" runat="server" GroupName="Available" Text="Yes" />
            <asp:RadioButton ID="isNotAvailable" runat="server" GroupName="Available" Text="No" />
        </div>
    </fieldset>

    <div>
        <asp:button id="Save" runat="server" text="Save" onclick="Save_Click" />
        <asp:button ID="Cancel" runat="server" Text="Cancel" OnClick="Cancel_Click" />
    </div>

</asp:Content>
