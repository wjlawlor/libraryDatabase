<%@ Page Title="Edit Library" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LibraryEdit.aspx.cs" Inherits="Library.Project.Library.LibraryEdit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

    <h2>Edit Library</h2>

    <fieldset>
        <div>
            <asp:label id="NameLabel" runat="server" associatedcontrolid="Name" text="Library Name: " />
            <asp:textbox id="Name" runat="server" />
        </div>
        <div>
            <asp:label id="AddressLabel" runat="server" associatedcontrolid="Address" text="Address: " />
            <asp:textbox id="Address" runat="server" />
        </div>
        <div>
            <asp:label id="CityLabel" runat="server" associatedcontrolid="City" text="City: " />
            <asp:textbox id="City" runat="server" />
        </div>
        <div>
            <asp:label id="StateLabel" runat="server" associatedcontrolid="State" text="State (##): " />
            <asp:textbox id="State" runat="server" />
        </div>
        <div>
            <asp:label id="PostalCodeLabel" runat="server" associatedcontrolid="PostalCode" text="Zip Code: " />
            <asp:textbox id="PostalCode" runat="server" />
        </div>
    </fieldset>

    <div>
        <asp:button id="Save" runat="server" text="Save" onclick="Save_Click" />
        <asp:button id="Cancel" runat="server" text="Cancel" onclick="Cancel_Click" />
    </div>
    
</asp:Content>
