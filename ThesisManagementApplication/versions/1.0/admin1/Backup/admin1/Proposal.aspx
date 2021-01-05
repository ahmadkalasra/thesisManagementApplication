﻿
<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="admin1._Default" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

   <!-- Latest compiled and minified CSS -->
  <meta charset="utf-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link href="css/bootstrap.min.css" rel="stylesheet"/>
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    
    </head>
    <script>
        var flag = true;
    </script>
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
    position; relative;
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
  <a href="http://localhost:21315/Proposal.aspx">Proposal</a>
</div>


<div id="main">
<h1 class="page-header">Proposal</h1>
  <span style="font-size:30px;cursor:pointer" onclick="openNav()">&#9776;</span>
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
  <li><a href="#"><span class="glyphicon glyphicon-log-out"></span> Logout</a></li>
  </ul>
</nav>
<br />

<form class="form-horizontal" action='' method="POST">

 <div class="form-group">
  <label class="col-md-4 control-label" for="selectbasic">Select Basic</label>
  <div class="col-md-4">
    <select id="selectbasic" name="selectbasic" class="form-control input-md">
      <option>Option one</option>
      <option>Option two</option>
    </select>

  </div>
</div>
 <div class="form-group">
  <label class="col-md-4 control-label" for="selectbasic">Select Proposal</label>
  <div class="col-md-4">
    <select id="select1" name="selectbasic" class="form-control input-md">
      <option>Option one</option>
      <option>Option two</option>
    </select>

  </div>
</div>
 <div class="form-group">
  <label class="col-md-4 control-label" for="selectbasic">Select Supervisor</label>
  <div class="col-md-4">
    <span class="btn btn-default btn-file">
    Browse <input type="file">
</span>
  </div>
</div>
<div class="form-group">
  <label class="col-md-4 control-label" for="submit"></label>
  <div class="col-md-4">
    <button id="submit" name="submit" class="btn btn-primary">Submit</button>
  </div>
</div>
</form>
</body>
</html>
