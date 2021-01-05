using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace admin1
{
    public partial class admin_login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["admin_name"] as string))
            {
                Response.Redirect("admin_profile.aspx");
            }
        }

        protected void login_Click(object sender, EventArgs e)
        {
            Session["enrollmentglobal"] = "sds";
            using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
            {
                SqlDataReader reader;
                cn.Open();

                String enroll1 = username.Text;
                String pass1 = password.Text;

                String querystr = "select * from admin where username=@enroll and password=@pass  ";


                SqlCommand cmd = new SqlCommand(querystr, cn);

                cmd.Parameters.AddWithValue("@enroll", enroll1);
                cmd.Parameters.AddWithValue("@pass", pass1);

                reader = cmd.ExecuteReader();


                while (reader.HasRows && reader.Read())
                {
                    Session["admin_designation_id"] = reader.GetInt32(reader.GetOrdinal("designation_id"));
                    String fname = reader.GetString(reader.GetOrdinal("first_name"));
                    String lname = reader.GetString(reader.GetOrdinal("last_name"));
                    Session["admin_name"] = fname +" "+ lname;
                    Session["admin_Access_id"] = reader.GetInt32(reader.GetOrdinal("access_id"));
                    Session["admin_pemail"] = reader.GetString(reader.GetOrdinal("personal_email"));
                    Session["admin_uemail"] = reader.GetString(reader.GetOrdinal("university_email"));
                    Session["admin_phone"] = reader.GetDecimal(reader.GetOrdinal("phone"));
                    Session["admin_ext"] = reader.GetInt32(reader.GetOrdinal("extension"));
                    Session["admin_address"] = reader.GetString(reader.GetOrdinal("address"));
                }

                if (reader.HasRows)
                {
                    Response.Redirect("admin_profile.aspx");

                }
                else
                {
                    Response.Redirect("admin_login.aspx");
                }
                reader.Close();
                cn.Close();

                //---------------------------------------------

            }

        }
    }
}