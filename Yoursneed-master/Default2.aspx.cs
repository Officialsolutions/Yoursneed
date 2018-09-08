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
    string constring = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        string apival = "http://www.sambsms.com/app/smsapi/index.php?key=459EDA8C909B85&campaign=1&routeid=7&type=text&contacts=9814777093&msg=hi&senderid=YOURND";
        apicall(apival);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(constring))
        {

            using (SqlCommand cmd = new SqlCommand("VAL_DOWNLINE", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PID", 1053);           // sponser id
                cmd.Parameters.AddWithValue("@ID", 1054);                            // node
                cmd.Parameters.Add("@Down", SqlDbType.VarChar, 30);
                cmd.Parameters["@Down"].Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                string a = cmd.Parameters["@Down"].Value.ToString();

            }

        }
    }
    public string apicall(string url)
    {
        HttpWebRequest httpreq = (HttpWebRequest)WebRequest.Create(url);
        HttpWebResponse httpres = (HttpWebResponse)httpreq.GetResponse();
        StreamReader sr = new StreamReader(httpres.GetResponseStream());
        string results = sr.ReadToEnd();
        sr.Close();
        return results;
    }
}