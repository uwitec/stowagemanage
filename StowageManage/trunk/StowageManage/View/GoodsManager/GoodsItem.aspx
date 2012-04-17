<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GoodsItem.aspx.cs" Inherits="StowageManage.View.GoodsManager.GoodsItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lab_GSnum" runat="server" Text="物品编号："></asp:Label>
    <asp:TextBox ID="txt_GSnum" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lab_GSname" runat="server" Text="物品名称："></asp:Label>
    <asp:TextBox ID="txt_GSname" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lab_GStype" runat="server" Text="物品类型："></asp:Label>
    <asp:TextBox ID="txt_GStype" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label1" runat="server" Text="备注："></asp:Label>
    <br />
    <asp:TextBox ID="txt_GSnote" runat="server" Height="179px" Width="597px"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="but_Enter" runat="server" onclick="but_Enter_Click" Text="确认" 
        Visible="False" />
</asp:Content>
