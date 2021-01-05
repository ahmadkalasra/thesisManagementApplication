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
using System.Net.Mail;
using System.Threading;
using System.Security.Cryptography;
namespace admin1 
{
    public class State
    {
        public string Name { get; set; }
        public string value { get; set; }
        public string Abbreviation { get; set; }
    }
    public partial class admin_setup_proposal_defense : System.Web.UI.Page
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
                Panel17.Visible = false;
                Panel20.Visible = false;
                Panel21.Visible = false;
                Panel22.Visible = false;
                Panel23.Visible = false;
                Panel19.Visible = false;
                

                Literal6.Text = Session["admin_name"].ToString();
                Literal7.Text = Session["admin_designation"].ToString();
                Literal8.Text = Session["admin_uemail"].ToString();
                enrollment.Text = Convert.ToString(Session["proposal_defense_student_enrollment"]);
                name.Text = Convert.ToString(Session["proposal_defense_student_name"]);
                program.Text = Convert.ToString(Session["proposal_defense_student_program"]);
                research_area.Text = Convert.ToString(Session["proposal_defense_project_title"]);
                approval_status.Text = Convert.ToString(Session["proposal_defense_proposal_status"]);
                submisssion_date.Text = Convert.ToString(Session["proposal_defense_submission_date"]);
                suggested_supervisor.Text = Session["proposal_defense_sup_name"].ToString();
                supervisor_status.Text = Session["proposal_defense_sup_status"].ToString();


                DropDownList1.Items.Clear();
                DropDownList2.Attributes.Add("OnChange", "MyApp(this)");
                Panel3.Visible = false;
                Panel4.Visible = false;
                Panel5.Visible = false;
                Panel6.Visible = false;
                Panel7.Visible = false;
                Panel9.Visible = false;
                Panel10.Visible = false;
                Panel11.Visible = false;
                Panel12.Visible = false;
                Panel13.Visible = false;
                Panel14.Visible = false;
                Panel16.Visible = false;
                using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                {


                    SqlDataReader reader2;
                    cn.Open();
                    String querystr2 = "select * from frc where frc_id between ((select max(frc_id) from frc)-5) and (select max(frc_id) from frc)";

                    SqlCommand cmd2 = new SqlCommand(querystr2, cn);

                    //cmd2.Parameters.AddWithValue("@sup_id", Convert.ToInt32(Session["suggested_supervisor_id"]));

                    reader2 = cmd2.ExecuteReader();

                    int x = 1;
                    Session["setup_frc_id"] = "";
                    Session["setup_frc_meeting_title"] = "";
                    DropDownList1.Items.Add(new ListItem("-- Select FRC Approval --", 0.ToString()));
                    DropDownList5.Items.Add(new ListItem("-- Select FRC Approval --", 0.ToString()));
                    while (reader2.HasRows && reader2.Read())
                    {
                        Session["setup_frc_id"] = reader2.GetInt32(reader2.GetOrdinal("frc_id"));
                        Session["setup_frc_meeting_title"] = reader2.GetString(reader2.GetOrdinal("meeting_name"));
                        Session["setup_frc_date"] = reader2.GetString(reader2.GetOrdinal("date"));

                        String value = Session["setup_frc_id"].ToString() + "-" + Session["setup_frc_meeting_title"].ToString() + "--" + Session["setup_frc_date"].ToString();

                        DropDownList1.Items.Add(new ListItem(value, x.ToString()));
                        DropDownList5.Items.Add(new ListItem(value, x.ToString()));

                    }
                    reader2.Close();
                    cn.Close();
                }

