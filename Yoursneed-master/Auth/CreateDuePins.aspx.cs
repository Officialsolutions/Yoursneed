using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Transactions;

public partial class Auth_CreateDuePins : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    Common cm = new Common();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        using (TransactionScope ts = new TransactionScope())
        {
            try
            {
                int length = Convert.ToInt32(ddlpin.SelectedItem.Text);
                for (int i = 0; i < length; i++)
                {
                    objsql.ExecuteNonQuery("insert into duepins(pin,pintype,status,allotted,regno,subregno,datecreate) values('" + Guid.NewGuid().ToString().Substring(1,15) + "','" + ddlpintype.SelectedItem.Text + "','n','y','" + txtpin.Text + "','','" + DateTime.Now + "')");
                }
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
            }
            catch (Exception a)
            {
                string message = a.Message;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + message + "')", true);
                throw;
            }
            ts.Complete();
            ts.Dispose();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
            clear();
        }
    }

    protected void txtpin_TextChanged(object sender, EventArgs e)
    {
        lblname.Text = Common.Get(objsql.GetSingleValue("select fname from usersnew where regno='" + txtpin.Text + "'"));
    }
    protected void clear()
    {
        txtpin.Text = "";
    }
}