using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Servant;

namespace MyHearthStoneV2.Game.CardLibrary.CardAction.Servant
{
    /// <summary>
    /// 随从受到治疗时，增加它的生命值，然后触发随从或英雄治疗后的技能
    /// </summary>
    public class HealServantLifeAction : Action.IGameAction
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            ServantActionParameter para = actionParameter as ServantActionParameter;
            BaseServant servant = para.Biology;
            GameContext gameContext = para.GameContext;
            Card triggerCard = para.SecondaryCard;

            servant.Life += para.DamageOrHeal;
            if (servant.Life > servant.BuffLife)
            {
                servant.Life = servant.BuffLife;
            }
            gameContext.TriggerCardAbility(servant, SpellCardAbilityTime.治疗, AbilityType.无, triggerCard);
            gameContext.TriggerCardAbility(actionParameter.GameContext.DeskCards, SpellCardAbilityTime.治疗随从, triggerCard, servant.DeskIndex);

            return null;
        }
    }
}
