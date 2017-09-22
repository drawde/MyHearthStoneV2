using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyHearthStoneV2.API.Hubs
{
    public class SignalRUser
    {
        public string UserCode { get; set; }

        ///昵称
        public string NickName { get; set; }

        /// <summary>
        /// 是否选好了卡组
        /// </summary>
        public bool IsReady { get; set; } = false;

        /// <summary>
        /// 选择的卡组
        /// </summary>
        public string ChosenCardGroupCode { get; set; }
    }
}