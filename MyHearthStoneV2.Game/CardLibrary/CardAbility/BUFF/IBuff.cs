using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.Parameter;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BUFF
{
    public interface IBuff<F, EVENT, RE> : ICardAbility where F : ICardLocationFilter where EVENT : IEvent where RE: IBuffRestore<ICardLocationFilter, IEvent>
    {
        Card MasterCard { get; set; }
        IBuffRestore<ICardLocationFilter, IEvent> BuffRestore { get; set; }
        //IActionOutputParameter Restore(BaseActionParameter actionParameter);
    }
}
