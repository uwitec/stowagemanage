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
    public class CangKuManage
    {
        Model.CangKuManage myCKM = new Model.CangKuManage();
         /// <summary>
        /// 设置对象实例
        /// </summary>
        /// <param name="CKId">ID</param>
        /// <param name="CKName">仓库名称</param>
        /// <param name="CKType">仓库类型</param>
        /// <param name="CKNote">备注</param>
        /// <returns>DAO.Cangku </returns>
        public DAO.Cangku SetModel(string CKId, string CKName, string CKType, string CKNote)
        {
            return myCKM.SetModel(CKId, CKName, CKType, CKNote);
        }
        /// <summary>
        /// 根据仓库ID获取对象实例
        /// </summary>
        /// <param name="CKId">ID</param>
        /// <returns>DAO.Cangku 仓库对象</returns>
        public DAO.Cangku GetModel(String CKId)
        {
            return myCKM.GetModel(CKId);
        }
        /// <summary>
        /// 添加记录
        /// </summary>
        /// <param name="myDAOCK">DAO.Cangku</param>
        /// <returns>bool 是否成功添加记录</returns>
        public string AddCK(DAO.Cangku myDAOCK)
        {
            try
            {
                if (myCKM.AddCK(myDAOCK))
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
        /// 根据ID删除记录
        /// </summary>
        /// <param name="CKID">ID</param>
        /// <returns>bool</returns>
        public string DelCK(String CKID)
        {
            try
            {
                if (myCKM.DelCK(CKID))
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
        /// 根据ID修改数据
        /// </summary>
        /// <param name="myDAOCK">DAO.Cangku</param>
        /// <returns>bool</returns>
        public string UpdateCK(DAO.Cangku myDAOCK)
        {
            try
            {
                if (myCKM.UpdateCK(myDAOCK))
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
        /// <param name="CKID">ID</param>
        /// <param name="CKName">仓库名称</param>
        /// <param name="CKType">仓库类型</param>
        /// <returns>DataSet</returns>
        public DataSet SelectCK(string CKID, string CKName, string CKType)
        {
            return myCKM.SelectCK(CKID, CKName, CKType);
        }
    }
}