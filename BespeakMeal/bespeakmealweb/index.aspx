<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>
<%@ Register Src="IndexModule\Classify.ascx" TagName="Classify" TagPrefix="UC2" %>
<%@ Register Src="IndexModule\FoodList.ascx" TagName="FoodList" TagPrefix="UC3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentLeft" Runat="Server">

    <UC2:Classify ID="Classify" runat="server" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentRight" Runat="Server">

    <table border="1" runat="server">
        <tr style="margin-top:0">
            <td style="width:auto">
                <UC3:FoodList ID="FoodList1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>

