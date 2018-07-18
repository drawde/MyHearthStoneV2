using BattleForAzeroth.Game.Action;
using BattleForAzeroth.Game.Capture;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.Event;
using BattleForAzeroth.Game.Event.GameProcess;
using BattleForAzeroth.Game.Context;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.Driver
{
    public class MyTurnEndDriver<T, F> : BaseDriver<T, F>, ICapture<F, MyTurnEndEvent> where T : IGameAction where F : ICardLocationFilter
    {
        //public override List<SpellCardAbilityTime> SpellCardAbilityTimes { get; set; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.己方回合结束 };

        public override bool TryCapture(Card card, IEvent @event)
        {
            ICardLocationFilter filter = GameActivator<F>.CreateInstance();
            UserContext uc = @event.Parameter.GameContext.GetUserContextByMyCard(card);
            return filter.Filter(card) && @event.GetType() == typeof(MyTurnEndEvent) && @event.Parameter.GameContext.IsThisActivationUserCard(card);
        }
    }
}
