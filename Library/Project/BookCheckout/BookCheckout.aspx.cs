using Library.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library.Project.BookCheckout
{
    public partial class BookCheckout : System.Web.UI.Page
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
                DataTable patronTable = DatabaseHelper.Retrieve(@"
                    SELECT CONCAT(FirstName,' ',LastName) AS PatronName, Id
                    FROM Patron
                    ORDER BY LastName;
                ");

                PatronDropDown.DataSource = patronTable;
                PatronDropDown.DataBind();

                // Populating second dropdownlist.
                DataTable librarianTable = DatabaseHelper.Retrieve(@"
                SELECT CONCAT(FirstName,' ',LastName) AS LibrarianName, Id
                FROM Librarian
                ORDER BY LastName;
            ");

                LibrarianDropDown.DataSource = librarianTable;
                LibrarianDropDown.DataBind();

                // Populating the other field(s).
                DataTable dt = DatabaseHelper.Retrieve(@"
                    SELECT Book.Title
                    FROM BookCopy
                    JOIN Book ON BookCopy.BookId = Book.Id
                    WHERE BookCopy.Id = @BookId
                ", 
                    new SqlParameter("@BookId", bookCopyId)
                );

                

                if (dt.Rows.Count == 1)
                {
                    BookCopy.Text = dt.Rows[0].Field<string>("Title").ToString();
                }
                else
                {
                    Response.Redirect("~/Project/BookCopy/BookCopyList.aspx");
                }
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            int patronId = int.Parse(PatronDropDown.SelectedValue);
            int librarianId = int.Parse(LibrarianDropDown.SelectedValue);
            DateTime checkoutDate = DateTime.Now;
            DateTime dueDate = DateTime.Now.AddDays(14);

            DatabaseHelper.Insert(@"
                INSERT INTO Checkouts (BookCopyId, PatronId, LibrarianId, CheckoutDate, DueDate)
                VALUES (@BookCopyId, @PatronId, @LibrarianId, @CheckoutDate, @DueDate)
            ",
                new SqlParameter("@BookCopyId", bookCopyId),
                new SqlParameter("@PatronId", patronId),
                new SqlParameter("@LibrarianId", librarianId),
                new SqlParameter("@CheckoutDate", checkoutDate),
                new SqlParameter("@DueDate", dueDate)
            );

            Response.Redirect("~/Project/BookCopy/BookCopyList.aspx");
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Project/BookCopy/BookCopyList.aspx");
        }
    }
}