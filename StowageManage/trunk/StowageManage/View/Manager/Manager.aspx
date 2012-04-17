<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manager.aspx.cs" Inherits="StowageManage.View.Manager.Manager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label2" runat="server" Text="职位："></asp:Label>
    <asp:DropDownList ID="ddl_MGtype" runat="server">
        <asp:ListItem>请选择</asp:ListItem>
        <asp:ListItem>会计</asp:ListItem>
        <asp:ListItem>杂工</asp:ListItem>
        <asp:ListItem>验货员</asp:ListItem>
        <asp:ListItem>入库员</asp:ListItem>
    </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lab_MGname" runat="server" Text="姓名："></asp:Label>
    <asp:TextBox ID="txt_MGname" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lab_MGnum" runat="server" Text="工号："></asp:Label>
    <asp:TextBox ID="txt_MGnum" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lab_MGIDnumber" runat="server" Text="身份证号："></asp:Label>
    <asp:TextBox ID="txt_MGIDnumber" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lab_contact" runat="server" Text="联系方式："></asp:Label>
    <asp:TextBox ID="txt_MGcontact" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="but_MGselect" runat="server" Text="查询" 
        onclick="but_MGselect_Click" />
    <br />
    <asp:GridView ID="gv_Manager" runat="server" OnRowDataBound="gv_Manager_RowDataBound"  OnRowCommand="gv_Manager_RowCommand">
    <Columns>
            <asp:TemplateField HeaderText="查看">
                <ItemTemplate>
                    <asp:LinkButton ID="dll_view" runat="server" CausesValidation="false"  CommandName="view"  CommandArgument=<%# Eval("MG_ID") %>  Text="查看"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <Columns>
            <asp:TemplateField HeaderText="修改">
                <ItemTemplate>
                    <asp:LinkButton ID="dll_edit" runat="server" CausesValidation="false"  CommandName="edt"  CommandArgument=<%# Eval("MG_ID") %>  Text="修改"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <Columns>
            <asp:TemplateField HeaderText="删除">
                <ItemTemplate>
                    <asp:LinkButton ID="dll_del" runat="server" CausesValidation="false"  CommandName="del"  CommandArgument=<%# Eval("MG_ID") %>  Text="删除" OnClientClick="javascript:return window.confirm('确定要删除该项吗?');"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
