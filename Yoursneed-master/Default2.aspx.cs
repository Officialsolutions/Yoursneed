using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    string constring = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        check();
    }

    protected void check()
    {
        DataTable dt = new DataTable();
        dt = objsql.GetTable("select * from usersnew");
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {

                DataTable dt2 = new DataTable();
                dt2 = objsql.GetTable("select * from legs where regno='" + dr["regno"] + "'");
                if (dt2.Rows.Count > 0)
                {
                    int left = Convert.ToInt32(dt2.Rows[0]["leftleg"]);
                    int right = Convert.ToInt32(dt2.Rows[0]["rightleg"]);

                    if (left <= right)
                    {
                        DataTable dt3 = new DataTable();
                        dt3 = objsql.GetTable("select * from tblrewards where pins<=" + left + "");
                        foreach (DataRow dd in dt3.Rows)
                        {
                            string test = Common.Get(objsql.GetSingleValue("select rewads from tblpendingreward where rewads='" + dd["id"] + "' and regno='" + dr["regno"] + "' "));
                            if (test == "")
                            {
                                objsql.ExecuteNonQuery("insert into tblPendingreward(regno,rewads,payout,date) values('" + dr["regno"] + "','" + dd["id"] + "','Pending','" + System.DateTime.Now + "')");
                            }
                        }
                    }
                    else
                    {
                        DataTable dt3 = new DataTable();
                        dt3 = objsql.GetTable("select * from tblrewards where pins<=" + right + "");
                        foreach (DataRow dd in dt3.Rows)
                        {
                            string test = Common.Get(objsql.GetSingleValue("select rewads from tblpendingreward where rewads='" + dd["id"] + "' and regno='" + dr["regno"] + "' "));
                            if (test == "")
                            {
                                objsql.ExecuteNonQuery("insert into tblPendingreward(regno,rewads,payout,date) values('" + dr["regno"] + "','" + dd["id"] + "','Pending','" + System.DateTime.Now + "')");
                            }
                        }
                    }
                }
            }
        }
    }
}