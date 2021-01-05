using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

namespace admin1
{
    public partial class admin_student_proposal_submitted : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
            {

                
                SqlDataReader reader2;
                cn.Open();
                String querystr2 = "select * from proposal";

                SqlCommand cmd2 = new SqlCommand(querystr2, cn);

                //cmd2.Parameters.AddWithValue("@enrollment", Convert.ToInt32(Session["enrollment"]));

                reader2 = cmd2.ExecuteReader();

                int x = 0;
                Panel2.Controls.Add(new LiteralControl("<tr><th>No.</th><th>Enrollment</th><th>Name</th><th>Program</th><th>Setup Defense</th></tr>"));
                Table Table1 = new Table();
                while (reader2.HasRows && reader2.Read())
                {
                    ++x;
                    Session["student_enrollment"] = reader2.GetString(reader2.GetOrdinal("enrollment"));

                    //get student data
                    using (SqlConnection cn1 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                    {
                        String querystr3 = "select * from student_personal_info where enrollment=@enrollment";
                        SqlDataReader reader3;
                        cn1.Open();
                        SqlCommand cmd3 = new SqlCommand(querystr3, cn1);
                        cmd3.Parameters.AddWithValue("@enrollment", Convert.ToString(Session["student_enrollment"]));
                        reader3 = cmd3.ExecuteReader();
                        while (reader3.HasRows && reader3.Read())
                        {
                            String s_fname = reader3.GetString(reader3.GetOrdinal("first_name"));
                            String s_lname = reader3.GetString(reader3.GetOrdinal("last_name"));
                            Session["student_name"] = s_fname + " " + s_lname;
                            Session["student_program"] = reader3.GetString(reader3.GetOrdinal("program"));
                        }
                        reader3.Close();
                        cn1.Close();
                    }
                    //get Student Data End

                    //get student_thesis info
                    using (SqlConnection cn2 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                    {
                        String querystr4 = "select * from student_thesis_info where enrollment=@enrollment";
                        SqlDataReader reader4;
                        cn2.Open();
                        SqlCommand cmd4 = new SqlCommand(querystr4, cn2);
                        cmd4.Parameters.AddWithValue("@enrollment", Convert.ToString(Session["student_enrollment"]));
                        reader4 = cmd4.ExecuteReader();
                        while (reader4.HasRows && reader4.Read())
                        {
                            Session["student_project_title"] = reader4.GetString(reader4.GetOrdinal("research_area"));
                        }
                        reader4.Close();
                        cn2.Close();
                    }
                    //get student_thesis info End


                    ///////////////////////////
                    //< asp:Button runat = ""server"" text = ""SetupDefense"" style = ""background - color: Black; border: none; color: white; padding: 15px 32px; text - align: center; text - decoration: none; display: inline - block; font - size: 16px; margin: 4px 2px; cursor: pointer; "" />
                    /////////////////////////////////
                    //    System.Web.UI.HtmlControls.HtmlButton btn = new System.Web.UI.HtmlControls.HtmlButton();
                    //btn.ID = "myID";
                    //btn.Attributes["class"] = "btn btn-primary";
                    ////btn.ServerClick += new EventHandler(someFunc);
                    //btn.InnerHtml = "<i class=\"Setup Defense\">add</i>";

                    //String aa = "Panel" + Convert.ToString(x);
                    //Panel2.Controls.Add(new LiteralControl("<tr><th>"+Convert.ToString(Session["student_enrollment"])+ " </th><td>" + Convert.ToString(Session["student_name"]) + "</td><td>" + Convert.ToString(Session["student_program"]) + "</td>"));
                    //Panel2.Controls.Add(btn);
                    //Panel2.Controls.Add(new LiteralControl("<td></td></tr>"));


                    ////////////////////

                    HtmlGenericControl myDiv = new HtmlGenericControl("div");
                    myDiv.ID = "myDiv";
                    LinkButton myLnkBtn = new LinkButton();
                    myLnkBtn.ID = Convert.ToString(Session["student_enrollment"]);
                    myLnkBtn.Click += new EventHandler(setup_defense_Click);
                    myLnkBtn.Text = "Setup Proposal Defense";
                    myLnkBtn.Attributes["class"] = "btn btn-primary";
                    myDiv.Controls.Add(myLnkBtn);
                    //Panel2.Controls.Add();


                    /////////////////////////////////////////////


                    // Create new row and add it to the table.
                    TableRow tRow = new TableRow();
                    
                    //Table1.Rows.Add(tRow);
                        // Create a new cell and add it to the row.
                        TableCell tCell1 = new TableCell();
                    TableCell tCell2 = new TableCell();
                    TableCell tCell3 = new TableCell();
                    TableCell tCell4 = new TableCell();
                    TableCell tCell5 = new TableCell();

                    tCell1.Text = "DSZFsadfasd";
                        tRow.Cells.Add(tCell1);
                        Button bt = new Button();
                        bt.Text = "Click Me";
                        bt.Click += new EventHandler(setup_defense_Click);
                    //"<tr><td>" + Convert.ToString(x) + "</td><th>" + Convert.ToString(Session["student_enrollment"]) + " </th><td>" + Convert.ToString(Session["student_name"]) + "</td><td>" + Convert.ToString(Session["student_program"]) + "</td><td><a ID=\"MyAnchor\" OnClick = \"setup_defense_Click\" runat = \"server\" > Click This </ a ></td></tr>"
                    tCell1.Controls.Add(new LiteralControl(Convert.ToString(x)));
                    tCell2.Controls.Add(new LiteralControl(Convert.ToString(Session["student_enrollment"])));
                    tCell3.Controls.Add(new LiteralControl(Convert.ToString(Session["student_name"])));
                    tCell4.Controls.Add(new LiteralControl(Convert.ToString(Session["student_program"])));
                    tCell5.Controls.Add(myLnkBtn);
                    tRow.Cells.Add(tCell1);
                    tRow.Cells.Add(tCell2);
                    tRow.Cells.Add(tCell3);
                    tRow.Cells.Add(tCell4);
                    tRow.Cells.Add(tCell5);

                    Panel2.Controls.Add(tRow);
                }
                reader2.Close();
                cn.Close();
            }
        }

