using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Servant;
using MyHearthStoneV2.Game.Parameter;

namespace MyHearthStoneV2.Game.Event.Player
{
    internal class CastServantEvent : IEvent
    {
        public Card EventCard { get; set; }
        public BaseActionParameter Parameter { get; set; }

        public void Settlement()
        {
            CastServantAction action = new CastServantAction();
            action.Action(Parameter);
            //CardActionFactory.CreateAction(EventCard, ActionType.进场).Action(para);
        }
    }
}
