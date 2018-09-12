using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_ViewInstallments : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                if (Convert.ToInt32(Request.QueryString["id"]) < 3200)
                {
                    lbltotal.Text = "16";
                }
                else
                {
                    lbltotal.Text = "12";
                }
                bind(Request.QueryString["id"]);
                count(Request.QueryString["id"]);

            }
        }

    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(txtregid.Text) < 3200)
        {
            lbltotal.Text = "16";
        }
        else
        {
            lbltotal.Text = "12";
        }
        bind(txtregid.Text);
        count(txtregid.Text);
        lblname.Text = Common.Get(objsql.GetSingleValue("select fname from usersnew where regno='" + txtregid.Text + "'"));
        lblmobile.Text = Common.Get(objsql.GetSingleValue("select mobile from usersnew where regno='" + txtregid.Text + "'"));


    }
    protected void bind(string id)
    {
        txtregid.Text = id;
        lblname.Text = Common.Get(objsql.GetSingleValue("select fname from usersnew where regno='" + id + "'"));
        lblmobile.Text = Common.Get(objsql.GetSingleValue("select mobile from usersnew where regno='" + id + "'"));
        dt = objsql.GetTable("select * from installments where regno='" + id + "' order by dated ");
        if (dt.Rows.Count > 0)
        {
            gvpins.DataSource = dt;
            gvpins.DataBind();
        }
        else
        {
            gvpins.DataSource = dt;
            gvpins.DataBind();
            lblpaid.Text = "0";
            lblpending.Text = "0";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid Registration')", true);
        }
    }
    protected void count(string id)
    {
        if (dt.Rows.Count > 0)
        {
            lblpaid.Text = Common.Get(objsql.GetSingleValue("select count(*) from installments where regno = '" + id + "'"));
            lblpending.Text = (Convert.ToInt32(lbltotal.Text) - Convert.ToInt32(lblpaid.Text)).ToString();
        }

    }

    protected void delete_Click(object sender, EventArgs e)
    {
        string id = (sender as LinkButton).CommandArgument;
        objsql.ExecuteNonQuery("delete from installments where serial='" + id + "'");
        if (Request.QueryString["id"] != null)
        {
            bind(Request.QueryString["id"]);
        }
        else
        {
            bind(txtregid.Text);

        }

    }
    //protected void lnkedit_Click(object sender, EventArgs e)
    //{
    //    string id = (sender as LinkButton).CommandArgument;
    //    //objsql.ExecuteNonQuery("update installments set dated='"+ +"' where serial='" + id + "'");
    //    //if (Request.QueryString["id"] != null)
    //    //{
    //    //    bind(Request.QueryString["id"]);
    //    //}
    //    //else
    //    //{
    //    //    bind(txtregid.Text);

    //    //}
    //}

    //protected void lnkupdate_Click(object sender, EventArgs e)
    //{

    //}

    protected void gvpins_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Label id = gvpins.Rows[e.RowIndex].FindControl("lblid") as Label;

        TextBox txtdate = this.gvpins.Rows[e.RowIndex].FindControl("txtdate") as TextBox;
        string date = txtdate.Text;
      //  DateTime dat = DateTime.ParseExact(date, ("yyyy-MM-dd"), null);
        objsql.ExecuteNonQuery("Update installments set dated='" + Convert.ToDateTime(date).ToString("yyyy-MM-dd") + "' where serial='" + id.Text + "'");
        gvpins.EditIndex = -1;
        if (Request.QueryString["id"] != null)
        {
            bind(Request.QueryString["id"]);
        }
        else
        {
            bind(txtregid.Text);

        }
    }

    protected void gvpins_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvpins.EditIndex = e.NewEditIndex;
        if (Request.QueryString["id"] != null)
        {
            bind(Request.QueryString["id"]);
        }
        else
        {
            bind(txtregid.Text);

        }
    }

    protected void gvpins_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvpins.EditIndex = -1;
        if (Request.QueryString["id"] != null)
        {
            bind(Request.QueryString["id"]);
        }
        else
        {
            bind(txtregid.Text);

        }
    }
}