using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_Payrewards : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblid.Text = Request.QueryString["id"];
            lblname.Text = Common.Get(objsql.GetSingleValue("select fname from usersnew where regno='" + lblid.Text + "'"));
            bind(Request.QueryString["id"].ToString());
        }
    }
    protected void bind(string reg)
    {
        dt = objsql.GetTable("select * from legs where regno='" + reg + "'");
        if (dt.Rows.Count > 0)
        {
            lblleft.Text = dt.Rows[0]["leftleg"].ToString();
            lblright.Text = dt.Rows[0]["rightleg"].ToString();
        }
        dt = objsql.GetTable("select * from tblrewards");
        if (dt.Rows.Count > 0)
        {
            gvpins.DataSource = dt;
            gvpins.DataBind();
        }

    }



    protected void gvpins_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            Label pins = (Label)e.Item.FindControl("lblpins");
            LinkButton level = (LinkButton)e.Item.FindControl("lnklevel");
            LinkButton pay = (LinkButton)e.Item.FindControl("lnkpay");
            HiddenField id = (HiddenField)e.Item.FindControl("hfid");
            LinkButton Salary = (LinkButton)e.Item.FindControl("lnkSalary");

            if (Convert.ToInt32(pins.Text) <= Convert.ToInt32(lblleft.Text) && Convert.ToInt32(pins.Text) <= Convert.ToInt32(lblright.Text))
            {
                level.Text = "Achieved";

            }
            else
            {
                level.CssClass = "text-danger";
            }
            string check = Common.Get(objsql.GetSingleValue("select * from tblpayreward where regno='" + Request.QueryString["id"] + "' and rewads='" + id.Value + "'"));
            if (check == "")
            {
                pay.Text = "Pay";
                if (level.Text == "Achieved")
                {
                    pay.Enabled = true;
                    pay.CssClass = "label label-danger";
                    Salary.Visible = true;
                }
                else
                {
                    pay.Enabled = false;
                    pay.CssClass = "label label-primary";
                    pay.Text = "Pending";
                }
               
            }
            else
            {
                pay.Text = "Paid";
                pay.Enabled = false;
                pay.CssClass = "label label-success";
                Salary.Visible = false;
            }

        }
    }

    protected void lnkpay_Click(object sender, EventArgs e)
    {
        string id = (sender as LinkButton).CommandArgument;
        objsql.ExecuteNonQuery("insert into tblpayreward(regno,rewads,payout,date) values('" + Request.QueryString["id"] + "','" + id + "','Pay','" + System.DateTime.Now + "')");
        bind(Request.QueryString["id"].ToString());
    }

    protected void lnkSalary_Click(object sender, EventArgs e)
    {
        string id = (sender as LinkButton).CommandArgument;
        objsql.ExecuteNonQuery("insert into tblrewardsalary(regno,rewadid,salary,date) values('" + Request.QueryString["id"] + "','" + id + "','salary paid','" + System.DateTime.Now + "')");
    }
}