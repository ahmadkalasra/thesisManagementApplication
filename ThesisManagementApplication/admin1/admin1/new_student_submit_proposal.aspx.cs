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
using System.Threading;
using System.Net.Mail;

namespace admin1
{
    public partial class new_student_submit_proposal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel16.Visible = false;
            Panel14.Visible = false;
            Panel15.Visible = false;
            Panel10.Visible = false;
            Panel17.Visible = false;
            Panel18.Visible = false;
            Panel19.Visible = false;
            Panel20.Visible = false;
            Panel21.Visible = false;
            if (!string.IsNullOrEmpty(Session["enrollment"] as string))
            {

                if (!IsPostBack)
                {
                    Literal7.Text = Session["enrollment"].ToString();
                    Literal10.Text = Session["name"].ToString();
                    //select supervisors list
                    using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                    {


                        SqlDataReader reader2;
                        cn.Open();
                        String querystr2 = "select * from supervisor";

                        SqlCommand cmd2 = new SqlCommand(querystr2, cn);
                        supervisor.Items.Clear();
                        reader2 = cmd2.ExecuteReader();
                        supervisor.Items.Add(new ListItem("-- Select Supervisor --", 0.ToString()));
                        int x = 1;
                        while (reader2.HasRows && reader2.Read())
                        {
                            String sname = reader2.GetString(reader2.GetOrdinal("sup_name"));
                            supervisor.Items.Add(new ListItem(sname, x.ToString()));
                            ++x;
                        }
                        reader2.Close();
                        cn.Close();
                    }
                }
                //check defense id
                using (SqlConnection cn1 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                {



                    cn1.Open();
                    String querystr21 = "select defense_id from proposal where enrollment=@enroll";
                    SqlDataReader reader21;
                    SqlCommand cmd21 = new SqlCommand(querystr21, cn1);
                    cmd21.Parameters.AddWithValue("@enroll", Session["enrollment"].ToString());

                    reader21 = cmd21.ExecuteReader();
                    if (reader21.HasRows)
                    {
                        int defense_id = 0;
                        while (reader21.HasRows && reader21.Read())
                        {
                            if (!reader21.IsDBNull(reader21.GetOrdinal("defense_id")))
                            {
                                defense_id = reader21.GetInt32(reader21.GetOrdinal("defense_id"));
                            }


                        }
                        if (defense_id != 0)
                        {
                            using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                            {


                                SqlDataReader reader2;
                                cn.Open();
                                String querystr2 = "select * from proposal right join defense on defense.def_id=proposal.defense_id where proposal.enrollment=@enroll  ";

                                SqlCommand cmd2 = new SqlCommand(querystr2, cn);
                                cmd2.Parameters.AddWithValue("@enroll", Session["enrollment"].ToString());
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
                                    using (SqlConnection cn12 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                                    {


                                        SqlDataReader reader212;
                                        cn12.Open();
                                        String querystr212 = "select * from proposal right join defense_examiner on defense_examiner.defense_id=proposal.defense_id where proposal.enrollment=@enroll  ";

                                        SqlCommand cmd212 = new SqlCommand(querystr212, cn12);
                                        cmd212.Parameters.AddWithValue("@enroll", Session["enrollment"].ToString());
                                        reader212 = cmd212.ExecuteReader();

                                        while (reader212.HasRows && reader212.Read())
                                        {

                                            int examiner1_id = reader212.GetInt32(reader212.GetOrdinal("examiner_1_id"));
                                            int examiner2_id = reader212.GetInt32(reader212.GetOrdinal("examiner_2_id"));

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
                                }
                                reader2.Close();
                                cn.Close();
                            }
                            Panel16.Visible = true;
                        }
                    }

                    reader21.Close();
                    cn1.Close();
                }

                //---------------------------select proposal Data-----------------------------------
                using (SqlConnection cn5 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                {


                    SqlDataReader reader5;
                    cn5.Open();
                    String querystr5 = "select * from proposal where enrollment=@enroll";

                    SqlCommand cmd5 = new SqlCommand(querystr5, cn5);

                    cmd5.Parameters.AddWithValue("@enroll", Session["enrollment"].ToString());

                    reader5 = cmd5.ExecuteReader();



                    if (reader5.HasRows)
                    {
                        int defense_id = 0;
                        while (reader5.HasRows && reader5.Read())
                        {
                            Session["proposal_id"] = reader5.GetInt32(reader5.GetOrdinal("pro_id"));
                            Session["proposal_status_id"] = reader5.GetInt32(reader5.GetOrdinal("status_id"));
                            Session["Assigned_supervisor_id"] = reader5.GetInt32(reader5.GetOrdinal("supervisor_id"));
                            Session["proposal_submission_date"] = reader5.GetString(reader5.GetOrdinal("submission_date"));
                            //defense_id = reader5.GetInt32(reader5.GetOrdinal("defense_id"));


                        }

                        //---------------------------select Student-Thesis Data-----------------------------------
                        using (SqlConnection cn7 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                        {


                            SqlDataReader reader7;
                            cn7.Open();
                            String querystr7 = "select * from student_thesis_info where enrollment=@enrolll";

                            SqlCommand cmd7 = new SqlCommand(querystr7, cn7);

                            cmd7.Parameters.AddWithValue("@enrolll", Session["enrollment"].ToString());

                            reader7 = cmd7.ExecuteReader();


                            while (reader7.HasRows && reader7.Read())
                            {
                                Session["suggested_supervisor_id"] = reader7.GetInt32(reader7.GetOrdinal("suggested_supervisor_id"));
                                Session["proposal_id"] = reader7.GetInt32(reader7.GetOrdinal("proposal_id"));
                                Session["Assigned_supervisor_id"] = reader7.GetInt32(reader7.GetOrdinal("supervisor_id"));
                                Session["Research_area"] = reader7.GetString(reader7.GetOrdinal("research_area"));

                            }
                            Session["Assigned_supervisor_name"] = "";
                            if (!string.IsNullOrEmpty(Session["Assigned_supervisor_id"] as string))
                            {
                                using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                                {


                                    SqlDataReader reader2;
                                    cn.Open();
                                    String querystr2 = "select * from supervisor where supervisor_id=@sup_id";

                                    SqlCommand cmd2 = new SqlCommand(querystr2, cn);

                                    cmd2.Parameters.AddWithValue("@sup_id", Session["Assigned_supervisor_id"]);

                                    reader2 = cmd2.ExecuteReader();


                                    while (reader2.HasRows && reader2.Read())
                                    {
                                        Session["Assigned_supervisor_name"] = reader2.GetString(reader2.GetOrdinal("sup_name"));

                                    }
                                    reader2.Close();
                                    cn.Close();
                                }

                            }
                            reader7.Close();
                            cn7.Close();
                        }

                        //--------------------------Select Student-Thesis Data End-------------------------
                        //---------------------------select suggested supervisor Data-----------------------------------
                        using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                        {


                            SqlDataReader reader2;
                            cn.Open();
                            String querystr2 = "select * from supervisor where supervisor_id=@sup_id";

                            SqlCommand cmd2 = new SqlCommand(querystr2, cn);

                            cmd2.Parameters.AddWithValue("@sup_id", Convert.ToInt32(Session["suggested_supervisor_id"]));

                            reader2 = cmd2.ExecuteReader();


                            while (reader2.HasRows && reader2.Read())
                            {
                                Session["suggested_supervisor_name"] = reader2.GetString(reader2.GetOrdinal("sup_name"));

                            }
                            reader2.Close();
                            cn.Close();
                        }
                        using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                        {


                            SqlDataReader reader2;
                            cn.Open();
                            String querystr2 = "select * from supervisor_student_record,supervisor_status where supervisor_student_record.enrollment=@enrol11 and supervisor_status.status_id=supervisor_student_record.status_id";

                            SqlCommand cmd2 = new SqlCommand(querystr2, cn);

                            cmd2.Parameters.AddWithValue("@enrol11", Session["enrollment"].ToString());

                            reader2 = cmd2.ExecuteReader();


                            while (reader2.HasRows && reader2.Read())
                            {
                                Session["supervisor_assigned_status_new"] = reader2.GetString(reader2.GetOrdinal("status"));

                            }
                            reader2.Close();
                            cn.Close();
                        }

                        //--------------------------Select suggested Supervisor Data End-------------------------
                        //---------------------------select Proposal Status-----------------------------------
                        using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                        {


                            SqlDataReader reader2;
                            cn.Open();
                            String querystr2 = "select * from status where status_id=@status_id";

                            SqlCommand cmd2 = new SqlCommand(querystr2, cn);

                            cmd2.Parameters.AddWithValue("@status_id", Convert.ToInt32(Session["proposal_status_id"]));

                            reader2 = cmd2.ExecuteReader();


                            while (reader2.HasRows && reader2.Read())
                            {
                                Session["proposal_status"] = reader2.GetString(reader2.GetOrdinal("status"));
                            }
                            reader2.Close();
                            cn.Close();
                        }

                        //--------------------------Select Proposal status  End-------------------------


                        research_area.Text = Session["Research_area"].ToString();
                        suggested_supervisor.Text = Session["suggested_supervisor_name"].ToString();
                        supervisor_status.Text = Session["supervisor_assigned_status_new"].ToString();
                        approval_status.Text = Session["proposal_status"].ToString();
                        submisssion_date.Text = Session["proposal_submission_date"].ToString();

                        Panel1.Visible = true;


                        Panel7.Visible = false;
                        Panel8.Visible = true;
                    }
                    else
                    {
                        Panel8.Visible = false;
                    }
                    reader5.Close();
                    cn5.Close();
                }

                //--------------------------Select proposal Data End-------------------------


                if (supervisor_status.Text == "ASSIGNED")
                {
                    Panel16.Visible = false;
                    Panel7.Visible = false;
                    Panel8.Visible = false;
                }
                using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                {
                    SqlDataReader reader2;
                    cn.Open();
                    String querystr2 = "select * from thesis where enrollment=@enroll";
                    SqlCommand cmd2 = new SqlCommand(querystr2, cn);
                    cmd2.Parameters.AddWithValue("@enroll", Session["enrollment"].ToString());
                    reader2 = cmd2.ExecuteReader();
                    if (reader2.HasRows)
                    {
                        while (reader2.HasRows && reader2.Read())
                        {
                            if(!reader2.IsDBNull(reader2.GetOrdinal("pdf_thesis_file_url")))
                            {
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
                                            Literal9.Text = reader27.GetString(reader27.GetOrdinal("status"));
                                        }
                                    }
                                    reader27.Close();
                                    cn7.Close();
                                }
                                Session["student_thesis_file_path"] = reader2.GetString(reader2.GetOrdinal("pdf_thesis_file_url"));
                                Literal8.Text = reader2.GetString(reader2.GetOrdinal("submission_date"));
                                
                                Panel17.Visible = true;
                                Panel18.Visible = true;
                            }
                            else
                            {
                                Panel10.Visible = true;
                            }
                            if (!reader2.IsDBNull(reader2.GetOrdinal("defense_id")))
                            {
                                int id = reader2.GetInt32(reader2.GetOrdinal("defense_id"));
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
                                            Literal11.Text = reader27.GetString(reader27.GetOrdinal("date"));
                                            Literal12.Text = reader27.GetString(reader27.GetOrdinal("time"));
                                            Literal13.Text = reader27.GetString(reader27.GetOrdinal("location"));
                                            int ex1_id = 0;
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
                                                        if (n4 == 1)
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
                                Panel21.Visible = true;
                                Panel18.Visible = false;
                            }
                        }
                    }
                    reader2.Close();
                    cn.Close();
                }


            }
            else
            {
                Response.Redirect("student_signIn.aspx");
            }
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
            Panel6.Visible = false;

            Panel9.Visible = false;
            Panel11.Visible = false;
            Panel12.Visible = false;


        }

        protected void upload_Click(object sender, EventArgs e)
        {
            if (project_title.Text == String.Empty)
            {
                Panel5.Visible = true;
            }
            else
            {
                Panel5.Visible = false;
            }
            if (project_abstract.InnerText == "")
            {
                Panel4.Visible = true;
            }
            else
            {
                Panel4.Visible = false;
            }
            if (supervisor.SelectedValue=="0")
            {
                Panel3.Visible = true;
            }
            
            if (!FileUpload1.HasFile)
            {
                Panel6.Visible = true;
            }
            if (FileUpload1.HasFile)
            {
                Panel6.Visible = false;
            }
            if (System.IO.Path.GetExtension(FileUpload1.FileName) != ".pdf")
            {
                Panel6.Visible = true;
            }
            else
            {
                Panel6.Visible = false;
            }
            if (project_title.Text != String.Empty && project_abstract.InnerText != String.Empty && supervisor.SelectedItem.Text != "-- Select Supervisor --" && FileUpload1.HasFile && System.IO.Path.GetExtension(FileUpload1.FileName) == ".pdf")
            {
                if (FileUpload1.HasFile && System.IO.Path.GetExtension(FileUpload1.FileName) == ".pdf")
                {
                    // if the \pix directory doesn't exist - create it. 

                    if (!System.IO.Directory.Exists(Server.MapPath(@"~/" + Session["class"] + "/" + Session["enrollment"] + "/")))
                    {
                        System.IO.Directory.CreateDirectory(Server.MapPath(@"~/" + Session["class"] + "/" + Session["enrollment"] + "/"));
                        string filename = Path.GetFileName(FileUpload1.FileName);
                        FileUpload1.SaveAs(Server.MapPath(@"~/" + Session["class"] + "/" + Session["enrollment"] + "/") + Session["enrollment"] + ".pdf");

                        //----------------------------------------------------------------------Database Updation-------------------------------------------------------

                        //---------------------------select supervisor Data-----------------------------------
                        using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                        {


                            SqlDataReader reader2;
                            cn.Open();
                            String querystr2 = "select * from supervisor where sup_name=@name";

                            SqlCommand cmd2 = new SqlCommand(querystr2, cn);

                            cmd2.Parameters.AddWithValue("@name", supervisor.Items[supervisor.SelectedIndex].Text);

                            reader2 = cmd2.ExecuteReader();


                            while (reader2.HasRows && reader2.Read())
                            {
                                Session["suggested_supervisor_id"] = reader2.GetInt32(reader2.GetOrdinal("supervisor_id"));
                                Session["suggested_supervisor_name"] = reader2.GetString(reader2.GetOrdinal("sup_name"));

                            }
                            reader2.Close();
                            cn.Close();
                        }

                        //--------------------------Select Supervisor Data End-------------------------

                        //--------------------------Update Proposal Data---------------------

                        SqlConnection con = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");

                        String val = Session["class"] + "/" + Session["enrollment"] + "/" + Session["enrollment"] + ".pdf";

                        SqlCommand cmd = new SqlCommand("insert into proposal(enrollment,abstract, supervisor_id, submission_date, proposal_file_url,  status_id) values (@enrollment,@abstract,@supervisor_id,@submission_date,@proposal_file_url,@status_id)", con);
                        cmd.Parameters.AddWithValue(@"enrollment", Session["enrollment"]);
                        cmd.Parameters.AddWithValue(@"submission_date", DateTime.Now.ToString());
                        cmd.Parameters.AddWithValue(@"proposal_file_url", val);
                        cmd.Parameters.AddWithValue(@"status_id", 2);
                        cmd.Parameters.AddWithValue(@"supervisor_id", Convert.ToInt32(Session["suggested_supervisor_id"]));
                        cmd.Parameters.AddWithValue(@"abstract", Convert.ToString(project_abstract.InnerText));


                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        //--------------------------Update Proposal Data End---------------------

                        SqlConnection con11 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");

                        String val11 = Session["class"] + "/" + Session["enrollment"] + "/" + Session["enrollment"] + ".pdf";

                        SqlCommand cmd11 = new SqlCommand("insert into supervisor_student_record(supervisor_id, enrollment, status_id) values (@supervisor_id, @enrollment, @status_id)", con11);
                        cmd11.Parameters.AddWithValue(@"supervisor_id", Convert.ToInt32(Session["suggested_supervisor_id"]));
                        cmd11.Parameters.AddWithValue(@"enrollment", Convert.ToString(Session["enrollment"]));
                        cmd11.Parameters.AddWithValue(@"status_id", 2);


                        con11.Open();
                        cmd11.ExecuteNonQuery();
                        con11.Close();
                        //--------------------------Reserve Thesis Data---------------------

                        //SqlConnection con3 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");

                        //SqlCommand cmd3 = new SqlCommand("insert into thesis(due_date) values (@due_date)", con3);

                        //cmd3.Parameters.AddWithValue(@"due_date", DateTime.Now.AddMonths(2).ToString());

                        //con3.Open();
                        //cmd3.ExecuteNonQuery();
                        //con3.Close();




                        //--------------------------Reserve Thesis Data End---------------------

                        //---------------------------select proposal Data-----------------------------------
                        using (SqlConnection cn5 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                        {


                            SqlDataReader reader5;
                            cn5.Open();
                            String querystr5 = "select * from proposal where enrollment=@enroll";

                            SqlCommand cmd5 = new SqlCommand(querystr5, cn5);

                            cmd5.Parameters.AddWithValue("@enroll", Session["enrollment"].ToString());

                            reader5 = cmd5.ExecuteReader();


                            while (reader5.HasRows && reader5.Read())
                            {
                                Session["proposal_id"] = reader5.GetInt32(reader5.GetOrdinal("pro_id"));

                            }
                            reader5.Close();
                            cn5.Close();
                        }

                        //--------------------------Select proposal Data End-------------------------


                        //--------------------------Update Student - Thesis Data---------------------
                        SqlConnection con6 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");

                        SqlCommand cmd4 = new SqlCommand("insert into student_thesis_info(enrollment, supervisor_id, suggested_supervisor_id, proposal_id, research_area) values (@enrollment,@supervisor_id,@suggested_supervisor_id,@proposal_id, @research_area)", con6);
                        cmd4.Parameters.AddWithValue(@"enrollment", Session["enrollment"]);
                        cmd4.Parameters.AddWithValue(@"suggested_supervisor_id", Session["suggested_supervisor_id"]);
                        cmd4.Parameters.AddWithValue(@"supervisor_id", Session["suggested_supervisor_id"]);
                        cmd4.Parameters.AddWithValue(@"proposal_id", Convert.ToInt32(Session["proposal_id"]));
                        cmd4.Parameters.AddWithValue(@"research_area", project_title.Text);

                        con6.Open();
                        cmd4.ExecuteNonQuery();
                        con6.Close();
                        //--------------------------Update Student - Thesis Data End---------------------

                        //--------------------------------------------------Database Updation Completed--------------------------------------
                        Response.Redirect("new_student_submit_proposal.aspx");
                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath(@"~/" + Session["class"] + "/" + Session["enrollment"] + "/") + Session["enrollment"] + ".pdf");
                        //----------------------------------------------------------------------Database Updation-------------------------------------------------------

                        //---------------------------select supervisor Data-----------------------------------
                        using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                        {


                            SqlDataReader reader2;
                            cn.Open();
                            String querystr2 = "select * from supervisor where sup_name=@name";

                            SqlCommand cmd2 = new SqlCommand(querystr2, cn);

                            cmd2.Parameters.AddWithValue("@name", supervisor.Items[supervisor.SelectedIndex].Text);

                            reader2 = cmd2.ExecuteReader();


                            while (reader2.HasRows && reader2.Read())
                            {
                                Session["suggested_supervisor_id"] = reader2.GetInt32(reader2.GetOrdinal("supervisor_id"));
                                Session["suggested_supervisor_name"] = reader2.GetString(reader2.GetOrdinal("sup_name"));

                            }
                            reader2.Close();
                            cn.Close();
                        }

                        //--------------------------Select Supervisor Data End-------------------------

                        //--------------------------Update Proposal Data---------------------

                        SqlConnection con = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");

                        String val = Session["class"] + "/" + Session["enrollment"] + "/" + Session["enrollment"] + ".pdf";

                        SqlCommand cmd = new SqlCommand("insert into proposal(enrollment,abstract, supervisor_id, submission_date, proposal_file_url,  status_id) values (@enrollment,@abstract, @supervisor_id,@submission_date,@proposal_file_url,@status_id)", con);
                        cmd.Parameters.AddWithValue(@"enrollment", Session["enrollment"]);
                        cmd.Parameters.AddWithValue(@"submission_date", DateTime.Now.ToString());
                        cmd.Parameters.AddWithValue(@"proposal_file_url", val);
                        cmd.Parameters.AddWithValue(@"status_id", 2);
                        cmd.Parameters.AddWithValue(@"supervisor_id", Convert.ToInt32(Session["suggested_supervisor_id"]));
                        cmd.Parameters.AddWithValue(@"abstract", Convert.ToString(project_abstract.InnerText));

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        //--------------------------Update Proposal Data End---------------------

                        SqlConnection con11 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");

                        String val11 = Session["class"] + "/" + Session["enrollment"] + "/" + Session["enrollment"] + ".pdf";

                        SqlCommand cmd11 = new SqlCommand("insert into supervisor_student_record(supervisor_id, enrollment, status_id) values (@supervisor_id, @enrollment, @status_id)", con11);
                        cmd11.Parameters.AddWithValue(@"supervisor_id", Convert.ToInt32(Session["suggested_supervisor_id"]));
                        cmd11.Parameters.AddWithValue(@"enrollment", Session["enrollment"]);
                        cmd11.Parameters.AddWithValue(@"status_id", 2);


                        con11.Open();
                        cmd11.ExecuteNonQuery();
                        con11.Close();

                        //--------------------------Reserve Thesis Data---------------------

                        //SqlConnection con3 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");

                        //SqlCommand cmd3 = new SqlCommand("insert into thesis(due_date) values (@due_date)", con3);

                        //cmd3.Parameters.AddWithValue(@"due_date", DateTime.Now.AddMonths(2).ToString());

                        //con3.Open();
                        //cmd3.ExecuteNonQuery();
                        //con3.Close();




                        //--------------------------Reserve Thesis Data End---------------------

                        //---------------------------select proposal Data-----------------------------------
                        using (SqlConnection cn5 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                        {


                            SqlDataReader reader5;
                            cn5.Open();
                            String querystr5 = "select * from proposal where enrollment=@enroll";

                            SqlCommand cmd5 = new SqlCommand(querystr5, cn5);

                            cmd5.Parameters.AddWithValue("@enroll", Session["enrollment"].ToString());

                            reader5 = cmd5.ExecuteReader();


                            while (reader5.HasRows && reader5.Read())
                            {
                                Session["proposal_id"] = reader5.GetInt32(reader5.GetOrdinal("pro_id"));

                            }
                            reader5.Close();
                            cn5.Close();
                        }

                        //--------------------------Select proposal Data End-------------------------


                        //--------------------------Update Student - Thesis Data---------------------
                        SqlConnection con6 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");

                        SqlCommand cmd4 = new SqlCommand("insert into student_thesis_info(enrollment, supervisor_id, suggested_supervisor_id, proposal_id, research_area) values (@enrollment,@supervisor_id,@suggested_supervisor_id,@proposal_id, @research_area)", con6);
                        cmd4.Parameters.AddWithValue(@"enrollment", Session["enrollment"]);
                        cmd4.Parameters.AddWithValue(@"suggested_supervisor_id", Session["suggested_supervisor_id"]);
                        cmd4.Parameters.AddWithValue(@"supervisor_id", Session["suggested_supervisor_id"]);
                        cmd4.Parameters.AddWithValue(@"proposal_id", Convert.ToInt32(Session["proposal_id"]));
                        cmd4.Parameters.AddWithValue(@"research_area", project_title.Text);

                        con6.Open();
                        cmd4.ExecuteNonQuery();
                        con6.Close();
                        //--------------------------Update Student - Thesis Data End---------------------

                        //--------------------------------------------------Database Updation Completed--------------------------------------

                        Response.Redirect("new_student_submit_proposal.aspx");
                    }
                }
                else
                {
                    Panel2.Visible = true;
                    errortext.Text = "Please Choose the file first";
                }
            }
        }

        protected void update_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == String.Empty)
            {
                Panel9.Visible = true;
            }
            else
            {
                Panel9.Visible = false;
            }
            if (Textarea1.InnerText == "")
            {
                Panel11.Visible = true;
            }
            else
            {
                Panel11.Visible = false;
            }
            if (!FileUpload2.HasFile)
            {
                Panel12.Visible = true;
            }
            if (FileUpload2.HasFile)
            {
                Panel12.Visible = false;
            }

            if (System.IO.Path.GetExtension(FileUpload2.FileName) != ".pdf")
            {
                Panel12.Visible = true;
            }
            else
            {
                Panel12.Visible = false;
            }
            if (TextBox1.Text != String.Empty && Textarea1.InnerText != "" && FileUpload2.HasFile && System.IO.Path.GetExtension(FileUpload2.FileName) == ".pdf")
            {
                if (FileUpload2.HasFile && System.IO.Path.GetExtension(FileUpload2.FileName) == ".pdf")
                {
                    // if the \pix directory doesn't exist - create it. 

                    if (!System.IO.Directory.Exists(Server.MapPath(@"~/" + Session["class"] + "/" + Session["enrollment"] + "/")))
                    {
                        System.IO.Directory.CreateDirectory(Server.MapPath(@"~/" + Session["class"] + "/" + Session["enrollment"] + "/"));
                        string filename = Path.GetFileName(FileUpload2.FileName);
                        FileUpload2.SaveAs(Server.MapPath(@"~/" + Session["class"] + "/" + Session["enrollment"] + "/") + Session["enrollment"] + ".pdf");

                        //----------------------------------------------------------------------Database Updation-------------------------------------------------------


                        //--------------------------Update Proposal Data---------------------

                        SqlConnection con = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");

                        String val = Session["class"] + "/" + Session["enrollment"] + "/" + Session["enrollment"] + ".pdf";

                        SqlCommand cmd = new SqlCommand("update proposal set abstract=@abstract, submission_date=@submission_date, proposal_file_url=@proposal_file_url where enrollment=@enrollment", con);
                        cmd.Parameters.AddWithValue(@"enrollment", Session["enrollment"]);
                        cmd.Parameters.AddWithValue(@"submission_date", DateTime.Now.ToString());
                        cmd.Parameters.AddWithValue(@"proposal_file_url", val);
                        cmd.Parameters.AddWithValue(@"abstract", Convert.ToString(Textarea1.InnerText));


                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        //--------------------------Update Proposal Data End---------------------

                        //---------------------------select proposal Data-----------------------------------
                        using (SqlConnection cn5 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                        {


                            SqlDataReader reader5;
                            cn5.Open();
                            String querystr5 = "select * from proposal where enrollment=@enroll";

                            SqlCommand cmd5 = new SqlCommand(querystr5, cn5);

                            cmd5.Parameters.AddWithValue("@enroll", Session["enrollment"].ToString());

                            reader5 = cmd5.ExecuteReader();


                            while (reader5.HasRows && reader5.Read())
                            {
                                Session["proposal_id"] = reader5.GetInt32(reader5.GetOrdinal("pro_id"));

                            }
                            reader5.Close();
                            cn5.Close();
                        }

                        //--------------------------Select proposal Data End-------------------------


                        //--------------------------Update Student - Thesis Data---------------------
                        SqlConnection con6 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");

                        SqlCommand cmd4 = new SqlCommand("update student_thesis_info set research_area=@research_area where enrollment=@enrollment", con6);
                        cmd4.Parameters.AddWithValue(@"enrollment", Session["enrollment"]);
                        cmd4.Parameters.AddWithValue(@"research_area", TextBox1.Text);

                        con6.Open();
                        cmd4.ExecuteNonQuery();
                        con6.Close();
                        //--------------------------Update Student - Thesis Data End---------------------

                        //--------------------------------------------------Database Updation Completed--------------------------------------
                        Response.Redirect("new_student_submit_proposal.aspx");
                    }
                    else
                    {
                        FileUpload2.SaveAs(Server.MapPath(@"~/" + Session["class"] + "/" + Session["enrollment"] + "/") + Session["enrollment"] + ".pdf");
                        //----------------------------------------------------------------------Database Updation-------------------------------------------------------


                        //--------------------------Select Supervisor Data End-------------------------

                        //--------------------------Update Proposal Data---------------------

                        //--------------------------Update Proposal Data---------------------

                        SqlConnection con = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");

                        String val = Session["class"] + "/" + Session["enrollment"] + "/" + Session["enrollment"] + ".pdf";

                        SqlCommand cmd = new SqlCommand("update proposal set abstract=@abstract, submission_date=@submission_date, proposal_file_url=@proposal_file_url where enrollment=@enrollment", con);
                        cmd.Parameters.AddWithValue(@"enrollment", Session["enrollment"]);
                        cmd.Parameters.AddWithValue(@"submission_date", DateTime.Now.ToString());
                        cmd.Parameters.AddWithValue(@"proposal_file_url", val);
                        cmd.Parameters.AddWithValue(@"abstract", Convert.ToString(Textarea1.InnerText));


                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        //--------------------------Update Proposal Data End---------------------

                        //---------------------------select proposal Data-----------------------------------
                        using (SqlConnection cn5 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                        {


                            SqlDataReader reader5;
                            cn5.Open();
                            String querystr5 = "select * from proposal where enrollment=@enroll";

                            SqlCommand cmd5 = new SqlCommand(querystr5, cn5);

                            cmd5.Parameters.AddWithValue("@enroll", Session["enrollment"].ToString());

                            reader5 = cmd5.ExecuteReader();


                            while (reader5.HasRows && reader5.Read())
                            {
                                Session["proposal_id"] = reader5.GetInt32(reader5.GetOrdinal("pro_id"));

                            }
                            reader5.Close();
                            cn5.Close();
                        }

                        //--------------------------Select proposal Data End-------------------------


                        //--------------------------Update Student - Thesis Data---------------------
                        SqlConnection con6 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");

                        SqlCommand cmd4 = new SqlCommand("update student_thesis_info set research_area=@research_area where enrollment=@enrollment", con6);
                        cmd4.Parameters.AddWithValue(@"enrollment", Session["enrollment"]);
                        cmd4.Parameters.AddWithValue(@"research_area", TextBox1.Text);

                        con6.Open();
                        cmd4.ExecuteNonQuery();
                        con6.Close();
                        //--------------------------Update Student - Thesis Data End---------------------

                        //--------------------------------------------------Database Updation Completed--------------------------------------

                        Response.Redirect("new_student_submit_proposal.aspx");
                    }
                }
                else
                {
                    Panel2.Visible = true;
                    errortext.Text = "Please Choose the file first";
                }
            }
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
                    response.AddHeader("Content-Disposition", "attachment;filename=\"" + Session["enrollment"] + "-Proposal-File.pdf");
                    byte[] data = req.DownloadData(Server.MapPath(@"~/" + Session["class"] + "/" + Session["enrollment"] + "/" + Session["enrollment"] + ".pdf"));
                    response.BinaryWrite(data);
                    response.End();
                }
                Response.End();
            }
            catch (Exception)
            {

            }
        }
        
