
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Monitor;
using System.Linq;
using System.Collections.Generic;
using MyHearthStoneV2.Game.CardLibrary;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.CardLibrary.CardAction;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Servant;

namespace MyHearthStoneV2.Game.Controler
{
    internal partial class Controler_Base
    {
        /// <summary>
        /// 将一名随从从手牌中移到场上
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="cardInGameCode"></param>
        /// <param name="location"></param>
        [ControlerMonitor(AttributePriority = 99), PlayerActionMonitor(AttributePriority = 98), UserActionMonitor(AttributePriority = 1)]
        internal void CastServant(BaseServant triggerCard, int location, int target)
        {
            var user = GameContext.GetActivationUserContext();
            user.Power -= triggerCard.Cost;
            #region 首先触发打出的这张牌的战吼技能
            if (triggerCard.Abilities.Any(c => c.SpellCardAbilityTimes.Any(x => x == SpellCardAbilityTime.战吼)))
            {
                foreach (var buff in triggerCard.Abilities.Where(c => c.SpellCardAbilityTimes.Any(x => x == SpellCardAbilityTime.战吼)))
                {
                    buff.CastAbility(GameContext, triggerCard, triggerCard, target, location);
                }
            }
            #endregion


            triggerCard.Cast(GameContext, location, target);

            #region 然后触发场内牌的技能
            GameContext.TriggerCardAbility(GameContext.DeskCards.GetDeskCardsByIsFirst(user.IsFirst).Where(c => c != null && c.CardInGameCode != triggerCard.CardInGameCode), SpellCardAbilityTime.己方随从入场, triggerCard, target);
            #endregion

            #region 最后触发手牌的技能
            
            #endregion
        }


        /// <summary>
        /// 随从攻击进行阶段
        /// </summary>
        /// <param name="servant"></param>
        /// <param name="target"></param>
        [ControlerMonitor(AttributePriority = 99), PlayerActionMonitor(AttributePriority = 98), UserActionMonitor(AttributePriority = 1)]
        internal void ServantAttack(BaseServant servant, int target)
        {
            servant.Attack(GameContext, GameContext.DeskCards[target]);
        }


    }
}
