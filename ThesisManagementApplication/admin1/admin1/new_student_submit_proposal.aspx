<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="new_student_submit_proposal.aspx.cs" Inherits="admin1.new_student_submit_proposal" %>
<!DOCTYPE html>
<html lang="en">
<head>
  <title>Bootstrap Case</title> 
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <style>
        /* CSS used here will be applied after bootstrap.css */

/* Create a medium height at 40px */
.navbar-md {min-height:38px; background-color:#7a8c74;}
.navbar-md .navbar-brand,
.navbar-md .navbar-nav>li>a {padding-top:9px; padding-bottom:8.5px; color:#fff;}
.navbar-md .navbar-brand {height: 38px}  
.navbar-md .navbar-toggle {margin: 4px 13px 3px 0px; padding: 6px 8px 8px 11px;}
.navbar-md .navbar-toggle .icon-bar {width: 19px;}


 
.container
{
    padding-top:30px;
    
    margin:0;
}

#open
{
    background-color:#7a8c74;
    font-size:18px;
    font-weight:bold;
    color:#fff;
}
#open:hover
{
    background-color: #555;
    color:#fff;
}
.title
{
    background-color:black;
    color:#fff;
}
#brand
{
    font-size:24px;
    font-family: Cambria;
    padding-left:10px;
}
#brand:hover
{
    color:#dee2dc;
}
.navbar-default .navbar-toggle .icon-bar {
    background-color: #fff;
}
.navbar-default .navbar-toggle .icon-bar:hover
{
    color:white;
}
.navbar-default .navbar-toggle:hover
{
    background-color:transparent;
}
.dropdown-default .dropdown-toggle.dropdown-menu{
    padding:0px;
    margin:0 auto;
   
}
#dropd
{
    color:#fff;
    font-size:12px;
    margin:0 auto;
    
}
#dropd:hover
{
    color:#fff;
    background-color:#555;
}
#dropd:focus
{
    color:#fff;
    background-color:#555;
}

#profpic
{
    text-align:center; color:white;
}
#profpica
{
    color:#fff;
}
#profpica:hover
{
    background-color:#7a8c74;
}
.dropbut
{
    color:white;
}
#dropbut
{
    color:white;
    background-color:#616161;
    width:100%;
}
#dropbut:hover
{
    background-color:#555;
}
#drop11
{
    margin-bottom:0;
    margin-top:0px;
    background-color:#7a8c74; 
    border-color:#7a8c74; 
    padding:0px; 
    margin:0px;
}
@media (max-width: 767px)
{
   .navbar-collapse
   {
       border-color:black;
       background-color:#616161;
   }
   #dropbut
   {
       width:100vh;
   }
   #drop11
{
    margin-bottom:0;
    margin-top:0px;
}
   
}

    </style>
    <link href="Styles/new1.css" rel="stylesheet" />
    <script>
        var x = 0;
        function w3_close() {
            if (document.getElementById("mySidenav").style.display == "none")
            {
                if (!$("#hideshow").is(":visible")) {
                    var elements = document.querySelectorAll('.main');
                    for (var i = 0; i < elements.length; i++) {
                        elements[i].style.width = "calc(100% - 225px)";
                        elements[i].style.marginLeft = 225 + "px";
                    }
                    document.getElementById("mySidenav").style.display = "block";
                }
                else
                {
                    document.getElementById("mySidenav").style.display = "block";
                }
            }
            else
            {
                var elements = document.querySelectorAll('.main');
                for (var i = 0; i < elements.length; i++) {
                    elements[i].style.width = "calc(100% - 225px)";
                    elements[i].style.marginLeft = 0 + "px";
                }
                document.getElementById("mySidenav").style.display = "none";
            }
            
        }
        function w3_close1() {
            document.getElementById("mySidenav").style.display = "none";
        }
    </script>
    <style >
        .my11
{
    background-color:gainsboro;
}
   .table-bordered td, .table-bordered th{
    border-color:	#989898 !important;
}
    </style>
</head>
<body>
    <div class="main3">
<div class="navbar navbar-default navbar-fixed-top navbar-md" id="main-navbar">
 <div class="navbar-header" >
     <a class="navbar-brand"  id="open" title="Open/Hide Menu" onclick="w3_close()" href="#">&#9776;</a>
     <a class="navbar-brand" id="brand" href="#">Bahria University</a>
      <a class="navbar-toggle"  id="hideshow" data-toggle="collapse" data-target=".navbar-collapse" onclick="w3_close1()">
        <span class="icon-bar" ></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
      </a>
    </div>
    <div class="navbar-collapse collapse" >
      <ul class="nav navbar-nav navbar-right"  >
        <li class="dropdown" >
        <a href="#" id="dropd" class="dropdown-toggle" data-toggle="dropdown"> <span  class="glyphicon glyphicon-user icon-size"></span><asp:Literal ID="Literal7" runat="server"></asp:Literal> <span class="caret"></span></a>

                  <ul class="dropdown-menu pull-left" id="drop11"  role="menu">
                    <li class="hidden-sm hidden-xs" id="profpic"><a href="#" id="profpica" ><img src="img/pic.png" style="width:75px;height:75px; padding:10px;" /><br /><asp:Literal ID="Literal10" runat="server"></asp:Literal> <br /><span style="word-break:break-all;">01-134132-<br />079@student.bahria.edu.pk</span></a></li>
                      <li><a href="#" id="dropbut">Profile</a></li>
                      <li><a href="logout.aspx" id="dropbut">Sign Out</a></li>
                      

                    </ul>
      </li>
        
      </ul>
        
    </div>
</div>

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
				<li class="lii" style="border-top-color:#7a8c74;border-bottom-color:#7a8c74;"><a href="new_student_profile.aspx" style="color:#fff;  width:inherit; height:inherit;"><span >Profile</span><span style="font-size:16px;" class="pull-right hidden-xs showopacity glyphicon glyphicon-user"></span></a></li>
				
                <li class="lii" style="border-top-color:#7a8c74;border-bottom-color:#7a8c74;"><a href="new_student_submit_proposal.aspx" style="color:#fff;  width:inherit; height:inherit;"><span >Thesis</span><span style="font-size:16px;" class="pull-right hidden-xs showopacity glyphicon glyphicon-book"></span></a></li>
				<li class="lii" style="border-top-color:#7a8c74;border-bottom-color:#7a8c74;"><a href="#" style="color:#fff;  width:inherit; height:inherit;"><span >Change Password</span></a></li>
				
				
			</ul>
		</div>
        
	</div>
    
</nav>
<div class="container-fluid" style="padding-top:30px; height:100%; overflow:auto;">
 <form runat="server">
<h3 class="page-header"><span class="glyphicon glyphicon-book"></span> Research Proposal</h3>

 <asp:Panel ID="Panel1" runat="server">
  <table class="table table-bordered">
            <tbody >
    <tr class="my11" >
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
    <tr class="my11">
      <th>Submission Date</th>
      <td><asp:Literal ID="submisssion_date" runat="server" ></asp:Literal></td>
      <th>Defense Date</th>
      <td colspan="2"><asp:Literal ID="proposal_defense_date" runat="server" ></asp:Literal></td>
    </tr>
   
    
  </tbody>
</table>
        </asp:Panel>

     <!-- Proposal Defense Details -->
        <asp:Panel ID="Panel16" runat="server">

        <h3 class="page-header"><span class="glyphicon glyphicon-calendar"></span> Proposal Defense Details</h3><br />
        <table class="table table-bordered"  >
            <tbody >
    <tr  class="my11">
      <th>Defense Date</th>   
        <td><asp:Literal ID="Literal1" runat="server" ></asp:Literal></td> 
      <th>Defense Time</th>
        <td><asp:Literal ID="Literal2" runat="server" ></asp:Literal></td>
      <th>Location</th>
        <td><asp:Literal ID="Literal3" runat="server" ></asp:Literal></td>

    </tr>
                <tr>
      <th>Examiner 1</th>   
        <td colspan="2"><asp:Literal ID="Literal4" runat="server" ></asp:Literal></td> 
      <th>Examiner 2</th>
        <td colspan="2"><asp:Literal ID="Literal5" runat="server" ></asp:Literal></td>
    </tr> 
  
  </tbody>
</table>
         </asp:Panel>
     <!-- Proposal Defense Details -->
    <!--------------------------------------- Proposal Status Table End ----------------------------------------------->
     <asp:Panel ID="Panel7" runat="server">
     <h3 class="page-header"><div style="text-align:center;">Upload Proposal</div> </h3> 
 <div class="row">
  <label class="col-md-4 control-label" for="selectbasic" style="text-align:right;padding-top:5px;">Project title</label>
  <div class="col-md-4">
  <asp:TextBox ID="project_title" placeholder="Project Title" class="form-control input-md" runat="server"></asp:TextBox>
    <asp:Panel ID="Panel5" runat="server"><span style="color:red;">*Please Enter Project Title <b>!</b></span></asp:Panel>
  </div>

</div><br />
 <div class="row">
  <label class="col-md-4 control-label" for="selectbasic" style="text-align:right;padding-top:5px;">Select Supervisor</label>
  <div class="col-md-4">
        <asp:DropDownList ID="supervisor" class="form-control input-md" runat="server"></asp:DropDownList>
      <asp:Panel ID="Panel3" runat="server"><span style="color:red;">*Please Select Suprevisor <b>!</b></span></asp:Panel>
  </div>
</div><br />

    <div class="row">
  <label class="col-md-4 control-label" for="selectbasic" style="text-align:right;padding-top:5px;">Project Abstract</label>
  <div class="col-md-4">
  <textarea id="project_abstract" cols="20" rows="2" placeholder="Please Write Project Abstract(200-300 Words)" class="form-control input-md" style="resize: none;overflow-y: scroll;min-height:200px;word-break: keep-all;" runat="server"></textarea>
  <asp:Panel ID="Panel4" runat="server"><span style="color:red;">*Please Write Project Abstract <b>!</b></span></asp:Panel>
  </div>
        </div><br />
 <div class="row">
  <label class="col-md-4 control-label" for="selectbasic" style="text-align:right;padding-top:5px;">Upload Proposal</label>
  <div class="col-md-3">
    <span class="btn btn-default btn-file">
        <asp:FileUpload ID="FileUpload1" runat="server" />
</span>
      <asp:Panel ID="Panel6" runat="server"><span style="color:red;">*Please Choose Proposal File in PDF <b>!</b></span></asp:Panel>
  </div>
     <div class="col-md-2">
         
  </div>
</div><br />
    <asp:Panel ID="Panel2" runat="server">
    <div class="form-group">
        <label class="col-md-4 control-label" for="selectbasic">
       
            </label>
        <div class="col-md-3" style="color:red;">
            <asp:Literal ID="errortext" runat="server" ></asp:Literal>
            </div>
        </div>
        </asp:Panel>
    <div class="row">
        <label class="col-md-4 control-label" for="selectbasic">
       
            </label>
        <div class="col-md-3" style="color:red;">
            <asp:Button ID="login" runat="server" Text="Upload" class="btn btn-primary" OnClick="upload_Click" />
            </div>
        </div>
</asp:Panel>

     <!-- Update Proposal -->


          <asp:Panel ID="Panel8" runat="server">
     <h3 class="page-header"><div style="text-align:center;">Update Proposal</div> </h3> 
 <div class="row">
  <label class="col-md-4 control-label" for="selectbasic" style="text-align:right;padding-top:5px;">Project title</label>
  <div class="col-md-4">
  <asp:TextBox ID="TextBox1" placeholder="Project Title" class="form-control input-md" runat="server"></asp:TextBox>
    <asp:Panel ID="Panel9" runat="server"><span style="color:red;">*Please Enter Project Title <b>!</b></span></asp:Panel>
  </div>

</div><br />
    <div class="row">
  <label class="col-md-4 control-label" for="selectbasic" style="text-align:right;padding-top:5px;">Project Abstract</label>
  <div class="col-md-4">
  <textarea id="Textarea1" cols="20" rows="2" placeholder="Please Write Project Abstract(200-300 Words)" class="form-control input-md" style="resize: none;overflow-y: scroll;min-height:200px;word-break: keep-all;" runat="server"></textarea>
  <asp:Panel ID="Panel11" runat="server"><span style="color:red;">*Please Write Project Abstract <b>!</b></span></asp:Panel>
  </div>
        </div><br />
 <div class="row">
  <label class="col-md-4 control-label" for="selectbasic" style="text-align:right;padding-top:5px;">Upload Proposal</label>
  <div class="col-md-3">
    <span class="btn btn-default btn-file">
        <asp:FileUpload accept="application/pdf" ID="FileUpload2" runat="server" />
</span>
      <asp:Panel ID="Panel12" runat="server"><span style="color:red;">*Please Choose Proposal File in PDF <b>!</b></span></asp:Panel>
  </div>
     <div class="col-md-2">
         
  </div>
</div>
    <asp:Panel ID="Panel13" runat="server">
    <div class="form-group">
        <label class="col-md-4 control-label" for="selectbasic">
       
            </label>
        <div class="col-md-3" style="color:red;">
            <asp:Literal ID="Literal6" runat="server" ></asp:Literal>
            </div>
        </div>
        </asp:Panel>
    <div class="row">
        <div class="col-md-4 control-label" for="selectbasic">
       
            </div>
        <div class="col-md-3" style="color:red;">
            <asp:Button ID="Button1" runat="server" Text="Update" class="btn btn-primary" OnClick="update_Click" />
            </div>
        </div>
</asp:Panel>

     <!-- Update Proposal End -->
    <!-- Submit Thesis Section -->

     <asp:Panel ID="Panel10" runat="server">
         <br /><h3 class="page-header"><span class="glyphicon glyphicon-book"></span> Thesis Panel</h3><br />
         <div class="row">
             <label class="col-md-4 control-label" for="selectbasic" style="text-align:right;padding-top:5px;"></label>
             <div class="col-md-3" style="margin-bottom:5px; font-size:large; font-weight:bold; ">Upload Thesis</div>
         </div>
         <div class="row">
  <label class="col-md-4 control-label" for="selectbasic" style="text-align:right;padding-top:5px;"></label>
  <div class="col-md-3">
    <span class="btn btn-default btn-file">
        <asp:FileUpload accept="application/pdf" ID="FileUpload3" runat="server" />
</span>
      <asp:Panel ID="Panel15" runat="server"><span style="color:red;">*Please Choose Thesis File <b>!</b></span></asp:Panel>
      <asp:Panel ID="Panel14" runat="server"><span style="color:red;">*Please Upload File in PDF Format <b>!</b></span></asp:Panel>
  </div>
     <div class="col-md-2">
         
  </div>
</div><br />
         <div class="row">
             <label class="col-md-4"></label>
             <div class="col-md-3" style="color:red;">
            <asp:Button ID="Button2" runat="server" Text="Upload Thesis" OnClick="upload_thesis" class="btn btn-primary"  />
            </div>
         </div>

     </asp:Panel>

     <!-- Thesis Details -->
        <asp:Panel ID="Panel17" runat="server">

        <h3 class="page-header"><span class="glyphicon glyphicon-book"></span> Thesis Details</h3><br />
        <table class="table table-bordered"  >
            <tbody >
    <tr  class="my11">
      <th>Thesis File</th>   
        <td><asp:LinkButton runat="server" OnClick="btnDownload_Click_thesis" Text="Download"/></td> 
      <th>Submission Date</th>
        <td><asp:Literal ID="Literal8" runat="server" ></asp:Literal></td>
      <th>Status</th>
        <td><asp:Literal ID="Literal9" runat="server" ></asp:Literal></td>

    </tr>
                
  </tbody>
</table>
         </asp:Panel>
     <!-- Thesis Details -->
     <!-- Thesis Defense Details -->
        <asp:Panel ID="Panel21" runat="server">

        <h3 class="page-header"><span class="glyphicon glyphicon-book"></span> Thesis Defense Details</h3>
        <table class="table table-bordered"  >
            <tbody >
    <tr  class="my11">
      <th>Defense Date</th>   
        <td><asp:Literal ID="Literal11" runat="server" ></asp:Literal></td> 
      <th>Defense Time</th>
        <td><asp:Literal ID="Literal12" runat="server" ></asp:Literal></td>
      <th>Location</th>
        <td><asp:Literal ID="Literal13" runat="server" ></asp:Literal></td>

    </tr>
                <tr>
      <th>Examiner 1</th>   
        <td colspan="2"><asp:Literal ID="Literal14" runat="server" ></asp:Literal></td> 
      <th>Examiner 2</th>
        <td colspan="2"><asp:Literal ID="Literal15" runat="server" ></asp:Literal></td>
    </tr>
  
  </tbody>
</table>
         </asp:Panel>
     <!-- Thesis Defense Details end-->

     <!-- update Thesis -->
     <asp:Panel ID="Panel18" runat="server">
         <br />
         <div class="row">
             <label class="col-md-4 control-label" for="selectbasic" style="text-align:right;padding-top:5px;"></label>
             <div class="col-md-3" style="margin-bottom:5px; font-size:large; font-weight:bold; ">Update Thesis</div>
         </div>
         <div class="row">
  <label class="col-md-4 control-label" for="selectbasic" style="text-align:right;padding-top:5px;"></label>
  <div class="col-md-3">
    <span class="btn btn-default btn-file">
        <asp:FileUpload accept="application/pdf" ID="FileUpload4" runat="server" />
</span>
      <asp:Panel ID="Panel19" runat="server"><span style="color:red;">*Please Choose Thesis File <b>!</b></span></asp:Panel>
      <asp:Panel ID="Panel20" runat="server"><span style="color:red;">*Please Upload File in PDF Format <b>!</b></span></asp:Panel>
  </div>
     <div class="col-md-2">
         
  </div>
</div><br />
         <div class="row">
             <label class="col-md-4"></label>
             <div class="col-md-3" style="color:red;">
            <asp:Button ID="Button3" runat="server" Text="Update Thesis" OnClick="update_thesis" class="btn btn-primary"  />
            </div>
         </div>

     </asp:Panel>

     <!-- update Thesis End-->
     
 </form>
    </div>
    
</div>
</body>
</html>

