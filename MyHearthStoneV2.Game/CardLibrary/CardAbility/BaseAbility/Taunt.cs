using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    /// <summary>
    /// 嘲讽
    /// </summary>
    public class Taunt<TAG> : ICardAbility where TAG : IParameterFilter
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            foreach (BaseServant servant in actionParameter.GameContext.DeskCards.Where(Activator.CreateInstance<TAG>().Filter(actionParameter)).OrderBy(c => c.CastIndex))
            {
                servant.HasTaunt = true;
            }
            return null;
        }
        public bool TryCapture(Card card, IEvent @event) => false;
    }
}
