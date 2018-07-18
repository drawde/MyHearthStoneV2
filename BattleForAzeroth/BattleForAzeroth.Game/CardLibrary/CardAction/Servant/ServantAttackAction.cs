using BattleForAzeroth.Game.Action;
using BattleForAzeroth.Game.CardLibrary.Servant;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Parameter;

namespace BattleForAzeroth.Game.CardLibrary.CardAction.Servant
{
    /// <summary>
    /// 攻击一个随从
    /// </summary>
    public class ServantAttackAction : Action.IGameAction
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            BaseServant servant = actionParameter.PrimaryCard as BaseServant;
            GameContext gameContext = actionParameter.GameContext;
            BaseBiology attackCard = actionParameter.SecondaryCard as BaseBiology;
            int trueDamege = actionParameter.DamageOrHeal;

            ActionParameter actionPara = new ActionParameter()
            {
                PrimaryCard = attackCard,
                GameContext = actionParameter.GameContext,
                DamageOrHeal = trueDamege,
                SecondaryCard = servant
            };
            CardActionFactory.CreateAction(attackCard, ActionType.受到攻击).Action(actionPara);

            //自己挨打（如果攻击的是英雄，则不掉血）
            if (attackCard.CardType == CardType.随从)
            {
                ServantUnderAttackAction underAttackAction = new ServantUnderAttackAction();
                var underAttackPara = new ActionParameter()
                {
                    GameContext = gameContext,
                    PrimaryCard = servant,
                    SecondaryCard = attackCard,
                    DamageOrHeal = attackCard.Damage,
                };
                underAttackAction.Action(underAttackPara);
            }
            servant.RemainAttackTimes -= 1;
            servant.CanAttack = servant.RemainAttackTimes > 0 ? true : false;
            return null;
        }
    }
}
