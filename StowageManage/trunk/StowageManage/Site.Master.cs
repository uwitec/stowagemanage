using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StowageManage
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    if (Session["UserName"] == null)
            //    {
            //        NavigationMenu.Enabled = false;
            //        Response.Write("<script>alert(\"您长时间未进行操作，请重新登陆\");window.location.href(''Account/Login.aspx');</script>");
            //    }
            //    else
            //    {
            //        if (Session["UserType"] == "会计")
            //        {
            //            //设置用户管理为不可选
            //            NavigationMenu.Items[6].Selectable = false;
            //            NavigationMenu.Items[6].Selected = false;
            //        }

            //    }
            //}
        }
    }
}
