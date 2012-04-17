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
    public delegate bool delegateAddStorage(DAO.Storage[] mySM);
    //public delegate bool delegeteAddStock(DAO.Stock myStock);

    public class StorageManage
    {
        Model.StorageManage myModel_SM = new Model.StorageManage();

        /// <summary>
        /// 设置入库单对象实例
        /// </summary>
        /// <param name="STID">ID</param>
        /// <param name="STnum">入库单号</param>
        /// <param name="STCKID">仓库ID</param>
        /// <param name="STGSID">货物ID</param>
        /// <param name="STRKMGID">入库员ID</param>
        /// <param name="STYHMGID">验货员ID</param>
        /// <param name="STKHID">供货商ID</param>
        /// <param name="STquantity">数量</param>
        /// <param name="STDW">单位</param>
        /// <param name="STDJ">单价</param>
        /// <param name="STprice">总价格</param>
        /// <param name="STdate">入库日期</param>
        /// <param name="STnote">备注</param>
        /// /// <param name="STstatus">状态</param>
        /// <returns></returns>
        public DAO.Storage SetModel(string STID, string STnum, string STCKID, string STGSID, string STRKMGID, string STYHMGID, string STKHID, int STquantity, string STDW, decimal STDJ, decimal STprice, DateTime STdate, string STnote, string STstatus)
        {
            return myModel_SM.SetModel(STID, STnum, STCKID, STGSID, STRKMGID, STYHMGID, STKHID, STquantity, STDW, STDJ, STprice, STdate, STnote, STstatus);
        }
        /// <summary>
        /// 获取入库单对象实例
        /// </summary>
        /// <param name="STID"></param>
        /// <returns></returns>
        public DAO.Storage GetModel(string STID)
        {
            return myModel_SM.GetModel(STID);
        }
        /// <summary>
        /// 添加单条入库单记录
        /// </summary>
        /// <param name="myDAOST"></param>
        /// <returns>string</returns>
        public string AddST_Singole(DAO.Storage myDAOST)
        {
            try
            {
                if (myModel_SM.AddST_Singole(myDAOST))
                {
                    return "添加入库单成功";
                }
                else
                {
                    return "添加入库单失败";
                }
            }
            catch
            { return "添加入库单异常"; }
        }
         /// <summary>
        /// 添加多条记录
        /// </summary>
        /// <param name="myDAOST">DAO.Storage[]</param>
        /// <returns>string</returns>
        public string AddST_More(DAO.Storage[] myDAOST)
        {
            try
            {
                if (myModel_SM.AddST_More(myDAOST))
                {
                    return "添加入库单成功";
                }
                else
                {
                    return "添加入库单失败";
                }
            }
            catch
            { return "添加入库单异常"; }
        }
           /// <summary>
        /// 添加多条记录
        /// </summary>
        /// <param name="myDAOST">DAO.Storage[]</param>
        /// <returns>bool</returns>
        public bool AddST_More_bool(DAO.Storage[] myDAOST)
        {
            return myModel_SM.AddST_More(myDAOST);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="myDAOST"></param>
        /// <param name="myDAOSK"></param>
        /// <param name="myStorage"></param>
        /// <returns></returns>
        public string AddSTMore_StockMore(DAO.Storage[] myDAOST)//,DAO.Stock myDAOSK,delegateAddStorage myStorage)//, delegeteAddStock myStock)
        {
            Control.StockManage mySM=new StockManage();
            DAO.Stock[] myDAOsk=new DAO.Stock[myDAOST.Length];
            //把storage[]转为Stock[]
            for (int i = 0; i < myDAOsk.Length;i++ )
            {

            }

            try
            {
                if (myModel_SM.AddST_More(myDAOST) & mySM.StockAddorUpdate(myDAOsk))
                {
                    return "添加入库单成功";
                }
                else
                {
                    return "添加入库单失败";
                }
            }
            catch
            { return "添加入库单异常"; }
        }
        /// <summary>
        /// 删除入库单
        /// </summary>
        /// <param name="STnum"></param>
        /// <returns>string</returns>
        public string DelST(String STnum)
        {
            //缺少对库存的更新
            //缺少删除表单应添加到日志中
            try
            {
                if (myModel_SM.DelST(STnum))
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
        /// 更新入库单
        /// </summary>
        /// <param name="myDAOST">DAO.Storage</param>
        /// <returns>string</returns>
        public string UpdateST(DAO.Storage myDAOST)
        {
            //缺少对库存的更新
            //缺少删除表单应添加到日志中
            try
            {
                if (myModel_SM.UpdateST(myDAOST))
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
        /// 根据条件查询入库单
        /// </summary>
        /// <param name="STnum">入库单号</param>
        /// <param name="STRKMGID">入库员</param>
        /// <param name="STYHMGID">验货员</param>
        /// <param name="STKHID">供货商</param>
        /// <param name="STGSID">货物ID</param>
        /// <param name="STCKID">仓库ID</param>
        /// <param name="STDate">入库日期</param>
        /// <param name="STStatus">状态</param>
        /// <returns>DataSet</returns>
        public DataSet SelectST(string STID, string STnum, string STRKMGID, string STYHMGID, string STKHID, string STGSID, string STCKID, string STStartDate, string STEndDate, string STStatus)
        {
            return myModel_SM.SelectST(STID, STnum, STRKMGID, STYHMGID, STKHID, STGSID, STCKID, STStartDate, STEndDate, STStatus);
        }
    }
}