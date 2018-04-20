using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Servant;

namespace MyHearthStoneV2.Game.CardLibrary.CardAction.Servant
{
    /// <summary>
    /// 随从受到伤害时，扣除它的生命值，然后触发随从或英雄受伤后的技能
    /// </summary>
    public class DeductionServantLifeAction : Action.IGameAction
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            ServantActionParameter para = actionParameter as ServantActionParameter;
            BaseServant servant = para.Biology;
            GameContext gameContext = para.GameContext;
            Card triggerCard = para.SecondaryCard;

            servant.Life -= para.DamageOrHeal;
            gameContext.TriggerCardAbility(servant, SpellCardAbilityTime.受伤, AbilityType.无, triggerCard);
            gameContext.TriggerCardAbility(actionParameter.GameContext.DeskCards, SpellCardAbilityTime.随从受伤, triggerCard, servant.DeskIndex);

            return null;
        }
    }
}
