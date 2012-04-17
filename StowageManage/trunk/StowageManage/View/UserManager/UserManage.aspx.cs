using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace StowageManage.View.UserManager
{
    public partial class UserManage : System.Web.UI.Page
    {
        Control.UserManager myUM = new Control.UserManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                DataSet mySource = myUM.SelectUser("", "", "", "");
                gv_UserManager.DataSource = mySource;
                gv_UserManager.DataBind();
            }
        }
        protected void gv_UserManager_RowDataBound(object sender, GridViewRowEventArgs e)
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
        protected void gv_UserManager_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "view")
            {
                string myUserID = e.CommandArgument.ToString();
                Page.RegisterStartupScript("js", "<script>window.location.href='UserItem.aspx?option=" + e.CommandName + "&myUserId=" + myUserID + "';</script>");
            }

            if (e.CommandName == "del")
            {
                string myUserID = e.CommandArgument.ToString().Trim();
                Page.RegisterStartupScript("js", "<script>alert('" + myUM.DelUser(myUserID) + "');window.location.href='UserManage.aspx';</script>");
            }


            if (e.CommandName == "edt")
            {
                string myUserID = e.CommandArgument.ToString();
                Page.RegisterStartupScript("js", "<script>window.location.href='UserItem.aspx?option=" + e.CommandName + "&myUserId=" + myUserID + "';</script>");
            }


        }
    }
}