using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace StowageManage.View.GoodsManager
{
    public partial class GoodsManage : System.Web.UI.Page
    {
        Control.GoodsManage myGSM = new Control.GoodsManage();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void gv_Goods_RowDataBound(object sender, GridViewRowEventArgs e)
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
        protected void gv_Goods_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string myGSID = e.CommandArgument.ToString();
            if (e.CommandName == "view")
            {
                Page.RegisterStartupScript("js", "<script>window.location.href='GoodsItem.aspx?option=" + e.CommandName + "&myGSId=" + myGSID + "';</script>");
            }

            if (e.CommandName == "del")
            {
                Page.RegisterStartupScript("js", "<script>alert('" + myGSM.DelGS(myGSID) + "');window.location.href='GoodsManage.aspx';</script>");
            }


            if (e.CommandName == "edt")
            {
                Page.RegisterStartupScript("js", "<script>window.location.href='GoodsItem.aspx?option=" + e.CommandName + "&myGSId=" + myGSID + "';</script>");
            }


        }
        protected void but_Select_Click(object sender, EventArgs e)
        {
            string myGSname = txt_GSname.Text.ToString().Trim().Replace("'", "");
            string myGSnum = txt_GSnum.Text.ToString().Trim().Replace("'", "");
            string myGStype = txt_GStype.Text.ToString().Trim().Replace("'", "");

            DataSet myData = myGSM.SelectGS("", myGSname, myGSnum, myGStype, "");
            gv_Goods.DataSource = myData;
            gv_Goods.DataBind();
        }
    }
}