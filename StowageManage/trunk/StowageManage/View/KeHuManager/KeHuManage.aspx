<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="KeHuManage.aspx.cs" Inherits="StowageManage.View.KeHuManager.KeHuManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lab_KHtype" runat="server" Text="客户类型："></asp:Label>
    <asp:DropDownList ID="ddl_KHtype" runat="server">
        <asp:ListItem>请选择</asp:ListItem>
        <asp:ListItem>供货商</asp:ListItem>
        <asp:ListItem>购货商</asp:ListItem>
    </asp:DropDownList>
    <asp:Label ID="lab_KHname" runat="server" Text="客户名称："></asp:Label>
    <asp:TextBox ID="txt_KHname" runat="server"></asp:TextBox>
    <asp:Button ID="but_Enter" runat="server" Text="查询" onclick="but_Enter_Click" />
    <br />
    <asp:GridView ID="gv_KeHu" runat="server" OnRowDataBound="gv_KeHu_RowDataBound"  OnRowCommand="gv_KeHu_RowCommand">
        <Columns>
            <asp:TemplateField HeaderText="查看">
                <ItemTemplate>
                    <asp:LinkButton ID="dll_view" runat="server" CausesValidation="false"  CommandName="view"  CommandArgument=<%# Eval("KH_ID") %>  Text="查看"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <Columns>
            <asp:TemplateField HeaderText="修改">
                <ItemTemplate>
                    <asp:LinkButton ID="dll_edit" runat="server" CausesValidation="false"  CommandName="edt"  CommandArgument=<%# Eval("KH_ID") %>  Text="修改"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <Columns>
            <asp:TemplateField HeaderText="删除">
                <ItemTemplate>
                    <asp:LinkButton ID="dll_del" runat="server" CausesValidation="false"  CommandName="del"  CommandArgument=<%# Eval("KH_ID") %>  Text="删除" OnClientClick="javascript:return window.confirm('确定要删除该项吗?');"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
