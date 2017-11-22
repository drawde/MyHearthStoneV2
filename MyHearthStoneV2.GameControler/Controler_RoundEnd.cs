using MyHearthStoneV2.BLL;
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
        /// <summary>
        /// 回合结束
        /// </summary>        
        [ControlerMonitor, PlayerActionMonitor]
        internal void RoundEnd()
        {            
            #region 调整玩家对象
            UserCards uc = null, next_uc = null;
            if (roundIndex > 0)
            {
                uc = GetCurrentRoundUserCards();
                next_uc = GetNextRoundUserCards();
                uc.IsActivation = false;
                next_uc.IsActivation = true;
                if (next_uc.Power < 11)
                {
                    next_uc.Power++;
                }
            }
            //else
            //{
            //    uc = gameContext.Players.First(c => c.IsFirst);
            //    next_uc = gameContext.Players.First(c => c.IsFirst == false);
            //    uc.IsActivation = true;
            //    next_uc.IsActivation = false;
            //}
            #endregion

            #region 调整游戏环境对象
            currentRoundRemainingSecond = 60;
            currentRoundCode = nextRoundCode;
            nextRoundCode = ShortCodeBll.Instance.CreateCode(ShortCodeTypeEnum.GameRoundCode);
            roundIndex++;
            
            #endregion
        }
    }
}
