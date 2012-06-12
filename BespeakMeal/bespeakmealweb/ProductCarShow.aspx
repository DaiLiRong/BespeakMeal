<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" 
AutoEventWireup="true" CodeFile="ProductCarShow.aspx.cs" Inherits="ProductCarShow" %>

<%@ Register Src="IndexModule\ProductCar.ascx" TagName="ProductCar" TagPrefix="UC2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentLeft" Runat="Server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentRight" Runat="Server">


    <asp:Panel ID="Panel2" runat="server" Visible="False">
        <UC2:ProductCar ID="ProductCar1" runat="server" />
        <asp:ImageButton ID="ImageButton1" runat="server" Height="31px" 
                ImageUrl="~/img/buynow.jpg" onclick="ImageButton1_Click" 
                PostBackUrl="~/SubmitOrder.aspx" Width="114px" />
    </asp:Panel>

    <asp:Panel ID="Panel1" runat="server" Visible="False">
        <!-- E 商品列表 --> 
        <!-- S 购物车为空并且用户登录 -->
        <div>
            <h3>您的购物车还是空的。</h3>
            <p> 您还没有添加任何商品。马上去<a href="index.aspx">挑选商品</a>看看。</p>
        </div>
    </asp:Panel>

</asp:Content>
