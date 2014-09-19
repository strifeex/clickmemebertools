<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

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

    <%--Google Nexus Website Menu--%>
    <link rel="stylesheet" type="text/css" href="css/normalize.css" />
	<link rel="stylesheet" type="text/css" href="css/demo.css" />
	<link rel="stylesheet" type="text/css" href="css/component.css" />
	<script src="js/modernizr.custom.js"></script>
</head>
<body>

    <div class="formcontainer searchform">
        <h2><small></small></h2>
      <form>
    
        <div class="group">      
          <input id="searchUsername" type="text" onkeypress="return isSingleQuoteKey(event)" <%--onkeydown="return noCopyKey(event);" onmousedown="return noCopyMouse(event);" onpaste="return false"--%> required>
          <span class="highlight"></span>
          <span class="bar"></span>
          <label>Username Or Email</label>
        </div>

          
      </form>
      <p class="footer">
        <div class="action_btns">
            <button class="ripple" onclick="UsernameSearch()">Search</button>
	    </div>
      </p>

    </div>

     <div class="formcontainer userinfoform">
        <h2>Infomation<small></small></h2>

     <form id="infoform">  
            <ul class="tabletitle">
                   <li>USERNAME</li>
                   <li>EMAIL</li>
                   <li>FIRSTNAME</li>
                   <li>LASTNAME</li>
                   <li>DATECREATE</li>
                   <li>MOBILE</li>
                   <li>ID NUMBER</li>
                   <li>LAST LOGIN</li>
            </ul>
            <ul class="tablevalues" id="infoval">
                   <li>USERNAME</li>
                   <li>EMAIL</li>
                   <li>FIRSTNAME</li>
                   <li>LASTNAME</li>
                   <li>DATECREATE</li>
                   <li>MOBILE</li>
                   <li>ID NUMBER</li>
                   <li>LAST LOGIN</li>
            </ul>
      </form>
       <p class="footer">
        <div class="action_btns">
            &nbsp;
	    </div>
      </p>
    </div>


    <div class="formcontainer renewform">
  
      <h2>Renew Password<small></small></h2>
  
      <form>
    
        <div class="group">      
          <input id="re_clickId" type="text" onkeypress="return isSingleQuoteKey(event)" <%--onkeydown="return noCopyKey(event);" onmousedown="return noCopyMouse(event);" onpaste="return false"--%> required>
          <span class="highlight"></span>
          <span class="bar"></span>
          <label>UserName</label>
        </div>
      
        <div class="group">      
          <input id="re_clickPw" type="text" required>
          <span class="highlight"></span>
          <span class="bar"></span>
          <label>NewPassword</label>
        </div>

      </form>

      <p class="footer">
        <div class="action_btns">
            <button class="ripple" onclick="RenewPassword()">RENEW</button>
	    </div>
      </p>

    </div>


    <div class="formcontainer rollbackform">
  
      <h2>Rollback Password<small></small></h2>
  
      <form>
    
        <div class="group">      
          <input id="roll_clickId" type="text" onkeypress="return isSingleQuoteKey(event)" <%--onkeydown="return noCopyKey(event);" onmousedown="return noCopyMouse(event);" onpaste="return false"--%> required>
          <span class="highlight"></span>
          <span class="bar"></span>
          <label>UserName</label>
        </div>

      </form>
      <p class="footer">
        <div class="action_btns">
		    <button class="ripple" onclick="RollBackPassword()">ROLLBACK</button>
	    </div>
      </p>


    </div>

    <div class="formcontainer Userlist">
  
      <h2>User List<small></small></h2>
  
      <form>
        <div class="usertable" id="UserList">
        </div>
      </form>

      <p class="footer">
        <div class="action_btns">
             &nbsp;
	    </div>
      </p>

    </div>


    <div class="formcontainer Privmanage">
  
      <h2 id="PrivmanageHead">header<small></small></h2>
  
      <form>
         <ul>
            <li><input type="checkbox" id="RenewCheck"></li><li>Renew Password</li>
        </ul>
        <ul>
            <li><input type="checkbox" id="RollbackCheck"></li><li>Rollback Password</li>
        </ul>

        <input type="hidden" id="tmpCMSId" value="0">
      </form>


      <p class="footer">
        <div class="action_btns">
            <button class="ripple" onclick="MemberToolsPrivilege()">ACCEPT</button>
	    </div>
      </p>

    </div>

    	<div class="container">
			<ul id="gn-menu" class="gn-menu-main">
				<li class="gn-trigger">
					<a class="gn-icon gn-icon-menu"><span>Menu</span></a>
					<nav class="gn-menu-wrapper">
						<div class="gn-scroller">
							<ul class="gn-menu" id="sidemenu" runat="server">
