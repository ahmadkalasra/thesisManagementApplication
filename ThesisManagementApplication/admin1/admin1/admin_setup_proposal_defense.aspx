<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="admin_setup_proposal_defense.aspx.cs" Inherits="admin1.admin_setup_proposal_defense" %>
<!DOCTYPE html>
<html lang="en">
<head>
  <title>Bootstrap Case</title>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <link href="Styles/jquery.datetimepicker.css" rel="stylesheet" />
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

.my11
{
    background-color:gainsboro;
}
.table-bordered td, .table-bordered th{
    border-color:	#989898 !important;
}
    </style>
    <link href="Styles/new0.css" rel="stylesheet" />
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
    <script type="text/javascript">
        $(document).ready(function() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

            function EndRequestHandler(sender, args) {
                $('#datetimepicker').datetimepicker({ dateTimeFormat: "yy-mm-dd HH:MM:SS" });
            }

        });
    </script>

    <script type="text/javascript">
        function pageLoad() {
            $(document).ready(function () {

                $("input:radio[name='RadioButtonList1']").click(function () {

                    var selectedRadio = $("input:radio[name='RadioButtonList1']:checked").val();

                    var dataValue = "{ name: 'person', isGoing: 'true', returnAddress: 'returnEmail' }";

                    var name = "Ahmad";
                    var age = 18;
                    if (selectedRadio == 1) {
                        $.ajax({
                            type: "POST",
                            url: "callback_template.asmx/GetDetails",
                            dataType: "json",
                            success: function (r) {
                                //var list = JsonConvert.DeserializeObject < List < string >> (r.d);
                                var resultAsJson = r.d // your return result is JS array
                                // Now you can loop over the array to get each object
                                $("#DropDownList2").get(0).options.length = 0;
                                $("#DropDownList2").get(0).options[0] = new Option("-- Select state --");

                                for (var i in resultAsJson) {
                                    var user = resultAsJson[i];
                                    $("#DropDownList2").get(0).options[$("#DropDownList2").get(0).options.length] = new Option(user);
                                    // Here you append that value to your label
                                }
                            },
                            error: function (r) {
                                var resultAsJson = r.responseText // your return result is JS array
                                // Now you can loop over the array to get each object
                                $("#DropDownList2").get(0).options.length = 0;
                                $("#DropDownList2").get(0).options[0] = new Option("-- Select Internal Examiner --");

                                var res = resultAsJson.split("\n");
                                for (var i in res) {
                                    var user = res[i];
                                    $("#DropDownList2").get(0).options[$("#DropDownList2").get(0).options.length] = new Option(user);
                                    // Here you append that value to your label
                                }
                            },
                            failure: function (r) {
                                alert(r.responseText);
                            }
                        });
                    }
                    else if (selectedRadio == 2) {
                        $.ajax({
                            type: "POST",
                            url: "callback_template.asmx/GetDetails2",
                            dataType: "json",
                            success: function (r) {
                                //var list = JsonConvert.DeserializeObject < List < string >> (r.d);
                                var resultAsJson = r.d // your return result is JS array
                                // Now you can loop over the array to get each object
                                $("#DropDownList2").get(0).options.length = 0;
                                $("#DropDownList2").get(0).options[0] = new Option("-- Select state --");

                                for (var i in resultAsJson) {
                                    var user = resultAsJson[i];
                                    $("#DropDownList2").get(0).options[$("#DropDownList2").get(0).options.length] = new Option(user);
                                    // Here you append that value to your label
                                }
                            },
                            error: function (r) {
                                var resultAsJson = r.responseText // your return result is JS array
                                // Now you can loop over the array to get each object
                                $("#DropDownList2").get(0).options.length = 0;
                                $("#DropDownList2").get(0).options[0] = new Option("-- Select External Examiner --");

                                var res = resultAsJson.split("\n");
                                for (var i in res) {
                                    var user = res[i];
                                    $("#DropDownList2").get(0).options[$("#DropDownList2").get(0).options.length] = new Option(user);
                                    // Here you append that value to your label
                                }
                            },
                            failure: function (r) {
                                alert(r.responseText);
                            }
                        });
                    }
                });

                $("#DropDownList2").bind("change", function () {
                    $('#' + '<%= DropDownList2.ClientID %>').val($(this).val());
                });
            });

            $(document).ready(function () {

                $("input:radio[name='RadioButtonList2']").click(function () {

                    var selectedRadio = $("input:radio[name='RadioButtonList2']:checked").val();

                    if (selectedRadio == 1) {
                        $.ajax({
                            type: "POST",
                            url: "callback_template.asmx/GetDetails",
                            dataType: "json",
                            success: function (r) {
                                //var list = JsonConvert.DeserializeObject < List < string >> (r.d);
                                var resultAsJson = r.d // your return result is JS array
                                // Now you can loop over the array to get each object
                                $("#DropDownList3").get(0).options.length = 0;
                                $("#DropDownList3").get(0).options[0] = new Option("-- Select Internal Examiner --");

                                for (var i in resultAsJson) {
                                    var user = resultAsJson[i];
                                    $("#DropDownList3").get(0).options[$("#DropDownList3").get(0).options.length] = new Option(user);
                                    // Here you append that value to your label
                                }
                            },
                            error: function (r) {

                                var resultAsJson = r.responseText // your return result is JS array
                                // Now you can loop over the array to get each object
                                $("#DropDownList3").get(0).options.length = 0;
                                $("#DropDownList3").get(0).options[0] = new Option("-- Select Internal Examiner --");

                                var res = resultAsJson.split("\n");
                                for (var i in res) {
                                    var user = res[i];
                                    $("#DropDownList3").get(0).options[$("#DropDownList3").get(0).options.length] = new Option(user);
                                    // Here you append that value to your label
                                }
                            },
                            failure: function (r) {
                                alert(r.responseText);
                            }
                        });
                    }
                    else if (selectedRadio == 2) {
                        $.ajax({
                            type: "POST",
                            url: "callback_template.asmx/GetDetails2",
                            dataType: "json",
                            success: function (r) {
                                //var list = JsonConvert.DeserializeObject < List < string >> (r.d);
                                var resultAsJson = r.d // your return result is JS array
                                // Now you can loop over the array to get each object
                                $("#DropDownList3").get(0).options.length = 0;
                                $("#DropDownList3").get(0).options[0] = new Option("-- Select External Examiner --");

                                for (var i in resultAsJson) {
                                    var user = resultAsJson[i];
                                    $("#DropDownList3").get(0).options[$("#DropDownList3").get(0).options.length] = new Option(user);
                                    // Here you append that value to your label
                                }
                            },
                            error: function (r) {

                                var resultAsJson = r.responseText // your return result is JS array
                                // Now you can loop over the array to get each object
                                $("#DropDownList3").get(0).options.length = 0;
                                $("#DropDownList3").get(0).options[0] = new Option("-- Select External Examiner --");

                                var res = resultAsJson.split("\n");
                                for (var i in res) {
                                    var user = res[i];
                                    $("#DropDownList3").get(0).options[$("#DropDownList3").get(0).options.length] = new Option(user);
                                    // Here you append that value to your label
                                }
                            },
                            failure: function (r) {
                                alert(r.responseText);
                            }
                        });
                    }


                });

                $("#DropDownList3").bind("change", function () {
                    $('#' + '<%= DropDownList3.ClientID %>').val($(this).val());
                });

            });



            //Update Panel Work Here

            $(document).ready(function () {

                $("input:radio[name='RadioButtonList3']").click(function () {

                    var selectedRadio = $("input:radio[name='RadioButtonList3']:checked").val();

                    var dataValue = "{ name: 'person', isGoing: 'true', returnAddress: 'returnEmail' }";

                    var name = "Ahmad";
                    var age = 18;
                    if (selectedRadio == 1) {
                        $.ajax({
                            type: "POST",
                            url: "callback_template.asmx/GetDetails",
                            dataType: "json",
                            success: function (r) {
                                //var list = JsonConvert.DeserializeObject < List < string >> (r.d);
                                var resultAsJson = r.d // your return result is JS array
                                // Now you can loop over the array to get each object
                                $("#DropDownList7").get(0).options.length = 0;
                                $("#DropDownList7").get(0).options[0] = new Option("-- Select state --");

                                for (var i in resultAsJson) {
                                    var user = resultAsJson[i];
                                    $("#DropDownList7").get(0).options[$("#DropDownList7").get(0).options.length] = new Option(user);
                                    // Here you append that value to your label
                                }
                            },
                            error: function (r) {
                                var resultAsJson = r.responseText // your return result is JS array
                                // Now you can loop over the array to get each object
                                $("#DropDownList7").get(0).options.length = 0;
                                $("#DropDownList7").get(0).options[0] = new Option("-- Select Internal Examiner --");

                                var res = resultAsJson.split("\n");
                                for (var i in res) {
                                    var user = res[i];
                                    $("#DropDownList7").get(0).options[$("#DropDownList7").get(0).options.length] = new Option(user);
                                    // Here you append that value to your label
                                }
                            },
                            failure: function (r) {
                                alert(r.responseText);
                            }
                        });
                    }
                    else if (selectedRadio == 2) {
                        $.ajax({
                            type: "POST",
                            url: "callback_template.asmx/GetDetails2",
                            dataType: "json",
                            success: function (r) {
                                //var list = JsonConvert.DeserializeObject < List < string >> (r.d);
                                var resultAsJson = r.d // your return result is JS array
                                // Now you can loop over the array to get each object
                                $("#DropDownList7").get(0).options.length = 0;
                                $("#DropDownList7").get(0).options[0] = new Option("-- Select state --");

                                for (var i in resultAsJson) {
                                    var user = resultAsJson[i];
                                    $("#DropDownList7").get(0).options[$("#DropDownList7").get(0).options.length] = new Option(user);
                                    // Here you append that value to your label
                                }
                            },
                            error: function (r) {
                                var resultAsJson = r.responseText // your return result is JS array
                                // Now you can loop over the array to get each object
                                $("#DropDownList7").get(0).options.length = 0;
                                $("#DropDownList7").get(0).options[0] = new Option("-- Select External Examiner --");

                                var res = resultAsJson.split("\n");
                                for (var i in res) {
                                    var user = res[i];
                                    $("#DropDownList7").get(0).options[$("#DropDownList7").get(0).options.length] = new Option(user);
                                    // Here you append that value to your label
                                }
                            },
                            failure: function (r) {
                                alert(r.responseText);
                            }
                        });
                    }
                });

                $("#DropDownList7").bind("change", function () {
                    $('#' + '<%= DropDownList7.ClientID %>').val($(this).val());
                });
            });

            $(document).ready(function () {

                $("input:radio[name='RadioButtonList4']").click(function () {

                    var selectedRadio = $("input:radio[name='RadioButtonList4']:checked").val();

                    if (selectedRadio == 1) {
                        $.ajax({
                            type: "POST",
                            url: "callback_template.asmx/GetDetails",
                            dataType: "json",
                            success: function (r) {
                                //var list = JsonConvert.DeserializeObject < List < string >> (r.d);
                                var resultAsJson = r.d // your return result is JS array
                                // Now you can loop over the array to get each object
                                $("#DropDownList8").get(0).options.length = 0;
                                $("#DropDownList8").get(0).options[0] = new Option("-- Select Internal Examiner --");

                                for (var i in resultAsJson) {
                                    var user = resultAsJson[i];
                                    $("#DropDownList8").get(0).options[$("#DropDownList8").get(0).options.length] = new Option(user);
                                    // Here you append that value to your label
                                }
                            },
                            error: function (r) {

                                var resultAsJson = r.responseText // your return result is JS array
                                // Now you can loop over the array to get each object
                                $("#DropDownList8").get(0).options.length = 0;
                                $("#DropDownList8").get(0).options[0] = new Option("-- Select Internal Examiner --");

                                var res = resultAsJson.split("\n");
                                for (var i in res) {
                                    var user = res[i];
                                    $("#DropDownList8").get(0).options[$("#DropDownList8").get(0).options.length] = new Option(user);
                                    // Here you append that value to your label
                                }
                            },
                            failure: function (r) {
                                alert(r.responseText);
                            }
                        });
                    }
                    else if (selectedRadio == 2) {
                        $.ajax({
                            type: "POST",
                            url: "callback_template.asmx/GetDetails2",
                            dataType: "json",
                            success: function (r) {
                                //var list = JsonConvert.DeserializeObject < List < string >> (r.d);
                                var resultAsJson = r.d // your return result is JS array
                                // Now you can loop over the array to get each object
                                $("#DropDownList8").get(0).options.length = 0;
                                $("#DropDownList8").get(0).options[0] = new Option("-- Select External Examiner --");

                                for (var i in resultAsJson) {
                                    var user = resultAsJson[i];
                                    $("#DropDownList8").get(0).options[$("#DropDownList8").get(0).options.length] = new Option(user);
                                    // Here you append that value to your label
                                }
                            },
                            error: function (r) {

                                var resultAsJson = r.responseText // your return result is JS array
                                // Now you can loop over the array to get each object
                                $("#DropDownList8").get(0).options.length = 0;
                                $("#DropDownList8").get(0).options[0] = new Option("-- Select External Examiner --");

                                var res = resultAsJson.split("\n");
                                for (var i in res) {
                                    var user = res[i];
                                    $("#DropDownList8").get(0).options[$("#DropDownList8").get(0).options.length] = new Option(user);
                                    // Here you append that value to your label
                                }
                            },
                            failure: function (r) {
                                alert(r.responseText);
                            }
                        });
                    }


                });

                $("#DropDownList8").bind("change", function () {
                    $('#' + '<%= DropDownList3.ClientID %>').val($(this).val());
                });

            });

            //update panel worl end here

            //Thesis Panel Work Here

            $(document).ready(function () {

                $("input:radio[name='RadioButtonList5']").click(function () {

                    var selectedRadio = $("input:radio[name='RadioButtonList5']:checked").val();

                    var dataValue = "{ name: 'person', isGoing: 'true', returnAddress: 'returnEmail' }";

                    var name = "Ahmad";
                    var age = 18;
                    if (selectedRadio == 1) {
                        $.ajax({
                            type: "POST",
                            url: "callback_template.asmx/GetDetails",
                            dataType: "json",
                            success: function (r) {
                                //var list = JsonConvert.DeserializeObject < List < string >> (r.d);
                                var resultAsJson = r.d // your return result is JS array
                                // Now you can loop over the array to get each object
                                $("#DropDownList11").get(0).options.length = 0;
                                $("#DropDownList11").get(0).options[0] = new Option("-- Select state --");

                                for (var i in resultAsJson) {
                                    var user = resultAsJson[i];
                                    $("#DropDownList11").get(0).options[$("#DropDownList11").get(0).options.length] = new Option(user);
                                    // Here you append that value to your label
                                }
                            },
                            error: function (r) {
                                var resultAsJson = r.responseText // your return result is JS array
                                // Now you can loop over the array to get each object
                                $("#DropDownList11").get(0).options.length = 0;
                                $("#DropDownList11").get(0).options[0] = new Option("-- Select Internal Examiner --");

                                var res = resultAsJson.split("\n");
                                for (var i in res) {
                                    var user = res[i];
                                    $("#DropDownList11").get(0).options[$("#DropDownList11").get(0).options.length] = new Option(user);
                                    // Here you append that value to your label
                                }
                            },
                            failure: function (r) {
                                alert(r.responseText);
                            }
                        });
                    }
                    else if (selectedRadio == 2) {
                        $.ajax({
                            type: "POST",
                            url: "callback_template.asmx/GetDetails2",
                            dataType: "json",
                            success: function (r) {
                                //var list = JsonConvert.DeserializeObject < List < string >> (r.d);
                                var resultAsJson = r.d // your return result is JS array
                                // Now you can loop over the array to get each object
                                $("#DropDownList11").get(0).options.length = 0;
                                $("#DropDownList11").get(0).options[0] = new Option("-- Select state --");

                                for (var i in resultAsJson) {
                                    var user = resultAsJson[i];
                                    $("#DropDownList11").get(0).options[$("#DropDownList11").get(0).options.length] = new Option(user);
                                    // Here you append that value to your label
                                }
                            },
                            error: function (r) {
                                var resultAsJson = r.responseText // your return result is JS array
                                // Now you can loop over the array to get each object
                                $("#DropDownList11").get(0).options.length = 0;
                                $("#DropDownList11").get(0).options[0] = new Option("-- Select External Examiner --");

                                var res = resultAsJson.split("\n");
                                for (var i in res) {
                                    var user = res[i];
                                    $("#DropDownList11").get(0).options[$("#DropDownList11").get(0).options.length] = new Option(user);
                                    // Here you append that value to your label
                                }
                            },
                            failure: function (r) {
                                alert(r.responseText);
                            }
                        });
                    }
                });

                $("#DropDownList11").bind("change", function () {
                    $('#' + '<%= DropDownList11.ClientID %>').val($(this).val());
                });
            });

            $(document).ready(function () {

                $("input:radio[name='RadioButtonList6']").click(function () {

                    var selectedRadio = $("input:radio[name='RadioButtonList6']:checked").val();

                    if (selectedRadio == 1) {
                        $.ajax({
                            type: "POST",
                            url: "callback_template.asmx/GetDetails",
                            dataType: "json",
                            success: function (r) {
                                //var list = JsonConvert.DeserializeObject < List < string >> (r.d);
                                var resultAsJson = r.d // your return result is JS array
                                // Now you can loop over the array to get each object
                                $("#DropDownList12").get(0).options.length = 0;
                                $("#DropDownList12").get(0).options[0] = new Option("-- Select Internal Examiner --");

                                for (var i in resultAsJson) {
                                    var user = resultAsJson[i];
                                    $("#DropDownList12").get(0).options[$("#DropDownList12").get(0).options.length] = new Option(user);
                                    // Here you append that value to your label
                                }
                            },
                            error: function (r) {

                                var resultAsJson = r.responseText // your return result is JS array
                                // Now you can loop over the array to get each object
                                $("#DropDownList12").get(0).options.length = 0;
                                $("#DropDownList12").get(0).options[0] = new Option("-- Select Internal Examiner --");

                                var res = resultAsJson.split("\n");
                                for (var i in res) {
                                    var user = res[i];
                                    $("#DropDownList12").get(0).options[$("#DropDownList12").get(0).options.length] = new Option(user);
                                    // Here you append that value to your label
                                }
                            },
                            failure: function (r) {
                                alert(r.responseText);
                            }
                        });
                    }
                    else if (selectedRadio == 2) {
                        $.ajax({
                            type: "POST",
                            url: "callback_template.asmx/GetDetails2",
                            dataType: "json",
                            success: function (r) {
                                //var list = JsonConvert.DeserializeObject < List < string >> (r.d);
                                var resultAsJson = r.d // your return result is JS array
                                // Now you can loop over the array to get each object
                                $("#DropDownList12").get(0).options.length = 0;
                                $("#DropDownList12").get(0).options[0] = new Option("-- Select External Examiner --");

                                for (var i in resultAsJson) {
                                    var user = resultAsJson[i];
                                    $("#DropDownList12").get(0).options[$("#DropDownList12").get(0).options.length] = new Option(user);
                                    // Here you append that value to your label
                                }
                            },
                            error: function (r) {

                                var resultAsJson = r.responseText // your return result is JS array
                                // Now you can loop over the array to get each object
                                $("#DropDownList12").get(0).options.length = 0;
                                $("#DropDownList12").get(0).options[0] = new Option("-- Select External Examiner --");

                                var res = resultAsJson.split("\n");
                                for (var i in res) {
                                    var user = res[i];
                                    $("#DropDownList12").get(0).options[$("#DropDownList12").get(0).options.length] = new Option(user);
                                    // Here you append that value to your label
                                }
                            },
                            failure: function (r) {
                                alert(r.responseText);
                            }
                        });
                    }


                });

                $("#DropDownList12").bind("change", function () {
                    $('#' + '<%= DropDownList12.ClientID %>').val($(this).val());
                });

            });

            //Thesis panel worl end here

        }


    </script>
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
        <a href="#" style="background-color:transparent;" id="dropd" class="dropdown-toggle" data-toggle="dropdown"> <span  class="glyphicon glyphicon-user icon-size"></span><asp:Literal ID="Literal6" runat="server" ></asp:Literal><span class="caret"></span></a>

                  <ul class="dropdown-menu pull-left" style="background-color:#7a8c74; border-color:#7a8c74; padding:0px; margin:0px;" role="menu">
                    <li class="hidden-sm hidden-xs" id="profpic"><a href="#" id="profpica" ><img src="img/pic.png" style="width:75px;height:75px; padding:10px;" /><br /><asp:Literal ID="Literal7" runat="server" ></asp:Literal><br /><span style="word-break:break-all;"><asp:Literal ID="Literal8" runat="server" ></asp:Literal></span></a></li>
                      <li><a href="admin_profile.aspx" id="dropbut">Profile</a></li>
                      <li><a href="admin-logout.aspx" id="dropbut">Sign Out</a></li>
                      

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
				
                <li class="lii" style="border-top-color:#616161; border-bottom-color:#7a8c74;"><a href="admin_profile.aspx" style="color:#fff;  width:inherit; height:inherit;"><span>Profile</span></a></li>
                <li class="lii" style="border-top-color:#7a8c74;border-bottom-color:#7a8c74;"><a href="admin_view_submitted_proposals.aspx" style="color:#fff;  width:inherit; height:inherit;"><span>Thesis</span></a></li>
				<li class="lii" style="border-top-color:#7a8c74;border-bottom-color:#7a8c74;"><a href="admin-frc-setup.aspx" style="color:#fff;  width:inherit; height:inherit;"><span>FRC-Setup</span></a></li>
            </ul>
		</div>
        
	</div>
    
