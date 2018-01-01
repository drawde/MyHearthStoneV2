
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Monitor;
using System.Linq;
using System.Collections.Generic;
using MyHearthStoneV2.Game.CardLibrary;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.CardLibrary.Servant;

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
        [ControlerMonitor, PlayerActionMonitor]
        internal void CastServant(BaseServant triggerCard, int location, int target)
        {
            #region 首先触发打出的这张牌的战吼技能
            if (triggerCard.Abilities.Any(c => c.LstSpellCardAbilityTime.Any(x => x == SpellCardAbilityTime.战吼)))
            {
                foreach (var buff in triggerCard.Abilities.Where(c => c.LstSpellCardAbilityTime.Any(x => x == SpellCardAbilityTime.战吼)))
                {
                    buff.CastAbility(gameContext, triggerCard, triggerCard, target, location);
                }
            }
            #endregion

            gameContext.CastCardCount++;
            triggerCard.CastIndex = gameContext.CastCardCount;

            var user = gameContext.GetActivationUserContext();
            user.Power -= triggerCard.Cost;
            triggerCard.CardLocation = CardLocation.场上;
            triggerCard.DeskIndex = location;
            user.DeskCards[location < 8? location: location - 8] = triggerCard;
            user.HandCards.Remove(triggerCard);
            #region 然后触发场内牌的技能
            gameContext.TriggerCardAbility(gameContext.GetActivationUserContext().DeskCards, CardLocation.场上, SpellCardAbilityTime.己方随从入场, triggerCard, target);
            #endregion

            #region 最后触发手牌的技能
            gameContext.TriggerCardAbility(gameContext.GetActivationUserContext().DeskCards, CardLocation.手牌, SpellCardAbilityTime.己方随从入场, triggerCard, target);
            #endregion
        }

        /// <summary>
        /// 随从攻击准备阶段
        /// </summary>
        /// <param name="servant"></param>
        /// <param name="target"></param>
        [ControlerMonitor, PlayerActionMonitor]
        internal void ServantReadyAttack(BaseServant servant, int target)
        {
        }

        /// <summary>
        /// 随从攻击进行阶段
        /// </summary>
        /// <param name="servant"></param>
        /// <param name="target"></param>
        [ControlerMonitor, PlayerActionMonitor]
        internal void ServantAttack(BaseServant servant, int target)
        {
            //gameContext.TriggerCardAbility(gameContext.GetActivationUserContext().DeskCards, CardLocation.场上, SpellCardAbilityTime.己方随从攻击, servant, target);
            //gameContext.TriggerCardAbility(gameContext.GetNotActivationUserContext().DeskCards, CardLocation.场上, SpellCardAbilityTime.对方随从攻击, servant, target);

            gameContext.AddActionStatement(gameContext.DeskCards, SpellCardAbilityTime.己方随从攻击, servant, target);
        }


    }
}
