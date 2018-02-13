using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter.Player;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Player;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter;
using System.Linq;
namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    internal class DropCard<UC, Q, P> : BaseCardAbility where UC : IUserContextFilter where Q : IQuantity where P : IPickType
    {
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            Q dropCount = GameActivator<Q>.CreateInstance();
            P pickType = GameActivator<P>.CreateInstance();
            UC uc = GameActivator<UC>.CreateInstance();
            var users = actionParameter.GameContext.Players.Where(uc.Filter(actionParameter));
            foreach (UserContext user in users)
            {
                DropCardActionParameter para = new DropCardActionParameter()
                {
                    MainCard = actionParameter.MainCard,
                    DropCount = dropCount.Quantity,
                    GameContext = actionParameter.GameContext,
                    UserContext = user,
                    DropCardType = pickType.PickType
                };
                new DropCardAction().Action(para);
            }
            return null;
        }
    }
}
