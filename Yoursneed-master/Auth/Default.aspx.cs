using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_Default : System.Web.UI.Page
{ SQLHelper objsql = new SQLHelper();
    public string current = "",monthname="",days="",year="";
    public static string date = "";
    private static TimeZoneInfo INDIAN_ZONE;
    string constring = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Admin"] == null)
        {
            Response.Redirect("login.aspx");
        }
        bind();
    }
    protected void bind()
    {
        INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
        date = indianTime.ToString("yyyy-MM-dd");
        lbltoday.Text = Common.Get(objsql.GetSingleValue("select count(*) from usersnew where joined='" + date + "'"));
        lbltotal.Text = Common.Get(objsql.GetSingleValue("select count(*) from usersnew "));
        lblblock.Text= Common.Get(objsql.GetSingleValue("select count(*) from usersnew where active='0'"));
        lblunblock.Text= Common.Get(objsql.GetSingleValue("select count(*) from usersnew where active='1'"));
        lblused.Text= Common.Get(objsql.GetSingleValue("select count(*) from pins where status='y'"));
        lblunused.Text= Common.Get(objsql.GetSingleValue("select count(*) from pins where status='n'"));
        lblstruct.Text= Common.Get(objsql.GetSingleValue("select count(*) from inststruc i Inner Join usersnew u on i.Cregno=u.regno"));
        lbltoday.Text= Common.Get(objsql.GetSingleValue("SELECT COUNT(*) FROM installments WHERE dated='" + date + "'"));
        current = Common.Get(objsql.GetSingleValue("select Month('" + date + "')"));
        year = Common.Get(objsql.GetSingleValue("select year('" + date + "')"));
        
        if (Convert.ToInt32(current)==1)
        {
            monthname = "January";
            days = "31";
        }
        else if (Convert.ToInt32(current) == 2)
        {
            string leap = Common.Get(objsql.GetSingleValue("SELECT IIF(DAY(EOMONTH(DATEFROMPARTS('"+year+"', 2, 1))) = 29, 'Leap year', 'Not Leap year')"));
           
            if (leap == "Leap year")
            {
                days = "29";
            }
            else
            {
                monthname = "February";
                days = "28";
            }
        }
        else if (Convert.ToInt32(current) == 3)
        {
            monthname = "March";
            days = "31";
        }
        else if (Convert.ToInt32(current) == 4)
        {
            monthname = "April";
            days = "30";
        }
        else if (Convert.ToInt32(current) == 5)
        {
            monthname = "May";
            days = "31";
        }
        else if (Convert.ToInt32(current) == 6)
        {
            monthname = "June";
            days = "30";
        }
        else if (Convert.ToInt32(current) == 7)
        {
            monthname = "July";
            days = "31";
        }
        else if (Convert.ToInt32(current) == 8)
        {
            monthname = "August";
            days = "31";
        }
        else if (Convert.ToInt32(current) == 9)
        {
            monthname = "September";
            days = "30";
        }
        else if (Convert.ToInt32(current) == 10)
        {
            monthname = "October";
            days = "31";
        }
        else if (Convert.ToInt32(current) == 11)
        {
            monthname = "November";
            days = "30";
        }
        else if (Convert.ToInt32(current) == 12)
        {
            monthname = "December";
            days = "31";
        }
        else 
        {
            monthname = "error";
            days = "0";
        }
        string startdate = (year +"-"+ current +"-1");
        string enddate = (year + "-" + current + "-"+days);

         lblmonth.Text= Common.Get(objsql.GetSingleValue("SELECT COUNT(*) FROM installments WHERE dated BETWEEN '"+ startdate + "' AND '"+ enddate + "'"));

        //using (SqlConnection con = new SqlConnection(constring))
        //{

        //    using (SqlCommand cmd = new SqlCommand("AchieveRewards", con))
        //    {
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        // sponser id                           // node
        //        cmd.Parameters.Add("@printvalue", SqlDbType.VarChar, 30);
        //        cmd.Parameters["@printvalue"].Direction = ParameterDirection.Output;
        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //        lblreward.Text = cmd.Parameters["@printvalue"].Value.ToString();

        //    }

        //}

    }

}