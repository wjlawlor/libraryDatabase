using Library.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library
{
    public partial class AuthorAdd : System.Web.UI.Page
    {
        protected void Save_Click(object sender, EventArgs e)
        {
            string firstName = FirstName.Text;
            string lastName = LastName.Text;

            int? id = DatabaseHelper.Insert(@"
                INSERT INTO Author (FirstName, LastName)
                VALUES (@FirstName, @LastName);
            ",
                new SqlParameter("@FirstName", firstName),
                new SqlParameter("@LastName", lastName));

            Response.Redirect("~/Project/Author/AuthorList.aspx");
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Project/Author/AuthorList.aspx");
        }
    }
}