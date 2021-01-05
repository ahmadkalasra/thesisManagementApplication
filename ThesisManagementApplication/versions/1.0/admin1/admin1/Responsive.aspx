<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Responsive.aspx.cs" Inherits="admin1._Default" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

   <!-- Latest compiled and minified CSS -->
  <meta charset="utf-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link href="Styles/jquery.datetimepicker.css" rel="stylesheet" type="text/css" />
    <link href="Styles/reset.css" rel="stylesheet" type="text/css" />
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap.min.css" rel="stylesheet"/>
    <link href="Styles/style.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-2.1.4.js"></script>
    <script src="js/jquery.menu-aim.js"></script>
<script src="js/main.js"></script> <!-- Resource jQuery -->

    </head>
<body>

  	<header class="cd-main-header">
		<a class="navbar-brand" href="#">Bahria university Islamabad </a>
		<a href="#0" class="cd-nav-trigger">Menu<span></span></a>

		<nav class="cd-nav">
			<ul class="cd-top-nav">
				<li class="has-children account">
					<a href="#0">
						Account
					</a>

					<ul>

						<li><a href="#0">My Account</a></li>
						<li><a href="#0">Edit Account</a></li>
						<li><a href="#0">Logout</a></li>
					</ul>
				</li>
			</ul>
		</nav>
	</header><!-- .cd-main-header -->

	<main class="cd-main-content">
		<nav class="cd-side-nav">
			<ul>
				<li class="has-children overview">
					<a href="#">Overview</a>
                    <a href="#">Proposal</a>
                    <a href="#">Proposal</a>
                    <a href="#">Proposal</a>
				</li>
		</nav>
        <br />
         <h1 class="page-header">Proposal</h1>
		<div class="content-wrapper">
       
     <form class="form-horizontal" action=''>
     <div class="form-group">
  <label class="col-md-4 control-label" for="fn">Name</label>  
  <div class="col-md-4">
  <input id="Text1" name="fn" type="text" placeholder="Name..." class="form-control input-md" required="">
    
  </div>
</div>
</form>
        </div>
	</main> <!-- .cd-main-content -->

</body>
</html>