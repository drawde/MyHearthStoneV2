using BattleForAzeroth.Game.Action;
using BattleForAzeroth.Game.Parameter;
using System.Linq;
using System;
using BattleForAzeroth.Game.Event;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility
{
    public class AddDamage<TAG,Q> : ICardAbility where TAG : IParameterFilter where Q : INumber
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            foreach (BaseBiology biology in actionParameter.GameContext.DeskCards.Where(Activator.CreateInstance<TAG>().Filter(actionParameter)).OrderBy(c => c.CastIndex))
            {
                biology.Damage += GameActivator<Q>.CreateInstance().GetNumber(actionParameter);
                ActionParameter para = new ActionParameter()
                {
                    PrimaryCard = biology,
                    GameContext = actionParameter.GameContext
                }; ;
                
                CardActionFactory.CreateAction(biology, ActionType.重置攻击次数).Action(para);
            }
            return null;
        }
        public bool TryCapture(Card card, IEvent @event) => false;
    }
}
