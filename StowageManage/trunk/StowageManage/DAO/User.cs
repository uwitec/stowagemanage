using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StowageManage.DAO
{
    public class User
    {
        private String _usid;
        private String _usname;
        private String _uspassword;
        private String _ustype;
        /// <summary>
        /// UserID
        /// </summary>
        public String Usid
        {
            get { return _usid; }
            set { _usid = value; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public String Usname
        {
            get { return _usname; }
            set { _usname = value; }
        }      
        /// <summary>
        /// 密码
        /// </summary>
        public String Uspassword
        {
            get { return _uspassword; }
            set { _uspassword = value; }
        }
        /// <summary>
        /// 用户类型（职位）
        /// </summary>
        public String Ustype
        {
            get { return _ustype; }
            set { _ustype = value; }
        }

    }
}