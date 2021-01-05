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
using System.Security.Cryptography;

namespace admin1
{
    public partial class quarterly_report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel2.Visible = false;
            Panel10.Visible = false;
            Panel3.Visible = false;
            if (Page.RouteData.Values["enrollment121"] == null || Page.RouteData.Values["ex_id1"] == null)
            {
                Panel1.Visible = false;
                Panel2.Visible = true;

            }
            if (Page.RouteData.Values["enrollment121"] != null || Page.RouteData.Values["ex_id1"] != null)
            {
                using (SqlConnection cnn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                {


                    SqlDataReader reader;
                    cnn.Open();
                    String querystr = "select * from report where enrollment=@enroll and report_num=@num and keey=@key";

                    SqlCommand cmd = new SqlCommand(querystr, cnn);

                    cmd.Parameters.AddWithValue("@enroll", Convert.ToString(Page.RouteData.Values["enrollment121"]));
                    cmd.Parameters.AddWithValue("@num", Convert.ToInt32(Page.RouteData.Values["ex_id1"]));
                    cmd.Parameters.AddWithValue("@key", Convert.ToString(Page.RouteData.Values["keey1"]));
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.HasRows && reader.Read())
                        {
                            if (!reader.IsDBNull(reader.GetOrdinal("comments")))
                            {
                                Panel1.Visible = false;
                                Panel2.Visible = true;
                            }
                            else
                            {
                                using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                                {


                                    SqlDataReader reader2;
                                    cn.Open();
                                    String querystr2 = "select * from proposal inner join defense on defense.def_id=proposal.defense_id right join student_thesis_info on student_thesis_info.enrollment=@enroll right join student_personal_info on student_personal_info.enrollment=@enroll right join defense_examiner on defense_examiner.defense_id=proposal.defense_id where proposal.enrollment=@enroll";

                                    SqlCommand cmd2 = new SqlCommand(querystr2, cn);

                                    cmd2.Parameters.AddWithValue("@enroll", Convert.ToString(Page.RouteData.Values["enrollment121"]));

                                    reader2 = cmd2.ExecuteReader();


                                    while (reader2.HasRows && reader2.Read())
                                    {

                                        if (!reader2.IsDBNull(reader2.GetOrdinal("date")))
                                        {
                                            String fname = reader2.GetString(reader2.GetOrdinal("first_name"));
                                            String lname = reader2.GetString(reader2.GetOrdinal("last_name"));
                                            Session["Form-10-student_name"] = fname + " " + lname;
                                            sname.Text = Session["Form-10-student_name"].ToString();
                                            Literal1.Text = Convert.ToString(reader2.GetInt32(reader2.GetOrdinal("registration_number")));
                                            Literal2.Text = Convert.ToString(reader2.GetString(reader2.GetOrdinal("program")));
                                            Session["Form-10-"] = reader2.GetString(reader2.GetOrdinal("date"));
                                            Session["Form-10-research_title"] = reader2.GetString(reader2.GetOrdinal("research_area"));
                                            Literal5.Text = Session["Form-10-research_title"].ToString();

                                            Session["Form_10_expert_id"] = reader2.GetInt32(reader2.GetOrdinal("supervisor_id"));

                                            using (SqlConnection cn1 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                                            {


                                                SqlDataReader reader21;
                                                cn1.Open();
                                                String querystr21 = "select * from supervisor where supervisor_id=@id";

                                                SqlCommand cmd21 = new SqlCommand(querystr21, cn1);

                                                cmd21.Parameters.AddWithValue("@id", Convert.ToInt32(Session["Form_10_expert_id"]));

                                                reader21 = cmd21.ExecuteReader();


                                                while (reader21.HasRows && reader21.Read())
                                                {
                                                    Session["MS_10_Expert_Name"] = reader21.GetString(reader21.GetOrdinal("sup_name"));
                                                    Literal6.Text = Session["MS_10_Expert_Name"].ToString();
                                                    DateTime dd = DateTime.Now;
                                                    string date = dd.ToString("dd/MM/yyyy");
                                                    Literal7.Text = date;
                                                }
                                                reader21.Close();
                                                cn1.Close();
                                            }
                                        }


                                    }
                                    reader2.Close();
                                    cn.Close();
                                } 
                                using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                                {


                                    SqlDataReader reader2;
                                    cn.Open();
                                    String querystr2 = "select * from report where enrollment=@enroll and report_num=@num and keey=@key";

                                    SqlCommand cmd2 = new SqlCommand(querystr2, cn);
                                    cmd2.Parameters.AddWithValue("@enroll", Convert.ToString(Page.RouteData.Values["enrollment121"]));
                                    cmd2.Parameters.AddWithValue("@num", Convert.ToString(Page.RouteData.Values["enrollment121"]));
                                    cmd2.Parameters.AddWithValue("@key", Convert.ToString(Page.RouteData.Values["enrollment121"]));
                                    reader2 = cmd2.ExecuteReader();

                                    while (reader2.HasRows && reader2.Read())
                                    {
                                        Session["settup_defense_proposal_file_url"] = reader2.GetString(reader2.GetOrdinal("proposal_file_url"));
                                    }
                                    reader2.Close();
                                    cn.Close();
                                }
                                Literal10.Text = reader.GetString(reader.GetOrdinal("from_date"));
                                Literal11.Text = reader.GetString(reader.GetOrdinal("to_date"));
                            }

                        }
                    }
                    else
                    {
                        Panel1.Visible = false;
                        Panel2.Visible = true;
                    }
                    reader.Close();
                    cnn.Close();
                }

            }
            else
            {
                Panel1.Visible = false;
                Panel2.Visible = true;
            }
        }
        protected void update_click(object sender, EventArgs e)
        {
            if(TextArea1.InnerText==string.Empty)
            {
                Panel10.Visible = true;
            }
            if(RadioButtonList1.SelectedValue=="")
            {
                Panel3.Visible = true;
            }
            if (TextArea1.InnerText != string.Empty && RadioButtonList1.SelectedValue!="")
            {
                if (RadioButtonList1.SelectedItem.Value == "1" || RadioButtonList1.SelectedItem.Value == "2" || RadioButtonList1.SelectedItem.Value == "3")
                {
                    SqlConnection con1 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");

                    SqlCommand cmd1 = new SqlCommand("update  report set comments=@comments, result=@result where enrollment=@enroll and report_num=@num and keey=@key", con1);
                    cmd1.Parameters.AddWithValue(@"enroll", Convert.ToString(Page.RouteData.Values["enrollment121"]));
                    cmd1.Parameters.AddWithValue(@"num", Convert.ToInt32(Page.RouteData.Values["ex_id1"]));
                    cmd1.Parameters.AddWithValue(@"key", Convert.ToString(Page.RouteData.Values["keey1"]));
                    cmd1.Parameters.AddWithValue(@"comments", TextArea1.InnerText);
                    if (RadioButtonList1.SelectedItem.Value == "1")
                    {
                        cmd1.Parameters.AddWithValue(@"result", "Excellent");
                    }
                    if (RadioButtonList1.SelectedItem.Value == "2")
                    {
                        cmd1.Parameters.AddWithValue(@"result", "Satisfactory");
                    }
                    if (RadioButtonList1.SelectedItem.Value == "3")
                    {
                        cmd1.Parameters.AddWithValue(@"result", "Unsatisfactory");
                    }
                    con1.Open();
                    cmd1.ExecuteNonQuery();
                    con1.Close();

                    int x = 0;
                    using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                    {


                        SqlDataReader reader2;
                        cn.Open();
                        String querystr2 = "select * from report where enrollment=@enroll ";

                        SqlCommand cmd2 = new SqlCommand(querystr2, cn);
                        cmd2.Parameters.AddWithValue("@enroll", Convert.ToString(Page.RouteData.Values["enrollment121"]));
                        reader2 = cmd2.ExecuteReader();

                        while (reader2.HasRows && reader2.Read())
                        {
                            if(reader2.IsDBNull(reader2.GetOrdinal("comments")))
                            {
                                x = 0;
                            }
                            else
                            {
                                x = 1;
                            }
                        }

                        reader2.Close();
                        cn.Close();
                    }
                    if(x==1)
                    {
                        DateTime dd21 = DateTime.Now.Date;
                        string date21 = dd21.ToString("dd/MM/yyyy");
                        
                        SqlConnection con = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");

                        SqlCommand cmd = new SqlCommand("insert into thesis (enrollment, due_date) values (@enroll, @date)", con);
                        cmd.Parameters.AddWithValue(@"enroll", Convert.ToString(Page.RouteData.Values["enrollment121"]));
                        cmd.Parameters.AddWithValue(@"date", date21);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        //select thesis id
                        int th_id=0;
                        using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                        {


                            SqlDataReader reader2;
                            cn.Open();
                            String querystr2 = "select * from thesis where enrollment=@enroll  ";

                            SqlCommand cmd2 = new SqlCommand(querystr2, cn);
                            cmd2.Parameters.AddWithValue("@enroll", Convert.ToString(Page.RouteData.Values["enrollment121"]));
                            reader2 = cmd2.ExecuteReader();

                            while (reader2.HasRows && reader2.Read())
                            {
                                th_id = reader2.GetInt32(reader2.GetOrdinal("thesis_id"));
                            }
                            reader2.Close();
                            cn.Close();
                        }

                        //update student_thesis_info
                        SqlConnection con3 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");

                        SqlCommand cmd3 = new SqlCommand("update student_thesis_info set thesis_id=@id where enrollment=@enroll  ", con3);
                        cmd3.Parameters.AddWithValue(@"enroll", Convert.ToString(Page.RouteData.Values["enrollment121"]));
                        cmd3.Parameters.AddWithValue(@"id", th_id);
                        con3.Open();
                        cmd3.ExecuteNonQuery();
                        con3.Close();
                    }
                    Panel1.Visible = false;
                    Panel4.Visible = true;
                }

            }
        }
    }
}