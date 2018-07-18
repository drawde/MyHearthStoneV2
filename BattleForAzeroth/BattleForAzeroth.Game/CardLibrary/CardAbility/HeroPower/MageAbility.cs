using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.CardLibrary.CardAction.Hero;
using BattleForAzeroth.Game.CardLibrary.Hero;
using BattleForAzeroth.Game.Parameter;

using BattleForAzeroth.Game.Action;
using BattleForAzeroth.Game.CardLibrary.CardAbility.AbilityAttribute;
using BattleForAzeroth.Game.Event;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.HeroPower
{
    public class MageAbility : DefaultAttribute, IHeroAbility
    {
        public string PowerImage { get; } = "Mage.png";
        public override CastCrosshairStyle CastCrosshairStyle { get; set; } = CastCrosshairStyle.单个;
        public int Cost { get; set; } = 2;
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            var uc = actionParameter.GameContext.GetActivationUserContext();
            var hero = actionParameter.PrimaryCard as BaseHero;

            ActionParameter para = new ActionParameter
            {
                PrimaryCard = actionParameter.SecondaryCard,
                GameContext = actionParameter.GameContext,
                DamageOrHeal = 1,
                SecondaryCard = hero
            };
            CardActionFactory.CreateAction(actionParameter.SecondaryCard, ActionType.受到伤害).Action(para);            
            return null;
        }
        public bool TryCapture(Card card, IEvent @event) => false;
    }
}
