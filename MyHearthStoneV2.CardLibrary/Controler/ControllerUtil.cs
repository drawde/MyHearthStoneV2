using MyHearthStoneV2.CardLibrary.Context;
using MyHearthStoneV2.Model;
using System.Linq;

namespace MyHearthStoneV2.CardLibrary.Controler
{
    public partial class Controler_Base
    {
        public void SetCurrentRoundCode(HS_Game game)
        {
            //currentRoundCode = ShortCodeBll
        }

        /// <summary>
        /// 获取当前回合的用户对象
        /// </summary>
        /// <returns></returns>
        public UserCards GetCurrentRoundUserCards()
        {
            return gameContext.Players.First(c => c.IsActivation);
        }

        /// <summary>
        /// 获取下个回合或是后手的用户对象
        /// </summary>
        /// <returns></returns>
        public UserCards GetNextRoundUserCards()
        {
            return gameContext.Players.First(c => c.IsActivation == false || c.IsFirst == false);
        }
    }
}
