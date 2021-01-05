<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="new_student_profile.aspx.cs" Inherits="admin1.new_student_profile" %>
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
@media (max-width: 767px)
{
   .navbar-collapse
   {
       border-color:black;
       background-color:#616161;
   }
   #dropbut
   {
       width:100vh;
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
    <div class="navbar-collapse collapse" >
      <ul class="nav navbar-nav navbar-right"  >
        <li class="dropdown" >
        <a href="#" id="dropd" class="dropdown-toggle" data-toggle="dropdown"> <span  class="glyphicon glyphicon-user icon-size"></span> <asp:Literal ID="Literal7" runat="server"></asp:Literal> <span class="caret"></span></a>

                  <ul class="dropdown-menu pull-left" style="background-color:#7a8c74; border-color:#7a8c74; padding:0px; margin:0px;" role="menu">
                    <li class="hidden-sm hidden-xs" id="profpic"><a href="#" id="profpica" ><img src="img/pic.png" style="width:75px;height:75px; padding:10px;" /><br /><asp:Literal ID="Literal1" runat="server"></asp:Literal> <br /><span style="word-break:break-all;">01-134132-<br />079@student.bahria.edu.pk</span></a></li>
                      <li><a href="#" id="dropbut">Profile</a></li>
                      <li><a href="logout.aspx" id="dropbut">Sign Out</a></li>
                      

                    </ul>
      </li>
        
      </ul>
        
    </div>
</div>

<nav id="mySidenav" class="navbar navbar-inverse sidebar"  >
    <div class="container-fluid" >
		<!-- Brand and toggle get grouped for better mobile display 
		<div class="navbar-header">
			<button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-sidebar-navbar-collapse-1">
				<span class="sr-only">Toggle navigation</span>
				<span class="icon-bar"></span>
				<span class="icon-bar"></span>
				<span class="icon-bar"></span>
			</button>
			<a class="navbar-brand" href="#">Brand</a>
		</div>
		<!-- Collect the nav links, forms, and other content for toggling 
		<div class="collapse navbar-collapse" id="bs-sidebar-navbar-collapse-1">-->
        <div>
			<ul class="nav navbar-nav" >
				<!--<li class="active"><a href="#">Home<span style="font-size:16px;" class="pull-right hidden-xs showopacity glyphicon glyphicon-home"></span></a></li>-->
				
                <li class="lii" style="border-top-color:#616161; border-bottom-color:#7a8c74;"><a href="new_student_profile.aspx" style="color:#fff;  width:inherit; height:inherit;"><span >Profile</span><span style="font-size:16px;" class="pull-right hidden-xs showopacity glyphicon glyphicon-user"></span></a></li>
                <li class="lii" style="border-top-color:#7a8c74;border-bottom-color:#7a8c74;"><a href="new_student_submit_proposal.aspx" style="color:#fff; height:inherit;"><span>Thesis</span><span style="font-size:16px;" class="pull-right hidden-xs showopacity glyphicon glyphicon-book"></span></a></li>
				<li class="lii" style="border-top-color:#7a8c74;border-bottom-color:#7a8c74;"><a href="new_student_submit_proposal.aspx" style="color:#fff; height:inherit;"><span>Change Password</span></a></li>
				
			</ul>
		</div>
        
	</div>
    
</nav>
<div class="container-fluid" style="padding-top:30px; height:100%; overflow:auto;">
 
<h1 class="page-header"><span class="glyphicon glyphicon-user"></span> Profile Information</h1><br />
 
    <table class="table table-bordered" >
            <tbody >
    <tr>
      <th>Enrollment</th>
      <td><asp:Literal ID="enrollment" runat="server" ></asp:Literal></td>
      <th>Registration</th>
      <td><asp:Literal ID="registration" runat="server" ></asp:Literal></td>
      <th>Intake Semester</th>
      <td><asp:Literal ID="intake" runat="server" ></asp:Literal></td>
      <td rowspan="7"></td>
        
    </tr>
    <tr>
      <th>Name</th>
      <td><asp:Literal ID="name" runat="server" ></asp:Literal></td>
      <th>Father Name</th>
      <td colspan="3"><asp:Literal ID="fathername" runat="server" ></asp:Literal></td>
    </tr>
    <tr>
      <th>Class</th>
      <td><asp:Literal ID="class_name" runat="server" ></asp:Literal></td>
      <th>Degree Duration</th>
      <td colspan="3"><asp:Literal ID="degreeduration" runat="server" ></asp:Literal></td>
    </tr>
    <tr>
      <th>Mobile</th>
      <td><asp:Literal ID="phone" runat="server" ></asp:Literal></td>
      <th>Phone No.</th>
      <td><asp:Literal ID="phone2" runat="server" ></asp:Literal></td>
      <th>Email</th>
      <td><asp:Literal ID="pemail" runat="server" ></asp:Literal></td>
    </tr>
    <tr>
    <th>Current Address</th>
      <td colspan="5"><asp:Literal ID="address" runat="server" ></asp:Literal></td>
    </tr>
    <tr>
    <th>University Email</th>
      <td colspan="5"><asp:Literal ID="uemail" runat="server" ></asp:Literal></td>
    </tr>
    <tr>
    <th>Community Support Work:</th>
      <td colspan="5"><asp:Literal ID="community" runat="server" ></asp:Literal></td>
    </tr>
    
  </tbody>
</table>
    
</div>
    </div>
</body>
</html>

