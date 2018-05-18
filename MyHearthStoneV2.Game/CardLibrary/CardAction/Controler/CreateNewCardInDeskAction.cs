using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Event.Servant;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Controler;
using MyHearthStoneV2.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.CardAction.Controler
{
    /// <summary>
    /// 创造一张牌到场内
    /// </summary>
    public class CreateNewCardInDeskAction
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            ControlerActionParameter para = actionParameter as ControlerActionParameter;
            GameContext context = para.GameContext;
            bool isActivation = para.IsActivation;

            BaseServant servant = para.PrimaryCard as BaseServant;
            string cardCode = "";
            using (var redisClient = RedisManager.GetClient())
            {
                List<Card> lstCardLib = redisClient.Get<List<Card>>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.CardsInstance));
                cardCode = lstCardLib.First(c => c.GetType() == servant.GetType()).CardCode;
            }
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
            context.AllCard.Add(servant);
            servant.DeskIndex = deskIndex;
            servant.CardInGameCode = context.AllCard.Count.ToString();
            context.DeskCards[deskIndex] = servant;
            player.AllCards.Add(servant);

            BaseActionParameter castPara = CardActionFactory.CreateParameter(servant, actionParameter.GameContext, deskIndex: deskIndex);
            CardActionFactory.CreateAction(servant, ActionType.进场).Action(castPara);
            //servant.Cast(context, deskIndex, -1);

            context.EventQueue.AddLast(new ServantInDeskEvent() { EventCard = servant, Parameter = para });
            return servant;
        }
    }
}
