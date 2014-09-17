using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class loginPage : System.Web.UI.Page
{
    wsClickService.IwsClickAlotCMSClient ClickCRM = new wsClickService.IwsClickAlotCMSClient();
    ClickMemberToolsService.ClickMemberToolsServiceSoapClient Clicktoolservice = new ClickMemberToolsService.ClickMemberToolsServiceSoapClient();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserLoginSys"] != null)
        {
            int userId = Convert.ToInt32(MISCoreLibrary.ClsDecrypt.DecryptSTD(((Authensession)(Session["UserLoginSys"])).userAccId, "GjrAIdzK97quE67Pho3pBhpV6VPP72hB", "OI1miOctWpPCvOu9"));

            string userIP = Request.UserHostAddress;
            ClickCRM.UserLogout(userId, userIP);

            string logDeatail = ((Authensession)(Session["UserLoginSys"])).userFirstName + " Logout from ClickMemberTools ";
            Clicktoolservice.LogAdd(userId, ((Authensession)(Session["UserLoginSys"])).userAccName, "Logout", logDeatail, "loginPage.aspx", userIP);

            Session.Abandon();
        }
    }
}