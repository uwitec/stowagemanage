<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CangKuItem.aspx.cs" Inherits="StowageManage.View.CangKuManager.CangKuItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lab_CKname" runat="server" Text="仓库名称："></asp:Label>
    <asp:TextBox ID="txt_CKname" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lab_CKtyep" runat="server" Text="仓库类型："></asp:Label>
    <asp:TextBox ID="txt_CKtype" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lab_CKnote" runat="server" Text="备注："></asp:Label>
    <br />
    <asp:TextBox ID="txt_CKnote" runat="server" Height="200px" Width="600px"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="but_Enter" runat="server" onclick="but_Enter_Click" Text="确认" 
        Visible="False" />
</asp:Content>
