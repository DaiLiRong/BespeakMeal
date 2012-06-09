<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductCar.ascx.cs" Inherits="IndexModule_ProductCar" %>

<center>
   <asp:DataList ID="ProductCar" runat="server" CellPadding="4" 
            ForeColor="#333333" RepeatColumns="1" 
            onselectedindexchanged="ProductCar_SelectedIndexChanged">
            <HeaderTemplate>
            <table border="1">
                <td width="60"><asp:CheckBox ID="SelectAll" runat="server"  Text="全选"/></td>
                <td width="100"><span style="width:200px;">食物</span></td>
                <td width="130px"><span>名称</span></td>
                <td width="100px"><span style="width:100px">单价（元）</span></td>
                <td width="100px"><span style="width:150px;">数量（件）</span></td>
                <td width="100px"><span style="width:300px;">小计（元）</span></td>
                <td width="100px"><span style="width:60px;">操作</span></td>
            <table>
            </HeaderTemplate>

            <ItemStyle BackColor="#FFFBD6" ForeColor="#333333" />

            <ItemTemplate>
            <table border="1">
                </tr>
                <tr>
                    <td width="60">
                        <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" 
                            oncheckedchanged="CheckBox2_CheckedChanged" />
                    </td>
                    <td width="100">
                        <span style="width:500px; height: 50px;">
                        <img    alt= '<%#Eval("FoodName")%>'
                src='<%#string.Format("img/{0}.jpg ",Eval("FoodId").ToString().Replace("    "," "))%> '
                width= "45px" height="45px "/>
                        </span>
                    </td>
                    <td width="130px">
                        <span class="FoodName" style="font-family:Tahoma;color:Blue">
                        <%#Eval("FoodName")%></span>
                    </td>
                    <td width="100px">
                        <span style="font-size:large;color:Red;font-family:Tahoma">¥<%#Eval("FoodPrice")%></span></td>
                    <td width="100px">
                        <span>
                        <asp:TextBox ID="FoodNum" runat="server" AutoPostBack="True" 
                            ontextchanged="FoodNum_TextChanged" Text='<%# Eval("FoodNum") %>' Width="40px"></asp:TextBox>
                        <asp:LinkButton ID="ModifyNum" runat="server" Text="修改"></asp:LinkButton>
                        <asp:LinkButton ID="Confirm" runat="server" Text="确认" Visible="false"></asp:LinkButton>
                        </span>
                    </td>
                    <td width="100px">
                        <span style="font-size:large;color:Red;font-family:Tahoma">¥<%#Eval("MoneyCount")%></span></td>
                    <td width="100px">
                        <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">删除</asp:LinkButton>
                    </td>
                </tr>
            </table>
            </ItemTemplate>


            <AlternatingItemStyle BackColor="White" />
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />

    </asp:DataList>
</center>
    <div></div>
    <asp:Label ID="Label1" runat="server" Text="商品总价：" style=" margin-left:600px"></asp:Label>
    <asp:Label ID="Total" runat="server" Text=""></asp:Label>元
    <asp:ImageButton ID="ImageButton1" ImageUrl="~/img/buynow.jpg" runat="server" 
        Height="31px" Width="114px" onclick="ImageButton1_Click" PostBackUrl="~/SubmitOrder.aspx" />