using BattleForAzeroth.Game.Action;
using BattleForAzeroth.Game.CardLibrary.Hero;
using BattleForAzeroth.Game.CardLibrary.Servant;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Parameter;

namespace BattleForAzeroth.Game.CardLibrary.CardAction.Servant
{
    /// <summary>
    /// 随从被攻击
    /// </summary>
    public class ServantUnderAttackAction : Action.IGameAction
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            BaseServant servant = actionParameter.PrimaryCard as BaseServant;
            GameContext gameContext = actionParameter.GameContext;
            BaseBiology attackCard = actionParameter.SecondaryCard as BaseBiology;
            int damege = actionParameter.DamageOrHeal;

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
                PrimaryCard = servant,
                GameContext = actionParameter.GameContext,
                DamageOrHeal = trueDamege,
                SecondaryCard = attackCard
            };
            CardActionFactory.CreateAction(servant, ActionType.受到伤害).Action(underAttackPara);
            return null;
        }
    }
}
