<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PrintOutofLibrary.aspx.cs" Inherits="StowageManage.View.OutOfLibrary.PrintOut" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <rsweb:ReportViewer ID="RV_PrintOOL" runat="server" ProcessingMode="Remote">
</rsweb:ReportViewer>
</asp:Content>
