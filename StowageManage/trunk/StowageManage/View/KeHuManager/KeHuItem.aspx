<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="KeHuItem.aspx.cs" Inherits="StowageManage.View.KeHuManager.KeHuItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lab_KHname" runat="server" Text="客户名称："></asp:Label>
    <asp:TextBox ID="txt_KHname" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lab_KHtype" runat="server" Text="客户类型："></asp:Label>
    <asp:DropDownList ID="ddl_KHtype" runat="server">
        <asp:ListItem>供货商</asp:ListItem>
        <asp:ListItem>购货商</asp:ListItem>
    </asp:DropDownList>
    <br />
    <asp:Label ID="lab_KHtell" runat="server" Text="联系电话："></asp:Label>
    <asp:TextBox ID="txt_KHtell" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lab_KHaddress" runat="server" Text="通信地址："></asp:Label>
    <asp:TextBox ID="txt_KHaddress" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lab_KHnote" runat="server" Text="备注："></asp:Label>
    <br />
    <asp:TextBox ID="txt_KHnote" runat="server" Height="200px" Width="600px"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="but_Enter" runat="server" onclick="but_Enter_Click" Text="确认" 
        Visible="False" />
</asp:Content>
