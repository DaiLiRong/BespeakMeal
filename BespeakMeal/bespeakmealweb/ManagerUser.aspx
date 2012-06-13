<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManagerUser.aspx.cs" Inherits="_Default" %>

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
    <span style="font-size: x-large; color: #990099"><strong>会员管理</strong></span> 
    <asp:DataList ID="UserList" runat="server">
        <HeaderTemplate>
            <table border="0">
                <td width="60px" align="center"><span>头像</span></td>
                <td width="100px" align="center"><span>帐号</span></td>
                <td width="70px" align="center"><span>姓名</span></td>
                <td width="50px" align="center"><span>性别</span></td>
                <td width="150px" align="center"><span>电话</span></td>
                <td width="180px" align="center"><span>邮箱</span></td>
                <td width="180px" align="center"><span>创建时间</span></td>
                <td width="70px" align="center"><span>权限</span></td>
            <table>
            </HeaderTemplate>

            <ItemStyle BackColor="#FFFBD6" ForeColor="#333333" />

            <ItemTemplate>
            <table>
                </tr>
                <tr>

                    <td width="60px" align="center">
                        <span>
                            <img    alt= '<%#Eval("UserName")%>'
                            src='<%#string.Format("img/userimage/{0}.jpg ",Eval("UserId").ToString().Replace("    "," "))%> '
                            width= "45px" height="45px "/>
                        </span>
                    </td>
                    <td width="100px" align="center">
                        <span class="FoodName" style="font-family:Tahoma;color:Blue">
                        <%#Eval("UserName")%></span>
                    </td>
                    <td width="70px" align="center">
                        <span ><%#Eval("Name")%></span></td>
                    <td width="50px" align="center">
                        <span style="font-size:large;color:Red;font-family:Tahoma">
                        <%# Eval("Gender")%>
                        </span>
                    </td>
                    <td width="150px" align="center">
                        <span><%#Eval("PhoneNum")%></span></td>
                    <td width="180px" align="center">
                        <span><%#Eval("Email")%></span></td>
                    <td width="180px" align="center">
                        <span><%#Eval("CreateTime")%></span></td>
                    <td width="70px" align="center">
                        <span><%#Eval("SuperUser")%></span></td>
                    
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

