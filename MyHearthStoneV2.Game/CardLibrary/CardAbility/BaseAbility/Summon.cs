using MyHearthStoneV2.Game.CardLibrary.CardAction.Controler;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Controler;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    /// <summary>
    /// 召唤一个随从到场上
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class Summon<T,C> : BaseCardAbility where T : BaseServant where C : IQuantity
    {
        //public int SummonCount { get; set; } = 2;
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            int count = 0;
            C summonCount = GameActivator<C>.CreateInstance();
            bool isActivation = actionParameter.GameContext.IsThisActivationUserCard(actionParameter.MainCard);
            while (count < summonCount.Quantity)
            {
                CreateNewGenericCardInDeskAction<T> action = new CreateNewGenericCardInDeskAction<T>();
                ControlerActionParameter para = new ControlerActionParameter()
                {
                    GameContext = actionParameter.GameContext,
                    IsActivation = isActivation,
                };
                action.Action(para);
                count++;
            }
            return null;
        }
    }
}
