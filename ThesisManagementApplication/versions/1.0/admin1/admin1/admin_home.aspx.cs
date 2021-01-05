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
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM;Integrated Security=True");
            int phone = Convert.ToInt32(Request.Form["phone"]);
            int regno = Convert.ToInt32(Request.Form["regnum"]);

            String enrollment = "01-134132-048";
            String fname = "Ahmad";
            String lname = "Ghafoor";
            String Program = "MSCS";
            String pemail = "ahmad31102@gmail.com";
            String uemail = "01-134132-048@student.bahria.edu.pk";
            //int phone = 333496838;
            String address = "House 4/2-E, Street 11, Sector G-7/2, Islamabad";
            int reg = 18401;
            String password = "Ahmad123";
            SqlCommand cmd = new SqlCommand("insert into student_personal_info(enrollment, first_name, last_name, program, personal_email, university_email, phone_number, address, registration_number, password) values (@enrollment,@first_name,@last_name,@program,@personal_email,@university_email,@phone_number,@address,@registration_number,@password)", con);
            cmd.Parameters.AddWithValue(@"enrollment", Request.Form["enrollment"]);
            cmd.Parameters.AddWithValue(@"first_name", Request.Form["fname"]);
            cmd.Parameters.AddWithValue(@"last_name", Request.Form["lname"]);
            cmd.Parameters.AddWithValue(@"program", Request.Form["program"]);
            cmd.Parameters.AddWithValue(@"personal_email", Request.Form["pemail"]);
            cmd.Parameters.AddWithValue(@"university_email", Request.Form["uemail"]);
            cmd.Parameters.AddWithValue(@"phone_number", phone);
            cmd.Parameters.AddWithValue(@"address", Request.Form["address"]);
            cmd.Parameters.AddWithValue(@"registration_number", regno);
            cmd.Parameters.AddWithValue(@"password", Request.Form["password"]);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
