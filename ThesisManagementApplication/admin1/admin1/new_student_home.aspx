<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="new_student_home.aspx.cs" Inherits="admin1.new_student_home" %>

<!DOCTYPE html>

<html lang="en" class="no-js">
<head>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">

	<link href='https://fonts.googleapis.com/css?family=Open+Sans:300,400,700' rel='stylesheet' type='text/css'>

	<link rel="stylesheet" href="css/reset.css"> <!-- CSS reset -->
	<link rel="stylesheet" href="css/style.css"> <!-- Resource style -->
    <meta charset="utf-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link href="css/bootstrap.min.css" rel="stylesheet"/>
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="Styles/jquery.datetimepicker.css" rel="stylesheet" />

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

	<script src="js/modernizr.js"></script> <!-- Modernizr -->
  	
	<div id="main">

<h1 class="page-header"><span class="glyphicon glyphicon-user"></span> Student Panel</h1>
  <span style="font-size:30px;cursor:pointer" onclick="openNav()">&#9776; </span>
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
</head>
<body>
	<header class="cd-main-header" style="background:#7a8c74; height:38px;">
		<a href="#0" class="cd-logo" style=" margin:6px; font-size:28px; color:white;">Bahria University</a>
		<!--
		<div class="cd-search is-hidden">
			<form action="#0">
				<input type="search" placeholder="Search...">
			</form>
		</div> <!-- cd-search -->


		<a href="#0" class="cd-nav-trigger">Menu<span></span></a>

		<nav class="cd-nav">
			<ul class="cd-top-nav">
				<li class="has-children account">
					<a href="#0">
						<img src="img/cd-avatar.png" alt="avatar">
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
	</header> <!-- .cd-main-header -->

	<main class="cd-main-content" style="margin:0px; padding:0;">
		<nav class="cd-side-nav" style="margin:0px; padding:0;">
			<ul>
				
				<li class="has-children overview">
					<a href="#0">Personal Information</a>
					
					<ul>
						<li><a href="#0">All Data</a></li>
						<li><a href="#0">Category 1</a></li>
						<li><a href="#0">Category 2</a></li>
					</ul>
				</li>
				<li class="has-children notifications active">
					<a href="#0">Proposal</a>
					
				</li>

				<li class="has-children comments">
					<a href="#0">Thesis</a>
					
				</li>
			</ul>

			
		</nav>

		<div class="content-wrapper">
			<h1>Responsive Sidebar Navigation</h1>
		</div> <!-- .content-wrapper -->
	</main> <!-- .cd-main-content -->
<script src="js/jquery-2.1.4.js"></script>
<script src="js/jquery.menu-aim.js"></script>
<script src="js/main.js"></script> <!-- Resource jQuery -->
</body>
</html>
