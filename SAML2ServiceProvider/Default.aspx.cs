using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;

using ComponentSpace.SAML2;
using ComponentSpace.SAML2.Assertions;
using ComponentSpace.SAML2.Protocols;
using ComponentSpace.SAML2.Profiles.SingleLogout;

namespace SAML2ServiceProvider
{
    public partial class _Default : System.Web.UI.Page
    {
        private string CreateAbsoluteURL(string relativeURL)
        {
            return new Uri(Request.Url, ResolveUrl(relativeURL)).ToString();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void logoutButton_Click(object sender, EventArgs e)
        {
            try
            {
                LogoutRequest logoutRequest = new LogoutRequest();
                logoutRequest.Issuer = new Issuer(CreateAbsoluteURL("~/"));
                logoutRequest.NameID = new NameID(Context.User.Identity.Name);
                XmlElement logoutRequestXml = logoutRequest.ToXml();
                string logoutURL = WebConfigurationManager.AppSettings["idpLogoutURL"];
                X509Certificate2 x509Certificate = (X509Certificate2)Application[Global.SPX509Certificate];
                SingleLogoutService.SendLogoutRequestByHTTPRedirect(Response, logoutURL, logoutRequestXml, null, x509Certificate.PrivateKey, null);
                FormsAuthentication.SignOut();
                Session.Abandon();
            }
            catch (Exception exception)
            {
                Trace.Write("SP", "Error on logout page", exception);
            }
        }
    }
}
