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
    public class CangKuManage
    {
        /// <summary>
        /// 设置对象实例
        /// </summary>
        /// <param name="CKId">ID</param>
        /// <param name="CKName">仓库名称</param>
        /// <param name="CKType">仓库类型</param>
        /// <param name="CKNote">备注</param>
        /// <returns>DAO.Cangku </returns>
        public DAO.Cangku SetModel(string CKId,string CKName,string CKType,string CKNote)
        {
            DAO.Cangku myModel = new DAO.Cangku();
            myModel.CKid = CKId;
            myModel.CKname = CKName;
            myModel.CKtype = CKType;
            myModel.CKnote = CKNote;

            return myModel;
        }
        /// <summary>
        /// 根据仓库ID获取对象实例
        /// </summary>
        /// <param name="CKId">ID</param>
        /// <returns>DAO.Cangku 仓库对象</returns>
        public DAO.Cangku GetModel(String CKId)
        {
            DataSet myData = DBHelperSQL.Query("select * from db_cangku where ck_id=" + CKId);
            DAO.Cangku myModel = new DAO.Cangku();
            if (myData.Tables[0].Rows.Count > 0)
            {
                myModel.CKid = CKId;
                myModel.CKname = myData.Tables[0].Rows[0]["ck_name"].ToString();
                myModel.CKtype = myData.Tables[0].Rows[0]["ck_type"].ToString();
                myModel.CKnote = myData.Tables[0].Rows[0]["ck_note"].ToString();

                return myModel;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 添加记录
        /// </summary>
        /// <param name="myDAOCK">DAO.Cangku</param>
        /// <returns>bool 是否成功添加记录</returns>
        public bool AddCK(DAO.Cangku myDAOCK)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into db_cangku (");
            strSql.Append("ck_name,ck_type,ck_note");
            strSql.Append(")values(");
            strSql.Append("'" + myDAOCK.CKname + "',");
            strSql.Append("'" + myDAOCK.CKtype + "',");
            strSql.Append("'" + myDAOCK.CKnote + "')");

            int count = DBHelperSQL.ExecuteSql(strSql.ToString());
            //判断是否成功添加记录
            if (count == 1)
            { return true; }
            else
            { return false; }
        }
        /// <summary>
        /// 根据ID删除记录
        /// </summary>
        /// <param name="CKID">ID</param>
        /// <returns>bool</returns>
        public bool DelCK(String CKID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from db_cangku ");
            strSql.Append("where ck_id=" + CKID);
            int count = DBHelperSQL.ExecuteSql(strSql.ToString());
            if (count == 1)
            { return true; }
            else
            { return false; }
        }
        /// <summary>
        /// 根据ID修改数据
        /// </summary>
        /// <param name="myDAOCK">DAO.Cangku</param>
        /// <returns>bool</returns>
        public bool UpdateCK(DAO.Cangku myDAOCK)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update db_cangku set ");
            strSql.Append("ck_name='" + myDAOCK.CKname + "',");
            strSql.Append("ck_type='" + myDAOCK.CKtype + "',");
            strSql.Append("ck_note='" + myDAOCK.CKnote + "'");
            strSql.Append(" where ck_id=" + myDAOCK.CKid);

            int count = DBHelperSQL.ExecuteSql(strSql.ToString());
            if (count == 1)
            { return true; }
            else
            { return false; }
        }
        /// <summary>
        /// 根据条件查询记录
        /// </summary>
        /// <param name="CKID">ID</param>
        /// <param name="CKName">仓库名称</param>
        /// <param name="CKType">仓库类型</param>
        /// <returns>DataSet</returns>
        public DataSet SelectCK(string CKID, string CKName, string CKType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ck_id,ck_name as '仓库名称',ck_type as '仓库类型',ck_note as '备注' from db_cangku");
            strSql.Append(" where 1=1");
            if (CKID != "")
            { strSql.Append(" and ck_id=" + CKID + ""); }
            if (CKName != "")
            { strSql.Append(" and ck_name like '%" + CKName + "%'"); }
            if (CKType != "")
            { strSql.Append(" and ck_type='" + CKType + "'"); }            

            return DBHelperSQL.Query(strSql.ToString());
        }
    }
}