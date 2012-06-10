<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SubmitOrder.aspx.cs" Inherits="SubmitOrder" %>
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
                .style1
                {
                    width:80%;
                }
                .style3
                {
                    width: 429px;
                }
                .style4
                {
                    width: 189px;
                    text-align: right;
                }
                .style5
                {
                    width: 189px;
                    height: 20px;
                    text-align: right;
                }
                .style6
                {
                    width: 429px;
                    height: 20px;
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
            <td class="style5">
                <strong>填写订单信息</strong></td>
            <td class="style6">
            </td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                地址：</td>
            <td class="style3">
                <asp:TextBox ID="AddressBox" runat="server" Width="300px" 
                    style="text-align: left"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4">
                电话：</td>
            <td class="style3">
                <asp:TextBox ID="PhoneNumBox" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4">
                其他要求：</td>
            <td class="style3">
                <asp:TextBox ID="OtherReqBox" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                <strong>确认商品信息</strong></td>
            <td class="style3">
                &nbsp;</td>
        </tr>
    </table>
       
    <UC2:Login ID="ProductCar1" runat="server" />
                <asp:ImageButton ID="ImageButton1" runat="server" Height="31px" 
                ImageUrl="~/img/queren.jpg" onclick="ImageButton1_Click" 
                 Width="114px" />
                </center>
    </form>
</body>
</html>
