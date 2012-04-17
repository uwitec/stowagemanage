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
    public class Manager
    {
        /// <summary>
        /// 设置人员对象实例
        /// </summary>
        /// <param name="MGId">ID</param>
        /// <param name="MGName">姓名</param>
        /// <param name="MGnum">工号</param>
        /// <param name="MGContact">联系方式</param>
        /// <param name="MGIDnumber">身份证号</param>
        /// <param name="MGtype">职位</param>
        /// <param name="MGNote">备注</param>
        /// <returns>DAO.Manager</returns>
        public DAO.Manager SetModel(string MGId, string MGName, string MGnum, string MGContact, string MGIDnumber, string MGtype,string MGNote)
        {
            DAO.Manager myModel = new DAO.Manager();
            myModel.MGid = MGId;
            myModel.MGname = MGName;
            myModel.MGnum = MGnum;
            myModel.MGcontact = MGContact;
            myModel.MGIDnumber = MGIDnumber;
            myModel.MGtype = MGtype;
            myModel.MGnote = MGNote;

            return myModel;
        }
        /// <summary>
        /// 获取客户对象实例
        /// </summary>
        /// <param name="MGId">ID</param>
        /// <returns>DAO.Manager</returns>
        public DAO.Manager GetModel(string MGId)
        {
            DataSet myData = DBUtility.DBHelperSQL.Query("select * from db_Manager where mg_id=" + MGId);
            DAO.Manager myModel = new DAO.Manager();
            myModel.MGid = MGId;
            myModel.MGname = myData.Tables[0].Rows[0]["mg_name"].ToString().Trim();
            myModel.MGnum = myData.Tables[0].Rows[0]["mg_num"].ToString().Trim();
            myModel.MGcontact = myData.Tables[0].Rows[0]["mg_contact"].ToString().Trim();
            myModel.MGIDnumber = myData.Tables[0].Rows[0]["mg_IDnumber"].ToString().Trim();
            myModel.MGtype = myData.Tables[0].Rows[0]["mg_type"].ToString().Trim();
            myModel.MGnote = myData.Tables[0].Rows[0]["mg_note"].ToString().Trim();

            return myModel;
        }
        /// <summary>
        /// 添加人员
        /// </summary>
        /// <param name="myDAOMG">DAO.Manager</param>
        /// <returns>bool 是否成功添加记录</returns>
        public bool AddMG(DAO.Manager myDAOMG)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into db_Manager (");
            strSql.Append("mg_name,mg_num,mg_contact,mg_IDnumber,mg_type,mg_note");
            strSql.Append(")values(");
            strSql.Append("'" + myDAOMG.MGname + "',");
            strSql.Append("'" + myDAOMG.MGnum + "',");
            strSql.Append("'" + myDAOMG.MGcontact + "',");
            strSql.Append("'" + myDAOMG.MGIDnumber + "',");
            strSql.Append("'" + myDAOMG.MGtype + "',");
            strSql.Append("'" + myDAOMG.MGnote + "')");

            int count = DBHelperSQL.ExecuteSql(strSql.ToString());
            //判断是否成功添加记录
            if (count == 1)
            { return true; }
            else
            { return false; }
        }
        /// <summary>
        /// 删除人员记录
        /// </summary>
        /// <param name="MGID">ID</param>
        /// <returns>bool 是否成功删除记录</returns>
        public bool DelMG(String MGID)
        {

            //缺少对使用客户的判断


            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from db_Manager ");
            strSql.Append("where mg_id=" + MGID);
            int count = DBHelperSQL.ExecuteSql(strSql.ToString());
            
            //判断是否成功删除记录
            if (count == 1)
            { return true; }
            else
            { return false; }

        }
         /// <summary>
        /// 更新人员记录
        /// </summary>
        /// <param name="myDAOMG">DAO.Manager</param>
        /// <returns>bool 是否成功修改记录</returns>
        public bool UpdateMG(DAO.Manager myDAOMG)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update DB_manager set ");
            strSql.Append("mg_name='" + myDAOMG.MGname + "',");
            strSql.Append("mg_num='" + myDAOMG.MGnum + "',");
            strSql.Append("mg_contact='" + myDAOMG.MGcontact + "',");
            strSql.Append("mg_IDnumber='" + myDAOMG.MGIDnumber + "',");
            strSql.Append("mg_type='" + myDAOMG.MGtype + "',");
            strSql.Append("mg_note='" + myDAOMG.MGnote + "'");
            strSql.Append(" where mg_id=" + myDAOMG.MGid);

            int count = DBHelperSQL.ExecuteSql(strSql.ToString());
            //判断是否成功修改记录
            if (count == 1)
            { return true; }
            else
            { return false; }
        }
        /// <summary>
        /// 根据条件查询人员记录
        /// </summary>
        /// <param name="MGID">ID</param>
        /// <param name="MGname">姓名</param>
        /// <param name="MGnum">工号</param>
        /// <param name="MGcontact">联系方式</param>
        /// <param name="MGIDnumber">身份证号</param>
        /// <param name="MGtype">职位</param>
        /// <returns>DataSet SelectMG</returns>
        public DataSet SelectMG(string MGID, string MGname, string MGnum, string MGcontact, string MGIDnumber, string MGtype)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select mg_id,mg_name as '姓名',mg_num as '工号',mg_type as '职位',mg_contact as '联系方式',mg_IDnumber as '身份证号' ,mg_note as '备注' from DB_manager");
            strSql.Append(" where 1=1");
            if (MGID != "")
            { strSql.Append(" and mg_id=" + MGID + ""); }
            if (MGname != "")
            { strSql.Append(" and mg_name like '%" + MGname + "%'"); }
            if (MGnum != "")
            { strSql.Append(" and mg_num like '%" + MGnum + "%'"); }
            if (MGcontact != "")
            { strSql.Append(" and mg_contact like '%" + MGcontact + "%'"); }
            if (MGIDnumber != "")
            { strSql.Append(" and mg_IDnumber like '%" + MGIDnumber + "%'"); }
            if (MGtype != "" && MGtype != "0")
            { strSql.Append(" and mg_type = '" + MGtype + "'"); }

            return DBHelperSQL.Query(strSql.ToString());
        }
    }
}