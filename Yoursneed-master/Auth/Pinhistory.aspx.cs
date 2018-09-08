using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_Pinhistory : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    DataTable dt2 = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                bindNew(Request.QueryString["id"]);
                bindAllow(Request.QueryString["id"]);
            }
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {

        bindNew(txtregid.Text);
        bindAllow(txtregid.Text);
        lblname.Text = Common.Get(objsql.GetSingleValue("select fname from usersnew where regno='" + txtregid.Text + "'"));
        lblmobile.Text = Common.Get(objsql.GetSingleValue("select mobile from usersnew where regno='" + txtregid.Text + "'"));

    }
    protected void bindNew(string id)
    {
        dt = objsql.GetTable("select Pins.regno,Pins.Pin,Pins.pintype,Pins.status,Pins.datecreate,usersnew.fname,usersnew.mobile from Pins Inner Join usersnew on Pins.regno=usersnew.regno and Pins.status='n' and Pins.regno='" + id + "' order by Pins.datecreate");
        if (dt.Rows.Count > 0)
        {
            gvpinsnew.DataSource = dt;
            gvpinsnew.DataBind();
        }
        else
        {
            gvpinsnew.DataSource = dt;
            gvpinsnew.DataBind();
        }
    }
    protected void bindAllow(string id)
    {
        dt2 = objsql.GetTable("select Pins.regno,Pins.Pin,Pins.pintype,Pins.status,Pins.datecreate,usersnew.fname,usersnew.mobile from Pins Inner Join usersnew on Pins.regno=usersnew.regno and Pins.status='y' and Pins.regno='" + id + "' order by Pins.datecreate");
        if (dt2.Rows.Count > 0)
        {
            gvpinsallow.DataSource = dt2;
            gvpinsallow.DataBind();
        }
        else
        {
            gvpinsallow.DataSource = dt2;
            gvpinsallow.DataBind();
        }
    }
}