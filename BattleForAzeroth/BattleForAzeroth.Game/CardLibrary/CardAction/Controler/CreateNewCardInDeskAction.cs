using BattleForAzeroth.Game.Action;
using BattleForAzeroth.Game.CardLibrary.Servant;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Event.Servant;
using BattleForAzeroth.Game.Parameter;
using System.Linq;

namespace BattleForAzeroth.Game.CardLibrary.CardAction.Controler
{
    /// <summary>
    /// 创造一张牌到场内
    /// </summary>
    public class CreateNewCardInDeskAction
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            GameContext context = actionParameter.GameContext;
            bool isActivation = actionParameter.IsActivation;

            BaseServant servant = actionParameter.PrimaryCard as BaseServant;
            string cardCode = actionParameter.GameContext.GameCache.GetAllCard().First(c => c.GetType() == servant.GetType()).CardCode;

            servant.CardCode = cardCode;

            var player = context.Players.First(c => c.IsActivation == isActivation);
            servant.IsFirstPlayerCard = player.IsFirst;
            int deskIndex = -1;
            int searchCount = 0;
            for (int i = player.IsFirst ? 0 : 8; i < context.DeskCards.Count; i++)
            {
                searchCount++;
                if (searchCount > 8)
                {
                    break;
                }
                if (context.DeskCards[i] == null)
                {
                    deskIndex = i;
                    break;
                }
            }
            if (deskIndex < 0)
            {
                return null;
            }
            context.CastCardCount++;
            servant.CastIndex = context.CastCardCount;
            //context.AllCard.Add(servant);
            servant.DeskIndex = deskIndex;
            servant.CardInGameCode = context.AllCard.Count().ToString();
            context.DeskCards[deskIndex] = servant;
            player.AllCards.Add(servant);

            ActionParameter castPara = new ActionParameter()
            {
                PrimaryCard = servant,
                GameContext = actionParameter.GameContext,
                DeskIndex = deskIndex
            };
            CardActionFactory.CreateAction(servant, ActionType.进场).Action(castPara);
            //servant.Cast(context, deskIndex, -1);

            context.EventQueue.AddLast(new ServantInDeskEvent() { EventCard = servant, Parameter = actionParameter });
            return servant;
        }
    }
}
