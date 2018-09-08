using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Main : System.Web.UI.MasterPage
{
    SQLHelper objsql = new SQLHelper();
    public string frontimg = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //BindImage();
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
    //public void BindImage()
    //{
    //    DataTable dt = new DataTable();
    //    dt = objsql.GetTable("select * from popup");
    //    if (dt.Rows.Count > 0)
    //    {
    //        frontimg= dt.Rows[0]["image"].ToString();
    //    }
    //}
}
