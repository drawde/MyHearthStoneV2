using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHearthStoneV2.API.Hubs
{
    public class Connection
    {
        /// <summary>
        /// 连接ID
        /// </summary>
        public string ConnectionID { get; set; }
        /// <summary>
        /// 用户代理
        /// </summary>
        public string UserAgent { get; set; }
        /// <summary>
        /// 是否连接
        /// </summary>
        public bool Connected { get; set; }
    }
}