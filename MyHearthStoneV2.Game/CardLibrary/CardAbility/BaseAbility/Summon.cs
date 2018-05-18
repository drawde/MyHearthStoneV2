using MyHearthStoneV2.Game.CardLibrary.CardAction.Controler;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Controler;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter;
using System.Linq;
using MyHearthStoneV2.Game.Widget.Number;
using MyHearthStoneV2.Game.Widget.Filter.Servant;
using MyHearthStoneV2.Redis;
using System.Collections.Generic;
using System;
using MyHearthStoneV2.Game.Widget.Filter.PickCard;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    /// <summary>
    /// 召唤一个随从到场上
    /// </summary>
    /// <typeparam name="F"></typeparam>
    public class Summon<UC, CardLocation, F, CardPick, NUM> : ICardAbility where UC : IUserContextFilter where F : IServantCardFilter where CardPick : ICardPickFilter where NUM : INumber where CardLocation : ICardLocationFilter
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            UC uc = GameActivator<UC>.CreateInstance();
            var users = actionParameter.GameContext.Players.Where(uc.Filter(actionParameter));
            var filter = Activator.CreateInstance<F>();
            CardLocation cardLocation = GameActivator<CardLocation>.CreateInstance();
            List<Card> summonCards = new List<Card>();
            CardPick cardPick = Activator.CreateInstance<CardPick>();

            using (var redisClient = RedisManager.GetClient())
            {
                List<Card> lstCardLib = redisClient.Get<List<Card>>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.CardsInstance));
                summonCards.AddRange(lstCardLib.Where(filter.Filter()));
            }
            NUM num = GameActivator<NUM>.CreateInstance();
            foreach (UserContext user in users)
            {
                summonCards = cardPick.Filter(summonCards.Where(c => user.AllCards.Where(x => cardLocation.Filter(x)).Any(z => z.CardCode == c.CardCode)).ToList(), actionParameter).ToList();
                foreach (Card card in summonCards)
                {
                    for (int i = 0; i < num.GetNumber(actionParameter); i++)
                    {
                        var newCard = Activator.CreateInstance(card.GetType()) as Card;
                        newCard.CardCode = card.CardCode;
                        CreateNewCardInDeskAction action = new CreateNewCardInDeskAction();
                        ControlerActionParameter para = new ControlerActionParameter()
                        {
                            GameContext = actionParameter.GameContext,
                            IsActivation = user.IsActivation,
                            PrimaryCard = newCard
                        };
                        action.Action(para);
                    }
                }
            }
            return null;
        }

        public bool TryCapture(Card card, Event.IEvent @event) => false;
    }
}
