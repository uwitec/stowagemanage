using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace StowageManage.View.CangKuManager
{
    public partial class CangkuManage : System.Web.UI.Page
    {
        Control.CangKuManage myCKM = new Control.CangKuManage();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void gv_Cangku_RowDataBound(object sender, GridViewRowEventArgs e)
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
        protected void gv_Cangku_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string myCKID = e.CommandArgument.ToString();
            if (e.CommandName == "view")
            {
                Page.RegisterStartupScript("js", "<script>window.location.href='CangKuItem.aspx?option=" + e.CommandName + "&myCKId=" + myCKID + "';</script>");
            }

            if (e.CommandName == "del")
            {
                Page.RegisterStartupScript("js", "<script>alert('" + myCKM.DelCK(myCKID) + "');window.location.href='CangKuManage.aspx';</script>");
            }


            if (e.CommandName == "edt")
            {
                Page.RegisterStartupScript("js", "<script>window.location.href='CangKuItem.aspx?option=" + e.CommandName + "&myCKId=" + myCKID + "';</script>");
            }


        }
        protected void but_Enter_Click(object sender, EventArgs e)
        {
            string myCKname = txt_CKname.Text.Trim().Replace("'", "");
            string myCKtype = txt_CKtype.Text.Trim().Replace("'", "");

            DataSet myData = myCKM.SelectCK("", myCKname, myCKtype);
            gv_Cangku.DataSource = myData;
            gv_Cangku.DataBind();
        }
    }
}