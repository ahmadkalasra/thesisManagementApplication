<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="thesis_defense_evaluation_form.aspx.cs" Inherits="admin1.thesis_defense_evaluation_form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MS-10-Form</title>
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
        table.radioWithProperWrap input
 {    
      float: left;
 }

 table.radioWithProperWrap label
 {    
      margin-left: 25px;
      display: block;
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
            Research Proposal Evaluation Form
        </div><hr />
        <div class="main3">
            <div class="main14">
            <span class="main4">Student Name: <span class="main5"><asp:Literal ID="sname"  runat="server" ></asp:Literal></span></span><br />
            <span  class="main4">Registration No: <span class="main5"><asp:Literal ID="Literal1"  runat="server" ></asp:Literal></span></span><br />
            <span class="main4">Program: <span class="main5"><asp:Literal ID="Literal2"  runat="server" ></asp:Literal></span></span>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
            <span  class="main4">Dicipline: <span class="main5"><asp:Literal ID="Literal3"  runat="server" >Computer Science </asp:Literal></span></span><br />
            <span  class="main4">Faculty/Department: <span class="main5"><asp:Literal ID="Literal4"  runat="server" >Computer Science </asp:Literal></span></span><br />
            <span  class="main4">Research Title: <span class="main5"><asp:Literal ID="Literal5"  runat="server" ></asp:Literal></span></span><hr />
            </div>
                <div class="main6">
                Evaluation                    
                <br />
                    <asp:Panel ID="Panel28" runat="server"><span style="color:red;">*All feilds are Required <b>!</b></span></asp:Panel>
                    
                <table class="table table-bordered" id="main7">
            <tbody >
            <tr>
                <th class="col-xs-4">Parameter</th>
                <th class="col-xs-1">Wheitage</th>
                <th class="col-xs-2">Marks Awarded</th>
            </tr>
            <tr>
                <td class="col-xs-4">Thesis Write-up and its quality</td>
                <td class="col-xs-1">50</td>
                <th class="col-xs-2">
                    <asp:TextBox CssClass="main8" ID="TextBox1" onkeypress="pageLoad(event);" onkeyup="CountMe(this.value);" runat="server"></asp:TextBox>
                    <asp:Panel ID="Panel2" runat="server"><span style="color:red;">*Please Enter Marks <b>!</b></span></asp:Panel>
                    <asp:Panel ID="Panel3" runat="server"><span style="color:red;">*Must be <= 50 <b>!</b></span></asp:Panel>
                </th>
            </tr>
            <tr>
                <td class="col-xs-4">Presentation</td>
                <td class="col-xs-1">25</td>
                <th class="col-xs-2">
                    <asp:TextBox CssClass="main8" ID="TextBox2" onkeypress="pageLoad(event);" onkeyup="CountMe(this.value);" runat="server"></asp:TextBox>
                    <asp:Panel ID="Panel4" runat="server"><span style="color:red;">*Please Enter Marks <b>!</b></span></asp:Panel>
                    <asp:Panel ID="Panel5" runat="server"><span style="color:red;">*Must be <= 25 <b>!</b></span></asp:Panel>
                </th>
            </tr>
            <tr>
                <td class="col-xs-4">Viva Voice Examination</td>
                <td class="col-xs-1">25</td>
                <th class="col-xs-2">
                    <asp:TextBox CssClass="main8" ID="TextBox3" onkeypress="pageLoad(event);" onkeyup="CountMe(this.value);" runat="server"></asp:TextBox>
                    <asp:Panel ID="Panel6" runat="server"><span style="color:red;">*Please Enter Marks <b>!</b></span></asp:Panel>
                    <asp:Panel ID="Panel7" runat="server"><span style="color:red;">*Must be <= 25 <b>!</b></span></asp:Panel>
                </th>
            </tr>
             
            <tr>
                <th class="col-xs-4" style="text-align:right"> *Total</th>
                <td class="col-xs-1">100</td>
                <th class="col-xs-2">
                    <!--<asp:TextBox CssClass="main8" ID="TextBox13" onkeypress="pageLoad(event);" onkeyup="CountMe(this.value);" runat="server"></asp:TextBox>-->
                    <span id="sum"  runat="server">0.00</span>
                    <asp:Panel ID="Panel26" runat="server"><span style="color:red;">*Please Enter Marks <b>!</b></span></asp:Panel>
                    <asp:Panel ID="Panel27" runat="server"><span style="color:red;">*Must be less than <= 3 <b>!</b></span></asp:Panel>
                </th>
            </tr>
            
            
    
  </tbody>
</table>
                <div class="main9">
                    *Passing Percentage (60%)
                </div>
            </div>
            <div class="main10">
                <span class="main11">Based on my above assessment: (please initial the appropriate box) </span><br />
                <asp:RadioButtonList ID="RadioButtonList1" CssClass="radioWithProperWrap" runat="server">
                    <asp:ListItem Text="The thesis meets all the requirements. The degree be awarded." Value="1"></asp:ListItem>
                    <asp:ListItem Text="The thesis requires major/minor changes, as pointed put in the detailed report. Thesis changes be incorporated and the revised thesis to be sent to me, along with the compliance report, within 2 weeks for reassessment. Degree be awarded if recommended in my reassessment report." Value="2"></asp:ListItem>
                    <asp:ListItem Text="The thesis is unacceptable. Degree not to be awarded." Value="3"></asp:ListItem>
                </asp:RadioButtonList>
                <asp:Panel ID="Panel9" runat="server"><span style="color:red;">*Please Initiate Appropriate Box <b>!</b></span></asp:Panel>
                    
            </div>
            <div class="main12">
                <div class="row">
                    <span class="main11">Comments</span>
                </div>
                <div class="row">
                    <textarea id="TextArea1" class="main13" cols="20" rows="2" runat="server"></textarea>
                    <asp:Panel ID="Panel8" runat="server"><span style="color:red;">*Please write down comments <b>!</b></span></asp:Panel>
                    
                </div>
            </div>
            <div class="main14">
            <span  class="main4">Examiner Name: <span class="main5"><asp:Literal ID="Literal6"  runat="server" >Dr. Muhammd Muzammal </asp:Literal></span></span><br />
            
                <span  class="main4">Date: <span class="main5"><asp:Literal ID="Literal7"  runat="server" >24-03-2017</asp:Literal></span></span><hr />
            
            </div>
            <div class="main15">
                
                    <asp:Button ID="submit" runat="server" Text="Submit" OnClick="setup_thesis_defense"  class="btn btn-primary" />
                    <asp:Button ID="close" runat="server" Text="Close" class="btn btn-primary" />
               
            </div>
        </div><hr />
    </div>
            </asp:Panel>
        <asp:Panel ID="Panel29" runat="server">
            <div class="threat">
                Unauthorized Access
            </div>
        </asp:Panel>
        <asp:Panel ID="Panel30" runat="server">
            <div class="threat">
                Evaluation Form Submitted Successfully. Thankyou for your time :-) .
            </div>
        </asp:Panel>
    </form>
</body>
</html>
