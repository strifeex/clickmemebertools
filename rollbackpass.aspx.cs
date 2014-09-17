using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class rollbackpass : System.Web.UI.Page
{
    ClickMemberToolsService.ClickMemberToolsServiceSoapClient Clicktoolservice = new ClickMemberToolsService.ClickMemberToolsServiceSoapClient();

    protected void Page_Load(object sender, EventArgs e)
    {
        int cmsId = Convert.ToInt32(MISCoreLibrary.ClsDecrypt.DecryptSTD(((Authensession)(Session["UserLoginSys"])).userAccId, "GjrAIdzK97quE67Pho3pBhpV6VPP72hB", "OI1miOctWpPCvOu9"));
        string cmsName = ((Authensession)(Session["UserLoginSys"])).userAccName;
        string username = Request.Params["clickId"];
        string userIP = Request.UserHostAddress;
        string responesStat = "";

        
        ClickMemberToolsService.ClickPasswordDataList resMemberPw = Clicktoolservice.GetMemberPassword(username);


        if (resMemberPw.ClickPasswordListResult.Length == 1)
        {

            string[] resGetBackupPw = Clicktoolservice.GetBackupPassword(Convert.ToInt32(resMemberPw.ClickPasswordListResult[0].memberId));
            if (resGetBackupPw[0].ToString() == "0")
            {
                string resRollback = Clicktoolservice.ClickMemberSetPassword(username, resGetBackupPw[1].ToString());

                switch (resRollback)
                {
                    case "0":
                        string res = Clicktoolservice.ClickMemberPasswordRollbackComplete(Convert.ToInt32(resMemberPw.ClickPasswordListResult[0].memberId), cmsId, cmsName);
                        if (res == "0")
                        {                            
                            string logDeatail = username + " password rollback";
                            Clicktoolservice.LogAdd(cmsId, cmsName, "Rollback Password", logDeatail, "rollbackpass.aspx", userIP);
                            responesStat = "OK";

                        }
                        else if (res == "2")
                        {
                            responesStat = "NEED_INFO";
                        }
                        else
                        {
                            responesStat = "MANY_ROW";
                        }

                        Response.Write("{ \"responseStat\":\"" + responesStat + "\" }");
                        break;
                    case "2": responesStat = "NO_MEMBER";
                        Response.Write("{ \"responseStat\":\"" + responesStat + "\" }");
                        break;
                    default: responesStat = "ERROR";
                        Response.Write("{ \"responseStat\":\"" + responesStat + "\" }");
                        break;
                }

            }
            else if (resGetBackupPw[0].ToString() == "4")
            {
                responesStat = "PASSWORD NOT RENEW";
                Response.Write("{ \"responseStat\":\"" + responesStat + "\" }");
            }
            else {
                responesStat = "CAN'T GET ROLLBACK PASSWORD";
                Response.Write("{ \"responseStat\":\"" + responesStat + "\" }");
            }

        }
        else
        {
            responesStat = "CLICK MEMBER WRONG";
            Response.Write("{ \"responseStat\":\"" + responesStat + "\" }");
        }




        //wsClickMemberService.ClickAlotLoginMember resItem = ClickMember.LoginMember(4, txtUser.Text, txtPwd.Text);

        //if (resItem.ClickAlotMemberDataListResult != null)
        //{
        //    ds = resItem.ClickAlotMemberDataListResult;
        //    this.KeepSession(ds);
        //    Response.Redirect("getcode.aspx");
        //}

        //switch (res)
        //{
        //    case "0": responesStat = "OK";
        //        Response.Write("{ \"responseStat\":\"" + responesStat + "\" }");
        //        break;
        //    case "2": responesStat = "NO_USER";
        //        Response.Write("{ \"responseStat\":\"" + responesStat + "\" }");
        //        break;
        //    case "3": responesStat = "MANY_ROWS";
        //        Response.Write("{ \"responseStat\":\"" + responesStat + "\" }");
        //        break;
        //    default: responesStat = "ERROR";
        //        Response.Write("{ \"responseStat\":\"" + responesStat + "\" }");
        //        break;
        //}
    }
}