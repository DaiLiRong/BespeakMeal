<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <style type="text/css" >
    .wang
    {
       color:white;
       background-color:red;
    }
    .ai
    {
       color:yellow;
       background-color:green;    
       display:inline-block;
       border-width:1px;
       border-style:Solid;
    }  
    .hui
    {
       color:blue;
       background-color:orange;    
       display:inline-block;
       border-width:1px;
       border-style:Solid;            
    }
    </style>   
    <script language="javascript" type="text/javascript">
        function mouseOver() {
            var label1 = document.getElementById("Label1");
            label1.className = "ai";
            return false;
        }
        function mouseOut() {
            var label1 = document.getElementById("Label1");
            label1.className = "hui";
            return false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label  ID="Label1" runat="server" CssClass="wang"   onmouseover="mouseOver();" onmouseout="mouseOut();" Text="曲阳变化大了,我也好久没回去了,有点怀念它了." BorderStyle="Solid" BorderWidth="1px"></asp:Label>
    </div>
    <asp:Menu ID="Menu1" runat="server" StaticSubMenuIndent="50px" Font-Size="X-Large">
        <Items>
            <asp:MenuItem Text="菜单编辑" NavigateUrl="~/index.aspx"></asp:MenuItem>
            <asp:MenuItem Text="订单编辑"></asp:MenuItem>
            <asp:MenuItem Text="打印账单"></asp:MenuItem>
            <asp:MenuItem Text="安静年啊"></asp:MenuItem>
        </Items>
    </asp:Menu>
    </form>
</body>
</html>


