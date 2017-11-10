using MyHearthStoneV2.BLL;
using MyHearthStoneV2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.GameControler
{
    internal partial class Controler
    {
        /// <summary>
        /// 回合结束
        /// </summary>
        [ControlerMonitor]
        internal void RoundEnd()
        {
            roundIndex++;
            currentRoundRemainingSecond = 60;
            currentRoundCode = nextRoundCode;
            nextRoundCode = ShortCodeBll.Instance.CreateCode(ShortCodeTypeEnum.GameRoundCode);
        }
    }
}
