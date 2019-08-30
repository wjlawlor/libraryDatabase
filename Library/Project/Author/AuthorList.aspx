<%@ Page Title="Author List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AuthorList.aspx.cs" Inherits="Library.AuthorList" %>

<%@ import namespace="System.Data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">

    <h2>Authors</h2>

    <div>
        <asp:hyperlink runat="server" class="btn btn-primary mb-2" NavigateUrl="~/Project/Author/AuthorAdd.aspx">Add New Author</asp:hyperlink>
    </div>

    <asp:repeater id="Authors" runat="server" itemtype="DataRow">
        <headertemplate>
            <table class="table border table-sm">
                <thead class="thead-dark">
                    <tr>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>&nbsp;</th>
                    </tr>
                </thead>
        </headertemplate>
        <itemtemplate>
            <tbody>
                <tr>
                    <td><%# Item.Field<string>("FirstName") %></td>
                    <td><%# Item.Field<string>("LastName") %></td>
                    <td><asp:hyperlink runat="server" navigateurl='<%# string.Format("~/Project/Author/AuthorEdit.aspx?ID={0}", Item.Field<int>("Id")) %>' text="Edit" /></td>
                </tr>
            </tbody>
        </itemtemplate>
        <footertemplate>
        </table>
        </footertemplate>
    </asp:repeater>

</asp:Content>
