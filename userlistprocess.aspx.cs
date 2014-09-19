using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class userlistprocess : System.Web.UI.Page
{
    ClickMemberToolsService.ClickMemberToolsServiceSoapClient Clicktoolservice = new ClickMemberToolsService.ClickMemberToolsServiceSoapClient();

    protected void Page_Load(object sender, EventArgs e)
    {
        //int cmsId = Convert.ToInt32(MISCoreLibrary.ClsDecrypt.DecryptSTD(((Authensession)(Session["UserLoginSys"])).userAccId, "GjrAIdzK97quE67Pho3pBhpV6VPP72hB", "OI1miOctWpPCvOu9"));
        //string cmsName = ((Authensession)(Session["UserLoginSys"])).userAccName;
        //string username = Request.Params["searchUsername"];
        //string userIP = Request.UserHostAddress;


        ClickMemberToolsService.UserCMSDataList resCMSuser = Clicktoolservice.UserCMSList();
        int ResLength = resCMSuser.UserCMSListResult.Length;
        
        if (ResLength >= 1)
        {
            Response.Write("[");
            while (ResLength > 0)
            {
                ResLength -= 1;

                Response.Write("{ \"No\":\"" + resCMSuser.UserCMSListResult[ResLength].No + "\", ");
                Response.Write("\"userId\":\"" + resCMSuser.UserCMSListResult[ResLength].userId + "\", ");
                Response.Write("\"userName\":\"" + resCMSuser.UserCMSListResult[ResLength].userName + "\", ");
                Response.Write("\"userPwd\":\"" + resCMSuser.UserCMSListResult[ResLength].userPwd + "\", ");
                Response.Write("\"firstName\":\"" + resCMSuser.UserCMSListResult[ResLength].firstName + "\", ");
                Response.Write("\"lastName\":\"" + resCMSuser.UserCMSListResult[ResLength].lastName + "\" ");
                Response.Write("}");

                if (ResLength > 0)
                {
                    Response.Write(",");
                }
            }
            Response.Write("]");
        }
        else
        {
            Response.Write("[]");
        }
    }
}