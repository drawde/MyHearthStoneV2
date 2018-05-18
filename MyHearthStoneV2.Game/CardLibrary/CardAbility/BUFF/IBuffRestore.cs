using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using MyHearthStoneV2.Game.Event;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BUFF
{
    public interface IBuffRestore<F, EVENT> : ICardAbility where F : ICardLocationFilter where EVENT : IEvent
    {
        Card MasterCard { get; set; }
    }
}
