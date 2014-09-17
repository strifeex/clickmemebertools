using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class resetpass : System.Web.UI.Page
{
    ClickMemberToolsService.ClickMemberToolsServiceSoapClient Clicktoolservice = new ClickMemberToolsService.ClickMemberToolsServiceSoapClient();

    protected void Page_Load(object sender, EventArgs e)
    {
        int cmsId = Convert.ToInt32(MISCoreLibrary.ClsDecrypt.DecryptSTD(((Authensession)(Session["UserLoginSys"])).userAccId, "GjrAIdzK97quE67Pho3pBhpV6VPP72hB", "OI1miOctWpPCvOu9"));
        string cmsName = ((Authensession)(Session["UserLoginSys"])).userAccName;
        string username = Request.Params["clickId"];
        string newpassword = Request.Params["renewpw"];
        string userIP = Request.UserHostAddress;
        string responesStat = "";


        ClickMemberToolsService.ClickPasswordDataList resMemberPw = Clicktoolservice.GetMemberPassword(username);
        if (resMemberPw.ClickPasswordListResult.Length == 1)
        {

            string BackupRes = Clicktoolservice.ClickMemberPasswordBackup(Convert.ToInt32(resMemberPw.ClickPasswordListResult[0].memberId), resMemberPw.ClickPasswordListResult[0].memberPassword, cmsId, cmsName);

            switch (BackupRes)
            {
                case "0":
                    string res = Clicktoolservice.ClickMemberRenewPassword(username, newpassword);
                    if (res == "0") {
                        responesStat = "OK";
                        string logDeatail = username + " renew password = " + newpassword;
                        Clicktoolservice.LogAdd(cmsId, cmsName, "Renew Password", logDeatail, "resetpass.aspx", userIP);
 
                    }else if (res == "2")
                    {
                        responesStat = "NO_MEMBER";
                    }
                    else {
                        responesStat = "OTHER_ERROR";
                    }
                    
                    Response.Write("{ \"responseStat\":\"" + responesStat + "\" }");
                    break;
                case "2": responesStat = "NEED_INFO";
                    Response.Write("{ \"responseStat\":\"" + responesStat + "\" }");
                    break;
                case "3": responesStat = "MANY_ROW";
                    Response.Write("{ \"responseStat\":\"" + responesStat + "\" }");
                    break;
                case "6": responesStat = "PLEASE_ROLLBACK";
                    Response.Write("{ \"responseStat\":\"" + responesStat + "\" }");
                    break;
                default: responesStat = "ERROR";
                    Response.Write("{ \"responseStat\":\"" + responesStat + "\" }");
                    break;
            }
    
        }
        else {
            responesStat = "CLICK MEMBER WRONG";
            Response.Write("{ \"responseStat\":\"" + responesStat + "\" }");
        }

    }
}