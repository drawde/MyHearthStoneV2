using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.Equip;
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
    public class HeroBySpellAction : Action.IGameAction
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            HeroActionParameter para = actionParameter as HeroActionParameter;
            BaseHero baseHero = para.Biology;
            GameContext gameContext = para.GameContext;
            int damage = para.DamageOrHeal;

            //计算法术强度类技能
            var biologys = gameContext.DeskCards.GetDeskCardsByMyCard(baseHero);
            damage += biologys.Sum(c => c.SpellPower);
            if (biologys.Any(c => c.CardType == CardType.英雄 && (c as BaseHero).Equip != null))
            {
                damage += (biologys.First(c => c.CardType == CardType.英雄) as BaseHero).Equip.SpellPower;
            }

            var damagePara = CardActionFactory.CreateParameter(baseHero, actionParameter.GameContext, damage, secondaryCard: actionParameter.PrimaryCard);
            CardActionFactory.CreateAction(baseHero, ActionType.受到伤害).Action(damagePara);
            return new IntParameter() { Value = damage };
        }
    }
}