</nav>
<div class="container-fluid" style="padding-top:30px; height:100%; overflow:auto;">
 <form runat="server">
     <h3 class="page-header"><span class="glyphicon glyphicon-book"></span> Research Proposal Info</h3>

<asp:Panel ID="Panel1" runat="server">
  <table class="table table-bordered" >
            <tbody >
    <tr  class="my11">
      <th >Enrollment</th>   
        <td ><asp:Literal ID="enrollment" runat="server" ></asp:Literal></td> 
      <th>Student Name</th>
        <td><asp:Literal ID="name" runat="server" ></asp:Literal></td>
        <td><asp:Literal ID="program" runat="server" ></asp:Literal></td>

    </tr> 
                <tr>
      <th >Project Title</th>   
        <td><asp:Literal ID="research_area" runat="server" ></asp:Literal></td> 
        <td><asp:LinkButton runat="server" OnClick="btnDownload_Click"  Text="Download"/></td>  
      <th>Status</th>
        <td><asp:Literal ID="approval_status" runat="server" ></asp:Literal></td>

    </tr>
    <tr  class="my11">
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
     
     <!-- Proposal Defense Details -->
        <asp:Panel ID="Panel16" runat="server">

        <h3 class="page-header"><span class="glyphicon glyphicon-book"></span> Proposal Defense Details</h3>
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

     <!-- Thesis Details -->
        <asp:Panel ID="Panel17" runat="server">

        <h3 class="page-header"><span class="glyphicon glyphicon-book"></span> Thesis Info</h3>
        <table class="table table-bordered"  >
            <tbody >
    <tr  class="my11">
      <th>Thesis File</th>   
        <td><asp:LinkButton runat="server" OnClick="thesis_Click_1"  Text="Download"/></td> 
      <th>Submission Date</th>
        <td><asp:Literal ID="Literal10" runat="server" ></asp:Literal></td>
      <th>Status</th>
        <td><asp:Literal ID="Literal11" runat="server" ></asp:Literal></td>

    </tr>
                
  
  </tbody>
