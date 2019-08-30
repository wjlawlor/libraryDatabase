using Library.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library.Project.Library
{
    public partial class LibraryEdit : System.Web.UI.Page
    {
        int libraryId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.QueryString["ID"], out libraryId))
            {
                Response.Redirect("~/Project/Library/LibraryList.aspx");
            }

            if (!IsPostBack)
            {
                DataTable dt = DatabaseHelper.Retrieve(@"
                    SELECT Name, AddrLine1, City, State, PostalCode
                    FROM Library
                    WHERE Id = @LibraryId
                ", new SqlParameter("@LibraryId", libraryId));

                if (dt.Rows.Count == 1)
                {
                    Name.Text = dt.Rows[0].Field<string>("Name");
                    Address.Text = dt.Rows[0].Field<string>("AddrLine1");
                    City.Text = dt.Rows[0].Field<string>("City");
                    State.Text = dt.Rows[0].Field<string>("State");
                    PostalCode.Text = dt.Rows[0].Field<string>("PostalCode");
                }
                else
                {
                    Response.Redirect("~/Project/Library/LibraryList.aspx");
                }
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            string name = Name.Text;
            string address = Address.Text;
            string city = City.Text;
            string state = State.Text;
            string postalCode = PostalCode.Text;

            DatabaseHelper.Update(@"
                UPDATE Library SET
                    Name = @Name,
                    AddrLine1 = @Address,
                    City = @City,
                    State = @State,
                    PostalCode = @PostalCode
                WHERE Id = @LibraryId
            ",
                new SqlParameter("@Name", name),
                new SqlParameter("@Address", address),
                new SqlParameter("@City", city),
                new SqlParameter("@State", state),
                new SqlParameter("@PostalCode", postalCode),
                new SqlParameter("@LibraryId", libraryId));

            Response.Redirect("~/Project/Library/LibraryList.aspx");
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Project/Library/LibraryList.aspx");
        }
    }
}