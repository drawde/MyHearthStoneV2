using BattleForAzeroth.Game.Action;
using BattleForAzeroth.Game.Capture;
using BattleForAzeroth.Game.CardLibrary.CardAbility.AbilityAttribute;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.Event;
using BattleForAzeroth.Game.Event.Player;
using BattleForAzeroth.Game.Parameter;
using System;
using System.Collections.Generic;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.Driver
{
    /// <summary>
    /// 技能驱动器基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseDriver<T, F> : DefaultAttribute, ICardAbility where T : IGameAction where F : ICardLocationFilter
    {
        public virtual IActionOutputParameter Action(ActionParameter actionParameter)
        {            
            if (typeof(T).GetConstructor(Type.EmptyTypes) != null)
                return Activator.CreateInstance<T>().Action(actionParameter);
            return ((T)Activator.CreateInstance(typeof(T), actionParameter.TertiaryCard)).Action(actionParameter);
        }

        public virtual bool TryCapture(Card card, IEvent @event) => false;
    }
}