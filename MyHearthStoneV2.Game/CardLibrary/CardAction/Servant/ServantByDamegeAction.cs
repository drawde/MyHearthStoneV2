using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Servant;
using System.Collections.Generic;
using System.Linq;
namespace MyHearthStoneV2.Game.CardLibrary.CardAction.Servant
{
    /// <summary>
    /// 随从受到伤害（被火球砸、火冲点）
    /// </summary>
    public class ServantByDamegeAction : Action.IGameAction
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            ServantActionParameter para = actionParameter as ServantActionParameter;
            BaseServant servant = para.Biology;
            GameContext gameContext = para.GameContext;
            Card triggerCard = para.SecondaryCard;
            int damege = para.DamageOrHeal;
            
            if (servant.Abilities.Any(c => c.SpellCardAbilityTimes.Any(x => x == SpellCardAbilityTime.己方随从受到伤害前)))
            {
                gameContext.TriggerCardAbility(new List<Card>() { servant }, SpellCardAbilityTime.己方随从受到伤害前, triggerCard, servant.DeskIndex);
            }
            else
            {
                DeductionServantLifeAction dslAct = new DeductionServantLifeAction();
                ServantActionParameter dslPara = new ServantActionParameter()
                {
                    GameContext = gameContext,
                    Biology = servant,
                    SecondaryCard = triggerCard,
                    DamageOrHeal = damege,
                };
                dslAct.Action(dslPara);
                //DeductionBiologyLife(servant, gameContext, triggerCard, trueDamege);
            }
            gameContext.TriggerCardAbility(gameContext.DeskCards.GetDeskCardsByMyCard(servant), SpellCardAbilityTime.己方随从受到伤害后, triggerCard, servant.DeskIndex);

            return null;
        }
    }
}
