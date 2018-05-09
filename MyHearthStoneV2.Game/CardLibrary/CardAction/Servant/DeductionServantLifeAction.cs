using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Event.Trigger;
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
            BaseServant servant = para.Servant;
            GameContext gameContext = para.GameContext;
            Card triggerCard = para.SecondaryCard;

            if (servant.HasHolyShield)
            {
                servant.HasHolyShield = false;
            }
            else if (servant.HasPoison)
            {
                servant.IsDeathing = true;
            }
            else
            {
                servant.Life -= para.DamageOrHeal;
            }

            gameContext.EventQueue.AddLast(new MyServantHurtEvent() { EventCard = servant, Parameter = para }); 
            gameContext.EventQueue.AddLast(new AnyServantHurtEvent() { EventCard = servant, Parameter = para });
            gameContext.EventQueue.AddLast(new AnyHurtEvent() { EventCard = servant, Parameter = para });            
            return null;
        }
    }
}
