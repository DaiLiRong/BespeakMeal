<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FoodList.ascx.cs" Inherits="IndexModule_FoodList" %>
    
   
    <div>
        
        <asp:DataList ID="FoodListView" runat="server" CellPadding="4" 
            RepeatColumns="6" BackColor="White" BorderColor="#CC9966" 
            BorderStyle="None" BorderWidth="1px" GridLines="Both" 
            OnItemCommand="FoodListView_OnItemCommand" Font-Size="Small" 
            Height="276px" RepeatDirection="Horizontal">

         
            <ItemTemplate>
                <div    class= "FoodListClass "    style= "width:140px; height: 200px;">
                <img    alt= '<%#Eval("FoodName")%>'
                src='<%#string.Format("img/{0}.jpg ",Eval("FoodId").ToString().Replace("    "," "))%> '
                width= "140px" height="140px "/> 
                <div style="font-family:Tahoma;color:Blue" class="FoodName"><%#Eval("FoodName")%>
                    <br/>
                    <div style="font-size:large;color:Red;font-family:Tahoma">¥<%#Eval("FoodPrice")%></div>
                </div>
                <div    class="selectfood">
                    <asp:LinkButton ID="LinkButton1" runat="server">购买</asp:LinkButton>
                </div>  
            </ItemTemplate>

            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <ItemStyle BackColor="#E9E09D" ForeColor="#330099" />
            <SelectedItemStyle BackColor="#FFCC66" ForeColor="#663399" />

        </asp:DataList>
    </div>