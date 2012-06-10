<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PayNow.aspx.cs" Inherits="IndexModule_PayNow" %>
<%@ Register Src="IndexModule\Login.ascx" TagName="Login" TagPrefix="UC1" %>

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
        <div style="margin-left:100"><img alt="一乐订餐" src="1leBespeakMeal.jpg"/></div>
        <h5 >支持以下银行机构在线支付，订单提交后即可选择：</h5>
        <div><img alt="支付银行" src="img\pic_bank.jpg"/></div>
    </center>


    </form>
</body>
</html>
