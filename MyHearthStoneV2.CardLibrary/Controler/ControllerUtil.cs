using MyHearthStoneV2.CardEnum;
using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.CardLibrary.Context;
using MyHearthStoneV2.Model;
using System.Linq;

namespace MyHearthStoneV2.CardLibrary.Controler
{
    public partial class Controler_Base
    {
        /// <summary>
        /// 获取当前回合的用户对象
        /// </summary>
        /// <returns></returns>
        public UserContext GetCurrentTurnUserCards()
        {
            return gameContext.Players.First(c => c.IsActivation);
        }

        /// <summary>
        /// 获取下个回合或是后手的用户对象
        /// </summary>
        /// <returns></returns>
        public UserContext GetNextTurnUserCards()
        {
            return gameContext.Players.First(c => c.IsActivation == false || c.IsFirst == false);
        }


        //public void TryTriggerCardAbility(Card card, SpellCardAbilityTime spellCardAbilityTime)
        //{

        //}
    }
}
