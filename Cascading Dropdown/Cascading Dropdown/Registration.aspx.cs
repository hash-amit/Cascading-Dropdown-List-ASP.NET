using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
            if (!IsPostBack)
            {
                BindGender();
            }
        }

        // Bind gender
        public void BindGender()
        {
            _connection.Open();
            SqlCommand cmd = new SqlCommand("spBindGender", _connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            _connection.Close();
            gender_rbl.DataValueField = "Gender ID";
            gender_rbl.DataTextField = "GEN";
            gender_rbl.DataSource = dt;
            gender_rbl.DataBind();
        }

        protected void country_ddl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void create_btn_Click(object sender, EventArgs e)
        {

        }
    }
}