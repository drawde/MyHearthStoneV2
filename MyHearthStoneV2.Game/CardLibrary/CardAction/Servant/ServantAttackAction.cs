using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Hero;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.CardAbility;
using MyHearthStoneV2.Game.Parameter.Hero;
using MyHearthStoneV2.Game.Parameter.Servant;
using System.Collections.Generic;
using System.Linq;

namespace MyHearthStoneV2.Game.CardLibrary.CardAction.Servant
{
    /// <summary>
    /// 攻击一个随从
    /// </summary>
    internal class ServantAttackAction : Action.IGameAction
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            ServantActionParameter para = actionParameter as ServantActionParameter;
            BaseServant servant = para.Biology;
            GameContext gameContext = para.GameContext;
            BaseBiology attackCard = para.SecondaryCard as BaseBiology;
            int trueDamege = para.DamageOrHeal;

            //攻击对方
            if (servant.Abilities.Any(c => c.SpellCardAbilityTimes.Any(x => x == SpellCardAbilityTime.随从攻击)))
            {
                var abiliti = servant.Abilities.First(c => c.SpellCardAbilityTimes.Any(x => x == SpellCardAbilityTime.随从攻击));
                CardAbilityParameter abilityPara = new CardAbilityParameter()
                {
                    GameContext = gameContext,
                    MainCard = servant,
                    SecondaryCard = attackCard,
                };
                abiliti.Action(abilityPara);
            }
            else
            {
                BaseActionParameter actionPara = CardActionFactory.CreateParameter(attackCard, actionParameter.GameContext, trueDamege, secondaryCard: servant);
                CardActionFactory.CreateAction(attackCard, ActionType.受到攻击).Action(actionPara);
                //targetCard.UnderAttack(gameContext, servant);
            }

            //自己挨打（如果攻击的是英雄，则不掉血）
            if (attackCard.CardType == CardType.随从)
            {
                ServantUnderAttackAction underAttackAction = new ServantUnderAttackAction();
                ServantActionParameter underAttackPara = new ServantActionParameter()
                {
                    GameContext = gameContext,
                    Biology = servant,
                    SecondaryCard = attackCard,
                    DamageOrHeal = attackCard.Damage,
                };
                underAttackAction.Action(underAttackPara);
                //UnderAttack(servant, gameContext, targetCard);
            }
            servant.RemainAttackTimes -= 1;
            servant.CanAttack = servant.RemainAttackTimes > 0 ? true : false;
            return null;
        }
    }
}