</table>
         </asp:Panel>
     <!-- Thesis Details -->

     <!-- Thesis Defense Details -->
        <asp:Panel ID="Panel19" runat="server">

        <h3 class="page-header"><span class="glyphicon glyphicon-book"></span> Thesis Defense Details</h3>
        <table class="table table-bordered"  >
            <tbody >
    <tr  class="my11">
      <th>Defense Date</th>   
        <td><asp:Literal ID="Literal9" runat="server" ></asp:Literal></td> 
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



     <asp:ScriptManager runat="server" ID="sm">
 </asp:ScriptManager>
     <asp:Panel ID="Panel8" runat="server">
<h3 class="page-header"><div style="text-align:center;">Setup </div> </h3> 
     
 <asp:updatepanel  runat="server">
 <ContentTemplate>
     <div class="row">
  <label class="col-md-4 control-label" for="selectbasic" style="text-align:right;padding-top:5px;">Select FRC Approval</label>
  <div class="col-md-4">
    <asp:DropDownList ID="DropDownList1" class="form-control input-md" runat="server"></asp:DropDownList>
      <asp:Panel ID="Panel4" runat="server"><span style="color:red;">*Please Select FRC Approval <b>!</b></span></asp:Panel>
  </div>
         
</div><br />
<div class="row">
<label class="col-md-4 control-label" for="fn" style="padding-top:5px;text-align:right;">Select Date/Time</label>
<div class="col-md-4"> 
    <asp:TextBox ID="datetimepicker" name="fn" placeholder="Select Date Time" style="background:url('../img/calendar.png') no-repeat Right; cursor:pointer;" class="form-control input-md" runat="server"></asp:TextBox>
