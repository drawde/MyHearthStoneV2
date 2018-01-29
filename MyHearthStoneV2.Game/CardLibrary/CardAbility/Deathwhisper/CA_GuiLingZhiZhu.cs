using MyHearthStoneV2.Game.Controler;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.NAXX;
using System.Collections.Generic;
using System.Linq;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Controler;
using MyHearthStoneV2.Game.Parameter.Controler;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Deathwhisper
{
    public class CA_GuiLingZhiZhu : BaseCardAbility
    {
        public override AbilityType AbilityType { get; set; } = AbilityType.亡语;
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            var userContext = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.MainCard);
            int count = 0;
            bool isActivation = actionParameter.GameContext.IsThisActivationUserCard(actionParameter.MainCard);
            while (count < 2)
            {
                CreateNewCardInDeskAction<XiaoZhiZhu> action = new CreateNewCardInDeskAction<XiaoZhiZhu>();
                ControlerActionParameter para = new ControlerActionParameter()
                {
                    GameContext = actionParameter.GameContext,
                    IsActivation =isActivation,
                };
                action.Action(para);
                //actionParameter.GameContext.AddActionStatement(action, para);
                //actionParameter.GameContext.CreateNewCardInDesk<XiaoZhiZhu>(isActivation);
                count++;
            }
            return null;
        }
    }
}
