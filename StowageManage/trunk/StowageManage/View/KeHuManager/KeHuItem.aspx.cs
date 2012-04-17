using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StowageManage.View.KeHuManager
{
    public partial class KeHuItem : System.Web.UI.Page
    {
        Control.KeHuManage myKHM = new Control.KeHuManage();

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
                    String myKHId = Request.QueryString["myKHId"];
                    SetView(myKHId);
                }
            }
            if (myOption == "view")
            {
                if (!IsPostBack)
                {
                    String myKHId = Request.QueryString["myKHId"];
                    SetView(myKHId);
                }
            }
        }
        private void SetView(String myKHId)
        {
            DAO.KEHU myModel = myKHM.GetModel(myKHId);
            txt_KHname.Text = myModel.KHname;
            txt_KHaddress.Text = myModel.KHaddress;
            txt_KHtell.Text = myModel.KHtell;
            txt_KHnote.Text = myModel.KHnote;
            ddl_KHtype.SelectedValue = myModel.KHtype;
            
        }

        protected void but_Enter_Click(object sender, EventArgs e)
        {
            String myOption = Request.QueryString["option"];
            
            string myKHname = txt_KHname.Text.ToString().Trim().Replace("'", "");
            string myKHaddress = txt_KHaddress.Text.ToString().Trim().Replace("'", "");
            string myKHtell = txt_KHtell.Text.ToString().Trim().Replace("'", "");
            string myKHnote = txt_KHnote.Text.ToString().Trim().Replace("'", "");
            string myKHtype = ddl_KHtype.SelectedValue.ToString().Trim().Replace("'", "");
            string myKHid;

            if (Request.QueryString["myKHId"] == null)
            {
                myKHid = "";
            }
            else
            {
                myKHid = Request.QueryString["myKHId"].ToString().Trim().Replace("'", "");
            }

            DAO.KEHU myModel = myKHM.SetModel(myKHid, myKHname, myKHtype, myKHaddress, myKHtell, myKHnote);
            
            if (myOption == "add")
            {
                Page.RegisterStartupScript("js", "<script>alert(\"" + myKHM.AddKH(myModel) + "\");</script>");
            }
            if (myOption == "edt")
            {
                Page.RegisterStartupScript("js", "<script>alert(\"" + myKHM.UpdateKH(myModel) + "\");</script>");

            }
        }
    }
}