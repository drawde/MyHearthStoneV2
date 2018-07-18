using BattleForAzeroth.Game.Action;
using BattleForAzeroth.Game.CardLibrary.Hero;
using BattleForAzeroth.Game.CardLibrary.Servant;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Parameter;
using BattleForAzeroth.Game.Parameter.Variable;
using System.Linq;


namespace BattleForAzeroth.Game.CardLibrary.CardAction.Servant
{
    /// <summary>
    /// 随从受到法术伤害
    /// </summary>
    public class ServantBySpellAction : Action.IGameAction
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            BaseServant baseServant = actionParameter.PrimaryCard as BaseServant;
            GameContext gameContext = actionParameter.GameContext;
            int damage = actionParameter.DamageOrHeal;

            //计算法术强度类技能
            var biologys = gameContext.DeskCards.GetDeskCardsByMyCard(baseServant);
            damage += biologys.Sum(c => c.SpellPower);
            if (biologys.Any(c => c.CardType == CardType.英雄 && (c as BaseHero).Equip != null))
            {
                damage += (biologys.First(c => c.CardType == CardType.英雄) as BaseHero).Equip.SpellPower;
            }

            var damagePara = new ActionParameter
            {
                PrimaryCard = baseServant,
                GameContext = actionParameter.GameContext,
                DamageOrHeal = damage,
                SecondaryCard = actionParameter.PrimaryCard
            };
            CardActionFactory.CreateAction(baseServant, ActionType.受到伤害).Action(damagePara);
            return new IntParameter() { Value = damage };
        }
    }
}
