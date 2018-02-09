using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter.Player;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Player;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    internal class DropCard<Q,P> : BaseCardAbility where Q : IQuantity where P : IPickType
    {
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            var uc = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.MainCard);
            Q dropCount = GameActivator<Q>.CreateInstance();
            P pickType = GameActivator<P>.CreateInstance();
            DropCardActionParameter para = new DropCardActionParameter()
            {
                MainCard = actionParameter.MainCard,
                DropCount = dropCount.Quantity,
                GameContext = actionParameter.GameContext,
                UserContext = uc,
                DropCardType = pickType.PickType
            };
            new DropCardAction().Action(para);
            return null;
        }
    }
}
