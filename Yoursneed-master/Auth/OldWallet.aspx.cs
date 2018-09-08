using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_OldWallet : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    public int sponser = 0, proposer = 0;
    DataTable dt = new DataTable();
    public int total = 0, bal = 0;
    public string value1 = "", value2 = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


        }
    }
    protected void bind(string reg)
    {
        lblregno.Text = reg.ToString();
        lblname.Text = Common.Get(objsql.GetSingleValue("select fname from usersnew where regno='" + reg + "'"));
        sponser = int.Parse(Common.Get(objsql.GetSingleValue("select count(*) from usersnew where spillsregno='" + reg + "' and joined between '2017-07-01 00:00:00' and '2018-05-31 00:00:00'")));
        proposer = int.Parse(Common.Get(objsql.GetSingleValue("select count(*) from usersnew where proposerregno='" + reg + "' and joined between '2017-07-01 00:00:00' and '2018-05-31 00:00:00'")));
        lblstotal.Text = (Convert.ToInt32(lblsincome.Text) * Convert.ToInt32(sponser)).ToString();
        lblptotal.Text = (Convert.ToInt32(lblpincome.Text) * Convert.ToInt32(proposer)).ToString();
        lbltotal.Text = (Convert.ToInt32(lblstotal.Text) + Convert.ToInt32(lblptotal.Text)).ToString();
        lbltds.Text = ((Convert.ToInt32(lbltotal.Text) * Convert.ToInt32(10)) / Convert.ToInt32(100)).ToString();
        lblnet.Text = (Convert.ToInt32(lbltotal.Text) - Convert.ToInt32(lbltds.Text)).ToString();
        dt = objsql.GetTable("select * from payout where regno='" + reg + "' and dated between '2017-07-01 00:00:00' and '2018-05-31 00:00:00'");
        if (dt.Rows.Count > 0)
        {
            ListView1.DataSource = dt;
            ListView1.DataBind();
        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        DataTable dt2 = new DataTable();
        dt2 = objsql.GetTable("select * from usersnew where regno='" + txtregid.Text + "' ");
        if (dt2.Rows.Count > 0)
        {
            Panel1.Visible = true;
            txtreg.Text = txtregid.Text;
            bind(txtregid.Text);

        }
        else
        {
            Panel1.Visible = false;

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No Data Found')", true);

        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string id = (sender as LinkButton).CommandArgument;
        objsql.ExecuteNonQuery("delete from payout where serial='" + id + "'");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Delete Successfully')", true);
        bind(txtregid.Text);

    }

    protected void btnpaid_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(txtmnt.Text) >= bal)
        {
            if (RadioButtonList1.SelectedItem.Text == "Cash")
            {
                value1 = RadioButtonList1.SelectedItem.Text;
            }
            else
            {
                value2 = RadioButtonList1.SelectedItem.Text;
            }
            objsql.ExecuteNonQuery("insert into payout(regno,dated,amount,cash,chqno,remarks) values('" + txtregid.Text + "','" + System.DateTime.Now + "','" + txtmnt.Text + "','" + value1 + "','" + value2 + "','" + txtreason.Text + "')");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Pay Sucessfully')", true);

        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Low Balance')", true);
        }
        bind(txtregid.Text);
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

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        string id = (sender as LinkButton).CommandArgument;
        Response.Redirect("payout-edit.aspx?id=" + id);
    }
}