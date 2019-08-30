using Library.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library
{
    public partial class BookAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
     
            DataTable dt = DatabaseHelper.Retrieve(@"
                    SELECT CONCAT(FirstName,' ',LastName) AS FullName, Id
                    FROM Author
                    ORDER by LastName, FirstName;
                ");

            AuthorName.DataSource = dt;
            AuthorName.DataBind();
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            int id = int.Parse(AuthorName.SelectedValue);
            string title = BookTitle.Text;
            string isbn = Isbn.Text;

            int? query = DatabaseHelper.Insert(@"
                INSERT INTO Book (AuthorId, Title, ISBN)
                VALUES (@AuthorId, @Title, @ISBN);
            ",
                new SqlParameter("@AuthorId", id),
                new SqlParameter("@Title", title),
                new SqlParameter("@ISBN", isbn));

            Response.Redirect("~/Project/Book/BookList.aspx");
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Project/Book/BookList.aspx");
        }
    }
}