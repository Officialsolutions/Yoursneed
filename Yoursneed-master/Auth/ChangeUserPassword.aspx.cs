using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_ChangeUserPassword : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }

    protected void txtpin_TextChanged(object sender, EventArgs e)
    {
        lblname.Text ="Name: "+ Common.Get(objsql.GetSingleValue("select fname from usersnew where regno='" + txtpin.Text + "'"));
        lblpass.Text ="Password :"+ Common.Get(objsql.GetSingleValue("select pass from usersnew where regno='" + txtpin.Text + "'"));
        txtpassword.Focus();
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        string serial= Common.Get(objsql.GetSingleValue("select serial from usersnew where regno='" + txtpin.Text + "'"));
        if (serial != "")
        {
            objsql.ExecuteNonQuery("update usersnew set pass='" +txtpassword.Text + "' where regno='" + txtpin.Text + "'");
         
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Updated Successfully')", true);
            txtpin.Text = "";
            txtpassword.Text = "";
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Not Found')", true);
        }
    }

}