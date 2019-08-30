<%@ Page Title="Edit Book" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookEdit.aspx.cs" Inherits="Library.BookEdit" %>


<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

<h2>Edit Book</h2>

<div class="form-group row">
    <div class="col-xs-3 ml-3">
        <asp:Label ID="AuthorNameLabel" runat="server" AssociatedControlId="AuthorName" Text="Author: " />
        <asp:DropDownList ID="AuthorName" class="custom-select mr-sm-2" runat="server" AppendDataBoundItems="True" DataTextField="FullName" DataValueField="Id">
            <asp:ListItem Value="" Text ="Select an author..." />
        </asp:DropDownList>
    </div>
</div>
<div class="form-group row">
    <div class="col-lg-5 ml-0">
        <asp:Label ID="BookTitleLabel" runat="server" AssociatedControlID="BookTitle" Text="Title: " />
        <asp:Textbox ID="BookTitle" class="form-control" runat="server" />
    </div>
</div>
<div class="form-group row">
    <div class="col-lg-5 ml-0">
        <div>
            <asp:Label ID="IsbnLabel" runat="server" AssociatedControlID="Isbn" Text="ISBN: " />
            <asp:Textbox ID="Isbn" class="form-control" runat="server" />
        </div>
    </div>
</div>

<div>
    <asp:button id="Save" class="btn btn-success btn-lg" runat="server" text="Save" onclick="Save_Click" />
    <asp:button ID="Cancel"  class="btn btn-outline-danger btn-lg" runat="server" Text="Cancel" OnClick="Cancel_Click" />
</div>

</asp:Content>
