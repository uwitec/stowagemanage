using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls; 


namespace StowageManage.View.CangKuManager
{
    public partial class CangKuItem : System.Web.UI.Page
    {
        StowageManage.Control.CangKuManage myCKM = new Control.CangKuManage();

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
                    String myCKId = Request.QueryString["myCKId"];
                    SetView(myCKId);
                }
            }
            if (myOption == "view")
            {
                if (!IsPostBack)
                {
                    String myCKId = Request.QueryString["myCKId"];
                    SetView(myCKId);
                }
            }

        }
        private void SetView(string myCKId)
        {
            DAO.Cangku myModel = myCKM.GetModel(myCKId);
            txt_CKname.Text = myModel.CKname;
            txt_CKtype.Text = myModel.CKname;
            txt_CKnote.Text = myModel.CKnote;
        }

        protected void but_Enter_Click(object sender, EventArgs e)
        {
            String myOption = Request.QueryString["option"];
            DAO.Cangku myModel = new DAO.Cangku();
            myModel.CKname = txt_CKname.Text.ToString().Trim().Replace("'", "");
            myModel.CKname = txt_CKtype.Text.ToString().Trim().Replace("'", "");
            myModel.CKnote = txt_CKnote.Text.ToString().Trim().Replace("'", "");
   
            if (Request.QueryString["myCKId"] == null)
            {
                myModel.CKid = "";
            }
            else
            {
                myModel.CKid = Request.QueryString["myCKId"].ToString().Trim().Replace("'", "");
            }

            if (myOption == "add")
            {
                Page.RegisterStartupScript("js", "<script>alert(\"" + myCKM.AddCK(myModel) + "\");</script>");
            }
            if (myOption == "edt")
            {
                Page.RegisterStartupScript("js", "<script>alert(\"" + myCKM.UpdateCK(myModel) + "\");</script>");

            }
        }
    }
}