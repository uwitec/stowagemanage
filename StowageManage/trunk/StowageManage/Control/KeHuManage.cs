using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace StowageManage.Control
{
    public class KeHuManage
    {
        Model.KeHuManage myKHM = new Model.KeHuManage();
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
            return myKHM.SetModel(KHId, KHName, KHType, KHaddress, KHtell, KHnote);
        }
         /// <summary>
        /// 获取客户对象实例
        /// </summary>
        /// <param name="KHId">ID</param>
        /// <returns>DAO.KEHU</returns>
        public DAO.KEHU GetModel(string KHId)
        {
            return myKHM.GetModel(KHId);
        }
         /// <summary>
        /// 添加客户
        /// </summary>
        /// <param name="myDAOKH">DAO.KEHU</param>
        /// <returns>bool 是否成功添加记录</returns>
        public string AddKH(DAO.KEHU myDAOKH)
        {
            //判断物品是否存在
            if (myKHM.SelectKH("",myDAOKH.KHtype, myDAOKH.KHname,myDAOKH.KHaddress,myDAOKH.KHtell).Tables[0].Rows.Count > 0)
            {
                return "物品已经存在";
            }
            else
            {
                try
                {
                    if (myKHM.AddKH(myDAOKH))
                    { return "添加物品成功"; }
                    else
                    { return "添加物品失败"; }
                }
                catch
                { return "添加物品异常"; }
            }
        }
         /// <summary>
        /// 删除客户记录
        /// </summary>
        /// <param name="KHID">ID</param>
        /// <returns>bool 是否成功删除记录</returns>
        public string DelKH(String KHID)
        {
            try
            {
                if (myKHM.DelKH(KHID))
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
        /// 更新客户记录
        /// </summary>
        /// <param name="myDAOKH">DAO.KEHU</param>
        /// <returns>bool 是否成功修改记录</returns>
        public string UpdateKH(DAO.KEHU myDAOKH)
        {
            try
            {
                if (myKHM.UpdateKH(myDAOKH))
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
        /// 根据条件查询客户记录
        /// </summary>
        /// <param name="KHID">ID</param>
        /// <param name="KHType">类型(供货单位、收货单位)</param>
        /// <param name="KHName">客户名称</param>
        /// <param name="KHAddress">地址</param>
        /// <param name="KHTell">电话</param>
        /// <returns></returns>
        public DataSet SelectKH(string KHID, string KHType, string KHName, string KHAddress, string KHTell)
        {
            return myKHM.SelectKH(KHID, KHType, KHName, KHAddress, KHTell);
        }
    }
}