<asp:Panel ID="Panel3" runat="server"><span style="color:red;">*Please Select Date/Time <b>!</b></span></asp:Panel>
</div>
    
</div><br />

 <div class="row">
  <label class="col-md-4 control-label" for="selectroom" style="padding-top:5px;text-align:right;">Select Class Room</label>
  <div class="col-md-4">
    <asp:DropDownList ID="DropDownList4" class="form-control input-md" runat="server">
        <asp:ListItem Text="-- Select Class --" Value="0"></asp:ListItem>
        <asp:ListItem Text="XC-01" Value="1"></asp:ListItem>
        <asp:ListItem Text="XC-02" Value="2"></asp:ListItem>
        <asp:ListItem Text="XC-03" Value="3"></asp:ListItem>
        <asp:ListItem Text="XC-04" Value="4"></asp:ListItem>
        <asp:ListItem Text="XC-05" Value="5"></asp:ListItem>
      </asp:DropDownList>
      <asp:Panel ID="Panel5" runat="server"><span style="color:red;">*Please Select Class Room <b>!</b></span></asp:Panel>
  </div>
</div><br />
 <div class="row">
  <label class="col-md-4 control-label" for="selectbasic" style="padding-top:5px;text-align:right;">Examiner 1</label>
  <div class="col-md-4">
      <asp:DropDownList ID="DropDownList2" class="form-control input-md" runat="server">

      </asp:DropDownList>
      <asp:Panel ID="Panel6" runat="server"><span style="color:red;">*Please Select Examiner <b>!</b></span></asp:Panel>
      <span>
          <asp:RadioButtonList ID="RadioButtonList1"   RepeatDirection="Horizontal" runat="server" >
              <asp:ListItem  Text="Internal&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp" Value="1" > </asp:ListItem>
              <asp:ListItem Text="External" Value="2"></asp:ListItem>
          </asp:RadioButtonList>
      </span>

  </div>
