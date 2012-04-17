using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBUtility;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace StowageManage.Model
{
    public class StockManage
    {
        /// <summary>
        /// 设置对象实例
        /// </summary>
        /// <param name="SKid">ID</param>
        /// <param name="SKCKid">仓库</param>
        /// <param name="SKGSid">物品</param>
        /// <param name="SKquantity">数量</param>
        /// <returns>DAO.Stock</returns>
        public DAO.Stock SetModel(string SKid,string SKCKid,string SKGSid,int SKquantity)
        {
            DAO.Stock myModel = new DAO.Stock();
            myModel.SKid = SKid;
            myModel.SKCKid = SKCKid;
            myModel.SKGSid = SKGSid;
            myModel.SKquantity = SKquantity;
            return myModel;
        }
        /// <summary>
        /// 获取对象实例
        /// </summary>
        /// <param name="SKid">库存ID</param>
        /// <returns>DAO.Stock</returns>
        public DAO.Stock GetModel(string SKid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from db_stock where sk_id="+SKid);
            DataSet myDS = DBHelperSQL.Query(strSql.ToString());
            DAO.Stock myModel = new DAO.Stock();
            if(myDS.Tables[0].Rows.Count>0)
            {
            myModel.SKid = SKid;
            myModel.SKCKid = myDS.Tables[0].Rows[0]["SK_CK_ID"].ToString().Trim();
            myModel.SKGSid = myDS.Tables[0].Rows[0]["SK_GS_ID"].ToString().Trim();
            myModel.SKquantity =int.Parse( myDS.Tables[0].Rows[0]["SK_quantity"].ToString());

            return myModel;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 判断指定仓库的指定物品是否存在
        /// </summary>
        /// <param name="myDAOSK">DAO.Stock</param>
        /// <returns>bool</returns>
        public bool equalsStock(DAO.Stock myDAOSK)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from db_stock where sk_ck_id=" + myDAOSK.SKCKid + " and sk_gs_id=" + myDAOSK.SKGSid);
            DataSet ds = DBHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count == 1)
            { return true; }
            else
            { return false; }
        }
        /// <summary>
        /// 添加记录
        /// </summary>
        /// <param name="myDAOSK">DAO.Stock</param>
        /// <returns>bool</returns>
        public bool AddSK(DAO.Stock myDAOSK)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into db_stock (");
            strSql.Append("sk_ck_id,sk_gs_id,sk_quantity");
            strSql.Append(")values(");
            strSql.Append("'" + myDAOSK.SKCKid + "',");
            strSql.Append("'" + myDAOSK.SKGSid + "',");
            strSql.Append("" + myDAOSK.SKquantity + ")");

            int count = DBHelperSQL.ExecuteSql(strSql.ToString());
            //判断是否成功添加记录
            if (count == 1)
            { return true; }
            else
            { return false; }
        }
        
        /// <summary>
        /// 删除1条库存记录
        /// </summary>
        /// <param name="SKID">库存ID</param>
        /// <returns>bool</returns>
        public bool DelSK(String SKID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from db_stock ");
            strSql.Append("where SK_id=" + SKID);
            int count = DBHelperSQL.ExecuteSql(strSql.ToString());
            
            if (count == 1)
            { return true; }
            else
            { return false; }
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="myDAOSK">DAO.Stock</param>
        /// <returns>bool</returns>
        public bool UpdateSK(DAO.Stock myDAOSK)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update db_stock set ");
            strSql.Append("sk_ck_id='" + myDAOSK.SKCKid + "',");
            strSql.Append("sk_gs_id='" + myDAOSK.SKGSid + "',");
            strSql.Append("sk_quantity=" + myDAOSK.SKquantity + "");
            strSql.Append(" where sk_id=" + myDAOSK.SKid);

            int count = DBHelperSQL.ExecuteSql(strSql.ToString());
            if (count == 1)
            { return true; }
            else
            { return false; }
        }
        /// <summary>
        /// 根据条件查询仓库记录
        /// </summary>
        /// <param name="SKCKid">仓库ID</param>
        /// <param name="SKGSid">物品ID</param>
        /// <returns>DataSet</returns>
        public DataSet SelectStock(string SKCKid,string SKGSid)
        {
            //仓库、物品、
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select (select ck_name from db_cangku where ck_id=sk_ck_id) as '仓库名称',(select gs_name from db_goods where gs_id=sk_gs_id) as '物品名称' from db_stock");
            strSql.Append(" where 1=1");
            if (SKCKid != "")
            { strSql.Append(" and sk_ck_id=" + SKCKid + ""); }
            if (SKGSid != "")
            { strSql.Append(" and sk_gs_id =" + SKGSid + ""); }
            

            return DBHelperSQL.Query(strSql.ToString());
        }
    }
}