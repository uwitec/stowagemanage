<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Get_Calendar.aspx.cs" Inherits="StowageManage.Get_Calendar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>库存管理系统</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />

    <script id="clientEventHandlersJS" language="javascript"> 
        <!--
        function IFRAME1_onblur() { } 
        //--> 
    </script> 

<base target="_self" />
</head>
<body runat="server" ID="Body1"> 
  <form id="Form1" method="post" runat="server"> 
   <iframe frameborder="no" src='Calendar.aspx' style="WIDTH: 440px; HEIGHT: 360px" id="IFRAME1" 
    language="javascript" onblur="return IFRAME1_onblur()"></iframe> 
  </form> 
</body> 

</html>
