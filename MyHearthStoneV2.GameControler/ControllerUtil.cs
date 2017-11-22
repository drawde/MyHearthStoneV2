using MyHearthStoneV2.BLL;
using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Game;
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
        internal void SetCurrentRoundCode(HS_Game game)
        {
            //currentRoundCode = ShortCodeBll
        }

        /// <summary>
        /// 获取当前回合的用户对象
        /// </summary>
        /// <returns></returns>
        internal UserCards GetCurrentRoundUserCards()
        {
            return gameContext.Players.First(c => c.IsActivation);
        }

        /// <summary>
        /// 获取下个回合或是后手的用户对象
        /// </summary>
        /// <returns></returns>
        internal UserCards GetNextRoundUserCards()
        {
            return gameContext.Players.First(c => c.IsActivation == false || c.IsFirst == false);
        }
    }
}
