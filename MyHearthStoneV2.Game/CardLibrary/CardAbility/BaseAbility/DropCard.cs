using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter.Player;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Player;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    public class DropCard : BaseCardAbility
    {
        public int DropCount { get; set; } = 1;
        public DropCardType DropCardType { get; set; } = DropCardType.随机;
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            var uc = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.MainCard);
            DropCardActionParameter para = new DropCardActionParameter()
            {
                MainCard = actionParameter.MainCard,
                DropCount = DropCount,
                GameContext = actionParameter.GameContext,
                UserContext = uc,
                DropCardType = DropCardType
            };
            new DropCardAction().Action(para);
            return null;
        }
    }
}
