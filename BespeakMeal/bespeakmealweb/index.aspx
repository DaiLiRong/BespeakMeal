<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<%@ Register Src="IndexModule\Login.ascx" TagName="Login" TagPrefix="UC1" %>
<%@ Register Src="IndexModule\Classify.ascx" TagName="Classify" TagPrefix="UC2" %>
<%@ Register Src="IndexModule\FoodList.ascx" TagName="FoodList" TagPrefix="UC3" %>

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

<form runat="server">
<center>

<UC1:Login ID="Login1" runat="server" />

    <div style="margin-left:100"><img alt="一乐订餐" src="1leBespeakMeal.jpg"/></div>
    <table border="1" runat="server">

        <tr style="margin-top:0">
            <td style="width:auto; caption-side:top">
                <UC2:Classify ID="Classify" runat="server" />
            </td>
            <td style="width:auto">
                <UC3:FoodList ID="FoodList1" runat="server" />
            </td>
        </tr>
    </table>
</center>
</form>
</body>
</html>
