using BattleForAzeroth.Game.Action;
using BattleForAzeroth.Game.Parameter;
using System.Linq;
using BattleForAzeroth.Game.Widget.Number;
using System;
using BattleForAzeroth.Game.Event;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility
{
    public class Heal<TAG, C> : ICardAbility where TAG : IParameterFilter where C : INumber
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            TAG tag = Activator.CreateInstance<TAG>();
            C qat = GameActivator<C>.CreateInstance();

            foreach (BaseBiology biology in actionParameter.GameContext.DeskCards.Where(tag.Filter(actionParameter)).OrderBy(c => c.CastIndex))
            {
                var para = new ActionParameter
                {
                    PrimaryCard = biology,
                    GameContext = actionParameter.GameContext,
                    DamageOrHeal = qat.GetNumber(actionParameter),
                    SecondaryCard = actionParameter.PrimaryCard
                };
                CardActionFactory.CreateAction(biology, ActionType.受到治疗).Action(para);
            }
            return null;
        }
        public bool TryCapture(Card card, IEvent @event) => false;
    }
}
