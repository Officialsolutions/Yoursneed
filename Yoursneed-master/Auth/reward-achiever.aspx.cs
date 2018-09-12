using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Auth_reward_achiever : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        bind();
    }
    public void bind()
    {
        DataTable dt = new DataTable();
        dt = objsql.GetTable("select p.id,p.rewads,p.regno,p.date,r.rewards,u.fname,u.mobile from tblPendingreward p join tblrewards r on r.id=p.rewads join usersnew u on u.regno=p.regno and p.payout='Pending' and u.active='1' order by p.regno desc");
        if(dt.Rows.Count>0)
        {
            gvpins.DataSource = dt;
            gvpins.DataBind();
        }
    }
}