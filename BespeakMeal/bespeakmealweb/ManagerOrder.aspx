<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManagerOrder.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeft" Runat="Server">

    <asp:Menu ID="Menu1" runat="server" onmenuitemclick="Menu1_MenuItemClick">
        <Items>
            <asp:MenuItem Text="菜单管理" Value="菜单管理" NavigateUrl="~/ManagerFood.aspx"></asp:MenuItem>
            <asp:MenuItem Text="订单管理" Value="4" NavigateUrl="~/ManagerOrder.aspx">
                <asp:MenuItem Text="所有订单" Value="所有订单"></asp:MenuItem>
                <asp:MenuItem Text="交易成功" Value="4"></asp:MenuItem>
                <asp:MenuItem Text="正在送" Value="3"></asp:MenuItem>
                <asp:MenuItem Text="已付款" Value="2"></asp:MenuItem>
                <asp:MenuItem Text="未付款" Value="1"></asp:MenuItem>
                <asp:MenuItem Text="已取消" Value="-1"></asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem Text="销售统计" Value="销售统计" NavigateUrl="~/ManagerSale.aspx"></asp:MenuItem>
            <asp:MenuItem Text="会员管理" Value="会员管理" NavigateUrl="~/ManagerUser.aspx"></asp:MenuItem>
        </Items>
    </asp:Menu>

</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="ContentRight" Runat="Server">
    <asp:LinkButton ID="PrintOrder" runat="server" PostBackUrl="~/ManagerPage/PrintOrder.aspx">打印订单</asp:LinkButton>
    <asp:Panel ID="AllOrders" runat="server">

    <asp:DataList ID="ManagerAllOrderList" runat="server" >
                <HeaderTemplate>
            <table border="0">
                <td width="120" align="center"><span>订单编号</span></td>
                <td width="70px" align="center"><span>用户</span></td>
                <td width="70px" align="center"><span>下单时间</span></td>
                <td width="100px" align="center"><span>状态</span></td>
                <td width="180px" align="center"><span>地址</span></td>
                <td width="100px" align="center"><span>电话</span></td>
                <td width="100px" align="center"><span>金额（元）</span></td>
                <td width="70px" align="center"><span>操作</span></td>
            <table>
            </HeaderTemplate>

            <ItemStyle BackColor="#FFFBD6" ForeColor="#333333" />

            <ItemTemplate>
            <table>
                </tr>
                <tr>
                    <td width="120px" align="center">
                        <span style="font-size:x-small;color:gray;font-family:Tahoma"><%#Eval("OrderReference")%></span>
                    </td>
                    
                    <td width="70px" align="center">
                        <span class="FoodName" style="font-family:Tahoma;color:Blue"><%#Eval("UserName")%></span>
                    </td>

                    <td width="70px" align="center">
                        <span style="font-size:small; color:gray;"><%#Eval("PayTime")%></span>
                    </td>

                    <td width="100px" align="center">
                        <span style="font-size:small;color:Red;font-family:Tahoma"><%#Eval("Status")%></span>
                    </td>

                    <td width="180px" align="center">
                        <span style=" font-size:small;:black;font-family:Tahoma"><%# Eval("Address")%></span>
                    </td>

                    <td width="100px" align="center">
                        <span style="font-size:small;color:Red;font-family:Tahoma"><%#Eval("PhoneNum")%></span>
                    </td>

                    <td width="100px" align="center">
                        <span style="font-size:large;color:Red;font-family:Tahoma"><%#Eval("Total")%>元</span></td>
                    <td width="70px" align="center">
                        <asp:LinkButton ID="CheckLinkButton" runat="server" 
                            onclick="CheckLinkButton_Click">查看>></asp:LinkButton>
                    </td>
                </tr>
            </table>
            </ItemTemplate>


            <AlternatingItemStyle BackColor="White" />
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#7799FF" Font-Bold="true" ForeColor="White" />
            <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
    </asp:DataList>
    </asp:Panel>


    <asp:Panel ID="OrderDetail" runat="server" Visible="False">

        <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">&lt;&lt;返回</asp:LinkButton>
        <br /><br />
        <table style="width: 100%">
            <tr>
                <td style="width: 100%">
                    订单编号：<asp:Label ID="OrderReference" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 100%">
                    用户：<asp:Label ID="UserName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 100%; height: 25px;">
                    付款时间：<asp:Label ID="PayTime" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 100%">
                    状态：<asp:Label ID="StatusLabel" runat="server"></asp:Label>
                    <asp:LinkButton ID="StatusLinkButton" runat="server" 
                        Text="标记已发送" onclick="StatusLinkButton_Click"></asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td style="width: 100%">
                    地址：<asp:Label ID="AddressLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 100%">
                    电话：<asp:Label ID="PhoneLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>    
                <td>
                商品总价：<asp:Label ID="Total" runat="server" Text="0"></asp:Label>元 
                </td>
            </tr>
        </table>
        <br />
        购买食物列表：
            <asp:DataList ID="OrderFoodList" runat="server">

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



            </asp:DataList>

        </asp:Panel>

</asp:Content>




<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

