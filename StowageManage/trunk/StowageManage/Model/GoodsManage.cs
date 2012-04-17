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
    public class GoodsManage
    {
        /// <summary>
        /// 设置物品对象实例
        /// </summary>
        /// <param name="GSID">ID</param>
        /// <param name="GSName">物品名称</param>
        /// <param name="GSNum">物品编号</param>
        /// <param name="GSType">物品类型</param>
        /// <param name="GSNote">备注</param>
        /// <returns>DAO.goods Model 物品对象</returns>
        public DAO.goods SetModel(string GSID, string GSName, string GSNum, string GSType, string GSNote)
        {
            DAO.goods myModel = new DAO.goods();
            myModel.GSid = GSID;
            myModel.GSname = GSName;
            myModel.GSnum = GSNum;
            myModel.GStype = GSType;
            myModel.GSnote = GSType;

            return myModel;
        }
        /// <summary>
        /// 获取物品对象实例
        /// </summary>
        /// <param name="GSID">ID</param>
        /// <returns>DAO.goods Model 物品对象</returns>
        public DAO.goods GetModel(string GSID)
        {
            DataSet myData = DBUtility.DBHelperSQL.Query("select * from db_goods where gs_id=" + GSID);
            DAO.goods myModel = new DAO.goods();
            myModel.GSid = GSID;
            myModel.GSname = myData.Tables[0].Rows[0]["gs_name"].ToString().Trim();
            myModel.GSnum = myData.Tables[0].Rows[0]["gs_num"].ToString().Trim();
            myModel.GStype = myData.Tables[0].Rows[0]["gs_type"].ToString().Trim();
            myModel.GSnote = myData.Tables[0].Rows[0]["gs_note"].ToString().Trim();

            return myModel;
        }
        /// <summary>
        /// 添加物品
        /// </summary>
        /// <param name="myDAOGS">DAO.goods</param>
        /// <returns>bool 否成功添加记录</returns>
        public bool AddGS(DAO.goods myDAOGS)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into db_goods (");
            strSql.Append("gs_name,gs_num,gs_type,gs_note");
            strSql.Append(")values(");
            strSql.Append("'" + myDAOGS.GSname + "',");
            strSql.Append("'" + myDAOGS.GSnum + "',");
            strSql.Append("'" + myDAOGS.GStype + "',");
            strSql.Append("'" + myDAOGS.GSnote + "')");

            int count = DBHelperSQL.ExecuteSql(strSql.ToString());
            //判断是否成功添加记录
            if (count == 1)
            { return true; }
            else
            { return false; }
        }
        /// <summary>
        /// 删除物品
        /// </summary>
        /// <param name="GSID">ID</param>
        /// <returns>bool 是否成功删除记录</returns>
        public bool DelGS(String GSID)
        {

            //缺少对使用物品的判断


            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from DB_goods ");
            strSql.Append("where gs_id=" + GSID);
            int count = DBHelperSQL.ExecuteSql(strSql.ToString());
            //判断是否成功删除记录
            if (count == 1)
            { return true; }
            else
            { return false; }
            
        }
        /// <summary>
        /// 更新物品
        /// </summary>
        /// <param name="myDAOGS">DAO.goods</param>
        /// <returns>bool 是否成功修改记录</returns>
        public bool UpdateGS(DAO.goods myDAOGS)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update DB_goods set ");
            strSql.Append("gs_name='" + myDAOGS.GSname + "',");
            strSql.Append("gs_num='" + myDAOGS.GSnum + "',");
            strSql.Append("gs_type='" + myDAOGS.GStype + "',");
            strSql.Append("gs_note='" + myDAOGS.GSnote + "'");
            strSql.Append(" where gs_id=" + myDAOGS.GSid);

            int count = DBHelperSQL.ExecuteSql(strSql.ToString());
            //判断是否成功修改记录
            if (count == 1)
            { return true; }
            else
            { return false; }
        }
        /// <summary>
        /// 根据条件查询物品记录
        /// </summary>
        /// <param name="GSID">ID</param>
        /// <param name="GSName">物品名称</param>
        /// <param name="GSNum">物品编号</param>
        /// <param name="GSType">物品类型</param>
        /// <param name="GSNote">备注</param>
        /// <returns></returns>
        public DataSet SelectGS(string GSID, string GSName, string GSNum, string GSType,string GSNote)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select gs_id,gs_num as '物品编号',gs_name as '物品名称',gs_type as '物品类型',gs_note as '备注' from db_goods");
            strSql.Append(" where 1=1");
            if (GSID != "")
            { strSql.Append(" and gs_id=" + GSID + ""); }
            if (GSName != "")
            { strSql.Append(" and gs_name like '%" + GSName + "%'"); }
            if (GSNum != "")
            { strSql.Append(" and gs_num like '%" + GSNum + "%'"); }
            if (GSType != "")
            { strSql.Append(" and gs_type='" + GSType + "'"); }
            if (GSNote != "")
            { strSql.Append(" and gs_note like '%" + GSNote + "%'"); }

            return DBHelperSQL.Query(strSql.ToString());
        }
    }
}