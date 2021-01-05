<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="quarterly-report.aspx.cs" Inherits="admin1.quarterly_report" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quarterly-Form</title>
    <meta charset="utf-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1" />
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script type="text/javascript">

        function pageLoad(eve) {
                
            if ((eve.which != 46 || $("#TextBox1").val().indexOf('.') != -1) && (eve.which < 48 || eve.which > 57) || (eve.which == 46 && $("#TextBox1").val().caret().start == 0)) {
                eve.preventDefault();
                
            }
            //iterate through each textboxes and add keyup
            //handler to trigger sum event 
            
                };
        function CountMe(eve1) {
            var $regex = /(\w)\1{1,}/;
            if ($("#TextBox1").val().indexOf('.') == 0) {
                $("#TextBox1").val($("#TextBox1").val().substring(1));
            }
        };
        $(document).ready(function () {

            //iterate through each textboxes and add keyup
            //handler to trigger sum event
            $(".main8").each(function () {

                $(this).keyup(function () {
                    calculateSum();
                });
            });

        });
        function calculateSum() {

            var sum = 0;
            //iterate through each textboxes and add the values
            $(".main8").each(function () {

                //add only if the value is number
                if (!isNaN(this.value) && this.value.length != 0) {
                    sum += parseFloat(this.value);
                }

            });
            //.toFixed() method will roundoff the final sum to 2 decimal places
            $("#sum").html(sum.toFixed(2));
        }
    </script>
    <link href="Styles/ms-10.css" rel="stylesheet" />
    <style>
        .threat
        {
            margin:0;
            padding:0;
            text-align:center;
            width:100%;
            height:20px;
            background-color:lawngreen;
            color:black;
            font-size:15px;
            font-weight:bolder;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="Panel1" runat="server">
    <div class="main">
        <div class="main1">
            MS/PHd Thesis Evaluation System
        </div>
        <div>
            <img  src="<%= ResolveClientUrl("~/img/Bahria_Logo.png") %>" class="main2" />
        </div>
        <div class="main1">
            Quarterly Progress Report Form
        </div><hr />
        <div class="main3">
            <div class="main14">
            <span class="main4">Student Name: <span class="main5"><asp:Literal ID="sname"  runat="server" ></asp:Literal></span></span><br />
            <span  class="main4">Registration No: <span class="main5"><asp:Literal ID="Literal1"  runat="server" ></asp:Literal></span></span><br />
            <span class="main4">Program: <span class="main5"><asp:Literal ID="Literal2"  runat="server" ></asp:Literal></span></span>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
            <span  class="main4">Dicipline: <span class="main5"><asp:Literal ID="Literal3"  runat="server" >Computer Science </asp:Literal></span></span><br />
            <span  class="main4">Faculty/Department: <span class="main5"><asp:Literal ID="Literal4"  runat="server" >Computer Science </asp:Literal></span></span><br />
            <span  class="main4">Title of Thesis : <span class="main5"><asp:Literal ID="Literal5"  runat="server" ></asp:Literal></span></span><br />
            <span  class="main4">Report For Research Period : <span class="main5"><asp:Literal ID="Literal9"  runat="server" ></asp:Literal></span></span><br />
            <span class="main4">From : <span class="main5"><asp:Literal ID="Literal10"  runat="server" ></asp:Literal></span></span>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
            <span  class="main4">To : <span class="main5"><asp:Literal ID="Literal11"  runat="server" >Computer Science </asp:Literal></span></span><hr />
            </div>
                <div class="main6">
                Progress Report
                <hr />
            </div>
            <div class="main12">
                <div class="row">
                    <span class="main11">Comments/Assessment:<br />(Please include the progress of Research Paper publication, if any.)</span>
                </div>
                <div class="row">
                    <textarea id="TextArea1" class="main13" placeholder="Please write comments about student performance" cols="20" rows="2" runat="server"></textarea>
                    <asp:Panel ID="Panel10" runat="server"><span style="color:red;">*Please Enter Comments <b>!</b></span></asp:Panel>
                </div>
            </div>
            <div class="main10">
                <span class="main11">As per my assesment, the progress during the period is: <br />(please initial the appropriate box) </span><br />
                <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                    <asp:ListItem Text="&nbsp Excellent" Value="1"></asp:ListItem>
                    <asp:ListItem Text="&nbsp Satisfactory" Value="2"></asp:ListItem>
                    <asp:ListItem Text="&nbsp Unsatisfactory" Value="3"></asp:ListItem>
                </asp:RadioButtonList>
                <asp:Panel ID="Panel3" runat="server"><span style="color:red;">*Please initial appropriate box <b>!</b></span></asp:Panel>
            </div>
            
            <div class="main14">
            <span  class="main4">Supervisor Name: <span class="main5"><asp:Literal ID="Literal6"  runat="server" >Dr. Muhammd Muzammal </asp:Literal></span></span><br />
            <span  class="main4">Date: <span class="main5"><asp:Literal ID="Literal7"  runat="server" >24-03-2017</asp:Literal></span></span><hr />
            
            </div>
            
            <div class="main15">
                
                    <asp:Button ID="submit" runat="server" Text="Submit" OnClick="update_click" class="btn btn-primary" />
                    <asp:Button ID="close" runat="server" Text="Close" class="btn btn-primary" />
               
            </div>
        </div><hr />
    </div>
            </asp:Panel>
        <asp:Panel ID="Panel2" runat="server">
            <div class="threat">
                Unauthorized Access
            </div>
        </asp:Panel>
        <asp:Panel ID="Panel4" runat="server">
            <div class="threat">
                Progress Report submitted Successfully. Thankyou for your time :-)
            </div>
        </asp:Panel>
    </form>
</body>
</html>