</div><br />
 <div class="row">
  <label class="col-md-4 control-label" for="selectbasic" style="padding-top:5px;text-align:right;">Examiner 2</label>
  <div class="col-md-4">
    <asp:DropDownList ID="DropDownList3" class="form-control input-md" runat="server">

      </asp:DropDownList>
      <asp:Panel ID="Panel7" runat="server"><span style="color:red;">*Please Select Examiner <b>!</b></span></asp:Panel>
      <span>
          <asp:Panel ID="Panel2" runat="server">
          <asp:RadioButtonList ID="RadioButtonList2"   RepeatDirection="Horizontal" runat="server">
              <asp:ListItem Value="1">Internal &nbsp&nbsp&nbsp </asp:ListItem>
              <asp:ListItem Value="2">External</asp:ListItem>
              
          </asp:RadioButtonList></asp:Panel>
      </span>
  </div>
</div>
     <br />


<div class="row">
  <label class="col-md-4 control-label" for="submit"></label>
  <div class="col-md-4">
      <asp:Button ID="Button1"     class="btn btn-primary" PostBackUrl="~/admin_setup_proposal_defense.aspx"  OnClick="submit_click" runat="server" Text="Submit" />
  </div>
</div>
     </ContentTemplate>
     <Triggers>
       <asp:PostBackTrigger ControlID = "DropDownList2" />
        <asp:PostBackTrigger ControlID = "DropDownList3" />
    </Triggers>

     </asp:updatepanel>
     <br />
         </asp:Panel>

     <!-- Update Setup Defense Panel -->


          <asp:Panel ID="Panel9" runat="server">
