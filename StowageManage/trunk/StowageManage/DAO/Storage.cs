using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StowageManage.DAO
{
    public class Storage
    {
        private String _STid;
        /// <summary>
        /// 入库记录ID
        /// </summary>
        public String STid
        {
            get { return _STid; }
            set { _STid = value; }
        }
        private String _STnum;
        /// <summary>
        /// 入库单号
        /// </summary>
        public String STnum
        {
            get { return _STnum; }
            set { _STnum = value; }
        }
        private String _STckid;
        /// <summary>
        /// 仓库ID
        /// </summary>
        public String STckid
        {
            get { return _STckid; }
            set { _STckid = value; }
        }
        private String _STgsid;
        /// <summary>
        /// 货物ID
        /// </summary>
        public String STgsid
        {
            get { return _STgsid; }
            set { _STgsid = value; }
        }
        private String _STRK_MGid;
        /// <summary>
        /// 入库员
        /// </summary>
        public String STRK_MGid
        {
            get { return _STRK_MGid; }
            set { _STRK_MGid = value; }
        }
        private String _STYH_MGid;
        /// <summary>
        /// 验货员
        /// </summary>
        public String STYH_MGid
        {
            get { return _STYH_MGid; }
            set { _STYH_MGid = value; }
        }
        private String _STKHid;
        /// <summary>
        /// 供货商
        /// </summary>
        public String STKHid
        {
            get { return _STKHid; }
            set { _STKHid = value; }
        }
        private int _STquantity;
        /// <summary>
        /// 数量
        /// </summary>
        public int STquantity
        {
            get { return _STquantity; }
            set { _STquantity = value; }
        }
        private String _STDW;
        /// <summary>
        /// 单位
        /// </summary>
        public String STDW
        {
            get { return _STDW; }
            set { _STDW = value; }
        }
        private decimal _STDJ;
        /// <summary>
        /// 单价
        /// </summary>
        public decimal STDJ
        {
            get { return _STDJ; }
            set { _STDJ = value; }
        }
        private decimal _STprice;
        /// <summary>
        /// 总价格
        /// </summary>
        public decimal STprice
        {
            get { return _STprice; }
            set { _STprice = value; }
        }
        private DateTime _STdate;
        /// <summary>
        /// 入库日期
        /// </summary>
        public DateTime STdate
        {
            get { return _STdate; }
            set { _STdate = value; }
        }
        private String _STnote;
        /// <summary>
        /// 备注
        /// </summary>
        public String STnote
        {
            get { return _STnote; }
            set { _STnote = value; }
        }
        private String _STstatus;
        /// <summary>
        /// 状态
        /// </summary>
        public String STstatus
        {
            get { return _STstatus; }
            set { _STstatus = value; }
        }
    }
}