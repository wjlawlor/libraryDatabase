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
    public partial class BookCopyEdit : System.Web.UI.Page
    {
        int bookCopyId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.QueryString["ID"], out bookCopyId))
            {
                Response.Redirect("~/Project/BookCopy/BookCopyList.aspx");
            }

            if (!IsPostBack)
            {
                // Populating first dropdownlist.
                DataTable bookTable = DatabaseHelper.Retrieve(@"
                    SELECT Title AS BookTitle, Id
                    FROM Book
                    ORDER BY Title;
                ");

                Book.DataSource = bookTable;
                Book.DataBind();

                // Populating second dropdownlist.
                DataTable libraryTable = DatabaseHelper.Retrieve(@"
                SELECT [Name] AS LibraryName, Id
                FROM [Library]
                ORDER BY [Name];
            ");

                LibraryName.DataSource = libraryTable;
                LibraryName.DataBind();

                // Populating the other field(s).
                DataTable dt = DatabaseHelper.Retrieve(@"
                    SELECT Id, BookId, LibraryId, Available
                    FROM BookCopy
                    WHERE Id = @BookId
                ", 
                    new SqlParameter("@BookId", bookCopyId)
                );

                if (dt.Rows.Count == 1)
                {
                    Book.SelectedValue = dt.Rows[0].Field<int>("BookId").ToString();
                    LibraryName.SelectedValue = dt.Rows[0].Field<int>("LibraryId").ToString();
                    // Why did I use a radio button? Lmao.
                    if (dt.Rows[0].Field<bool>("Available"))
                        { isAvailable.Checked = true;  }
                        else { isNotAvailable.Checked = true; }

                }
                else
                {
                    Response.Redirect("~/Project/BookCopy/BookCopyList.aspx");
                }
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            int bookId = int.Parse(Book.SelectedValue);
            int libraryId = int.Parse(LibraryName.SelectedValue);
            bool available;
                if (isAvailable.Checked) { available = true; }
                else { available = false; }

            DatabaseHelper.Update(@"
                UPDATE BookCopy SET
                    BookId = @BookId,
                    LibraryId = @LibraryId,
                    Available = @Available
                WHERE Id = @BookCopyId
            ",
                new SqlParameter("@BookId", bookId),
                new SqlParameter("@LibraryId", libraryId),
                new SqlParameter("@Available", available),
                new SqlParameter("@BookCopyId", bookCopyId));

            Response.Redirect("~/Project/BookCopy/BookCopyList.aspx");
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Project/BookCopy/BookCopyList.aspx");
        }
    }
}