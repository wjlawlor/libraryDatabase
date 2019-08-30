<%@ Page Title="Edit Author" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AuthorEdit.aspx.cs" Inherits="Library.AuthorEdit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

<h2>Edit Author</h2>

<div class="form-group row">
    <div class="col-xs-3 ml-3">
        <asp:label id="FirstNameLabel" runat="server" associatedcontrolid="FirstName" text="First Name: " />
        <asp:textbox id="FirstName" class="form-control" runat="server" />
    </div>
</div>
<div class="form-group row">
    <div class="col-xs-3 ml-3">
        <asp:label id="LastNameLabel" runat="server" associatedcontrolid="LastName" text="Last Name: " />
        <asp:textbox id="LastName" class="form-control" runat="server" />
    </div>
</div>  

<div>
    <asp:button id="Save" class="btn btn-success" runat="server" text="Save" onclick="Save_Click" />
    <asp:button id="Cancel" class="btn btn-outline-danger" runat="server" text="Cancel" onclick="Cancel_Click" />
</div>

</asp:Content>
