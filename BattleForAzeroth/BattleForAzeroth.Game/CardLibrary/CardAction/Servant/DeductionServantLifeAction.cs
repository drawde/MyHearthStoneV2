using BattleForAzeroth.Game.Action;
using BattleForAzeroth.Game.CardLibrary.Servant;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Event.Trigger;
using BattleForAzeroth.Game.Parameter;


namespace BattleForAzeroth.Game.CardLibrary.CardAction.Servant
{
    /// <summary>
    /// 随从受到伤害时，扣除它的生命值，然后触发随从或英雄受伤后的技能
    /// </summary>
    public class DeductionServantLifeAction : Action.IGameAction
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            BaseServant servant = actionParameter.PrimaryCard as BaseServant;
            GameContext gameContext = actionParameter.GameContext;
            Card triggerCard = actionParameter.SecondaryCard;

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
                servant.Life -= actionParameter.DamageOrHeal;
            }

            gameContext.EventQueue.AddLast(new MyServantHurtEvent() { EventCard = servant, Parameter = actionParameter }); 
            gameContext.EventQueue.AddLast(new AnyServantHurtEvent() { EventCard = servant, Parameter = actionParameter });
            gameContext.EventQueue.AddLast(new AnyHurtEvent() { EventCard = servant, Parameter = actionParameter });            
            return null;
        }
    }
}
