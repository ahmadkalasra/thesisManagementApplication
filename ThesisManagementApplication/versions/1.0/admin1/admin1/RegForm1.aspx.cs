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
    public partial class RegForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");
            int phone1 = Convert.ToInt32(phone.Text);
            int regno = Convert.ToInt32(registration.Text);

            
            SqlCommand cmd = new SqlCommand("insert into student_personal_info(enrollment, first_name, last_name, program, personal_email, university_email, phone_number, address, registration_number, password) values (@enrollment,@first_name,@last_name,@program,@personal_email,@university_email,@phone_number,@address,@registration_number,@password)", con);
            cmd.Parameters.AddWithValue(@"enrollment", enrollment.Text);
            cmd.Parameters.AddWithValue(@"first_name", fname.Text);
            cmd.Parameters.AddWithValue(@"last_name", lname.Text);
            cmd.Parameters.AddWithValue(@"program", program.Items[program.SelectedIndex].Text);
            cmd.Parameters.AddWithValue(@"personal_email", pemail.Text);
            cmd.Parameters.AddWithValue(@"university_email", uemail.Text);
            cmd.Parameters.AddWithValue(@"phone_number", phone1);
            cmd.Parameters.AddWithValue(@"address", address.Text);
            cmd.Parameters.AddWithValue(@"registration_number", regno);
            cmd.Parameters.AddWithValue(@"password", password.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }

}