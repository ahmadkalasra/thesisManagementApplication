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
    public partial class Proposal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;

            if (!string.IsNullOrEmpty(Session["enrollment"] as string))
            {
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
                        while (reader5.HasRows && reader5.Read())
                        {
                            Session["proposal_id"] = reader5.GetInt32(reader5.GetOrdinal("pro_id"));
                            Session["proposal_status_id"] = reader5.GetInt32(reader5.GetOrdinal("status_id"));
                            Session["Assigned_supervisor_id"] = reader5.GetInt32(reader5.GetOrdinal("supervisor_id"));
                            Session["proposal_submission_date"] = reader5.GetString(reader5.GetOrdinal("submission_date"));

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
                        supervisor_status.Text = "PENDING";
                        approval_status.Text = Session["proposal_status"].ToString();
                        submisssion_date.Text = Session["proposal_submission_date"].ToString();
                     
                        Panel1.Visible = true;
                    }
                    reader5.Close();
                    cn5.Close();
                }

                //--------------------------Select proposal Data End-------------------------

                
                

            }
            else
            {
                Response.Redirect("SignIn.aspx");
            }
        }

        protected void upload_Click(object sender, EventArgs e)
        {
            if(project_title.Text == "")
            {
                Panel2.Visible = true;
                errortext.Text = "Please Enter Project Title";
            }
            if (project_abstract.InnerText == "")
            {
                Panel2.Visible = true;
                errortext.Text = "Please write Project Abstract";
            }
            if (supervisor.Items[supervisor.SelectedIndex].Text == "-----SELECT-----")
            {
                Panel2.Visible = true;
                errortext.Text = "Please Select Research Area then Upload";
            }
            else
            {
                if (FileUpload1.HasFile && System.IO.Path.GetExtension(FileUpload1.FileName) == ".pdf" && project_title.Text != "" && supervisor.Items[supervisor.SelectedIndex].Text != "-----SELECT-----")
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
                        Response.Redirect("Home.aspx");
                    }
                    else
                    {
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

                        Response.Redirect("Home.aspx");
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
                    response.AddHeader("Content-Disposition", "attachment;filename=\"" + Server.MapPath(@"~/" + Session["class"] + "/" + Session["enrollment"] + "/" + Session["enrollment"] + ".pdf") + "\"");
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
            

    }
}