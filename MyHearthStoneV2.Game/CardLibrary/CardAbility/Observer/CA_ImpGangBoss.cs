using MyHearthStoneV2.Game.CardLibrary.CardAction.Controler;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Controler;
using System;
using System.Collections.Generic;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary.Servant.Warlock;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Observer
{
    public class CA_ImpGangBoss : BaseCardAbility
    {
        public override AbilityType AbilityType { get; set; } = AbilityType.触发;
        public override List<SpellCardAbilityTime> SpellCardAbilityTimes { get; set; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.随从受伤 };
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            bool isActivation = actionParameter.GameContext.IsThisActivationUserCard(actionParameter.MainCard);
            CreateNewGenericCardInDeskAction<Imp> action = new CreateNewGenericCardInDeskAction<Imp>();
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
