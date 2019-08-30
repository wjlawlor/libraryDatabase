using Library.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library.Project.Librarian
{
    public partial class LibrarianList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = DatabaseHelper.Retrieve(@"
                    SELECT Librarian.Id, Library.Name, FirstName, LastName, Librarian.AddrLine1, AddrLine2, Librarian.City, Librarian.State, Librarian.PostalCode
                    FROM Librarian
                    JOIN Library ON Librarian.LibraryId = Library.Id
                    ORDER BY Id;
                ");

                Librarians.DataSource = dt.Rows;
                Librarians.DataBind();
            }
        }
    }
}