using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    ClickMemberToolsService.ClickMemberToolsServiceSoapClient Clicktoolservice = new ClickMemberToolsService.ClickMemberToolsServiceSoapClient();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserLoginSys"] == null)
        {
            Response.Redirect("~/loginPage.aspx");
        }

        string result = String.Empty;
        result = "<li><a class='" + "gn-icon gn-icon-search" + "' onclick='" + "SearchMenu()" + "'>Search</a></li>";

        int cmsId = Convert.ToInt32(MISCoreLibrary.ClsDecrypt.DecryptSTD(((Authensession)(Session["UserLoginSys"])).userAccId, "GjrAIdzK97quE67Pho3pBhpV6VPP72hB", "OI1miOctWpPCvOu9"));

        int privilegeMenu = 1;
        int renewMenu = 2;
        int rollbackmenu = 3;

        if (Clicktoolservice.CheckPrivilege(cmsId, renewMenu) == "0")
        {
            result += "<li><a class='" + "gn-icon gn-icon-cog" + "' onclick='" + "RenewMenu()" + "'>ReNew Password</a></li>";
        }

        if (Clicktoolservice.CheckPrivilege(cmsId, rollbackmenu) == "0")
        {
            result += "<li><a class='" + "gn-icon gn-icon-help" + "' onclick='" + "RollbackMenu()" + "'>RollBack Password</a></li>";
        }

        if (Clicktoolservice.CheckPrivilege(cmsId, privilegeMenu) == "0")
        {
            result += "<li><a class='" + "gn-icon gn-icon-article" + "' onclick='" + "PrivilegeMenu()" + "'>User Privileges</a></li>";
        }

        //if ((cmsId != 11) && (cmsId != 13))
        //{
        //    result += "<li><a class='" + "gn-icon gn-icon-cog" + "' onclick='" + "RenewMenu()" + "'>ReNew Password</a></li>" +
        //             "<li><a class='" + "gn-icon gn-icon-help" + "' onclick='" + "RollbackMenu()" + "'>RollBack Password</a></li>";
            
        //}
        sidemenu.InnerHtml = result;
    }
}