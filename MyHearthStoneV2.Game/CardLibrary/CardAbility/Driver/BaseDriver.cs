using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Capture;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.AbilityAttribute;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
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
        public virtual IActionOutputParameter Action(BaseActionParameter actionParameter) => Activator.CreateInstance<T>().Action(actionParameter);

        public virtual bool TryCapture(Card card, IEvent @event) => false;
    }
}