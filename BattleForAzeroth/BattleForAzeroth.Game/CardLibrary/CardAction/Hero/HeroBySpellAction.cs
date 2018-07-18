using BattleForAzeroth.Game.Action;
using BattleForAzeroth.Game.CardLibrary.Hero;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Parameter;
using BattleForAzeroth.Game.Parameter.Variable;
using System.Linq;

namespace BattleForAzeroth.Game.CardLibrary.CardAction.Hero
{
    /// <summary>
    /// 英雄受到法术伤害
    /// </summary>
    public class HeroBySpellAction : Action.IGameAction
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            ActionParameter para = actionParameter as ActionParameter;
            BaseHero baseHero = para.PrimaryCard as BaseHero;
            GameContext gameContext = para.GameContext;
            int damage = para.DamageOrHeal;

            //计算法术强度类技能
            var biologys = gameContext.DeskCards.GetDeskCardsByMyCard(baseHero);
            damage += biologys.Sum(c => c.SpellPower);
            if (biologys.Any(c => c.CardType == CardType.英雄 && (c as BaseHero).Equip != null))
            {
                damage += (biologys.First(c => c.CardType == CardType.英雄) as BaseHero).Equip.SpellPower;
            }

            var damagePara = new ActionParameter
            {
                PrimaryCard = baseHero,
                GameContext = actionParameter.GameContext,
                DamageOrHeal = damage,
                SecondaryCard = actionParameter.PrimaryCard
            };
            CardActionFactory.CreateAction(baseHero, ActionType.受到伤害).Action(damagePara);
            return new IntParameter() { Value = damage };
        }
    }
}
