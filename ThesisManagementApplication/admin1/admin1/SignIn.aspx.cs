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
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void login_Click(object sender, EventArgs e)
        {
            Session["enrollmentglobal"] = "sds";
            using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
            {
                SqlDataReader reader;
                cn.Open();

                String enroll1 = enrollment.Text;
                String pass1 = password.Text;

                String querystr = "select * from student_personal_info where enrollment=@enroll and password=@pass  ";
            

                SqlCommand cmd = new SqlCommand(querystr, cn);

                cmd.Parameters.AddWithValue("@enroll", enroll1);
                cmd.Parameters.AddWithValue("@pass", pass1);

                reader = cmd.ExecuteReader();
                

                while (reader.HasRows && reader.Read())
                {
                    Session["enrollment"] = reader.GetString(reader.GetOrdinal("enrollment"));
                    String fname = reader.GetString(reader.GetOrdinal("first_name"));
                    String lname = reader.GetString(reader.GetOrdinal("last_name"));
                    Session["name"] = fname + lname;
                    Session["deptname"] = reader.GetString(reader.GetOrdinal("program"));
                    Session["pemail"] = reader.GetString(reader.GetOrdinal("personal_email"));
                    Session["uemail"] = reader.GetString(reader.GetOrdinal("university_email"));
                    Session["intake_semester"] = "MSCS-2015-17";
                    Session["father_name"] = "Abdul Ghafoor";
                    Session["class"] = reader.GetString(reader.GetOrdinal("program"));
                    Session["degree_duration"] = "2 Years";
                    Session["phone"] = "03334968386";
                    Session["phone2"] = reader.GetInt32(reader.GetOrdinal("phone_number"));
                    Session["address"] = reader.GetString(reader.GetOrdinal("address"));
                    Session["community_support_work"] = "Completed";
                    Session["registration_no"] = reader.GetInt32(reader.GetOrdinal("registration_number"));

                }

                if (reader.HasRows)
                {

                    Response.Redirect("new_student_profile.aspx");

                }
                else
                {
                    Response.Redirect("SignIn.aspx");
                }
                reader.Close();
                cn.Close();

                //---------------------------------------------
               
            }

        }
    }
}