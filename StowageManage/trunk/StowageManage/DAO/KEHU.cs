using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StowageManage.DAO
{
    public class KEHU
    {
        private String _KHid;
        /// <summary>
        /// 客户ID
        /// </summary>
        public String KHid
        {
            get { return _KHid; }
            set { _KHid = value; }
        }
        private String _KHtype;
        /// <summary>
        /// 类型(供货单位、收货单位)
        /// </summary>
        public String KHtype
        {
            get { return _KHtype; }
            set { _KHtype = value; }
        }
        private String _KHname;
        /// <summary>
        /// 客户名称
        /// </summary>
        public String KHname
        {
            get { return _KHname; }
            set { _KHname = value; }
        }
        private String _KHaddress;
        /// <summary>
        /// 地址
        /// </summary>
        public String KHaddress
        {
            get { return _KHaddress; }
            set { _KHaddress = value; }
        }
        private String _KHtell;
        /// <summary>
        /// 电话
        /// </summary>
        public String KHtell
        {
            get { return _KHtell; }
            set { _KHtell = value; }
        }
        private String _KHnote;
        /// <summary>
        /// 备注
        /// </summary>
        public String KHnote
        {
            get { return _KHnote; }
            set { _KHnote = value; }
        }
    }
}