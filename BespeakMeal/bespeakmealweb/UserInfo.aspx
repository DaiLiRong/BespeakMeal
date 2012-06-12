<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" 
AutoEventWireup="true" CodeFile="UserInfo.aspx.cs" Inherits="ChangeUserInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentLeft" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentRight" Runat="Server">

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
                    <asp:Button ID="Button2" runat="server" Text="确定" onclick="Button2_Click" />

                    <asp:Label ID="Label7" runat="server"></asp:Label>

                </asp:Panel>
                </td>
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
</asp:Content>