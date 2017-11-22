using MyHearthStoneV2.CardLibrary.Context;
using MyHearthStoneV2.CardLibrary.Monitor;
using MyHearthStoneV2.Model;
namespace MyHearthStoneV2.CardLibrary.Controler
{
    public partial class Controler_Base
    {
        /// <summary>
        /// 回合结束
        /// </summary>        
        [ControlerMonitor, PlayerActionMonitor]
        public void RoundEnd()
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
            nextRoundCode = MyHearthStoneV2.ShortCodeBll.ShortCodeBusiness.Instance.CreateCode(ShortCodeTypeEnum.GameRoundCode);
            roundIndex++;
            
            #endregion
        }
    }
}
