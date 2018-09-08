using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_Reward_Details : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                bind(Request.QueryString["id"].ToString());
            }
        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            objsql.ExecuteNonQuery("update tblrewards set pins='" + txtpair.Text + "',rewards='" + txtrewards.Text + "' where id='" + Request.QueryString["id"] + "'");
        }
        else
        {
            objsql.ExecuteNonQuery("insert into tblrewards(pins,rewards) values('" + txtpair.Text + "','" + txtrewards.Text + "')");
          
        }
        Response.Redirect("view-rewards.aspx");
    }
    protected void bind(string id)
    {
        DataTable dt = new DataTable();
        dt = objsql.GetTable("select * from tblrewards where id='" + id + "'");
        if (dt.Rows.Count > 0)
        {
            txtpair.Text = dt.Rows[0]["pins"].ToString();
            txtrewards.Text = dt.Rows[0]["rewards"].ToString();
        }
    }
}