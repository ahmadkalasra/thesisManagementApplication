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

namespace admin1
{
    public partial class admin_profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["admin_name"] == null)
                    Response.Redirect("admin_login.aspx");
                else
                {
                    Response.ClearHeaders();
                    Response.AddHeader("Cache-Control", "no-cache, no-store, max-age=0, must-revalidate");
                    Response.AddHeader("Pragma", "no-cache");
                }
            }
            if (!string.IsNullOrEmpty(Session["admin_name"] as string))
            {
                using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                {


                    SqlDataReader reader2;
                    cn.Open();
                    String querystr2 = "select * from admin_access,designation where admin_access.access_id=@access_id and designation.designation_id=@d_id";

                    SqlCommand cmd2 = new SqlCommand(querystr2, cn);

                    cmd2.Parameters.AddWithValue("@access_id", Convert.ToInt32(Session["admin_access_id"]));
                    cmd2.Parameters.AddWithValue("@d_id", Convert.ToInt32(Session["admin_designation_id"]));

                    reader2 = cmd2.ExecuteReader();


                    while (reader2.HasRows && reader2.Read())
                    {
                        Session["admin_designation"] = reader2.GetString(reader2.GetOrdinal("designation_title"));
                        Session["admin_access"] = reader2.GetString(reader2.GetOrdinal("access"));

                    }
                    reader2.Close();
                    cn.Close();
                }
                name.Text = Session["admin_name"].ToString();
                designation.Text = Session["admin_designation"].ToString();
                access.Text = Session["admin_access"].ToString();
                uemial.Text = Session["admin_uemail"].ToString();
                pemail.Text = Session["admin_pemail"].ToString();
                phone.Text = "0"+Session["admin_phone"].ToString();
                ext.Text = Session["admin_ext"].ToString();
                address.Text = Session["admin_address"].ToString();
                Literal1.Text = " "+Session["admin_name"].ToString()+" ";
                Literal2.Text = Session["admin_uemail"].ToString();
                Literal3.Text = Session["admin_designation"].ToString();

            }
            else
            {
                Response.Redirect("admin_login.aspx");
            }
        }
    }
}