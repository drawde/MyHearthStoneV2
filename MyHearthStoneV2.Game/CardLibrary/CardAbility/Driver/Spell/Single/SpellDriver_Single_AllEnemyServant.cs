using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Capture;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using MyHearthStoneV2.Game.Event;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Spell.Single
{
    /// <summary>
    /// 单个目标法术驱动器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SpellDriver_Single_AllEnemyServant<T> : BaseSpellDriver<T>, ICapture<InParachuteFilter, NullEvent> where T : IGameAction
    {
        public override bool TryCapture(Card card, IEvent @event) => false;
        public override AbilityType AbilityType => AbilityType.法术;
        public override CastCrosshairStyle CastCrosshairStyle { get; set; } = CastCrosshairStyle.单个;
        public override CastStyle CastStyle => CastStyle.敌方随从;
    }
}
