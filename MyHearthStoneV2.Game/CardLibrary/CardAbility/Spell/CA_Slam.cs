﻿using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Player;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Player;
using MyHearthStoneV2.Game.Context;
namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Spell
{
    public class CA_Slam : BaseCardAbility
    {
        public override AbilityType AbilityType { get; set; } = AbilityType.法术;
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            BaseServant servant = actionParameter.SecondaryCard as BaseServant;
            var huntPara = CardActionFactory.CreateParameter(servant, actionParameter.GameContext, 2, secondaryCard: actionParameter.MainCard);
            CardActionFactory.CreateAction(servant, ActionType.受到伤害).Action(huntPara);

            if (servant.Life > 0)
            {
                DrawCardActionParameter para = new DrawCardActionParameter()
                {
                    DrawCount = 1,
                    GameContext = actionParameter.GameContext,
                    UserContext = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.MainCard)
                };
                new DrawCardAction().Action(para);
            }
            return null;
        }
    }
}
