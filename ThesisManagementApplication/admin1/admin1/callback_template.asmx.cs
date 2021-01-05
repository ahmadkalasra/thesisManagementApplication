using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web.Script.Services;
using System.Xml;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace admin1
{
    /// <summary>
    /// Summary description for callback_template
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class callback_template : System.Web.Services.WebService
    {

        
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetDetails()
        {
            String[] arr = new string[2] {"sdfds","fdsfsd" };
            List<string> arrr = new List<string>();
            
            //return arrr;


            using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
            {


                SqlDataReader reader2;
                cn.Open();
                String querystr2 = "select * from examiner where examiner_type_id=1";

                SqlCommand cmd2 = new SqlCommand(querystr2, cn);

                //cmd2.Parameters.AddWithValue("@sup_id", Convert.ToInt32(Session["suggested_supervisor_id"]));

                reader2 = cmd2.ExecuteReader();

                int x = 0;
                while (reader2.HasRows && reader2.Read())
                {
                    String name = reader2.GetString(reader2.GetOrdinal("examiner_name"));
                    arrr.Add(name);
                }
                reader2.Close();
                cn.Close();
            }
            Context.Response.Write(string.Join(Environment.NewLine, arrr));
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetDetails2()
        {
            String[] arr1 = new string[2] { "sdfds", "fdsfsd" };
            List<string> arrr1 = new List<string>();
            
            //return arrr;


            using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
            {


                SqlDataReader reader2;
                cn.Open();
                String querystr2 = "select * from examiner where examiner_type_id=2";

                SqlCommand cmd2 = new SqlCommand(querystr2, cn);

                //cmd2.Parameters.AddWithValue("@sup_id", Convert.ToInt32(Session["suggested_supervisor_id"]));

                reader2 = cmd2.ExecuteReader();

                int x = 0;
                while (reader2.HasRows && reader2.Read())
                {
                    String name = reader2.GetString(reader2.GetOrdinal("examiner_name"));
                    arrr1.Add(name);
                }
                reader2.Close();
                cn.Close();
            }
            Context.Response.Write(string.Join(Environment.NewLine, arrr1));
        }
        public void GetDetails3()
        {
            String[] arr = new string[2] { "sdfds", "fdsfsd" };
            List<string> arrr = new List<string>();
            arrr.Add("sdf");
            arrr.Add("sda");
            //return arrr;


            using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
            {


                SqlDataReader reader2;
                cn.Open();
                String querystr2 = "select * from examiner where examiner_type_id=1";

                SqlCommand cmd2 = new SqlCommand(querystr2, cn);

                //cmd2.Parameters.AddWithValue("@sup_id", Convert.ToInt32(Session["suggested_supervisor_id"]));

                reader2 = cmd2.ExecuteReader();
                
                while (reader2.HasRows && reader2.Read())
                {
                    String name = reader2.GetString(reader2.GetOrdinal("examiner_name"));
                    
                    arrr.Add(name);
                }
                reader2.Close();
                cn.Close();
            }
            Context.Response.Write(string.Join(Environment.NewLine, arrr));
        }
        public void GetDetails4()
        {
            String[] arr = new string[2] { "sdfds", "fdsfsd" };
            List<string> arrr = new List<string>();
            arrr.Add("sdf");
            arrr.Add("sda");
            //return arrr;


            using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
            {


                SqlDataReader reader2;
                cn.Open();
                String querystr2 = "select * from examiner where examiner_type_id=1";

                SqlCommand cmd2 = new SqlCommand(querystr2, cn);

                //cmd2.Parameters.AddWithValue("@sup_id", Convert.ToInt32(Session["suggested_supervisor_id"]));

                reader2 = cmd2.ExecuteReader();
                
                while (reader2.HasRows && reader2.Read())
                {
                    String name = reader2.GetString(reader2.GetOrdinal("examiner_name"));
                    arrr.Add(name);
                }
                reader2.Close();
                cn.Close();
            }
            Context.Response.Write(string.Join(Environment.NewLine, arrr));
        }
    }
}
