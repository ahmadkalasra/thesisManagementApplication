﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace admin1
{
    public partial class admin_logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session.Clear();
            //Session.Abandon();
            //Response.Cookies["admin_name"].Value = string.Empty;
            //Session["check"] = "abd";
            //Response.Redirect("admin_login.aspx");

            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("admin_login.aspx");
        }
    }
}