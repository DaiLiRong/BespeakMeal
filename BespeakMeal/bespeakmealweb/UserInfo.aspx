<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserInfo.aspx.cs" Inherits="ChangeUserInfo" %>
<%@ Register Src="IndexModule\Login.ascx" TagName="Login" TagPrefix="UC1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 65%;
        }
        .style2
        {
            width: 330px;
            height: 162px;
        }
        .style4
        {
            width: 473px;
        }
        .style6
        {
            width: 83px;
            text-align: right;
            font-size: medium;
            font-family: 黑体;
        }
        .style7
        {
            width: 390px;
            height: 162px;
        }
        .style9
        {
            height: 60px;
            text-align: left;
        }
        .style10
        {
            width: 108px;
        }
        .style11
        {
            font-size: x-large;
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
            <td class="style2">
                <asp:Image ID="Image1" runat="server" Height="70px" Width="70px" />
                <br />
                <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click">修改头像</asp:LinkButton>
                <br />
                
                <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">修改密码</asp:LinkButton>
                <br />
                <asp:Panel ID="Panel1" runat="server" Width="235px" Visible="false">
                    
                    新的密码<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    <br />
                    确认密码<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    <br />
                    <asp:Button ID="Button2" runat="server" Text="Button" onclick="Button2_Click" />

                    <asp:Label ID="Label7" runat="server"></asp:Label>

                </asp:Panel>

            <td class="style7">
                <asp:Panel ID="Panel2" runat="server" Visible="False">
                
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:Button ID="Button1" runat="server" Text="上传" onclick="Button1_Click" />
                <br />
                请选择头像
                </asp:Panel>
                </tr>
     </table>
     <table>
        <tr>
            <td class="style9" colspan="3">
                <span class="style11">
                <br />
                <br />
                基本资料</span><br />
                -------------------------------------------------
            </td>
        </tr>

        <tr>
            <td class="style6">
                帐号：</td>
            <td class="style10">
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </td>
            <td class="style4">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                姓名：</td>
            <td class="style10">
                <asp:Label ID="Label2" runat="server"></asp:Label>
            </td>
            <td class="style4">
                <asp:LinkButton ID="LinkButtonName" runat="server" 
                    onclick="LinkButtonName_Click">修改</asp:LinkButton>
                <asp:TextBox ID="TextBoxName" runat="server" Visible="False"></asp:TextBox>
                <asp:Button ID="ButtonName" runat="server" onclick="ButtonName_Click" 
                    Text="确定" Visible="False" />
            </td>
        </tr>
        <tr>
            <td class="style6">
                性别：</td>
            <td class="style10">
                <asp:Label ID="Label3" runat="server"></asp:Label>
            </td>
            <td class="style4">
                <asp:LinkButton ID="LinkButtonGender" runat="server" 
                    onclick="LinkButtonGender_Click">修改</asp:LinkButton>
                <asp:RadioButton ID="RadioButtonMale" runat="server" Text="男" GroupName = "xb" 
                    Checked="True" Visible="False"/>
                <asp:RadioButton ID="RadioButtonFemale" runat="server" Text="女" 
                    GroupName = "xb" Visible="False"/>
                <asp:Button ID="ButtonGender" runat="server" onclick="ButtonGender_Click" 
                    Text="确定" Visible="False" />
            </td>
        </tr>
        <tr>
            <td class="style6">
                电话：</td>
            <td class="style10">
                <asp:Label ID="Label4" runat="server"></asp:Label>
            </td>
            <td class="style4">
                <asp:LinkButton ID="LinkButtonPhoneNum" runat="server" 
                    onclick="LinkButtonPhoneNum_Click">修改</asp:LinkButton>
                <asp:TextBox ID="TextBoxPhoneNum" runat="server" Visible="False"></asp:TextBox>
                <asp:Button ID="ButtonPhoneNum" runat="server" onclick="ButtonPhoneNum_Click" 
                    Text="确定" Visible="False" />
            </td>
        </tr>
        <tr>
            <td class="style6">
                邮箱：</td>
            <td class="style10">
                <asp:Label ID="Label5" runat="server"></asp:Label>
            </td>
            <td class="style4">
                <asp:LinkButton ID="LinkButtonEmail" runat="server" 
                    onclick="LinkButtonEmail_Click">修改</asp:LinkButton>
                <asp:TextBox ID="TextBoxEmail" runat="server" Visible="False"></asp:TextBox>
                <asp:Button ID="ButtonEmail" runat="server" onclick="ButtonEmail_Click" 
                    style="height: 21px" Text="确定" Visible="False" />
            </td>
        </tr>
        <tr>
            <td class="style6">
                创建时间：</td>
            <td class="style10">
                <asp:Label ID="Label6" runat="server"></asp:Label>
            </td>
            <td class="style4">
                &nbsp;</td>
        </tr>
    </table>
    </form>
</center>
</body>
</html>
