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
    public class GoodsManage
    {
        Model.GoodsManage myGS = new Model.GoodsManage();
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
            return myGS.SetModel(GSID, GSName, GSNum, GSType, GSNote);
        }
         /// <summary>
        /// 获取物品对象实例
        /// </summary>
        /// <param name="GSID">ID</param>
        /// <returns>DAO.goods Model 物品对象</returns>
        public DAO.goods GetModel(string GSID)
        {
            return myGS.GetModel(GSID);
        }
         /// <summary>
        /// 添加新物品
        /// </summary>
        /// <param name="myDAOGS">DAO.goods</param>
        /// <returns>bool 否成功添加记录</returns>
        public string AddGS(DAO.goods myDAOGS)
        {
            //判断物品是否存在
            if (myGS.SelectGS("", myDAOGS.GSname, myDAOGS.GSname, myDAOGS.GStype, "").Tables[0].Rows.Count > 0)
            {
                return "物品已经存在";
            }
            else
            {
                try
                {
                    if (myGS.AddGS(myDAOGS))
                    { return "添加物品成功"; }
                    else
                    { return "添加物品失败"; }
                }
                catch
                { return "添加物品异常"; }
            }
        }
         /// <summary>
        /// 删除物品
        /// </summary>
        /// <param name="GSID">ID</param>
        /// <returns>bool 是否成功删除记录</returns>
        public string DelGS(String GSID)
        {
            try
            {
                if (myGS.DelGS(GSID))
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
        /// 更新物品
        /// </summary>
        /// <param name="myDAOGS">DAO.goods</param>
        /// <returns>bool 是否成功修改记录</returns>
        public string UpdateGS(DAO.goods myDAOGS)
        {
            try
            {
                if (myGS.UpdateGS(myDAOGS))
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
        /// 根据条件查询物品记录
        /// </summary>
        /// <param name="GSID">ID</param>
        /// <param name="GSName">物品名称</param>
        /// <param name="GSNum">物品编号</param>
        /// <param name="GSType">物品类型</param>
        /// <param name="GSNote">备注</param>
        /// <returns></returns>
        public DataSet SelectGS(string GSID, string GSName, string GSNum, string GSType, string GSNote)
        {
            return myGS.SelectGS(GSID, GSName, GSNum, GSType, GSNote);
        }
    }
}