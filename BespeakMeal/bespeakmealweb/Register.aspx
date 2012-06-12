<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" 
AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentLeft" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentRight" Runat="Server">


    <table cellspacing="1" class="style1">
        <tr>
            <td><asp:Label ID="Label1" runat="server" Text="用户名"></asp:Label></td>
            <td><asp:TextBox ID="UserName" runat="server" AutoPostBack="True" 
                    ontextchanged="UserName_TextChanged"></asp:TextBox> </td>
        </tr>
        <tr>
            <td><asp:Label ID="Label2" runat="server" Text="密码"></asp:Label></td>
            <td><asp:TextBox ID="Password" runat="server" ></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label3" runat="server" Text="确认密码"></asp:Label></td>
            <td><asp:TextBox ID="ConfirmPassword" runat="server" AutoPostBack="True" 
                    ontextchanged="ConfirmPassword_TextChanged"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td><asp:Button ID="Button1" runat="server" Text="注册" onclick="Button1_Click" /></td>
        </tr>
    </table>
        <asp:Label ID="WrongMessage" runat="server" Text=""></asp:Label>
</asp:Content>
