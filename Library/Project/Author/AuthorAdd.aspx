<%@ Page Title="Add Author" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AuthorAdd.aspx.cs" Inherits="Library.AuthorAdd" %>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

<h2>Add Author</h2>

<div class="form-group row">
    <div class="col-xs-3 ml-3">
        <asp:label id="FirstNameLabel" runat="server" associatedcontrolid="FirstName" text="First Name: " />
        <asp:textbox id="FirstName" class="form-control" runat="server" />
    </div>
    <div class="col-xs-3 ml-3">
        <asp:label id="LastNameLabel" runat="server" associatedcontrolid="LastName" text="Last Name: " />
        <asp:textbox id="LastName" class="form-control" runat="server" />
    </div>
</div>  

<div>
    <asp:button id="Save" class="btn btn-success btn-lg" runat="server" text="Save" onclick="Save_Click" />
    <asp:button id="Cancel" class="btn btn-outline-danger btn-lg" runat="server" text="Cancel" onclick="Cancel_Click" />
</div>

</asp:Content>
