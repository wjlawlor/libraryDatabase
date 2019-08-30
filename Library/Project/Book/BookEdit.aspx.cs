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
    public partial class BookEdit : System.Web.UI.Page
    {

        int bookId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.QueryString["ID"], out bookId))
            {
                Response.Redirect("~/Project/Book/BookList.aspx");
            }

            if (!IsPostBack)
            {
                // Populating the dropdownlist.
                DataTable authorDropDownList = DatabaseHelper.Retrieve(@"
                    SELECT CONCAT(FirstName,' ',LastName) AS FullName, Id
                    FROM Author
                    ORDER by LastName, FirstName;
                ");

                AuthorName.DataSource = authorDropDownList;
                AuthorName.DataBind();

                // Populating other fields.
                DataTable dt = DatabaseHelper.Retrieve(@"
                    SELECT AuthorId, Title, ISBN
                    FROM Book
                    WHERE Id = @BookId
                ", new SqlParameter("@BookId", bookId));

                if (dt.Rows.Count == 1)
                {
                    AuthorName.SelectedValue = dt.Rows[0].Field<int>("AuthorId").ToString();
                    BookTitle.Text = dt.Rows[0].Field<string>("Title");
                    Isbn.Text = dt.Rows[0].Field<string>("ISBN");
                }
                else
                {
                    Response.Redirect("~/Project/Book/BookList.aspx");
                }
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            int authorId = int.Parse(AuthorName.SelectedValue);
            string title = BookTitle.Text;
            string isbn = Isbn.Text;

            DatabaseHelper.Update(@"
                UPDATE Book SET
                    AuthorId = @AuthorId,
                    Title = @Title,
                    ISBN = @ISBN
                WHERE Id = @BookId
            ",
                new SqlParameter("@AuthorId", authorId),
                new SqlParameter("@Title", title),
                new SqlParameter("@ISBN", isbn),
                new SqlParameter("@BookId", bookId));

            Response.Redirect("~/Project/Book/BookList.aspx");
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Project/Book/BookList.aspx");
        }
    }
}