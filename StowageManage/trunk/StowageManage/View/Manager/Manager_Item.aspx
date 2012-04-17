<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manager_Item.aspx.cs" Inherits="StowageManage.View.Manager.Manager_Item" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lab_MGname" runat="server" Text="姓名："></asp:Label>
    <asp:TextBox ID="txt_MGname" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lab_MGnum" runat="server" Text="工号："></asp:Label>
    <asp:TextBox ID="txt_MGnum" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lab_MGtype" runat="server" Text="职位："></asp:Label>
    <asp:DropDownList ID="ddl_MGtype" runat="server">
       
    </asp:DropDownList>
    <br />
    <asp:Label ID="lab_MGIDnumber" runat="server" Text="身份证号："></asp:Label>
    <asp:TextBox ID="txt_MGIDnumber" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lab_MGcontact" runat="server" Text="联系方式："></asp:Label>
    <asp:TextBox ID="txt_MGcontact" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lab_MGnote" runat="server" Text="备注："></asp:Label>
    <br />
    <asp:TextBox ID="txt_MGnote" runat="server" Height="200px" Width="600px"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="but_Enter" runat="server" onclick="but_Enter_Click" Text="确认" 
        Visible="False" />
</asp:Content>
