using BattleForAzeroth.Game.Action;
using BattleForAzeroth.Game.Capture;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.Event;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.Driver.Spell.Single
{
    public class AllTargetSpellDriver<T> : BaseSpellDriver<T>, ICapture<InParachuteFilter, NullEvent> where T : IGameAction
    {
        public override bool TryCapture(Card card, IEvent @event) => false;

        public override AbilityType AbilityType => AbilityType.法术;
        public override CastCrosshairStyle CastCrosshairStyle { get; set; } = CastCrosshairStyle.单个;
        public override CastStyle CastStyle => CastStyle.无限制;
    }
}
