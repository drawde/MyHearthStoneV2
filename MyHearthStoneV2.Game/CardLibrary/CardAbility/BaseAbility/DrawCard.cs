using MyHearthStoneV2.Game.CardLibrary.CardAction.Player;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Player;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter;
using System.Linq;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Quantity;
namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    public class DrawCard<UC, D> : IBaseCardAbility where UC : IUserContextFilter where D : IQuantity
    {
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            D drawCount = GameActivator<D>.CreateInstance();
            UC uc = GameActivator<UC>.CreateInstance();
            var users = actionParameter.GameContext.Players.Where(uc.Filter(actionParameter));
            foreach (UserContext user in users)
            {
                DrawCardActionParameter para = new DrawCardActionParameter()
                {
                    DrawCount = drawCount.Quantity,
                    GameContext = actionParameter.GameContext,
                    UserContext = user
                };
                new DrawCardAction().Action(para);
            }
            return null;
        }
    }
}
