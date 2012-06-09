<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductCarShow.aspx.cs" Inherits="ProductCarShow" %>
<%@ Register Src="IndexModule\Login.ascx" TagName="Login" TagPrefix="UC1" %>
<%@ Register Src="IndexModule\ProductCar.ascx" TagName="Login" TagPrefix="UC2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <style type="text/css"> body { 
        background-attachment:fixed; 
        background-color:#FFFF66; 
        background-image:url(bg.jpg); 
        background-position:center; 
        background-repeat:no-repeat; 
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <center>
        <UC1:Login ID="Login1" runat="server" />
        <UC2:Login ID="ProductCar1" runat="server" />

    </form>
</body>
</html>
