using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_payout : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    public int sponser = 0, proposer = 0;
    DataTable dt = new DataTable();
    public int total = 0, bal = 0;
    public string value1 = "", value2 = "";
    public static int cnt = 0,valcnt=0;
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
   
        sponser = int.Parse(Common.Get(objsql.GetSingleValue("select count(*) from usersnew where spillsregno='" + reg + "' and joined>'2018-07-17 00:00:00'")));
        proposer = int.Parse(Common.Get(objsql.GetSingleValue("select count(*) from usersnew where proposerregno='" + reg + "' and joined>'2018-07-17 00:00:00'")));
        lblstotal.Text = (Convert.ToInt32(lblsincome.Text) * Convert.ToInt32(sponser)).ToString();
        lblptotal.Text = (Convert.ToInt32(lblpincome.Text) * Convert.ToInt32(proposer)).ToString();
        lbltotal.Text = (Convert.ToInt32(lblstotal.Text) + Convert.ToInt32(lblptotal.Text)).ToString();
        lbltds.Text = ((Convert.ToInt32(lbltotal.Text) * Convert.ToInt32(10)) / Convert.ToInt32(100)).ToString();
        lblnet.Text = (Convert.ToInt32(lbltotal.Text) - Convert.ToInt32(lbltds.Text)).ToString();

        dt = objsql.GetTable("select * from payout where regno='" + reg + "' and dated >'2018-07-17 00:00:00'");
        if (dt.Rows.Count > 0)
        {
            ListView1.DataSource = dt;
            ListView1.DataBind();
        }

    }
    public string apicall(string url)
    {
        HttpWebRequest httpreq = (HttpWebRequest)WebRequest.Create(url);
        HttpWebResponse httpres = (HttpWebResponse)httpreq.GetResponse();
        StreamReader sr = new StreamReader(httpres.GetResponseStream());
        string results = sr.ReadToEnd();
        sr.Close();
        return results;
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        DataTable dt2 = new DataTable();
        dt2 = objsql.GetTable("select * from usersnew where regno='" + txtregid.Text + "'");
        if (dt2.Rows.Count > 0)
        {
            Panel1.Visible = true;
            txtreg.Text = txtregid.Text;
            bind(txtregid.Text);
            cnt = 0;
            valcnt = 0;
        }
        else
        {
            Panel1.Visible = false;

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No Data Found')", true);
        }
    }

    protected void Details(string reg)
    {
        string mobile = Common.Get(objsql.GetSingleValue("select mobile from usersnew where regno='" + reg + "'"));
        string msz = "Yours Id No. " + reg.ToString() + " Debit INR amount " + txtmnt.Text + "/- on Date " + DateTime.Now + " by YOURSNEED Business Total Bal INR " + bal + "/-. For more info visit to www.yoursneed.com";
        string apival = "http://www.sambsms.com/app/smsapi/index.php?key=459EDA8C909B85&campaign=1&routeid=7&type=text&contacts=" + mobile + "&msg=" + msz + "&senderid=YOURND";
        apicall(apival);
        cnt = 0;
        valcnt = 0;
        txtmnt.Text = "";
        txtreason.Text = "";

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
            cnt += 1;

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
        int col = (Convert.ToInt32(ListView1.Items.Count.ToString()))+1;
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            Label amt = (Label)e.Item.FindControl("lblamt");
            total += int.Parse(amt.Text);
            valcnt += 1;
        }
        bal = Convert.ToInt32(lblnet.Text) - total;
     
        if (cnt == 0)
        {

        }
        else
        {
            if (valcnt ==col)
            {
                Details(lblregno.Text);
                cnt = 0;
            }
        }
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        string id = (sender as LinkButton).CommandArgument;
        Response.Redirect("payout-edit.aspx?id=" + id);
    }
}