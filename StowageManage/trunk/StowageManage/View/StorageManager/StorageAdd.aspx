<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StorageAdd.aspx.cs" Inherits="StowageManage.View.StorageManager.StorageAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lab_GSnum" runat="server" Text="物品编号："></asp:Label>
    <asp:TextBox ID="txt_GSnum" runat="server"></asp:TextBox>
&nbsp;<asp:Label ID="lab_GSname" runat="server" Text="物品名称："></asp:Label>
    <asp:DropDownList ID="ddl_GSname" runat="server">
    </asp:DropDownList>
&nbsp;<br />
    <asp:Label ID="lab_STDW" runat="server" Text="物品单位："></asp:Label>
    <asp:TextBox ID="txt_STDW" runat="server"></asp:TextBox>
&nbsp;<asp:Label ID="lab_STDJ" runat="server" Text="物品单价："></asp:Label>
    <asp:TextBox ID="txt_STDJ" runat="server"></asp:TextBox>
    <asp:Label ID="lab_STquantity" runat="server" Text="物品数量："></asp:Label>
    <asp:TextBox ID="txt_STquantity" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lab_STnote" runat="server" Text="备注："></asp:Label>
    <asp:TextBox ID="txt_STnote" runat="server" Width="634px"></asp:TextBox>
&nbsp;<asp:Button ID="but_inster" runat="server" Text="添加" onclick="but_inster_Click" />
    <br />
    <asp:GridView ID="gv_Storage" runat="server" OnRowDataBound="gv_Storage_RowDataBound" OnRowCommand="gv_Storage_RowCommand">
       <Columns>
            <asp:TemplateField HeaderText="删除">
                <ItemTemplate>
                    <asp:LinkButton ID="dll_del" runat="server" CausesValidation="false"  CommandName="del"  CommandArgument=<%# Eval("编号") %>  Text="删除" OnClientClick="javascript:return window.confirm('确定要删除该项吗?');"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>           
        </Columns>
       
    </asp:GridView>
    <br />
    <asp:Label ID="lab_STnum" runat="server" Text="入库单号"></asp:Label>
    <asp:TextBox ID="txt_STnum" runat="server"></asp:TextBox>
    <asp:Label ID="lab_RKY" runat="server" Text="入库员："></asp:Label>
    <asp:DropDownList ID="ddl_RKY" runat="server">       
    </asp:DropDownList>
    <asp:Label ID="lab_YHY" runat="server" Text="验货员："></asp:Label>
    <asp:DropDownList ID="ddl_YHY" runat="server">
    </asp:DropDownList>
    <asp:Label ID="lab_GHS" runat="server" Text="供货商："></asp:Label>
    <asp:DropDownList ID="DDL_GHS" runat="server">
    </asp:DropDownList>
    <br />
    <asp:Label ID="lab_price" runat="server" Text="总价："></asp:Label>
    <asp:TextBox ID="txt_price" runat="server"></asp:TextBox>
    <asp:Label ID="lab_CangKu" runat="server" Text="仓库："></asp:Label>
    <asp:DropDownList ID="ddl_Cangku" runat="server">
    </asp:DropDownList>
    <asp:Button ID="but_Storage" runat="server" Text="入库" 
        onclick="but_Storage_Click" />
</asp:Content>
