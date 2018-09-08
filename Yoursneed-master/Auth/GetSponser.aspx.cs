using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_GetSponser : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (txtregid.Text != "")
        {
            //select* from usersnew where spillsregno = '" + txtregid.Text + "' and node = 'one'
          
            dt = objsql.GetTable("select u.regno,u.fname,u.mobile,u.joined,(select count(*) from installments where regno = u.regno) as cnt from usersnew u where u.spillsregno = '" + txtregid.Text + "' and u.node = 'one' order by u.joined");
            if (dt.Rows.Count > 0)
            {
                gvpins.DataSource = dt;
                gvpins.DataBind();
                Panel1.Visible = true;
            }
            else
            {
                Panel1.Visible = false;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No Data Found')", true);

            }
            //select* from usersnew where spillsregno = '" + txtregid.Text + "' and node = 'two'
            dt = objsql.GetTable("select u.regno,u.fname,u.mobile,u.joined,(select count(*) from installments where regno = u.regno) as cnt from usersnew u where u.spillsregno = '" + txtregid.Text + "' and u.node = 'two' order by u.joined");
            if (dt.Rows.Count > 0)
            {
                ListView1.DataSource = dt;
                ListView1.DataBind();
                Panel1.Visible = true;
            }
            else
            {
                Panel1.Visible = false;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No Data Found')", true);

            }
            txtregid.Text = "";
        }
        else
        {
            
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid RegistrationId')", true);

        }
    }
}