using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Aura
{
    public interface IAura : ICardAbility
    {
        Card AuraCard { get; set; }
        ICardLocationFilter LocationFilter { get; set; }
        void RestoreAura(Parameter.BaseActionParameter actionParameter);
    }
}
