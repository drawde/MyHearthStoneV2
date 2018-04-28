using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Capture;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.Parameter;
using System;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver
{
    /// <summary>
    /// 双技能驱动
    /// </summary>
    /// <typeparam name="G1"></typeparam>
    /// <typeparam name="G2"></typeparam>
    public class DoubleActionDriver<G1, G2, F> : BaseDriver<G1, F>, ICapture<F, IEvent> where G1 : IGameAction where G2 : IGameAction where F : ICardLocationFilter
    {
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            Activator.CreateInstance<G1>().Action(actionParameter);
            Activator.CreateInstance<G2>().Action(actionParameter);
            return null;
        }

        public override bool TryCapture(Card card, IEvent @event) => false;
    }
}
