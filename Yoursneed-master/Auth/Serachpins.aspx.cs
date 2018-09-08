using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_Serachpins : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    public static string total = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }

    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
       
        if (lblname.Text != null)
        {
            objsql.ExecuteNonQuery("delete top(" + txtdelete.Text + ") from pins where regno='" + txtregid.Text + "' and status='n' ");
            bind();
        }
        
    }

    protected void txtregid_TextChanged(object sender, EventArgs e)
    {
        bind();


    }
    protected void bind()
    {
        lblname.Text = Common.Get(objsql.GetSingleValue("select fname from usersnew where regno='" + txtregid.Text + "'"));
        if (lblname.Text == "")
        {
            lblname.Text = "No Data Found";
            btnsubmit.Enabled = false;
        }
        else
        {
            total = Common.Get(objsql.GetSingleValue("select count(*) from pins where regno='" + txtregid.Text + "' and status='n'"));
          

            btnsubmit.Enabled = true;
        }
       
    }
}