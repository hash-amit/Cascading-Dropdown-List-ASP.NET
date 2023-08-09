using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Cascading_Dropdown
{
    public partial class Registration : System.Web.UI.Page
    {
        SqlConnection _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["con_string"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void country_ddl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void create_btn_Click(object sender, EventArgs e)
        {

        }
    }
}