using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_Unblock : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    string constring = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }

    }

  

    
    protected void bind()
    {
        dt = objsql.GetTable("select * from usersnew where active='0'");
        if (dt.Rows.Count > 0)
        {
            gvpins.DataSource = dt;
            gvpins.DataBind();
        }
    }

    protected void lnkstatus_Click(object sender, EventArgs e)
    {
        string id = (sender as LinkButton).CommandArgument;
        string Active = Common.Get(objsql.GetSingleValue("select Active from usersnew where regno='" + id + "'"));
        if (Active != "1")
        {
            string check = Common.Get(objsql.GetSingleValue("select sregno from usersnew where regno='" + id + "'"));
            if (check == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sorry Id Not UnBlock')", true);
            }
            else
            {
                string node = Common.Get(objsql.GetSingleValue("select node from usersnew where regno='" +id+ "'"));
                using (SqlConnection con = new SqlConnection(constring))
                {

                    using (SqlCommand cmd = new SqlCommand("EveryNode", con))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", check);           // sponser id
                        cmd.Parameters.AddWithValue("@node", node);                            // node
                        cmd.Parameters.AddWithValue("@checkid", check);
                        cmd.Parameters.Add("@printvalue", SqlDbType.VarChar, 30);
                        cmd.Parameters["@printvalue"].Direction = ParameterDirection.Output;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        string a = cmd.Parameters["@printvalue"].Value.ToString();

                    }

                }


                objsql.ExecuteNonQuery("update usersnew set active='1' where regno='" + id + "'");



                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User UnBlock Successfully')", true);
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User Already Unblocked')", true);

        }
        bind();
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        string Active = Common.Get(objsql.GetSingleValue("select Active from usersnew where regno='" + txtregid.Text + "'"));
        if (Active != "0")
        {
            string check = Common.Get(objsql.GetSingleValue("select sregno from usersnew where regno='" + txtregid.Text + "'"));
            if (check == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sorry Id Not Deleting')", true);
            }
            else
            {
                string node = Common.Get(objsql.GetSingleValue("select node from usersnew where regno='" + txtregid.Text + "'"));
                using (SqlConnection con = new SqlConnection(constring))
                {

                    using (SqlCommand cmd = new SqlCommand("EveryNodeMinus", con))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", check.Trim());           // sponser id
                        cmd.Parameters.AddWithValue("@node", node);                            // node
                        cmd.Parameters.AddWithValue("@checkid", check.Trim());
                        cmd.Parameters.Add("@printvalue", SqlDbType.VarChar, 30);
                        cmd.Parameters["@printvalue"].Direction = ParameterDirection.Output;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        string a = cmd.Parameters["@printvalue"].Value.ToString();

                    }

                }


                objsql.ExecuteNonQuery("update usersnew set active='0' where regno='" + txtregid.Text + "'");

                bind();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User Blocked Successfully')", true);
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User Already Blocked')", true);

        }
    }

    protected void txtregid_TextChanged(object sender, EventArgs e)
    {
        lblname.Text = bindid();

    }
    protected string bindid()
    {
        lblname.Text = Common.Get(objsql.GetSingleValue("select fname from usersnew where regno='" + txtregid.Text + "'"));
        if (lblname.Text == "")
        {
            lblname.Text = "No Data Found";
            btnsubmit.Enabled = false;
        }
        else
        {

            return lblname.Text;
            btnsubmit.Enabled = true;
        }
        return "";
    }
}