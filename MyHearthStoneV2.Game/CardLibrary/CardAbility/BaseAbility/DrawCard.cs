using MyHearthStoneV2.Game.CardLibrary.CardAction.Player;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Player;
using MyHearthStoneV2.Game.Context;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    public class DrawCard : BaseCardAbility
    {
        public int DrawCount { get; set; } = 1;
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            var uc = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.MainCard);
            DrawCardActionParameter para = new DrawCardActionParameter()
            {
                DrawCount = DrawCount,
                GameContext = actionParameter.GameContext,
                UserContext = uc
            };
            new DrawCardAction().Action(para);
            return null;
        }
    }
}
