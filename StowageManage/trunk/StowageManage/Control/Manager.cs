using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace StowageManage.Control
{
    public class Manager
    {
        Model.Manager myModel_MG = new Model.Manager();

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
        public DAO.Manager SetModel(string MGId, string MGName, string MGnum, string MGContact, string MGIDnumber, string MGtype, string MGNote)
        {
            return myModel_MG.SetModel(MGId, MGName, MGnum, MGContact, MGIDnumber, MGtype, MGNote);
        }
         /// <summary>
        /// 获取客户对象实例
        /// </summary>
        /// <param name="MGId">ID</param>
        /// <returns>DAO.Manager</returns>
        public DAO.Manager GetModel(string MGId)
        {
            return myModel_MG.GetModel(MGId);
        }
         /// <summary>
        /// 添加人员
        /// </summary>
        /// <param name="myDAOMG">DAO.Manager</param>
        /// <returns>bool 是否成功添加记录</returns>
        public string AddMG(DAO.Manager myDAOMG)
        {
            //判断人员是否存在
            if (myModel_MG.SelectMG("", myDAOMG.MGname, myDAOMG.MGnum, myDAOMG.MGcontact, myDAOMG.MGIDnumber, myDAOMG.MGtype).Tables[0].Rows.Count > 0)
            {
                return "人员已经存在";
            }
            else
            {
                try
                {
                    if (myModel_MG.AddMG(myDAOMG))
                    { return "添加人员成功"; }
                    else
                    { return "添加人员失败"; }
                }
                catch
                { return "添加人员异常"; }
            }
        }
         /// <summary>
        /// 删除人员记录
        /// </summary>
        /// <param name="MGID">ID</param>
        /// <returns>bool 是否成功删除记录</returns>
        public string DelMG(String MGID)
        {
            try
            {
                if (myModel_MG.DelMG(MGID))
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
        /// 更新人员记录
        /// </summary>
        /// <param name="myDAOMG">DAO.Manager</param>
        /// <returns>bool 是否成功修改记录</returns>
        public string UpdateMG(DAO.Manager myDAOMG)
        {
            try
            {
                if (myModel_MG.UpdateMG(myDAOMG))
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
            return myModel_MG.SelectMG(MGID, MGname, MGnum, MGcontact, MGIDnumber, MGtype);
        }
    }
}