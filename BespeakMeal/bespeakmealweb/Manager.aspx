<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Manager.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeft" Runat="Server">
    
    <table style="width: 100%; height: 157px">
        <tr>
            <td style="color: #FF0000">
                <asp:LinkButton ID="FoodLinkButton" runat="server" Text="菜单管理" PostBackUrl="~/ManagerFood.aspx"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td style="color: #FF0000">
                <asp:LinkButton ID="OrderLinkButton" runat="server" Text="订单管理" PostBackUrl="~/ManagerOrder.aspx"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td style="color: #FF0000">
                <asp:LinkButton ID="SaleLinkButton" runat="server" Text="销售统计" PostBackUrl="~/ManagerSale.aspx"></asp:LinkButton>
          </td>
        </tr>
        <tr>
            <td style="color: #FF0000">
                <asp:LinkButton ID="UserLinkButton" runat="server" Text="会员管理" PostBackUrl="~/ManagerUser.aspx"></asp:LinkButton>
            </td>
        </tr>
    </table>
    
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentRight" Runat="Server">
    


</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

