
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
using MyHearthStoneV2.Game.Parameter.CardAbility;

namespace MyHearthStoneV2.Game.Controler
{
    internal partial class Controler_Base
    {
        /// <summary>
        /// 打出一张法术牌
        /// </summary>
        /// <param name="spell"></param>
        /// <param name="target"></param>
        [ControlerMonitor(AttributePriority = 99), PlayerActionMonitor(AttributePriority = 98), UserActionMonitor(AttributePriority = 1)]
        internal void CastSpell(BaseSpell spell, int target)
        {
            var currentUserContext = GameContext.GetActivationUserContext();
            //var enenmyUserContext = gameContext.GetNotActivationUserContext();

            currentUserContext.Power -= spell.Cost < 0 ? 0 : spell.Cost;
            currentUserContext.HandCards.Remove(spell);

            #region 触发场内牌的技能
            GameContext.TriggerCardAbility(GameContext.DeskCards.GetDeskCardsByIsFirst(), SpellCardAbilityTime.己方打出法术牌前, spell, target);
            #endregion

            GameContext.CastCardCount++;
            spell.CastIndex = GameContext.CastCardCount;

            Card triggerCard = null;
            if (target > -1)
            {
                triggerCard = GameContext.DeskCards[target];
            }

            if (spell.Abilities.Any(c => c.AbilityType == AbilityType.法术))
            {
                foreach (BaseCardAbility abilities in spell.Abilities.Where(c => c.AbilityType == AbilityType.法术))
                {
                    CardAbilityParameter para = new CardAbilityParameter()
                    {
                        GameContext = GameContext,
                        MainCard = spell,
                        SecondaryCard = triggerCard,
                    };
                    abilities.Action(para);
                }
            }
            spell.CardLocation = CardLocation.坟场;
            currentUserContext.GraveyardCards.Add(spell);

            #region 触发场内牌的技能
            GameContext.TriggerCardAbility(GameContext.DeskCards.GetDeskCardsByIsFirst(), SpellCardAbilityTime.己方打出法术牌后, spell, target);
            GameContext.TriggerCardAbility(GameContext.DeskCards.GetDeskCardsByIsFirst(false), SpellCardAbilityTime.对方打出法术牌后, spell, target);
            #endregion
        }
    }
}
