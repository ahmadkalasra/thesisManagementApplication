<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Short URL</title>
    
    <style type="text/css">
        body                    {margin:0; padding:0; background-color:#EBE7E0; font-family:"Lucida Grande", "Corbel", Arial; text-align:center;}
        #container          {width:600px; margin:0 auto;}
        #container div         {padding:15px; background-color:#C6D4E1; border:solid 1px #44749D; text-align:center; margin-bottom:20px;}
        input               {padding:10px; font-size:160%;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    
    <div id="container">
    
        <h1><asp:Label ID="lblDomainName" runat="server" /></h1>
    
        <div>
            <asp:TextBox ID="txtRealUrl" runat="server" />
            <asp:Button ID="btnSubmit" runat="server" Text="Create Short URL" OnClick="GenerateShortUrl" />
        </div>
    
        <div>
            Your new shortened URL is :
            <asp:HyperLink ID="lnkShortUrl" runat="server" Font-Bold="true" />
        </div>
    
    </div>
    
    </form>
</body>
</html>
