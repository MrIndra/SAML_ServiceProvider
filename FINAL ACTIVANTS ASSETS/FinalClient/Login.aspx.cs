using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace FinalClient
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void continueButton_Click(object sender, EventArgs e)
        {
            try
            {
                var partnerId = "http://localhost:64712/SAML/AssertionConsumerService.aspx";
                var target = "http://localhost:64723/default.aspx";
                //Response.Redirect("http://localhost:64614/login.aspx?target{0}=&partnerId={1}", target, partnerId);
            }
            catch(Exception ex)
            {
                errorMessageLabel.Text = ex.GetType().ToString();
            }
        }
    }
}
