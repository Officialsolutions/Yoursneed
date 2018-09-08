using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Dashboard : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    public string regno, name, father, date, address, gender, phn, marital;
    public string single, single2, single3;
    public int cl = 0, cr = 0, Cl = 0, Cr = 0, Activeid = 0,  ActiveidL = 0, leftthismont = 0, thismonthinst = 0, thismonthinstleft = 0, counterdata = 0, counterdata2 = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
            Binddash();
            bindgrid();
            //pNodeL(Session["user"].ToString(), "one");
            //pNodeR(Session["user"].ToString(), "two");
        }
    }
    protected void bind()
    {
        DataTable dt = new DataTable();
        dt = objsql.GetTable("select * from usersnew where regno='" + Session["user"] + "'");
        if (dt.Rows.Count > 0)
        {
            regno = dt.Rows[0]["regno"].ToString();
            name = dt.Rows[0]["fname"].ToString();
            father= dt.Rows[0]["lname"].ToString();
            date = dt.Rows[0]["joined"].ToString();
            address = dt.Rows[0]["add1"].ToString();
            gender = dt.Rows[0]["sex"].ToString();
            phn = dt.Rows[0]["mobile"].ToString();
            marital = dt.Rows[0]["marital"].ToString();

        }
    }
    public void Binddash()
    {
        int sponser = 0, stotal = 0;
        string tds, net;
        lblnew.Text = Common.Get(objsql.GetSingleValue("select count(*) from pins where regno='" + Session["user"] + "' and status='n'"));
        lblused.Text = Common.Get(objsql.GetSingleValue("select count(*) from pins where regno='" + Session["user"] + "' and status='y'"));
        lbltrans.Text = Common.Get(objsql.GetSingleValue("select count(*) from pintransfers where oldregno='" + Session["user"] + "' "));
        lblins.Text = Common.Get(objsql.GetSingleValue("select count(*) from installments where regno='" + Session["user"] + "' "));

        sponser = int.Parse(Common.Get(objsql.GetSingleValue("select count(*) from usersnew where spillsregno='" + Session["user"] + "' and joined>'2018-07-17 00:00:00'")));
        stotal = (Convert.ToInt32(200) * Convert.ToInt32(sponser));
        tds = ((Convert.ToInt32(stotal) * Convert.ToInt32(10)) / Convert.ToInt32(100)).ToString();
        net = (Convert.ToInt32(stotal) - Convert.ToInt32(tds)).ToString();

        lblclear.Text = Common.Get(objsql.GetSingleValue("select sum(amount) from payout where regno='" + Session["user"] + "' "));
        if (lblclear.Text != "")
        {
            lblwallet.Text = (Convert.ToInt32(net) - Convert.ToInt32(lblclear.Text)).ToString();
        }
    }
    public void bindgrid()
    {
        DataTable dtg = new DataTable();
        dtg = objsql.GetTable("select * from legs where regno='" + Session["user"].ToString() + "'");
        if (dtg.Rows.Count > 0)
        {
            leftdr.Text = dtg.Rows[0]["leftdirect"].ToString();
            rightdr.Text = dtg.Rows[0]["rightdirect"].ToString();
            teaml.Text = dtg.Rows[0]["leftleg"].ToString();
            teamr.Text = dtg.Rows[0]["rightleg"].ToString();

        }
    }
    //protected void ActiveR(string id)
    //{
    //    leftthismont += 1;
    //    if (Convert.ToInt32(id) != 0)
    //    {
    //        int check = Convert.ToInt32(Common.Get(objsql.GetSingleValue("select count(*) from installments where regno='" + id + "'")));
    //        if (check >= 2)
    //        {
    //            string datemax = Common.Get(objsql.GetSingleValue("select max(dated) from installments where regno='" + id + "'"));
    //            if (datemax != "")
    //            {

    //                DateTime today = System.DateTime.Now;
    //                DateTime mx = Convert.ToDateTime(datemax);
    //                // string month = (Convert.ToDateTime(today).Month - Convert.ToDateTime(datemax).Month).ToString();
    //                int Diff = ((today.Year - mx.Year) * 12) + today.Month - mx.Month;
    //                if (Diff < 0)
    //                {
    //                    Diff = Convert.ToInt32(Diff) * Convert.ToInt32(-1);
    //                }
    //                else
    //                {

    //                }
    //                if (Diff <= 6)
    //                {
    //                    counterdata2 += 1;
    //                    lblright.Text = counterdata2.ToString();
    //                }

    //            }
    //        }
    //    }
 
    //}
    //private void pNodeR(string node, string place)
    //{
    //    string sql = "select * from usersnew where sregno='" + node + "' and node='" + place + "'";


    //    DataTable dt = new DataTable();
    //    dt = objsql.GetTable(sql);

    //    if (dt.Rows.Count == 1)
    //    {
    //        ActiveR(node);
    //        Cl = Cl + 1;
    //        pNodeRR(dt.Rows[0]["regno"].ToString(), "");

    //    }
    //    else if (dt.Rows.Count > 1)
    //    {
    //        ActiveR(node);
    //        Cl = Cl + 2;

    //        pNodeRR(dt.Select("node='one'")[0].ItemArray[0].ToString(), "One");
    //        pNodeRR(dt.Select("node='two'")[0].ItemArray[0].ToString(), "Two");

    //    }
    //    if (dt.Rows.Count == 0)
    //    {
    //        ActiveR(node);
    //        single3 = single3 + ',' + node;
    //    }
    //}
    //// Calculate after 1 count left
    //private void pNodeRR(string node, string place)
    //{
    //    string sql = "select * from usersnew where sregno='" + node + "' ";
    //    DataTable dt = new DataTable();
    //    dt = objsql.GetTable(sql);

    //    if (dt.Rows.Count == 1)
    //    {
    //        ActiveR(node);
    //        Cl = Cl + 1;
    //        single = single + ',' + node;
    //        pNodeRR(dt.Rows[0]["regno"].ToString(), "");
    //    }
    //    else if (dt.Rows.Count > 1 || dt.Rows.Count < 0)
    //    {
    //        ActiveR(node);
    //        Cl = Cl + 2;
    //        single2 = single2 + ',' + node;
    //        pNodeRR(dt.Select("node='one'")[0].ItemArray[0].ToString(), "One");


    //        pNodeRR(dt.Select("node='two'")[0].ItemArray[0].ToString(), "Two");

    //        //   ActiveL(node);


    //    }
    //    if (dt.Rows.Count == 0)
    //    {

    //        ActiveR(node);
    //        single3 = single3 + ',' + node;
    //    }

    //}
    //protected void ActiveL(string id)
    //{
    //    leftthismont += 1;
    //    if (Convert.ToInt32(id) != 0)
    //    {
    //        int check = Convert.ToInt32(Common.Get(objsql.GetSingleValue("select count(*) from installments where regno='" + id + "'")));
    //        if (check >= 2)
    //        {
    //            string datemax = Common.Get(objsql.GetSingleValue("select max(dated) from installments where regno='" + id + "'"));
    //            if (datemax != "")
    //            {

    //                DateTime today = System.DateTime.Now;
    //                DateTime mx = Convert.ToDateTime(datemax);
    //                // string month = (Convert.ToDateTime(today).Month - Convert.ToDateTime(datemax).Month).ToString();
    //                int Diff = ((today.Year - mx.Year) * 12) + today.Month - mx.Month;
    //                if (Diff < 0)
    //                {
    //                    Diff = Convert.ToInt32(Diff) * Convert.ToInt32(-1);
    //                }
    //                else
    //                {

    //                }
    //                if (Diff <= 6)
    //                {
    //                    counterdata += 1;
    //                    lblleft.Text = counterdata.ToString();
    //                }

    //            }
    //        }
    //    }
    //}
    //private void pNodeL(string node, string place)
    //{
    //    string sql = "select * from usersnew where sregno='" + node + "' and node='" + place + "'";


    //    DataTable dt = new DataTable();
    //    dt = objsql.GetTable(sql);

    //    if (dt.Rows.Count == 1)
    //    {
    //        ActiveL(node);
    //        Cl = Cl + 1;
    //        pNodeLL(dt.Rows[0]["regno"].ToString(), "");

    //    }
    //    else if (dt.Rows.Count > 1)
    //    {
    //        ActiveL(node);
    //        Cl = Cl + 2;

    //        pNodeLL(dt.Select("node='one'")[0].ItemArray[0].ToString(), "One");
    //        pNodeLL(dt.Select("node='two'")[0].ItemArray[0].ToString(), "Two");

    //    }
    //    if (dt.Rows.Count == 0)
    //    {
    //        ActiveL(node);

    //    }
    //}
    //// Calculate after 1 count left
    //private void pNodeLL(string node, string place)
    //{
    //    string sql = "select * from usersnew where sregno='" + node + "' ";
    //    DataTable dt = new DataTable();
    //    dt = objsql.GetTable(sql);

    //    if (dt.Rows.Count == 1)
    //    {
    //        ActiveL(node);
    //        Cl = Cl + 1;
    //        single = single + ',' + node;
    //        pNodeLL(dt.Rows[0]["regno"].ToString(), "");
    //    }
    //    else if (dt.Rows.Count > 1 || dt.Rows.Count < 0)
    //    {
    //        ActiveL(node);
    //        Cl = Cl + 2;
    //        single2 = single2 + ',' + node;
    //        pNodeLL(dt.Select("node='one'")[0].ItemArray[0].ToString(), "One");


    //        pNodeLL(dt.Select("node='two'")[0].ItemArray[0].ToString(), "Two");

    //        //   ActiveL(node);


    //    }
    //    if (dt.Rows.Count == 0)
    //    {

    //        ActiveL(node);
    //        single3 = single3 + ',' + node;
    //    }

    //}
}