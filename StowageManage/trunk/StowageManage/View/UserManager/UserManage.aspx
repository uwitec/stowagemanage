<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserManage.aspx.cs" Inherits="StowageManage.View.UserManager.UserManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="gv_UserManager" runat="server" 
         OnRowDataBound="gv_UserManager_RowDataBound"  OnRowCommand="gv_UserManager_RowCommand">

         <Columns>
                                <asp:TemplateField HeaderText="查看">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="dll_view" runat="server" CausesValidation="false"  CommandName="view"  CommandArgument=<%# Eval("US_ID") %>  Text="查看"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <Columns>
                                <asp:TemplateField HeaderText="修改">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="dll_edit" runat="server" CausesValidation="false"  CommandName="edt"  CommandArgument=<%# Eval("US_ID") %>  Text="修改"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <Columns>
                                <asp:TemplateField HeaderText="删除">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="dll_del" runat="server" CausesValidation="false"  CommandName="del"  CommandArgument=<%# Eval("US_ID") %>  Text="删除" OnClientClick="javascript:return window.confirm('确定要删除该项吗?');"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
    </asp:GridView>
</asp:Content>
