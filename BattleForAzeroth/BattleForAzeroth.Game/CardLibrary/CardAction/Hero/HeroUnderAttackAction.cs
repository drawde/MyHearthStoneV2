using BattleForAzeroth.Game.Action;
using BattleForAzeroth.Game.CardLibrary.Hero;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Parameter;
namespace BattleForAzeroth.Game.CardLibrary.CardAction.Hero
{
    /// <summary>
    /// 被攻击
    /// </summary>
    public class HeroUnderAttackAction : Action.IGameAction
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            ActionParameter para = actionParameter as ActionParameter;
            BaseHero baseHero = para.PrimaryCard as BaseHero;
            GameContext gameContext = para.GameContext;
            BaseBiology attackCard = para.SecondaryCard as BaseBiology;
            int trueDamege = attackCard.Damage;
            if (attackCard.CardType == CardType.英雄)
            {
                BaseHero attackHero = attackCard as BaseHero;
                if (attackHero.Equip != null)
                {
                    trueDamege += attackHero.Equip.Damage;
                }
            }
            ActionParameter underAttackPara = new ActionParameter()
            {
                PrimaryCard = baseHero,
                GameContext = actionParameter.GameContext,
                DamageOrHeal = trueDamege,
                SecondaryCard = attackCard
            };
            CardActionFactory.CreateAction(baseHero, ActionType.受到伤害).Action(underAttackPara);
            return null;
        }
    }
}
