<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="new_responsive.aspx.cs" Inherits="admin1.new_responsive" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Testing</title>
    <script src="http://code.jquery.com/jquery-1.11.0.min.js"></script>
<script src="http://code.jquery.com/jquery-migrate-1.2.1.min.js"></script>
<link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css">
<script src="//maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>
    <link href="Styles/test_resp.css" rel="stylesheet" />
   <script>
       var x = 0;
       function w3_close()
       {
           if (x == 0)
           {
               document.getElementById("mySidenav").style.display = "none";
               var elements = document.querySelectorAll('.main');
               for (var i = 0; i < elements.length; i++)
               {
                   elements[i].style.width = 100 + "%";
                   elements[i].style.marginLeft = 0 + "px";
               }
               ++x;
           }
           else
           {
               var elements = document.querySelectorAll('.main');
               for (var i = 0; i < elements.length; i++) {
                   elements[i].style.width = "calc(100% - 225px)";
                   elements[i].style.marginLeft = 225 + "px";
               }
               document.getElementById("mySidenav").style.display = "block";
               
               --x;
           }
       }
   </script>
</head>
<body>
    <form id="form1" runat="server">
        <nav id="head1" style="background-color:#7a8c74; border:none;" class="navbar navbar-inverse">
  <div class="container-fluid" style="padding:0; margin:0;">
    <div class="navbar-header" >
      <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>                        
      </button>
      <a href="#" class="navbar-brand" id="open1" onclick="w3_close()" style=""><span style="color:white;" >&#9776;</span></a>
        <a class="navbar-brand" href="#"><span style="color:#fff;font-family: Cambria; font-size:24px;">Bahria University</span></a>
        
    </div>
    <div class="collapse navbar-collapse" id="myNavbar">
      <%--<ul class="nav navbar-nav">
        <li class="active" ><a href="#">Home</a></li>
       
        <li class="dropdown">
          <a class="dropdown-toggle" data-toggle="dropdown" href="#">Page 1 <span class="caret"></span></a>
          <ul class="dropdown-menu">
            <li><a href="#">Page 1-1</a></li>
            <li><a href="#">Page 1-2</a></li>
            <li><a href="#">Page 1-3</a></li>
          </ul>
        </li>
        <li><a href="#">Page 2</a></li>
        <li><a href="#">Page 3</a></li>
      </ul>--%>
      <ul class="nav navbar-nav navbar-right">
        <li><a href="#"><span class="glyphicon glyphicon-user"></span> Sign Up</a></li>
        <li><a href="#"><span class="glyphicon glyphicon-log-in"></span> Login</a></li>
      </ul>
    </div>
  </div>
</nav>
    <div>
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
        <div >
			<ul class="nav navbar-nav" >
				<!--<li class="active"><a href="#">Home<span style="font-size:16px;" class="pull-right hidden-xs showopacity glyphicon glyphicon-home"></span></a></li>-->
				
                <li class="lii" style="border-top-color:#616161; border-bottom-color:#7a8c74;"><a href="#"><span style="color:#fff;">Home</span></a></li>
                <li class="lii" style="border-top-color:#7a8c74;border-bottom-color:#7a8c74;"><a href="#" ><span style="color:#fff;">Profile</span><span style="font-size:16px;" class="pull-right hidden-xs showopacity glyphicon glyphicon-user"></span></a></li>
				<li class="lii" style="border-top-color:#7a8c74;border-bottom-color:#7a8c74;"><a href="#"><span style="color:#fff;">Messages</span><span style="font-size:16px;" class="pull-right hidden-xs showopacity glyphicon glyphicon-envelope"></span></a></li>
				<li id="lii" style="border-top-color:#7a8c74;border-bottom-color:#7a8c74;" class="dropdown">
					<a href="#" class="dropdown-toggle" data-toggle="dropdown"><span style="color:#fff;">Settings</span> <span class="caret"></span><span style="font-size:16px;" class="pull-right hidden-xs showopacity glyphicon glyphicon-cog"></span></a>
					<ul class="dropdown-menu forAnimate" role="menu">
						<li><a href="#">Action</a></li>
						<li><a href="#">Another action</a></li>
						<li><a href="#">Something else here</a></li>
						<li class="divider"></li>
						<li><a href="#">Separated link</a></li>
						<li class="divider"></li>
						<li><a href="#">One more separated link</a></li>
					</ul>
				</li>
				<li class="lii" style="border-top-color:#7a8c74;border-bottom-color:#7a8c74;"><a href="#"><span style="color:#fff;">Home</span><span style="font-size:16px;" class="pull-right hidden-xs showopacity glyphicon glyphicon-home"></span></a></li>
				<li class="lii" style="border-top-color:#7a8c74;border-bottom-color:#7a8c74;"><a href="#" ><span style="color:#fff;">Profile</span><span style="font-size:16px;" class="pull-right hidden-xs showopacity glyphicon glyphicon-user"></span></a></li>
				<li class="lii" style="border-top-color:#7a8c74;border-bottom-color:#7a8c74;"><a href="#"><span style="color:#fff;">Messages</span><span style="font-size:16px;" class="pull-right hidden-xs showopacity glyphicon glyphicon-envelope"></span></a></li>
				<li id="lii" style="border-top-color:#7a8c74;border-bottom-color:#7a8c74;" class="dropdown">
					<a href="#" class="dropdown-toggle" data-toggle="dropdown"><span style="color:#fff;">Settings</span> <span class="caret"></span><span style="font-size:16px;" class="pull-right hidden-xs showopacity glyphicon glyphicon-cog"></span></a>
					<ul class="dropdown-menu forAnimate" role="menu">
						<li><a href="#">Action</a></li>
						<li><a href="#">Another action</a></li>
						<li><a href="#">Something else here</a></li>
						<li class="divider"></li>
						<li><a href="#">Separated link</a></li>
						<li class="divider"></li>
						<li><a href="#">One more separated link</a></li>
					</ul>
				</li>
			</ul>
		</div>
	</div>
</nav>
<div class="main">
sdfghrtfgh
</div>

    </div>
    </form>
</body>
</html>
