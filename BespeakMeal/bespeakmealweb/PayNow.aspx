<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" 
AutoEventWireup="true" CodeFile="PayNow.aspx.cs" Inherits="IndexModule_PayNow" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentLeft" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentRight" Runat="Server">

        <div>
        <br />
            <table class="style1">
                <tr>
                    <td class="style3">
                        <span class="style2">应付款项：</span>
                        <asp:Label ID="TotalLabel" runat="server" 
                            style="font-size: x-large; color: #FF0000;" Text="0"></asp:Label>
                        <span class="style2">元</span></td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style3">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </div>
        <h5 >支持以下银行机构在线支付，订单提交后即可选择：</h5>
        <div><img alt="支付银行" src="img\pic_bank.jpg"/></div>
        <br /><br /><br />
        <asp:LinkButton ID="FinishPayLink" runat="server"  
            onclick="FinishPayLink_Click">已完成付款</asp:LinkButton>
</asp:Content>
