<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManagerOrder.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeft" Runat="Server">

    <asp:Menu ID="Menu1" runat="server" onmenuitemclick="Menu1_MenuItemClick">
        <Items>
            <asp:MenuItem Text="菜单管理" Value="菜单管理" NavigateUrl="~/ManagerFood.aspx"></asp:MenuItem>
            <asp:MenuItem Text="订单管理" Value="订单管理" NavigateUrl="~/ManagerOrder.aspx">
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
                        <asp:LinkButton ID="CheckLinkButton" runat="server">查看>></asp:LinkButton>
                    </td>
                </tr>
            </table>
            </ItemTemplate>


            <AlternatingItemStyle BackColor="White" />
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#7799FF" Font-Bold="true" ForeColor="White" />
            <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
    </asp:DataList>

</asp:Content>




<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

