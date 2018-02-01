using MyHearthStoneV2.Game.CardLibrary.CardAction.Controler;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Controler;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.NAXX;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Deathwhisper
{
    public class CA_NerubianEgg : BaseCardAbility
    {
        public override AbilityType AbilityType { get; set; } = AbilityType.亡语;
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            var userContext = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.MainCard);            
            bool isActivation = actionParameter.GameContext.IsThisActivationUserCard(actionParameter.MainCard);
            CreateNewGenericCardInDeskAction<Nerubian> action = new CreateNewGenericCardInDeskAction<Nerubian>();
            ControlerActionParameter para = new ControlerActionParameter()
            {
                GameContext = actionParameter.GameContext,
                IsActivation = isActivation,
            };
            action.Action(para);
            return null;
        }
    }
}
