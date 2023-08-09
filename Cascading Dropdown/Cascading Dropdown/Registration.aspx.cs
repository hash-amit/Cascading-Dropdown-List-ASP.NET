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
                BindCountry();
                state_ddl.Enabled = false;
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

        // Bind Country
        public void BindCountry()
        {
            _connection.Open();
            SqlCommand cmd = new SqlCommand("spBindCountry", _connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            _connection.Close();
            country_ddl.DataValueField = "Country ID";
            country_ddl.DataTextField = "Country Name";
            country_ddl.DataSource = dt;
            country_ddl.DataBind();
            country_ddl.Items.Insert(0, new ListItem("Select Country", "0"));
        }

        // Bind state
        public void BindState()
        {
            _connection.Open();
            SqlCommand cmd = new SqlCommand("spBindState", _connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@country_id", country_ddl.SelectedValue);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            _connection.Close();
            state_ddl.DataValueField = "State ID";
            state_ddl.DataTextField = "State Name";
            state_ddl.DataSource = dt;
            state_ddl.DataBind();
            state_ddl.Items.Insert(0, new ListItem("Select state", "0"));
        }

        protected void country_ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (country_ddl.SelectedIndex != 0)
            {
                state_ddl.Enabled = true;
                BindState();
            }
            else 
            { 
                state_ddl.Enabled = false; 
            }
        }

        protected void create_btn_Click(object sender, EventArgs e)
        {
            _connection.Open();
            SqlCommand cmd = new SqlCommand("spInsertRecord", _connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", name_Text.Text);
            cmd.Parameters.AddWithValue("@email", email_Text.Text);
            cmd.Parameters.AddWithValue("@gender", gender_rbl.SelectedValue);
            cmd.Parameters.AddWithValue("@country", country_ddl.SelectedValue);
            cmd.Parameters.AddWithValue("@state", state_ddl.SelectedValue);
            cmd.Parameters.AddWithValue("@password", pass_Text.Text);
            cmd.ExecuteNonQuery();
            _connection.Close();
        }
    }
}