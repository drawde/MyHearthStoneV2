using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.Game.CardLibrary.Equip;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.Context;

namespace MyHearthStoneV2.Game.CardLibrary.CardAction.Equip
{
    public static class BaseEquipAction
    {
        /// <summary>
        /// 拆卸装备，如果装备耐久小于1的话
        /// </summary>
        /// <param name="equip"></param>
        /// <param name="gameContext"></param>
        public static void Unload(this BaseEquip equip, GameContext gameContext)
        {
            BaseHero baseHero = gameContext.DeskCards.GetHeroByIsFirst(gameContext.GetUserContextByMyCard(equip).IsFirst);

            baseHero.Equip.Durable -= 1;
            if (baseHero.Equip.Durable == 0)
            {
                baseHero.Equip.CardLocation = CardLocation.坟场;
                if (baseHero.Equip.Abilities.Any(c => c.AbilityType == AbilityType.亡语))
                {
                    gameContext.TriggerCardAbility(new List<Card> {baseHero.Equip}, SpellCardAbilityTime.无);
                }
                else
                {
                    baseHero.Equip = null;
                }
            }
        }
    }
}
