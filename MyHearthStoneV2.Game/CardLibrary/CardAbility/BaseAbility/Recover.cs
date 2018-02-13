using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Player;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Player;
using System.Linq;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    /// <summary>
    /// 将场上的牌返回到手牌
    /// </summary>
    /// <typeparam name="TAG"></typeparam>
    internal class Recover<TAG> : BaseCardAbility where TAG : IFilter
    {
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            TAG tag = GameActivator<TAG>.CreateInstance();
            foreach (BaseBiology biology in actionParameter.GameContext.DeskCards.Where(tag.Filter(actionParameter)).OrderBy(c => c.CastIndex))
            {
                UserContext user = actionParameter.GameContext.GetUserContextByMyCard(biology);
                ReturnCardToHandParameter para = new ReturnCardToHandParameter()
                {
                    ReturnCount = 1,
                    GameContext = actionParameter.GameContext,
                    UserContext = user,
                    MainCard = actionParameter.SecondaryCard
                };
                new ReturnCardToHandAction().Action(para);
            }
            return null;
        }
    }
}
