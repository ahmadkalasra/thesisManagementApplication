<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registered_successfully.aspx.cs" Inherits="admin1.Registered_successfully" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head  runat="server">

   <!-- Latest compiled and minified CSS -->
  <meta charset="utf-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link href="css/bootstrap.min.css" rel="stylesheet"/>
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="Styles/jquery.datetimepicker.css" rel="stylesheet" type="text/css" />
    </head>
<body>
<nav class="navbar navbar-inverse navbar-fixed-top">
  <ul class="nav navbar-nav">
    <a class="navbar-brand" href="#">Bahria university Islamabad </a>
 </ul>
 <ul class="nav navbar-nav navbar-right">
  <li><a href="#"><span class="glyphicon glyphicon-log-out"></span> Logout</a></li>
  </ul>
</nav>
<br />
<h1 class="page-header">Registration form</h1>
<form class="form-horizontal" runat="server">
  

<div class="form-group">
  <div  style="background:green;color:white; text-align:center; ;">
      You have been Registered Successfully. Click button below to sign in.<br />
      <asp:Button ID="Button1"  runat="server" Text="Sign In" class="btn btn-success" OnClick="Button1_Click"  />
  </div>
</div>

</form>
</body>
</html>

