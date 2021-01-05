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
using System.Net.Mail;
using System.Threading;
using System.Security.Cryptography;

namespace admin1
{
    public partial class thesis_defense_evaluation_form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
            Panel6.Visible = false;
            Panel7.Visible = false;
            Panel8.Visible = false;
            Panel9.Visible = false;
            Panel26.Visible = false;
            Panel27.Visible = false;
            Panel28.Visible = false;
            Panel29.Visible = false;
            Panel30.Visible = false;

            if (Convert.ToString(Page.RouteData.Values["enrollment1212"]) == null || Convert.ToString(Page.RouteData.Values["ex_id12"]) == null || Convert.ToString(Page.RouteData.Values["keey12"]) == null)
            {

            }

            if (Page.RouteData.Values["enrollment1212"] != null && Page.RouteData.Values["ex_id12"] != null && Page.RouteData.Values["keey12"] != null)
            {
                using (SqlConnection cn45 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                {
                    SqlDataReader reader245;
                    cn45.Open();
                    String querystr245 = "select * from final_form_records where enrollment=@enroll and id=@id and keey=@key";

                    SqlCommand cmd245 = new SqlCommand(querystr245, cn45);

                    cmd245.Parameters.AddWithValue("@enroll", Convert.ToString(Page.RouteData.Values["enrollment1212"]));
                    cmd245.Parameters.AddWithValue("@id", Convert.ToString(Page.RouteData.Values["ex_id12"]));
                    cmd245.Parameters.AddWithValue("@key", Convert.ToString(Page.RouteData.Values["keey12"]));
                    reader245 = cmd245.ExecuteReader();

                    if (reader245.HasRows)
                    {
                        while (reader245.HasRows && reader245.Read())
                        {
                            if (!reader245.IsDBNull(reader245.GetOrdinal("enrollment")))
                            {
                                if (reader245.IsDBNull(reader245.GetOrdinal("result")) || reader245.GetString(reader245.GetOrdinal("result")) == "Condition")
                                {
                                    Session["final_evaluation_examiner_name"] = reader245.GetString(reader245.GetOrdinal("examiner_name"));
                                    
                                    using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                                    {
                                        SqlDataReader reader2;
                                        cn.Open();
                                        String querystr2 = "select * from student_personal_info inner join student_thesis_info on student_thesis_info.enrollment=student_personal_info.enrollment where student_personal_info.enrollment=@enroll";

                                        SqlCommand cmd2 = new SqlCommand(querystr2, cn);

                                        cmd2.Parameters.AddWithValue("@enroll", Convert.ToString(Page.RouteData.Values["enrollment1212"]));
                                        reader2 = cmd2.ExecuteReader();
                                        while (reader2.HasRows && reader2.Read())
                                        {
                                            string n1 = reader2.GetString(reader2.GetOrdinal("first_name"));
                                            string n2 = reader2.GetString(reader2.GetOrdinal("last_name"));
                                            Session["final_evaluation_student_name"] = n1 + " " + n2;
                                            Session["final_evaluation_student_registration_num"] = reader2.GetInt32(reader2.GetOrdinal("registration_number"));
                                            Session["final_evaluation_student_registration_program"] = reader2.GetString(reader2.GetOrdinal("program"));
                                            Session["final_evaluation_student_registration_thesis_title"] = reader2.GetString(reader2.GetOrdinal("research_area"));
                                        }
                                        reader2.Close();
                                        cn.Close();
                                    }

                                    sname.Text = Session["final_evaluation_student_name"].ToString();
                                    Literal1.Text = Session["final_evaluation_student_registration_num"].ToString();
                                    Literal2.Text = Session["final_evaluation_student_registration_program"].ToString();
                                    Literal5.Text = Session["final_evaluation_student_registration_thesis_title"].ToString();
                                    Literal6.Text = Session["final_evaluation_examiner_name"].ToString();
                                }
                                else
                                {
                                    Panel1.Visible = false;
                                    Panel29.Visible = true;
                                }
                            }

                            else
                            {
                                Panel1.Visible = false;
                                Panel29.Visible = true;
                            }
                        }
                    }
                    else
                    {
                        Panel1.Visible = false;
                        Panel29.Visible = true;
                    }
                        
                    reader245.Close();
                    cn45.Close();
                }
                
            }
        }

