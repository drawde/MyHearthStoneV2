using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Capture;
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
    public class BaseDriver<T, F> : IBaseCardAbility, ICapture<F, NullEvent> where T : IGameAction where F : ICardLocationFilter
    {
        public virtual PriorityOfSettlement PriorityOfSettlement { get; set; } = PriorityOfSettlement.无;
        public virtual CastStyle CastStyle { get; set; } = CastStyle.无;
        public virtual CastCrosshairStyle CastCrosshairStyle { get; set; } = CastCrosshairStyle.无;

        public virtual List<SpellCardAbilityTime> SpellCardAbilityTimes { get; set; } = new List<SpellCardAbilityTime>();

        public virtual AbilityType AbilityType { get; set; } = AbilityType.无;

        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            Activator.CreateInstance<T>().Action(actionParameter);
            return null;
        }

        public new virtual bool TryCapture(Card card, IEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
