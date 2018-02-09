using MyHearthStoneV2.Game.CardLibrary.CardAction.Player;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Player;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    internal class DrawCard<D> : BaseCardAbility where D : IQuantity
    {
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            D drawCount = GameActivator<D>.CreateInstance();
            var uc = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.MainCard);
            DrawCardActionParameter para = new DrawCardActionParameter()
            {
                DrawCount = drawCount.Quantity,
                GameContext = actionParameter.GameContext,
                UserContext = uc
            };
            new DrawCardAction().Action(para);
            return null;
        }
    }
}
