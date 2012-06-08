<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css"> body { 
        background-attachment:fixed; 
        background-color:#FFFF66; 
        background-image:url(bg.jpg); 
        background-position:center; 
        background-repeat:no-repeat; 
        }
    </style>
</head>
<body>
    <form id="reg" runat="server">
    <center>
    <table cellspacing="1" class="style1">
        <tr>
            <td><asp:Label ID="Label1" runat="server" Text="用户名"></asp:Label></td>
            <td><asp:TextBox ID="UserName" runat="server" AutoPostBack="True" 
                    ontextchanged="UserName_TextChanged"></asp:TextBox> </td>
        </tr>
        <tr>
            <td><asp:Label ID="Label2" runat="server" Text="密码"></asp:Label></td>
            <td><asp:TextBox ID="Password" runat="server"></asp:TextBox></td>
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
    </form>
   </center>
</body>
</html>
