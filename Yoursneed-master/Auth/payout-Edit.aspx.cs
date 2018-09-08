using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_payout_Edit : System.Web.UI.Page
{ SQLHelper objsql = new SQLHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                txtregid.Text = Common.Get(objsql.GetSingleValue("select remarks from  payout where serial='" + Request.QueryString["id"] + "'"));
            }
        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        objsql.ExecuteNonQuery("update payout set remarks='" + txtregid.Text + "' where serial='" + Request.QueryString["id"] + "'");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('update sucessfully')", true);
    }
}