        protected void btnDownload_Click_thesis(object sender, EventArgs e)
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
                    response.AddHeader("Content-Disposition", "attachment;filename=\"" +Session["enrollment"]+"-Thesis-File.pdf");
                    byte[] data = req.DownloadData(Server.MapPath(@"~/" + Session["student_thesis_file_path"]));
                    response.BinaryWrite(data);
                    response.End();
                }
                Response.End();
            }
            catch (Exception)
            {

            }
        }
        protected void upload_thesis(object sender, EventArgs e)
        {
            if(!FileUpload3.HasFile)
            {
                Panel15.Visible = true;
            }
            if(FileUpload3.HasFile && System.IO.Path.GetExtension(FileUpload3.FileName) != ".pdf")
            {
                Panel14.Visible = true;
            }
            if (FileUpload3.HasFile && System.IO.Path.GetExtension(FileUpload3.FileName) == ".pdf")
            {
                String path = Session["class"] + "/" + Session["enrollment"] + "/" +Session["enrollment"] + "-Thesis" + ".pdf";
                FileUpload3.SaveAs(Server.MapPath(@"~/" + Session["class"] + "/" + Session["enrollment"] + "/") + Session["enrollment"]+"-Thesis" + ".pdf");
                //update thesis_info
                SqlConnection con3 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");

                SqlCommand cmd3 = new SqlCommand("update thesis set status_id=@id, pdf_thesis_file_url=@url, submission_date=@date where enrollment=@enroll  ", con3);
                cmd3.Parameters.AddWithValue(@"enroll", Convert.ToString(Session["enrollment"]));
                cmd3.Parameters.AddWithValue(@"id", 2);
                cmd3.Parameters.AddWithValue(@"url", path);
                cmd3.Parameters.AddWithValue(@"date", Convert.ToString(DateTime.Now));
                con3.Open();
                cmd3.ExecuteNonQuery();
                con3.Close();

                Response.Redirect("new_student_submit_proposal.aspx");
            }
        }

        protected void update_thesis(object sender, EventArgs e)
        {
            if (!FileUpload4.HasFile)
            {
                Panel19.Visible = true;
            }
            if (FileUpload4.HasFile && System.IO.Path.GetExtension(FileUpload4.FileName) != ".pdf")
            {
                Panel20.Visible = true;
            }
            if (FileUpload4.HasFile && System.IO.Path.GetExtension(FileUpload4.FileName) == ".pdf")
            {
                if (Literal9.Text == "COND_APPROVED")
                {
                    String path = Session["class"] + "/" + Session["enrollment"] + "/" + Session["enrollment"] + "-Thesis" + ".pdf";
                    FileUpload4.SaveAs(Server.MapPath(@"~/" + Session["class"] + "/" + Session["enrollment"] + "/") + Session["enrollment"] + "-Thesis" + ".pdf");
                    //update thesis_info
                    SqlConnection con3 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");

                    SqlCommand cmd3 = new SqlCommand("update thesis set pdf_thesis_file_url=@url, submission_date=@date where enrollment=@enroll  ", con3);
                    cmd3.Parameters.AddWithValue(@"enroll", Convert.ToString(Session["enrollment"]));
                    cmd3.Parameters.AddWithValue(@"url", path);
                    cmd3.Parameters.AddWithValue(@"date", Convert.ToString(DateTime.Now));
                    con3.Open();
                    cmd3.ExecuteNonQuery();
                    con3.Close();

                    string examiner="";
                    string ex_email = "";
                    string keey = "";
                    int id = 1;
                    using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                    {


                        SqlDataReader reader2;
                        cn.Open();
                        String querystr2 = "select * from final_form_records inner join examiner on examiner.examiner_name=final_form_records.examiner_name where final_form_records.enrollment =@enroll and final_form_records.result=@res";

                        SqlCommand cmd2 = new SqlCommand(querystr2, cn);
                        cmd2.Parameters.AddWithValue(@"enroll", Session["enrollment"].ToString());
                        cmd2.Parameters.AddWithValue(@"res", "Condition");
                        reader2 = cmd2.ExecuteReader();

                        while (reader2.HasRows && reader2.Read())
                        {
                            examiner = reader2.GetString(reader2.GetOrdinal("examiner_name"));
                            ex_email = reader2.GetString(reader2.GetOrdinal("official_email"));
                            id = reader2.GetInt32(reader2.GetOrdinal("id"));
                            keey = reader2.GetString(reader2.GetOrdinal("keey"));
                        }
                        reader2.Close();
                        cn.Close();
                    }

                    //send mail
                    String from = "budrshehzad@gmail.com";
                    String to = ex_email;
                    String ccc = "ahmad31102@gmail.com";
                    String password = "Ahmad123";
                    String Message = "Respected " + "<b>" + examiner + "</b>" + "," + "<br />" + "<br />" + "This is to inform you that student has updated the thesis as per your requirements. Please have a look on the file attached with this mail and resubmit the evaluation form" + "<br />" + "Student Details are given Below." + "<br />" + "<br />" + "<b>Student Detials</b>" + "<br />" + "<b>Student Name : </b>" + Session["name"].ToString() + "<br />" + "<b>Program : </b>" + Session["class"].ToString() + "<br />" + "<b>Enrollment : </b>" + Session["enrollment"].ToString() + "<br />" + "<br />" + "Evaluation Form link is given below. Please Fill this form." + "</b>" + "<br />" + "http://localhost:21315/thesis_defense_evaluation_form/" + Session["enrollment"] +"/"+ Convert.ToString(id) + "/" + keey + ".aspx";
                    String subject = "Thesis Proposal Defense Evaluation Alert";
                    String host = "smtp.gmail.com";
                    int port = 587;
                    String file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);


                    //official mail send
                    Thread t = new Thread(() => Send(from, password, to, Message, subject, host, port, file, ccc));
                    t.Start();
                }
                else
                {
                    String path = Session["class"] + "/" + Session["enrollment"] + "/" + Session["enrollment"] + "-Thesis" + ".pdf";
                    FileUpload4.SaveAs(Server.MapPath(@"~/" + Session["class"] + "/" + Session["enrollment"] + "/") + Session["enrollment"] + "-Thesis" + ".pdf");
                    //update thesis_info
                    SqlConnection con3 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");

                    SqlCommand cmd3 = new SqlCommand("update thesis set pdf_thesis_file_url=@url, submission_date=@date where enrollment=@enroll  ", con3);
                    cmd3.Parameters.AddWithValue(@"enroll", Convert.ToString(Session["enrollment"]));
                    cmd3.Parameters.AddWithValue(@"url", path);
                    cmd3.Parameters.AddWithValue(@"date", Convert.ToString(DateTime.Now));
                    con3.Open();
                    cmd3.ExecuteNonQuery();
                    con3.Close();
                }
                Response.Redirect("new_student_submit_proposal.aspx");
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
    }

}