                using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                {


                    SqlDataReader reader2;
                    cn.Open();
                    String querystr2 = "select * from proposal right join defense on defense.def_id=proposal.defense_id where proposal.enrollment=@enroll  ";

                    SqlCommand cmd2 = new SqlCommand(querystr2, cn);
                    cmd2.Parameters.AddWithValue("@enroll", Session["proposal_defense_student_enrollment"].ToString());
                    reader2 = cmd2.ExecuteReader();

                    while (reader2.HasRows && reader2.Read())
                    {
                        String date1 = reader2.GetString(reader2.GetOrdinal("date"));
                        String time1 = reader2.GetString(reader2.GetOrdinal("time"));
                        String location = reader2.GetString(reader2.GetOrdinal("location"));

                        String date_time = date1 + "-" + time1;
                        proposal_defense_date.Text = date_time;

                        Literal1.Text = date1;
                        Literal2.Text = time1;
                        Literal3.Text = location;
                    }
                    if (reader2.HasRows)
                    {
                        Panel8.Visible = false;
                        Panel9.Visible = true;


                        using (SqlConnection cn12 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                        {


                            SqlDataReader reader212;
                            cn12.Open();
                            String querystr212 = "select * from proposal inner join defense_examiner on defense_examiner.defense_id=proposal.defense_id where proposal.enrollment=@enroll  ";

                            SqlCommand cmd212 = new SqlCommand(querystr212, cn12);
                            cmd212.Parameters.AddWithValue("@enroll", Session["proposal_defense_student_enrollment"].ToString());
                            reader212 = cmd212.ExecuteReader();

                            while (reader212.HasRows && reader212.Read())
                            {

                                int examiner1_id = reader212.GetInt32(reader212.GetOrdinal("examiner_1_id"));
                                int examiner2_id = reader212.GetInt32(reader212.GetOrdinal("examiner_2_id"));
                                Session["Setup_defense_proposal_file_path"] = reader212.GetString(reader212.GetOrdinal("proposal_file_url"));
                                using (SqlConnection cn121 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                                {


                                    SqlDataReader reader2121;
                                    cn121.Open();
                                    String querystr2121 = "select * from examiner where examiner_id=@ex1 or examiner_id=@ex2  ";

                                    SqlCommand cmd2121 = new SqlCommand(querystr2121, cn121);
                                    cmd2121.Parameters.AddWithValue("@ex1", examiner1_id);
                                    cmd2121.Parameters.AddWithValue("@ex2", examiner2_id);

                                    reader2121 = cmd2121.ExecuteReader();
                                    int x = 0;
                                    while (reader2121.HasRows && reader2121.Read())
                                    {
                                        if (x == 0)
                                        {
                                            String examiner1 = reader2121.GetString(reader2121.GetOrdinal("examiner_name"));
                                            int examiner1_t_id = reader2121.GetInt32(reader2121.GetOrdinal("examiner_type_id"));
                                            if (examiner1_t_id == 1)
                                            {
                                                Literal4.Text = examiner1 + " -(Internal)";
                                            }
                                            else
                                            {
                                                Literal4.Text = examiner1 + " -(External)";
                                            }
                                            ++x;
                                        }
                                        else
                                        {
                                            String examiner1 = reader2121.GetString(reader2121.GetOrdinal("examiner_name"));
                                            int examiner1_t_id = reader2121.GetInt32(reader2121.GetOrdinal("examiner_type_id"));
                                            if (examiner1_t_id == 1)
                                            {
                                                Literal5.Text = examiner1 + " -(Internal)";
                                            }
                                            else
                                            {
                                                Literal5.Text = examiner1 + " -(External)";
                                            }
                                            --x;
                                        }

                                    }
                                    reader2121.Close();
                                    cn121.Close();
                                }
                            }
                            reader212.Close();
                            cn12.Close();
                        }
                        Panel16.Visible = true;
                    }
                    else
                    {
                        Panel9.Visible = false;
                        Panel8.Visible = true;
                    }
                    reader2.Close();
                    cn.Close();
                }
                if (supervisor_status.Text == "ASSIGNED")
                {

                    Panel8.Visible = false;
                    Panel9.Visible = false;

                    using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                    {


                        SqlDataReader reader2;
                        cn.Open();
                        String querystr2 = "select * from thesis where enrollment=@enroll";

                        SqlCommand cmd2 = new SqlCommand(querystr2, cn);

                        cmd2.Parameters.AddWithValue("@enroll", Session["proposal_defense_student_enrollment"].ToString());
                        reader2 = cmd2.ExecuteReader();
                        if (reader2.HasRows)
                        {
                            while (reader2.HasRows && reader2.Read())
                            {
                                if (!reader2.IsDBNull(reader2.GetOrdinal("pdf_thesis_file_url")))
                                {
                                    Session["setup_defense_thesis_file_path"] = reader2.GetString(reader2.GetOrdinal("pdf_thesis_file_url"));
                                    Literal10.Text = reader2.GetString(reader2.GetOrdinal("submission_date"));
                                    int id = reader2.GetInt32(reader2.GetOrdinal("status_id"));
                                    using (SqlConnection cn7 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                                    {
                                        SqlDataReader reader27;
                                        cn7.Open();
                                        String querystr27 = "select * from status where status_id=@id";
                                        SqlCommand cmd27 = new SqlCommand(querystr27, cn7);
                                        cmd27.Parameters.AddWithValue("@id", id);
                                        reader27 = cmd27.ExecuteReader();
                                        if (reader27.HasRows)
                                        {
                                            while (reader27.HasRows && reader27.Read())
                                            {
                                                Literal11.Text = reader27.GetString(reader27.GetOrdinal("status"));
                                            }
                                        }
                                        reader27.Close();
                                        cn7.Close();
                                    }
                                    Panel17.Visible = true;
                                }
                                if(!reader2.IsDBNull(reader2.GetOrdinal("defense_id")))
                                {
                                    int id =reader2.GetInt32(reader2.GetOrdinal("defense_id"));
                                    using (SqlConnection cn7 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                                    {
                                        SqlDataReader reader27;
                                        cn7.Open();
                                        String querystr27 = "select * from defense where def_id=@id";
                                        SqlCommand cmd27 = new SqlCommand(querystr27, cn7);
                                        cmd27.Parameters.AddWithValue("@id", id);
                                        reader27 = cmd27.ExecuteReader();
                                        if (reader27.HasRows)
                                        {
                                            while (reader27.HasRows && reader27.Read())
                                            {
                                                Literal9.Text = reader27.GetString(reader27.GetOrdinal("date"));
                                                Literal12.Text = reader27.GetString(reader27.GetOrdinal("time"));
                                                Literal13.Text = reader27.GetString(reader27.GetOrdinal("location"));
                                                int ex1_id=0;
                                                int ex2_id = 0;
                                                using (SqlConnection cn71 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                                                {
                                                    SqlDataReader reader271;
                                                    cn71.Open();
                                                    String querystr271 = "select * from defense_examiner where defense_id=@id";
                                                    SqlCommand cmd271 = new SqlCommand(querystr271, cn71);
                                                    cmd271.Parameters.AddWithValue("@id", id);
                                                    reader271 = cmd271.ExecuteReader();
                                                    if (reader271.HasRows)
                                                    {
                                                        while (reader271.HasRows && reader271.Read())
                                                        {
                                                            ex1_id = reader271.GetInt32(reader271.GetOrdinal("examiner_1_id"));
                                                            ex2_id = reader271.GetInt32(reader271.GetOrdinal("examiner_2_id"));
                                                        }
                                                    }
                                                    reader271.Close();
                                                    cn71.Close();
                                                }
                                                using (SqlConnection cn71 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                                                {
                                                    SqlDataReader reader271;
                                                    cn71.Open();
                                                    String querystr271 = "select * from examiner where examiner_id=@id";
                                                    SqlCommand cmd271 = new SqlCommand(querystr271, cn71);
                                                    cmd271.Parameters.AddWithValue("@id", ex1_id);
                                                    reader271 = cmd271.ExecuteReader();
                                                    if (reader271.HasRows)
                                                    {
                                                        while (reader271.HasRows && reader271.Read())
                                                        {
                                                            string n1 = reader271.GetString(reader271.GetOrdinal("first_name"));
                                                            string n2 = reader271.GetString(reader271.GetOrdinal("last_name"));
                                                            int n4 = reader271.GetInt32(reader271.GetOrdinal("examiner_type_id"));

                                                            string n3 = n1 + " " + n2;
                                                            if(n4==1)
                                                            {
                                                                Literal14.Text = n3 + "-(Internal)";
                                                            }
                                                            if (n4 == 2)
                                                            {
                                                                Literal14.Text = n3 + "-(External)";
                                                            }
                                                        }
                                                    }
                                                    reader271.Close();
                                                    cn71.Close();
                                                }
                                                using (SqlConnection cn71 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                                                {
                                                    SqlDataReader reader271;
                                                    cn71.Open();
                                                    String querystr271 = "select * from examiner where examiner_id=@id";
                                                    SqlCommand cmd271 = new SqlCommand(querystr271, cn71);
                                                    cmd271.Parameters.AddWithValue("@id", ex2_id);
                                                    reader271 = cmd271.ExecuteReader();
                                                    if (reader271.HasRows)
                                                    {
                                                        while (reader271.HasRows && reader271.Read())
                                                        {
                                                            string n1 = reader271.GetString(reader271.GetOrdinal("first_name"));
                                                            string n2 = reader271.GetString(reader271.GetOrdinal("last_name"));
                                                            int n4 = reader271.GetInt32(reader271.GetOrdinal("examiner_type_id"));

                                                            string n3 = n1 + " " + n2;
                                                            if (n4 == 1)
                                                            {
                                                                Literal15.Text = n3 + "-(Internal)";
                                                            }
                                                            if (n4 == 2)
                                                            {
                                                                Literal15.Text = n3 + "-(External)";
                                                            }
                                                        }
                                                    }
                                                    reader271.Close();
                                                    cn71.Close();
                                                }

                                            }
                                        }
                                        reader27.Close();
                                        cn7.Close();
                                    }
                                    Panel19.Visible = true;
                                }

                            }
                        }
                        reader2.Close();
                        cn.Close();
                    }
                }

            }


        }

        protected void submit_click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string examiner1 = Request.Form[DropDownList2.UniqueID];
                string examiner2 = Request.Form[DropDownList3.UniqueID];
                if (DropDownList1.SelectedItem.Text == "-- Select FRC Approval --")
                {
                    Panel4.Visible = true;
                    RadioButtonList1.ClearSelection();
                    RadioButtonList2.ClearSelection();
                }
                else
                {
                    Panel4.Visible = false;
                }
                if (datetimepicker.Text == string.Empty)
                {
                    Panel3.Visible = true;
                    RadioButtonList1.ClearSelection();
                    RadioButtonList2.ClearSelection();
                }
                if (DropDownList4.SelectedItem.Text == "-- Select Class --")
                {
                    Panel5.Visible = true;
                    RadioButtonList1.ClearSelection();
                    RadioButtonList2.ClearSelection();
                }
                if (DropDownList4.SelectedItem.Text != "-- Select Class --")
                {
                    Panel5.Visible = false;
                    RadioButtonList1.ClearSelection();
                    RadioButtonList2.ClearSelection();
                }
                if (examiner1 == null)
                {
                    Panel6.Visible = true;
                }
                else { Panel6.Visible = false; }
                if (examiner2 == null)
                {
                    Panel7.Visible = true;
                }
                else { Panel7.Visible = false; }

                {
                    if (examiner1 != null && (examiner1 == "-- Select External Examiner --" || examiner1.ToString() == "-- Select Internal Examiner --"))
                    {
                        Panel6.Visible = true;

                    }
                }
                if (examiner2 != null && (examiner2 == "-- Select External Examiner --" || examiner2.ToString() == "-- Select Internal Examiner --"))
                {
                    Panel7.Visible = true;
                }

                if (DropDownList1.SelectedItem.Text != "-- Select FRC Approval --" && datetimepicker.Text != string.Empty && DropDownList4.SelectedItem.Text != "-- Select Class --" && examiner1 != null && examiner2 != null && (examiner1 != "-- Select External Examiner --" || examiner1.ToString() != "-- Select Internal Examiner --") && (examiner2 != "-- Select External Examiner --" || examiner2.ToString() != "-- Select Internal Examiner --"))
                {

                    //insert defense records
                    String sp1 = datetimepicker.Text;
                    String[] sp2 = sp1.Split(' ');
                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");

                    String val = Session["class"] + "/" + Session["enrollment"] + "/" + Session["enrollment"] + ".pdf";

                    SqlCommand cmd = new SqlCommand("insert into defense(time, date, location, def_type_id, outcome_id) values (@time, @date, @location, @def_type_id, @outcome_id)", con);
                    cmd.Parameters.AddWithValue(@"time", sp2[1]);
                    cmd.Parameters.AddWithValue(@"date", sp2[0]);
                    cmd.Parameters.AddWithValue(@"location", DropDownList4.SelectedItem.Text);
                    cmd.Parameters.AddWithValue(@"def_type_id", 0);
                    cmd.Parameters.AddWithValue(@"outcome_id", 1);


                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    //select defense id

                    using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                    {


                        SqlDataReader reader2;
                        cn.Open();
                        String querystr2 = "select top 1 * from defense order by def_id desc";

                        SqlCommand cmd2 = new SqlCommand(querystr2, cn);

                        reader2 = cmd2.ExecuteReader();

                        while (reader2.HasRows && reader2.Read())
                        {
                            Session["settup_defense_defense_id"] = reader2.GetInt32(reader2.GetOrdinal("def_id"));
                        }
                        reader2.Close();
                        cn.Close();
                    }

                    // select examiners id email
                    using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                    {


                        SqlDataReader reader2;
                        cn.Open();
                        String querystr2 = "select * from examiner where examiner_name=@ex1 or examiner_name=@ex2";

                        SqlCommand cmd2 = new SqlCommand(querystr2, cn);

                        cmd2.Parameters.AddWithValue("@ex1", examiner1.ToString());
                        cmd2.Parameters.AddWithValue("@ex2", examiner2.ToString());
                        reader2 = cmd2.ExecuteReader();
                        int x = 0;

                        while (reader2.HasRows && reader2.Read())
                        {
                            if (x == 0)
                            {
                                Session["setup_defense_examiner_1_id"] = reader2.GetInt32(reader2.GetOrdinal("examiner_id"));
                                Session["setup_defense_examiner_1_email"] = reader2.GetString(reader2.GetOrdinal("official_email"));

                                ++x;
                            }
                            else
                            {
                                Session["setup_defense_examiner_2_id"] = reader2.GetInt32(reader2.GetOrdinal("examiner_id"));
                                Session["setup_defense_examiner_2_email"] = reader2.GetString(reader2.GetOrdinal("official_email"));

                                --x;
                            }
                        }
                        reader2.Close();
                        cn.Close();
                    }

                    //select proposal file url

                    using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                    {


                        SqlDataReader reader2;
                        cn.Open();
                        String querystr2 = "select * from proposal where enrollment=@enroll";

                        SqlCommand cmd2 = new SqlCommand(querystr2, cn);
                        cmd2.Parameters.AddWithValue("@enroll", Session["proposal_defense_student_enrollment"]);
                        reader2 = cmd2.ExecuteReader();

                        while (reader2.HasRows && reader2.Read())
                        {
                            Session["settup_defense_proposal_file_url"] = reader2.GetString(reader2.GetOrdinal("proposal_file_url"));
                        }
                        reader2.Close();
                        cn.Close();
                    }

                    //insert defense examiners

                    SqlConnection con11 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");

                    String val11 = Session["class"] + "/" + Session["enrollment"] + "/" + Session["enrollment"] + ".pdf";

                    SqlCommand cmd11 = new SqlCommand("insert into defense_examiner(defense_id, examiner_1_id, examiner_2_id) values (@defense_id, @examiner_1_id, @examiner_2_id)", con11);
                    cmd11.Parameters.AddWithValue(@"defense_id", Convert.ToInt32(Session["settup_defense_defense_id"]));
                    cmd11.Parameters.AddWithValue(@"examiner_1_id", Convert.ToInt32(Session["setup_defense_examiner_1_id"]));
                    cmd11.Parameters.AddWithValue(@"examiner_2_id", Convert.ToInt32(Session["setup_defense_examiner_2_id"]));


                    con11.Open();
                    cmd11.ExecuteNonQuery();
                    con11.Close();

                    //update proposal table set defense id

                    SqlConnection con111 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");

                    String val111 = Session["class"] + "/" + Session["enrollment"] + "/" + Session["enrollment"] + ".pdf";

                    SqlCommand cmd111 = new SqlCommand("update proposal set defense_id=@def_id where enrollment=@enrollment", con111);
                    cmd111.Parameters.AddWithValue(@"def_id", Convert.ToInt32(Session["settup_defense_defense_id"]));
                    cmd111.Parameters.AddWithValue(@"enrollment", Convert.ToString(Session["proposal_defense_student_enrollment"]));


                    con111.Open();
                    cmd111.ExecuteNonQuery();
                    con111.Close();

                    //show date time on proposal info panel

                    using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                    {


                        SqlDataReader reader2;
                        cn.Open();
                        String querystr2 = "select * from proposal right join defense on defense.def_id=proposal.defense_id where proposal.enrollment=@enroll  ";

                        SqlCommand cmd2 = new SqlCommand(querystr2, cn);
                        cmd2.Parameters.AddWithValue("@enroll", Session["proposal_defense_student_enrollment"].ToString());
                        reader2 = cmd2.ExecuteReader();

                        while (reader2.HasRows && reader2.Read())
                        {
                            String date1 = reader2.GetString(reader2.GetOrdinal("date"));
                            String time1 = reader2.GetString(reader2.GetOrdinal("time"));
                            String date_time = date1 + "-" + time1;
                            proposal_defense_date.Text = date_time;
                        }
                        reader2.Close();
                        cn.Close();
                    }

                    //send mail to examiners with form link and proposal file

                    var smtp = new System.Net.Mail.SmtpClient();
                    {
                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 587;
                        smtp.EnableSsl = true;
                        smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                        smtp.Credentials = new NetworkCredential("ahmad311002@gmail.com", "Transformer_1343");
                        smtp.Timeout = 20000;


                    }
                    //smtp.Send("ahmad311002@gmail.com", "ahmad311002@gmail.com", "this is subject", "This is body");

                    //set key details 1

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


                    // random key end

                    SqlConnection con112 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");

                    String val112 = Session["class"] + "/" + Session["enrollment"] + "/" + Session["enrollment"] + ".pdf";

                    SqlCommand cmd112 = new SqlCommand("insert into proposal_evaluation_form_records(enrollment, id, keey) values (@enrollment, @id, @keey)", con112);
                    cmd112.Parameters.AddWithValue(@"enrollment", Session["proposal_defense_student_enrollment"].ToString());
                    cmd112.Parameters.AddWithValue(@"id", 1);
                    cmd112.Parameters.AddWithValue(@"keey", result.ToString());

                    con112.Open();
                    cmd112.ExecuteNonQuery();
                    con112.Close();

                    //key end 1

                    //set key details 2

                    //////random key

                    char[] chars1 = new char[72];
                    chars1 =
                    "abcdefghijklmnopqrstuvwxyz1212121212ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
                    byte[] data1 = new byte[1];
                    using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
                    {
                        crypto.GetNonZeroBytes(data1);
                        data1 = new byte[8];
                        crypto.GetNonZeroBytes(data1);
                    }
                    StringBuilder result1 = new StringBuilder(8);
                    foreach (byte b in data1)
                    {
                        result1.Append(chars[b % (chars.Length)]);
                    }


                    // random key end

                    SqlConnection con11211 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");

                    String val11211 = Session["class"] + "/" + Session["enrollment"] + "/" + Session["enrollment"] + ".pdf";

                    SqlCommand cmd11211 = new SqlCommand("insert into proposal_evaluation_form_records(enrollment, id, keey) values (@enrollment, @id, @keey)", con11211);
                    cmd11211.Parameters.AddWithValue(@"enrollment", Session["proposal_defense_student_enrollment"].ToString());
                    cmd11211.Parameters.AddWithValue(@"id", 2);
                    cmd11211.Parameters.AddWithValue(@"keey", result1.ToString());

                    con11211.Open();
                    cmd11211.ExecuteNonQuery();
                    con11211.Close();

                    //key end 2 

                    //--------------------------------------------------------------------------------
                    String from = "ahmad311002@gmail.com";
                    String to = Session["setup_defense_examiner_1_email"].ToString();
                    String to1 = Session["setup_defense_examiner_2_email"].ToString();
                    String ccc = "ahmad31102@gmail.com";
                    String password = "Transformer_1343";
                    String Message = "Respected " + "<b>" + examiner1 + "</b>" + "," + "<br />" + "<br />" + "This is to inform you that you have been assigned as an Thesis proposal Evaluation's Examiner." + "<br />" + "Student Details are given Below." + "<br />" + " Proposal File is attached with this mail. Kindly find the attachment." + "<br />" + "<b>Student Detials</b>" + "<br />" + "<b>Student Name : </b>" + Session["proposal_defense_student_name"].ToString() + "<br />" + "<b>Program : </b>" + Session["proposal_defense_student_program"].ToString() + "<br />" + "<b>Enrollment : </b>" + Session["proposal_defense_student_enrollment"].ToString() + "<br />" + "<br />" + "<b>Defense Details</b>" + "<br />" + "<b>Date: </b>" + sp2[0] + "<br />" + "<b>Time: </b>" + sp2[1] + "<br />" + "<b>Location: </b>" + DropDownList4.SelectedItem.Text + "<br />" + "<br />" + "<b>" + "Proposal Defense Evaluation Form link is given below. Please Fill this form after defense." + "</b>" + "<br />" + "http://localhost:21315/MS-10-Form/" + Session["proposal_defense_student_enrollment"] + "/1/" + result.ToString() + ".aspx";
                    String Message2 = "Respected " + "<b>" + examiner2 + "</b>" + "," + "<br />" + "<br />" + "This is to inform you that you have been assigned as an Thesis proposal Evaluation's Examiner." + "<br />" + "Student Details are given Below." + "<br />" + " Proposal File is attached with this mail. Kindly find the attachment." + "<br />" + "<b>Student Detials</b>" + "<br />" + "<b>Student Name : </b>" + Session["proposal_defense_student_name"].ToString() + "<br />" + "<b>Program : </b>" + Session["proposal_defense_student_program"].ToString() + "<br />" + "<b>Enrollment : </b>" + Session["proposal_defense_student_enrollment"].ToString() + "<br />" + "<br />" + "<b>Defense Details</b>" + "<br />" + "<b>Date: </b>" + sp2[0] + "<br />" + "<b>Time: </b>" + sp2[1] + "<br />" + "<b>Location: </b>" + DropDownList4.SelectedItem.Text + "<br />" + "<br />" + "<b>" + "Proposal Defense Evaluation Form link is given below. Please Fill this form after defense." + "</b>" + "<br />" + "http://localhost:21315/MS-10-Form/" + Session["proposal_defense_student_enrollment"] + "/2/" + result1.ToString() + ".aspx";
                    String subject = "Thesis Proposal Defense Evaluation Alert";
                    String host = "smtp.gmail.com";
                    int port = 587;
                    String file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Session["settup_defense_proposal_file_url"].ToString());


                    //official mail send
                    Thread t = new Thread(() => Send(from, password, to, Message, subject, host, port, file, ccc));
                    t.Start();
                    Thread t2 = new Thread(() => Send(from, password, to1, Message2, subject, host, port, file, ccc));
                    t2.Start();


                    Panel8.Visible = false;
                    Panel9.Visible = true;
                    Response.Redirect(Request.Url.AbsoluteUri);
                    //Send(from, password, to, Message, subject, host, port, file, ccc);
                    //Send(from, password, to1, Message2, subject, host, port, file, ccc);

                }
            }
        }

        protected void update_click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string examiner1 = Request.Form[DropDownList7.UniqueID];
                string examiner2 = Request.Form[DropDownList8.UniqueID];
                if (DropDownList5.SelectedItem.Text == "-- Select FRC Approval --")
                {
                    Panel10.Visible = true;
                    RadioButtonList3.ClearSelection();
                    RadioButtonList4.ClearSelection();
                }
                else
                {
                    Panel10.Visible = false;
                }
                if (datetimepicker2.Text == string.Empty)
                {
                    Panel11.Visible = true;
                    RadioButtonList3.ClearSelection();
                    RadioButtonList4.ClearSelection();
                }
                else
                {
                    Panel11.Visible = false;
                    RadioButtonList3.ClearSelection();
                    RadioButtonList4.ClearSelection();
                }
                if (DropDownList6.SelectedItem.Text == "-- Select Class --")
                {
                    Panel12.Visible = true;
                    RadioButtonList3.ClearSelection();
                    RadioButtonList4.ClearSelection();
                }
                if (DropDownList6.SelectedItem.Text != "-- Select Class --")
                {
                    Panel12.Visible = false;
                    RadioButtonList3.ClearSelection();
                    RadioButtonList4.ClearSelection();
                }
                if (examiner1 == null)
                {
                    Panel13.Visible = true;
                }
                else { Panel13.Visible = false; }
                if (examiner2 == null)
                {
                    Panel14.Visible = true;
                }
                else { Panel14.Visible = false; }

                {
                    if (examiner1 != null && (examiner1 == "-- Select External Examiner --" || examiner1.ToString() == "-- Select Internal Examiner --"))
                    {
                        Panel13.Visible = true;

                    }
                }
                if (examiner2 != null && (examiner2 == "-- Select External Examiner --" || examiner2.ToString() == "-- Select Internal Examiner --"))
                {
                    Panel14.Visible = true;
                }

                if (DropDownList5.SelectedItem.Text != "-- Select FRC Approval --" && datetimepicker2.Text != string.Empty && DropDownList6.SelectedItem.Text != "-- Select Class --" && examiner1 != null && examiner2 != null && (examiner1 != "-- Select External Examiner --" || examiner1.ToString() != "-- Select Internal Examiner --") && (examiner2 != "-- Select External Examiner --" || examiner2.ToString() != "-- Select Internal Examiner --"))
                {

                    //select defense id

                    using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                    {


                        SqlDataReader reader2;
                        cn.Open();
                        String querystr2 = "select * from proposal where enrollment =@enroll";

                        SqlCommand cmd2 = new SqlCommand(querystr2, cn);
                        cmd2.Parameters.AddWithValue(@"enroll", Session["proposal_defense_student_enrollment"].ToString());
                        reader2 = cmd2.ExecuteReader();

                        while (reader2.HasRows && reader2.Read())
                        {
                            Session["settup_defense_defense_id"] = reader2.GetInt32(reader2.GetOrdinal("defense_id"));
                        }
                        reader2.Close();
                        cn.Close();
                    }


                    //update defense records
                    String sp1 = datetimepicker2.Text;
                    String[] sp2 = sp1.Split(' ');
                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");

                    String val = Session["class"] + "/" + Session["enrollment"] + "/" + Session["enrollment"] + ".pdf";

                    SqlCommand cmd = new SqlCommand("update defense set time=@time, date=@date, location=@location where def_id=@def_id", con);
                    cmd.Parameters.AddWithValue(@"time", sp2[1]);
                    cmd.Parameters.AddWithValue(@"date", sp2[0]);
                    cmd.Parameters.AddWithValue(@"location", DropDownList6.SelectedItem.Text);
                    cmd.Parameters.AddWithValue(@"def_id", Convert.ToInt32(Session["settup_defense_defense_id"]));


                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();



                    // select examiners id email
                    using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                    {


                        SqlDataReader reader2;
                        cn.Open();
                        String querystr2 = "select * from examiner where examiner_name=@ex1 or examiner_name=@ex2";

                        SqlCommand cmd2 = new SqlCommand(querystr2, cn);

                        cmd2.Parameters.AddWithValue("@ex1", examiner1.ToString());
                        cmd2.Parameters.AddWithValue("@ex2", examiner2.ToString());
                        reader2 = cmd2.ExecuteReader();
                        int x = 0;

                        while (reader2.HasRows && reader2.Read())
                        {
                            if (x == 0)
                            {
                                Session["setup_defense_examiner_1_id"] = reader2.GetInt32(reader2.GetOrdinal("examiner_id"));
                                Session["setup_defense_examiner_1_email"] = reader2.GetString(reader2.GetOrdinal("official_email"));

                                ++x;
                            }
                            else
                            {
                                Session["setup_defense_examiner_2_id"] = reader2.GetInt32(reader2.GetOrdinal("examiner_id"));
                                Session["setup_defense_examiner_2_email"] = reader2.GetString(reader2.GetOrdinal("official_email"));

                                --x;
                            }
                        }
                        reader2.Close();
                        cn.Close();
                    }

                    //select proposal file url

                    using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                    {


                        SqlDataReader reader2;
                        cn.Open();
                        String querystr2 = "select * from proposal where enrollment=@enroll";

                        SqlCommand cmd2 = new SqlCommand(querystr2, cn);
                        cmd2.Parameters.AddWithValue("@enroll", Session["proposal_defense_student_enrollment"]);
                        reader2 = cmd2.ExecuteReader();

                        while (reader2.HasRows && reader2.Read())
                        {
                            Session["settup_defense_proposal_file_url"] = reader2.GetString(reader2.GetOrdinal("proposal_file_url"));
                        }
                        reader2.Close();
                        cn.Close();
                    }

                    //update defense examiners

                    SqlConnection con11 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");
                    
                    SqlCommand cmd11 = new SqlCommand("update defense_examiner set  examiner_1_id=@examiner_1_id, examiner_2_id=@examiner_2_id where defense_id=@defense_id", con11);
                    cmd11.Parameters.AddWithValue(@"defense_id", Convert.ToInt32(Session["settup_defense_defense_id"]));
                    cmd11.Parameters.AddWithValue(@"examiner_1_id", Convert.ToInt32(Session["setup_defense_examiner_1_id"]));
                    cmd11.Parameters.AddWithValue(@"examiner_2_id", Convert.ToInt32(Session["setup_defense_examiner_2_id"]));


                    con11.Open();
                    cmd11.ExecuteNonQuery();
                    con11.Close();


                    //show date time on proposal info panel

                    using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                    {


                        SqlDataReader reader2;
                        cn.Open();
                        String querystr2 = "select * from proposal right join defense on defense.def_id=proposal.defense_id where proposal.enrollment=@enroll  ";

                        SqlCommand cmd2 = new SqlCommand(querystr2, cn);
                        cmd2.Parameters.AddWithValue("@enroll", Session["proposal_defense_student_enrollment"].ToString());
                        reader2 = cmd2.ExecuteReader();

                        while (reader2.HasRows && reader2.Read())
                        {
                            String date1 = reader2.GetString(reader2.GetOrdinal("date"));
                            String time1 = reader2.GetString(reader2.GetOrdinal("time"));
                            String date_time = date1 + "-" + time1;
                            proposal_defense_date.Text = date_time;
                        }
                        reader2.Close();
                        cn.Close();
                    }

                    //send mail to examiners with form link and proposal file

                    var smtp = new System.Net.Mail.SmtpClient();
                    {
                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 587;
                        smtp.EnableSsl = true;
                        smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                        smtp.Credentials = new NetworkCredential("ahmad311002@gmail.com", "Transformer_1343");
                        smtp.Timeout = 20000;


                    }
                    //smtp.Send("ahmad311002@gmail.com", "ahmad311002@gmail.com", "this is subject", "This is body");



                    //--------------------------------------------------------------------------------
                    String from = "ahmad311002@gmail.com";
                    String to = Session["setup_defense_examiner_1_email"].ToString();
                    String to1 = Session["setup_defense_examiner_2_email"].ToString();
                    String ccc = "ahmad31102@gmail.com";
                    String password = "Transformer_1343";
                    String Message = "Respected " + "<b>" + examiner1 + "</b>" + "," + "<br />" + "<br />" + "This is to inform you that you have been assigned as an Thesis proposal Evaluation's Examiner." + "<br />" + "Student Details are given Below." + "<br />" + " Proposal File is attached with this mail. Kindly find the attachment." + "<br />" + "<b>Student Detials</b>" + "<br />" + "<b>Student Name : </b>" + Session["proposal_defense_student_name"].ToString() + "<br />" + "<b>Program : </b>" + Session["proposal_defense_student_program"].ToString() + "<br />" + "<b>Enrollment : </b>" + Session["proposal_defense_student_enrollment"].ToString() + "<br />" + "<br />" + "<b>Defense Details</b>" + "<br />" + "<b>Date: </b>" + sp2[0] + "<br />" + "<b>Time: </b>" + sp2[1] + "<br />" + "<b>Location: </b>" + DropDownList4.SelectedItem.Text + "<br />" + "<br />" + "<b>" + "Proposal Defense Evaluation Form link is given below. Please Fill this form after defense." + "</b>" + "<br />" + "http://localhost:21315/MS-10-Form/" + Session["proposal_defense_student_enrollment"] + "_1" + ".aspx";
                    String Message2 = "Respected " + "<b>" + examiner2 + "</b>" + "," + "<br />" + "<br />" + "This is to inform you that you have been assigned as an Thesis proposal Evaluation's Examiner." + "<br />" + "Student Details are given Below." + "<br />" + " Proposal File is attached with this mail. Kindly find the attachment." + "<br />" + "<b>Student Detials</b>" + "<br />" + "<b>Student Name : </b>" + Session["proposal_defense_student_name"].ToString() + "<br />" + "<b>Program : </b>" + Session["proposal_defense_student_program"].ToString() + "<br />" + "<b>Enrollment : </b>" + Session["proposal_defense_student_enrollment"].ToString() + "<br />" + "<br />" + "<b>Defense Details</b>" + "<br />" + "<b>Date: </b>" + sp2[0] + "<br />" + "<b>Time: </b>" + sp2[1] + "<br />" + "<b>Location: </b>" + DropDownList4.SelectedItem.Text + "<br />" + "<br />" + "<b>" + "Proposal Defense Evaluation Form link is given below. Please Fill this form after defense." + "</b>" + "<br />" + "http://localhost:21315/MS-10-Form/" + Session["proposal_defense_student_enrollment"] + "_2" + ".aspx";
                    String subject = "Thesis Proposal Defense Evaluation Alert";
                    String host = "smtp.gmail.com";
                    int port = 587;
                    String file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Session["settup_defense_proposal_file_url"].ToString());


                    //official mail send
                    //Thread t = new Thread(() => Send(from, password, to, Message, subject, host, port, file, ccc));
                    //t.Start();
                    //Thread t2 = new Thread(() => Send(from, password, to1, Message2, subject, host, port, file, ccc));
                    //t2.Start();

                    Panel8.Visible = false;
                    Panel9.Visible = true;
                    Response.Redirect(Request.Url.AbsoluteUri);
                    //Send(from, password, to, Message, subject, host, port, file, ccc);
                    //Send(from, password, to1, Message2, subject, host, port, file, ccc);

                }
            }
        }

        public static void Send(string from, string password, string to, string Message, string subject, string host, int port, string file, String ccc)
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

            if (file.Length > 0)
            {
                Attachment attachment;
                attachment = new Attachment(file);
                email.Attachments.Add(attachment);
            }

            smtp.Send(email);
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {


                var fileInBytes = Encoding.UTF8.GetBytes("Your file text");
                using (var stream = new MemoryStream(fileInBytes))
                {

                    // string strURL = txtFileName.Text;
                    WebClient req = new WebClient();
                    HttpResponse response = HttpContext.Current.Response;
                    response.Clear();
                    response.ClearContent();
                    response.ClearHeaders();
                    response.Buffer = true;
                    response.AddHeader("Content-Disposition", "attachment;filename=\"" + Session["proposal_defense_student_enrollment"].ToString() + "-Proposal-File.pdf");
                    byte[] data = req.DownloadData(Server.MapPath(@"~/" + Session["Setup_defense_proposal_file_path"]));
                    response.BinaryWrite(data);
                    response.End();
                }
                Response.End();
            }
            catch (Exception)
            {

            }
        }
        protected void thesis_Click(object sender, EventArgs e)
        {
            try
            {


                var fileInBytes = Encoding.UTF8.GetBytes("Your file text");
                using (var stream = new MemoryStream(fileInBytes))
                {

                    // string strURL = txtFileName.Text;
                    WebClient req = new WebClient();
                    HttpResponse response = HttpContext.Current.Response;
                    response.Clear();
                    response.ClearContent();
                    response.ClearHeaders();
                    response.Buffer = true;
                    response.AddHeader("Content-Disposition", "attachment;filename=\"" + Session["proposal_defense_student_enrollment"].ToString() + "-Proposal-File.pdf");
                    byte[] data = req.DownloadData(Server.MapPath(@"~/" + Session["Setup_defense_proposal_file_path"]));
                    response.BinaryWrite(data);
                    response.End();
                }
                Response.End();
            }
            catch (Exception)
            {

            }
        }

        protected void thesis_Click_1(object sender, EventArgs e)
        {
            try
            {


                var fileInBytes = Encoding.UTF8.GetBytes("Your file text");
                using (var stream = new MemoryStream(fileInBytes))
                {

                    // string strURL = txtFileName.Text;
                    WebClient req = new WebClient();
                    HttpResponse response = HttpContext.Current.Response;
                    response.Clear();
                    response.ClearContent();
                    response.ClearHeaders();
                    response.Buffer = true;
                    response.AddHeader("Content-Disposition", "attachment;filename=\"" + Session["proposal_defense_student_enrollment"].ToString() + "-Thesis-File.pdf");
                    byte[] data = req.DownloadData(Server.MapPath(@"~/" + Session["setup_defense_thesis_file_path"]));
                    response.BinaryWrite(data);
                    response.End();
                }
                Response.End();
            }
            catch (Exception)
            {

            }
        }
        protected void setup_thesis_defense(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string examiner1 = Request.Form[DropDownList11.UniqueID];
                string examiner2 = Request.Form[DropDownList12.UniqueID];
                
                if (TextBox1.Text == string.Empty)
                {
                    Panel20.Visible = true;
                    RadioButtonList5.ClearSelection();
                    RadioButtonList6.ClearSelection();
                }
                else
                {
                    Panel20.Visible = false;
                    RadioButtonList5.ClearSelection();
                    RadioButtonList6.ClearSelection();
                }
                if (DropDownList10.SelectedItem.Text == "-- Select Class --")
                {
                    Panel21.Visible = true;
                    RadioButtonList5.ClearSelection();
                    RadioButtonList6.ClearSelection();
                }
                if (DropDownList10.SelectedItem.Text != "-- Select Class --")
                {
                    Panel21.Visible = false;
                    RadioButtonList5.ClearSelection();
                    RadioButtonList6.ClearSelection();
                }
                if (examiner1 == null)
                {
                    Panel22.Visible = true;
                }
                else { Panel22.Visible = false; }
                if (examiner2 == null)
                {
                    Panel23.Visible = true;
                }
                else { Panel23.Visible = false; }

                {
                    if (examiner1 != null && (examiner1 == "-- Select External Examiner --" || examiner1.ToString() == "-- Select Internal Examiner --"))
                    {
                        Panel22.Visible = true;

                    }
                }
                if (examiner2 != null && (examiner2 == "-- Select External Examiner --" || examiner2.ToString() == "-- Select Internal Examiner --"))
                {
                    Panel23.Visible = true;
                }

                if (TextBox1.Text != string.Empty && DropDownList10.SelectedItem.Text != "-- Select Class --" && examiner1 != null && examiner2 != null && (examiner1 != "-- Select External Examiner --" || examiner1.ToString() != "-- Select Internal Examiner --") && (examiner2 != "-- Select External Examiner --" || examiner2.ToString() != "-- Select Internal Examiner --"))
                {
                    //insert defense records
                    String sp1 = TextBox1.Text;
                    String[] sp2 = sp1.Split(' ');
                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");
                    
                    SqlCommand cmd = new SqlCommand("insert into defense(time, date, location, def_type_id, outcome_id) values (@time, @date, @location, @def_type_id, @outcome_id)", con);
                    cmd.Parameters.AddWithValue(@"time", sp2[1]);
                    cmd.Parameters.AddWithValue(@"date", sp2[0]);
                    cmd.Parameters.AddWithValue(@"location", DropDownList10.SelectedItem.Text);
                    cmd.Parameters.AddWithValue(@"def_type_id", 1);
                    cmd.Parameters.AddWithValue(@"outcome_id", 1);


                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    //select defense id

                    using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                    {


                        SqlDataReader reader2;
                        cn.Open();
                        String querystr2 = "select top 1 * from defense order by def_id desc";

                        SqlCommand cmd2 = new SqlCommand(querystr2, cn);

                        reader2 = cmd2.ExecuteReader();

                        while (reader2.HasRows && reader2.Read())
                        {
                            Session["settup_defense_thesis_defense_id"] = reader2.GetInt32(reader2.GetOrdinal("def_id"));
                        }
                        reader2.Close();
                        cn.Close();
                    }
                    //select Examiner id and mail
                    using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                    {
                        SqlDataReader reader2;
                        cn.Open();
                        String querystr2 = "select * from examiner where examiner_name=@ex1";

                        SqlCommand cmd2 = new SqlCommand(querystr2, cn);

                        cmd2.Parameters.AddWithValue("@ex1", examiner1.ToString());
                        reader2 = cmd2.ExecuteReader();
                        while (reader2.HasRows && reader2.Read())
                        {
                                Session["setup_defense_thesis_examiner_1_id"] = reader2.GetInt32(reader2.GetOrdinal("examiner_id"));
                                Session["setup_defense_thesis_examiner_1_email"] = reader2.GetString(reader2.GetOrdinal("official_email"));
                                
                        }
                        reader2.Close();
                        cn.Close();
                    }
                    using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                    {
                        SqlDataReader reader2;
                        cn.Open();
                        String querystr2 = "select * from examiner where examiner_name=@ex1";

                        SqlCommand cmd2 = new SqlCommand(querystr2, cn);

                        cmd2.Parameters.AddWithValue("@ex1", examiner2.ToString());
                        reader2 = cmd2.ExecuteReader();
                        while (reader2.HasRows && reader2.Read())
                        {
                            Session["setup_defense_thesis_examiner_2_id"] = reader2.GetInt32(reader2.GetOrdinal("examiner_id"));
                            Session["setup_defense_thesis_examiner_2_email"] = reader2.GetString(reader2.GetOrdinal("official_email"));

                        }
                        reader2.Close();
                        cn.Close();
                    }
                    //update defense examiners

                    SqlConnection con11 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");
                    
                    SqlCommand cmd11 = new SqlCommand("insert into defense_examiner (defense_id, examiner_1_id, examiner_2_id) values (@defense_id, @examiner_1_id, @examiner_2_id )", con11);
                    cmd11.Parameters.AddWithValue(@"defense_id", Convert.ToInt32(Session["settup_defense_thesis_defense_id"]));
                    cmd11.Parameters.AddWithValue(@"examiner_1_id", Convert.ToInt32(Session["setup_defense_thesis_examiner_1_id"]));
                    cmd11.Parameters.AddWithValue(@"examiner_2_id", Convert.ToInt32(Session["setup_defense_thesis_examiner_2_id"]));


                    con11.Open();
                    cmd11.ExecuteNonQuery();
                    con11.Close();
                    
                    //update thesis table set defense_id

                    SqlConnection con1 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");
                    
                    SqlCommand cmd1 = new SqlCommand("update thesis set  defense_id=@id where enrollment=@enroll", con1);
                    cmd1.Parameters.AddWithValue(@"id", Convert.ToInt32(Session["settup_defense_thesis_defense_id"]));
                    cmd1.Parameters.AddWithValue(@"enroll", Session["proposal_defense_student_enrollment"].ToString());


                    con1.Open();
                    cmd1.ExecuteNonQuery();
                    con1.Close();

                    //insert final forms records
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


                    // random key end

                    //////random key

                    char[] chars1 = new char[62];
                    chars1 =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
                    byte[] data1 = new byte[1];
                    using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
                    {
                        crypto.GetNonZeroBytes(data1);
                        data1 = new byte[8];
                        crypto.GetNonZeroBytes(data1);
                    }
                    StringBuilder result1 = new StringBuilder(8);
                    foreach (byte b in data1)
                    {
                        result1.Append(chars[b % (chars.Length)]);
                    }


                    // random key end
                    for(int x=1; x<3; x++)
                    {
                        SqlConnection con12 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");

                        SqlCommand cmd12 = new SqlCommand("insert into final_form_records(enrollment, id, keey, examiner_name ) values (@enrollment, @id, @keey, @examiner_name)", con12);
                        cmd12.Parameters.AddWithValue(@"enrollment", Session["proposal_defense_student_enrollment"]);
                        cmd12.Parameters.AddWithValue(@"id", x);
                        if(x==1)
                        {
                            cmd12.Parameters.AddWithValue(@"keey", result.ToString());
                            cmd12.Parameters.AddWithValue(@"examiner_name", examiner1);
                        }
                        if (x == 2)
                        {
                            cmd12.Parameters.AddWithValue(@"keey", result1.ToString());
                            cmd12.Parameters.AddWithValue(@"examiner_name", examiner2);
                        }
                        con12.Open();
                        cmd12.ExecuteNonQuery();
                        con12.Close();
                    }
                    using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                    {
                        SqlDataReader reader2;
                        cn.Open();
                        String querystr2 = "select * from examiner where examiner_name=@examiner1  ";
                        SqlCommand cmd2 = new SqlCommand(querystr2, cn);
                        cmd2.Parameters.AddWithValue("@examiner1", examiner1);
                        reader2 = cmd2.ExecuteReader();
                        while (reader2.HasRows && reader2.Read())
                        {
                            Session["admin_final_defense_examiner_1_email"] = reader2.GetString(reader2.GetOrdinal("official_email"));
                        }
                        reader2.Close();
                        cn.Close();
                    }
                    using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                    {
                        SqlDataReader reader2;
                        cn.Open();
                        String querystr2 = "select * from examiner where examiner_name=@examiner1  ";
                        SqlCommand cmd2 = new SqlCommand(querystr2, cn);
                        cmd2.Parameters.AddWithValue("@examiner1", examiner2);
                        reader2 = cmd2.ExecuteReader();
                        while (reader2.HasRows && reader2.Read())
                        {
                            Session["admin_final_defense_examiner_2_email"] = reader2.GetString(reader2.GetOrdinal("official_email"));
                        }
                        reader2.Close();
                        cn.Close();
                    }
                    using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                    {
                        SqlDataReader reader2;
                        cn.Open();
                        String querystr2 = "select * from thesis where enrollment=@enroll  ";
                        SqlCommand cmd2 = new SqlCommand(querystr2, cn);
                        cmd2.Parameters.AddWithValue("@enroll", Session["proposal_defense_student_enrollment"].ToString());
                        reader2 = cmd2.ExecuteReader();
                        while (reader2.HasRows && reader2.Read())
                        {
                            Session["settup_defense_thesis_file_url"] = reader2.GetString(reader2.GetOrdinal("pdf_thesis_file_url"));
                        }
                        reader2.Close();
                        cn.Close();
                    }
                    enrollment.Text = Convert.ToString(Session["proposal_defense_student_enrollment"]);
                    name.Text = Convert.ToString(Session["proposal_defense_student_name"]);
                    program.Text = Convert.ToString(Session["proposal_defense_student_program"]);
                    //email to examiner1
                    String from = "budrshehzad@gmail.com";
                    String to = Session["admin_final_defense_examiner_1_email"].ToString();
                    String to1 = Session["admin_final_defense_examiner_2_email"].ToString();
                    String ccc = "ahmad31102@gmail.com";
                    String password = "Ahmad123";
                    String Message1 = "Respected " + "<b>" + examiner1 + "</b>" + "," + "<br />" + "<br />" + "This is to inform you that you have been assigned as an Thesis Evaluation's Examiner." + "<br />" + "Student Details are given Below." + "<br />" + " Thesis File is attached with this mail. Kindly find the attachment." + "<br />" + "<b>Student Detials</b>" + "<br />" + "<b>Student Name : </b>" + Convert.ToString(Session["proposal_defense_student_name"]) + "<br />" + "<b>Program : </b>" + Convert.ToString(Session["proposal_defense_student_program"]) + "<br />" + "<b>Enrollment : </b>" + Convert.ToString(Session["proposal_defense_student_enrollment"]) + "<br />" + "<br />" + "<b>Defense Details</b>" + "<br />" + "<b>Date: </b>" + sp2[0] + "<br />" + "<b>Time: </b>" + sp2[1] + "<br />" + "<b>Location: </b>" + DropDownList10.SelectedItem.Text + "<br />" + "<br />" + "<b>" + "Proposal Defense Evaluation Form link is given below. Please Fill this form after defense." + "</b>" + "<br />" + "http://localhost:21315/thesis_defense_evaluation_form/" + Session["proposal_defense_student_enrollment"] + "/1/" + result.ToString() + ".aspx";
                    String Message2 = "Respected " + "<b>" + examiner1 + "</b>" + "," + "<br />" + "<br />" + "This is to inform you that you have been assigned as an Thesis Evaluation's Examiner." + "<br />" + "Student Details are given Below." + "<br />" + " Thesis File is attached with this mail. Kindly find the attachment." + "<br />" + "<b>Student Detials</b>" + "<br />" + "<b>Student Name : </b>" + Convert.ToString(Session["proposal_defense_student_name"]) + "<br />" + "<b>Program : </b>" + Convert.ToString(Session["proposal_defense_student_program"]) + "<br />" + "<b>Enrollment : </b>" + Convert.ToString(Session["proposal_defense_student_enrollment"]) + "<br />" + "<br />" + "<b>Defense Details</b>" + "<br />" + "<b>Date: </b>" + sp2[0] + "<br />" + "<b>Time: </b>" + sp2[1] + "<br />" + "<b>Location: </b>" + DropDownList10.SelectedItem.Text + "<br />" + "<br />" + "<b>" + "Proposal Defense Evaluation Form link is given below. Please Fill this form after defense." + "</b>" + "<br />" + "http://localhost:21315/thesis_defense_evaluation_form/" + Session["proposal_defense_student_enrollment"] + "/2/" + result1.ToString() + ".aspx";
                    String subject = "Examiner appointment for Thesis Defense";
                    String host = "smtp.gmail.com";
                    int port = 587;
                    String file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Session["settup_defense_thesis_file_url"].ToString());


                    //official mail send
                    Thread t = new Thread(() => Send(from, password, to, Message1, subject, host, port, file, ccc));
                    t.Start();
                    Thread t2 = new Thread(() => Send(from, password, to1, Message2, subject, host, port, file, ccc));
                    t2.Start();



                    Response.Redirect("admin_setup_proposal_defense.aspx");
                }
            }
        }
    }
    
}