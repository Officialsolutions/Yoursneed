using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_TreeViewer : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                binddiscription();
            }
        }

    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            objsql.ExecuteNonQuery("update tblviewer set regno='" + txtregid.Text + "' where id='" + Request.QueryString["id"] + "'");
        }
        else
        {
            objsql.ExecuteNonQuery("insert into tblviewer(regno) values('" + txtregid.Text + "')");
        }
        Response.Redirect("ViewTreeViewer.aspx");
    }
    protected void binddiscription()
    {
        DataTable ddt = new DataTable();
        ddt = objsql.GetTable("select * from tblviewer where id='" + Request.QueryString["id"] + "'");
        if(ddt.Rows.Count>0)
        {
            txtregid.Text = ddt.Rows[0]["regno"].ToString();
        }
    }

    protected void txtregid_TextChanged(object sender, EventArgs e)
    {
        lblname.Text = bind();

    }
    protected string bind()
    {
        lblname.Text = Common.Get(objsql.GetSingleValue("select fname from usersnew where regno='" + txtregid.Text + "'"));
        if (lblname.Text == "")
        {
            lblname.Text = "No Data Found";
            btnsubmit.Enabled = false;
        }
        else
        {

            return lblname.Text;
            btnsubmit.Enabled = true;
        }
        return "";
    }
}