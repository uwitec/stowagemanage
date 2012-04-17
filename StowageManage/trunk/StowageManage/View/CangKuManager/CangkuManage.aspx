<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CangkuManage.aspx.cs" Inherits="StowageManage.View.CangKuManager.CangkuManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lab_CKname" runat="server" Text="仓库名称："></asp:Label>
    <asp:TextBox ID="txt_CKname" runat="server"></asp:TextBox>
    <asp:Label ID="lab_CKtype" runat="server" Text="仓库类型："></asp:Label>
    <asp:TextBox ID="txt_CKtype" runat="server"></asp:TextBox>
    <asp:Button ID="but_Enter" runat="server" Text="查询" onclick="but_Enter_Click" />
    <br />
    <asp:GridView ID="gv_Cangku" runat="server" OnRowDataBound="gv_Cangku_RowDataBound"  OnRowCommand="gv_Cangku_RowCommand">
        <Columns>
            <asp:TemplateField HeaderText="查看">
                <ItemTemplate>
                    <asp:LinkButton ID="dll_view" runat="server" CausesValidation="false"  CommandName="view"  CommandArgument=<%# Eval("CK_ID") %>  Text="查看"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <Columns>
            <asp:TemplateField HeaderText="修改">
                <ItemTemplate>
                    <asp:LinkButton ID="dll_edit" runat="server" CausesValidation="false"  CommandName="edt"  CommandArgument=<%# Eval("CK_ID") %>  Text="修改"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <Columns>
            <asp:TemplateField HeaderText="删除">
                <ItemTemplate>
                    <asp:LinkButton ID="dll_del" runat="server" CausesValidation="false"  CommandName="del"  CommandArgument=<%# Eval("CK_ID") %>  Text="删除" OnClientClick="javascript:return window.confirm('确定要删除该项吗?');"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
