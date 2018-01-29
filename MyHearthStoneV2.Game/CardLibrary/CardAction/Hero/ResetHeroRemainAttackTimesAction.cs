using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Hero;
using System.Collections.Generic;
using System.Linq;

namespace MyHearthStoneV2.Game.CardLibrary.CardAction.Hero
{
    /// <summary>
    /// 重置英雄攻击次数
    /// </summary>
    internal class ResetHeroRemainAttackTimesAction : IGameAction
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            HeroActionParameter para = actionParameter as HeroActionParameter;
            BaseHero baseHero = para.Biology;
            GameContext gameContext = para.GameContext;

            if (((baseHero.Equip != null && baseHero.Equip.Damage > 0) || baseHero.Damage > 0) && baseHero.CanAttack && 
                baseHero.Abilities.Any(c => c.SpellCardAbilityTimes.Any(x => x == SpellCardAbilityTime.重置攻击次数)) == false)
            {
                baseHero.RemainAttackTimes += 1;
            }
            else
            {
                gameContext.TriggerCardAbility(new List<Card>() { baseHero }, SpellCardAbilityTime.重置攻击次数);
            }
            return null;
        }
    }
}
