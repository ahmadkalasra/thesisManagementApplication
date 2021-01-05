<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm10.aspx.cs" Inherits="Forms1.WebForm10" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <title></title>
     <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <head>
<style>

</style>
</head>
<body>
   <div class="container" >
 <div class="row" style="border: px solid #ccc;">
 <div class="col-md-offset-3 col-md-6">
 <form  method="post">
 <h2> <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/d/d2/Bahria_University_SVG.svg/2000px-Bahria_University_SVG.svg.png"  width="160" height="128">  <b > <p style="padding-right:20px;"</p> BAHRIA UNIVERSITY </b></h2>
  <h2> Islamabad Campus </h2>
    <h2>
        Research Proposal Evaluation 
    </h2>
  
  <br/>
  <p>Student Name ________________Reg No.______________________ 
  Programme______________________Discipline:___________________________
  Faculty/Department____________________________________________________
  Proposal Title for Research_________________________________________
  </p>
  <br />
  <h2> Assignment Report</h2>
      <table class="table table-bordered" >
            <tbody >
            <tr>
                <th class="col-xs-5">Evaluation Criteria</th>
                <th class="col-xs-2">Marks(0-3)</th>
            </tr>
            <tr>
                <th class="col-xs-5">(1) Research Topics</th>
                <th class="col-xs-2"></th>
            </tr>
            <tr>
                <td class="col-xs-5">Clarity</td>
                <th class="col-xs-2"></th>
            </tr>
            <tr>
                <td class="col-xs-5">depth</td>
                <th class="col-xs-2"></th>
            </tr>
            <tr>
                <td class="col-xs-5">Justification w.r.t degree program and background Study</td>
                <th class="col-xs-2"></th>
            </tr>
             <tr>
                <th class="col-xs-5">(2) Quality of witten proposal:</th>
                <th class="col-xs-2"></th>
            </tr>
            <tr>
                <td class="col-xs-5">All essential elements (topic, literature review, problem defination, etc)</td>
                <th class="col-xs-2"></th>
            </tr>
            <tr>
                <td class="col-xs-5">Studying write-up</td>
                <th class="col-xs-2"></th>
            </tr>
            <tr>
                <th class="col-xs-5">(3) Comprehension of subject matter:</th>
                <th class="col-xs-2"></th>
            </tr>
            <tr>
                <td class="col-xs-5">Knowledge of background literature</td>
                <th class="col-xs-2"></th>
            </tr>
            <tr>
                <td class="col-xs-5">Ability to form a hypothesis and objective</td>
                <th class="col-xs-2"></th>
            </tr>
             <tr>
                <th class="col-xs-5">(4) Knowledge of Method:</th>
                <th class="col-xs-2"></th>
            </tr>
             <tr>
                <td class="col-xs-5">Methodology of work presented with intelligibility</td>
                <th class="col-xs-2"></th>
            </tr>
             <tr>
                <td class="col-xs-5">Awareness of mordern hardware/sofware tools</td>
                <th class="col-xs-2"></th>
            </tr>
             <tr>
                <th class="col-xs-5">(5) Presentation of Proposal:</th>
                <th class="col-xs-2"></th>
            </tr>
             <tr>
                <td class="col-xs-5">Demonstration of professionalism</td>
                <th class="col-xs-2"></th>
            </tr>
             <tr>
                <td class="col-xs-5">Level of Confidence</td>
                <th class="col-xs-2"></th>
            </tr>
             <tr>
                <td class="col-xs-5">Answers to questions</td>
                <th class="col-xs-2"></th>
            </tr>
            <tr>
                <th class="col-xs-8" style="padding-left:330px;"> Total(out of 36)</th>
                <th class="col-xs-2"></th> 
            </tr>
            
            
    
  </tbody>
</table>
 <p style="padding-left:380px;" >Minimum Pass Score 60%)</p>
     <b>Based on my above assessment: (please initial the appropriate box) </b>
      <br />
       I recommend the research proposal.<input type="checkbox" name="v" value="B" >
       <br />
       I recommend the research proposal but suggest modifying the topic/title. <input type="checkbox" name="v" value="B" >
       <br />
       i am nit covienced and do not recommend the research proposal. <input type="checkbox" name="v" value="B" >
       <br />
      <p for="comment"><b> Comments </b></p>
      <textarea class="form-control" rows="4" id="Textarea1"></textarea>
     <p>Expert Name:__________ </p>  <p>Signature:__________ </p>
      <p>Date:__________ </p>
      <br />
<div>
<br />
    <span class="btn btn-default btn-file">
    Browse <input type="file">
</span>
</div>
<br />
      <div class="col-md-4">
        <button type="button" class="btn btn-success"> Save </button>
        </div>
        <div class="col-md-6">
         <button type="button" class="btn btn-default">Save and Submit</button> 
         </div>
          <div class="col-md-2">
         <button type="button" class="btn btn-danger">Close</button>
         </div>   
  </form>
 
  </div>
  </div>
</body>
</html>
