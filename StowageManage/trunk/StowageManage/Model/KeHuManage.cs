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
    public class KeHuManage
    {
        /// <summary>
        /// 设置客户对象实例
        /// </summary>
        /// <param name="KHId">ID</param>
        /// <param name="KHName">客户名称</param>
        /// <param name="KHType">类型(供货单位、收货单位)</param>
        /// <param name="KHaddress">地址</param>
        /// <param name="KHtell">电话</param>
        /// <param name="KHnote">备注</param>
        /// <returns>DAO.KEHU</returns>
        public DAO.KEHU SetModel(string KHId, string KHName, string KHType, string KHaddress, string KHtell, string KHnote)
        {
            DAO.KEHU myModel = new DAO.KEHU();
            myModel.KHid = KHId;
            myModel.KHname = KHName;
            myModel.KHtype = KHType;
            myModel.KHaddress = KHaddress;
            myModel.KHtell = KHtell;
            myModel.KHnote = KHnote;

            return myModel;
        }
        /// <summary>
        /// 获取客户对象实例
        /// </summary>
        /// <param name="KHId">ID</param>
        /// <returns>DAO.KEHU</returns>
        public DAO.KEHU GetModel(string KHId)
        {
            DataSet myData = DBUtility.DBHelperSQL.Query("select * from db_kehu where kh_id=" + KHId);
            DAO.KEHU myModel = new DAO.KEHU();
            myModel.KHid = KHId;
            myModel.KHname = myData.Tables[0].Rows[0]["kh_name"].ToString().Trim();
            myModel.KHtype = myData.Tables[0].Rows[0]["kh_type"].ToString().Trim();
            myModel.KHaddress = myData.Tables[0].Rows[0]["kh_address"].ToString().Trim();
            myModel.KHtell = myData.Tables[0].Rows[0]["kh_tell"].ToString().Trim();
            myModel.KHnote = myData.Tables[0].Rows[0]["kh_note"].ToString().Trim();

            return myModel;
        }
        /// <summary>
        /// 添加客户
        /// </summary>
        /// <param name="myDAOKH">DAO.KEHU</param>
        /// <returns>bool 是否成功添加记录</returns>
        public bool AddKH(DAO.KEHU myDAOKH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into db_kehu (");
            strSql.Append("kh_type,kh_name,kh_address,kh_tell,kh_note");
            strSql.Append(")values(");
            strSql.Append("'" + myDAOKH.KHtype + "',");
            strSql.Append("'" + myDAOKH.KHname + "',");
            strSql.Append("'" + myDAOKH.KHaddress + "',");
            strSql.Append("'" + myDAOKH.KHtell + "',");
            strSql.Append("'" + myDAOKH.KHnote + "')");

            int count = DBHelperSQL.ExecuteSql(strSql.ToString());
            //判断是否成功添加记录
            if (count == 1)
            { return true; }
            else
            { return false; }
        }
        /// <summary>
        /// 删除客户记录
        /// </summary>
        /// <param name="KHID">ID</param>
        /// <returns>bool 是否成功删除记录</returns>
        public bool DelKH(String KHID)
        {

            //缺少对使用客户的判断


            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from db_kehu ");
            strSql.Append("where kh_id=" + KHID);
            int count = DBHelperSQL.ExecuteSql(strSql.ToString());
            //判断是否成功删除记录
            if (count == 1)
            { return true; }
            else
            { return false; }

        }
        /// <summary>
        /// 更新客户记录
        /// </summary>
        /// <param name="myDAOKH">DAO.KEHU</param>
        /// <returns>bool 是否成功修改记录</returns>
        public bool UpdateKH(DAO.KEHU myDAOKH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update DB_kehu set ");
            strSql.Append("kh_type='" + myDAOKH.KHtype + "',");
            strSql.Append("kh_name='" + myDAOKH.KHname + "',");
            strSql.Append("kh_address='" + myDAOKH.KHaddress + "',");
            strSql.Append("kh_tell='" + myDAOKH.KHtell + "',");
            strSql.Append("kh_note='" + myDAOKH.KHnote + "'");
            strSql.Append(" where kh_id=" + myDAOKH.KHid);

            int count = DBHelperSQL.ExecuteSql(strSql.ToString());
            //判断是否成功修改记录
            if (count == 1)
            { return true; }
            else
            { return false; }
        }
        /// <summary>
        /// 根据条件查询客户记录
        /// </summary>
        /// <param name="KHID">ID</param>
        /// <param name="KHType">类型(供货单位、收货单位)</param>
        /// <param name="KHName">客户名称</param>
        /// <param name="KHAddress">地址</param>
        /// <param name="KHTell">电话</param>
        /// <returns>DataSet SelectKH</returns>
        public DataSet SelectKH(string KHID, string KHType, string KHName, string KHAddress, string KHTell)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select kh_id,kh_type as '客户类型',kh_name as '客户名称',kh_address as '地址',kh_tell as '电话' ,kh_note as '备注'from DB_kehu");
            strSql.Append(" where 1=1");
            if (KHID != "")
            { strSql.Append(" and kh_id=" + KHID + ""); }
            if (KHType != "" && KHType != "请选择")
            { strSql.Append(" and kh_type='" + KHType + "'"); }
            if (KHName != "")
            { strSql.Append(" and kh_name like '%" + KHName + "%'"); }
            if (KHAddress != "")
            { strSql.Append(" and kh_address like '%" + KHAddress + "%'"); }
            if (KHTell != "")
            { strSql.Append(" and kh_note like '%" + KHTell + "%'"); }

            return DBHelperSQL.Query(strSql.ToString());
        }
    }
}