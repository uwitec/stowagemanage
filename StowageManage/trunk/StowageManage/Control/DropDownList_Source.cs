using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace StowageManage.Control
{
    public class DropDownList_Source
    {
        /// <summary>
        /// 仓库下拉列表数据源
        /// </summary>
        /// <returns>DataSet</returns>
        public DataSet DDL_CangKu()
        {
            DataSet myDS = DBUtility.DBHelperSQL.Query("select ck_name as text,ck_id as value from db_cangku");
            DataTable myTB = myDS.Tables[0];

            DataRow myRow = myTB.NewRow();
            myRow["text"] = "请选择";
            myRow["value"] = "0";
            myTB.Rows.InsertAt(myRow, 0);
            return myDS;
        }
        /// <summary>
        /// 物品下拉列表数据源
        /// </summary>
        /// <returns>DataSet</returns>
        public DataSet DDL_Goods()
        {
            DataSet myDS = DBUtility.DBHelperSQL.Query("select gs_name as text,gs_id as value from db_Goods");
            DataTable myTB = myDS.Tables[0];

            DataRow myRow = myTB.NewRow();
            myRow["text"] = "请选择";
            myRow["value"] = "0";
            myTB.Rows.InsertAt(myRow, 0);
            return myDS;
        }
        /// <summary>
        /// 客户下拉列表数据源
        /// </summary>
        /// <returns>DataSet</returns>
        public DataSet DDL_KeHu()
        {
            DataSet myDS = DBUtility.DBHelperSQL.Query("select kh_name as text,kh_id as value from db_kehu");
            DataTable myTB = myDS.Tables[0];

            DataRow myRow = myTB.NewRow();
            myRow["text"] = "请选择";
            myRow["value"] = "0";
            myTB.Rows.InsertAt(myRow, 0);
            return myDS;
        }
        /// <summary>
        /// 员工下拉列表数据源
        /// </summary>
        /// <returns>DataSet</returns>
        public DataSet DDL_Manager()
        {
            DataSet myDS = DBUtility.DBHelperSQL.Query("select mg_name as text,mg_id as value from db_manager");
            DataTable myTB = myDS.Tables[0];

            DataRow myRow = myTB.NewRow();
            myRow["text"] = "请选择";
            myRow["value"] = "0";
            myTB.Rows.InsertAt(myRow, 0);
            return myDS;
        }
        public DataSet DDL_Manager_Type()
        {
            DataSet myDS = new DataSet();
            DataTable myTB = new DataTable("table");
            myDS.Tables.Add(myTB);
            myTB.Columns.Add("text");
            myTB.Columns.Add("value");
           
            myTB.Rows.Add(AddRows(myTB,"请选择", "0"));
            myTB.Rows.Add(AddRows(myTB,"会计", "1"));
            myTB.Rows.Add(AddRows(myTB, "杂工", "2"));
            myTB.Rows.Add(AddRows(myTB, "验货员", "3"));
            myTB.Rows.Add(AddRows(myTB, "入库员", "4"));
            return myDS;
        }
        public DataSet DDL_User_Type()
        {
            DataSet myDS = new DataSet();
            DataTable myTB = new DataTable("table");
            myDS.Tables.Add(myTB);
            myTB.Columns.Add("text");
            myTB.Columns.Add("value");

            myTB.Rows.Add(AddRows(myTB, "请选择", "0"));
            myTB.Rows.Add(AddRows(myTB, "管理员", "1"));
            myTB.Rows.Add(AddRows(myTB, "会计", "2"));
            
            return myDS;
        }
        private DataRow AddRows(DataTable myTB,string Text, string Value)
        {

            DataRow myRow = myTB.NewRow();
            myRow["text"] = Text;
            myRow["value"] = Value;
            
            return myRow;
        }
    }
}