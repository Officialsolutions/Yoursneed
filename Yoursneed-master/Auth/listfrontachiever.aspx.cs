using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_listfrontachiever : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
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
        dt = objsql.GetTable("select * from achiever order by id desc");
        if(dt.Rows.Count>0)
        {
            gvpins.DataSource = dt;
            gvpins.DataBind();
        }
    }

    protected void edit_Click(object sender, EventArgs e)
    {
        string id = (sender as LinkButton).CommandArgument;
        Response.Redirect("front-achiever.aspx?id=" + id);
    }

    protected void delete_Click(object sender, EventArgs e)
    {
        string id = (sender as LinkButton).CommandArgument;
        objsql.ExecuteNonQuery("delete from achiever where id='" + id + "'");
        bind();
    }
}