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
    public partial class MS_10_Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["MS_10_2_result"] = "";
            Panel30.Visible = false;
            if ( Convert.ToString(Page.RouteData.Values["enrollment12"]) == null || Convert.ToString(Page.RouteData.Values["ex_id"]) == null || Convert.ToString(Page.RouteData.Values["keey"]) == null)
            {
                Panel1.Visible = false;
                Panel29.Visible = true;
            }
            else
            {
                Panel31.Visible = false;
                Panel32.Visible = false;
            if (Page.RouteData.Values["enrollment12"]!=null && Page.RouteData.Values["ex_id"] != null && Page.RouteData.Values["keey"] != null)
            {

                    using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                    {


                        SqlDataReader reader2;
                        cn.Open();
                        String querystr2 = "select * from proposal_evaluation_form_records where enrollment=@enroll and id=@id and keey=@keey  ";

                        SqlCommand cmd2 = new SqlCommand(querystr2, cn);
                        cmd2.Parameters.AddWithValue("@enroll", Convert.ToString(Page.RouteData.Values["enrollment12"]));
                        cmd2.Parameters.AddWithValue("@id", Convert.ToString(Page.RouteData.Values["ex_id"]));
                        cmd2.Parameters.AddWithValue("@keey", Convert.ToString(Page.RouteData.Values["keey"]));
                        reader2 = cmd2.ExecuteReader();

                        if (reader2.HasRows)
                        {
                            while(reader2.HasRows && reader2.Read())
                            {
                            
                            
                            if (reader2.IsDBNull(reader2.GetOrdinal("result")))
                            {


                                Panel1.Visible = true;
                                Panel29.Visible = false;
                                
                                using (SqlConnection cn1 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                                {


                                    SqlDataReader reader21;
                                    cn1.Open();
                                    String querystr21 = "select * from proposal inner join defense on defense.def_id=proposal.defense_id right join student_thesis_info on student_thesis_info.enrollment=@enroll right join student_personal_info on student_personal_info.enrollment=@enroll right join defense_examiner on defense_examiner.defense_id=proposal.defense_id where proposal.enrollment=@enroll";

                                    SqlCommand cmd21 = new SqlCommand(querystr21, cn1);

                                    cmd21.Parameters.AddWithValue("@enroll", Convert.ToString(Page.RouteData.Values["enrollment12"]));

                                    reader21 = cmd21.ExecuteReader();


                                    while (reader21.HasRows && reader21.Read())
                                    {

                                        if (!reader21.IsDBNull(reader21.GetOrdinal("date")))
                                        {
                                            String fname = reader21.GetString(reader21.GetOrdinal("first_name"));
                                            String lname = reader21.GetString(reader21.GetOrdinal("last_name"));
                                            Session["Form-10-student_name"] = fname + " " + lname;
                                            sname.Text = Session["Form-10-student_name"].ToString();
                                            Literal1.Text = Convert.ToString(reader21.GetInt32(reader21.GetOrdinal("registration_number")));
                                            Session["Form-10-student_program"]= Convert.ToString(reader21.GetString(reader21.GetOrdinal("program")));
                                            Literal2.Text = Session["Form-10-student_program"].ToString();
                                            Session["Form-10-"] = reader21.GetString(reader21.GetOrdinal("date"));
                                            Session["Form-10-research_title"] = reader21.GetString(reader21.GetOrdinal("research_area"));
                                            Literal5.Text = Session["Form-10-research_title"].ToString();

                                            ///////////////////////////////
                                            if (Convert.ToInt32(Page.RouteData.Values["ex_id"]) == 1)
                                            {
                                                Session["Form_10_expert_id"] = reader21.GetInt32(reader21.GetOrdinal("examiner_1_id"));
                                            }
                                            if (Convert.ToInt32(Page.RouteData.Values["ex_id"]) == 2)
                                            {
                                                Session["Form_10_expert_id"] = reader21.GetInt32(reader21.GetOrdinal("examiner_2_id"));
                                            }
                                            using (SqlConnection cn12 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                                            {


                                                SqlDataReader reader212;
                                                cn12.Open();
                                                String querystr212 = "select * from examiner where examiner_id=@id";

                                                SqlCommand cmd212 = new SqlCommand(querystr212, cn12);

                                                cmd212.Parameters.AddWithValue("@id", Convert.ToInt32(Session["Form_10_expert_id"]));

                                                reader212 = cmd212.ExecuteReader();


                                                while (reader212.HasRows && reader212.Read())
                                                {
                                                    Session["MS_10_Expert_Name"] = reader212.GetString(reader212.GetOrdinal("examiner_name"));
                                                    Literal6.Text = Session["MS_10_Expert_Name"].ToString();
                                                    DateTime dd = DateTime.Now;
                                                    string date = dd.ToString("dd/MM/yyyy");
                                                    Literal7.Text = date;
                                                }
                                                reader212.Close();
                                                cn12.Close();
                                            }
                                        }


                                    }
                                    reader21.Close();
                                    cn1.Close();
                                }
                            }
                            else
                            {
                                Panel1.Visible = false;
                                Panel29.Visible = true;
                            }
                            }
                            reader2.Close();
                            cn.Close();
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
            
                
            }
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
            Panel6.Visible = false;
            Panel7.Visible = false;
            Panel8.Visible = false;
            Panel9.Visible = false;
            Panel10.Visible = false;
            Panel11.Visible = false;
            Panel12.Visible = false;
            Panel13.Visible = false;
            Panel14.Visible = false;
            Panel15.Visible = false;
            Panel16.Visible = false;
            Panel17.Visible = false;
            Panel18.Visible = false;
            Panel19.Visible = false;
            Panel20.Visible = false;
            Panel21.Visible = false;
            Panel22.Visible = false;
            Panel23.Visible = false;
            Panel24.Visible = false;
            Panel25.Visible = false;
            Panel26.Visible = false;
            Panel27.Visible = false;
            Panel28.Visible = false;
        }


        protected void submit_form(object sender, EventArgs e)
        {
            if (!FileUpload1.HasFile && (TextBox1.Text != string.Empty || TextBox2.Text != string.Empty || TextBox3.Text != string.Empty || TextBox4.Text != string.Empty || TextBox5.Text != string.Empty || TextBox6.Text != string.Empty || TextBox7.Text != string.Empty || TextBox8.Text != string.Empty || TextBox9.Text != string.Empty || TextBox10.Text != string.Empty || TextBox11.Text != string.Empty || TextBox12.Text != string.Empty))
            {
                if (TextBox1.Text == string.Empty)
                {
                    Panel2.Visible = true;
                }
                if (TextBox1.Text != string.Empty && Convert.ToDouble(TextBox1.Text) > 3.0)
                {
                    Panel3.Visible = true;
                }
            }
            if (!FileUpload1.HasFile && (TextBox1.Text == string.Empty && TextBox2.Text == string.Empty && TextBox3.Text == string.Empty && TextBox4.Text == string.Empty && TextBox5.Text == string.Empty && TextBox6.Text == string.Empty && TextBox7.Text == string.Empty && TextBox8.Text == string.Empty && TextBox9.Text == string.Empty && TextBox10.Text == string.Empty && TextBox11.Text == string.Empty && TextBox12.Text == string.Empty))
            {
                Panel28.Visible = true;
            }
            if (FileUpload1.HasFile && (TextBox1.Text == string.Empty && TextBox2.Text == string.Empty && TextBox3.Text == string.Empty && TextBox4.Text == string.Empty && TextBox5.Text == string.Empty && TextBox6.Text == string.Empty && TextBox7.Text == string.Empty && TextBox8.Text == string.Empty && TextBox9.Text == string.Empty && TextBox10.Text == string.Empty && TextBox11.Text == string.Empty && TextBox12.Text == string.Empty))
            {
                
            }
            if (!FileUpload1.HasFile && ( TextArea1.InnerText!=string.Empty && TextBox1.Text != string.Empty && TextBox2.Text != string.Empty && TextBox3.Text != string.Empty && TextBox4.Text != string.Empty && TextBox5.Text != string.Empty && TextBox6.Text != string.Empty && TextBox7.Text != string.Empty && TextBox8.Text != string.Empty && TextBox9.Text != string.Empty && TextBox10.Text != string.Empty && TextBox11.Text != string.Empty && TextBox12.Text != string.Empty && Convert.ToDouble(TextBox1.Text) <= 3.0 && Convert.ToDouble(TextBox2.Text) <= 3.0 && Convert.ToDouble(TextBox3.Text) <= 3.0 && Convert.ToDouble(TextBox4.Text) <= 3.0 && Convert.ToDouble(TextBox5.Text) <= 3.0 && Convert.ToDouble(TextBox6.Text) <= 3.0 && Convert.ToDouble(TextBox7.Text) <= 3.0 && Convert.ToDouble(TextBox8.Text) <= 3.0 && Convert.ToDouble(TextBox9.Text) <= 3.0 && Convert.ToDouble(TextBox10.Text) <= 3.0 && Convert.ToDouble(TextBox11.Text) <= 3.0 && Convert.ToDouble(TextBox12.Text) <= 3.0))
            {
                if(RadioButtonList1.SelectedItem.Value=="1")
                {
                    DateTime dd = DateTime.Now;
                    string date = dd.ToString("dd/MM/yyyy");

                    decimal sum1 = Convert.ToDecimal(TextBox1.Text) + Convert.ToDecimal(TextBox2.Text) + Convert.ToDecimal(TextBox3.Text) + Convert.ToDecimal(TextBox4.Text) + Convert.ToDecimal(TextBox5.Text) + Convert.ToDecimal(TextBox6.Text) + Convert.ToDecimal(TextBox7.Text) + Convert.ToDecimal(TextBox8.Text) + Convert.ToDecimal(TextBox9.Text) + Convert.ToDecimal(TextBox10.Text) + Convert.ToDecimal(TextBox11.Text) + Convert.ToDecimal(TextBox12.Text);

                    SqlConnection con11 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");

                    String val11 = Session["class"] + "/" + Session["enrollment"] + "/" + Session["enrollment"] + ".pdf";

                    SqlCommand cmd11 = new SqlCommand("update proposal_evaluation_form_records set clarity=@clarity, depth=@depth, justification=@justification, assessment_elements=@assessment_elements, write_up=@write_up, back_literature=@back_literature, hypothesis=@hypothesis, methodology=@methodology, awareness=@awareness, demonstratoin=@demonstration, confidence=@confidence, answer_question=@answer_question, sum=@sum, supervisor_name=@supervisor_name, result=@result, submission_date=@submission_date, comments=@comments where enrollment=@enrollment and id=@id and keey=@keey", con11);
                    cmd11.Parameters.AddWithValue(@"enrollment", Convert.ToString(Page.RouteData.Values["enrollment12"]));
                    cmd11.Parameters.AddWithValue(@"id", Convert.ToInt32(Page.RouteData.Values["ex_id"]));
                    cmd11.Parameters.AddWithValue(@"clarity", Convert.ToDecimal(TextBox1.Text));
                    cmd11.Parameters.AddWithValue(@"depth", Convert.ToDecimal(TextBox2.Text));
                    cmd11.Parameters.AddWithValue(@"justification", Convert.ToDecimal(TextBox3.Text));
                    cmd11.Parameters.AddWithValue(@"assessment_elements", Convert.ToDecimal(TextBox4.Text));
                    cmd11.Parameters.AddWithValue(@"write_up", Convert.ToDecimal(TextBox5.Text));
                    cmd11.Parameters.AddWithValue(@"back_literature", Convert.ToDecimal(TextBox6.Text));
                    cmd11.Parameters.AddWithValue(@"hypothesis", Convert.ToDecimal(TextBox7.Text));
                    cmd11.Parameters.AddWithValue(@"methodology", Convert.ToDecimal(TextBox8.Text));
                    cmd11.Parameters.AddWithValue(@"awareness", Convert.ToDecimal(TextBox9.Text));
                    cmd11.Parameters.AddWithValue(@"demonstration", Convert.ToDecimal(TextBox10.Text));
                    cmd11.Parameters.AddWithValue(@"confidence", Convert.ToDecimal(TextBox11.Text));
                    cmd11.Parameters.AddWithValue(@"answer_question", Convert.ToDecimal(TextBox12.Text));
                    cmd11.Parameters.AddWithValue(@"sum", sum1);
                    cmd11.Parameters.AddWithValue(@"supervisor_name", Session["MS_10_Expert_Name"].ToString());
                    cmd11.Parameters.AddWithValue(@"result", "Recommended");
                    cmd11.Parameters.AddWithValue(@"submission_date", date);
                    cmd11.Parameters.AddWithValue(@"comments", TextArea1.InnerText);
                    cmd11.Parameters.AddWithValue(@"keey", Convert.ToString(Page.RouteData.Values["keey"]));


                    con11.Open();
                    cmd11.ExecuteNonQuery();
                    con11.Close();

                    if( Convert.ToString(Page.RouteData.Values["ex_id"])=="1")
                    {
                        using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                        {


                            SqlDataReader reader2;
                            cn.Open();
                            String querystr2 = "select * from proposal_evaluation_form_records where enrollment=@enroll and id=@id";

                            SqlCommand cmd2 = new SqlCommand(querystr2, cn);
                            cmd2.Parameters.AddWithValue(@"enroll", Convert.ToString(Page.RouteData.Values["enrollment12"]));
                            cmd2.Parameters.AddWithValue(@"id", 2);
                            reader2 = cmd2.ExecuteReader();
                            if (reader2.HasRows)
                            {
                                while (reader2.HasRows && reader2.Read())
                                {
                                    if (!reader2.IsDBNull(reader2.GetOrdinal("result")))
                                    { 
                                    Session["MS_10_2_result"] = reader2.GetString(reader2.GetOrdinal("result"));
                                    }
                                }

                                if (Session["MS_10_2_result"].ToString() == "Recommended")
                                {
                                    SqlConnection con1 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");

                                    SqlCommand cmd1 = new SqlCommand("update  proposal set status_id=@st_id where enrollment=@enroll", con1);
                                    cmd1.Parameters.AddWithValue(@"enroll", Convert.ToString(Page.RouteData.Values["enrollment12"]));
                                    cmd1.Parameters.AddWithValue(@"st_id", 4);


                                    con1.Open();
                                    cmd1.ExecuteNonQuery();
                                    con1.Close();

                                    //update supervisor status
                                    SqlConnection con5 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");

                                    SqlCommand cmd5 = new SqlCommand("update  supervisor_student_record set status_id=@st1_id where enrollment=@enroll1", con5);
                                    cmd5.Parameters.AddWithValue(@"enroll1", Convert.ToString(Page.RouteData.Values["enrollment12"]));
                                    cmd5.Parameters.AddWithValue(@"st1_id", 1);
                                    con5.Open();
                                    cmd5.ExecuteNonQuery();
                                    con5.Close();

                                    //trfyhsffffffffffffffffffffffffffffffffffffffffffffffffffff

                                    //insert report forms data

                                    //////random key
                                    string[] array = new string[6];

                                    array[0] = " ";
                                    DateTime dd1 = DateTime.Now;
                                    string date1 = dd1.ToString("dd/MM/yyyy");
                                    array[1] = date1;
                                    DateTime dd2 = DateTime.Now.AddMonths(2);
                                    string date2 = dd2.ToString("dd/MM/yyyy");
                                    array[2] = date2;
                                    DateTime dd21 = DateTime.Now.AddMonths(4);
                                    string date21 = dd21.ToString("dd/MM/yyyy");
                                    array[3] = date21;
                                    DateTime dd211 = DateTime.Now.AddMonths(6);
                                    string date211 = dd211.ToString("dd/MM/yyyy");
                                    array[4] = date211;
                                    DateTime dd212 = DateTime.Now.AddMonths(8);
                                    string date212 = dd212.ToString("dd/MM/yyyy");
                                    array[5] = date212;

                                    for (int i = 1; i < 5; i++)
                                    {
                                        char[] chars = new char[62];
                                    chars ="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
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
                                    // random key end
                                    
                                    SqlConnection con51 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");

                                    SqlCommand cmd51 = new SqlCommand("insert into report (enrollment, report_num, keey, from_date, to_date) values(@enroll, @num, @key, @from, @to)", con51);
                                    cmd51.Parameters.AddWithValue(@"enroll", Convert.ToString(Page.RouteData.Values["enrollment12"]));
                                    cmd51.Parameters.AddWithValue(@"num", i);
                                    cmd51.Parameters.AddWithValue(@"key", result.ToString());
                                    cmd51.Parameters.AddWithValue(@"from", array[i]);
                                    cmd51.Parameters.AddWithValue(@"to", array[i+1]);
                                    con51.Open();
                                    cmd51.ExecuteNonQuery();
                                    con51.Close();
                                    }
                                    //insert report forms data end


                                    

                                }
                            }
                            else
                            {
                                Panel2.Visible = true;
                            }
                            reader2.Close();
                            cn.Close();
                        }
                    }
                    if (Convert.ToString(Page.RouteData.Values["ex_id"]) == "2")
                    {
                        using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                        {


                            SqlDataReader reader2;
                            cn.Open();
                            String querystr2 = "select * from proposal_evaluation_form_records where enrollment=@enroll and id=@id";

                            SqlCommand cmd2 = new SqlCommand(querystr2, cn);
                            cmd2.Parameters.AddWithValue(@"enroll", Convert.ToString(Page.RouteData.Values["enrollment12"]));
                            cmd2.Parameters.AddWithValue(@"id", 1);
                            reader2 = cmd2.ExecuteReader();
                            if (reader2.HasRows)
                            {
                                while (reader2.HasRows && reader2.Read())
                                {
                                    if (!reader2.IsDBNull(reader2.GetOrdinal("result")))
                                    {
                                        Session["MS_10_2_result"] = reader2.GetString(reader2.GetOrdinal("result"));
                                    }
                                }
                                if (Session["MS_10_2_result"].ToString() == "Recommended")
                                {
                                    SqlConnection con1 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");

                                    SqlCommand cmd1 = new SqlCommand("update  proposal set status_id=@st_id where enrollment=@enroll", con1);
                                    cmd1.Parameters.AddWithValue(@"enroll", Convert.ToString(Page.RouteData.Values["enrollment12"]));
                                    cmd1.Parameters.AddWithValue(@"st_id", 4);


                                    con1.Open();
                                    cmd1.ExecuteNonQuery();
                                    con1.Close();

                                    //update supervisor status
                                    SqlConnection con5 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");

                                    SqlCommand cmd5 = new SqlCommand("update  supervisor_student_record set status_id=@st1_id where enrollment=@enroll1", con5);
                                    cmd5.Parameters.AddWithValue(@"enroll1", Convert.ToString(Page.RouteData.Values["enrollment12"]));
                                    cmd5.Parameters.AddWithValue(@"st1_id", 1);
                                    con5.Open();
                                    cmd5.ExecuteNonQuery();
                                    con5.Close();

                                    //insert report forms data

                                    //////random key
                                    string[] array = new string[6];

                                    array[0] = " ";
                                    DateTime dd1 = DateTime.Now;
                                    string date1 = dd1.ToString("dd/MM/yyyy");
                                    array[1] = date1;
                                    DateTime dd2 = DateTime.Now.AddMonths(2);
                                    string date2 = dd2.ToString("dd/MM/yyyy");
                                    array[2] = date2;
                                    DateTime dd21 = DateTime.Now.AddMonths(4);
                                    string date21 = dd21.ToString("dd/MM/yyyy");
                                    array[3] = date21;
                                    DateTime dd211 = DateTime.Now.AddMonths(6);
                                    string date211 = dd211.ToString("dd/MM/yyyy");
                                    array[4] = date211;
                                    DateTime dd212 = DateTime.Now.AddMonths(8);
                                    string date212 = dd212.ToString("dd/MM/yyyy");
                                    array[5] = date212;
                                    string[] arr1 = new string[5];
                                    for (int i = 1; i < 5; i++)
                                    {
                                        char[] chars = new char[62];
                                        chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
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
                                        arr1[i] = result.ToString();
                                        // random key end

                                        SqlConnection con51 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");

                                        SqlCommand cmd51 = new SqlCommand("insert into report (enrollment, report_num, keey, from_date, to_date) values(@enroll, @num, @key, @from, @to)", con51);
                                        cmd51.Parameters.AddWithValue(@"enroll", Convert.ToString(Page.RouteData.Values["enrollment12"]));
                                        cmd51.Parameters.AddWithValue(@"num", i);
                                        cmd51.Parameters.AddWithValue(@"key", result.ToString());
                                        cmd51.Parameters.AddWithValue(@"from", array[i]);
                                        cmd51.Parameters.AddWithValue(@"to", array[i + 1]);
                                        con51.Open();
                                        cmd51.ExecuteNonQuery();
                                        con51.Close();
                                    }
                                    //insert report forms data end
                                    //email to supervisor
                                    using (SqlConnection cn45 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                                    {
                                        SqlDataReader reader245;
                                        cn45.Open();
                                        String querystr245 = "select * from proposal right join supervisor on supervisor.supervisor_id=proposal.supervisor_id where proposal.enrollment=@enroll ";
                                        SqlCommand cmd245 = new SqlCommand(querystr245, cn45);
                                        cmd245.Parameters.AddWithValue("@enroll", Convert.ToString(Page.RouteData.Values["enrollment12"]));
                                        reader245 = cmd245.ExecuteReader();
                                        while (reader245.HasRows && reader245.Read())
                                        {
                                            Session["student_supervisor_official_email"] = reader245.GetString(reader245.GetOrdinal("email"));
                                            Session["sup_name_student"] = reader245.GetString(reader245.GetOrdinal("sup_name"));
                                        }
                                        reader2.Close();
                                        cn.Close();
                                    }

                                    //email to supervisor
                                    String from = "budrshehzad@gmail.com";
                                    String to = Session["student_supervisor_official_email"].ToString();
                                    String ccc = "ahmad31102@gmail.com";
                                    String password = "Ahmad123";
                                    String Message1 = "Respected " + "<b>" + Session["sup_name_student"] + "</b>" + "," + "<br />" + "<br />" + "Please submit student's bi-monthly evaluation report form." + "<br />" +  "<br />" + "<b>Student Detials are given Below </b>" + "<br />" + "<br />" + "<b>Student Name : </b>" + Session["Form-10-student_name"].ToString() + "<br />" + "<b>Program : </b>" + Session["Form-10-student_program"].ToString() + "<br />" + "<b>Enrollment : </b>" + Convert.ToString(Page.RouteData.Values["enrollment12"]) + "<br />" + "<br />" + "<b>Thesis Title</b>" + "<br />" + Session["Form-10-research_title"].ToString() + "<br />" + "<br />" + "<b>" + "Progress Form link is given below." + "</b>" + "<br />" + "http://localhost:21315/quarterly-report/" + Convert.ToString(Page.RouteData.Values["enrollment12"]) + "/1/" + arr1[1] + ".aspx";
                                    String Message2 = "Respected " + "<b>" + Session["sup_name_student"] + "</b>" + "," + "<br />" + "<br />" + "Please submit student's bi-monthly evaluation report form." + "<br />" +  "<br />" + "<b>Student Detials are given Below </b>" + "<br />" + "<br />" + "<b>Student Name : </b>" + Session["Form-10-student_name"].ToString() + "<br />" + "<b>Program : </b>" + Session["Form-10-student_program"].ToString() + "<br />" + "<b>Enrollment : </b>" + Convert.ToString(Page.RouteData.Values["enrollment12"]) + "<br />" + "<br />" + "<b>Thesis Title</b>" + "<br />" + Session["Form-10-research_title"].ToString() + "<br />" + "<br />" + "<b>" + "Progress Form link is given below." + "</b>" + "<br />" + "http://localhost:21315/quarterly-report/" + Convert.ToString(Page.RouteData.Values["enrollment12"]) + "/2/" + arr1[2] + ".aspx";
                                    String Message3 = "Respected " + "<b>" + Session["sup_name_student"] + "</b>" + "," + "<br />" + "<br />" + "Please submit student's bi-monthly evaluation report form." + "<br />" +  "<br />" + "<b>Student Detials are given Below </b>" + "<br />" + "<br />" + "<b>Student Name : </b>" + Session["Form-10-student_name"].ToString() + "<br />" + "<b>Program : </b>" + Session["Form-10-student_program"].ToString() + "<br />" + "<b>Enrollment : </b>" + Convert.ToString(Page.RouteData.Values["enrollment12"]) + "<br />" + "<br />" + "<b>Thesis Title</b>" + "<br />" + Session["Form-10-research_title"].ToString() + "<br />" + "<br />" + "<b>" + "Progress Form link is given below." + "</b>" + "<br />" + "http://localhost:21315/quarterly-report/" + Convert.ToString(Page.RouteData.Values["enrollment12"]) + "/3/" + arr1[3] + ".aspx";
                                    String Message4 = "Respected " + "<b>" + Session["sup_name_student"] + "</b>" + "," + "<br />" + "<br />" + "Please submit student's bi-monthly evaluation report form." + "<br />" +  "<br />" + "<b>Student Detials are given Below </b>" + "<br />" + "<br />" + "<b>Student Name : </b>" + Session["Form-10-student_name"].ToString() + "<br />" + "<b>Program : </b>" + Session["Form-10-student_program"].ToString() + "<br />" + "<b>Enrollment : </b>" + Convert.ToString(Page.RouteData.Values["enrollment12"]) + "<br />" + "<br />" + "<b>Thesis Title</b>" + "<br />" + Session["Form-10-research_title"].ToString() + "<br />" + "<br />" + "<b>" + "Progress Form link is given below." + "</b>" + "<br />" + "http://localhost:21315/quarterly-report/" + Convert.ToString(Page.RouteData.Values["enrollment12"]) + "/4/" + arr1[4] + ".aspx";
                                    String subject = "Progress Report Evaluation Form";
                                    String host = "smtp.gmail.com";
                                    int port = 587;



                                    //official mail send
                                    Thread t = new Thread(() => Send(from, password, to, Message1, subject, host, port, ccc));
                                    t.Start();
                                    Thread t2 = new Thread(() => Send(from, password, to, Message2, subject, host, port, ccc));
                                    t2.Start();
                                    Thread t3 = new Thread(() => Send(from, password, to, Message3, subject, host, port, ccc));
                                    t3.Start();
                                    Thread t4 = new Thread(() => Send(from, password, to, Message4, subject, host, port, ccc));
                                    t4.Start();


                                }
                            }
                            else
                            {
                                Panel2.Visible = true;
                            }
                            reader2.Close();
                            cn.Close();
                        }
                    }
                }
                //Response.Redirect(Request.Url.ToString());
                Panel1.Visible = false;
                Panel30.Visible = true;
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

    }
}