<h3 class="page-header"><div style="text-align:center;">Update Proposal Defense Setup </div> </h3> 
     
 <asp:updatepanel  runat="server">
 <ContentTemplate>
     <div class="row">
  <label class="col-md-4 control-label" for="selectbasic" style="text-align:right;padding-top:5px;">Select FRC Approval</label>
  <div class="col-md-4">
    <asp:DropDownList ID="DropDownList5" class="form-control input-md" runat="server"></asp:DropDownList>
      <asp:Panel ID="Panel10" runat="server"><span style="color:red;">*Please Select FRC Approval <b>!</b></span></asp:Panel>
  </div>
         
</div><br />
<div class="row">
<label class="col-md-4 control-label" for="fn" style="padding-top:5px;text-align:right;">Select Date/Time</label>
<div class="col-md-4"> 
    <asp:TextBox ID="datetimepicker2" name="fn" placeholder="Select Date Time" style="background:url('../img/calendar.png') no-repeat Right; cursor:pointer;" class="form-control input-md" runat="server"></asp:TextBox>
<asp:Panel ID="Panel11" runat="server"><span style="color:red;">*Please Select Date/Time <b>!</b></span></asp:Panel>
</div>
    
</div><br />

 <div class="row">
  <label class="col-md-4 control-label" for="selectroom" style="padding-top:5px;text-align:right;">Select Class Room</label>
  <div class="col-md-4">
    <asp:DropDownList ID="DropDownList6" class="form-control input-md" runat="server">
        <asp:ListItem Text="-- Select Class --" Value="0"></asp:ListItem>
        <asp:ListItem Text="XC-01" Value="1"></asp:ListItem>
        <asp:ListItem Text="XC-02" Value="2"></asp:ListItem>
        <asp:ListItem Text="XC-03" Value="3"></asp:ListItem>
        <asp:ListItem Text="XC-04" Value="4"></asp:ListItem>
        <asp:ListItem Text="XC-05" Value="5"></asp:ListItem>
      </asp:DropDownList>
      <asp:Panel ID="Panel12" runat="server"><span style="color:red;">*Please Select Class Room <b>!</b></span></asp:Panel>
  </div>
