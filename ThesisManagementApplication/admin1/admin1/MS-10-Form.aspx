<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MS-10-Form.aspx.cs" Inherits="admin1.MS_10_Form" %>

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
            <span  class="main4">Proposal Title of Research: <span class="main5"><asp:Literal ID="Literal5"  runat="server" ></asp:Literal></span></span><hr />
            </div>
                <div class="main6">
                Assignment Report
                    
                <br />
                    <asp:Panel ID="Panel28" runat="server"><span style="color:red;">*Please Fill this form or upload scanned copy <b>!</b></span></asp:Panel>
                    
                <table class="table table-bordered" id="main7">
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
                <th class="col-xs-2">
                    <asp:TextBox CssClass="main8" ID="TextBox1" onkeypress="pageLoad(event);" onkeyup="CountMe(this.value);" runat="server"></asp:TextBox>
                    <asp:Panel ID="Panel2" runat="server"><span style="color:red;">*Please Enter Marks <b>!</b></span></asp:Panel>
                    <asp:Panel ID="Panel3" runat="server"><span style="color:red;">*Must be less than 3 <b>!</b></span></asp:Panel>
                </th>
            </tr>
            <tr>
                <td class="col-xs-5">Depth</td>
                <th class="col-xs-2">
                    <asp:TextBox CssClass="main8" ID="TextBox2" onkeypress="pageLoad(event);" onkeyup="CountMe(this.value);" runat="server"></asp:TextBox>
                    <asp:Panel ID="Panel4" runat="server"><span style="color:red;">*Please Enter Marks <b>!</b></span></asp:Panel>
                    <asp:Panel ID="Panel5" runat="server"><span style="color:red;">*Must be less than 3 <b>!</b></span></asp:Panel>
                </th>
            </tr>
            <tr>
                <td class="col-xs-5">Justification w.r.t degree program and background Study</td>
                <th class="col-xs-2">
                    <asp:TextBox CssClass="main8" ID="TextBox3" onkeypress="pageLoad(event);" onkeyup="CountMe(this.value);" runat="server"></asp:TextBox>
                    <asp:Panel ID="Panel6" runat="server"><span style="color:red;">*Please Enter Marks <b>!</b></span></asp:Panel>
                    <asp:Panel ID="Panel7" runat="server"><span style="color:red;">*Must be less than 3 <b>!</b></span></asp:Panel>
                </th>
            </tr>
             <tr>
                <th class="col-xs-5">(2) Quality of witten proposal:</th>
                <th class="col-xs-2"></th>
            </tr>
            <tr>
                <td class="col-xs-5">All essential elements (topic, literature review, problem defination, etc)</td>
                <th class="col-xs-2">
                    <asp:TextBox CssClass="main8" ID="TextBox4" onkeypress="pageLoad(event);" onkeyup="CountMe(this.value);" runat="server"></asp:TextBox>
                    <asp:Panel ID="Panel8" runat="server"><span style="color:red;">*Please Enter Marks <b>!</b></span></asp:Panel>
                    <asp:Panel ID="Panel9" runat="server"><span style="color:red;">*Must be less than 3 <b>!</b></span></asp:Panel>
                </th>
            </tr>
            <tr>
                <td class="col-xs-5">Studying write-up</td>
                <th class="col-xs-2">
                    <asp:TextBox CssClass="main8" ID="TextBox5" onkeypress="pageLoad(event);" onkeyup="CountMe(this.value);" runat="server"></asp:TextBox>
                    <asp:Panel ID="Panel10" runat="server"><span style="color:red;">*Please Enter Marks <b>!</b></span></asp:Panel>
                    <asp:Panel ID="Panel11" runat="server"><span style="color:red;">*Must be less than 3 <b>!</b></span></asp:Panel>
                </th>
            </tr>
            <tr>
                <th class="col-xs-5">(3) Comprehension of subject matter:</th>
                <th class="col-xs-2"></th>
            </tr>
            <tr>
                <td class="col-xs-5">Knowledge of background literature</td>
                <th class="col-xs-2">
                    <asp:TextBox CssClass="main8" ID="TextBox6" onkeypress="pageLoad(event);" onkeyup="CountMe(this.value);" runat="server"></asp:TextBox>
                    <asp:Panel ID="Panel12" runat="server"><span style="color:red;">*Please Enter Marks <b>!</b></span></asp:Panel>
                    <asp:Panel ID="Panel13" runat="server"><span style="color:red;">*Must be less than 3 <b>!</b></span></asp:Panel>
                </th>
            </tr>
            <tr>
                <td class="col-xs-5">Ability to form a hypothesis and objective</td>
                <th class="col-xs-2">
                    <asp:TextBox CssClass="main8" ID="TextBox7" onkeypress="pageLoad(event);" onkeyup="CountMe(this.value);" runat="server"></asp:TextBox>
                    <asp:Panel ID="Panel14" runat="server"><span style="color:red;">*Please Enter Marks <b>!</b></span></asp:Panel>
                    <asp:Panel ID="Panel15" runat="server"><span style="color:red;">*Must be less than 3 <b>!</b></span></asp:Panel>
                </th>
            </tr>
             <tr>
                <th class="col-xs-5">(4) Knowledge of Method:</th>
                <th class="col-xs-2"></th>
            </tr>
             <tr>
                <td class="col-xs-5">Methodology of work presented with intelligibility</td>
                <th class="col-xs-2">
                    <asp:TextBox CssClass="main8" ID="TextBox8" onkeypress="pageLoad(event);" onkeyup="CountMe(this.value);" runat="server"></asp:TextBox>
                    <asp:Panel ID="Panel16" runat="server"><span style="color:red;">*Please Enter Marks <b>!</b></span></asp:Panel>
                    <asp:Panel ID="Panel17" runat="server"><span style="color:red;">*Must be less than 3 <b>!</b></span></asp:Panel>
                </th>
            </tr>
             <tr>
                <td class="col-xs-5">Awareness of mordern hardware/sofware tools</td>
                <th class="col-xs-2">
                    <asp:TextBox CssClass="main8" ID="TextBox9" onkeypress="pageLoad(event);" onkeyup="CountMe(this.value);" runat="server"></asp:TextBox>
                    <asp:Panel ID="Panel18" runat="server"><span style="color:red;">*Please Enter Marks <b>!</b></span></asp:Panel>
                    <asp:Panel ID="Panel19" runat="server"><span style="color:red;">*Must be less than 3 <b>!</b></span></asp:Panel>
                </th>
            </tr>
             <tr>
                <th class="col-xs-5">(5) Presentation of Proposal:</th>
                <th class="col-xs-2"></th>
            </tr>
             <tr>
                <td class="col-xs-5">Demonstration of professionalism</td>
                <th class="col-xs-2">
                    <asp:TextBox CssClass="main8" ID="TextBox10" onkeypress="pageLoad(event);" onkeyup="CountMe(this.value);" runat="server"></asp:TextBox>
                    <asp:Panel ID="Panel20" runat="server"><span style="color:red;">*Please Enter Marks <b>!</b></span></asp:Panel>
                    <asp:Panel ID="Panel21" runat="server"><span style="color:red;">*Must be less than 3 <b>!</b></span></asp:Panel>
                </th>
            </tr>
             <tr>
                <td class="col-xs-5">Level of Confidence</td>
                <th class="col-xs-2">
                    <asp:TextBox CssClass="main8" ID="TextBox11" onkeypress="pageLoad(event);" onkeyup="CountMe(this.value);" runat="server"></asp:TextBox>
                    <asp:Panel ID="Panel22" runat="server"><span style="color:red;">*Please Enter Marks <b>!</b></span></asp:Panel>
                    <asp:Panel ID="Panel23" runat="server"><span style="color:red;">*Must be less than 3 <b>!</b></span></asp:Panel>
                </th>
            </tr>
             <tr>
                <td class="col-xs-5">Answers to questions</td>
                <th class="col-xs-2">
                    <asp:TextBox CssClass="main8" ID="TextBox12" onkeypress="pageLoad(event);" onkeyup="CountMe(this.value);" runat="server"></asp:TextBox>
                    <asp:Panel ID="Panel24" runat="server"><span style="color:red;">*Please Enter Marks <b>!</b></span></asp:Panel>
                    <asp:Panel ID="Panel25" runat="server"><span style="color:red;">*Must be less than 3 <b>!</b></span></asp:Panel>
                </th>
            </tr>
            <tr>
                <th class="col-xs-8" style="text-align:right"> Total(out of 36)</th>
                <th class="col-xs-2">
                    <!--<asp:TextBox CssClass="main8" ID="TextBox13" onkeypress="pageLoad(event);" onkeyup="CountMe(this.value);" runat="server"></asp:TextBox>-->
                    <span id="sum"  runat="server">0.00</span>
                    <asp:Panel ID="Panel26" runat="server"><span style="color:red;">*Please Enter Marks <b>!</b></span></asp:Panel>
                    <asp:Panel ID="Panel27" runat="server"><span style="color:red;">*Must be less than 3 <b>!</b></span></asp:Panel>
                </th>
            </tr>
            
            
    
  </tbody>
