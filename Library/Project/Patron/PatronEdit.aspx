<%@ Page Title="Edit Patron" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PatronEdit.aspx.cs" Inherits="Library.Project.Patron.PatronEdit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

<h2>Edit Patron</h2>

<div class="form-group row">
    <div class="col-lg-3">
        <asp:label id="LibraryCardNumberLabel" runat="server" associatedcontrolid="LibraryCardNumber" text="Library Card Number: " />
        <asp:textbox id="LibraryCardNumber" class="form-control" runat="server" />
    </div>
</div>
<div class="form-group row">
    <div class="col-sm-3">
        <div>
            <asp:label id="FirstNameLabel" runat="server" associatedcontrolid="FirstName" text="First Name: " />
            <asp:textbox id="FirstName" class="form-control" runat="server" />
        </div>
        </div>
        <div class="col-sm-3">
        <div>
            <asp:label id="LastNameLabel" runat="server" associatedcontrolid="LastName" text="Last Name: " />
            <asp:textbox id="LastName" class="form-control" runat="server" />
        </div>
    </div>
</div>
<div class="form-group row ml-0">
    <asp:label id="AddrLine1Label" runat="server" associatedcontrolid="AddrLine1" text="Address Line 1: " />
    <asp:textbox id="AddrLine1" class="form-control" runat="server" />
</div>

<div class="form-group row ml-0">
    <asp:label id="AddrLine2Label" runat="server" associatedcontrolid="AddrLine2" text="Address Line 2: " />
    <asp:textbox id="AddrLine2" class="form-control" runat="server" />
</div>
<div class="form-group row">
    <div class="col-auto">
        <asp:label id="CityLabel" runat="server" associatedcontrolid="City" text="City: " />
        <asp:textbox id="City" class="form-control" runat="server" />
    </div>
    <div class="col-auto">
        <asp:label id="StateLabel" runat="server" associatedcontrolid="State" text="State (##): " />
        <asp:textbox id="State" class="form-control" runat="server" />
    </div>
    <div class="col-auto">
        <asp:label id="PostalCodeLabel" runat="server" associatedcontrolid="PostalCode" text="Zip Code: " />
        <asp:textbox id="PostalCode" class="form-control" runat="server" />
    </div>
</div>
<div>
    <asp:button id="Save" class="btn btn-success btn-lg" runat="server" text="Save" onclick="Save_Click" />
    <asp:button id="Cancel" class="btn btn-outline-danger btn-lg" runat="server" text="Cancel" onclick="Cancel_Click" />
</div>

</asp:Content>
