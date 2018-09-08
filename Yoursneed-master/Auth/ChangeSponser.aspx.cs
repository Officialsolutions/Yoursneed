using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_ChangeSponser : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

   

    protected void txtsponser_TextChanged(object sender, EventArgs e)
    {
        lblsponser.Text = Common.Get(objsql.GetSingleValue("select fname from usersnew where regno='" + txtsponser.Text + "'"));
        if (lblsponser.Text == "")
        {
            lblsponser.Text = "No Data Found";
            btnsubmit.Enabled = false;
        }
        else
        {
           
            btnsubmit.Enabled = true;
        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        objsql.ExecuteNonQuery("update usersnew set spillsregno='" + txtsponser.Text.Trim() + "' where regno='" + txtregid.Text + "'");
        txtregid.Text = "";
        txtsponser.Text = "";
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Change Sponser Successfully')", true);
    }

    protected void txtregid_TextChanged(object sender, EventArgs e)
    {
        lblname.Text = Common.Get(objsql.GetSingleValue("select spillsregno from usersnew where regno='" + txtregid.Text + "'"));
        if (lblname.Text == "")
        {
            lblname.Text = "No Data Found";
            btnsubmit.Enabled = false;
        }
        else
        {
            lblna.Text = Common.Get(objsql.GetSingleValue("select fname from usersnew where regno='" + lblname.Text + "'"));
            btnsubmit.Enabled = true;
        }
    }
}