using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Capture;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.Event.Player;
namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver
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
