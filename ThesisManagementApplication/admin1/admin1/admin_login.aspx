<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_login.aspx.cs" Inherits="admin1.admin_login" %>
<!DOCTYPE html>
<html lang="en">
<head>
  <title>Bootstrap Case</title>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <style>
        /* CSS used here will be applied after bootstrap.css */

/* Create a medium height at 40px */
.navbar-md {min-height:38px; background-color:#7a8c74;}
.navbar-md .navbar-brand,
.navbar-md .navbar-nav>li>a {padding-top:9px; padding-bottom:8.5px; color:#fff;}
.navbar-md .navbar-brand {height: 38px}  
.navbar-md .navbar-toggle {margin: 4px 13px 3px 0px; padding: 6px 8px 8px 11px;}
.navbar-md .navbar-toggle .icon-bar {width: 19px;}



.container
{
    padding-top:30px;
    
    margin:0;
}

#open
{
    background-color:#7a8c74;
    font-size:18px;
    font-weight:bold;
    color:#fff;
}
#open:hover
{
    background-color: #555;
    color:#fff;
}
.title
{
    background-color:black;
    color:#fff;
}
#brand
{
    font-size:24px;
    font-family: Cambria;
    padding-left:10px;
}
#brand:hover
{
    color:#dee2dc;
}
.navbar-default .navbar-toggle .icon-bar {
    background-color: #fff;
}
.navbar-default .navbar-toggle .icon-bar:hover
{
    color:white;
}
.navbar-default .navbar-toggle:hover
{
    background-color:transparent;
}
.dropdown-default .dropdown-toggle.dropdown-menu{
    padding:0px;
    margin:0px;
    height:10px;
}
#dropd
{
    color:#fff;
    font-size:12px;
    
}
#dropd:hover
{
    color:#fff;
    background-color:#555;
}
#dropd:focus
{
    color:#fff;
    background-color:#555;
}

#profpic
{
    text-align:center; color:white;
}
#profpica
{
    color:#fff;
}
#profpica:hover
{
    background-color:#7a8c74;
}
.dropbut
{
    color:white;
}
#dropbut
{
    color:white;
    background-color:#616161;
    width:100%;
}
#dropbut:hover
{
    background-color:#555;
}
#footer {
    position: absolute;
    left:0;
    bottom: 0;
    display: block;
    min-height: 25px;
    margin: 0;
    padding: 0 10px;
    border-width: 1px 0 0 0;
    border-style: solid none none none;
    border-color: #eee;
    cursor: default;
    text-align:left;
    width:100%;
}
.noselect {
    -webkit-touch-callout: none;
    -webkit-user-select: none;
    -moz-user-select: none;
    -ms-user-select: none;
    user-select: none;
}
.alert {
    padding: 5px 15px;
    margin-bottom: 5px;
}
.alert-info {
    background-image: -webkit-linear-gradient(top,#d9edf7 0%,#b9def0 100%);
    background-image: -o-linear-gradient(top,#d9edf7 0%,#b9def0 100%);
    background-image: -webkit-gradient(linear,left top,left bottom,from(#d9edf7),to(#b9def0));
    background-image: linear-gradient(to bottom,#d9edf7 0%,#b9def0 100%);
    filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#ffd9edf7',endColorstr='#ffb9def0',GradientType=0);
    background-repeat: repeat-x;
    border-color: #9acfea;
}
.alert {
    text-shadow: 0 1px 0 rgba(255,255,255,.2);
    -webkit-box-shadow: inset 0 1px 0 rgba(255,255,255,.25), 0 1px 2px rgba(0,0,0,.05);
    box-shadow: inset 0 1px 0 rgba(255,255,255,.25), 0 1px 2px rgba(0,0,0,.05);
}
.alert-info {
    color: #31708f;
    background-color: #d9edf7;
    border-color: #bce8f1;
}
.alert-dismissable, .alert-dismissible {
    padding-right: 35px;
}
.alert {
    padding: 15px;
    margin-bottom: 20px;
    border: 1px solid transparent;
    border-radius: 4px;
}
* {
    box-sizing: border-box;
}
* {
    -webkit-box-sizing: border-box;
    -moz-box-sizing: border-box;
    box-sizing: border-box;
}
html,body
{
    margin: 0; padding: 0;
    text-align: center;
}
@media (max-width: 767px)
{
   .navbar-collapse
   {
       border-color:black;
       background-color:#616161;
   }
}

    </style>
    <link href="Styles/new1.css" rel="stylesheet" />
    <script>
        var x = 0;
        function w3_close() {
            if (document.getElementById("mySidenav").style.display == "none")
            {
                if (!$("#hideshow").is(":visible")) {
                    var elements = document.querySelectorAll('.main');
                    for (var i = 0; i < elements.length; i++) {
                        elements[i].style.width = "calc(100% - 225px)";
                        elements[i].style.marginLeft = 225 + "px";
                    }
                    document.getElementById("mySidenav").style.display = "block";
                }
                else
                {
                    document.getElementById("mySidenav").style.display = "block";
                }
            }
            else
            {
                var elements = document.querySelectorAll('.main');
                for (var i = 0; i < elements.length; i++) {
                    elements[i].style.width = "calc(100% - 225px)";
                    elements[i].style.marginLeft = 0 + "px";
                }
                document.getElementById("mySidenav").style.display = "none";
            }
            
        }
        function w3_close1() {
            document.getElementById("mySidenav").style.display = "none";
        }
    </script>
    
</head>
<body>
    <div class="main3">
<div class="navbar navbar-default navbar-fixed-top navbar-md" id="main-navbar">
 <div class="navbar-header" >
     <a class="navbar-brand"  id="open" title="Open/Hide Menu" onclick="w3_close()" href="#">&#9776;</a>
     <a class="navbar-brand" id="brand" href="#">Bahria University</a>
      <a class="navbar-toggle"  id="hideshow" data-toggle="collapse" data-target=".navbar-collapse" onclick="w3_close1()">
        <span class="icon-bar" ></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
      </a>
    </div>
    
</div>


<div class="container-fluid" style="padding-top:30px; height:100%; overflow:auto; text-align:center; ">
 <form runat="server">
<h1 class="page-header"><span class="glyphicon glyphicon-user"></span> Admin Panel - Login</h1>

 <br />

    <div class="row" style="margin:0 auto; text-align:center; max-width:425px;">
        <div >
            <div class="alert alert-info alert-dismissible" role="alert"> 
		<strong>Info!</strong> Use the below Forgot Password link for generating new password incase of forgot password.
	</div>
        </div>
    </div>
    <div class="row" style="margin:0 auto; text-align:left; max-width:425px;">
  <label  for="selectbasic" style="text-align:left;padding-top:5px;">Username</label>
        </div>
    <div class="row" style="margin:0 auto; text-align:center; max-width:425px;">
    <div class="input-group">
					<span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
					<asp:TextBox ID="username" placeholder="USERNAME" type="text" class="form-control input-md" runat="server"></asp:TextBox>
				</div></div><br />
    
    <div class="row" style="margin:0 auto; text-align:left; max-width:425px;">
  <label  for="selectbasic" style="text-align:left;padding-top:5px;">Password</label>
        </div>
    <div class="row" style="margin:0 auto; text-align:center; max-width:425px;">
    <div class="input-group">
					<span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
					<asp:TextBox ID="password" placeholder="PASSWORD" type="password" class="form-control input-md" runat="server"></asp:TextBox>
				</div></div>
    <br />
    <div class="row" style="margin:0 auto; text-align:center; max-width:425px;">
  <asp:Button ID="login" runat="server" Text="Sign In" class="btn btn-primary" style="width:425px;" OnClick="login_Click"  />
        </div><br />
     <div class="row" style="margin:0 auto; text-align:right; max-width:425px;">
  <a href="" >Forgot Password?</a>
        </div>
    <footer id="footer" class="noselect">
			2017 © <a href="http://bahria.edu.pk/" target="_blank">Bahria University</a>
		</footer>
     </form>
    </div>
        
</body>
</html>


