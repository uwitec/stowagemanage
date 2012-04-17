using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace StowageManage.View.StorageManager
{
    public partial class StorageAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetDropDownList();
                DataSet myDataSet = new DataSet("myDS");//创建数据集
                DataTable myTable = new DataTable("myTB");//创建数据表
                myDataSet.Tables.Add(myTable);//把数据表添加到数据集中

                //添加列
                myDataSet.Tables["myTB"].Columns.Add("编号");
                myDataSet.Tables["myTB"].Columns.Add("名称");
                myDataSet.Tables["myTB"].Columns.Add("单位");
                myDataSet.Tables["myTB"].Columns.Add("单价");
                myDataSet.Tables["myTB"].Columns.Add("数量");
                myDataSet.Tables["myTB"].Columns.Add("金额");
                myDataSet.Tables["myTB"].Columns.Add("备注");
                //修改表头
                myDataSet.Tables["myTB"].Columns["编号"].Caption = "主ID";//没有效果

                Session["myDataSet"] = myDataSet;
                gv_Storage.DataSource = myDataSet;
                gv_Storage.DataBind();
            }
            //else
            //{
            //    DataSet myDataSet = (DataSet)Session["myDataSet"];
            //    gv_Storage.DataSource = myDataSet;
            //    gv_Storage.DataBind();
            //}
            
        }
        protected void SetDropDownList()
        {
            Control.DropDownList_Source myDDLSource = new Control.DropDownList_Source();

            ddl_Cangku.DataSource = myDDLSource.DDL_CangKu();           
            DDL_DataBind(ddl_Cangku);
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

        protected void but_inster_Click(object sender, EventArgs e)
        {
            string GSnum = txt_GSnum.Text.Trim().Replace("'", "");
            string GSname = ddl_GSname.SelectedItem.Text;
            string STDW = txt_STDW.Text.Trim().Replace("'", "");
            string STDJ = txt_STDJ.Text.Trim().Replace("'", "");
            string STquantity = txt_STquantity.Text.Trim().Replace("'", "");
            string STnote = txt_STnote.Text.Trim().Replace("'", "");
            string mySum = (double.Parse(STDJ) * double.Parse(STquantity)).ToString();//金额

            DataSet myDataSet = (DataSet)Session["myDataSet"];


            //添加行
            DataRow myRow = myDataSet.Tables["myTB"].NewRow();            
            myRow["编号"] = GSnum;
            myRow["名称"] = GSname;
            myRow["单位"] = STDW;
            myRow["单价"] = STDJ;
            myRow["数量"] = STquantity;
            myRow["金额"] = mySum;
            myRow["备注"] = STnote;
            myDataSet.Tables["myTB"].Rows.Add(myRow);
            Session["myDataSet"] = myDataSet;
            gv_Storage.DataSource = myDataSet;
            gv_Storage.DataBind();

            
        }
        protected void gv_Storage_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //隐藏不必要的列 
            if ((e.Row.RowType == DataControlRowType.DataRow) || (e.Row.RowType == DataControlRowType.Header) || (e.Row.RowType == DataControlRowType.Footer))
            {
                //e.Row.Cells[3].Visible = false;
            }
            if (e.Row.RowIndex != -1)
            {
                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#E2F2FF'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
            }
        }
        /// <summary>
        /// 删除指定行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gv_Storage_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string  myGSnum = e.CommandArgument.ToString();
            DataSet myDataSet = (DataSet)Session["myDataSet"];
            if (e.CommandName == "del")
            {
                //删除指定行
                //myDataSet.Tables["myTB"].Rows[myGSnum].Delete();
                //myDataSet.Tables["myTB"].AcceptChanges();
                DataRow[] myDelRows = myDataSet.Tables["myTB"].Select("编号=" + myGSnum);                
                DataRow myDelRow = myDelRows[0];
                myDataSet.Tables["myTB"].Rows.Remove(myDelRow);               
                Session["myDataSet"] = myDataSet;
                gv_Storage.DataSource = myDataSet;
                gv_Storage.DataBind();
            }            
            
        }
        /// <summary>
        /// 把gridview中的数据保存到数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void but_Storage_Click(object sender, EventArgs e)
        {
            //string STID, string STnum, string STCKID, string STGSID, 
            //string STRKMGID, string STYHMGID, string STKHID, int STquantity, 
            //string STDW, decimal STDJ, decimal STprice, DateTime STdate, 
            //string STnote, string STstatus
            //"编号""名称""单位""单价""数量""金额""备注"

            DataSet myDataSet = (DataSet)Session["myDataSet"];
            Control.StorageManage myCSM = new Control.StorageManage();
            Control.GoodsManage myGSM = new Control.GoodsManage();
            Control.Manager myMG=new Control.Manager ();

            string mySTnum = txt_STnum.Text.Trim().Replace("'", "");
            string myCKid = ddl_Cangku.SelectedValue;
            string myKHid = DDL_GHS.SelectedValue;
            decimal mySTPrice = decimal.Parse(txt_price.Text.Trim().Replace("'", ""));
            string myRKMGid = ddl_RKY.SelectedValue;
            string myYHMGid = ddl_YHY.SelectedValue;
            int myCount = myDataSet.Tables["myTB"].Rows.Count;
            DAO.Storage[] myStorages = new DAO.Storage[myCount];
            //把DataSet中的记录实例化，存入数组
            for (int i = 0; i < myCount; i++)
            {
                string myGSid = myGSM.SelectGS("", myDataSet.Tables["myTB"].Rows[i]["名称"].ToString(), "", "", "").Tables[0].Rows[0]["gs_id"].ToString();
                int mySTquantity = int.Parse(myDataSet.Tables["myTB"].Rows[i]["数量"].ToString());
                string mySTdw = myDataSet.Tables["myTB"].Rows[i]["单位"].ToString();
                decimal mySTdj = decimal.Parse(myDataSet.Tables["myTB"].Rows[i]["单价"].ToString());
                string mySTnote = myDataSet.Tables["myTB"].Rows[i]["备注"].ToString();
                DAO.Storage myStorage = myCSM.SetModel("", mySTnum, myCKid, myGSid, myRKMGid, myYHMGid, myKHid, mySTquantity, mySTdw, mySTdj, mySTPrice, DateTime.Now, mySTnote, "");
                myStorages[i] = myStorage;
            }
            //
            Page.RegisterStartupScript("js", "<script>alert('" + myCSM.AddST_More_bool(myStorages) + "');window.location.href='StorageAdd.aspx';</script>");
            
        }
    }
}