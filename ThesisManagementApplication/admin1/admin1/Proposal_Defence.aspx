﻿<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Proposal_Defence.aspx.cs" Inherits="admin1.Proposal_Defence" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

   <!-- Latest compiled and minified CSS -->
  <meta charset="utf-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link href="css/bootstrap.min.css" rel="stylesheet"/>
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="Styles/jquery.datetimepicker.css" rel="stylesheet" />

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script>
        var flag = true;
    </script>
    </head>
<style>
body {
    font-family: "Lato", sans-serif;
}
.sidenav {
    height: 100%;
    width: 0;
    position: fixed;
    z-index: 1;
    top: 0;
    left: 0;
    background-color: #111;
    overflow-x: hidden;
    transition: 0.5s;
    padding-top: 60px;
}

.sidenav a {
    padding: 8px 8px 8px 32px;
    text-decoration: none;
    font-size: 15px;
    color: #818181;
    display: block;
    transition: 0.3s
}

.sidenav a:hover, .offcanvas a:focus{
    color: #f1f1f1;
}

.sidenav .closebtn {
    position: relative;
    top: 0;
    right: 25px;
    font-size: 36px;
    margin-left: 175px;
}

#main {
    transition: margin-left .5s;
    padding: 16px;
}

@media screen and (max-height: 200px) {
  .sidenav {padding-top: 10px;}
  .sidenav a {font-size: 10px;}
}
ul {
    list-style-type: none;
    margin: 0;
    padding: 0;
    overflow: hidden;
    background-color: #333;
}

li {
    float: left;
}

li a, .dropbtn {
    display: inline-block;
    color: white;
    text-align: center;
    padding: 14px 16px;
    text-decoration: none;
}

li a:hover, .dropdown:hover .dropbtn {
    background-color: black;
}

li.dropdown {
    display: inline-block;

}

.dropdown-content {
    display: none;
    position: absolute;
    background-color: #f9f9f9;
    min-width: 160px;
    box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
    z-index: 1;
}

.dropdown-content a {
    color: black;
    padding: 12px 16px;
    text-decoration: none;
    display: block;
    text-align: left;
}

.dropdown-content a:hover {background-color: #f1f1f1}

.dropdown:hover .dropdown-content {
    display: block;
}


</style>
<body onload="openNav()">
<nav class="navbar navbar-inverse navbar-fixed-top">
  <ul class="nav navbar-nav">
    <a class="navbar-brand" href="#">Bahria university Islamabad </a>
 </ul>
 <ul class="nav navbar-nav navbar-right">
  <li><a href="#"><span class="glyphicon glyphicon-log-out"></span> Logout</a></li>
  </ul>
</nav>
<br />

<div id="mySidenav" class="sidenav">
  <a href="javascript:void(0)" class="closebtn" onclick="closeNav()">&times;</a>
  <a href="http://localhost:21315/Default.aspx">Home</a>
  <a href="http://localhost:21315/Proposal_Defence.aspx">Setup Proposal Defence</a>
</div>


<script>
    function openNav() {

        if (flag == true) {
            document.getElementById("mySidenav").style.width = "250px";
            document.getElementById("main").style.marginLeft = "250px";
            flag = false;
        }
        else if (flag == false) {
            flag = true;
            document.getElementById("mySidenav").style.width = "0";
            document.getElementById("main").style.marginLeft = "0";
        }
    }

    function closeNav() {
        document.getElementById("mySidenav").style.width = "0";
        document.getElementById("main").style.marginLeft = "0";
    }
</script>
<nav class="navbar navbar-inverse navbar-fixed-top">
  <ul class="nav navbar-nav">
    <a class="navbar-brand" href="#">Bahria university Islamabad </a>
 </ul>
 <ul class="nav navbar-nav navbar-right">
  <li><a href="logout.aspx"><span class="glyphicon glyphicon-log-out"></span> Logout</a></li>
  </ul>
</nav>
<br />

<form class="form-horizontal" runat="server">
   
     <div id="main">
         <h1 class="page-header"><span class="glyphicon glyphicon-user"></span> Admin Panel - Setup Proposal Defense</h1>
  <span style="font-size:30px;cursor:pointer" onclick="openNav()">&#9776; </span>
<asp:Panel ID="Panel1" runat="server">
  <table class="table table-bordered" style="text-align:center;" >
            <tbody >
    <tr>
      <th>Enrollment</th>   
        <td><asp:Literal ID="enrollment" runat="server" ></asp:Literal></td> 
      <th>Student Name</th>
        <td><asp:Literal ID="name" runat="server" ></asp:Literal></td>
        <td><asp:Literal ID="program" runat="server" ></asp:Literal></td>

    </tr>
                <tr>
      <th>Project Title</th>   
        <td><asp:Literal ID="research_area" runat="server" ></asp:Literal></td> 
        <td><asp:LinkButton runat="server"  Text="Download"/></td>  
      <th>Status</th>
        <td><asp:Literal ID="approval_status" runat="server" ></asp:Literal></td>

      

      
        
    </tr>
    <tr>
        <th>Supervisor</th>
        <td colspan="2"><asp:Literal ID="suggested_supervisor" runat="server" ></asp:Literal></td>
        <th>Status</th>
        <td><asp:Literal ID="supervisor_status" runat="server" ></asp:Literal></td>
    </tr>
    <tr>
      <th>Submission Date</th>
      <td><asp:Literal ID="submisssion_date" runat="server" ></asp:Literal></td>
      <th>Defense Date</th>
      <td colspan="2"><asp:Literal ID="proposal_defense_date" runat="server" ></asp:Literal></td>
    </tr>
   
    
  </tbody>
</table>
        </asp:Panel>


<h3 class="page-header"><div style="text-align:center;">Setup </div> </h3> 
<div class="form-group">
<label class="col-md-4 control-label" for="fn">Select Date/Time</label>
<div class="col-md-4"> 
<input id="datetimepicker" name="fn" placeholder="Select Date Time" style="background:url('../img/calendar.png') no-repeat Right; cursor:pointer;" class="form-control input-md"  />
</div>
</div>
 <div class="form-group">
  <label class="col-md-4 control-label" for="selectroom">Select Class Room</label>
  <div class="col-md-4">
    <select id="selectbasic" name="selectroomc" class="form-control input-md">
      <option>---SELECT---</option>
      <option>XC-01</option>
      <option>XC-02</option>
    </select>

  </div>
</div>
 <div class="form-group">
  <label class="col-md-4 control-label" for="selectbasic">Internal Examiner</label>
  <div class="col-md-4">
    <select id="select1" name="selectbasic" class="form-control input-md">
      <option>---SELECT---</option>
      <option>XC-01</option>
      <option>XC-02</option>
    </select>

  </div>
</div>
 <div class="form-group">
  <label class="col-md-4 control-label" for="selectbasic">External Examiner</label>
  <div class="col-md-4">
    <select id="select2" name="selectbasic" class="form-control input-md">
      <option>---SELECT---</option>
      <option>XC-01</option>
      <option>XC-02</option>
    </select>

  </div>
</div>



<div class="form-group">
  <label class="col-md-4 control-label" for="submit"></label>
  <div class="col-md-4">
    <button id="submit" name="submit" class="btn btn-primary">Submit</button>
  </div>
</div>
        </div>
</form>
<!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="js/bootstrap.min.js"></script>
    <script src="Scripts/jquery.datetimepicker.full.js" type="text/javascript"></script>
      <script>
          $("#datetimepicker").datetimepicker();
            </script>
</body>
</html>