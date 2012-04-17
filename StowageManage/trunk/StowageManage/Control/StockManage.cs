using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


namespace StowageManage.Control
{
    public class StockManage
    {
        Model.StockManage mySM = new Model.StockManage();
         /// <summary>
        /// 设置对象实例
        /// </summary>
        /// <param name="SKid">ID</param>
        /// <param name="SKCKid">仓库</param>
        /// <param name="SKGSid">物品</param>
        /// <param name="SKquantity">数量</param>
        /// <returns>DAO.Stock</returns>
        public DAO.Stock SetModel(string SKid, string SKCKid, string SKGSid, int SKquantity)
        {
            return mySM.SetModel(SKid, SKCKid, SKGSid, SKquantity);
        }
         /// <summary>
        /// 获取对象实例
        /// </summary>
        /// <param name="SKid">库存ID</param>
        /// <returns>DAO.Stock</returns>
        public DAO.Stock GetModel(string SKid)
        {
            return mySM.GetModel(SKid);
        }
        /// <summary>
        /// 添加记录
        /// </summary>
        /// <param name="myDAOSK">DAO.Stock</param>
        /// <returns>string</returns>
        public string AddSK(DAO.Stock myDAOSK)
        {
            try
            {
                if (mySM.AddSK(myDAOSK))
                {
                    return "添加库存成功";
                }
                else
                {
                    return "添加库存失败";
                }
            }
            catch//可以增加用户名不存在或密码错误
            { return "添加库存异常"; }
        }
         /// <summary>
        /// 添加记录
        /// </summary>
        /// <param name="myDAOSK">DAO.Stock</param>
        /// <returns>bool</returns>
        public bool AddSK_bool(DAO.Stock myDAOSK)
        {
            DataSet ds = mySM.SelectStock(myDAOSK.SKCKid, myDAOSK.SKGSid);
            if (ds.Tables[0].Rows.Count > 0)
            {
                myDAOSK.SKquantity += int.Parse(ds.Tables[0].Rows[0]["sk_quantity"].ToString());
                return mySM.UpdateSK(myDAOSK);
            }
            else
            {
                return mySM.AddSK(myDAOSK);
            }
        }
         /// <summary>
        /// 删除1条库存记录
        /// </summary>
        /// <param name="SKID">库存ID</param>
        /// <returns>string</returns>
        public string DelSK(String SKID)
        {
            try
            {
                if (mySM.DelSK(SKID))
                {
                    return "删除库存成功";
                }
                else
                {
                    return "删除库存失败";
                }
            }
            catch
            {
                return "删除库存异常";
            }
        }
         /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="myDAOSK">DAO.Stock</param>
        /// <returns>string</returns>
        public string UpdateSK(DAO.Stock myDAOSK)
        {
            try
            {
                if (mySM.UpdateSK(myDAOSK))
                { return "修改库存成功"; }
                else
                { return "修改库存失败"; }
            }
            catch
            {
                return "修改库存异常";
            }
        }
        public bool StockAddorUpdate(DAO.Stock[] myDAOSK)
        {
            
            try
            {
                for (int i = 0; i < myDAOSK.Length; i++)
                {
                    if (equalsStock(myDAOSK[i]))
                    { mySM.UpdateSK(myDAOSK[i]); }
                    else
                    { mySM.AddSK(myDAOSK[i]); }

                }
                return true;
            }
            catch
            {
                return false;
            }
            
        }
        /// <summary>
        /// 判断指定仓库的指定物品是否存在
        /// </summary>
        /// <param name="myDAOSK">DAO.Stock</param>
        /// <returns>bool</returns>
        public bool equalsStock(DAO.Stock myDAOSK)
        {
            return mySM.equalsStock(myDAOSK);
        }
         /// <summary>
        /// 根据条件查询仓库记录
        /// </summary>
        /// <param name="SKCKid">仓库ID</param>
        /// <param name="SKGSid">物品ID</param>
        /// <returns>DataSet</returns>
        public DataSet SelectStock(string SKCKid, string SKGSid)
        {
            return mySM.SelectStock(SKCKid, SKGSid);
        }
    }
}