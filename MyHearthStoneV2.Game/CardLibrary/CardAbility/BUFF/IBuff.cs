using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using MyHearthStoneV2.Game.Event;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BUFF
{
    public interface IBuff<F, EVENT> : ICardAbility where F : ICardLocationFilter where EVENT : IEvent
    {

    }
}