        protected void setup_defense_Click(object sender, EventArgs e)
        {
            //Response.Redirect("SignIn.aspx");
            LinkButton lbtn = (LinkButton)sender;
            string id = lbtn.ID;

            using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
            {


                SqlDataReader reader2;
                cn.Open();
                String querystr2 = "select * from student_personal_info where enrollment=@enrollment";

                SqlCommand cmd2 = new SqlCommand(querystr2, cn);

                cmd2.Parameters.AddWithValue("@enrollment", id);

                reader2 = cmd2.ExecuteReader();
                String fname;
                String lname;
                while (reader2.HasRows && reader2.Read())
                {
                    Session["proposal_defense_student_enrollment"] = reader2.GetString(reader2.GetOrdinal("enrollment"));
                    fname = reader2.GetString(reader2.GetOrdinal("first_name"));
                    lname = reader2.GetString(reader2.GetOrdinal("last_name"));
                    Session["proposal_defense_student_name"] = fname + " " + lname;
                    Session["proposal_defense_student_program"] = reader2.GetString(reader2.GetOrdinal("program"));
                }
                reader2.Close();
                cn.Close();
            }

                    //get proposal data
                    using (SqlConnection cn1 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                    {
                        String querystr3 = "select * from proposal,status where proposal.enrollment=@enrollment and proposal.status_id=status.status_id";
                        SqlDataReader reader3;
                        cn1.Open();
                        SqlCommand cmd3 = new SqlCommand(querystr3, cn1);
                        cmd3.Parameters.AddWithValue("@enrollment", id);
                        reader3 = cmd3.ExecuteReader();
                        while (reader3.HasRows && reader3.Read())
                        {
                            Session["proposal_defense_submission_date"] = reader3.GetString(reader3.GetOrdinal("submission_date"));
                        Session["proposal_defense_proposal_status"] = reader3.GetString(reader3.GetOrdinal("status"));
                    }
                        reader3.Close();
                        cn1.Close();
                    }

            //get proposal data
            using (SqlConnection cn1 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
            {
                String querystr3 = "select * from student_thesis_info where enrollment=@enrollment";
                SqlDataReader reader3;
                cn1.Open();
                SqlCommand cmd3 = new SqlCommand(querystr3, cn1);
                cmd3.Parameters.AddWithValue("@enrollment", id);
                reader3 = cmd3.ExecuteReader();
                while (reader3.HasRows && reader3.Read())
                {
                    Session["proposal_defense_project_title"] = reader3.GetString(reader3.GetOrdinal("research_area"));
                    
                }
                reader3.Close();
                cn1.Close();
            }

            Response.Redirect("Proposal_Defence.aspx");

        }
    }
}