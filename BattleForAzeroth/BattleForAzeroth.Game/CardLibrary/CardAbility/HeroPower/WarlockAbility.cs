using BattleForAzeroth.Game.CardLibrary.CardAbility.AbilityAttribute;
using BattleForAzeroth.Game.CardLibrary.CardAction.Player;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Event;
using BattleForAzeroth.Game.Parameter;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.HeroPower
{
    public class WarlockAbility : DefaultAttribute, IHeroAbility
    {
        public string PowerImage { get; } = "Warlock.png";
        public int Cost { get; set; } = 2;
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            var uc = actionParameter.GameContext.GetActivationUserContext();
            var hero = actionParameter.GameContext.DeskCards.GetHeroByIsFirst(uc.IsFirst);
            hero.Life -= 2;
            var para = new ActionParameter()
            {
                DrawCount = 1,
                GameContext = actionParameter.GameContext,
                UserContext = uc
            };
            new DrawCardAction().Action(para);
            //actionParameter.GameContext.DrawCard();
            return null;
        }
        public bool TryCapture(Card card, IEvent @event) => false;
    }
}
