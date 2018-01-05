using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Equip;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Hero;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Servant;
using MyHearthStoneV2.Game.CardLibrary.Equip;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Observer
{
    public class CA_WarglaiveOfAzzinoth : BaseCardAbility
    {
        public override List<SpellCardAbilityTime> SpellCardAbilityTimes { get; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.对方英雄攻击前 };
        public override void CastAbility(GameContext gameContext, Card triggerCard, Card sourceCard, int targetCardIndex, int location = -1)
        {
            BaseEquip equip = sourceCard as BaseEquip;
            BaseHero baseHero = gameContext.GetUserContextByMyCard(sourceCard).Hero;
            //沉默目标
            gameContext.DisableCardAbility(new List<BaseBiology>() {triggerCard as BaseBiology }, CardLocation.场上);

            if (triggerCard.CardType == CardType.英雄)
            {
                BaseHero hero = triggerCard as BaseHero;
                //将护甲削减为0
                hero.Ammo = 0;
                hero.BiologyByDamege(triggerCard, gameContext, equip.Damege + baseHero.Damage);
            }
            else
            {
                BaseServant servant = triggerCard as BaseServant;
                servant.BiologyByDamege(triggerCard, gameContext, equip.Damege);
            }
            
            baseHero.Equip.Unload(gameContext);
        }
    }
}
