using Library.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library.Project.Patron
{
    public partial class PatronEdit : System.Web.UI.Page
    {
        int patronId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.QueryString["ID"], out patronId))
            {
                Response.Redirect("~/Project/Patron/PatronList.aspx");
            }

            if (!IsPostBack)
            {
                DataTable dt = DatabaseHelper.Retrieve(@"
                    SELECT LibraryCardNumber, FirstName, LastName, AddrLine1, AddrLine2, City, State, PostalCode
                    FROM Patron
                    WHERE Id = @PatronId
                ", new SqlParameter("@PatronId", patronId));

                if (dt.Rows.Count == 1)
                {
                    LibraryCardNumber.Text = dt.Rows[0].Field<string>("LibraryCardNumber");
                    FirstName.Text = dt.Rows[0].Field<string>("FirstName");
                    LastName.Text = dt.Rows[0].Field<string>("LastName");
                    AddrLine1.Text = dt.Rows[0].Field<string>("AddrLine1");
                    AddrLine2.Text = dt.Rows[0].Field<string>("AddrLine2");
                    City.Text = dt.Rows[0].Field<string>("City");
                    State.Text = dt.Rows[0].Field<string>("State");
                    PostalCode.Text = dt.Rows[0].Field<string>("PostalCode");
                }
                else
                {
                    Response.Redirect("~/Project/Patron/PatronsList.aspx");
                }
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            string libraryCardNumber = LibraryCardNumber.Text;
            string firstName = FirstName.Text;
            string lastName = LastName.Text;
            string addressLineOne = AddrLine1.Text;
            string addressLineTwo = AddrLine2.Text;
            string city = City.Text;
            string state = State.Text;
            string postalCode = PostalCode.Text;

            DatabaseHelper.Update(@"
                UPDATE Patron SET
                    LibraryCardNumber = @LibraryCardNumber,
                    FirstName = @FirstName,
                    LastName = @LastName,
                    AddrLine1 = @AddrLine1,
                    AddrLine2 = @AddrLine2,
                    City = @City,
                    State = @State,
                    PostalCode = @PostalCode
                WHERE Id = @PatronId
            ",
                new SqlParameter("@LibraryCardNumber", libraryCardNumber),
                new SqlParameter("@FirstName", firstName),
                new SqlParameter("@LastName", lastName),
                new SqlParameter("@AddrLine1", addressLineOne),
                new SqlParameter("@AddrLine2", (string.IsNullOrWhiteSpace(addressLineTwo) ? (object)DBNull.Value : addressLineTwo)),
                new SqlParameter("@City", city),
                new SqlParameter("@State", state),
                new SqlParameter("@PostalCode", postalCode),
                new SqlParameter("@PatronId", patronId)
            );

            Response.Redirect("~/Project/Patron/PatronList.aspx");
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Project/Patron/PatronList.aspx");
        }
    }
}