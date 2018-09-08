using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_Requestedewallet : System.Web.UI.Page
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
        dt = objsql.GetTable("select * from ewalletreq order by Id desc");
        if (dt.Rows.Count > 0)
        {
            gvpins.DataSource = dt;
            gvpins.DataBind();
        }
    }

    protected void gvpins_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if(e.CommandName== "approve")
        {
            objsql.ExecuteNonQuery("update ewalletreq set approvalstatus='approve',approvaldate='" + System.DateTime.Now.ToString("MM/dd/yyyy") + "' where regno=" + e.CommandArgument);
        }
        if(e.CommandName== "reject")
        {
            objsql.ExecuteNonQuery("update ewalletreq set approvalstatus='reject',approvaldate='" + System.DateTime.Now.ToString("MM/dd/yyyy") + "' where regno=" + e.CommandArgument);
        }
        bind();
    }
}