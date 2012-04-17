using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StowageManage
{
    public partial class Calendar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Calendar_pub_SelectionChanged(object sender, EventArgs e)
        {
            txt_cal.Text = Calendar_pub.SelectedDate.ToShortDateString();
            
        }
        protected void btn_cal_Click(object sender, EventArgs e)
        {
            Response.Write("<script language=javascript>window.returnValue='" + txt_cal.Text + "';window.close();</script>");
            Session["myDate"] = txt_cal.Text;
        }
    }
}