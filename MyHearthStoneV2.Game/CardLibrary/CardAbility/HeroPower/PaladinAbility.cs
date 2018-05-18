using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.AbilityAttribute;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Controler;
using MyHearthStoneV2.Game.CardLibrary.Servant.Paladin;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Controler;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.HeroPower
{
    public class PaladinAbility : DefaultAttribute, IHeroAbility
    {
        public string PowerImage { get; } = "Paladin.png";
        public int Cost { get; set; } = 2;
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            var user = actionParameter.GameContext.GetActivationUserContext();
            CreateNewGenericCardInDeskAction<SilverHandRecruit> action = new CreateNewGenericCardInDeskAction<SilverHandRecruit>();
            ControlerActionParameter para = new ControlerActionParameter()
            {
                GameContext = actionParameter.GameContext,
                IsActivation = user.IsActivation,
            };
            return action.Action(para);
        }
        public bool TryCapture(Card card, IEvent @event) => false;
    }
}
