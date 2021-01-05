using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace admin1
{
    public partial class Proposal_Defence : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            enrollment.Text = Convert.ToString(Session["proposal_defense_student_enrollment"]);
            name.Text = Convert.ToString(Session["proposal_defense_student_name"]);
            program.Text = Convert.ToString(Session["proposal_defense_student_program"]);
            research_area.Text = Convert.ToString(Session["proposal_defense_project_title"]);
            approval_status.Text = Convert.ToString(Session["proposal_defense_proposal_status"]);
            submisssion_date.Text = Convert.ToString(Session["proposal_defense_submission_date"]);


        }
    }
}