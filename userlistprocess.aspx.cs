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
        int count = 0;
        if (ResLength >= 1)
        {
            Response.Write("[");
            while (count < ResLength)
            {
                Response.Write("{ \"No\":\"" + resCMSuser.UserCMSListResult[count].No + "\", ");
                Response.Write("\"userId\":\"" + resCMSuser.UserCMSListResult[count].userId + "\", ");
                Response.Write("\"userName\":\"" + resCMSuser.UserCMSListResult[count].userName + "\", ");
                Response.Write("\"userPwd\":\"" + resCMSuser.UserCMSListResult[count].userPwd + "\", ");
                Response.Write("\"firstName\":\"" + resCMSuser.UserCMSListResult[count].firstName + "\", ");
                Response.Write("\"lastName\":\"" + resCMSuser.UserCMSListResult[count].lastName + "\" ");
                Response.Write("}");

                count++;

                if (count < ResLength)
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