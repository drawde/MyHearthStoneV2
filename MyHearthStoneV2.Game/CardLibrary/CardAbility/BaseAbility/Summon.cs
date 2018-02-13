using MyHearthStoneV2.Game.CardLibrary.CardAction.Controler;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Controler;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter;
using System.Linq;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    /// <summary>
    /// 召唤一个随从到场上
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class Summon<UC, T, C> : BaseCardAbility where UC : IUserContextFilter where T : BaseServant where C : IQuantity
    {
        //public int SummonCount { get; set; } = 2;
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            int count = 0;
            C summonCount = GameActivator<C>.CreateInstance();
            UC uc = GameActivator<UC>.CreateInstance();
            var users = actionParameter.GameContext.Players.Where(uc.Filter(actionParameter));
            foreach (UserContext user in users)
            {
                while (count < summonCount.Quantity)
                {
                    CreateNewGenericCardInDeskAction<T> action = new CreateNewGenericCardInDeskAction<T>();
                    ControlerActionParameter para = new ControlerActionParameter()
                    {
                        GameContext = actionParameter.GameContext,
                        IsActivation = user.IsActivation,
                    };
                    action.Action(para);
                    count++;
                }
            }
            return null;
        }
    }
}
