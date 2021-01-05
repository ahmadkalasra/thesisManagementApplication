using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;

namespace admin1
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RoutingData(RouteTable.Routes);
        }

        private void RoutingData(RouteCollection routecollection)
        {
            routecollection.MapPageRoute("", "MS-10-Form/{enrollment12}/{ex_id}/{keey}.aspx", "~/MS-10-Form.aspx");
            routecollection.MapPageRoute("", "quarterly-report/{enrollment121}/{ex_id1}/{keey1}.aspx", "~/quarterly-report.aspx");
            routecollection.MapPageRoute("", "thesis_defense_evaluation_form/{enrollment1212}/{ex_id12}/{keey12}.aspx", "~/thesis_defense_evaluation_form.aspx");
        }
        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

    }
}
