using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class searchprocess : System.Web.UI.Page
{
    ClickMemberToolsService.ClickMemberToolsServiceSoapClient Clicktoolservice = new ClickMemberToolsService.ClickMemberToolsServiceSoapClient();

    protected void Page_Load(object sender, EventArgs e)
    {
        string username = Request.Params["searchUsername"];

        string responesStat = "";


        ClickMemberToolsService.ClickMemberProfileDataList resMemberProf = Clicktoolservice.GetMemberProfile(username);
        if (resMemberProf.ClickMemberProfileListResult.Length == 1)
        {
            responesStat = "OK";
            Response.Write("{ \"responseStat\":\"" + responesStat + "\", \"UserName\":\"" + resMemberProf.ClickMemberProfileListResult[0].UserName + "\", ");
            Response.Write("\"Firstname\":\"" + resMemberProf.ClickMemberProfileListResult[0].Firstname + "\", ");
            Response.Write("\"Lastname\":\"" + resMemberProf.ClickMemberProfileListResult[0].Lastname + "\", ");
            Response.Write("\"Email\":\"" + resMemberProf.ClickMemberProfileListResult[0].Email + "\", ");
            Response.Write("\"CreateOn\":\"" + resMemberProf.ClickMemberProfileListResult[0].CrearteOn + "\", ");
            Response.Write("\"LastLogin\":\"" + resMemberProf.ClickMemberProfileListResult[0].LastLogin + "\", ");
            Response.Write("\"mobile\":\"" + resMemberProf.ClickMemberProfileListResult[0].mobile + "\", ");
            Response.Write("\"id_number\":\"" + resMemberProf.ClickMemberProfileListResult[0].id_number + "\"");
            Response.Write("}");
        }
        else
        {
            responesStat = "CLICK MEMBER WRONG";
            Response.Write("{ \"responseStat\":\"" + responesStat + "\" }");
        }
    }
}