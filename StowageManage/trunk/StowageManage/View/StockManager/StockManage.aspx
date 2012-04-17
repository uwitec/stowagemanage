<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StockManage.aspx.cs" Inherits="StowageManage.View.StockManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lab_CangKu" runat="server" Text="仓库："></asp:Label>
    <asp:DropDownList ID="ddl_CangKu" runat="server">
    </asp:DropDownList>
    <asp:Label ID="lab_Goods" runat="server" Text="物品:"></asp:Label>
    <asp:DropDownList ID="ddl_Goods" runat="server">
    </asp:DropDownList>
    <asp:Button ID="btn_Select" runat="server" onclick="btn_Select_Click" 
        Text="查询" />
    <br />
    <asp:GridView ID="gv_Stock" runat="server">
    </asp:GridView>
</asp:Content>
