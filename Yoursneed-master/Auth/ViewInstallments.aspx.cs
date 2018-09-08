using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_ViewInstallments : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                bind(Request.QueryString["id"]);
                count(Request.QueryString["id"]);
            }
        }

    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        
            bind(txtregid.Text);
            count(txtregid.Text);
            lblname.Text= Common.Get(objsql.GetSingleValue("select fname from usersnew where regno='" + txtregid.Text + "'"));
            lblmobile.Text= Common.Get(objsql.GetSingleValue("select mobile from usersnew where regno='" + txtregid.Text + "'"));


    }
    protected void bind(string id)
    {
        dt = objsql.GetTable("select * from installments where regno='" + id + "' order by dated ");
        if (dt.Rows.Count > 0)
        {
            gvpins.DataSource = dt;
            gvpins.DataBind();
        }
        else
        {
            gvpins.DataSource = dt;
            gvpins.DataBind();
            lblpaid.Text = "0";
            lblpending.Text = "0";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid Registration')", true);
        }
    }
    protected void count(string id)
    {
        if (dt.Rows.Count > 0)
        {
            lblpaid.Text = Common.Get(objsql.GetSingleValue("select count(*) from installments where regno = '" + id + "'"));
            lblpending.Text = (Convert.ToInt32(lbltotal.Text) - Convert.ToInt32(lblpaid.Text)).ToString();
        }
        
    }

    protected void delete_Click(object sender, EventArgs e)
    {
        string id = (sender as LinkButton).CommandArgument;
        objsql.ExecuteNonQuery("delete from installments where serial='" + id + "'");
        if (Request.QueryString["id"] != null)
        {
            bind(Request.QueryString["id"]);
        }
        else
        {
            bind(txtregid.Text);

        }
        
    }
}