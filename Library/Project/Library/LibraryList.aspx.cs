using Library.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library.Project.Library
{
    public partial class LibraryList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = DatabaseHelper.Retrieve(@"
                    SELECT Id, Name, AddrLine1, City, State, PostalCode
                    FROM Library
                ");

                Libraries.DataSource = dt.Rows;
                Libraries.DataBind();
            }
        }
    }
}