using BattleForAzeroth.Game.Parameter;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.CardLibrary.CardAbility.AbilityAttribute;
using BattleForAzeroth.Game.Event;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.HeroPower
{
    public class WarriorAbility : DefaultAttribute, IHeroAbility
    {
        public string PowerImage { get; } = "Druid.png";
        public int Cost { get; set; } = 2;
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            var uc = actionParameter.GameContext.GetActivationUserContext();
            var hero = actionParameter.GameContext.DeskCards.GetHeroByIsFirst(uc.IsFirst);
            hero.Ammo += 2;
            return null;
        }
        public bool TryCapture(Card card, IEvent @event) => false;
    }
}
