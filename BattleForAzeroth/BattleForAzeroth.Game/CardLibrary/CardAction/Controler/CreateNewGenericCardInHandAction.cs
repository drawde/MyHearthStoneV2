using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Parameter;
using System;
using System.Linq;

namespace BattleForAzeroth.Game.CardLibrary.CardAction.Controler
{
    /// <summary>
    /// 创造一张牌到手牌
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CreateNewGenericCardInHandAction<T> : Action.IGameAction where T : Card
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            //ControlerActionParameter para = actionParameter as ControlerActionParameter;
            GameContext context = actionParameter.GameContext;
            UserContext userContext = actionParameter.UserContext;
            T card = Activator.CreateInstance<T>();
            string cardCode = actionParameter.GameContext.GameCache.GetAllCard().First(c => c.GetType() == typeof(T)).CardCode;
            card.IsFirstPlayerCard = userContext.IsFirst;
            card.CardCode = cardCode;
            //context.AllCard.Add(card);
            card.CardInGameCode = context.AllCard.Count().ToString();
            context.Players.First(c => c == userContext).AllCards.Add(card);

            if (userContext.HandCards.Count() < 10)
            {
                //如果手牌没满则放入手牌中
                //userContext.HandCards.Add(card);
                card.CardLocation = CardLocation.手牌;
            }
            else
            {
                //否则撕了这张牌
                card.CardLocation = CardLocation.坟场;
                //userContext.GraveyardCards.Add(card);
            }
            return card;
        }
    }
}
