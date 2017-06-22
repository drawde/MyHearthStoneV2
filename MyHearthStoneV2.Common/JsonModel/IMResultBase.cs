using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Common.JsonModel
{
    public class IMResultBase
    {
        /// <summary>
        /// 返回值
        /// </summary>
        public int res { get; set; }

        /// <summary>
        /// 返回值说明
        /// </summary>
        public string msg { get; set; }
    }
}
