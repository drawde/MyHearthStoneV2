using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.Aura
{
    public interface IAura : ICardAbility
    {
        Card AuraCard { get; set; }
        ICardLocationFilter LocationFilter { get; set; }
        void RestoreAura(Parameter.ActionParameter actionParameter);
    }
}
