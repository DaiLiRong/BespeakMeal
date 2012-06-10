<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Login.ascx.cs" Inherits="IndexModule_Login" ClassName="IndexModule_Login" %>

    <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center" BorderWidth="0">

            <asp:Label ID="UserNameLabel" runat="server" Text="用户名"></asp:Label>
            <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
            <font color="red">*</font>
        
            <asp:Label ID="PasswordLabel" runat="server" Text="密码"></asp:Label>
            <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
            <font color="red">*</font>
       
            
            <asp:Button ID="UserLogin" runat="server" Text="登录" onclick="UserLogin_Click" />
            <asp:Label ID="LabelSuccessOrNot" runat="server" Text=""></asp:Label>
            <a href="Register.aspx"><asp:Label ID="Label1" runat="server" Text="注册"></asp:Label></a>
    </asp:Panel>

    <asp:Panel ID="Panel2" runat="server" HorizontalAlign="Center">
        <asp:LinkButton ID="MainPage" runat="server" onclick="MainPage_Click">首页</asp:LinkButton>
        Hello <%=Session["UserName"]%>!
        <asp:Label ID="Label2" runat="server" Text="欢迎使用订餐系统"></asp:Label>
        <asp:LinkButton ID="LinkButton3" runat="server" onclick="LinkButton3_Click">我的信息</asp:LinkButton>
        <asp:LinkButton ID="MyCar" runat="server" Text="我的购物车" onclick="MyCar_Click"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/MyOrder.aspx">我的订单</asp:LinkButton>
        <asp:LinkButton ID="Manager" runat="server" Visible="false">管理员入口</asp:LinkButton>
        <asp:LinkButton ID="Logout" runat="server" onclick="Logout_Click">退出</asp:LinkButton>
    </asp:Panel>