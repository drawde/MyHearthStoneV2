using MyHearthStoneV2.Game.CardLibrary.CardAction.Controler;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Controler;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter;
using System.Linq;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Number;
using MyHearthStoneV2.Game.CardLibrary.Filter.Servant;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition;
using MyHearthStoneV2.Redis;
using System.Collections.Generic;
using System;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    /// <summary>
    /// 召唤一个随从到场上
    /// </summary>
    /// <typeparam name="F"></typeparam>
    public class Summon<UC, F, Num> : ICardAbility where UC : IUserContextFilter where F : IServantCardFilter where Num : INumber
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            int count = 0;
            Num summonCount = GameActivator<Num>.CreateInstance();
            UC uc = GameActivator<UC>.CreateInstance();
            var users = actionParameter.GameContext.Players.Where(uc.Filter(actionParameter));
            var filter = Activator.CreateInstance<F>();
            BaseServant servant = null;
            using (var redisClient = RedisManager.GetClient())
            {
                List<Card> lstCardLib = redisClient.Get<List<Card>>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.CardsInstance));
                servant = lstCardLib.Where(filter.Filter()).First() as BaseServant;
            }

            foreach (UserContext user in users)
            {
                while (count < summonCount.GetNumber(actionParameter))
                {
                    CreateNewCardInDeskAction action = new CreateNewCardInDeskAction();
                    //CreateNewGenericCardInDeskAction<F> action = new CreateNewGenericCardInDeskAction<F>();
                    ControlerActionParameter para = new ControlerActionParameter()
                    {
                        GameContext = actionParameter.GameContext,
                        IsActivation = user.IsActivation,
                        MainCard = servant
                    };
                    action.Action(para);
                    count++;
                }
            }
            return null;
        }

        public bool TryCapture(Card card, Event.IEvent @event) => false;
    }
}
