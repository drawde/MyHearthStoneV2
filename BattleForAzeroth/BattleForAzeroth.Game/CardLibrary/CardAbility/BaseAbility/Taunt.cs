using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.CardLibrary.Servant;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Event;
using BattleForAzeroth.Game.Parameter;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility
{
    /// <summary>
    /// 嘲讽
    /// </summary>
    public class Taunt<TAG> : ICardAbility where TAG : IParameterFilter
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
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
