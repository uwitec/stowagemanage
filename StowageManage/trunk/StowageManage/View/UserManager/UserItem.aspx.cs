using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls; 


namespace StowageManage.Control
{
    public partial class UserItem : System.Web.UI.Page
    {
        StowageManage.Control.UserManager myUser = new UserManager();

        protected void Page_Load(object sender, EventArgs e)
        {  
            String myOption = Request.QueryString["option"];
            if (myOption == "add")
            {
                lab_Password2.Visible = true;
                txt_Password2.Visible = true;
                         
                bun_Enter.Visible = true;
                
            }
            if (myOption == "edt")
            {
                lab_Password2.Visible = true;
                txt_Password2.Visible = true;

                bun_Enter.Visible = true;


                if (!IsPostBack)
                {
                    String myUserId = Request.QueryString["myUserId"];
                    SetView(myUserId);
                }
            }
            if (myOption == "view")
            {
                ddl_Usertype.Enabled = false;
                if (!IsPostBack)
                {
                    String myUserId = Request.QueryString["myUserId"];
                    SetView(myUserId);
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

            ddl_Usertype.DataSource = myDDLSource.DDL_User_Type();
            DDL_DataBind(ddl_Usertype);


        }
        protected void DDL_DataBind(DropDownList DDL)
        {
            DDL.DataTextField = "text";
            DDL.DataValueField = "value";
            DDL.DataBind();
        }
        private void SetView(String UserId)
        {
            String myUserId = UserId;
            DAO.User myModel = myUser.GetModel(myUserId);
            txt_UserName.Text = myModel.Usname;
            txt_Password1.Text = myModel.Uspassword;
            txt_Password2.Text = myModel.Uspassword;
            ddl_Usertype.SelectedValue = myModel.Ustype.Trim();
        }
        protected void bun_Enter_Click(object sender, EventArgs e)
        {
            String myOption = Request.QueryString["option"];
            if (myOption == "add")
            {
                String myUserName = txt_UserName.Text.ToString().Trim().Replace("'", "");
                String myUserType = ddl_Usertype.SelectedValue.ToString();
                String myPSD1 = txt_Password1.Text.ToString().Trim().Replace("'", "");
                String myPSD2 = txt_Password2.Text.ToString().Trim().Replace("'", "");
                if (myPSD1 == myPSD2)
                {
                    
                    StowageManage.DAO.User myModel = myUser.SetModel("", myUserName, myPSD1, myUserType);
                    Page.RegisterStartupScript("js", "<script>alert(\"" + myUser.AddUser(myModel) + "\");</script>");
                    //Page.ClientScript.RegisterStartupScript(this.GetType, "", "");
                    
                }
                else
                {
                    Page.RegisterStartupScript("js", "<script>alert(\"密码不相同\");</script>");
                }
            }
            if (myOption == "edt")
            {
                String myUserId = Request.QueryString["myUserId"].Trim().Replace("'","");

                String myUserName = txt_UserName.Text.ToString().Trim().Replace("'", "");
                String myUserType = ddl_Usertype.SelectedValue.ToString();
                String myPSD1 = txt_Password1.Text.ToString().Trim().Replace("'", "");
                String myPSD2 = txt_Password2.Text.ToString().Trim().Replace("'", "");
                if (myPSD1 == myPSD2)
                {
                    
                    StowageManage.DAO.User myModel = myUser.SetModel(myUserId, myUserName, myPSD1, myUserType);
                    Page.RegisterStartupScript("js", "<script>alert(\"" + myUser.updateUser(myModel) + "\");</script>");


                }
                else
                {
                    Page.RegisterStartupScript("js", "<script>alert(\"密码不相同\");</script>");
                }
            }
        }
    }
}