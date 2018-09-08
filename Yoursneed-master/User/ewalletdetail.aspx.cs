using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_ewalletdetail : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    public int sponser = 0, proposer = 0;
    public int total = 0, bal = 0;
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();

        }
    }
    protected void bind()
    {
        lblregno.Text = Session["user"].ToString();
        lblname.Text = Common.Get(objsql.GetSingleValue("select fname from usersnew where regno='" + Session["user"] + "'"));
        lblmobile.Text = Common.Get(objsql.GetSingleValue("select mobile from usersnew where regno='" + Session["user"] + "'"));
        sponser = int.Parse(Common.Get(objsql.GetSingleValue("select count(*) from usersnew where spillsregno='" + Session["user"] + "' and joined between '2017-07-01 00:00:00' and '2018-05-31 00:00:00'")));
        //sponser = int.Parse(Common.Get(objsql.GetSingleValue("select count(*) from usersnew where spillsregno='" + Session["user"] + "' and joined>'2018-07-17 00:00:00'")));
        string stotal = (Convert.ToInt32(200) * Convert.ToInt32(sponser)).ToString();
        string tds = ((Convert.ToInt32(stotal) * Convert.ToInt32(10)) / Convert.ToInt32(100)).ToString();
        string net = (Convert.ToInt32(stotal) - Convert.ToInt32(tds)).ToString();
        lbltotal.Text = net;
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (txtamount.Text != "")
        {
            if (Convert.ToInt32(txtamount.Text) > Convert.ToInt32(lbltotal.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Transfer requested amount is greater than total amount')", true);
            }
            else
            {
                objsql.ExecuteNonQuery("insert into ewalletreq(regno,reqamount,transfertype,reason,date,approvalstatus) values('" + lblregno.Text + "','" + txtamount.Text + "','" + rdotype.SelectedItem.Text + "','" + txtreason.Text + "','" + System.DateTime.Now.ToString("MM/dd/yyyy") + "','pending')");
            }
        }
        txtamount.Text = "";
        txtreason.Text = "";
    }
}