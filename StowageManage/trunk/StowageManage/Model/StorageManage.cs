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
    public class StorageManage
    {
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
            DAO.Storage myModel = new DAO.Storage();
            myModel.STid = STID;
            myModel.STnum = STnum;
            myModel.STckid = STCKID;
            myModel.STgsid = STGSID;
            myModel.STRK_MGid = STRKMGID;
            myModel.STYH_MGid = STYHMGID;
            myModel.STKHid = STKHID;
            myModel.STquantity = STquantity;
            myModel.STDW = STDW;
            myModel.STDJ = STDJ;
            myModel.STprice = STprice;
            myModel.STdate = STdate;
            myModel.STnote = STnote;
            myModel.STstatus = STstatus;

            return myModel;
        }
        /// <summary>
        /// 获取入库单对象实例
        /// </summary>
        /// <param name="STID"></param>
        /// <returns></returns>
        public DAO.Storage GetModel(string STID)
        {
            DataSet myData = DBUtility.DBHelperSQL.Query("select * from db_Storage where ST_id=" + STID);
            DAO.Storage myModel = new DAO.Storage();
            myModel.STid = STID;
            myModel.STnum = myData.Tables[0].Rows[0]["st_num"].ToString().Trim();
            myModel.STckid = myData.Tables[0].Rows[0]["st_ckid"].ToString().Trim();
            myModel.STgsid = myData.Tables[0].Rows[0]["ST_gsid"].ToString().Trim();
            myModel.STRK_MGid = myData.Tables[0].Rows[0]["st_rk_mgid"].ToString().Trim();
            myModel.STYH_MGid = myData.Tables[0].Rows[0]["st_yh_mgid"].ToString().Trim();
            myModel.STKHid = myData.Tables[0].Rows[0]["st_khid"].ToString().Trim();
            myModel.STquantity = int.Parse(myData.Tables[0].Rows[0]["st_quantity"].ToString().Trim());
            myModel.STDW = myData.Tables[0].Rows[0]["st_dw"].ToString().Trim();
            myModel.STDJ = decimal.Parse(myData.Tables[0].Rows[0]["st_dj"].ToString().Trim());
            myModel.STprice = decimal.Parse(myData.Tables[0].Rows[0]["st_price"].ToString().Trim());
            myModel.STdate = DateTime.Parse(myData.Tables[0].Rows[0]["st_date"].ToString().Trim());
            myModel.STnote = myData.Tables[0].Rows[0]["st_note"].ToString().Trim();
            myModel.STstatus = myData.Tables[0].Rows[0]["st_status"].ToString().Trim();

            return myModel;
        }
        /// <summary>
        /// 添加单条入库单记录
        /// </summary>
        /// <param name="myDAOST"></param>
        /// <returns>bool</returns>
        public bool AddST_Singole(DAO.Storage myDAOST)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into db_Storage (");
            strSql.Append("st_num,st_ckid,ST_gsid,st_rk_mgid,st_yh_mgid,st_khid,st_quantity,st_dw,st_dj,st_price,st_date,st_note,st_status");
            strSql.Append(")values(");
            strSql.Append("'" + myDAOST.STnum + "',");
            strSql.Append("'" + myDAOST.STckid + "',");
            strSql.Append("'" + myDAOST.STgsid + "',");
            strSql.Append("'" + myDAOST.STRK_MGid + "',");
            strSql.Append("'" + myDAOST.STYH_MGid + "',");
            strSql.Append("'" + myDAOST.STKHid + "',");
            strSql.Append("'" + myDAOST.STquantity + "',");
            strSql.Append("'" + myDAOST.STDW + "',");
            strSql.Append("'" + myDAOST.STDJ + "',");
            strSql.Append("'" + myDAOST.STprice + "',");
            strSql.Append("'" + myDAOST.STdate + "',");
            strSql.Append("'" + myDAOST.STnote + "',");
            strSql.Append("'" + myDAOST.STstatus + "')");

            int count = DBHelperSQL.ExecuteSql(strSql.ToString());
            //判断是否成功添加记录
            if (count == 1)
            { return true; }
            else
            { return false; }
        }
        /// <summary>
        /// 添加多条记录
        /// </summary>
        /// <param name="myDAOST">DAO.Storage[]</param>
        /// <returns>bool</returns>
        public bool AddST_More(DAO.Storage[] myDAOST)
        {
            // INSERT into db_canGku (ck_name,ck_type,ck_note)
            //values('原料仓库', '1', '存原料'),
            //('报损仓库', '2', '损坏产品'),
            //('产品仓库','3', '存产品' );
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into db_storage (st_num,st_ckid,ST_gsid,st_rk_mgid,st_yh_mgid,st_khid,st_quantity,st_dw,st_dj,st_price,st_date,st_note,st_status)");
            strSql.Append("values");
            for (int i = 0; i < myDAOST.Length; i++)
            {
                DAO.Storage myStorage = myDAOST[i];
                strSql.Append("(");
                strSql.Append("'" + myStorage.STnum + "',");
                strSql.Append("'" + myStorage.STckid + "',");
                strSql.Append("'" + myStorage.STgsid + "',");
                strSql.Append("'" + myStorage.STRK_MGid + "',");
                strSql.Append("'" + myStorage.STYH_MGid + "',");
                strSql.Append("'" + myStorage.STKHid + "',");
                strSql.Append("'" + myStorage.STquantity + "',");
                strSql.Append("'" + myStorage.STDW + "',");
                strSql.Append("'" + myStorage.STDJ + "',");
                strSql.Append("'" + myStorage.STprice + "',");
                strSql.Append("'" + myStorage.STdate + "',");
                strSql.Append("'" + myStorage.STnote + "',");
                strSql.Append("'" + myStorage.STstatus + "'");
                strSql.Append(")");
                if (i != (myDAOST.Length - 1))
                { strSql.Append(","); }
            }
            int count = DBHelperSQL.ExecuteSql(strSql.ToString());
            //判断是否成功添加记录
            if (count == myDAOST.Length)
            { return true; }
            else
            { return false; }

        }
        /// <summary>
        /// 删除入库单
        /// </summary>
        /// <param name="STnum">入库单号</param>
        /// <returns>bool</returns>
        public bool DelST(String STnum)
        {
            //缺少对库存的更新
            //缺少删除表单应添加到日志中

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from DB_storage ");
            strSql.Append("where st_num=" + STnum);
            int count = DBHelperSQL.ExecuteSql(strSql.ToString());
            //判断是否成功删除记录
            if (count > 0)
            { return true; }
            else
            { return false; }
        }
        /// <summary>
        /// 更新入库单
        /// </summary>
        /// <param name="myDAOST">DAO.Storage</param>
        /// <returns>bool</returns>
        public bool UpdateST(DAO.Storage myDAOST)
        {
            //缺少对库存的更新
            //缺少删除表单应添加到日志中

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update DB_storage set ");
            strSql.Append("st_num='" + myDAOST.STnum + "',");
            strSql.Append("st_ckid='" + myDAOST.STckid + "',");
            strSql.Append("ST_gsid='" + myDAOST.STgsid + "',");
            strSql.Append("st_rk_mgid='" + myDAOST.STRK_MGid + "',");
            strSql.Append("st_yh_mgid='" + myDAOST.STYH_MGid + "',");
            strSql.Append("st_khid='" + myDAOST.STKHid + "',");
            strSql.Append("st_quantity='" + myDAOST.STquantity + "',");
            strSql.Append("st_dw='" + myDAOST.STDW + "',");
            strSql.Append("st_dj='" + myDAOST.STDJ + "',");
            strSql.Append("st_price='" + myDAOST.STprice + "',");
            strSql.Append("st_date='" + myDAOST.STdate + "',");
            strSql.Append("st_date='" + myDAOST.STnote + "',");
            strSql.Append("st_note='" + myDAOST.STstatus + "'");
            strSql.Append(" where st_id=" + myDAOST.STid);

            int count = DBHelperSQL.ExecuteSql(strSql.ToString());
            //判断是否成功修改记录
            if (count == 1)
            { return true; }
            else
            { return false; }
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
        public DataSet SelectST(string STID,string STnum, string STRKMGID, string STYHMGID, string STKHID, string STGSID, string STCKID, string STStartDate,string STEndDate, string STStatus)
        {
            //入库单号、入库员ID、验货员ID、供货商ID、入库日期、货物ID、仓库ID
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select st_id,st_num as '入库单号',(select ck_name from db_cangku where ck_id=st_ckid) as '仓库',(select gs_name from db_goods where gs_id=st_gsid) as '货物',st_dw as '单位',st_dj as '单价',st_quantity as '数量',st_price as '总价格',st_date as '入库日期',(select mg_name from db_manager where mg_id=st_rk_mgid) as '入库员',(select mg_name from db_manager where mg_id=st_yh_mgid) as '验货员',(select kh_name from db_kehu where kh_id=st_khid) as '供货商' from db_storage");
            strSql.Append(" where 1=1");
            if (STID != "")
            { strSql.Append(" and st_id=" + STID + ""); }
            if (STnum != "")
            { strSql.Append(" and st_num=" + STnum + ""); }
            if (STRKMGID != "" && STRKMGID !="0")
            { strSql.Append(" and st_rk_mgid=" + STRKMGID + ""); }
            if (STYHMGID != "" && STYHMGID != "0")
            { strSql.Append(" and st_YH_mgid=" + STYHMGID + ""); }
            if (STKHID != "" && STKHID != "0")
            { strSql.Append(" and st_KHid=" + STKHID + ""); }
            if (STGSID != "" && STGSID != "0")
            { strSql.Append(" and st_gsid=" + STGSID + ""); }
            if (STCKID != "" && STCKID != "0")
            { strSql.Append(" and st_ckid=" + STCKID + ""); }
            if (STStartDate != "" && STEndDate != "")
            {
                strSql.Append(" and (st_date between '" + STStartDate + "' and '" + STEndDate + "')");   
            }
            if (STStatus != "")
            { strSql.Append(" and st_status=" + STStatus + ""); }


            return DBHelperSQL.Query(strSql.ToString());
        }
    }
}