<%--                            <li><a class="gn-icon gn-icon-search" onclick="SearchMenu()">Search</a></li>
								<li><a class="gn-icon gn-icon-cog" onclick="RenewMenu()">ReNew Password</a></li>
								<li><a class="gn-icon gn-icon-help" onclick="RollbackMenu()">RollBack Password</a></li>--%>
							</ul>
						</div><!-- /gn-scroller -->
					</nav>
				</li>
                <li>ClickAlotMember Tools</li>
				<li><a href="loginPage.aspx">Logout</a></li>
			</ul>
		</div><!-- /container -->
		<script src="js/classie.js"></script>
		<script src="js/gnmenu.js"></script>
		<script>
		    new gnMenu(document.getElementById('gn-menu'));
		</script>

    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script language="JavaScript" type="text/javascript" charset="utf-8">

        $('.rollbackform').hide();
        $('.renewform').hide();
        $('.userinfoform').hide();
        $('.Userlist').hide();
        $('.Privmanage').hide();

        var renewParams = {};
        var rollbackParams = {};
        var searchParams = {};
        var PrivilegeParams = {};

        function RenewPassword() {

            var iclickId = document.getElementById('re_clickId');
            var irenewpw = document.getElementById('re_clickPw');

            renewParams['clickId'] = iclickId.value;
            renewParams['renewpw'] = irenewpw.value;

            $.post("resetpass.aspx", renewParams,
                function (data, status) {
                    //console.log("click update=------->");
                    //console.log(data);
                    alert(data.responseStat);

                    //                    if (data.responseStat == "OK") {

                    //                        alert('renew password complete');
                    //                        //window.location.href = "thankpage.aspx";

                    //                    } else if (data.responseStat == "NO_USER") {

                    //                        alert('NOT FOUND USER');
                    //                        //window.location.href = "";

                    //                    } else if (data.responseStat == "MANY_ROWS") {

                    //                        alert('USER NOT UNIQUE');
                    //                        //window.location.href = "";
                    //                    }
                    //                    else {
                    //                        alert('ERROR');
                    //                        //window.location.href = "";
                    //                    }

                }, "json");
            }

            function RollBackPassword() {

                var iclickId = document.getElementById('roll_clickId');

                rollbackParams['clickId'] = iclickId.value;

                $.post("rollbackpass.aspx", rollbackParams,
                function (data, status) {
                    //console.log("click update=------->");
                    //console.log(data);
                    alert(data.responseStat);
                    //                    if (data.responseStat == "OK") {

                    //                        alert('renew password complete');
                    //                        //window.location.href = "thankpage.aspx";

                    //                    } else if (data.responseStat == "NO_USER") {

                    //                        alert('NOT FOUND USER');
                    //                        //window.location.href = "";

                    //                    } else if (data.responseStat == "MANY_ROWS") {

                    //                        alert('USER NOT UNIQUE');
                    //                        //window.location.href = "";
                    //                    }
                    //                    else {
                    //                        alert('ERROR');
                    //                        //window.location.href = "";
                    //                    }

                }, "json");
            }


            function UsernameSearch() {
                var searchUsername = document.getElementById('searchUsername');

                searchParams['searchUsername'] = searchUsername.value;

                $.post("searchprocess.aspx", searchParams,
                function (data, status) {

                    if (data.responseStat == "OK") {

                        $('.userinfoform').show();

                        var infoform = document.getElementById('infoval');
                        infoform.innerHTML = "<li>" + data.UserName + "&nbsp</li>";
                        infoform.innerHTML += "<li>" + data.Email + "&nbsp</li>";
                        infoform.innerHTML += "<li>" + data.Firstname + "&nbsp</li>";
                        infoform.innerHTML += "<li>" + data.Lastname + "&nbsp</li>";
                        infoform.innerHTML += "<li>" + data.CreateOn + "&nbsp</li>";
                        infoform.innerHTML += "<li>" + data.mobile + "&nbsp</li>";
                        infoform.innerHTML += "<li>" + data.id_number + "&nbsp</li>";
                        infoform.innerHTML += "<li>" + data.LastLogin + "&nbsp</li>";

                    }
                    else {
                        $('.userinfoform').hide();
                        alert("username not found");
                     }

                }, "json");
            }


            function UserCMSList() {

                var ListParams = {};

                ListParams['ListParams'] = "";

                $.post("userlistprocess.aspx", ListParams,
                function (data, status) {

                    var dataLen = data.length;

                    if (dataLen > 0) {

                        var UserList = document.getElementById('UserList');

                            UserList.innerHTML = "<ul>";
                            UserList.innerHTML += "<li class='NoData'>No</li>";
                            UserList.innerHTML += "<li class='usernameData'>Username</li>";
                            UserList.innerHTML += "<li class='FnameData'>Fistname</li>";
                            UserList.innerHTML += "<li class='LnameData'>Latsname</li>";
                            UserList.innerHTML += "</ul>";

                        while (dataLen > 0) {

                            dataLen -= 1;
                            UserList.innerHTML += "<ul>";
                            UserList.innerHTML += "<li class='NoData'>" + data[dataLen].No + "&nbsp</li>";
                            UserList.innerHTML += "<li class='usernameData'>" + data[dataLen].userName + "&nbsp</li>";
                            UserList.innerHTML += "<li class='FnameData'>" + data[dataLen].firstName + "&nbsp</li>";
                            UserList.innerHTML += "<li class='LnameData'>" + data[dataLen].lastName + "&nbsp</li>";
                            UserList.innerHTML += "<li class='clickPriv'><a class='gn-icon gn-icon-article' onclick='EditPrivilege(" + data[dataLen].userId + ", \"" + data[dataLen].userName + "\")'></a></li>";
                            UserList.innerHTML += "</ul>";
                        }

                    }
                    else {
                        //alert("username not found");
                    }

                }, "json");
            }

            function EditPrivilege(paramId, paramName) {

                document.getElementById("RenewCheck").checked = false;
                document.getElementById("RollbackCheck").checked = false;

                PrivilegeParams['cmsId'] = paramId;

                $.post("getprivilegeprocess.aspx", PrivilegeParams,
                    function (data, status) {

                        if (data.resRenewMenu == "1") {

                            document.getElementById("RenewCheck").checked = true;

                        }

                        if (data.resRollbackMenu == "1") {

                            document.getElementById("RollbackCheck").checked = true;

                        }

                    }, "json");
                

                document.getElementById("PrivmanageHead").innerHTML = paramName;
                document.getElementById("tmpCMSId").value = paramId;

                $('.Userlist').hide();
                $('.Privmanage').show();
            }

            function MemberToolsPrivilege() {

                var cmsIdtmp = document.getElementById('tmpCMSId');
                PrivilegeParams['cmsId'] = cmsIdtmp.value;
                PrivilegeParams['renewCheck'] = "0";
                PrivilegeParams['rollbackCheck'] = "0";

                if(document.getElementById("RenewCheck").checked == true){
                    PrivilegeParams['renewCheck'] = "1";
                }

                if (document.getElementById("RollbackCheck").checked == true) {

                    PrivilegeParams['rollbackCheck'] = "1";
                }

                $.post("editPrivilegeprocess.aspx", PrivilegeParams,
                    function (data, status) {

                        //                    if (data.responseStat == "OK") {

                        //                        alert('renew password complete');
                        //                        //window.location.href = "thankpage.aspx";

                        //                    } else if (data.responseStat == "NO_USER") {

                        //                        alert('NOT FOUND USER');
                        //                        //window.location.href = "";

                        //                    } else if (data.responseStat == "MANY_ROWS") {

                        //                        alert('USER NOT UNIQUE');
                        //                        //window.location.href = "";
                        //                    }
                        //                    else {
                        //                        alert('ERROR');
                        //                        //window.location.href = "";
                        //                    }

                    }, "json");


                document.getElementById("RenewCheck").checked = false;
                document.getElementById("RollbackCheck").checked = false;

                $('.Privmanage').hide();
                $('.Userlist').show();
            }

            function RenewMenu() {
                $('.searchform').hide();
                $('.rollbackform').hide();
                $('.userinfoform').hide();
                $('.Userlist').hide();
                $('.Privmanage').hide();
                $('.renewform').show();
                
            }


            function RollbackMenu() {
                $('.searchform').hide();
                $('.renewform').hide();
                $('.userinfoform').hide();
                $('.Userlist').hide();
                $('.Privmanage').hide();
                $('.rollbackform').show();
            }

            function SearchMenu() {
                $('.renewform').hide();
                $('.rollbackform').hide();
                $('.userinfoform').hide();
                $('.Userlist').hide();
                $('.Privmanage').hide();
                $('.searchform').show();
            }

            function PrivilegeMenu() {
                $('.renewform').hide();
                $('.rollbackform').hide();
                $('.userinfoform').hide();
                $('.searchform').hide();
                $('.Privmanage').hide();

                UserCMSList();

                $('.Userlist').show();
            }




    </script>
</body>
</html>
