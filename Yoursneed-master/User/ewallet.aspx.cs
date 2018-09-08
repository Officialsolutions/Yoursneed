using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_ewallet : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    public int sponser = 0, proposer = 0;
    public int total = 0, bal = 0;
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            bind();

        }
    }
    protected void bind()
    {
        lblregno.Text = Session["user"].ToString();
        lblname.Text = Common.Get(objsql.GetSingleValue("select fname from usersnew where regno='" + Session["user"] + "'"));
        sponser =int.Parse(Common.Get(objsql.GetSingleValue("select count(*) from usersnew where spillsregno='" + Session["user"] + "' and joined>'2018-07-17 00:00:00'")));
        proposer = int.Parse(Common.Get(objsql.GetSingleValue("select count(*) from usersnew where proposerregno='" + Session["user"] + "' and joined>'2018-07-17 00:00:00'")));
        lblstotal.Text = (Convert.ToInt32(lblsincome.Text) * Convert.ToInt32(sponser)).ToString();
        lblptotal.Text = (Convert.ToInt32(lblpincome.Text) * Convert.ToInt32(proposer)).ToString();
        lbltotal.Text = (Convert.ToInt32(lblstotal.Text) + Convert.ToInt32(lblptotal.Text)).ToString();
        lbltds.Text = ((Convert.ToInt32(lbltotal.Text) * Convert.ToInt32(10)) / Convert.ToInt32(100)).ToString();
        lblnet.Text = (Convert.ToInt32(lbltotal.Text) - Convert.ToInt32(lbltds.Text)).ToString();
        dt = objsql.GetTable("select * from payout where regno='" + Session["user"] + "' and dated>'2018-07-17 00:00:00'");
        if (dt.Rows.Count > 0)
        {
            ListView1.DataSource = dt;
            ListView1.DataBind();
        }
        else
        {
            bal = Convert.ToInt32(lblnet.Text);
        }
    }

    protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            Label amt = (Label)e.Item.FindControl("lblamt");
            total += int.Parse(amt.Text);

        }
        bal = Convert.ToInt32(lblnet.Text) - total;
    }
}