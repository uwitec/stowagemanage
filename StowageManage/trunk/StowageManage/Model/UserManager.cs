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
    public class UserManager
    {
        /// <summary>
        /// 设置对象实例
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <param name="UserName">用户名</param>
        /// <param name="Password">密码</param>
        /// <param name="Usertype">用户类型</param>
        /// <returns>DAO.User Model 用户对象</returns>
        public DAO.User SetModel(String UserID, String UserName, String Password, String Usertype)
        {
            DAO.User myModel = new DAO.User();
            myModel.Usid = UserID;
            myModel.Usname = UserName;
            myModel.Uspassword = Password;
            myModel.Ustype = Usertype;

            return myModel;
        }
        /// <summary>
        /// 根据用户ID获取对象实例
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <returns>DAO.User Model 用户对象</returns>
        public DAO.User GetModel(String UserID)
        {
            DataSet myData = DBHelperSQL.Query("select * from db_user where us_id=" + UserID);
            DAO.User myModel = new DAO.User();
            if (myData.Tables[0].Rows.Count > 0)
            {
                myModel.Usid = UserID;
                myModel.Usname = myData.Tables[0].Rows[0]["us_name"].ToString();
                myModel.Uspassword = myData.Tables[0].Rows[0]["us_password"].ToString();
                myModel.Ustype = myData.Tables[0].Rows[0]["us_type"].ToString();

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
        /// <param name="myDAOUser">DAO.User</param>
        /// <returns>bool 是否成功添加记录</returns>
        public bool AddUser(DAO.User myDAOUser)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into DB_USER (");
            strSql.Append("us_name,us_password,us_type");
            strSql.Append(")values(");
            strSql.Append("'" + myDAOUser.Usname + "',");
            strSql.Append("'" + myDAOUser.Uspassword + "',");
            strSql.Append("'" + myDAOUser.Ustype + "')");

            int count = DBHelperSQL.ExecuteSql(strSql.ToString());
            //判断是否成功添加记录
            if (count == 1)
            { return true;}
            else
            { return false; }
        }
        /// <summary>
        /// 根据UserID删除记录
        /// </summary>
        /// <param name="UserID">ID</param>
        /// <returns>bool</returns>
        public bool DelUser(String UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from DB_USER ");
            strSql.Append("where us_id=" + UserID);
            int count = DBHelperSQL.ExecuteSql(strSql.ToString());
            if (count == 1)
            { return true; }
            else
            { return false; }
        }
        /// <summary>
        /// 根据UserID修改记录
        /// </summary>
        /// <param name="UserID">ID</param>
        /// <param name="UserName">用户名</param>
        /// <param name="Password">密码</param>
        /// <param name="UserType">类别</param>
        /// <returns></returns>
        public bool UpdateUser(DAO.User myDAOUser)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update DB_USER set ");
            strSql.Append("us_name='" + myDAOUser.Usname + "',");
            strSql.Append("us_password='" + myDAOUser.Uspassword + "',");
            strSql.Append("us_type='" + myDAOUser.Ustype + "'");
            strSql.Append(" where us_id=" + myDAOUser.Usid);

            int count = DBHelperSQL.ExecuteSql(strSql.ToString());
            if (count == 1)
            { return true; }
            else
            { return false; }
        }
       
        /// <summary>
        /// 根据条件查询用户记录
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <param name="UserName">用户名</param>
        /// <param name="Password">密码</param>
        /// <param name="Usertype">用户类型</param>
        /// <returns></returns>
        public DataSet SelectUser(string UserID,string UserName, string Password, string Usertype)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select us_id,us_name as '用户名',us_password as '登录密码',us_type as '用户类型' from db_user");
            strSql.Append(" where 1=1");
            if (UserID != "")
            { strSql.Append(" and us_id=" + UserID + ""); }
            if (UserName != "")
            { strSql.Append(" and us_name='" + UserName + "'"); }
            if (Password != "")
            { strSql.Append(" and us_password='" + Password + "'"); }
            if (Usertype != "")
            { strSql.Append(" and us_type='" + Usertype + "'"); }

            return DBHelperSQL.Query(strSql.ToString());
        }
    }
}