</div><br />
 <div class="row">
  <label class="col-md-4 control-label" for="selectbasic" style="padding-top:5px;text-align:right;">Examiner 1</label>
  <div class="col-md-4">
      <asp:DropDownList ID="DropDownList7" class="form-control input-md" runat="server">

      </asp:DropDownList>
      <asp:Panel ID="Panel13" runat="server"><span style="color:red;">*Please Select Examiner <b>!</b></span></asp:Panel>
      <span>
          <asp:RadioButtonList ID="RadioButtonList3"   RepeatDirection="Horizontal" runat="server" >
              <asp:ListItem  Text="Internal&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp" Value="1" > </asp:ListItem>
              <asp:ListItem Text="External" Value="2"></asp:ListItem>
          </asp:RadioButtonList>
      </span>

  </div>
</div><br />
 <div class="row">
  <label class="col-md-4 control-label" for="selectbasic" style="padding-top:5px;text-align:right;">Examiner 2</label>
  <div class="col-md-4">
    <asp:DropDownList ID="DropDownList8" class="form-control input-md" runat="server">

      </asp:DropDownList>
      <asp:Panel ID="Panel14" runat="server"><span style="color:red;">*Please Select Examiner <b>!</b></span></asp:Panel>
      <span>
          <asp:Panel ID="Panel15" runat="server">
          <asp:RadioButtonList ID="RadioButtonList4"   RepeatDirection="Horizontal" runat="server">
              <asp:ListItem Value="1">Internal &nbsp&nbsp&nbsp </asp:ListItem>
              <asp:ListItem Value="2">External</asp:ListItem>
              
          </asp:RadioButtonList></asp:Panel>
      </span>
  </div>
</div>
     <br />


<div class="row">
  <label class="col-md-4 control-label" for="submit"></label>
  <div class="col-md-4">
      <asp:Button ID="Button2"     class="btn btn-primary" PostBackUrl="~/admin_setup_proposal_defense.aspx"  OnClick="update_click" runat="server" Text="Submit" />
  </div>
