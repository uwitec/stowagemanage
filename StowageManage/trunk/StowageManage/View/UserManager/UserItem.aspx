<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserItem.aspx.cs" Inherits="StowageManage.Control.UserItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lab_UserName" runat="server" Text="用户名："></asp:Label>
<asp:TextBox ID="txt_UserName" runat="server"></asp:TextBox>
<br />
<asp:Label ID="lab_UserType" runat="server" Text="用户类型："></asp:Label>
<asp:DropDownList ID="ddl_Usertype" runat="server">
   
</asp:DropDownList>
<br />
<asp:Label ID="lab_Password1" runat="server" Text="登录密码："></asp:Label>
<asp:TextBox ID="txt_Password1" runat="server"></asp:TextBox>
<br />
<asp:Label ID="lab_Password2" runat="server" Text="确认密码：" Visible="False"></asp:Label>
<asp:TextBox ID="txt_Password2" runat="server" Visible="False"></asp:TextBox>
<br />
<asp:Button ID="bun_Enter" runat="server" onclick="bun_Enter_Click" Text="确认" 
        Visible="False" />
<br />
</asp:Content>
