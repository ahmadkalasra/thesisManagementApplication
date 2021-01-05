using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblDomainName.Text = ConfigurationManager.AppSettings["DomainName"].ToString();
    }

    protected void GenerateShortUrl(object sender, EventArgs e)
    {
        ShortUrl.Container oShortUrl = new ShortUrl.Container();

        oShortUrl.RealUrl = txtRealUrl.Text;
        oShortUrl.ShortenedUrl = ShortUrl.Utils.UniqueShortUrl();
        oShortUrl.CreateDate = DateTime.Now;
        oShortUrl.CreatedBy = HttpContext.Current.Request.UserHostAddress;

        ShortUrl.Utils.AddUrlToDatabase(oShortUrl);

        oShortUrl.ShortenedUrl = ShortUrl.Utils.PublicShortUrl(oShortUrl.ShortenedUrl);

        lnkShortUrl.Text = oShortUrl.ShortenedUrl;
        lnkShortUrl.NavigateUrl = oShortUrl.ShortenedUrl;
    }
}
