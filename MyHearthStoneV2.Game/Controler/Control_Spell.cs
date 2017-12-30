using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.CardLibrary.Monitor;
using MyHearthStoneV2.CardLibrary.Servant;
using MyHearthStoneV2.CardLibrary.Spell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardLibrary.Controler
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
            #region 触发场内牌的技能
            gameContext.TriggerCardAbility(gameContext.GetActivationUserContext().DeskCards, CardLocation.场上, SpellCardAbilityTime.己方打出法术牌前, spell, target);
            #endregion

            var user = gameContext.GetActivationUserContext();
            user.Power -= spell.Cost;
            Card triggerCard = null;
            if (target > -1)
            {
                triggerCard = gameContext.GetCardByLocation(target);
            }
            if (spell.Abilities.Any(c => c.LstSpellCardAbilityTime.Any(x => x == SpellCardAbilityTime.己方打出法术牌后)))
            {
                foreach (var buff in spell.Abilities.Where(c => c.LstSpellCardAbilityTime.Any(x => x == SpellCardAbilityTime.己方打出法术牌后)))
                {
                    buff.CastAbility(gameContext, triggerCard, spell, target);
                }
            }
            spell.CardLocation = CardLocation.坟场;
            user.HandCards.Remove(spell);
            user.GraveyardCards.Add(spell);

            #region 触发场内牌的技能
            gameContext.TriggerCardAbility(gameContext.GetActivationUserContext().DeskCards, CardLocation.场上, SpellCardAbilityTime.己方打出法术牌后, spell, target);
            #endregion
        }
    }
}
