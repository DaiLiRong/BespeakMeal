<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" 
AutoEventWireup="true" CodeFile="MyOrder.aspx.cs" Inherits="MyOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentLeft" Runat="Server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentRight" Runat="Server">
    <asp:Panel ID="OrderListPanel" runat="server">
        <asp:DataList ID="OrderList" runat="server" CellPadding="4" ForeColor="#333333">
            <AlternatingItemStyle BackColor="White" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderTemplate>
            <table border="1">
                <td width="120"><span style="width:200px;">订单编号</span></td>
                <td width="130px"><span>下单时间</span></td>
                <td width="100px"><span style="width:100px">数量（件）</span></td>
                <td width="120px"><span style="width:150px;">总金额（元）</span></td>
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
                    <td width="120px">
                        <span style="font-size:large;color:Red;font-family:Tahoma">¥<%#Eval("Total")%></span></td>
                    <td width="100px">
                        <span style="font-size:large;color:Green;font-family:Tahoma "><%#Eval("Status")%></span></td>
                    <td width="100px">
                        <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" >查看>></asp:LinkButton>
                    </td>
                </tr>
            </table>
            </ItemTemplate>
            <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        </asp:DataList>
    </asp:Panel>
<div></div>
<asp:Panel ID="OrderDetailPanel" runat="server" Visible="False">
        <table>
            <tr>
                <td>
                    订单详细资料</td>
                <td>
                    <asp:LinkButton ID="LinkButton2" runat="server" 
                        style="font-weight: 700; font-size: large" onclick="LinkButton2_Click">返回&lt;&lt;</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    订单号：<asp:Label ID="OrderReferenceLabel" runat="server"></asp:Label>
                </td>
                <td>
                    下单时间：<asp:Label ID="OrderTimeLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    用户名：<asp:Label ID="UserNameLabel" runat="server"></asp:Label>
                </td>
                <td>
                    订单状态：<asp:Label ID="StatusLabel" runat="server"></asp:Label>
                    <asp:LinkButton ID="PayNowLink" runat="server" Visible="False" 
                        PostBackUrl="~/PayNow.aspx" onclick="PayNowLink_Click">去付款</asp:LinkButton>
                    <asp:LinkButton ID="CancelLink" runat="server" Visible="False" 
                        onclick="CancelLink_Click" OnClientClick="return confirm('亲，你真的要取消吗？');">取消订单</asp:LinkButton>
                    <asp:LinkButton ID="ConfirmLink" runat="server" Visible="False" 
                        onclick="ConfirmLink_Click" OnClientClick="return confirm('亲，你真的要确认吗？');">确认订单</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    菜单列表：</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        
    <asp:DataList ID="FoodList" runat="server">

       <HeaderTemplate>
            <table border="1">
                <td width="100"><span style="width:200px;">食物</span></td>
                <td width="130px"><span>名称</span></td>
                <td width="100px"><span style="width:100px">单价（元）</span></td>
                <td width="100px"><span style="width:150px;">数量（件）</span></td>
                <td width="100px"><span style="width:300px;">小计（元）</span></td>
            <table>
            </HeaderTemplate>

            <ItemStyle BackColor="#FFFBD6" ForeColor="#333333" />

            <ItemTemplate>
            <table border="1">
                </tr>
                <tr>

                    <td width="100">
                        <span style="width:500px; height: 50px;">
                        <img    alt= '<%#Eval("FoodName")%>'
                src='<%#string.Format("img/{0}.jpg ",Eval("FoodId").ToString().Replace("    "," "))%> '
                width= "45px" height="45px "/>
                        </span>
                    </td>
                    <td width="130px">
                        <span  style="font-family:Tahoma;color:Blue">
                        <%#Eval("FoodName")%></span>
                    </td>
                    <td width="100px">
                        <span style="font-size:large;color:Red;font-family:Tahoma">¥<%#Eval("FoodPrice")%></span></td>
                    <td width="100px">
                        <span>
                        <asp:Label ID="FoodNum" runat="server" Text='<%# Eval("FoodNum") %>' Width="40px"></asp:Label>

                        </span>
                    </td>
                    <td width="100px">
                        <span style="font-size:large;color:Red;font-family:Tahoma">¥<%#Eval("MoneyCount")%></span></td>
                </tr>
            </table>
            </ItemTemplate>


            <AlternatingItemStyle BackColor="White" />
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#7799FF" Font-Bold="true" ForeColor="White" />
            <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
    </asp:DataList>

    商品总价： 
    <asp:Label ID="Total" runat="server" Text="0"></asp:Label>元 

</asp:Panel>

</asp:Content>