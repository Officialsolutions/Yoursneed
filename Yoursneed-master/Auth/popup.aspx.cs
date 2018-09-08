using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_popup : System.Web.UI.Page
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
            string a = null;
            if (FileUpload1.HasFile)
            {
                 a = FileUpload1 != null ? objsql.uploadfile(FileUpload1) : img;
            }
             else
            {
               a = img;
            }   
            objsql.ExecuteNonQuery("update popup set image='" + a + "',name='"+ txtname.Text.Trim() +"' where id='" + Request.QueryString["id"] + "'");
        }
        else
        {
            objsql.ExecuteNonQuery("insert into popup(name,image) values('"+ txtname.Text.Trim() + "','" + objsql.uploadfile(FileUpload1) + "')");
        }
        Response.Redirect("view-popup.aspx");
    }
    protected void bind()
    {
        dt = objsql.GetTable("select * from popup where id='" + Request.QueryString["id"] + "'");
        if (dt.Rows.Count > 0)
        {
            img = dt.Rows[0]["image"].ToString();
            txtname.Text = dt.Rows[0]["name"].ToString().Trim();
        }
    }
}