using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_News : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    public static string img;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                bind();
            }
        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            string a = FileUpload1 != null ? objsql.uploadfile(FileUpload1) : img;
            objsql.ExecuteNonQuery("update latestnews set image='" + a + "' where id='" + Request.QueryString["id"] + "'");
        }
        else
        {
            objsql.ExecuteNonQuery("insert into latestnews(image) values('" + objsql.uploadfile(FileUpload1) + "')");
        }
        Response.Redirect("viewnews.aspx");
    }
    protected void bind()
    {
        dt = objsql.GetTable("select * from latestnews where id='" + Request.QueryString["id"] + "'");
        if (dt.Rows.Count > 0)
        {
            img = dt.Rows[0]["image"].ToString();
        }
    }
}