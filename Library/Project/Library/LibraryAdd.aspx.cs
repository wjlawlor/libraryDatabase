using Library.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library.Project.Library
{
    public partial class LibraryAdd : System.Web.UI.Page
    {
        protected void Save_Click(object sender, EventArgs e)
        {
            string name = Name.Text;
            string address = Address.Text;
            string city = City.Text;
            string state = State.Text;
            string postalCode = PostalCode.Text;

            int? id = DatabaseHelper.Insert(@"
                INSERT INTO Library (Name, AddrLine1, City, State, PostalCode)
                VALUES (@Name, @AddrLine1, @City, @State, @PostalCode);
            ",
                new SqlParameter("@Name", name),
                new SqlParameter("@AddrLine1", address),
                new SqlParameter("@City", city),
                new SqlParameter("@State", state), 
                new SqlParameter("@PostalCode", postalCode)
                );

            Response.Redirect("~/Project/Library/LibraryList.aspx");
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Project/Library/LibraryList.aspx");
        }
    }
}