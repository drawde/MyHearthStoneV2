using MyHearthStoneV2.Game.CardLibrary;
using MyHearthStoneV2.Game.Parameter;
namespace MyHearthStoneV2.Game.Event.Trigger
{
    public class MyServantCastedEvent : RespondEvent, IEvent
    {
        public Card EventCard { get; set; }
        public BaseActionParameter Parameter { get; set; }

        public void Settlement()
        {
            Respond(this);
        }
    }
}
