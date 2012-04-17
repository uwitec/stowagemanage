using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace StowageManage.View.StorageManager
{
    public partial class StorageManage : System.Web.UI.Page
    {
        Control.StorageManage mySTM = new Control.StorageManage();
        protected void Page_Load(object sender, EventArgs e)
        {
            btn_StartDate.Attributes.Add("OnClick", "openModeBegin()");
            btn_EndDate.Attributes.Add("OnClick", "openModeBegin1()");
            if (!IsPostBack)
            {
                SetDropDownList();
            }
        }
        protected void SetDropDownList()
        {
            Control.DropDownList_Source myDDLSource = new Control.DropDownList_Source();
            
            DDL_GHS.DataSource = myDDLSource.DDL_KeHu();
            DDL_DataBind(DDL_GHS);
            ddl_GSname.DataSource = myDDLSource.DDL_Goods();
            DDL_DataBind(ddl_GSname);
            ddl_RKY.DataSource = myDDLSource.DDL_Manager();
            DDL_DataBind(ddl_RKY);
            ddl_YHY.DataSource = myDDLSource.DDL_Manager();
            DDL_DataBind(ddl_YHY);

        }
        protected void DDL_DataBind(DropDownList DDL)
        {
            DDL.DataTextField = "text";
            DDL.DataValueField = "value";
            DDL.DataBind();
        }
        protected void gv_StroageManage_RowDataBound(object sender, GridViewRowEventArgs e)
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
        protected void gv_StroageManage_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string mySTID = e.CommandArgument.ToString();
            DAO.Storage myDAOST = mySTM.GetModel(mySTID);
            myDAOST.STstatus = "1";
            if (e.CommandName == "view")
            {
                //Page.RegisterStartupScript("js", "<script>window.location.href='StorageItem.aspx?option=" + e.CommandName + "&mySTId=" + mySTID + "';</script>");
                Response.Write("<script>window.location.href='StorageItem.aspx?option=" + e.CommandName + "&mySTId=" + mySTID + "';</script>");

            }

            if (e.CommandName == "del")
            {
                Page.RegisterStartupScript("js", "<script>alert('" + mySTM.UpdateST(myDAOST) + "');window.location.href='Manager.aspx';</script>");
            }

            if (e.CommandName == "edt")
            {
                Page.RegisterStartupScript("js", "<script>window.location.href='StorageItem.aspx?option=" + e.CommandName + "&mySTId=" + mySTID + "';</script>");
            }
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void but_SelectStorage_Click(object sender, EventArgs e)
        {
            string myGSnum = txt_GSnum.Text.Trim().Replace("'", "");//物品编号
            string myGSname = ddl_GSname.SelectedValue;//物品名称
            string mySTnum = txt_STnum.Text.Trim().Replace("'", "");//入库单号
            string myRKY = ddl_RKY.SelectedValue;//入库员
            string myYHY = ddl_YHY.SelectedValue;//验货员
            string myGHS = DDL_GHS.SelectedValue;//供货商
            string myStartDate = txt_StartDate.Text;//起始日期
            string myEndDate = txt_EndDate.Text;//结束日期
            
            DataSet myData = mySTM.SelectST("", mySTnum, myRKY, myYHY, myGHS, myGSname, "",myStartDate,myEndDate,"");
            gv_StroageManage.DataSource = myData;
            gv_StroageManage.DataBind();
        }

        protected void btn_StartDate_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["myDate"] != null)
            {
                txt_StartDate.Text = Session["myDate"].ToString();
            }
        }

        protected void btn_EndDate_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["myDate"] != null)
            {
                txt_EndDate.Text = Session["myDate"].ToString();
            }
        }
    }
}