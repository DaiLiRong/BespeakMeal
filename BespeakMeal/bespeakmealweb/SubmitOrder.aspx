<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" 
AutoEventWireup="true" CodeFile="SubmitOrder.aspx.cs" Inherits="SubmitOrder" %>
<%@ Register Src="IndexModule\ProductCar.ascx" TagName="Login" TagPrefix="UC2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentLeft" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentRight" Runat="Server">


    <table class="style1">
        <tr>
            <td class="style5">
                <strong>填写订单信息</strong></td>
            <td class="style6">
            </td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                地址：</td>
            <td class="style3">
                <asp:TextBox ID="AddressBox" runat="server" Width="300px" 
                    style="text-align: left"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4">
                电话：</td>
            <td class="style3">
                <asp:TextBox ID="PhoneNumBox" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4">
                其他要求：</td>
            <td class="style3">
                <asp:TextBox ID="OtherReqBox" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                <strong>确认商品信息</strong></td>
            <td class="style3">
                &nbsp;</td>
        </tr>
    </table>
       
    <UC2:Login ID="ProductCar1" runat="server" />
                <asp:ImageButton ID="ImageButton1" runat="server" Height="31px" 
                ImageUrl="~/img/queren.jpg" onclick="ImageButton1_Click" 
                 Width="114px" />
</asp:Content>
