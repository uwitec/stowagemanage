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
    public class OutofLibraryManage
    {
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
            int OLquantity, string OLDW, decimal OLDJ, decimal OLYSHK, decimal OLSSHK,string OLKHid,
            string OLZDMGid, string OLYHMGid, string OLSHY, decimal OLPrice, DateTime OLDate,
            string OLSHMGid, string OLstatus, string OLnote)
        {
            DAO.Outoflibrary myModel = new DAO.Outoflibrary();
            myModel.OLid = OLid;
            myModel.OLckid = OLCKid;
            myModel.OLgsid = OLGSid;
            myModel.OLnum = OLnum;
            myModel.OLquantity = OLquantity;
            myModel.OLDW = OLDW;
            myModel.OLDJ = OLDJ;
            myModel.OLYSHK = OLYSHK;
            myModel.OLSSHK = OLSSHK;
            myModel.OLKHID = OLKHid;
            myModel.OLZDMGid = OLZDMGid;
            myModel.OLYHMGid = OLYHMGid;
            myModel.OLSHY = OLSHY;
            myModel.OLprice = OLPrice;
            myModel.OLdate = OLDate;
            myModel.OLSHMGid = OLSHMGid;
            myModel.OLstatus = OLstatus;
            myModel.OLnote = OLnote;
            return myModel;
        }
        /// <summary>
        /// 获取对象实例
        /// </summary>
        /// <param name="OLid">ID</param>
        /// <returns>DAO.Outoflibrary</returns>
        public DAO.Outoflibrary GetModel(string OLid)
        {
            StringBuilder Strsql = new StringBuilder();
            Strsql.Append("select * from db_outoflibrary where ol_id=" + OLid);
            DataSet myDS=DBHelperSQL.Query(Strsql.ToString());
            DAO.Outoflibrary myModel = new DAO.Outoflibrary();
            myModel.OLid = OLid;
            myModel.OLckid = myDS.Tables[0].Rows[0]["ol_ckid"].ToString();
            myModel.OLgsid = myDS.Tables[0].Rows[0]["ol_gsid"].ToString();
            myModel.OLnum = myDS.Tables[0].Rows[0]["ol_num"].ToString();
            myModel.OLquantity = int.Parse(myDS.Tables[0].Rows[0]["ol_quantity"].ToString());
            myModel.OLDW = myDS.Tables[0].Rows[0]["ol_dw"].ToString();
            myModel.OLDJ = decimal.Parse(myDS.Tables[0].Rows[0]["ol_dj"].ToString());
            myModel.OLYSHK = decimal.Parse(myDS.Tables[0].Rows[0]["ol_yshk"].ToString());
            myModel.OLSSHK = decimal.Parse(myDS.Tables[0].Rows[0]["ol_sshk"].ToString());
            myModel.OLKHID = myDS.Tables[0].Rows[0]["ol_khid"].ToString();
            myModel.OLZDMGid = myDS.Tables[0].Rows[0]["ol_zd_mgid"].ToString();
            myModel.OLYHMGid = myDS.Tables[0].Rows[0]["ol_yh_mgid"].ToString();
            myModel.OLSHY = myDS.Tables[0].Rows[0]["ol_shy"].ToString();
            myModel.OLprice = decimal.Parse(myDS.Tables[0].Rows[0]["ol_price"].ToString());
            myModel.OLdate = DateTime.Parse(myDS.Tables[0].Rows[0]["ol_date"].ToString());
            myModel.OLSHMGid = myDS.Tables[0].Rows[0]["ol_sh_mgid"].ToString();
            myModel.OLstatus = myDS.Tables[0].Rows[0]["ol_status"].ToString();
            myModel.OLnote = myDS.Tables[0].Rows[0]["ol_note"].ToString();
            return myModel;
        }
        /// <summary>
        /// 添加单条记录
        /// </summary>
        /// <param name="myDAOOL">DAO.Outoflibrary</param>
        /// <returns>bool</returns>
        public bool AddOL_Singole(DAO.Outoflibrary myDAOOL)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into db_Storage (");
            strSql.Append("ol_ckid,ol_gsid,ol_num,ol_quantity,ol_dw,ol_dj,ol_yshk,ol_sshk,ol_khid,ol_zd_mgid,ol_yh_mgid,ol_shy,ol_price,ol_date,ol_sh_mgid,ol_status,ol_note");
            strSql.Append(")values(");
            strSql.Append("'" + myDAOOL.OLckid + "',");
            strSql.Append("'" + myDAOOL.OLgsid + "',");
            strSql.Append("'" + myDAOOL.OLnum + "',");
            strSql.Append("" + myDAOOL.OLquantity + ",");
            strSql.Append("'" + myDAOOL.OLDW + "',");
            strSql.Append("'" + myDAOOL.OLDJ + "',");
            strSql.Append("'" + myDAOOL.OLYSHK + "',");
            strSql.Append("'" + myDAOOL.OLSSHK + "',");
            strSql.Append("'" + myDAOOL.OLKHID + "',");
            strSql.Append("'" + myDAOOL.OLZDMGid + "',");
            strSql.Append("'" + myDAOOL.OLYHMGid + "',");
            strSql.Append("'" + myDAOOL.OLSHY + "',");
            strSql.Append("'" + myDAOOL.OLprice + "',");
            strSql.Append("'" + myDAOOL.OLdate + "',");
            strSql.Append("'" + myDAOOL.OLSHMGid + "',");
            strSql.Append("'" + myDAOOL.OLstatus + "',");
            strSql.Append("'" + myDAOOL.OLnote + "')");

            int count = DBHelperSQL.ExecuteSql(strSql.ToString());
            //判断是否成功添加记录
            if (count == 1)
            { return true; }
            else
            { return false; }
        }
        /// <summary>
        /// 添加多条出库物品
        /// </summary>
        /// <param name="myDAOOL">物品记录数组</param>
        /// <returns>bool</returns>
        public bool AddOL_More(DAO.Outoflibrary[] myDAOOL)
        {
            
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into db_storage (ol_ckid,ol_gsid,ol_num,ol_quantity,ol_dw,ol_dj,ol_yshk,ol_sshk,ol_khid,ol_zd_mgid,ol_yh_mgid,ol_shy,ol_price,ol_date,ol_sh_mgid,ol_status,ol_note)");
            strSql.Append("values");
            for (int i = 0; i < myDAOOL.Length; i++)
            {
                DAO.Outoflibrary myOutoflibrary = myDAOOL[i];
                strSql.Append("(");
                strSql.Append("'" + myOutoflibrary.OLckid + "',");
                strSql.Append("'" + myOutoflibrary.OLgsid + "',");
                strSql.Append("'" + myOutoflibrary.OLnum + "',");
                strSql.Append("" + myOutoflibrary.OLquantity + ",");
                strSql.Append("'" + myOutoflibrary.OLDW + "',");
                strSql.Append("'" + myOutoflibrary.OLDJ + "',");
                strSql.Append("'" + myOutoflibrary.OLYSHK + "',");
                strSql.Append("'" + myOutoflibrary.OLSSHK + "',");
                strSql.Append("'" + myOutoflibrary.OLKHID + "',");
                strSql.Append("'" + myOutoflibrary.OLZDMGid + "',");
                strSql.Append("'" + myOutoflibrary.OLYHMGid + "',");
                strSql.Append("'" + myOutoflibrary.OLSHY + "',");
                strSql.Append("'" + myOutoflibrary.OLprice + "',");
                strSql.Append("'" + myOutoflibrary.OLdate + "',");
                strSql.Append("'" + myOutoflibrary.OLSHMGid + "',");
                strSql.Append("'" + myOutoflibrary.OLstatus + "',");
                strSql.Append("'" + myOutoflibrary.OLnote + "'");
                strSql.Append(")");
                if (i != (myDAOOL.Length - 1))
                { strSql.Append(","); }
            }
            int count = DBHelperSQL.ExecuteSql(strSql.ToString());
            //判断是否成功添加记录
            if (count == myDAOOL.Length)
            { return true; }
            else
            { return false; }

        }
        /// <summary>
        /// 删除出库单
        /// </summary>
        /// <param name="OLnum">出库单号</param>
        /// <returns>bool</returns>
        public bool DelOL(String OLnum)
        {
            //缺少对库存的更新
            //缺少删除表单应添加到日志中

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from db_outoflibrary ");
            strSql.Append("where ol_num=" + OLnum);
            int count = DBHelperSQL.ExecuteSql(strSql.ToString());
            //判断是否成功删除记录
            if (count > 0)
            { return true; }
            else
            { return false; }
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="myDAOOL">DAO.Outoflibrary</param>
        /// <returns>bool</returns>
        public bool UpdateOL(DAO.Outoflibrary myDAOOL)
        {
            //缺少对库存的更新
            //缺少删除表单应添加到日志中

            
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update db_outoflibrary set ");
            strSql.Append("ol_ckid='" + myDAOOL.OLckid + "',");
            strSql.Append("ol_gsid='" + myDAOOL.OLgsid + "',");
            strSql.Append("ol_num='" + myDAOOL.OLnum + "',");
            strSql.Append("ol_quantity='" + myDAOOL.OLquantity + "',");
            strSql.Append("ol_dw='" + myDAOOL.OLDW + "',");
            strSql.Append("ol_dj='" + myDAOOL.OLDJ + "',");
            strSql.Append("ol_yshk='" + myDAOOL.OLYSHK + "',");
            strSql.Append("ol_sshk='" + myDAOOL.OLSSHK + "',");
            strSql.Append("ol_khid='" + myDAOOL.OLKHID + "',");
            strSql.Append("ol_zd_mgid='" + myDAOOL.OLZDMGid + "',");
            strSql.Append("ol_yh_mgid='" + myDAOOL.OLYHMGid + "',");
            strSql.Append("ol_shy='" + myDAOOL.OLSHY + "',");
            strSql.Append("ol_price='" + myDAOOL.OLprice + "',");
            strSql.Append("ol_date='" + myDAOOL.OLdate + "',");
            strSql.Append("ol_sh_mgid='" + myDAOOL.OLSHMGid + "',");
            strSql.Append("ol_status='" + myDAOOL.OLstatus + "',");
            strSql.Append("ol_note='" + myDAOOL.OLnote + "'");
            strSql.Append(" where ol_id=" + myDAOOL.OLid);

            int count = DBHelperSQL.ExecuteSql(strSql.ToString());
            //判断是否成功修改记录
            if (count == 1)
            { return true; }
            else
            { return false; }
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
            //出库单号、仓库ID、货物ID、制单员、验货员、收货人、出库日期、送货员、出库单状态
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ol_id,ol_num as '出库单号',(select ck_name from db_cangku where ck_id=ol_ckid) as '仓库',(select gs_name from db_goods where gs_id=ol_gsid) as '货物',ol_dw as '单位',ol_dj as '单价',ol_quantity as '数量',ol_price as '总价格',ol_date as '入库日期',(select mg_name from db_manager where mg_id=ol_zd_mgid) as '制单员',(select mg_name from db_manager where mg_id=ol_yh_mgid) as '验货员',(select mg_name from db_manager where mg_id=ol_sh_mgid) as '送货员',ol_shy as '收货人' ,ol_status'出库单状态'from db_outoflibrary");
            strSql.Append(" where 1=1");
            if (OLid != "")
            { strSql.Append(" and ol_id=" + OLid + ""); }
            if (OLnum != "")
            { strSql.Append(" and st_num='" + OLnum + "'"); }
            if (OLCKid != "" && OLCKid != "0")
            { strSql.Append(" and ol_ckid=" + OLCKid + ""); }
            if (OLGSid != "" && OLGSid != "0")
            { strSql.Append(" and ol_gsid=" + OLGSid + ""); }
            if (OLZDMGid != "" && OLZDMGid != "0")
            { strSql.Append(" and ol_zd_mgid=" + OLZDMGid + ""); }
            if (OLYHMGid != "" && OLYHMGid != "0")
            { strSql.Append(" and ol_yh_mgid=" + OLYHMGid + ""); }
            if (OLSHY != "")
            { strSql.Append(" and ol_shy like %'" + OLSHY + "'%"); }
            if (OLSHMGid != "" && OLSHMGid != "0")
            { strSql.Append(" and ol_sh_mgid=" + OLSHMGid + ""); }
            if (OLStartDate != "" && OLEndDate != "")
            {
                strSql.Append(" and (st_date between '" + OLStartDate + "' and '" + OLEndDate + "')");
            }
            if (OLStatus != "" && OLSHMGid != "0")
            { strSql.Append(" and st_status=" + OLStatus + ""); }


            return DBHelperSQL.Query(strSql.ToString());
        }
    }
}