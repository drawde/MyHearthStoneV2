using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using System.Linq;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    /// <summary>
    /// 修改手牌的费用
    /// </summary>
    /// <typeparam name="TAG"></typeparam>
    /// <typeparam name="Q"></typeparam>
    /// <typeparam name="D"></typeparam>
    internal class UpdateCost<UC, TAG, Q, D> : BaseCardAbility where UC : IUserContextFilter where TAG : IFilter where Q : IQuantity where D : IDirection
    {
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            D direction = GameActivator<D>.CreateInstance();
            UC uc = GameActivator<UC>.CreateInstance();
            var users = actionParameter.GameContext.Players.Where(uc.Filter(actionParameter));
            foreach (UserContext user in users)
            {
                foreach (BaseBiology biology in user.HandCards.Where(GameActivator<TAG>.CreateInstance().Filter(actionParameter)))
                {
                    int quantity = direction.SetQuantity(GameActivator<Q>.CreateInstance());
                    biology.Cost += quantity;
                }
            }
            return null;
        }
    }
}
