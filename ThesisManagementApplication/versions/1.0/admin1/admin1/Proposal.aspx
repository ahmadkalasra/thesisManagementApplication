
<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Proposal.aspx.cs" Inherits="admin1.Proposal" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head  runat="server">

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
  <li><a href="logout.aspx"><span class="glyphicon glyphicon-log-out"></span> Logout</a></li>
  </ul>
</nav>
<br />

<div id="mySidenav" class="sidenav">
  <a href="javascript:void(0)" class="closebtn" onclick="closeNav()">&times;</a>
  <a href="http://localhost:21315/Home.aspx">Profile information</a>
  <a href="http://localhost:21315/Proposal.aspx">Proposal</a>
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

    <!--------------------------------------- Proposal Status Table----------------------------------------------->
<div id="main">

<h1 class="page-header"><span class="glyphicon glyphicon-user"></span> Student Panel - Proposal</h1>
  <span style="font-size:30px;cursor:pointer" onclick="openNav()">&#9776; </span>
    <asp:Panel ID="Panel1" runat="server">
  <table class="table table-bordered">
            <tbody >
    <tr>
      <th>Project Title</th>   
        <td><asp:Literal ID="research_area" runat="server" ></asp:Literal></td> 
        <td><asp:LinkButton runat="server" OnClick="btnDownload_Click" Text="Download"/></td>  
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


    <!--------------------------------------- Proposal Status Table End ----------------------------------------------->

 <div class="form-group">
  <label class="col-md-4 control-label" for="selectbasic">Research Area</label>
  <div class="col-md-4">
    <select id="reserach" name="selectbasic" runat="server" class="form-control input-md">
      <option>-----SELECT-----</option>
      <option>Machine Learning</option>
      <option>Ad-hoc Networks</option>
    </select>

  </div>
</div>
 <div class="form-group">
  <label class="col-md-4 control-label" for="selectbasic">Select Supervisor</label>
  <div class="col-md-4">
    <select id="supervisor" name="selectbasic" runat="server" class="form-control input-md">
      <option>-----SELECT-----</option>
      <option>Dr. Muhammad Muzammal</option>
      <option>Dr.Arif ur Rehman</option>
    </select>

  </div>
</div>
 <div class="form-group">
  <label class="col-md-4 control-label" for="selectbasic">Upload Proposal</label>
  <div class="col-md-3">
    <span class="btn btn-default btn-file">
        <asp:FileUpload ID="FileUpload1" runat="server" />
</span>
  </div>
     <div class="col-md-2">
         
  </div>
</div>
    <asp:Panel ID="Panel2" runat="server">
    <div class="form-group">
        <label class="col-md-4 control-label" for="selectbasic">
       
            </label>
        <div class="col-md-3" style="color:red;">
            <asp:Literal ID="errortext" runat="server" ></asp:Literal>
            </div>
        </div>
        </asp:Panel>
    <div class="form-group">
        <label class="col-md-4 control-label" for="selectbasic">
       
            </label>
        <div class="col-md-3" style="color:red;">
            <asp:Button ID="login" runat="server" Text="Upload" class="btn btn-primary" OnClick="upload_Click" />
            </div>
        </div>
    </div>
</form>
</body>
</html>
