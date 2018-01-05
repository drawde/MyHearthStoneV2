
using MyHearthStoneV2.Game.Monitor;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.CardLibrary.Spell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.Game.CardLibrary;
using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.Context;
namespace MyHearthStoneV2.Game.Controler
{
    internal partial class Controler_Base
    {
        /// <summary>
        /// 打出一张法术牌
        /// </summary>
        /// <param name="spell"></param>
        /// <param name="target"></param>
        [ControlerMonitor, PlayerActionMonitor]
        internal void CastSpell(BaseSpell spell, int target)
        {
            var currentUserContext = gameContext.GetActivationUserContext();
            //var enenmyUserContext = gameContext.GetNotActivationUserContext();

            currentUserContext.Power -= spell.Cost;            
            currentUserContext.HandCards.Remove(spell);

            #region 触发场内牌的技能
            gameContext.TriggerCardAbility(gameContext.GetActivationUserContext().DeskCards, SpellCardAbilityTime.己方打出法术牌前, spell, target);
            #endregion

            gameContext.CastCardCount++;
            spell.CastIndex = gameContext.CastCardCount;
            var user = gameContext.GetActivationUserContext();
            user.Power -= spell.Cost;
            Card triggerCard = null;
            if (target > -1)
            {
                triggerCard = gameContext.GetCardByLocation(target);
            }

            if (spell.Abilities.Any(c => c.SpellCardAbilityTimes.Any(x => x == SpellCardAbilityTime.打出一张法术牌)))
            {
                foreach (BaseCardAbility abilities in spell.Abilities.Where(c => c.SpellCardAbilityTimes.Any(x => x == SpellCardAbilityTime.打出一张法术牌)))
                {
                    abilities.CastAbility(gameContext, triggerCard, spell, target);
                }
            }
            spell.CardLocation = CardLocation.坟场;
            user.GraveyardCards.Add(spell);

            #region 触发场内牌的技能
            gameContext.TriggerCardAbility(gameContext.GetActivationUserContext().DeskCards, SpellCardAbilityTime.己方打出法术牌后, spell, target);
            #endregion
        }
    }
}
