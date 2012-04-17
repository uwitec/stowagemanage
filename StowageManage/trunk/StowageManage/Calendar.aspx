<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="StowageManage.Calendar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>日期选择窗体</title> 
  <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"> 
  <meta content="JavaScript" name="vs_defaultClientScript"> 
  <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"> 
 </head> 
 <body id="Mybody" runat="server" ms_positioning="GridLayout"> 
  <form id="Form1" method="post" runat="server"> 
   <asp:calendar id="Calendar_pub" 
       style="Z-INDEX: 101; LEFT: 32px; POSITION: absolute; TOP: 16px" runat="server" 
    Height="300px" Width="360px" BorderWidth="1px" BackColor="#FFFFCC" 
       DayNameFormat="Full" ForeColor="#663399" 
    Font-Size="8pt" Font-Names="Verdana" BorderColor="#FFCC66" 
       ShowGridLines="True" PrevMonthText="上个月&amp;lt;&amp;lt;" 
    NextMonthText="下个月&amp;gt;&amp;gt;" 
       onselectionchanged="Calendar_pub_SelectionChanged"> 
    <TodayDayStyle ForeColor="#00C000" BackColor="Khaki"></TodayDayStyle> 
    <SelectorStyle BackColor="#FFCC66"></SelectorStyle> 
    <NextPrevStyle Font-Size="7pt" ForeColor="#FFFFCC"></NextPrevStyle> 
    <DayHeaderStyle Height="1px" BackColor="#FFCC66"></DayHeaderStyle> 
    <SelectedDayStyle Font-Bold="True" BackColor="MediumPurple"></SelectedDayStyle> 
    <TitleStyle Font-Size="9pt" Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></TitleStyle> 
    <OtherMonthDayStyle ForeColor="#CC9966"></OtherMonthDayStyle> 
   </asp:calendar> 
   <asp:TextBox id="txt_cal" style="Z-INDEX: 102; LEFT: 32px; POSITION: absolute; TOP: 326px" runat="server" Visible="False"></asp:TextBox> 
   <asp:Button id="btn_cal" style="Z-INDEX: 103; LEFT: 168px; POSITION: absolute; TOP: 322px; right: 1030px;" runat="server" Text="确 定" BorderColor="SteelBlue" ForeColor="White" BackColor="SteelBlue" Width="81px" Height="30px" onclick="btn_cal_Click"></asp:Button></form> 
 </body> 
</html> 
