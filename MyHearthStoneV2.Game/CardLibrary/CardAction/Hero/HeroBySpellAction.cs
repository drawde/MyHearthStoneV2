using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Hero;
using MyHearthStoneV2.Game.Parameter.Variable;
using System.Linq;

namespace MyHearthStoneV2.Game.CardLibrary.CardAction.Hero
{
    /// <summary>
    /// 英雄受到法术伤害
    /// </summary>
    internal class HeroBySpellAction : Action.IGameAction
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            HeroActionParameter para = actionParameter as HeroActionParameter;
            BaseHero baseHero = para.Biology;
            GameContext gameContext = para.GameContext;
            int damage = para.DamageOrHeal;

            var biologys = gameContext.DeskCards.GetDeskCardsByMyCard(baseHero);
            //计算法术强度类技能
            foreach (var biology in biologys.Where(c => c != null))
            {
                if (biology.Abilities.Any(c => c.AbilityType == AbilityType.法术强度))
                {
                    damage += biology.Abilities.Where(c => c.AbilityType == AbilityType.法术强度).Sum(x => (x as SpellPower).Damage);
                }
                if (biology.CardType == CardType.英雄)
                {
                    BaseHero hero = biology as BaseHero;
                    if (hero.Equip != null && hero.Equip.Abilities.Any(c => c.AbilityType == AbilityType.法术强度))
                    {
                        damage += hero.Equip.Abilities.Where(c => c.AbilityType == AbilityType.法术强度).Sum(x => (x as SpellPower).Damage);
                    }
                }
            }

            var damagePara = CardActionFactory.CreateParameter(baseHero, actionParameter.GameContext, damage, secondaryCard: actionParameter.MainCard);
            CardActionFactory.CreateAction(baseHero, ActionType.受到法术伤害).Action(damagePara);
            return new IntParameter() { Value = damage };
        }
    }
}
