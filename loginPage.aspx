<%@ Page Language="C#" AutoEventWireup="true" CodeFile="loginPage.aspx.cs" Inherits="loginPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
	<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1"> 
	<meta name="viewport" content="width=device-width, initial-scale=1.0"> 
    <title>Clickalot Member Tools</title>
    <link type="text/css" rel="stylesheet" href="css/reset.css" />
    <link type="text/css" rel="stylesheet" href="css/style.css" />
    <link rel="import" href="http://www.polymer-project.org/components/font-roboto/roboto.html">
</head>
<body>
<div class="headerlogo"></div>

<p class="accent">

</p>

    <div class="formcontainer">
  
      <h2>Log in<small></small></h2>
  
      <form>
    
        <div class="group">      
          <input id="crmUsername" type="text" onkeypress="return isSingleQuoteKey(event)" <%--onkeydown="return noCopyKey(event);" onmousedown="return noCopyMouse(event);" onpaste="return false"--%> required>
          <span class="highlight"></span>
          <span class="bar"></span>
          <label>UserName</label>
        </div>
      
        <div class="group">      
          <input id="crmPassword" type="password" required>
          <span class="highlight"></span>
          <span class="bar"></span>
          <label>Password</label>
        </div>
     </form>   
      <p class="footer">
        <div class="action_btns">
            <button class="ripple" onclick="login()">LOGIN</button>
	    </div>
      </p>

    </div>

    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script language="JavaScript" type="text/javascript" charset="utf-8">

        var renewParams = {};

        function login() {

            var crmUsername = document.getElementById('crmUsername');
            var crmPassword = document.getElementById('crmPassword');

            renewParams['crmUsername'] = crmUsername.value;
            renewParams['crmPassword'] = crmPassword.value;

            $.post("loginprocess.aspx", renewParams,
                function (data, status) {
                    //console.log("click update=------->");
                    //console.log(data);
                    if (data.responseStat == "OK") {

                        //alert('renew password complete');
                        window.location.href = "default.aspx";

                    } else if (data.responseStat == "NotFound") {

                        alert('ไม่พบข้อมูลผู้ใช้งานในระบบ');
                        //window.location.href = "";

                    } else if (data.responseStat == "PasswordExpired") {

                        alert('รหัสผ่านของท่านหมดอายุการใช้งานแล้ว');
                        //window.location.href = "";
                    }
                    else if (data.responseStat == "UsedByOthers") {
                        alert('ผู้ใช้งานนี้ถูกใช้งานโดยผู้อื่นอยู่');
                        //window.location.href = "";
                    }
                    else {
                        alert('ขออภัยเกิดข้อผิดพลาด');
                    }

                }, "json");
            }
             
    </script>

</body>
</html>