</div>
     </ContentTemplate>
     <Triggers>
       <asp:PostBackTrigger ControlID = "DropDownList2" />
        <asp:PostBackTrigger ControlID = "DropDownList3" />
    </Triggers>

     </asp:updatepanel>
     <br />
         </asp:Panel>

     <!-- Thesis Defense Setup -->

     
     <asp:Panel ID="Panel18" runat="server">
<h3 class="page-header"><div style="text-align:center;">Setup Thesis Defense</div> </h3> 
     
 <asp:updatepanel  runat="server">
 <ContentTemplate>
     
<div class="row">
<label class="col-md-4 control-label" for="fn" style="padding-top:5px;text-align:right;">Select Date/Time</label>
<div class="col-md-4"> 
    <asp:TextBox ID="TextBox1" name="fn" placeholder="Select Date Time" style="background:url('../img/calendar.png') no-repeat Right; cursor:pointer;" class="form-control input-md" runat="server"></asp:TextBox>
<asp:Panel ID="Panel20" runat="server"><span style="color:red;">*Please Select Date/Time <b>!</b></span></asp:Panel>
</div>
    
</div><br />

 <div class="row">
  <label class="col-md-4 control-label" for="selectroom" style="padding-top:5px;text-align:right;">Select Class Room</label>
  <div class="col-md-4">
    <asp:DropDownList ID="DropDownList10" class="form-control input-md" runat="server">
        <asp:ListItem Text="-- Select Class --" Value="0"></asp:ListItem>
        <asp:ListItem Text="XC-01" Value="1"></asp:ListItem>
        <asp:ListItem Text="XC-02" Value="2"></asp:ListItem>
        <asp:ListItem Text="XC-03" Value="3"></asp:ListItem>
        <asp:ListItem Text="XC-04" Value="4"></asp:ListItem>
        <asp:ListItem Text="XC-05" Value="5"></asp:ListItem>
      </asp:DropDownList>
      <asp:Panel ID="Panel21" runat="server"><span style="color:red;">*Please Select Class Room <b>!</b></span></asp:Panel>
  </div>
</div><br />
 <div class="row">
  <label class="col-md-4 control-label" for="selectbasic" style="padding-top:5px;text-align:right;">Examiner 1</label>
  <div class="col-md-4">
      <asp:DropDownList ID="DropDownList11" class="form-control input-md" runat="server">

      </asp:DropDownList>
      <asp:Panel ID="Panel22" runat="server"><span style="color:red;">*Please Select Examiner <b>!</b></span></asp:Panel>
      <span>
          <asp:RadioButtonList ID="RadioButtonList5"   RepeatDirection="Horizontal" runat="server" >
              <asp:ListItem  Text="Internal&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp" Value="1" > </asp:ListItem>
              <asp:ListItem Text="External" Value="2"></asp:ListItem>
          </asp:RadioButtonList>
      </span>

  </div>
</div><br />
 <div class="row">
  <label class="col-md-4 control-label" for="selectbasic" style="padding-top:5px;text-align:right;">Examiner 2</label>
  <div class="col-md-4">
    <asp:DropDownList ID="DropDownList12" class="form-control input-md" runat="server">

      </asp:DropDownList>
      <asp:Panel ID="Panel23" runat="server"><span style="color:red;">*Please Select Examiner <b>!</b></span></asp:Panel>
      <span>
          <asp:Panel ID="Panel24" runat="server">
          <asp:RadioButtonList ID="RadioButtonList6"   RepeatDirection="Horizontal" runat="server">
              <asp:ListItem Value="1">Internal &nbsp&nbsp&nbsp </asp:ListItem>
              <asp:ListItem Value="2">External</asp:ListItem>
              
          </asp:RadioButtonList></asp:Panel>
      </span>
  </div>
</div>
     <br />


<div class="row">
  <label class="col-md-4 control-label" for="submit"></label>
  <div class="col-md-4">
      <asp:Button ID="Button3"     class="btn btn-primary" PostBackUrl="~/admin_setup_proposal_defense.aspx"  OnClick="setup_thesis_defense" runat="server" Text="Submit" />
  </div>
</div>
     </ContentTemplate>
     <Triggers>
       <asp:PostBackTrigger ControlID = "DropDownList2" />
        <asp:PostBackTrigger ControlID = "DropDownList3" />
    </Triggers>

     </asp:updatepanel>
     <br />
         </asp:Panel>
 </form>

   <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    
    <script src="Scripts/jquery.datetimepicker.full.js" type="text/javascript"></script>
      <script>
          $("#datetimepicker").datetimepicker();
          $("#datetimepicker2").datetimepicker();
          $("#TextBox1").datetimepicker();
          
            </script> 
</div>
    </div>

</body>
</html>


