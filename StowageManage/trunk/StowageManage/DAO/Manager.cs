using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StowageManage.DAO
{
    public class Manager
    {
        private String _MGid;
        /// <summary>
        /// 员工ID
        /// </summary>
        public String MGid
        {
            get { return _MGid; }
            set { _MGid = value; }
        }
        private String _MGname;
        /// <summary>
        /// 姓名
        /// </summary>
        public String MGname
        {
            get { return _MGname; }
            set { _MGname = value; }
        }
        private String _MGnum;
        /// <summary>
        /// 工号
        /// </summary>
        public String MGnum
        {
            get { return _MGnum; }
            set { _MGnum = value; }
        }
        private String _MGcontact;
        /// <summary>
        /// 联系方式
        /// </summary>
        public String MGcontact
        {
            get { return _MGcontact; }
            set { _MGcontact = value; }
        }
        private String _MGIDnumber;
        /// <summary>
        /// 身份证号
        /// </summary>
        public String MGIDnumber
        {
            get { return _MGIDnumber; }
            set { _MGIDnumber = value; }
        }
        private String _MGtype;
        /// <summary>
        /// 职位
        /// </summary>
        public String MGtype
        {
            get { return _MGtype; }
            set { _MGtype = value; }
        }
        private String _MGnote;
        /// <summary>
        /// 备注
        /// </summary>
        public String MGnote
        {
            get { return _MGnote; }
            set { _MGnote = value; }
        }
    }
}