using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StowageManage.DAO
{
    public class Outoflibrary
    {
        private String _OLid;
        /// <summary>
        /// 出库记录ID
        /// </summary>
        public String OLid
        {
            get { return _OLid; }
            set { _OLid = value; }
        }
        private String _OLnum;
        /// <summary>
        /// 出库单号20120102001
        /// </summary>
        public String OLnum
        {
            get { return _OLnum; }
            set { _OLnum = value; }
        }
        private String _OLckid;
        /// <summary>
        /// 仓库ID
        /// </summary>
        public String OLckid
        {
            get { return _OLckid; }
            set { _OLckid = value; }
        }
        private String _OLgsid;
        /// <summary>
        /// 货物ID
        /// </summary>
        public String OLgsid
        {
            get { return _OLgsid; }
            set { _OLgsid = value; }
        }
        private int _OLquantity;
        /// <summary>
        /// 数量
        /// </summary>
        public int OLquantity
        {
            get { return _OLquantity; }
            set { _OLquantity = value; }
        }
        private String _OLDW;
        /// <summary>
        /// 单位
        /// </summary>
        public String OLDW
        {
            get { return _OLDW; }
            set { _OLDW = value; }
        }
        private decimal _OLDJ;
        /// <summary>
        /// 单价
        /// </summary>
        public decimal OLDJ
        {
            get { return _OLDJ; }
            set { _OLDJ = value; }
        }
        private decimal _OLYSHK;
        /// <summary>
        /// 应收货款
        /// </summary>
        public decimal OLYSHK
        {
            get { return _OLYSHK; }
            set { _OLYSHK = value; }
        }
        private decimal _OLSSHK;
        /// <summary>
        /// 实收货款
        /// </summary>
        public decimal OLSSHK
        {
            get { return _OLSSHK; }
            set { _OLSSHK = value; }
        }
        private String _OLKHID;
        /// <summary>
        /// 购货单位
        /// </summary>
        public String OLKHID
        {
            get { return _OLKHID; }
            set { _OLKHID = value; }
        }
        private String _OLZDMGid;
        /// <summary>
        /// 制单员
        /// </summary>
        public String OLZDMGid
        {
            get { return _OLZDMGid; }
            set { _OLZDMGid = value; }
        }
        private String _OLYHMGid;
        /// <summary>
        /// 验货员
        /// </summary>
        public String OLYHMGid
        {
            get { return _OLYHMGid; }
            set { _OLYHMGid = value; }
        }
        private String _OLSHY;
        /// <summary>
        /// 收货人
        /// </summary>
        public String OLSHY
        {
            get { return _OLSHY; }
            set { _OLSHY = value; }
        }
        private decimal _OLprice;
        /// <summary>
        /// 金额
        /// </summary>
        public decimal OLprice
        {
            get { return _OLprice; }
            set { _OLprice = value; }
        }
        private DateTime _OLdate;
        /// <summary>
        /// 出库日期
        /// </summary>
        public DateTime OLdate
        {
            get { return _OLdate; }
            set { _OLdate = value; }
        }
        private String _OLSHMGid;
        /// <summary>
        /// 送货员
        /// </summary>
        public String OLSHMGid
        {
            get { return _OLSHMGid; }
            set { _OLSHMGid = value; }
        }
        private String _OLstatus;
        /// <summary>
        /// 出库单状态
        /// </summary>
        public String OLstatus
        {
            get { return _OLstatus; }
            set { _OLstatus = value; }
        }
        private String _OLnote;
        /// <summary>
        /// 备注
        /// </summary>
        public String OLnote
        {
            get { return _OLnote; }
            set { _OLnote = value; }
        }
    }
}