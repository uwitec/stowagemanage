using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace StowageManage.View
{
    public partial class StockManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Control.DropDownList_Source myDDLSource = new Control.DropDownList_Source();
            if (!IsPostBack)
            {
                ddl_CangKu.DataSource = myDDLSource.DDL_CangKu();
                DDL_DataBind(ddl_CangKu);
                ddl_Goods.DataSource = myDDLSource.DDL_Goods();
                DDL_DataBind(ddl_Goods);
            }
        }
        protected void DDL_DataBind(DropDownList DDL)
        {
            DDL.DataTextField = "text";
            DDL.DataValueField = "value";
            DDL.DataBind();
        }
        protected void btn_Select_Click(object sender, EventArgs e)
        {
            string myCKid = ddl_CangKu.SelectedValue.ToString();
            string myGSid = ddl_Goods.SelectedValue.ToString();
            Control.StockManage mySKM=new Control.StockManage ();
            DataSet ds = mySKM.SelectStock(myCKid, myGSid);
            gv_Stock.DataSource = ds;
            gv_Stock.DataBind();
        }
    }
}