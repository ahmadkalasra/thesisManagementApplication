using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace admin1
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["enrollment"] as string))
            {

                enrollment.Text = Session["enrollment"].ToString();
                registration.Text = Session["registration_no"].ToString();
                intake.Text = Session["intake_semester"].ToString();
                name.Text = Session["name"].ToString();
                class_name.Text = Session["class"].ToString();
                fathername.Text = Session["father_name"].ToString();
                degreeduration.Text = Session["degree_duration"].ToString();
                phone.Text = Session["phone"].ToString();
                phone2.Text = Session["phone2"].ToString();
                address.Text = Session["address"].ToString();
                pemail.Text = Session["pemail"].ToString();
                uemail.Text = Session["uemail"].ToString();
                community.Text = Session["community_support_work"].ToString();
            }
            else
            {
                Response.Redirect("SignIn.aspx");
            }
        }
    }
}