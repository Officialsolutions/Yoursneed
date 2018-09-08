using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Transactions;
using System.Net;
using System.IO;

public partial class Auth_AddInstallments : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    public static string date = "";
    private static TimeZoneInfo INDIAN_ZONE;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        using (TransactionScope ts=new TransactionScope ())
        {
            INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
            date = indianTime.ToString("yyyy-MM-dd");
            int end = int.Parse(ddlinst.SelectedItem.Value);
            for (int i = 1; i <= end; i++)
            {
                objsql.ExecuteNonQuery("insert into installments(regno,installment,amount,dated) values('" + txtregid.Text + "','1','" + txtamnt.Text + "','" + date + "')");
            }
            ts.Complete();
            ts.Dispose();
            details();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully ')", true);
        }

    }

    protected void txtregid_TextChanged(object sender, EventArgs e)
    {
        lblname.Text = Common.Get(objsql.GetSingleValue("select fname from usersnew where regno='" + txtregid.Text + "'"));
        if (lblname.Text == "")
        {
            lblname.Text = "No Data Found";
            btnsubmit.Enabled = false;
        }
        else
        {
            btnsubmit.Enabled = true;
        }
    }
    public void details()
    {
        string mobile = Common.Get(objsql.GetSingleValue("select mobile from usersnew where regno='" + txtregid.Text + "'"));
        string msz = "Your Emi update successfully.Please check it online.Thanks . For more info visit to www.yoursneed.com ";
        string apival = "http://www.sambsms.com/app/smsapi/index.php?key=459EDA8C909B85&campaign=1&routeid=7&type=text&contacts=" + mobile + "&msg=" + msz + "&senderid=YOURND";
        apicall(apival);
        // return total;

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
}