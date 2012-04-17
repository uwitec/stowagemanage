using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StowageManage.DAO
{
    public class Cangku
    {
        private String _CKid;
        /// <summary>
        /// 仓库ID
        /// </summary>
        public String CKid
        {
            get { return _CKid; }
            set { _CKid = value; }
        }
        private String _CKname;
        /// <summary>
        /// 仓库名
        /// </summary>
        public String CKname
        {
            get { return _CKname; }
            set { _CKname = value; }
        }
        private String _CKtype;
        /// <summary>
        /// 仓库类别
        /// </summary>
        public String CKtype
        {
            get { return _CKtype; }
            set { _CKtype = value; }
        }
        private String _CKnote;
        /// <summary>
        /// 备注
        /// </summary>
        public String CKnote
        {
            get { return _CKnote; }
            set { _CKnote = value; }
        }

    }
}