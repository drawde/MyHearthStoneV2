using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Capture;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using MyHearthStoneV2.Game.Event;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Spell
{
    public class NoneTargetSpellDriver<T> : BaseSpellDriver<T>, ICapture<InParachuteFilter, NullEvent> where T : IGameAction
    {
        public override bool TryCapture(Card card, IEvent @event) => false;

        public override AbilityType AbilityType => AbilityType.法术;
    }
}
