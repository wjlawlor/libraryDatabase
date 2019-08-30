using Library.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library.Project.Patron
{
    public partial class PatronList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = DatabaseHelper.Retrieve(@"
                    SELECT Id, LibraryCardNumber, FirstName, LastName, AddrLine1, AddrLine2, City, State, PostalCode
                    FROM Patron
                    ORDER BY Id;
                ");

                Patrons.DataSource = dt.Rows;
                Patrons.DataBind();
            }
        }
    }
}