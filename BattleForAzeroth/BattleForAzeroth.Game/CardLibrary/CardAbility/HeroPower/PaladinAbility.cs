using BattleForAzeroth.Game.CardLibrary.CardAbility.AbilityAttribute;
using BattleForAzeroth.Game.CardLibrary.CardAction.Controler;
using BattleForAzeroth.Game.CardLibrary.Servant.Paladin;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Event;
using BattleForAzeroth.Game.Parameter;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.HeroPower
{
    public class PaladinAbility : DefaultAttribute, IHeroAbility
    {
        public string PowerImage { get; } = "Paladin.png";
        public int Cost { get; set; } = 2;
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            var user = actionParameter.GameContext.GetActivationUserContext();
            CreateNewGenericCardInDeskAction<SilverHandRecruit> action = new CreateNewGenericCardInDeskAction<SilverHandRecruit>();
            var para = new ActionParameter()
            {
                GameContext = actionParameter.GameContext,
                IsActivation = user.IsActivation,
            };
            return action.Action(para);
        }
        public bool TryCapture(Card card, IEvent @event) => false;
    }
}
