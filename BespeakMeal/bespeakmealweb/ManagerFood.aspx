<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManagerFood.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeft" Runat="Server">
    
    <asp:Menu ID="Menu1" runat="server" onmenuitemclick="Menu1_MenuItemClick">
        <Items>
            <asp:MenuItem Text="菜单管理" Value="菜单管理" NavigateUrl="~/ManagerFood.aspx">
                <asp:MenuItem Text="添加新菜" Value="添加新菜"></asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem Text="订单管理" Value="订单管理" NavigateUrl="~/ManagerOrder.aspx"></asp:MenuItem>
            <asp:MenuItem Text="销售统计" Value="销售统计" NavigateUrl="~/ManagerSale.aspx"></asp:MenuItem>
            <asp:MenuItem Text="会员管理" Value="会员管理" NavigateUrl="~/ManagerUser.aspx"></asp:MenuItem>
        </Items>
    </asp:Menu>
    
</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="ContentRight" Runat="Server">
    <asp:Panel ID="AllFood" runat="server">

    <span style="font-size: x-large; color: #990099"><strong>菜单管理</strong></span> 
        <asp:LinkButton ID="AddNewFood" runat="server" onclick="AddNewFood_Click">添加新菜</asp:LinkButton>
    <br />
    <asp:DataList ID="ManagerFoodList" runat="server">
        <HeaderTemplate>
            <table border="0">
                <td width="100" align="center"><span>食物</span></td>
                <td width="150px" align="center"><span>名称</span></td>
                <td width="100px" align="center"><span>类别</span></td>
                <td width="100px" align="center"><span>单价（元）</span></td>
                <td width="100px" align="center"><span>状态</span></td>
                <td width="100px" align="center"><span>已售（件）</span></td>
                <td width="100px" align="center"><span>操作</span></td>
            <table>
            </HeaderTemplate>

            <ItemStyle BackColor="#FFFBD6" ForeColor="#333333" />

            <ItemTemplate>
            <table>
                </tr>
                <tr>

                    <td width="100" align="center">
                        <span>


                            <img    alt= '<%#Eval("FoodName")%>'
                            src='<%#string.Format("img/{0}.jpg ",Eval("FoodId").ToString().Replace("    "," "))%> '
                            width= "45px" height="45px "/>
                        </span>
                    </td>
                    <td width="150px" align="center">
                        <span class="FoodName" style="font-family:Tahoma;color:Blue">
                        <%#Eval("FoodName")%></span>
                    </td>
                    <td width="100px" align="center">
                        <span ><%#Eval("FoodType")%></span></td>
                    <td width="100px" align="center">
                        <span style="font-size:large;color:Red;font-family:Tahoma">
                        <%# Eval("FoodPrice")%>元
                        </span>
                    </td>
                    <td width="100px" align="center">
                        <span style="font-size:large;color:Red;font-family:Tahoma"><%#Eval("Status")%></span></td>
                    <td width="100px" align="center">
                        <span style="font-size:large;color:Red;font-family:Tahoma"><%#Eval("SaleNum")%>份</span></td>
                    <td width="100px" align="center">
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

    <asp:Panel ID="FoodDetail" runat="server" Visible="False">

        <asp:Image ID="FoodImage" runat="server" Width="140px" />
        <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">&lt;&lt;返回</asp:LinkButton>
        <br /><br />
        <table style="width: 100%">
            <tr>
                <td style="width: 100%">
                    名称：<asp:Label ID="FoodNameLabel" runat="server"></asp:Label>
                    <asp:LinkButton ID="ChangeFoodName" runat="server" 
                        onclick="ChangeFoodName_Click">修改</asp:LinkButton>
                    <asp:TextBox ID="FoodNameTextBox" runat="server" Visible="False"></asp:TextBox>
                    <asp:LinkButton ID="ConfirmFoodName" runat="server" 
                        onclick="ConfirmFoodName_Click" Visible="False">确定</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td style="width: 100%">
                    类别：<asp:Label ID="TypeLabel" runat="server"></asp:Label>
                    <asp:LinkButton ID="ChangeType" runat="server" onclick="ChangeType_Click">修改</asp:LinkButton>
                    <asp:TextBox ID="TypeTextBox" runat="server" Height="19px" Visible="False" 
                        Width="148px"></asp:TextBox>
                    <asp:LinkButton ID="ConfirmType" runat="server" onclick="ConfirmType_Click" 
                        Visible="False">确定</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td style="width: 100%; height: 25px;">
                    单价：<asp:Label ID="PriceLabel" runat="server"></asp:Label>
                    元<asp:LinkButton ID="ChangePrice" runat="server" onclick="ChangePrice_Click">修改</asp:LinkButton>
                    <asp:TextBox ID="PriceTextBox" runat="server" Visible="False"></asp:TextBox>
                    <asp:LinkButton ID="ConfirmPrice" runat="server" onclick="ConfirmPrice_Click" 
                        Visible="False">确定</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td style="width: 100%">
                    折扣：<asp:Label ID="DisCountLabel" runat="server"></asp:Label>
                    <asp:LinkButton ID="ChangeDisCount" runat="server" 
                        onclick="ChangeDisCount_Click">修改</asp:LinkButton>
                    <asp:TextBox ID="DisCountTextBox" runat="server" Visible="False"></asp:TextBox>
                    <asp:LinkButton ID="ConfirmDisCount" runat="server" 
                        onclick="ConfirmDisCount_Click" Visible="False">确定</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td style="width: 100%">
                    状态：<asp:Label ID="StatusLabel" runat="server"></asp:Label>
                    <asp:LinkButton ID="StatusLinkButton" runat="server" 
                        onclick="StatusLinkButton_Click"></asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td style="width: 100%">
                    内容：<asp:Label ID="ContentLabel" runat="server"></asp:Label>
                    <asp:LinkButton ID="ChangeContent" runat="server">修改</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td style="width: 100%">
                    已售：<asp:Label ID="SaleNumLabel" runat="server"></asp:Label>
                    </td>
            </tr>
        </table>
        </asp:Panel>

        <asp:Panel ID="AddNewFoodPanel" runat="server" Visible="false">

        
            <table style="width: 100%">
                <tr>
                    <td>
                        名称：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        价格：<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                        元</td>
                </tr>
                <tr>
                    <td>
                        类型：<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        内容：<asp:TextBox ID="TextBox4" runat="server" Width="500px"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <asp:Button ID="SubmitNewFood" runat="server" Text="增加" 
                onclick="SubmitNewFood_Click" />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br /><br /><br />
            <asp:Panel ID="FileUpLoadPanel" runat="server" Visible="false">
            选择图片<br />
                <asp:FileUpload ID="FoodImg" runat="server" />
                <asp:Button ID="UpLoadImg" runat="server" Text="上传" onclick="UpLoadImg_Click" />
            </asp:Panel>
        </asp:Panel>



</asp:Content>





<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

