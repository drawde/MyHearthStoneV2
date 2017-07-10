using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Common.JsonModel
{
    public class IMReciveData
    {
        public string appid { get; set; }
        public string apiname { get; set; }
        public string nonce_str { get; set; }
        public string version { get; set; }
        public string sign { get; set; }
        public string token { get; set; }
        public object param { get; set; }
    }
}
