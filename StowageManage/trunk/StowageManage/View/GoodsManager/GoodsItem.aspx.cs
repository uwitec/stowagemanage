using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StowageManage.View.GoodsManager
{
    public partial class GoodsItem : System.Web.UI.Page
    {
        Control.GoodsManage myGS = new Control.GoodsManage();
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
                    String myGSId = Request.QueryString["myGSId"];
                    SetView(myGSId);
                }
            }
            if (myOption == "view")
            {
                if (!IsPostBack)
                {
                    String myGSId = Request.QueryString["myGSId"];
                    SetView(myGSId);
                }
            }
        }
        private void SetView(String GSId)
        {
            DAO.goods myModel = myGS.GetModel(GSId);
            txt_GSname.Text = myModel.GSname;
            txt_GSnum.Text = myModel.GSnum;
            txt_GStype.Text = myModel.GStype;
            txt_GSnote.Text = myModel.GSnote;
        }

        protected void but_Enter_Click(object sender, EventArgs e)
        {
            String myOption = Request.QueryString["option"];
            DAO.goods myModel = new DAO.goods();
            myModel.GSname = txt_GSname.Text.ToString().Trim().Replace("'", "");
            myModel.GSnum = txt_GSnum.Text.ToString().Trim().Replace("'", "");
            myModel.GStype = txt_GStype.Text.ToString().Trim().Replace("'", "");
            myModel.GSnote = txt_GSnote.Text.ToString().Trim().Replace("'", "");
            
            if (Request.QueryString["myGSid"] == null)
            {
                myModel.GSid = "";
            }
            else
            { 
                myModel.GSid = Request.QueryString["myGSid"].ToString().Trim().Replace("'",""); 
            }

            if (myOption == "add")
            {                
                Page.RegisterStartupScript("js", "<script>alert(\"" + myGS.AddGS(myModel) + "\");</script>");                
            }
            if (myOption == "edt")
            {
                Page.RegisterStartupScript("js", "<script>alert(\"" + myGS.UpdateGS(myModel) + "\");</script>");
                
            }
        }
    }
}