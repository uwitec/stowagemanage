<%@ Page Title="主页" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="StowageManage._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        <asp:Label ID="lab_UserName" runat="server" Text=""></asp:Label> 欢迎使用 库存管理系统!
    </h2>
    <p>
        用户类型：<asp:Label ID="lab_UserType" runat="server" Text=""></asp:Label>
    </p>
    
</asp:Content>
