<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManagerSale.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeft" Runat="Server">

    <asp:Menu ID="Menu1" runat="server">
        <Items>
            <asp:MenuItem Text="菜单管理" Value="菜单管理" NavigateUrl="~/ManagerFood.aspx"></asp:MenuItem>
            <asp:MenuItem Text="订单管理" Value="订单管理" NavigateUrl="~/ManagerOrder.aspx"></asp:MenuItem>
            <asp:MenuItem Text="销售统计" Value="销售统计" NavigateUrl="~/ManagerSale.aspx"></asp:MenuItem>
            <asp:MenuItem Text="会员管理" Value="会员管理" NavigateUrl="~/ManagerUser.aspx"></asp:MenuItem>
        </Items>
    </asp:Menu>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentRight" Runat="Server">

    <asp:LinkButton ID="sevenday" runat="server" onclick="sevenday_Click">最近一个星期的销售额</asp:LinkButton>

    <asp:DataList ID="SaleList" runat="server">
        <HeaderTemplate>
            <table border="0">
                <td width="120" align="center"><span>星期一</span></td>
                <td width="70px" align="center"><span>销售额</span></td>
            <table>
            </HeaderTemplate>

            <ItemStyle BackColor="#FFFBD6" ForeColor="#333333" />

            <ItemTemplate>
            <table>
                </tr>
                <tr>
                    <td width="120px" align="center">
                        <span style="font-size:large;color:gray;font-family:Tahoma"><%#Eval("Date")%></span>

                    <td width="100px" align="center">
                        <span style="font-size:large;color:Red;font-family:Tahoma"><%#Eval("Total")%>元</span></td>

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

