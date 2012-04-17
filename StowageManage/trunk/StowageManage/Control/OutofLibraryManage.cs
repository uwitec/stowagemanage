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
    public class OutofLibraryManage
    {
        Model.OutofLibraryManage myOLM = new Model.OutofLibraryManage();
        /// <summary>
        /// 设置对象实例
        /// </summary>
        /// <param name="OLid">ID</param>
        /// <param name="OLCKid">仓库ID</param>
        /// <param name="OLGSid">物品ID</param>
        /// <param name="OLnum">出库单号</param>
        /// <param name="OLquantity">数量</param>
        /// <param name="OLDW">单位</param>
        /// <param name="OLDJ">单价</param>
        /// <param name="OLYSHK">应收货款</param>
        /// <param name="OLSSHK">实收货款</param>
        /// <param name="OLKHid">购货商ID</param>
        /// <param name="OLZDMGid">制单人</param>
        /// <param name="OLYHMGid">验货人</param>
        /// <param name="OLSHY">收货人</param>
        /// <param name="OLPrice">金额</param>
        /// <param name="OLDate">出单日期</param>
        /// <param name="OLSHMGid">送货人</param>
        /// <param name="OLstatus">出库单状态</param>
        /// <param name="OLnote">备注</param>
        /// <returns>DAO.Outoflibrary</returns>
        public DAO.Outoflibrary SetModel(string OLid, string OLCKid, string OLGSid, string OLnum,
            int OLquantity, string OLDW, decimal OLDJ, decimal OLYSHK, decimal OLSSHK, string OLKHid,
            string OLZDMGid, string OLYHMGid, string OLSHY, decimal OLPrice, DateTime OLDate,
            string OLSHMGid, string OLstatus, string OLnote)
        {
            return myOLM.SetModel(OLid, OLCKid, OLGSid, OLnum, OLquantity, OLDW, OLDJ, OLYSHK, OLSSHK, OLKHid, OLZDMGid, OLYHMGid, OLSHY, OLPrice, OLDate, OLSHMGid, OLstatus, OLnote);
        }
         /// <summary>
        /// 获取对象实例
        /// </summary>
        /// <param name="OLid">ID</param>
        /// <returns>DAO.Outoflibrary</returns>
        public DAO.Outoflibrary GetModel(string OLid)
        {
            return myOLM.GetModel(OLid);
        }
         /// <summary>
        /// 添加单条记录
        /// </summary>
        /// <param name="myDAOOL">DAO.Outoflibrary</param>
        /// <returns>string</returns>
        public string  AddOL_Singole(DAO.Outoflibrary myDAOOL)
        {
            try
            {
                if (myOLM.AddOL_Singole(myDAOOL))
                {
                    return "添加出库单成功";
                }
                else
                {
                    return "添加出库单失败";
                }
            }
            catch
            { return "添加出库单异常"; }
        }
         /// <summary>
        /// 添加多条出库物品
        /// </summary>
        /// <param name="myDAOOL">物品记录数组</param>
        /// <returns>string</returns>
        public string AddOL_More(DAO.Outoflibrary[] myDAOOL)
        {
            try
            {
                if (myOLM.AddOL_More(myDAOOL))
                {
                    return "添加出库单成功";
                }
                else
                {
                    return "添加出库单失败";
                }
            }
            catch
            { return "添加入库单异常"; }
        }
        /// <summary>
        /// 删除出库单
        /// </summary>
        /// <param name="OLnum">出库单号</param>
        /// <returns>string</returns>
        public string DelOL(String OLnum)
        {
            //缺少对库存的更新
            //缺少删除表单应添加到日志中
            try
            {
                if (myOLM.DelOL(OLnum))
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
        /// 更新数据
        /// </summary>
        /// <param name="myDAOOL">DAO.Outoflibrary</param>
        /// <returns>string</returns>
        public string UpdateOL(DAO.Outoflibrary myDAOOL)
        {
            //缺少对库存的更新
            //缺少删除表单应添加到日志中
            try
            {
                if (myOLM.UpdateOL(myDAOOL))
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
        /// 根据条件查询
        /// </summary>
        /// <param name="OLid">ID</param>
        /// <param name="OLnum">出库单号</param>
        /// <param name="OLCKid">仓库ID</param>
        /// <param name="OLGSid">物品ID</param>
        /// <param name="OLZDMGid">制单人</param>
        /// <param name="OLYHMGid">验货人</param>
        /// <param name="OLSHY">收货人</param>
        /// <param name="OLSHMGid">送货人</param>
        /// <param name="OLStartDate">起始时间</param>
        /// <param name="OLEndDate">结束时间</param>
        /// <param name="OLStatus">出库单状态</param>
        /// <returns>DataSet</returns>
        public DataSet SelectOL(string OLid, string OLnum, string OLCKid, string OLGSid, string OLZDMGid, string OLYHMGid, string OLSHY, string OLSHMGid, string OLStartDate, string OLEndDate, string OLStatus)
        {
            return myOLM.SelectOL(OLid, OLnum, OLCKid, OLGSid, OLZDMGid, OLYHMGid, OLSHY, OLSHMGid, OLStartDate, OLEndDate, OLStatus);
        }
    }
}