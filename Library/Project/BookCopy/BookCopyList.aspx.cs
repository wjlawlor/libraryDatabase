using Library.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library.Project.BookCopy
{
    public partial class BookCopyList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable libraryTable = DatabaseHelper.Retrieve(@"
                    SELECT Name AS LibraryName, Id
                    FROM Library
                    ORDER BY Name;
                ");

                LibraryDropDown.DataSource = libraryTable;
                LibraryDropDown.DataBind();
            }

            DataTable query;
            if (LibraryDropDown.SelectedValue != "")
            {
                query = DatabaseHelper.Retrieve(@"
                        SELECT BookCopy.Id, Book.Title, Book.ISBN, [Library].[Name], Available
                        FROM BookCopy
                        JOIN Book ON Book.Id = BookCopy.BookId
                        JOIN [Library] ON [Library].Id = BookCopy.LibraryId
                        WHERE BookCopy.LibraryId = @LibraryId
                        ORDER BY Title, Id;
                    ",
                        new SqlParameter("@LibraryId", int.Parse(LibraryDropDown.SelectedValue))
                    );
            }
            else
            {
                query = DatabaseHelper.Retrieve(@"
                        SELECT BookCopy.Id, Book.Title, Book.ISBN, [Library].[Name], Available
                        FROM BookCopy
                        JOIN Book ON Book.Id = BookCopy.BookId
                        JOIN [Library] ON [Library].Id = BookCopy.LibraryId
                        ORDER BY Title, Id;"
                    );
            }

            BookCopys.DataSource = query.Rows;
            BookCopys.DataBind();
        }
    }
}