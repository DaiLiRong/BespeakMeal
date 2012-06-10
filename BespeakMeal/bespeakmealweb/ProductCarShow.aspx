<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductCarShow.aspx.cs" Inherits="ProductCarShow" %>
<%@ Register Src="IndexModule\Login.ascx" TagName="Login" TagPrefix="UC1" %>
<%@ Register Src="IndexModule\ProductCar.ascx" TagName="ProductCar" TagPrefix="UC2" %>
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
        <div style="margin-left:100"><img src="1leBespeakMeal.jpg"/></div>
        <UC2:ProductCar ID="ProductCar1" runat="server" />
        <asp:Panel ID="Panel1" runat="server" Visible="False">
            <!-- E 商品列表 --> 
            <!-- S 购物车为空并且用户登录 -->
            <div>
                <h3>您的购物车还是空的。</h3>
                <p> 您还没有添加任何商品。马上去<a href="index.aspx">挑选商品</a>看看。</p>
            </div>
        </asp:Panel>
 <table class="style1">
    <tr>
        <td>
            <asp:ImageButton ID="ImageButton1" runat="server" Height="31px" 
                ImageUrl="~/img/buynow.jpg" onclick="ImageButton1_Click" 
                PostBackUrl="~/SubmitOrder.aspx" Width="114px" />
        </td>
    </tr>
</table>


    </form>
</body>
</html>
