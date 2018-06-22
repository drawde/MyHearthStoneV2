using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Capture;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.AbilityAttribute;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.Event.Player;
using MyHearthStoneV2.Game.Parameter;
using System;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver
{
    /// <summary>
    /// 技能驱动器基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseDriver<T, F> : DefaultAttribute, ICardAbility where T : IGameAction where F : ICardLocationFilter
    {
        public virtual IActionOutputParameter Action(BaseActionParameter actionParameter)
        {            
            if (typeof(T).GetConstructor(Type.EmptyTypes) != null)
                return Activator.CreateInstance<T>().Action(actionParameter);
            return ((T)Activator.CreateInstance(typeof(T), actionParameter.TertiaryCard)).Action(actionParameter);
        }

        public virtual bool TryCapture(Card card, IEvent @event) => false;
    }
}