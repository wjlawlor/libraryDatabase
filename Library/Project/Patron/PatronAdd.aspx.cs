using Library.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library.Project.Patron
{
    public partial class PatronAdd : System.Web.UI.Page
    {
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

            int? query = DatabaseHelper.Insert(@"
                INSERT INTO Patron (LibraryCardNumber, FirstName, LastName, AddrLine1, AddrLine2, City, State, PostalCode)
                VALUES (@LibraryCardNumber, @FirstName, @LastName, @AddrLine1, @AddrLine2, @City, @State, @PostalCode);
            ",
                new SqlParameter("@LibraryCardNumber", libraryCardNumber),
                new SqlParameter("@FirstName", firstName),
                new SqlParameter("@LastName", lastName),
                new SqlParameter("@AddrLine1", addressLineOne),
                new SqlParameter("@AddrLine2", (string.IsNullOrWhiteSpace(addressLineTwo) ? (object)DBNull.Value : addressLineTwo)),
                new SqlParameter("@City", city),
                new SqlParameter("@State", state),
                new SqlParameter("@PostalCode", postalCode)
                );

            Response.Redirect("~/Project/Patron/PatronList.aspx");
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Project/Patron/PatronList.aspx");
        }
    }
}