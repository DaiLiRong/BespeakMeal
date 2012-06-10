<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Pay.aspx.cs" Inherits="Pay" %>
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
        .style1
        {
            width: 80%;
        }
        .style2
        {
            width: 334px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <center>
        <UC1:Login ID="Login1" runat="server" />
        <div style="margin-left:100"><img alt="一乐订餐" src="1leBespeakMeal.jpg"/></div>
        <table class="style1">
            <tr>
                <td class="style2">
        订单提交成功！</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
        <asp:ImageButton ID="ImageButton1" runat="server" Height="31px" 
                ImageUrl="~/img/Pay.jpg" onclick="ImageButton1_Click" 
                PostBackUrl="~/PayNow.aspx" Width="114px" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        </center>
    </form>
</body>
</html>
