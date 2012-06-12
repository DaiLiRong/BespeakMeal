<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" 
AutoEventWireup="true" CodeFile="Pay.aspx.cs" Inherits="Pay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentLeft" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentRight" Runat="Server">

        <table style="text-align:left;" >
            <tr>
                <td >
        订单提交成功！</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
        <asp:ImageButton ID="ImageButton1" runat="server" Height="31px" 
                ImageUrl="~/img/Pay.jpg" onclick="ImageButton1_Click" 
                 Width="114px" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
</asp:Content>