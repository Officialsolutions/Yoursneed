using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_update_profile : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    public DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }

    }
    protected void bind()
    {
        dt = objsql.GetTable("select * from usersnew where regno='" + Session["user"] + "'");
        if (dt.Rows.Count > 0)
        {
            lblspon.Text = dt.Rows[0]["spillsregno"].ToString();
            if(lblspon.Text !="")
            {
                lblspon.Attributes.Add("Readonly", "Readonly");
            }
            lblads.Text = dt.Rows[0]["add1"].ToString();
            if (lblads.Text != "")
            {
                lblads.Attributes.Add("Readonly", "Readonly");
            }
            lblbank.Text = dt.Rows[0]["bankname"].ToString();
            if (lblbank.Text != "")
            {
                lblbank.Attributes.Add("Readonly", "Readonly");
            }
            lblbankac.Text = dt.Rows[0]["account"].ToString();
            if (lblbankac.Text != "")
            {
                lblbankac.Attributes.Add("Readonly", "Readonly");
            }
            lblcity.Text = dt.Rows[0]["city"].ToString();
            if (lblcity.Text != "")
            {
                lblcity.Attributes.Add("Readonly", "Readonly");
            }
            lblcountry.Text = dt.Rows[0]["country"].ToString();
            if (lblcountry.Text != "")
            {
                lblcountry.Attributes.Add("Readonly", "Readonly");
            }
            lblemail.Text = dt.Rows[0]["email"].ToString();
            if (lblemail.Text != "")
            {
                lblemail.Attributes.Add("Readonly", "Readonly");
            }
            lblfather.Text = dt.Rows[0]["lname"].ToString();
            if (lblfather.Text != "")
            {
                lblfather.Attributes.Add("Readonly", "Readonly");
            }
            lblmon.Text = dt.Rows[0]["mobile"].ToString();
            if (lblmon.Text != "")
            {
                lblmon.Attributes.Add("Readonly", "Readonly");
            }
            lblname.Text = dt.Rows[0]["fname"].ToString();
          
            lblnomads.Text = dt.Rows[0]["nomiadd"].ToString();
            if (lblnomads.Text != "")
            {
                lblnomads.Attributes.Add("Readonly", "Readonly");
            }
            lblnomiee.Text = dt.Rows[0]["nominame"].ToString();
            if (lblnomiee.Text != "")
            {
                lblnomiee.Attributes.Add("Readonly", "Readonly");
            }
            lblnomieephone.Text = dt.Rows[0]["nomiph"].ToString();
            if (lblnomieephone.Text != "")
            {
                lblnomieephone.Attributes.Add("Readonly", "Readonly");
            }
            lblpan.Text = dt.Rows[0]["pannumber"].ToString();
            if (lblpan.Text != "")
            {
                lblpan.Attributes.Add("Readonly", "Readonly");
            }
            lblphone.Text = dt.Rows[0]["phone1"].ToString();
            if (lblphone.Text != "")
            {
                lblphone.Attributes.Add("Readonly", "Readonly");
            }
            lblphpone2.Text = dt.Rows[0]["phone2"].ToString();
            if (lblphpone2.Text != "")
            {
                lblphpone2.Attributes.Add("Readonly", "Readonly");
            }
            lblpin.Text = dt.Rows[0]["updatepin"].ToString();
            if (lblpin.Text != "")
            {
                lblpin.Attributes.Add("Readonly", "Readonly");
            }
            lblreg.Text = dt.Rows[0]["regno"].ToString();
            lblrelation.Text = dt.Rows[0]["relation"].ToString();
            if (lblrelation.Text != "")
            {
                lblrelation.Attributes.Add("Readonly", "Readonly");
            }
            lblstate.Text = dt.Rows[0]["state"].ToString();
            if (lblstate.Text != "")
            {
                lblstate.Attributes.Add("Readonly", "Readonly");
            }

        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        objsql.ExecuteNonQuery("update usersnew set fname='"+ lblfather.Text + "',spillsregno='" + lblspon.Text + "',add1='" + lblads.Text + "',bankname='" + lblbank.Text + "',account='" + lblbankac.Text
            + "',city='" + lblcity.Text + "',country='" + lblcountry.Text + "',email='" + lblemail.Text + "',mobile='" + lblmon.Text + "',nomiadd='" + lblnomads.Text + "',nominame='" + lblnomiee.Text
            + "',nomiph='" + lblnomieephone.Text + "',pannumber='" + lblpan.Text + "',phone1='" + lblphone.Text + "',phone2='" + lblphpone2.Text + "',city='"+ lblcity.Text + "',pin='"+ lblpin.Text
            + "',state='"+ lblstate.Text + "',relation='" + lblrelation.Text + "',edited='1' where regno='" + Session["user"] + "' ");
        Response.Redirect("dashboard.aspx");
    }
}