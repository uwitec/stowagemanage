<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GoodsManage.aspx.cs" Inherits="StowageManage.View.GoodsManager.GoodsManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lab_GSnum" runat="server" Text="物品编号："></asp:Label>
    <asp:TextBox ID="txt_GSnum" runat="server"></asp:TextBox>
    <asp:Label ID="lab_GSname" runat="server" Text="物品名称："></asp:Label>
    <asp:TextBox ID="txt_GSname" runat="server"></asp:TextBox>
    <asp:Label ID="lab_GStype" runat="server" Text="物品类型："></asp:Label>
    <asp:TextBox ID="txt_GStype" runat="server"></asp:TextBox>
    <asp:Button ID="but_Select" runat="server" onclick="but_Select_Click" 
        Text="查询" />
    <br />
    <asp:GridView ID="gv_Goods" runat="server" OnRowDataBound="gv_Goods_RowDataBound"  OnRowCommand="gv_Goods_RowCommand">
        <Columns>
            <asp:TemplateField HeaderText="查看">
                <ItemTemplate>
                    <asp:LinkButton ID="dll_view" runat="server" CausesValidation="false"  CommandName="view"  CommandArgument=<%# Eval("GS_ID") %>  Text="查看"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <Columns>
            <asp:TemplateField HeaderText="修改">
                <ItemTemplate>
                    <asp:LinkButton ID="dll_edit" runat="server" CausesValidation="false"  CommandName="edt"  CommandArgument=<%# Eval("GS_ID") %>  Text="修改"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <Columns>
            <asp:TemplateField HeaderText="删除">
                <ItemTemplate>
                    <asp:LinkButton ID="dll_del" runat="server" CausesValidation="false"  CommandName="del"  CommandArgument=<%# Eval("GS_ID") %>  Text="删除" OnClientClick="javascript:return window.confirm('确定要删除该项吗?');"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
