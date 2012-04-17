using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StowageManage.DAO
{
    public class goods
    {
        private String _GSid;
        /// <summary>
        /// 货物ID
        /// </summary>
        public String GSid
        {
            get { return _GSid; }
            set { _GSid = value; }
        }
        private String _GSname;
        /// <summary>
        /// 货物名称
        /// </summary>
        public String GSname
        {
            get { return _GSname; }
            set { _GSname = value; }
        }
        private String _GSnum;
        /// <summary>
        /// 货物编号
        /// </summary>
        public String GSnum
        {
            get { return _GSnum; }
            set { _GSnum = value; }
        }
        private String _GStype;
        /// <summary>
        /// 货物类别
        /// </summary>
        public String GStype
        {
            get { return _GStype; }
            set { _GStype = value; }
        }
        private String _GSnote;
        /// <summary>
        /// 备注
        /// </summary>
        public String GSnote
        {
            get { return _GSnote; }
            set { _GSnote = value; }
        }
    }
}