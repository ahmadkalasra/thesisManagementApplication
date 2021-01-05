<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="admin1.SignIn" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

   <!-- Latest compiled and minified CSS -->
  <meta charset="utf-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link href="css/bootstrap.min.css" rel="stylesheet"/>
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    
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
<h1 class="page-header">Sign in form</h1>
<form class="form-horizontal" runat="server">
  <div class="form-group">
  <label class="col-md-4 control-label" for="fn">Enrollment</label>  
  <div class="col-md-4">
  <asp:TextBox ID="enrollment" placeholder="Enrollment" class="form-control input-md" runat="server"></asp:TextBox>
   
  </div>


</div>

    <div class="form-group">
  <label class="col-md-4 control-label" for="fn">Password</label>  
  <div class="col-md-4">
  <asp:TextBox ID="password" placeholder="password" type="password" class="form-control input-md" runat="server"></asp:TextBox>
   
  </div>


</div>
    <div class="form-group">
  <label class="col-md-4 control-label" for="submit"></label>
  <div class="col-md-4">
      <asp:Button ID="login"  runat="server" Text="Login" class="btn btn-success" OnClick="login_Click" />
  </div>
</div>

</form>
</body>
</html>
