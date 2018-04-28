using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.AbilityAttribute;
using MyHearthStoneV2.Game.Event;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.HeroPower
{
    public class WarriorAbility : DefaultAttribute, IHeroAbility
    {
        public string PowerImage { get; } = "Druid.png";
        public int Cost { get; set; } = 2;
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            var uc = actionParameter.GameContext.GetActivationUserContext();
            var hero = actionParameter.GameContext.DeskCards.GetHeroByIsFirst(uc.IsFirst);
            hero.Ammo += 2;
            return null;
        }
        public bool TryCapture(Card card, IEvent @event) => false;
    }
}
