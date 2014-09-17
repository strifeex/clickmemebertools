using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class loginprocess : System.Web.UI.Page
{
    wsClickService.IwsClickAlotCMSClient ClickCRM = new wsClickService.IwsClickAlotCMSClient();
    ClickMemberToolsService.ClickMemberToolsServiceSoapClient Clicktoolservice = new ClickMemberToolsService.ClickMemberToolsServiceSoapClient();

    protected void Page_Load(object sender, EventArgs e)
    {
        string userName = Request.Params["crmUsername"];
        string userpassword = Request.Params["crmPassword"];
        string userPwd = MISCoreLibrary.ClsEncrypt.EncryptSTD(userpassword, "GjrAIdzK97quE67Pho3pBhpV6VPP72hB", "OI1miOctWpPCvOu9");
        string userIP = Request.UserHostAddress;
        string responesStat = "";

        wsClickService.UserDataLogin userData = ClickCRM.UserLogin(userName, userPwd, userIP);

        switch (userData.UserLoginSystemResult)
        {
            case wsClickService.UserDataLoginSystemResult.Success:
                KeepSession(userData.userId, userName, userPwd, userData.firstName, userData.lastName);
                int userId = Convert.ToInt32(MISCoreLibrary.ClsDecrypt.DecryptSTD(((Authensession)(Session["UserLoginSys"])).userAccId, "GjrAIdzK97quE67Pho3pBhpV6VPP72hB", "OI1miOctWpPCvOu9"));
                string logDeatail = ((Authensession)(Session["UserLoginSys"])).userFirstName + " Login to ClickMemberTools with password " + userPwd;
                //Accodeservice.LogAdd(userId, userName, logDeatail, "Login", userIP, "SysLoginpage.aspx");
                Clicktoolservice.LogAdd(userId, userName, "Login", logDeatail, "loginprocess.aspx", userIP);
                responesStat = "OK";
                Response.Write("{ \"responseStat\":\"" + responesStat + "\" }");
                //ScriptManager.RegisterClientScriptBlock(btn_login, typeof(Button), "Onclick", "window.location.href='AcCodeManage.aspx';", true);
                break;
            case wsClickService.UserDataLoginSystemResult.UserOrPasswordIsEmpty:
                responesStat = "IsEmpty";
                Response.Write("{ \"responseStat\":\"" + responesStat + "\" }");
                //ScriptManager.RegisterClientScriptBlock(btn_login, typeof(Button), "Onclick", "alert('ชื่อผู้ใช้หรือรหัสผ่านเป็นค่าว่าง กรุณาตรวจสอบใหม่อีกครั้งค่ะ');", true);
                break;
            case wsClickService.UserDataLoginSystemResult.UserNotFound:
                responesStat = "NotFound";
                Response.Write("{ \"responseStat\":\"" + responesStat + "\" }");
                //ScriptManager.RegisterClientScriptBlock(btn_login, typeof(Button), "Onclick", "alert('ไม่พบข้อมูลผู้ใช้งานในระบบ  กรุณาตรวจสอบใหม่อีกครั้งค่ะ');", true);
                break;
            case wsClickService.UserDataLoginSystemResult.PasswordExpired:
                responesStat = "PasswordExpired";
                Response.Write("{ \"responseStat\":\"" + responesStat + "\" }");
                //ScriptManager.RegisterClientScriptBlock(btn_login, typeof(Button), "Onclick", "alert('รหัสผ่านของท่านหมดอายุการใช้งานแล้ว กรุณาเปลี่ยนรหัสผ่านใหม่ด้วยค่ะ');", true);
                break;
            case wsClickService.UserDataLoginSystemResult.SystemIsUsedByOthers:
                responesStat = "UsedByOthers";
                Response.Write("{ \"responseStat\":\"" + responesStat + "\" }");
                //ScriptManager.RegisterClientScriptBlock(btn_login, typeof(Button), "Onclick", "alert('ขอภัย ผู้ใช้งานนี้ถูกใช้งานโดยผู้อื่นอยู่ค่ะ');", true);
                break;
            case wsClickService.UserDataLoginSystemResult.TransactionError:
                responesStat = "Error";
                Response.Write("{ \"responseStat\":\"" + responesStat + "\" }");
                //ScriptManager.RegisterClientScriptBlock(btn_login, typeof(Button), "Onclick", "alert('เกิดข้อผิดพลาดในการดำเนินการบันทึกข้อมูลของระบบค่ะ');", true);
                break;
            case wsClickService.UserDataLoginSystemResult.Other:
                responesStat = "Other";
                Response.Write("{ \"responseStat\":\"" + responesStat + "\" }");
                //ScriptManager.RegisterClientScriptBlock(btn_login, typeof(Button), "Onclick", "alert('ขออภัยเกิดข้อผิดพลาดจากระบบฐานข้อมูล กรุณาลองใหม่อีกครั้ง');", true);
                break;
            default: 
                responesStat = "NOTCASE";
                Response.Write("{ \"responseStat\":\"" + responesStat + "\" }");
                break;
        }

    }

    protected void KeepSession(int userId, string userName, string userpw, string firstName, string lastName)
    {
        Authensession Authen = new Authensession();
        Authen.userAccId = MISCoreLibrary.ClsEncrypt.EncryptSTD(Convert.ToString(userId), "GjrAIdzK97quE67Pho3pBhpV6VPP72hB", "OI1miOctWpPCvOu9");
        Authen.userAccName = userName;
        Authen.userPassWord = userpw;
        Authen.userFirstName = firstName;
        Authen.userLastName = lastName;
        Session["UserLoginSys"] = Authen;
    }
}