        public static void Send(string from, string password, string to, string Message, string subject, string host, int port, String ccc)
        {

            MailMessage email = new MailMessage();
            email.From = new MailAddress(from);
            email.To.Add(to);
            email.CC.Add(ccc);
            email.Subject = subject;
            email.Body = Message;
            SmtpClient smtp = new SmtpClient(host, port);
            smtp.UseDefaultCredentials = false;
            NetworkCredential nc = new NetworkCredential(from, password);
            smtp.Credentials = nc;
            smtp.EnableSsl = true;
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;
            email.BodyEncoding = Encoding.UTF8;
            

            smtp.Send(email);
        }
        protected void setup_thesis_defense(object sender, EventArgs e)
        {
            if (TextBox1.Text == string.Empty)
            {
                Panel2.Visible = true;
            }
            if (TextBox1.Text != string.Empty && Convert.ToDouble(TextBox1.Text) > 50.0)
            {
                Panel3.Visible = true;
            }
            if (TextBox2.Text == string.Empty)
            {
                Panel4.Visible = true;
            }
            if (TextBox2.Text != string.Empty && Convert.ToDouble(TextBox2.Text) > 25.0)
            {
                Panel5.Visible = true;
            }
            if (TextBox3.Text == string.Empty)
            {
                Panel6.Visible = true;
            }
            if (TextBox3.Text != string.Empty && Convert.ToDouble(TextBox3.Text) > 25.0)
            {
                Panel7.Visible = true;
            }
            if (RadioButtonList1.SelectedValue == "")
            {
                Panel9.Visible = true;
            }
            if (TextArea1.InnerText == string.Empty)
            {
                Panel8.Visible = true;
            }
            if (TextBox1.Text != string.Empty && Convert.ToDouble(TextBox1.Text) <= 50.0 && TextBox2.Text != string.Empty && Convert.ToDouble(TextBox2.Text) <= 25.0 && TextBox3.Text != string.Empty && Convert.ToDouble(TextBox3.Text) <= 25.0 && RadioButtonList1.SelectedValue != "" && RadioButtonList1.SelectedValue == "1" && TextArea1.InnerText != string.Empty)
            {

                //get examiner email address
                string ex_email = "";
                using (SqlConnection cn2 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                {
                    SqlDataReader reader22;
                    cn2.Open();
                    String querystr22 = "select * from examiner where examiner_name=@name  ";
                    SqlCommand cmd22 = new SqlCommand(querystr22, cn2);
                    cmd22.Parameters.AddWithValue("@name", Session["final_evaluation_examiner_name"].ToString());
                    reader22 = cmd22.ExecuteReader();
                    while (reader22.HasRows && reader22.Read())
                    {
                        ex_email = reader22.GetString(reader22.GetOrdinal("official_email"));
                    }
                    reader22.Close();
                    cn2.Close();
                }

                if (Convert.ToString(Page.RouteData.Values["ex_id12"]) == "1")
                {
                    using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                    {
                        SqlDataReader reader2;
                        cn.Open();
                        String querystr2 = "select * from final_form_records where enrollment=@enroll and id=@key ";

                        SqlCommand cmd2 = new SqlCommand(querystr2, cn);
                        cmd2.Parameters.AddWithValue("@enroll", Convert.ToString(Page.RouteData.Values["enrollment1212"]));
                        cmd2.Parameters.AddWithValue("@key", 2);
                        reader2 = cmd2.ExecuteReader();
                        while (reader2.HasRows && reader2.Read())
                        {
                            if (!reader2.IsDBNull(reader2.GetOrdinal("result")))
                            {
                                if (!reader2.IsDBNull(reader2.GetOrdinal("result")) && reader2.GetString(reader2.GetOrdinal("result")) == "Recommended")
                                {
                                    //update final_form_records 
                                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");
                                    SqlCommand cmd = new SqlCommand(" update final_form_records set quality=@quality, presentation=@presentation, viva=@viva, comments=@com, result=@result, total_num=@total where enrollment=@enroll and id=@id and keey=@key ", con);
                                    cmd.Parameters.AddWithValue(@"quality", Convert.ToDecimal(TextBox1.Text));
                                    cmd.Parameters.AddWithValue(@"presentation", Convert.ToDecimal(TextBox2.Text));
                                    cmd.Parameters.AddWithValue(@"viva", Convert.ToDecimal(TextBox3.Text));
                                    cmd.Parameters.AddWithValue(@"com", TextArea1.InnerText);
                                    cmd.Parameters.AddWithValue(@"result", "Recommended");
                                    double x = Convert.ToDouble(TextBox1.Text) + Convert.ToDouble(TextBox2.Text) + Convert.ToDouble(TextBox3.Text);
                                    cmd.Parameters.AddWithValue(@"total", Convert.ToDecimal(x));
                                    cmd.Parameters.AddWithValue(@"enroll", Convert.ToString(Page.RouteData.Values["enrollment1212"]));
                                    cmd.Parameters.AddWithValue(@"id", Convert.ToString(Page.RouteData.Values["ex_id12"]));
                                    cmd.Parameters.AddWithValue(@"key", Convert.ToString(Page.RouteData.Values["keey12"]));
                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                    con.Close();


                                    //update thesis status 
                                    SqlConnection con1 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");
                                    SqlCommand cmd1 = new SqlCommand(" update thesis set status_id=@s_id where enrollment=@enroll ", con1);
                                    cmd1.Parameters.AddWithValue(@"s_id", 4);
                                    cmd1.Parameters.AddWithValue(@"enroll", Convert.ToString(Page.RouteData.Values["enrollment1212"]));
                                    con1.Open();
                                    cmd1.ExecuteNonQuery();
                                    con1.Close();

                                    //send emails

                                    String from = "budrshehzad@gmail.com";
                                    String to = ex_email;
                                    String to1 = "ahmad311002@gmail.com";
                                    String ccc = "ahmad31102@gmail.com";
                                    String password = "Ahmad123";
                                    String Message1 = "Respected " + "<b>" + Session["final_evaluation_examiner_name"].ToString() + "</b>" + "," + "<br />" + "<br />" + "This is to inform you that you have been submitted the final evaluation form successfully. Thankyou for your time." + "<br />" + "Student Details are given Below." + "<br />" + "<br />" + "<b>Student Detials</b>" + "<br />" + "<b>Student Name : </b>" + Session["final_evaluation_student_name"].ToString()  + "<br />" + "<b>Program : </b>" + Session["final_evaluation_student_registration_num"].ToString()  + "<br />" + "<b>Enrollment : </b>" + Convert.ToString(Page.RouteData.Values["enrollment1212"]);
                                    String Message2 = "Dear " + "<b>" + Session["final_evaluation_student_name"].ToString() + "</b>" + "," + "<br />" + "<br />" + "This is to inform you that your thesis has been approved in final defense. Your result has been uploaded on thesis panel. ";
                                    String subject = "Examiner appointment for Thesis Defense";
                                    String host = "smtp.gmail.com";
                                    int port = 587;

                                    //official mail send
                                    Thread t = new Thread(() => Send(from, password, to, Message1, subject, host, port, ccc));
                                    t.Start();
                                    Thread t2 = new Thread(() => Send(from, password, to1, Message2, subject, host, port, ccc));
                                    t2.Start();
                                }
                                if (!reader2.IsDBNull(reader2.GetOrdinal("result")) && reader2.GetString(reader2.GetOrdinal("result")) == "Condition")
                                {
                                    //update final_form_records 
                                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");
                                    SqlCommand cmd = new SqlCommand(" update final_form_records set quality=@quality, presentation=@presentation, viva=@viva, comments=@com, result=@result, total_num=@total where enrollment=@enroll and id=@id and keey=@key ", con);
                                    cmd.Parameters.AddWithValue(@"quality", Convert.ToDecimal(TextBox1.Text));
                                    cmd.Parameters.AddWithValue(@"presentation", Convert.ToDecimal(TextBox2.Text));
                                    cmd.Parameters.AddWithValue(@"viva", Convert.ToDecimal(TextBox3.Text));
                                    cmd.Parameters.AddWithValue(@"com", TextArea1.InnerText);
                                    cmd.Parameters.AddWithValue(@"result", "Recommended");
                                    double x = Convert.ToDouble(TextBox1.Text) + Convert.ToDouble(TextBox2.Text) + Convert.ToDouble(TextBox3.Text);
                                    cmd.Parameters.AddWithValue(@"total", Convert.ToDecimal(x));
                                    cmd.Parameters.AddWithValue(@"enroll", Convert.ToString(Page.RouteData.Values["enrollment1212"]));
                                    cmd.Parameters.AddWithValue(@"id", Convert.ToString(Page.RouteData.Values["ex_id12"]));
                                    cmd.Parameters.AddWithValue(@"key", Convert.ToString(Page.RouteData.Values["keey12"]));
                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                    con.Close();

                                    //send emails

                                    String from = "budrshehzad@gmail.com";
                                    String to = ex_email;
                                    String ccc = "ahmad31102@gmail.com";
                                    String password = "Ahmad123";
                                    String Message1 = "Respected " + "<b>" + Session["final_evaluation_examiner_name"].ToString() + "</b>" + "," + "<br />" + "<br />" + "This is to inform you that you have been submitted the final evaluation form successfully. Thankyou for your time." + "<br />" + "Student Details are given Below." + "<br />" + "<br />" + "<b>Student Detials</b>" + "<br />" + "<b>Student Name : </b>" + Session["final_evaluation_student_name"].ToString()  + "<br />" + "<b>Program : </b>" + Session["final_evaluation_student_registration_num"].ToString() + "<br />" + "<b>Enrollment : </b>" +  Convert.ToString(Page.RouteData.Values["enrollment1212"]);
                                    String subject = "Defense Evaluation Form Submission Alert";
                                    String host = "smtp.gmail.com";
                                    int port = 587;

                                    //official mail send
                                    Thread t = new Thread(() => Send(from, password, to, Message1, subject, host, port, ccc));
                                    t.Start();
                                }
                                if (!reader2.IsDBNull(reader2.GetOrdinal("result")) && reader2.GetString(reader2.GetOrdinal("result")) == "Rejected")
                                {
                                    //update final_form_records 
                                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");
                                    SqlCommand cmd = new SqlCommand(" update final_form_records set quality=@quality, presentation=@presentation, viva=@viva, comments=@com, result=@result, total_num=@total where enrollment=@enroll and id=@id and keey=@key ", con);
                                    cmd.Parameters.AddWithValue(@"quality", Convert.ToDecimal(TextBox1.Text));
                                    cmd.Parameters.AddWithValue(@"presentation", Convert.ToDecimal(TextBox2.Text));
                                    cmd.Parameters.AddWithValue(@"viva", Convert.ToDecimal(TextBox3.Text));
                                    cmd.Parameters.AddWithValue(@"com", TextArea1.InnerText);
                                    cmd.Parameters.AddWithValue(@"result", "Recommended");
                                    double x = Convert.ToDouble(TextBox1.Text) + Convert.ToDouble(TextBox2.Text) + Convert.ToDouble(TextBox3.Text);
                                    cmd.Parameters.AddWithValue(@"total", Convert.ToDecimal(x));
                                    cmd.Parameters.AddWithValue(@"enroll", Convert.ToString(Page.RouteData.Values["enrollment1212"]));
                                    cmd.Parameters.AddWithValue(@"id", Convert.ToString(Page.RouteData.Values["ex_id12"]));
                                    cmd.Parameters.AddWithValue(@"key", Convert.ToString(Page.RouteData.Values["keey12"]));
                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                    con.Close();

                                    //send emails

                                    String from = "budrshehzad@gmail.com";
                                    String to = ex_email;
                                    String ccc = "ahmad31102@gmail.com";
                                    String password = "Ahmad123";
                                    String Message1 = "Respected " + "<b>" + Session["final_evaluation_examiner_name"].ToString() + "</b>" + "," + "<br />" + "<br />" + "This is to inform you that you have been submitted the final evaluation form successfully. Thankyou for your time." + "<br />" + "Student Details are given Below." + "<br />" + "<br />" + "<b>Student Detials</b>" + "<br />" + "<b>Student Name : </b>" + Session["final_evaluation_student_name"].ToString() + "<br />" + "<b>Program : </b>" + Session["final_evaluation_student_registration_num"].ToString() + "<br />" + "<b>Enrollment : </b>" + Convert.ToString(Page.RouteData.Values["enrollment1212"]);
                                    String subject = "Defense Evaluation Form Submission Alert";
                                    String host = "smtp.gmail.com";
                                    int port = 587;

                                    //official mail send
                                    Thread t = new Thread(() => Send(from, password, to, Message1, subject, host, port, ccc));
                                    t.Start();
                                }
                            }
                            else
                            {
                                //update final_form_records 
                                SqlConnection con = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");
                                SqlCommand cmd = new SqlCommand(" update final_form_records set quality=@quality, presentation=@presentation, viva=@viva, comments=@com, result=@result, total_num=@total where enrollment=@enroll and id=@id and keey=@key ", con);
                                cmd.Parameters.AddWithValue(@"quality", Convert.ToDecimal(TextBox1.Text));
                                cmd.Parameters.AddWithValue(@"presentation", Convert.ToDecimal(TextBox2.Text));
                                cmd.Parameters.AddWithValue(@"viva", Convert.ToDecimal(TextBox3.Text));
                                cmd.Parameters.AddWithValue(@"com", TextArea1.InnerText);
                                cmd.Parameters.AddWithValue(@"result", "Recommended");
                                double x = Convert.ToDouble(TextBox1.Text) + Convert.ToDouble(TextBox2.Text) + Convert.ToDouble(TextBox3.Text);
                                cmd.Parameters.AddWithValue(@"total", Convert.ToDecimal(x));
                                cmd.Parameters.AddWithValue(@"enroll", Convert.ToString(Page.RouteData.Values["enrollment1212"]));
                                cmd.Parameters.AddWithValue(@"id", Convert.ToString(Page.RouteData.Values["ex_id12"]));
                                cmd.Parameters.AddWithValue(@"key", Convert.ToString(Page.RouteData.Values["keey12"]));
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();

                                //send emails

                                String from = "budrshehzad@gmail.com";
                                String to = ex_email;
                                String ccc = "ahmad31102@gmail.com";
                                String password = "Ahmad123";
                                String Message1 = "Respected " + "<b>" + Session["final_evaluation_examiner_name"].ToString() + "</b>" + "," + "<br />" + "<br />" + "This is to inform you that you have been submitted the final evaluation form successfully. Thankyou for your time." + "<br />" + "Student Details are given Below." + "<br />" + "<br />" + "<b>Student Detials</b>" + "<br />" + "<b>Student Name : </b>" + Session["final_evaluation_student_name"].ToString() + "<br />" + "<b>Program : </b>" + Session["final_evaluation_student_registration_num"].ToString() + "<br />" + "<b>Enrollment : </b>" + Convert.ToString(Page.RouteData.Values["enrollment1212"]);
                                String subject = "Defense Evaluation Form Submission Alert";
                                String host = "smtp.gmail.com";
                                int port = 587;

                                //official mail send
                                Thread t = new Thread(() => Send(from, password, to, Message1, subject, host, port, ccc));
                                t.Start();
                            }
                            Panel1.Visible = false;
                            Panel30.Visible = true;
                        }
                        reader2.Close();
                        cn.Close();
                    }
                }
                if (Convert.ToString(Page.RouteData.Values["ex_id12"]) == "2")
                {
                    using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                    {
                        SqlDataReader reader2;
                        cn.Open();
                        String querystr2 = "select * from final_form_records where enrollment=@enroll and id=1 ";

                        SqlCommand cmd2 = new SqlCommand(querystr2, cn);
                        cmd2.Parameters.AddWithValue("@enroll", Convert.ToString(Page.RouteData.Values["enrollment1212"]));
                        reader2 = cmd2.ExecuteReader();
                        while (reader2.HasRows && reader2.Read())
                        {
                            if (!reader2.IsDBNull(reader2.GetOrdinal("result")) && reader2.GetString(reader2.GetOrdinal("result")) == "Recommended")
                            {
                                //update final_form_records 
                                SqlConnection con = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");
                                SqlCommand cmd = new SqlCommand(" update final_form_records set quality=@quality, presentation=@presentation, viva=@viva, comments=@com, result=@result, total_num=@total where enrollment=@enroll and id=@id and keey=@key ", con);
                                cmd.Parameters.AddWithValue(@"quality", Convert.ToDecimal(TextBox1.Text));
                                cmd.Parameters.AddWithValue(@"presentation", Convert.ToDecimal(TextBox2.Text));
                                cmd.Parameters.AddWithValue(@"viva", Convert.ToDecimal(TextBox3.Text));
                                cmd.Parameters.AddWithValue(@"com", TextArea1.InnerText);
                                cmd.Parameters.AddWithValue(@"result", "Recommended");
                                double x = Convert.ToDouble(TextBox1.Text) + Convert.ToDouble(TextBox2.Text) + Convert.ToDouble(TextBox3.Text);
                                cmd.Parameters.AddWithValue(@"total", Convert.ToDecimal(x));
                                cmd.Parameters.AddWithValue(@"enroll", Convert.ToString(Page.RouteData.Values["enrollment1212"]));
                                cmd.Parameters.AddWithValue(@"id", Convert.ToString(Page.RouteData.Values["ex_id12"]));
                                cmd.Parameters.AddWithValue(@"key", Convert.ToString(Page.RouteData.Values["keey12"]));
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();


                                //update thesis status 
                                SqlConnection con1 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");
                                SqlCommand cmd1 = new SqlCommand(" update thesis set status_id=@s_id where enrollment=@enroll ", con1);
                                cmd1.Parameters.AddWithValue(@"s_id", 4);
                                cmd1.Parameters.AddWithValue(@"enroll", Convert.ToString(Page.RouteData.Values["enrollment1212"]));
                                con1.Open();
                                cmd1.ExecuteNonQuery();
                                con1.Close();

                                //send emails

                                String from = "budrshehzad@gmail.com";
                                String to = ex_email;
                                String to1 = "ahmad311002@gmail.com";
                                String ccc = "ahmad31102@gmail.com";
                                String password = "Ahmad123";
                                String Message1 = "Respected " + "<b>" + Session["final_evaluation_examiner_name"].ToString() + "</b>" + "," + "<br />" + "<br />" + "This is to inform you that you have been submitted the final evaluation form successfully. Thankyou for your time." + "<br />" + "Student Details are given Below." + "<br />" + "<br />" + "<b>Student Detials</b>" + "<br />" + "<b>Student Name : </b>" + Session["final_evaluation_student_name"].ToString() + "<br />" + "<b>Program : </b>" + Session["final_evaluation_student_registration_num"].ToString() + "<br />" + "<b>Enrollment : </b>" + Convert.ToString(Page.RouteData.Values["enrollment1212"]);
                                String Message2 = "Dear " + "<b>" + Session["final_evaluation_student_name"].ToString() + "</b>" + "," + "<br />" + "<br />" + "This is to inform you that your thesis has been approved in final defense. Your result has been uploaded on thesis panel. ";
                                String subject = "Examiner appointment for Thesis Defense";
                                String host = "smtp.gmail.com";
                                int port = 587;

                                //official mail send
                                Thread t = new Thread(() => Send(from, password, to, Message1, subject, host, port, ccc));
                                t.Start();
                                Thread t2 = new Thread(() => Send(from, password, to1, Message2, subject, host, port, ccc));
                                t2.Start();
                                Panel1.Visible = false;
                                Panel30.Visible = true;
                            }
                            if (!reader2.IsDBNull(reader2.GetOrdinal("result")) && (reader2.GetString(reader2.GetOrdinal("result")) == "Condition" || reader2.GetString(reader2.GetOrdinal("result")) == "Rejected"))
                            {
                                //update final_form_records 
                                SqlConnection con = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");
                                SqlCommand cmd = new SqlCommand(" update final_form_records set quality=@quality, presentation=@presentation, viva=@viva, comments=@com, result=@result, total_num=@total where enrollment=@enroll and id=@id and keey=@key ", con);
                                cmd.Parameters.AddWithValue(@"quality", Convert.ToDecimal(TextBox1.Text));
                                cmd.Parameters.AddWithValue(@"presentation", Convert.ToDecimal(TextBox2.Text));
                                cmd.Parameters.AddWithValue(@"viva", Convert.ToDecimal(TextBox3.Text));
                                cmd.Parameters.AddWithValue(@"com", TextArea1.InnerText);
                                cmd.Parameters.AddWithValue(@"result", "Recommended");
                                double x = Convert.ToDouble(TextBox1.Text) + Convert.ToDouble(TextBox2.Text) + Convert.ToDouble(TextBox3.Text);
                                cmd.Parameters.AddWithValue(@"total", Convert.ToDecimal(x));
                                cmd.Parameters.AddWithValue(@"enroll", Convert.ToString(Page.RouteData.Values["enrollment1212"]));
                                cmd.Parameters.AddWithValue(@"id", Convert.ToString(Page.RouteData.Values["ex_id12"]));
                                cmd.Parameters.AddWithValue(@"key", Convert.ToString(Page.RouteData.Values["keey12"]));
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();

                                //send emails

                                String from = "budrshehzad@gmail.com";
                                String to = ex_email;
                                String ccc = "ahmad31102@gmail.com";
                                String password = "Ahmad123";
                                String Message1 = "Respected " + "<b>" + Session["final_evaluation_examiner_name"].ToString() + "</b>" + "," + "<br />" + "<br />" + "This is to inform you that you have been submitted the final evaluation form successfully. Thankyou for your time." + "<br />" + "Student Details are given Below." + "<br />" + "<br />" + "<b>Student Detials</b>" + "<br />" + "<b>Student Name : </b>" + Session["final_evaluation_student_name"].ToString() + "<br />" + "<b>Program : </b>" + Session["final_evaluation_student_registration_num"].ToString() + "<br />" + "<b>Enrollment : </b>" + Convert.ToString(Page.RouteData.Values["enrollment1212"]);
                                String subject = "Defense Evaluation Form Submission Alert";
                                String host = "smtp.gmail.com";
                                int port = 587;

                                //official mail send
                                Thread t = new Thread(() => Send(from, password, to, Message1, subject, host, port, ccc));
                                t.Start();

                                Panel1.Visible = false;
                                Panel30.Visible = true;
                            }
                            if (reader2.IsDBNull(reader2.GetOrdinal("result")))
                            {
                                //update final_form_records 
                                SqlConnection con = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");
                                SqlCommand cmd = new SqlCommand(" update final_form_records set quality=@quality, presentation=@presentation, viva=@viva, comments=@com, result=@result, total_num=@total where enrollment=@enroll and id=@id and keey=@key ", con);
                                cmd.Parameters.AddWithValue(@"quality", Convert.ToDecimal(TextBox1.Text));
                                cmd.Parameters.AddWithValue(@"presentation", Convert.ToDecimal(TextBox2.Text));
                                cmd.Parameters.AddWithValue(@"viva", Convert.ToDecimal(TextBox3.Text));
                                cmd.Parameters.AddWithValue(@"com", TextArea1.InnerText);
                                cmd.Parameters.AddWithValue(@"result", "Recommended");
                                double x = Convert.ToDouble(TextBox1.Text) + Convert.ToDouble(TextBox2.Text) + Convert.ToDouble(TextBox3.Text);
                                cmd.Parameters.AddWithValue(@"total", Convert.ToDecimal(x));
                                cmd.Parameters.AddWithValue(@"enroll", Convert.ToString(Page.RouteData.Values["enrollment1212"]));
                                cmd.Parameters.AddWithValue(@"id", Convert.ToString(Page.RouteData.Values["ex_id12"]));
                                cmd.Parameters.AddWithValue(@"key", Convert.ToString(Page.RouteData.Values["keey12"]));
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();

                                //send emails

                                String from = "budrshehzad@gmail.com";
                                String to = ex_email;
                                String ccc = "ahmad31102@gmail.com";
                                String password = "Ahmad123";
                                String Message1 = "Respected " + "<b>" + Session["final_evaluation_examiner_name"].ToString() + "</b>" + "," + "<br />" + "<br />" + "This is to inform you that you have been submitted the final evaluation form successfully. Thankyou for your time." + "<br />" + "Student Details are given Below." + "<br />" + "<br />" + "<b>Student Detials</b>" + "<br />" + "<b>Student Name : </b>" + Session["final_evaluation_student_name"].ToString() + "<br />" + "<b>Program : </b>" + Session["final_evaluation_student_registration_num"].ToString() + "<br />" + "<b>Enrollment : </b>" + Convert.ToString(Page.RouteData.Values["enrollment1212"]);
                                String subject = "Defense Evaluation Form Submission Alert";
                                String host = "smtp.gmail.com";
                                int port = 587;

                                //official mail send
                                Thread t = new Thread(() => Send(from, password, to, Message1, subject, host, port, ccc));
                                t.Start();
                                Panel1.Visible = false;
                                Panel30.Visible = true;
                            }
                        }
                        reader2.Close();
                        cn.Close();

                    }
                }
            }
            if (TextBox1.Text != string.Empty && Convert.ToDouble(TextBox1.Text) <= 50.0 && TextBox2.Text != string.Empty && Convert.ToDouble(TextBox2.Text) <= 25.0 && TextBox3.Text != string.Empty && Convert.ToDouble(TextBox3.Text) <= 25.0 && RadioButtonList1.SelectedValue != "" && RadioButtonList1.SelectedValue == "2" && TextArea1.InnerText != string.Empty)
            {
                //get examiner email address
                string ex_email = "";
                using (SqlConnection cn2 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                {
                    SqlDataReader reader22;
                    cn2.Open();
                    String querystr22 = "select * from examiner where examiner_name=@name  ";
                    SqlCommand cmd22 = new SqlCommand(querystr22, cn2);
                    cmd22.Parameters.AddWithValue("@name", Session["final_evaluation_examiner_name"].ToString());
                    reader22 = cmd22.ExecuteReader();
                    while (reader22.HasRows && reader22.Read())
                    {
                        ex_email = reader22.GetString(reader22.GetOrdinal("official_email"));
                    }
                    reader22.Close();
                    cn2.Close();
                }
                //////random key

                char[] chars = new char[62];
                chars =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
                byte[] data = new byte[1];
                using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
                {
                    crypto.GetNonZeroBytes(data);
                    data = new byte[8];
                    crypto.GetNonZeroBytes(data);
                }
                StringBuilder result = new StringBuilder(8);
                foreach (byte b in data)
                {
                    result.Append(chars[b % (chars.Length)]);
                }
                //update final_form_records 
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");
                SqlCommand cmd = new SqlCommand(" update final_form_records set quality=@quality, presentation=@presentation, viva=@viva, comments=@com, result=@result, total_num=@total, keey=@key1 where enrollment=@enroll and id=@id and keey=@key ", con);
                cmd.Parameters.AddWithValue(@"quality", Convert.ToDecimal(TextBox1.Text));
                cmd.Parameters.AddWithValue(@"presentation", Convert.ToDecimal(TextBox2.Text));
                cmd.Parameters.AddWithValue(@"viva", Convert.ToDecimal(TextBox3.Text));
                cmd.Parameters.AddWithValue(@"com", TextArea1.InnerText);
                cmd.Parameters.AddWithValue(@"result", "Condition");
                double x = Convert.ToDouble(TextBox1.Text) + Convert.ToDouble(TextBox2.Text) + Convert.ToDouble(TextBox3.Text);
                cmd.Parameters.AddWithValue(@"total", Convert.ToDecimal(x));
                cmd.Parameters.AddWithValue(@"key1", result.ToString());
                cmd.Parameters.AddWithValue(@"enroll", Convert.ToString(Page.RouteData.Values["enrollment1212"]));
                cmd.Parameters.AddWithValue(@"id", Convert.ToString(Page.RouteData.Values["ex_id12"]));
                cmd.Parameters.AddWithValue(@"key", Convert.ToString(Page.RouteData.Values["keey12"]));
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                //update thesis status 
                SqlConnection con1 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");
                SqlCommand cmd1 = new SqlCommand(" update thesis set status_id=@s_id where enrollment=@enroll ", con1);
                cmd1.Parameters.AddWithValue(@"s_id", 5);
                cmd1.Parameters.AddWithValue(@"enroll", Convert.ToString(Page.RouteData.Values["enrollment1212"]));
                con1.Open();
                cmd1.ExecuteNonQuery();
                con1.Close();

                //send emails

                String from = "budrshehzad@gmail.com";
                String to = ex_email;
                String to1 = "ahmad311002@gmail.com";
                String ccc = "ahmad31102@gmail.com";
                String password = "Ahmad123";
                String Message1 = "Respected " + "<b>" + Session["final_evaluation_examiner_name"].ToString() + "</b>" + "," + "<br />" + "<br />" + "This is to inform you that you have been submitted the final evaluation form successfully. Thankyou for your time." + "<br />" + "Student Details are given Below." + "<br />" + "<br />" + "<b>Student Detials</b>" + "<br />" + "<b>Student Name : </b>" + Session["final_evaluation_student_name"].ToString() + "<br />" + "<b>Program : </b>" + Session["final_evaluation_student_registration_num"].ToString() + "<br />" + "<b>Enrollment : </b>" + Convert.ToString(Page.RouteData.Values["enrollment1212"]) + "<br />" + "<br />" + "<b>Kindly submit this evaluation form again using the link given below after changes you mention.</b>" + "<br />" + "http://localhost:21315/thesis_defense_evaluation_form" + "/" + Convert.ToString(Page.RouteData.Values["enrollment1212"]) + "/" + Convert.ToString(Page.RouteData.Values["ex_id12"]) + "/" + result.ToString() + ".aspx";
                String Message2 = "Dear " + "<b>" + Convert.ToString(Session["proposal_defense_student_name"]) + "</b>" + "," + "<br />" + "<br />" + "This is to inform you that your thesis has been conditionaly approved. Kindly upload thesis after changes mentioned by the examiner." + "<br />";
                String subject = "Defense Evaluation Form Submission Alert";
                String subject1 = "Thesis Defense Notification";
                String host = "smtp.gmail.com";
                int port = 587;

                //official mail send
                Thread t = new Thread(() => Send(from, password, to, Message1, subject, host, port, ccc));
                t.Start();
                Thread t1 = new Thread(() => Send(from, password, to1, Message2, subject1, host, port, ccc));
                t1.Start();

                Panel1.Visible = false;
                Panel30.Visible = true;
            }
            if (TextBox1.Text != string.Empty && Convert.ToDouble(TextBox1.Text) <= 50.0 && TextBox2.Text != string.Empty && Convert.ToDouble(TextBox2.Text) <= 25.0 && TextBox3.Text != string.Empty && Convert.ToDouble(TextBox3.Text) <= 25.0 && RadioButtonList1.SelectedValue != "" && RadioButtonList1.SelectedValue == "3" && TextArea1.InnerText != string.Empty)
            {
                //get examiner email address
                string ex_email = "";
                using (SqlConnection cn2 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                {
                    SqlDataReader reader22;
                    cn2.Open();
                    String querystr22 = "select * from examiner where examiner_name=@name  ";
                    SqlCommand cmd22 = new SqlCommand(querystr22, cn2);
                    cmd22.Parameters.AddWithValue("@name", Session["final_evaluation_examiner_name"].ToString());
                    reader22 = cmd22.ExecuteReader();
                    while (reader22.HasRows && reader22.Read())
                    {
                        ex_email = reader22.GetString(reader22.GetOrdinal("official_email"));
                    }
                    reader22.Close();
                    cn2.Close();
                }
                //update final_form_records 
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");
                SqlCommand cmd = new SqlCommand(" update final_form_records set quality=@quality, presentation=@presentation, viva=@viva, comments=@com, result=@result, total_num=@total where enrollment=@enroll and id=@id and keey=@key ", con);
                cmd.Parameters.AddWithValue(@"quality", Convert.ToDecimal(TextBox1.Text));
                cmd.Parameters.AddWithValue(@"presentation", Convert.ToDecimal(TextBox2.Text));
                cmd.Parameters.AddWithValue(@"viva", Convert.ToDecimal(TextBox3.Text));
                cmd.Parameters.AddWithValue(@"com", TextArea1.InnerText);
                cmd.Parameters.AddWithValue(@"result", "Rejected");
                double x = Convert.ToDouble(TextBox1.Text) + Convert.ToDouble(TextBox2.Text) + Convert.ToDouble(TextBox3.Text);
                cmd.Parameters.AddWithValue(@"total", Convert.ToDecimal(x));
                cmd.Parameters.AddWithValue(@"enroll", Convert.ToString(Page.RouteData.Values["enrollment1212"]));
                cmd.Parameters.AddWithValue(@"id", Convert.ToString(Page.RouteData.Values["ex_id12"]));
                cmd.Parameters.AddWithValue(@"key", Convert.ToString(Page.RouteData.Values["keey12"]));
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                //send emails

                String from = "budrshehzad@gmail.com";
                String to = ex_email;
                String ccc = "ahmad31102@gmail.com";
                String password = "Ahmad123";
                String Message1 = "Respected " + "<b>" + Session["final_evaluation_examiner_name"].ToString() + "</b>" + "," + "<br />" + "<br />" + "This is to inform you that you have been submitted the final evaluation form successfully. Thankyou for your time." + "<br />" + "Student Details are given Below." + "<br />" + "<br />" + "<b>Student Detials</b>" + "<br />" + "<b>Student Name : </b>" + Convert.ToString(Session["proposal_defense_student_name"]) + "<br />" + "<b>Program : </b>" + Convert.ToString(Session["proposal_defense_student_program"]) + "<br />" + "<b>Enrollment : </b>" + Convert.ToString(Session["proposal_defense_student_enrollment"]);
                String subject = "Defense Evaluation Form Submission Alert";
                String host = "smtp.gmail.com";
                int port = 587;

                //official mail send
                Thread t = new Thread(() => Send(from, password, to, Message1, subject, host, port, ccc));
                t.Start();

                Panel1.Visible = false;
                Panel30.Visible = true;
            }
        }
    }
}