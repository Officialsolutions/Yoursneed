using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Transactions;
using System.Net;
using System.IO;
public partial class Auth_View_Structure : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    public int cont = 0;
    public static string date = "";
    private static TimeZoneInfo INDIAN_ZONE;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
        }
        INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
        date = indianTime.ToString("yyyy-MM-dd");
    }
    protected void bind(string regno)
    {
        dt = objsql.GetTable("select u.fname,u.regno,u.joined,i.cregno,i.productname,i.productdate  from inststruc i, usersnew u where i.cregno=u.regno and pregno='"+regno+"' order by i.cregno asc");
        if (dt.Rows.Count>0)
        {
            gvpins.DataSource = dt;
            gvpins.DataBind();
        }
    }

    protected void gvpins_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType ==ListViewItemType.DataItem)
        {
            HiddenField hid = (HiddenField)e.Item.FindControl("hfid");
            Label installment = (Label)e.Item.FindControl("lbltotalinst");
            Label last = (Label)e.Item.FindControl("lbllastpaid");
            TextBox txtpaid = (TextBox)e.Item.FindControl("txtpaid");

            installment.Text = Common.Get(objsql.GetSingleValue("select count(*) from installments where regno='" + hid.Value + "'"));
            string id = Common.Get(objsql.GetSingleValue("select max(serial) from installments where regno='" + hid.Value + "'"));
            string date = Common.Get(objsql.GetSingleValue("select dated from installments where serial='" + id + "'"));
            last.Text = Convert.ToDateTime(date).ToString("dd/MM/yyyy");
        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        DataTable dt2 = new DataTable();
        dt2 = objsql.GetTable("select * from usersnew where regno='" + txtregid.Text + "'");
        if (dt2.Rows.Count > 0)
        {
            lblname.Text = dt2.Rows[0]["fname"].ToString();
            bind(dt2.Rows[0]["regno"].ToString());
            btnsave.Enabled = true;
        }
        else
        {
            btnsave.Enabled = false;

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No Data Found')", true);

        }
    }

    protected void btnpay_Click(object sender, EventArgs e)
    {
        string countpins = Common.Get(objsql.GetSingleValue("select count(*) from duepins where regno='" +txtregid.Text + "'"));
        
        foreach (ListViewItem lv in gvpins.Items)
        {
            TextBox pay = (TextBox)lv.FindControl("txtpaid");
            HiddenField id = (HiddenField)lv.FindControl("hfid");
            using (TransactionScope ts=new TransactionScope ())
            {
                if (pay.Text!="")
                {
                  
                    int length = Convert.ToInt32(pay.Text);
                        for (int i = 1; i <= length; i++)
                        {
                        
                        objsql.ExecuteNonQuery("insert into installments(regno,installment,amount,dated) values('" + id.Value + "','1','1000','" + date + "')");
                        string mobile = Common.Get(objsql.GetSingleValue("select mobile from usersnew where regno='" + id.Value + "'"));
                        string msz = "Your Emi update successfully.Please check it online.Thanks";
                        string apival = "http://www.sambsms.com/app/smsapi/index.php?key=459EDA8C909B85&campaign=1&routeid=7&type=text&contacts=" + mobile + "&msg=" + msz + "&senderid=YOURND";
                        apicall(apival);
                    }

                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Updated Sucessfully')", true);
                        ts.Complete();
                        ts.Dispose();
                    
                }
                
            }

            
        }
        bind(txtregid.Text);

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
    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (txtadreg.Text != "")
        {
            string check=Common.Get(objsql.GetSingleValue("select cregno from inststruc where cregno='" + txtadreg.Text + "'"));
            if (check == "")
            {
                string name = Common.Get(objsql.GetSingleValue("select serial from usersnew where regno='" + txtadreg.Text + "'"));
                if (name != "")
                {
                    objsql.ExecuteNonQuery("insert into inststruc(pregno,cregno,dated) values('" + txtregid.Text + "','" + txtadreg.Text + "','" + System.DateTime.Now + "')");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Insert Updated Sucessfully')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Not found')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Already Added')", true);
            }
        }
        
        bind(txtregid.Text);
    }

    protected void lnkdelete_Click(object sender, EventArgs e)
    {
        string id = (sender as LinkButton).CommandArgument;
        objsql.ExecuteNonQuery("delete from inststruc where cregno='" + id + "'");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Delete Sucessfully')", true);
        bind(txtregid.Text);
    }

    protected void txtadreg_TextChanged(object sender, EventArgs e)
    {
        lblregname.Text = Common.Get(objsql.GetSingleValue("select fname from usersnew where regno='" + txtadreg.Text + "'"));
    }

    protected void lnkinst_Click(object sender, EventArgs e)
    {
        string id = (sender as LinkButton).CommandArgument;
        Response.Redirect("viewinstallments.aspx?id=" + id);
    }

   
    protected void gvpins_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "save")
        {
            HiddenField hfid = (HiddenField)e.Item.FindControl("hfid");
            TextBox product = (TextBox)e.Item.FindControl("txtproduct");
            if (product.Text != null)
            {
                objsql.ExecuteNonQuery("update inststruc set productname='" + product.Text + "',productdate='" + System.DateTime.Now.ToString("MM/dd/yyyy") + "' where cregno=" + e.CommandArgument);
            }
        }
    }
}