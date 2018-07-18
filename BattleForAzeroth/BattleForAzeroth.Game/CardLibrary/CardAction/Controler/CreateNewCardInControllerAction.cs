using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Parameter;
using System;
using System.Linq;

namespace BattleForAzeroth.Game.CardLibrary.CardAction.Controler
{
    /// <summary>
    /// 创建一张牌
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CreateNewCardInControllerAction<T> : Action.IGameAction where T : Card
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            GameContext context = actionParameter.GameContext;
            UserContext userContext = actionParameter.UserContext;
            T card = Activator.CreateInstance<T>();
            string cardCode = actionParameter.GameContext.GameCache.GetAllCard().First(c => c.GetType() == typeof(T)).CardCode;

            card.CardCode = cardCode;
            card.IsFirstPlayerCard = userContext.IsFirst;
            //context.AllCard.Add(card);
            card.CardInGameCode = context.AllCard.Count().ToString();
            context.Players.First(c => c == userContext).AllCards.Add(card);
            return card;
        }
    }
}
