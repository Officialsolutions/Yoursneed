using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_LastJoining : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string date = System.DateTime.Now.ToString("MM/dd/yyyy");
            lblid.Text = Common.Get(objsql.GetSingleValue("select max(regno) from usersnew"));
            string date2= Common.Get(objsql.GetSingleValue("select max(joined) from usersnew"));
            lbldate.Text = Convert.ToDateTime(date2).ToString("dd/MM/yyyy");
            bind(date);
        }
    }


    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        string check = ddlyear.SelectedItem.Text + "/" + ddlmonth.SelectedItem.Text + "/" + ddlday.SelectedItem.Text;
        dt = objsql.GetTable("select * from usersnew where joined='" +check+ "' order by regno");
        if (dt.Rows.Count > 0)
        {
            gvpins.DataSource = dt;
            gvpins.DataBind();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sorry No Data Found')", true);
        }
    }
    protected void bind(string Date)
    {
        dt = objsql.GetTable("select * from usersnew where joined='" + Date + "' order by regno");
        if (dt.Rows.Count > 0)
        {
            gvpins.DataSource = dt;
            gvpins.DataBind();
        }
    }
   
}