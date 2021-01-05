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
    public partial class admin_frc_setup : System.Web.UI.Page
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
            }
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
        }
        protected void setup_FRC_Click(object sender, EventArgs e)
        {
            if (meeting_title.Text == "")
            {
                Panel1.Visible = true;
            }
            if (datetimepicker.Text == String.Empty)
            {
                Panel2.Visible = true;
            }
            if (!FileUpload1.HasFile)
            {
                Panel3.Visible = true;
            }
            if (FileUpload1.HasFile && FileUpload1.PostedFile.ContentType != "application/pdf")
            {
                Panel3.Visible = false;
                Panel4.Visible = true;
            }
            if (FileUpload1.HasFile && FileUpload1.PostedFile.ContentType == "application/pdf")
            {
                Panel3.Visible = false;
                Panel4.Visible = false;

                if (!System.IO.Directory.Exists(Server.MapPath(@"~/" + "Thesis-System" + "/" + "FRC-Details" + "/")))
                {
                    
                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");

                    
                    SqlCommand cmd = new SqlCommand("insert into frc(frc_type_id, meeting_name, date, frc_status_id) values (@frc_type_id, @meeting_name, @date, @frc_status_id)", con);
                    cmd.Parameters.AddWithValue(@"frc_type_id", 1);
                    cmd.Parameters.AddWithValue(@"meeting_name", meeting_title.Text);
                    cmd.Parameters.AddWithValue(@"date", datetimepicker.Text);
                    cmd.Parameters.AddWithValue(@"frc_status_id", 2);
                    
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();


                    using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                    {


                        SqlDataReader reader2;
                        cn.Open();
                        String querystr2 = "select * from frc where frc_id=(select max(frc_id) from frc)";

                        SqlCommand cmd2 = new SqlCommand(querystr2, cn);

                        //cmd2.Parameters.AddWithValue("@sup_id", Convert.ToInt32(Session["suggested_supervisor_id"]));

                        reader2 = cmd2.ExecuteReader();


                        while (reader2.HasRows && reader2.Read())
                        {
                            Session["frc_id"] = reader2.GetInt32(reader2.GetOrdinal("frc_id"));
                            Session["frc_meeting_title"] = reader2.GetString(reader2.GetOrdinal("meeting_name"));

                        }
                        reader2.Close();
                        cn.Close();
                    }
                    //File upload
                    
                    System.IO.Directory.CreateDirectory(Server.MapPath(@"~/" + "Thesis-System" + "/" + "FRC-Details" + "/"));
                    string filename = Path.GetFileName(FileUpload1.FileName);
                    FileUpload1.SaveAs(Server.MapPath(@"~/" + "Thesis-System" + "/" + "FRC-Details" + "/") + Session["frc_id"] + "-" + Session["frc_meeting_title"] + ".pdf");

                    //update file url
                    String val = "Thesis-System" + "/" + "FRC-Details" + "/" + Session["frc_id"] + "-" + Session["frc_meeting_title"] + ".pdf";

                    SqlConnection con12 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");


                    SqlCommand cmd12 = new SqlCommand("update frc set frc_scanned_file_url=@frc_scanned_file_url", con12);
                    cmd12.Parameters.AddWithValue("@frc_scanned_file_url", val);

                    con12.Open();
                    cmd12.ExecuteNonQuery();
                    con12.Close();
                    meeting_title.Text = "";
                    datetimepicker.Text = "";
                    Panel5.Visible = true;

                }
                else
                {
                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");


                    SqlCommand cmd = new SqlCommand("insert into frc(frc_type_id, meeting_name, date, frc_status_id) values (@frc_type_id, @meeting_name, @date, @frc_status_id)", con);
                    cmd.Parameters.AddWithValue(@"frc_type_id", 1);
                    cmd.Parameters.AddWithValue(@"meeting_name", meeting_title.Text);
                    cmd.Parameters.AddWithValue(@"date", datetimepicker.Text);
                    cmd.Parameters.AddWithValue(@"frc_status_id", 2);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();


                    using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True"))
                    {


                        SqlDataReader reader2;
                        cn.Open();
                        String querystr2 = "select * from frc where frc_id=(select max(frc_id) from frc)";

                        SqlCommand cmd2 = new SqlCommand(querystr2, cn);

                        //cmd2.Parameters.AddWithValue("@sup_id", Convert.ToInt32(Session["suggested_supervisor_id"]));

                        reader2 = cmd2.ExecuteReader();


                        while (reader2.HasRows && reader2.Read())
                        {
                            Session["frc_id"] = reader2.GetInt32(reader2.GetOrdinal("frc_id"));
                            Session["frc_meeting_title"] = reader2.GetString(reader2.GetOrdinal("meeting_name"));

                        }
                        reader2.Close();
                        cn.Close();
                    }
                    //File upload

                    string filename = Path.GetFileName(FileUpload1.FileName);
                    FileUpload1.SaveAs(Server.MapPath(@"~/" + "Thesis-System" + "/" + "FRC-Details" + "/") + Session["frc_id"] + "-" + Session["frc_meeting_title"] + ".pdf");

                    //update file url
                    String val = "Thesis-System" + "/" + "FRC-Details" + "/" + Session["frc_id"] + "-" + Session["frc_meeting_title"] + ".pdf";

                    SqlConnection con12 = new SqlConnection("Data Source=LAPTOP-34R30R6Q\\MSSQLSERVERLATES;Initial Catalog=MS_PHD_THESIS_SYSTEM_2;Integrated Security=True");


                    SqlCommand cmd12 = new SqlCommand("update frc set frc_scanned_file_url=@frc_scanned_file_url", con12);
                    cmd12.Parameters.AddWithValue("@frc_scanned_file_url", val);

                    con12.Open();
                    cmd12.ExecuteNonQuery();
                    con12.Close();
                    meeting_title.Text = "";
                    datetimepicker.Text = "";
                    Panel5.Visible = true;
                }
            }
        }
    }
}