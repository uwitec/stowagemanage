using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StowageManage.DAO
{
    public class Stock
    {
        string _SKid;
        /// <summary>
        /// ID
        /// </summary>
        public string SKid
        {
            get { return _SKid; }
            set { _SKid = value; }
        }
        string _SKCKid;
        /// <summary>
        /// 仓库ID
        /// </summary>
        public string SKCKid
        {
            get { return _SKCKid; }
            set { _SKCKid = value; }
        }
        string _SKGSid;
        
        /// <summary>
        /// 物品ID
        /// </summary>
        public string SKGSid
        {
            get { return _SKGSid; }
            set { _SKGSid = value; }
        }
        int _SKquantity;
        /// <summary>
        /// 数量
        /// </summary>
        public int SKquantity
        {
            get { return _SKquantity; }
            set { _SKquantity = value; }
        }

    }
}