using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace StowageManage.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string myUserName = UserName.Text.Trim().Replace("'", "");
            string myPassword = Password.Text.Trim().Replace("'", "");
            Control.UserManager myUM = new Control.UserManager();
            DataSet mydata = myUM.SelectUser("", myUserName, myPassword, "");
            if (mydata.Tables[0].Rows.Count == 1)
            {
                Session["UserName"] = myUserName;
                Session["UserType"] = mydata.Tables[0].Rows[0]["用户类型"];
                Response.Write("<script>window.location.href('../Default.aspx');</script>");

            }
            else
            {
                FailureText.Text = "“用户名”或“密码”错误";
            }

        }

        
    }
}
