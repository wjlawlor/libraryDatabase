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
    public partial class BookCopyAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable bookTable = DatabaseHelper.Retrieve(@"
                    SELECT Title AS BookTitle, Id
                    FROM Book
                    ORDER BY Title;
                ");

            Book.DataSource = bookTable;
            Book.DataBind();

            DataTable libraryTable = DatabaseHelper.Retrieve(@"
                SELECT [Name] AS LibraryName, Id
                FROM [Library]
                ORDER BY [Name];
            ");

            LibraryName.DataSource = libraryTable;
            LibraryName.DataBind();
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            int bookId = int.Parse(Book.SelectedValue);
            int libraryId = int.Parse(LibraryName.SelectedValue);
            bool available;
                if (isAvailable.Checked){ available = true; }
                else { available = false; }

            int? query = DatabaseHelper.Insert(@"
                INSERT INTO BookCopy (BookId, LibraryId, Available)
                VALUES (@BookId, @LibraryId, @Available);
            ",
                new SqlParameter("@BookId", bookId),
                new SqlParameter("@LibraryId", libraryId),
                new SqlParameter("@Available", available));

            Response.Redirect("~/Project/BookCopy/BookCopyList.aspx");
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Project/BookCopy/BookCopyList.aspx");
        }
    }
}