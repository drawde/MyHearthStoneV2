using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Player;
using System.Collections.Generic;
using System.Linq;

namespace MyHearthStoneV2.Game.CardLibrary.CardAction.Player
{
    /// <summary>
    /// 将一张牌返回到手牌（闷棍）
    /// </summary>
    internal class ReturnCardToHandAction : Action.IGameAction
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            ReturnCardToHandParameter returnPara = actionParameter as ReturnCardToHandParameter;
            int returnCount = returnPara.ReturnCount;
            UserContext uc = returnPara.UserContext;
            GameContext gameContext = actionParameter.GameContext;
            for (int i = 1; i <= returnCount; i++)
            {
                if (uc.HandCards.Count < 10)
                {
                    //如果手牌没满则放入手牌中
                    uc.HandCards.Add(returnPara.MainCard);
                    returnPara.MainCard.CardLocation = CardLocation.手牌;
                    gameContext.DeskCards[gameContext.DeskCards.FindIndex(c => c != null && c.CardInGameCode == returnPara.MainCard.CardInGameCode)] = null;
                }
                else
                {
                    //否则标记这张牌为死亡
                    BaseBiology biology = returnPara.MainCard as BaseBiology;
                    biology.Deathing = true;                    
                }
            }
            return null;
        }
    }
}
