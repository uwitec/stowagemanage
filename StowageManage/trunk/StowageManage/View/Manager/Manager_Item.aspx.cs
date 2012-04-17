using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StowageManage.View.Manager
{
    public partial class Manager_Item : System.Web.UI.Page
    {
        Control.Manager myMG = new Control.Manager();
        protected void Page_Load(object sender, EventArgs e)
        {
            String myOption = Request.QueryString["option"];
            if (myOption == "add")
            {
                but_Enter.Visible = true;
            }
            if (myOption == "edt")
            {

                but_Enter.Visible = true;


                if (!IsPostBack)
                {
                    String myMGId = Request.QueryString["myMGId"];
                    SetView(myMGId);
                }
            }
            if (myOption == "view")
            {
                if (!IsPostBack)
                {
                    String myMGId = Request.QueryString["myMGId"];
                    SetView(myMGId);
                }
            }
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
        private void SetView(String myMGId)
        {
            DAO.Manager myModel = myMG.GetModel(myMGId);
            txt_MGcontact.Text = myModel.MGcontact;
            txt_MGIDnumber.Text = myModel.MGIDnumber;
            txt_MGname.Text = myModel.MGname;
            txt_MGnote.Text = myModel.MGnote;
            txt_MGnum.Text = myModel.MGnum;
            ddl_MGtype.SelectedValue = myModel.MGtype;
        }

        protected void but_Enter_Click(object sender, EventArgs e)
        {
            String myOption = Request.QueryString["option"];

            string myMGcontact = txt_MGcontact.Text.Trim().Replace("'", "");
            string myMGIDnumber = txt_MGIDnumber.Text.Trim().Replace("'", "");
            string myMGname = txt_MGname.Text.Trim().Replace("'", "");
            string myMGnote = txt_MGnote.Text.Trim().Replace("'", "");
            string myMGnum = txt_MGnum.Text.Trim().Replace("'", "");
            string myMGtype = ddl_MGtype.SelectedValue;
            string myMGid;

            if (Request.QueryString["myMGId"] == null)
            {
                myMGid = "";
            }
            else
            {
                myMGid = Request.QueryString["myMGId"].ToString().Trim().Replace("'", "");
            }

            DAO.Manager myModel = myMG.SetModel(myMGid, myMGname, myMGnum, myMGcontact, myMGIDnumber, myMGtype, myMGnote);

            if (myOption == "add")
            {
                Page.RegisterStartupScript("js", "<script>alert(\"" + myMG.AddMG(myModel) + "\");</script>");
            }
            if (myOption == "edt")
            {
                Page.RegisterStartupScript("js", "<script>alert(\"" + myMG.UpdateMG(myModel) + "\");</script>");

            }
        }
    }
}