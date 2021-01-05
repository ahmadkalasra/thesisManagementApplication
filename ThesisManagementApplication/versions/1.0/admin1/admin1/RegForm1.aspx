<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="RegForm1.aspx.cs" Inherits="admin1.RegForm1" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
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
  <label class="col-md-4 control-label" for="fn">First name</label>  
  <div class="col-md-4">
     <asp:TextBox ID="fname" placeholder="first name" class="form-control input-md" runat="server"></asp:TextBox>
    
  </div>
</div>

<!-- Text input-->
<div class="form-group">
  <label class="col-md-4 control-label" for="ln">Last name</label>  
  <div class="col-md-4">
  <asp:TextBox ID="lname" placeholder="last name" class="form-control input-md" runat="server"></asp:TextBox>
    
  </div>
</div>
<div class="form-group">
  <label class="col-md-4 control-label" for="fn">Enrollment</label>  
  <div class="col-md-4">
  <asp:TextBox ID="enrollment" placeholder="enrollment" class="form-control input-md" runat="server"></asp:TextBox>
    
  </div>
</div>
<div class="form-group">
  <label class="col-md-4 control-label" for="fn">PersonalEmail</label>  
  <div class="col-md-4">
  <asp:TextBox ID="pemail" placeholder="personal email" class="form-control input-md" runat="server"></asp:TextBox>
    
  </div>
</div>
<div class="form-group">
  <label class="col-md-4 control-label" for="ln">University Email</label>  
  <div class="col-md-4">
  <asp:TextBox ID="uemail" placeholder="university email" class="form-control input-md" runat="server"></asp:TextBox>
  </div>
</div>

<!-- Text input-->
<div class="form-group">
  <label class="col-md-4 control-label" for="ln">Phone no</label>  
  <div class="col-md-4">
  <asp:TextBox ID="phone" placeholder="phone Number" class="form-control input-md" runat="server"></asp:TextBox>
    
  </div>
</div>
  <div class="form-group">
  <label class="col-md-4 control-label" for="selectbasic">Select Program</label>
  <div class="col-md-4">
    <select ID="program" class="form-control input-md" runat="server">
      <option value="1">--SELECT--</option>
      <option value="2">MSCS</option>
        <option value="3">MSEE</option>
    </select>

  </div>
</div>
<div class="form-group">
  <label class="col-md-4 control-label" for="ln">Registration #</label>  
  <div class="col-md-4">
  <asp:TextBox ID="registration" placeholder="Registration Number" class="form-control input-md" runat="server"></asp:TextBox>
    
  </div>
</div>
<div class="form-group">
  <label class="col-md-4 control-label" for="ln">Address</label>  
  <div class="col-md-4">
  <asp:TextBox ID="address" placeholder="Address" class="form-control input-md" runat="server"></asp:TextBox>
   
  </div>
</div>
<div class="form-group">
  <label class="col-md-4 control-label" for="ln">password</label>  
  <div class="col-md-4">
  <asp:TextBox ID="password" placeholder="password" type="password" class="form-control input-md" runat="server"></asp:TextBox>
   
  </div>
</div>

<div class="form-group">
  <label class="col-md-4 control-label" for="submit"></label>
  <div class="col-md-4">
      <asp:Button ID="Button1"  runat="server" Text="Register" class="btn btn-success" OnClick="Button1_Click" />
  </div>
</div>

</form>
</body>
</html>
