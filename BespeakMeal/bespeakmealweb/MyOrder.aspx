<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyOrder.aspx.cs" Inherits="MyOrder" %>
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
        <div style="margin-left:100"><img src="1leBespeakMeal.jpg"/></div>

        <asp:DataList ID="OrderList" runat="server" CellPadding="4" ForeColor="#333333">
            <AlternatingItemStyle BackColor="White" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderTemplate>
            <table border="1">
                <td width="120"><span style="width:200px;">订单编号</span></td>
                <td width="130px"><span>下单时间</span></td>
                <td width="100px"><span style="width:100px">数量（件）</span></td>
                <td width="100px"><span style="width:150px;">总金额（元）</span></td>
                <td width="100px"><span style="width:60px;">订单状态</span></td>
                <td width="100px"><span style="width:60px;">操作</span></td>
            <table>
            </HeaderTemplate>

            <ItemStyle BackColor="#EFF3FB" />

            <ItemTemplate>
            <table border="1">
                </tr>
                <tr>
                    <td width="120px">
                        <span style="color:Fuchsia"><%#Eval("OrderReference")%>
                        </span>
                    </td>
                    <td width="130px">
                        <span style="font-family:Tahoma;color:Blue"><%#Eval("OrderTime")%></span>
                    </td>
                    <td width="100px">
                        <span style="font-size:large;color:Red;font-family:Tahoma"><%#Eval("FoodNum")%></span></td>
                    <td width="100px">
                        <span style="font-size:large;color:Red;font-family:Tahoma">¥<%#Eval("Total")%></span></td>
                    <td width="100px">
                        <span style="font-size:large;color:Red;font-family:Tahoma"><%#Eval("Status")%></span></td>
                    <td width="100px">
                        <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" >查看>></asp:LinkButton>
                    </td>
                </tr>
            </table>
            </ItemTemplate>
            <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        </asp:DataList>
    </center>
</form>
</body>
</html>
