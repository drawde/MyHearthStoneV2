using System.Collections.Generic;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Controler;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.BlackrockMountain;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Controler;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Observer
{
    public class CA_GrimPatron : BaseCardAbility
    {
        public override AbilityType AbilityType { get; set; } = AbilityType.触发;
        public override List<SpellCardAbilityTime> SpellCardAbilityTimes { get;  set; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.随从受伤 };
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            BaseServant servant = actionParameter.MainCard as BaseServant;
            if (servant.Life > 0)
            {
                bool isActivation = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.MainCard).IsActivation;
                CreateNewGenericCardInDeskAction<GrimPatron> action = new CreateNewGenericCardInDeskAction<GrimPatron>();
                ControlerActionParameter para = new ControlerActionParameter()
                {
                    GameContext = actionParameter.GameContext,
                    IsActivation = isActivation,
                };
                action.Action(para);
                //actionParameter.GameContext.AddActionStatement(action, para);
            }
            return null;
        }
    }
}