</table>
                <div class="main9">
                    Minimum Pass Score (60%)
                </div>
            </div>
            <div class="main10">
                <span class="main11">Based on my above assessment: (please initial the appropriate box) </span><br />
                <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                    <asp:ListItem Text="&nbsp I recommend the research proposal." Value="1"></asp:ListItem>
                    <asp:ListItem Text="&nbsp I recommend the research proposal but suggest modifying the topic/title." Value="2"></asp:ListItem>
                    <asp:ListItem Text="&nbsp I am not convinced and do not recommend the research proposal." Value="3"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="main12">
                <div class="row">
                    <span class="main11">Comments</span>
                </div>
                <div class="row">
                    <textarea id="TextArea1" class="main13" cols="20" rows="2" runat="server"></textarea>

                </div>
            </div>
            <div class="main14">
            <span  class="main4">Expert Name: <span class="main5"><asp:Literal ID="Literal6"  runat="server" >Dr. Muhammd Muzammal </asp:Literal></span></span><br />
            <asp:Panel ID="Panel32" runat="server">
                <span  class="main4">Signature: <span class="main5"><asp:Literal ID="Literal8"  runat="server" >Name </asp:Literal></span></span><br />
            </asp:Panel>
                <span  class="main4">Date: <span class="main5"><asp:Literal ID="Literal7"  runat="server" >24-03-2017</asp:Literal></span></span><hr />
            
            </div>
            <asp:Panel ID="Panel31" runat="server">
            <div class="main14">
                <span class="main4">
                    Please Upload Scan PDF of Manual evaluation form-<b>( Optional )</b>
                </span><br />
                <span class="btn btn-default btn-file">
                    <asp:FileUpload ID="FileUpload1" style="outline:none;" runat="server" accept="application/pdf" />
                </span>
            </div>
            </asp:Panel>
            <div class="main15">
                
                    <asp:Button ID="submit" runat="server" Text="Submit" OnClick="submit_form" class="btn btn-primary" />
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
