using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace StowageManage.View.KeHuManager
{
    public partial class KeHuManage : System.Web.UI.Page
    {
        Control.KeHuManage myKHM = new Control.KeHuManage();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void gv_KeHu_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //隐藏不必要的列 
            if ((e.Row.RowType == DataControlRowType.DataRow) || (e.Row.RowType == DataControlRowType.Header) || (e.Row.RowType == DataControlRowType.Footer))
            {
                e.Row.Cells[3].Visible = false;
            }
            if (e.Row.RowIndex != -1)
            {
                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#E2F2FF'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
            }
        }
        protected void gv_KeHu_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string myKHID = e.CommandArgument.ToString();
            if (e.CommandName == "view")
            {
                Page.RegisterStartupScript("js", "<script>window.location.href='KeHuItem.aspx?option=" + e.CommandName + "&myKHId=" + myKHID + "';</script>");
            }

            if (e.CommandName == "del")
            {
                Page.RegisterStartupScript("js", "<script>alert('" + myKHM.DelKH(myKHID) + "');window.location.href='KeHuManage.aspx';</script>");
            }

            if (e.CommandName == "edt")
            {
                Page.RegisterStartupScript("js", "<script>window.location.href='KeHuItem.aspx?option=" + e.CommandName + "&myKHId=" + myKHID + "';</script>");
            }
        }
        protected void but_Enter_Click(object sender, EventArgs e)
        {
            string myKHname = txt_KHname.Text.ToString().Trim().Replace("'", "");
            string myKHtype = ddl_KHtype.SelectedValue.ToString().Trim().Replace("'", "");

            DataSet myData = myKHM.SelectKH("", myKHtype, myKHname, "", "");
            gv_KeHu.DataSource = myData;
            gv_KeHu.DataBind();
        }
    }
}