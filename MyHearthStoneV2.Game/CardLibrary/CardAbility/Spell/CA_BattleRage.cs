using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Context;
using System.Linq;
using MyHearthStoneV2.Game.Parameter.Player;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Player;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Spell
{
    public class CA_BattleRage : BaseCardAbility
    {
        public override AbilityType AbilityType { get; set; } = AbilityType.法术;
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            UserContext uc = actionParameter.GameContext.GetActivationUserContext();
            var deskCards = actionParameter.GameContext.DeskCards.GetDeskCardsByIsFirst(uc.IsFirst);
            int drawCount = deskCards.Count(c => c != null && c.Life < c.BuffLife);
            DrawCardActionParameter para = new DrawCardActionParameter()
            {
                DrawCount = drawCount,
                GameContext = actionParameter.GameContext,
                UserContext = uc
            };
            new DrawCardAction().Action(para);
            return null;
        }
    }
}
