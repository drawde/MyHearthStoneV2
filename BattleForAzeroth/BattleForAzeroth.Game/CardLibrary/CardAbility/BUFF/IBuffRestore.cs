using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.Event;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.BUFF
{
    public interface IBuffRestore<F, EVENT> : ICardAbility where F : ICardLocationFilter where EVENT : IEvent
    {
        Card MasterCard { get; set; }
    }
}
