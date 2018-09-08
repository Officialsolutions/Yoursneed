using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_Deleteid : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    string constring = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }

    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        string check = Common.Get(objsql.GetSingleValue("select regno from usersnew where sregno='" + txtregid.Text + "'"));
        if(check!="")
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
                    cmd.Parameters.AddWithValue("@id", txtregid.Text.Trim());           // sponser id
                    cmd.Parameters.AddWithValue("@node", node);                            // node
                    cmd.Parameters.AddWithValue("@checkid", txtregid.Text.Trim());
                    cmd.Parameters.Add("@printvalue", SqlDbType.VarChar, 30);
                    cmd.Parameters["@printvalue"].Direction = ParameterDirection.Output;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    string a = cmd.Parameters["@printvalue"].Value.ToString();

                }

            }
            string sregno = Common.Get(objsql.GetSingleValue("select spillsregno from usersnew where regno='" + txtregid.Text + "'"));
            if (sregno != "")
            {
                int count,minus=0;


                if (node == "one")
                {
                    count = Convert.ToInt32(objsql.GetSingleValue("select leftdirect from legs where regno='" + sregno + "'"));
                    if (count > 0)
                    {
                        minus = count - 1;
                        objsql.ExecuteNonQuery("update legs set leftdirect='" + minus + "' where regno='" + sregno + "'");
                    }

                   
                }
                else
                {
                    count = Convert.ToInt32(objsql.GetSingleValue("select rightdirect from legs where regno='" + sregno + "'"));
                    if (count > 0)
                    {
                        minus = count - 1;
                        objsql.ExecuteNonQuery("update legs set rightdirect='" + minus + "' where regno='" + sregno + "'");
                    }
                }
                
            }

            objsql.ExecuteNonQuery("delete from usersnew where regno='" + txtregid.Text + "'");
            objsql.ExecuteNonQuery("delete from legs where regno='" + txtregid.Text + "'");

            
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User Deleted Successfully')", true);
        }
    }

    protected void txtregid_TextChanged(object sender, EventArgs e)
    {
        lblname.Text = bind();

    }
    protected string bind()
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