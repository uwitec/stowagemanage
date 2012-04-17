using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StowageManage.View.StorageManager
{
    public partial class StorageItem : System.Web.UI.Page
    {
        Control.StorageManage mySTM = new Control.StorageManage();
        protected void Page_Load(object sender, EventArgs e)
        {
            String myOption = Request.QueryString["option"];
            if (!IsPostBack)
            {
                SetDropDownList();
            }
            if (myOption == "add")
            {
                but_Enter.Visible = true;
            }
            if (myOption == "edt")
            {

                but_Enter.Visible = true;


                if (!IsPostBack)
                {
                    String mySTId = Request.QueryString["mySTId"];
                    SetView(mySTId);
                }
            }
            if (myOption == "view")
            {
                if (!IsPostBack)
                {
                    String mySTId = Request.QueryString["mySTId"];
                    SetView(mySTId);
                }
            }
        }
        protected void SetDropDownList()
        {
            Control.DropDownList_Source myDDLSource = new Control.DropDownList_Source();

            ddl_CangKu.DataSource = myDDLSource.DDL_CangKu();
            DDL_DataBind(ddl_CangKu);           
            ddl_GSname.DataSource = myDDLSource.DDL_Goods();
            DDL_DataBind(ddl_GSname); 
        }
        protected void DDL_DataBind(DropDownList DDL)
        {
            DDL.DataTextField = "text";
            DDL.DataValueField = "value";
            DDL.DataBind();
        }
        private void SetView(String mySTId)
        {
            DAO.Storage myST = mySTM.GetModel(mySTId);
            ddl_CangKu.SelectedValue = myST.STckid;
            ddl_GSname.SelectedValue = myST.STgsid;
            txt_price.Text = myST.STprice.ToString();
            txt_STDJ.Text = myST.STDJ.ToString();
            txt_STDW.Text = myST.STDW.ToString();
            txt_STnote.Text = myST.STnote;
            txt_STnum.Text = myST.STnum;
            txt_STquantity.Text = myST.STquantity.ToString();
        }
        protected void but_Enter_Click(object sender, EventArgs e)
        {
            String myOption = Request.QueryString["option"];

            string mySTckid = ddl_CangKu.SelectedValue;
            string mySTGSid = ddl_GSname.SelectedValue;
            decimal mySTprice = decimal.Parse(txt_price.Text.Trim().Replace("'", ""));
            decimal mySTDJ = decimal.Parse(txt_STDJ.Text.Trim().Replace("'", ""));
            string mySTDW = txt_STDW.Text.Trim().Replace("'", "");
            string mySTnote = txt_STnote.Text.Trim().Replace("'", "");
            string mySTnum = txt_STnum.Text.Trim().Replace("'", "");
            int mySTquantity = int.Parse(txt_STquantity.Text.Trim().Replace("'", ""));
            string mySTId;

            if (Request.QueryString["mySTId"] == null)
            {
                mySTId = "";
            }
            else
            {
                mySTId = Request.QueryString["mySTId"].ToString().Trim().Replace("'", "");
            }
            DAO.Storage mySTModel = mySTM.GetModel(mySTId);
            DAO.Storage myModel = mySTM.SetModel(mySTId, mySTnum, mySTckid, mySTGSid, mySTModel.STRK_MGid, mySTModel.STYH_MGid, mySTModel.STKHid, mySTquantity, mySTDW, mySTDJ, mySTprice, DateTime.Now, mySTnote, "");

            if (myOption == "add")
            {
                Page.RegisterStartupScript("js", "<script>alert(\"" + "" + "\");</script>");
            }
            if (myOption == "edt")
            {
                Page.RegisterStartupScript("js", "<script>alert(\"" + mySTM.UpdateST(myModel) + "\");</script>");

            }
        }
    }
}