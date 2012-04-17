using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace StowageManage.View.Manager
{
    public partial class Manager : System.Web.UI.Page
    {
        Control.Manager myMG = new Control.Manager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetDropDownList();
            }
        }
        protected void SetDropDownList()
        {
            Control.DropDownList_Source myDDLSource = new Control.DropDownList_Source();

            ddl_MGtype.DataSource = myDDLSource.DDL_Manager_Type();
            DDL_DataBind(ddl_MGtype);

        }
        protected void DDL_DataBind(DropDownList DDL)
        {
            DDL.DataTextField = "text";
            DDL.DataValueField = "value";
            DDL.DataBind();
        }
        protected void gv_Manager_RowDataBound(object sender, GridViewRowEventArgs e)
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
        protected void gv_Manager_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string myMGID = e.CommandArgument.ToString();
            if (e.CommandName == "view")
            {
                Page.RegisterStartupScript("js", "<script>window.location.href='Manager_Item.aspx?option=" + e.CommandName + "&myMGId=" + myMGID + "';</script>");
            }

            if (e.CommandName == "del")
            {
                Page.RegisterStartupScript("js", "<script>alert('" + myMG.DelMG(myMGID) + "');window.location.href='Manager.aspx';</script>");
            }

            if (e.CommandName == "edt")
            {
                Page.RegisterStartupScript("js", "<script>window.location.href='Manager_Item.aspx?option=" + e.CommandName + "&myMGId=" + myMGID + "';</script>");
            }
        }
        protected void but_MGselect_Click(object sender, EventArgs e)
        {
            string myMGname = txt_MGname.Text.Trim().Replace("'", "");
            string myMGnum = txt_MGnum.Text.Trim().Replace("'", "");
            string myMGcontact = txt_MGcontact.Text.Trim().Replace("'", "");
            string myMGIDnumber = txt_MGIDnumber.Text.Trim().Replace("'", "");
            string myMGtype = ddl_MGtype.SelectedValue;

            DataSet myData = myMG.SelectMG("", myMGname, myMGnum, myMGcontact, myMGIDnumber, myMGtype);
            gv_Manager.DataSource = myData;
            gv_Manager.DataBind();
        }
    }
}