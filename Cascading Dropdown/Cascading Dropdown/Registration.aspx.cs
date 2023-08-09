using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
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

        // Clear form
        public void ClearForm()
        {
            name_Text.Text = string.Empty;
            email_Text.Text = string.Empty;
            gender_rbl.ClearSelection();
            country_ddl.ClearSelection();
            state_ddl.ClearSelection();
            state_ddl.Enabled = false;
            pass_Text.Text = string.Empty;
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

        // Validate form
        public bool ValidateForm()
        {
            if (name_Text.Text != string.Empty)
            {
                if (email_Text.Text != string.Empty)
                {
                    if (gender_rbl.SelectedValue != string.Empty)
                    {
                        if (country_ddl.SelectedValue != "0")
                        {
                            if (state_ddl.SelectedValue != "0")
                            {
                                if (pass_Text.Text != string.Empty)
                                {
                                    if (pass_Text.Text.Length >= 5 && pass_Text.Text.Length <= 8)
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        msg.Text = "Password should be 5 to 8 charracters long";
                                    }
                                }
                                else
                                {
                                    msg.Text = "Please make your password";
                                }
                            }
                            else
                            {
                                msg.Text = "Please select the state!";
                            }
                        }
                        else
                        {
                            msg.Text = "Please select your country!";
                        }
                    }
                    else
                    {
                        msg.Text = "Please select the gender!";
                    }
                }
                else
                {
                    msg.Text = "Please create your email!";
                }
            }
            else
            {
                msg.Text = "Please fill you name";
            }
            return false;
        }

        public bool CheckDuplicateRegistration()
        {
            _connection.Open();
            SqlCommand cmd = new SqlCommand("spCheckDuplicacy", _connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", email_Text.Text);
            cmd.Parameters.AddWithValue("@password", pass_Text.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            _connection.Close();
            if (dt.Rows.Count == 1)
            {
                msg.Text = "This email-ID is already registered!";
                return false;
            }
            else
            {
                return true;
            }
        }

        protected void create_btn_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                if (CheckDuplicateRegistration())
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
                    ClearForm();
                    msg.Text = "You account has been created!";
                }
            }
        }
    }
}