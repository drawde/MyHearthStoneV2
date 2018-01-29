using System.Collections.Generic;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Controler;
using System.Linq;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Servant;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Action;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Spell
{
    public class CA_Whirlwind : BaseCardAbility
    {
        public override AbilityType AbilityType { get; set; } = AbilityType.法术;
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            foreach (var servant in actionParameter.GameContext.DeskCards.Where(c => c != null && c.CardType == CardType.随从).OrderBy(c => c.CastIndex))
            {
                BaseActionParameter para = CardActionFactory.CreateParameter(servant, actionParameter.GameContext, 1, secondaryCard: actionParameter.MainCard);
                CardActionFactory.CreateAction(servant, ActionType.受到伤害).Action(para);
            }
            return null;
        }
    }
}
