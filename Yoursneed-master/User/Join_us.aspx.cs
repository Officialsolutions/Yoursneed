using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Transactions;
using System.Net;
using System.IO;

public partial class User_Join_us : System.Web.UI.Page
{
    public static string pin = "", sponser = "",pintype="", newregno="",pass="",lastdata;
    SQLHelper objsql = new SQLHelper();
    string constring = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
    public static Boolean proposalstatus = false;
    public int lefdirect = 0, rightdirect = 0, left = 0, right = 0;
    Common cm = new Common();
    public static string date = "";
    private static TimeZoneInfo INDIAN_ZONE;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["pin"] != null || Request.QueryString["sponser"] != null)
            {
                pin = Request.QueryString["pin"].ToString();
                sponser = Request.QueryString["sponser"].ToString();
                txtsponserid.Text = sponser;
                lblsponsername.Text = Common.Get(objsql.GetSingleValue("select fname from usersnew where regno='" + sponser + "'"));
                lblleafnode.Text =lastnode(sponser);
                pintype = Common.Get(objsql.GetSingleValue("select pintype from pins where pin='" + pin + "'"));
                lastdata = lastnode(sponser);
            }
        }
        INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
        date = indianTime.ToString("yyyy-MM-dd");
    }

    #region Check Valid Upline
    protected void txtproposerid_TextChanged(object sender, EventArgs e)
    {

        using (SqlConnection con = new SqlConnection(constring))
        {
            using (SqlCommand cmd = new SqlCommand("VAL_DOWNLINE", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PID", txtproposerid.Text.Trim());         // proposer id
                cmd.Parameters.AddWithValue("@ID", txtsponserid.Text.Trim());                             // sponser id
                cmd.Parameters.Add("@Down", SqlDbType.VarChar, 30);
                cmd.Parameters["@Down"].Direction = ParameterDirection.Output;  // outpur parameter
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                string check = cmd.Parameters["@Down"].Value.ToString();
                if (check == "")
                {
                    lblproposername.Text = "Proposer is Not Vaid in up line";
                }
                else
                {
                    lblproposername.Text = Common.Get(objsql.GetSingleValue("select fname from usersnew where regno='" + txtproposerid.Text + "'"));
                    proposalstatus = true;
                    lblleafnode.Text = lastnode(sponser);
                }
                //  lblFruitName.Text = "Last Node: " + cmd.Parameters["@printvalue"].Value.ToString();
            }
        }
    } 
    #endregion

    protected string lastnode(string sponser)
    {
        using (SqlConnection con = new SqlConnection(constring))
        {
           
                using (SqlCommand cmd = new SqlCommand("LastNode", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", txtsponserid.Text.Trim());           // sponser id
                    cmd.Parameters.AddWithValue("@node", rdonode.SelectedItem.Value);                            // node
                    cmd.Parameters.Add("@printvalue", SqlDbType.VarChar, 30);
                    cmd.Parameters["@printvalue"].Direction = ParameterDirection.Output;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return cmd.Parameters["@printvalue"].Value.ToString();
                   
                }
            
        }
    }

    protected void rdonode_TextChanged(object sender, EventArgs e)
    {
        lblleafnode.Text =lastnode(sponser);
       // lastdata = lastnode(sponser);
    }

    protected void btnjoin_Click(object sender, EventArgs e)
    {
        using (TransactionScope ts=new TransactionScope ())
        {
            try
            {
                
                    // insert in usersnew table
                    // sregno= lastnode
                    //spillsregno = sponser
                     newregno = cm.GenerateRegno();
                     pass = cm.Generatepass();
                    objsql.ExecuteNonQuery("insert into usersnew(regno,pass,fname,lname,dob,add1,city,pin,state,country,mobile,nomirel,sregno,node,status,joined,grace,spillsregno,updated,updatepin,pintypeid,aadharcard,proposerregno,relation,Active,edited) values('" + newregno + "','" + pass + "','" + txtname.Text + "','" + txtrelation.Text + "','" + dob() + "','" + txtadd.Text + "','" + txtcity.Text + "','" + txtpincode.Text + "','" + txtstate.Text + "','" + txtcountry.Text + "','" + txtphn.Text + "','" + txtnominee.Text + "','"+ lastnode(sponser) + "','"+rdonode.SelectedItem.Value+"','y','"+DateTime.Now+"','10','"+sponser+"','n','"+pin+"','"+pintype+"','"+txtaadhar.Text+"','"+txtproposerid.Text+"','"+ddlrelation.SelectedItem.Text+"','1','0')");
                    // joining installment
                    objsql.ExecuteNonQuery("insert into installments(regno,installment,amount,dated,paidby) values('" + newregno + "','1','1000','" + date + "','')");
                    objsql.ExecuteNonQuery("update pins set status='y',subregno='" + newregno+"' where pin='" + pin + "'");
                    #region insert in leg table
                    string countleafnode = Common.Get(objsql.GetSingleValue("select regno from legs where regno='" + newregno + "'"));

                    

                        if (rdonode.SelectedItem.Value == "one")
                        {
                            objsql.ExecuteNonQuery("insert into legs(regno,leftleg,rightleg,leftdirect,rightdirect)values('" + newregno + "','0','0','0','0')");

                        }
                        else
                        {
                            objsql.ExecuteNonQuery("insert into legs(regno,leftleg,rightleg,leftdirect,rightdirect)values('" + newregno + "','0','0','0','0')");


                        }
                    


                    #endregion
                    #region Update Legs
                    DataTable dt = new DataTable();
                    dt = objsql.GetTable("select * from legs where regno='" + txtsponserid.Text + "'");
                    if (dt.Rows.Count > 0)
                    {
                        if (txtsponserid.Text!="")        // direct 
                        {
                            if (rdonode.SelectedItem.Value == "one")
                            {
                                int getdirect = int.Parse(Common.Get(objsql.GetSingleValue("select leftdirect from legs where regno='" + txtsponserid.Text + "'")));
                                
                                    getdirect += 1;
                                    objsql.ExecuteNonQuery("update legs set leftdirect='" + getdirect + "' where regno='" + txtsponserid.Text + "'");
                               

                            }
                            else
                            {
                                rightdirect = int.Parse(Common.Get(objsql.GetSingleValue("select rightdirect from legs where regno='" + txtsponserid.Text + "'")));
                                rightdirect += 1;
                                objsql.ExecuteNonQuery("update legs set rightdirect='" + rightdirect + "' where regno='" + txtsponserid.Text + "'");

                            }
                            using (SqlConnection con = new SqlConnection(constring))
                            {

                                using (SqlCommand cmd = new SqlCommand("EveryNode", con))
                                {
                                    string check = lastdata;
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@id", lblleafnode.Text);           // sponser id
                                    cmd.Parameters.AddWithValue("@node", rdonode.SelectedItem.Value);                            // node
                                    cmd.Parameters.AddWithValue("@checkid", lblleafnode.Text);
                                    cmd.Parameters.Add("@printvalue", SqlDbType.VarChar, 30);
                                    cmd.Parameters["@printvalue"].Direction = ParameterDirection.Output;
                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                    string a = cmd.Parameters["@printvalue"].Value.ToString();

                                }

                            }
                        }
                        //else
                        //{
                        //    if (rdonode.SelectedItem.Value == "one")
                        //    {
                        //        left = int.Parse(Common.Get(objsql.GetSingleValue("select leftleg from legs where regno='" + sponser + "'")));
                        //        if (left >= 0)
                        //        {
                        //            left += 1;
                        //            objsql.ExecuteNonQuery("update legs set leftleg='" + left + "' where regno='" + sponser + "'");
                        //        }

                        //    }
                        //    else
                        //    {
                        //        right = int.Parse(Common.Get(objsql.GetSingleValue("select rightleg from legs where regno='" + sponser + "'")));
                        //        right += 1;
                        //        objsql.ExecuteNonQuery("update legs set rightleg='" + right + "' where regno='" + sponser + "'");

                        //    }
                        //}
                    }
                    #endregion
                    
                    string msz = "Welcome to YOURSNEED Business." + txtname.Text + ". Your id is " + newregno + " and password is " + pass + ". Please happy login www.yoursneed.com. Thank you Join Us";
                    if (txtphn.Text != null)
                    {
                        string apival = "http://www.sambsms.com/app/smsapi/index.php?key=459EDA8C909B85&campaign=1&routeid=7&type=text&contacts="+ txtphn.Text +"&msg="+msz+"&senderid=YOURND";
                        // objsql.SendSMS("", "", txtphn.Text, msz);
                        apicall(apival);
                    }
                    
               
                ts.Complete();
                ts.Dispose();
                details();

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Thank You For Registration ')", true);
                Response.Redirect("welcome.aspx?id=" + newregno + "&pass=" + pass+"&name="+txtname.Text);
                
            }
            catch (Exception a)
            {
                
                string msz = a.Message;
                throw;
            }
        }
    }
    protected string dob()
    {
        return ddlmonth.SelectedItem.Text + "/" + ddlday.SelectedItem.Text + "/" + txtyear.Text;
    }

    protected void txtsponserid_TextChanged(object sender, EventArgs e)
    {
        lblsponsername.Text = Common.Get(objsql.GetSingleValue("select fname from usersnew where regno='" + txtsponserid.Text + "'"));
        sponser = txtsponserid.Text;
        lastdata = lastnode(sponser);
        lblleafnode.Text = lastnode(sponser);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
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

    public void details()
    {
        string name= Common.Get(objsql.GetSingleValue("select fname from usersnew where regno='" + txtsponserid.Text + "'"));
        string mobile= Common.Get(objsql.GetSingleValue("select mobile from usersnew where regno='" + txtsponserid.Text + "'"));
        int sponser= int.Parse(Common.Get(objsql.GetSingleValue("select count(*) from usersnew where spillsregno='" + txtsponserid.Text + "' and joined>'2018-07-17 00:00:00'")));
        //int proposer = int.Parse(Common.Get(objsql.GetSingleValue("select count(*) from usersnew where proposerregno='" + txtsponserid.Text + "' and joined>'2018-07-17 00:00:00'")));
        int stotal = (200) * (sponser);
        string tds = ((Convert.ToInt32(stotal) * Convert.ToInt32(10)) / Convert.ToInt32(100)).ToString();
        string total = (Convert.ToInt32(stotal) - Convert.ToInt32(tds)).ToString();
        string msz = "Your Id A/C " + txtsponserid.Text + " Credited INR 200/- on "+date + " - Deposited by YOURSNEED business Total Bal INR " + total + "/-. For more info visit to www.yoursneed.com";
        //string msz = "CONGRATULATIONS." + name + " Id No. " + txtsponserid.Text + " Your direct income INR 200/- and Total INR " + total + "/- credited by YOURSNEED Trading Company.Plz check your details on www.yoursneed.com";
        string apival = "http://www.sambsms.com/app/smsapi/index.php?key=459EDA8C909B85&campaign=1&routeid=7&type=text&contacts=" + mobile + "&msg=" + msz + "&senderid=YOURND";
        apicall(apival);
       // return total;
    
    }
}