using MyHearthStoneV2.Game.CardLibrary;
using MyHearthStoneV2.Game.Parameter;
namespace MyHearthStoneV2.Game.Event.Trigger
{
    public class AnyServantHurtEvent : RespondEvent, IEvent
    {
        public Card EventCard { get; set; }
        public BaseActionParameter Parameter { get; set; }

        public void Settlement()
        {
            //BaseCardAbility ca = EventCard.Abilities.First(c => c.SpellCardAbilityTimes.Any(x => x == SpellCardAbilityTime.随从受伤));
            //CardAbilityParameter para = new CardAbilityParameter()
            //{
            //    GameContext = Parameter.GameContext,
            //    MainCard = EventCard,
            //    SecondaryCard = Parameter.SecondaryCard,
            //    MainCardLocation = -1,
            //};

            //Parameter.GameContext.AddActionStatement(ca, para);

            Respond(this);
        }
    }
}
