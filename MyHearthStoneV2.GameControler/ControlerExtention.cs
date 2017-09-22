using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.GameControler
{
    static class ControlerExtention
    {
        /// <summary>
        /// 保存状态
        /// </summary>
        /// <param name="ctl"></param>
        public static void Save(this Controler ctl)
        {
            ControllerCache.SetController(ctl);
        }
    }
}
