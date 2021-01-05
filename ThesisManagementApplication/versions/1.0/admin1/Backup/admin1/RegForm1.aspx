<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="admin1._Default" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

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
<form class="form-horizontal" action='' method="POST">
  <div class="form-group">
  <label class="col-md-4 control-label" for="fn">First name</label>  
  <div class="col-md-4">
  <input id="fn" name="fn" type="text" placeholder="first name" class="form-control input-md" required="">
    
  </div>
</div>

<!-- Text input-->
<div class="form-group">
  <label class="col-md-4 control-label" for="ln">Last name</label>  
  <div class="col-md-4">
  <input id="ln" name="ln" type="text" placeholder="last name" class="form-control input-md" required="">
    
  </div>
</div>
<div class="form-group">
  <label class="col-md-4 control-label" for="fn">Enrollment</label>  
  <div class="col-md-4">
  <input id="Text3" name="fn" type="text" placeholder="Enrollment" class="form-control input-md" required="">
    
  </div>
</div>
<div class="form-group">
  <label class="col-md-4 control-label" for="fn">PersonalEmail</label>  
  <div class="col-md-4">
  <input id="Text1" name="fn" type="text" placeholder="PersonalEmail" class="form-control input-md" required="">
    
  </div>
</div>
<div class="form-group">
  <label class="col-md-4 control-label" for="ln">University Email</label>  
  <div class="col-md-4">
  <input id="Text4" name="ln" type="text" placeholder="University Email" class="form-control input-md" required="">
    
  </div>
</div>

<!-- Text input-->
<div class="form-group">
  <label class="col-md-4 control-label" for="ln">Phone no</label>  
  <div class="col-md-4">
  <input id="Text2" name="ln" type="text" placeholder="Phone #" class="form-control input-md" required="">
    
  </div>
</div>
  <div class="form-group">
  <label class="col-md-4 control-label" for="selectbasic">Select Program</label>
  <div class="col-md-4">
    <select id="selectbasic" name="selectbasic" class="form-control input-md">
      <option>Option one</option>
      <option>Option two</option>
    </select>

  </div>
</div>
<div class="form-group">
  <label class="col-md-4 control-label" for="ln">Registration #</label>  
  <div class="col-md-4">
  <input id="Text5" name="ln" type="text" placeholder="Registration #" class="form-control input-md" required="">
    
  </div>
</div>
<div class="form-group">
  <label class="col-md-4 control-label" for="ln">Address</label>  
  <div class="col-md-4">
  <input id="Text6" name="ln" type="text" placeholder="Address" class="form-control input-md" required="">
    
  </div>
</div>
<div class="form-group">
  <label class="col-md-4 control-label" for="ln">password</label>  
  <div class="col-md-4">
  <input id="Text7" name="ln" type="password" placeholder="password" class="form-control input-md" required="">
    
  </div>
</div>

<div class="form-group">
  <label class="col-md-4 control-label" for="submit"></label>
  <div class="col-md-4">
    <button id="submit" name="submit" class="btn btn-success">Register</button>
  </div>
</div>

</form>
</body>
</html>
