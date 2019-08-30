<%@ Page Title="Librarian List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LibrarianList.aspx.cs" Inherits="Library.Project.Librarian.LibrarianList" %>

<%@ import namespace="System.Data" %>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

    <h2>Librarians</h2>

    <div>
        <asp:hyperlink runat="server" navigateurl="~/Default.aspx">Homepage</asp:hyperlink>
    </div>

    <div>
        <asp:hyperlink runat="server" navigateurl="~/Project/Librarian/LibraianAdd.aspx">Add New Librarian</asp:hyperlink>
    </div>

    <asp:repeater id="Librarians" runat="server" itemtype="DataRow">
        <headertemplate>
            <table>
                <tr>
                    <th>EmployeeId</th>
                    <th>Library</th>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>Address</th>
                    <th>&nbsp;</th>
                    <th>City</th>
                    <th>State</th>
                    <th>Postal Code</th>
                </tr>
        </headertemplate>
        <itemtemplate>
            <tr>
                <td><%# Item.Field<int>("Id") %></td>
                <td><%# Item.Field<string>("Name") %></td>
                <td><%# Item.Field<string>("FirstName") %></td>
                <td><%# Item.Field<string>("LastName") %></td>
                <td><%# Item.Field<string>("AddrLine1") %></td>
                <td><%# Item.Field<string>("AddrLine2") %></td>
                <td><%# Item.Field<string>("City") %></td>
                <td><%# Item.Field<string>("State") %></td>
                <td><%# Item.Field<string>("PostalCode") %></td>
                <td><asp:hyperlink runat="server" navigateurl='<%# string.Format("~/Project/Librarian/LibrarianEdit.aspx?ID={0}", Item.Field<int>("Id")) %>' text="Edit" /></td>
            </tr>
        </itemtemplate>
        <footertemplate>
            </table>
        </footertemplate>
    </asp:repeater>

</asp:Content>
