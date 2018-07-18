using BattleForAzeroth.Game.Action;
using BattleForAzeroth.Game.Capture;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.Event;
using BattleForAzeroth.Game.Event.Player;
namespace BattleForAzeroth.Game.CardLibrary.CardAbility.Driver
{
    /// <summary>
    /// 法术驱动器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseSpellDriver<T> : BaseDriver<T, InParachuteFilter>, ICapture<InParachuteFilter, NullEvent> where T : IGameAction
    {
        public override AbilityType AbilityType => AbilityType.法术;
        public override CastCrosshairStyle CastCrosshairStyle { get; set; } = CastCrosshairStyle.无;

        public override bool TryCapture(Card card, IEvent @event) => false;

    }
}
