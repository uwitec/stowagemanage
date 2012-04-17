<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StorageManage.aspx.cs" Inherits="StowageManage.View.StorageManager.StorageManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script language="javascript">
    function openModeBegin() {
        var sh;
        var returnValue = window.showModalDialog("../../Get_Calendar.aspx", sh, "dialogWidth=430px;dialogHeight=405px;scroll=no;status=no");
        document.getElementById("txt_StartDate").value = returnValue;
        //alert(returnValue);
    }
    function openModeBegin1() {
        var sh;
        var returnValue = window.showModalDialog("../../Get_Calendar.aspx", sh, "dialogWidth=430px;dialogHeight=405px;scroll=no;status=no");
        document.getElementById("txt_EndDate").value = returnValue;
        //alert(returnValue);
    } 
  </script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lab_GSnum" runat="server" Text="物品编号："></asp:Label>
    <asp:TextBox ID="txt_GSnum" runat="server"></asp:TextBox>
&nbsp;<asp:Label ID="lab_GSname" runat="server" Text="物品名称："></asp:Label>
    <asp:DropDownList ID="ddl_GSname" runat="server">
    </asp:DropDownList>
    <asp:Label ID="lab_STnum" runat="server" Text="入库单号"></asp:Label>
    <asp:TextBox ID="txt_STnum" runat="server"></asp:TextBox>
    <br />
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
    <asp:Label ID="lab_StartDate" runat="server" Text="起始日期："></asp:Label>
    <asp:TextBox ID="txt_StartDate" runat="server"></asp:TextBox>
                    <asp:ImageButton ID="btn_StartDate" runat="server" 
        CssClass="image" ImageUrl="~/Image/calendar.gif" ImageAlign="AbsMiddle" 
        onclick="btn_StartDate_Click" />
    <asp:Label ID="lab_EndDate" runat="server" Text="结束日期:"></asp:Label>
    <asp:TextBox ID="txt_EndDate" runat="server"></asp:TextBox>
                    <asp:ImageButton ID="btn_EndDate" runat="server" 
        CssClass="image" ImageUrl="~/Image/calendar.gif" ImageAlign="AbsMiddle" 
        onclick="btn_EndDate_Click" />
    <asp:Button ID="but_SelectStorage" runat="server" 
        onclick="but_SelectStorage_Click" Text="查询" />
    <br />
    <asp:GridView ID="gv_StroageManage" runat="server" OnRowDataBound="gv_StroageManage_RowDataBound"  OnRowCommand="gv_StroageManage_RowCommand">
    <Columns>
            <asp:TemplateField HeaderText="查看">
                <ItemTemplate>
                    <asp:LinkButton ID="dll_view" runat="server" CausesValidation="false"  CommandName="view"  CommandArgument=<%# Eval("ST_ID") %>  Text="查看"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <Columns>
            <asp:TemplateField HeaderText="修改">
                <ItemTemplate>
                    <asp:LinkButton ID="dll_edit" runat="server" CausesValidation="false"  CommandName="edt"  CommandArgument=<%# Eval("ST_ID") %>  Text="修改"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <Columns>
            <asp:TemplateField HeaderText="删除">
                <ItemTemplate>
                    <asp:LinkButton ID="dll_del" runat="server" CausesValidation="false"  CommandName="del"  CommandArgument=<%# Eval("ST_ID") %>  Text="删除" OnClientClick="javascript:return window.confirm('确定要删除该项吗?');"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
