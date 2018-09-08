using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    public string frontimg = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dt = objsql.GetTable("select * from achiever order by id desc");
            if (dt.Rows.Count > 0)
            {
                lvac.DataSource = dt;
                lvac.DataBind();
            }
            dt = objsql.GetTable("select * from latestnews");
            if (dt.Rows.Count > 0)
            {
                ListView1.DataSource = dt;
                ListView1.DataBind();
            }
            BindImage();
        }
    
    }
    protected void lnklogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/login.aspx");
    }

    protected void lnklogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("~/login.aspx");
    }
    public void BindImage()
    {
        DataTable dt2 = new DataTable();
        dt2 = objsql.GetTable("select * from popup");
        if (dt2.Rows.Count > 0)
        {
            ListView2.DataSource = dt2;
            ListView2.DataBind();
        }
    }
}