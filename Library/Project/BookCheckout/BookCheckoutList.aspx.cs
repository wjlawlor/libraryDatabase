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
    public partial class BookCheckoutList : System.Web.UI.Page
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

                //BindCheckoutsList();
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            BindCheckoutsList();
        }

        private void BindCheckoutsList()
        {
            DataTable query;
            if (LibraryDropDown.SelectedValue != "")
            {
                query = DatabaseHelper.Retrieve(@"
                        SELECT Checkouts.Id, [Library].[Name], Book.Title, Book.ISBN, CONCAT(Patron.FirstName,' ',Patron.LastName) AS LentTo, 
	                        CONCAT(Librarian.FirstName,' ',Librarian.LastName) AS FromLibrarian, CheckoutDate, ReturnDate, DueDate
                        FROM Checkouts
                        JOIN BookCopy ON Checkouts.BookCopyId = BookCopy.Id
                        JOIN Book ON  BookCopy.BookId = Book.Id
                        JOIN [Library] ON [Library].Id = BookCopy.LibraryId
                        JOIN Patron ON Checkouts.PatronId = Patron.Id
                        JOIN Librarian ON Checkouts.LibrarianId = Librarian.Id
                        WHERE Library.Id = @LibraryId;

                    ",
                        new SqlParameter("@LibraryId", int.Parse(LibraryDropDown.SelectedValue))
                    );
            }
            else
            {
                query = DatabaseHelper.Retrieve(@"
                        SELECT Checkouts.Id, [Library].[Name], Book.Title, Book.ISBN, CONCAT(Patron.FirstName,' ',Patron.LastName) AS LentTo, 
	                        CONCAT(Librarian.FirstName,' ',Librarian.LastName) AS FromLibrarian, CheckoutDate, ReturnDate, DueDate
                        FROM Checkouts
                        JOIN BookCopy ON Checkouts.BookCopyId = BookCopy.Id
                        JOIN Book ON  BookCopy.BookId = Book.Id
                        JOIN [Library] ON [Library].Id = BookCopy.LibraryId
                        JOIN Patron ON Checkouts.PatronId = Patron.Id
                        JOIN Librarian ON Checkouts.LibrarianId = Librarian.Id;
                    ");
            }

            CheckoutIDs.DataSource = query.Rows;
            CheckoutIDs.DataBind();
        }

        protected void Returned_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int checkoutId = int.Parse(button.CommandArgument);

            DatabaseHelper.Update(@"
                UPDATE Checkouts SET
                    ReturnDate = @ReturnDate
                WHERE Id = @CheckoutId
            ",
                new SqlParameter("@ReturnDate", DateTime.Today),
                new SqlParameter("@CheckoutId", checkoutId)
            );

            //BindCheckoutsList();
        }
    }
}
