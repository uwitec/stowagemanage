<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StorageItem.aspx.cs" Inherits="StowageManage.View.StorageManager.StorageItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="入库单号："></asp:Label>
    <asp:TextBox ID="txt_STnum" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="仓  库："></asp:Label>
    <asp:DropDownList ID="ddl_CangKu" runat="server">
    </asp:DropDownList>
    <br />
    <asp:Label ID="Label3" runat="server" Text="物品名称："></asp:Label>
    <asp:DropDownList ID="ddl_GSname" runat="server" >
    </asp:DropDownList>
    <br />
    <asp:Label ID="Label4" runat="server" Text="单位："></asp:Label>
    <asp:TextBox ID="txt_STDW" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label5" runat="server" Text="单价："></asp:Label>
    <asp:TextBox ID="txt_STDJ" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label6" runat="server" Text="数量："></asp:Label>
    <asp:TextBox ID="txt_STquantity" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label7" runat="server" Text="金额："></asp:Label>
    <asp:TextBox ID="txt_price" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label8" runat="server" Text="备注："></asp:Label>
    <asp:TextBox ID="txt_STnote" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="but_Enter" runat="server" onclick="but_Enter_Click" 
        style="width: 40px" Text="确认" Visible="False" />
</asp:Content>
