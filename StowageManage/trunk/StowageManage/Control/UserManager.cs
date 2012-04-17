using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using StowageManage.Model;

namespace StowageManage.Control
{
    public class UserManager
    {
        Model.UserManager myUser = new Model.UserManager();
        /// <summary>
        /// 设置对象属性
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <param name="UserName">用户名</param>
        /// <param name="Password">密码</param>
        /// <param name="Usertype">用户类型</param>
        public StowageManage.DAO.User SetModel(String UserID, String UserName, String Password, String Usertype)
        {
            return myUser.SetModel(UserID, UserName, Password, Usertype);
        }
        /// <summary>
        /// 获取对象
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <returns></returns>
        public DAO.User GetModel(String UserID)
        {
            return myUser.GetModel(UserID);
        }
        /// <summary>
        /// 添加记录
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="Userpassword">密码</param>
        /// <param name="Usertype">类别（职位）</param>
        /// <returns></returns>
        public String AddUser(DAO.User myDAOUser)
        {
            try
            {
                if (myUser.AddUser(myDAOUser))
                {
                    return "添加用户成功";
                }
                else
                {
                    return "添加用户失败";
                }
            }
            catch//可以增加用户名不存在或密码错误
            { return "添加用户异常"; }
        }
        /// <summary>
        /// 删除用户记录
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="Password">密码</param>
        /// <param name="Usertype">用户类型（岗位）</param>
        /// <returns></returns>
        public String DelUser(string UserID)
        {            
            try
            {
                if (myUser.DelUser(UserID))
                {
                    return "删除成功";
                }
                else
                {
                    return "删除失败";
                }
            }
            catch
            {
                return "删除异常";
            }
        }
        /// <summary>
        /// 修改用户记录
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="Password">密码</param>
        /// <param name="Usertype">用户类型</param>
        /// <returns></returns>
        public String updateUser(DAO.User myDAOUser)
        {
            try
            {
                if (myUser.UpdateUser(myDAOUser))
                { return "修改成功"; }
                else
                { return "修改失败"; }
            }
            catch
            {
                return "修改异常";
            }
        }
        /// <summary>
        /// 根据条件查询记录
        /// </summary>
        /// <param name="UserID">ID</param>
        /// <param name="UserName">用户名称</param>
        /// <param name="Password">登录密码</param>
        /// <param name="Usertype">用户类型</param>
        /// <returns>DataSet </returns>
        public DataSet SelectUser(string UserID, string UserName, string Password, string Usertype)
        {
            return myUser.SelectUser(UserID, UserName, Password, Usertype);
        }
    }
}