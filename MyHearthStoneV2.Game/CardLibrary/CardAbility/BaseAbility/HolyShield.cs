using MyHearthStoneV2.Common;
using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter;
using System;
using System.Linq;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    public class HolyShield<TAG> : ICardAbility where TAG : IParameterFilter
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            TAG tag = Activator.CreateInstance<TAG>();
            foreach (var card in actionParameter.GameContext.AllCard.Where(tag.Filter(actionParameter)).OrderBy(c => c.CastIndex))
            {
                BaseBiology biology = card as BaseBiology;
                biology.HasHolyShield = true;
            }
            return null;
        }
        public bool TryCapture(Card card, IEvent @event) => false;
    }
}
