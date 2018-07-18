using BattleForAzeroth.Game.Action;
using BattleForAzeroth.Game.CardLibrary.CardAbility.AbilityAttribute;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Event;
using BattleForAzeroth.Game.Parameter;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.HeroPower
{
    public class DruidAbility : DefaultAttribute, IHeroAbility
    {
        public string PowerImage { get; } = "Druid.png";
        public int Cost { get; set; } = 2;
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            var uc = actionParameter.GameContext.GetActivationUserContext();
            var hero = actionParameter.GameContext.DeskCards.GetHeroByIsFirst(uc.IsFirst);
            hero.Ammo += 1;
            hero.Damage += 1;
            ActionParameter para = new ActionParameter
            {
                PrimaryCard = actionParameter.PrimaryCard,
                GameContext = actionParameter.GameContext
            };
            CardActionFactory.CreateAction(actionParameter.PrimaryCard, ActionType.重置攻击次数).Action(para);

            return null;
        }
        public bool TryCapture(Card card, IEvent @event) => false;
    }
}
