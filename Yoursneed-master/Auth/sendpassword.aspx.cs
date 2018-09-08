using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;

public partial class Auth_sendpassword : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void txtpin_TextChanged(object sender, EventArgs e)
    {
        lblname.Text =Common.Get(objsql.GetSingleValue("select fname from usersnew where regno='" + txtpin.Text + "'"));
        lblpass.Text =Common.Get(objsql.GetSingleValue("select pass from usersnew where regno='" + txtpin.Text + "'"));
        lblmob.Text =Common.Get(objsql.GetSingleValue("select mobile from usersnew where regno='" + txtpin.Text + "'"));
        pnldata.Visible = true;
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        string msz = "Your new Password is "+lblpass.Text+".Plz check your details on www.yoursneed.com";
        string apival = "http://www.sambsms.com/app/smsapi/index.php?key=459EDA8C909B85&campaign=1&routeid=7&type=text&contacts=" + lblmob.Text + "&msg=" + msz + "&senderid=YOURND";
        apicall(apival);
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