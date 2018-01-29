using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Player;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Controler.Proxy;
using MyHearthStoneV2.Game.Parameter.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game
{
    /// <summary>
    /// 后门程序
    /// </summary>
    public class GameTester
    {
        public static void DrawCard(GameContext gameContext, int drawCount)
        {
            DrawCardActionParameter para = new DrawCardActionParameter()
            {
                DrawCount = drawCount,
                GameContext = gameContext,
                UserContext = gameContext.GetActivationUserContext()
            };
            IGameAction drawCardAction = new DrawCardAction();
            drawCardAction.Action(para);
        }

        public static void CastServant(GameContext gameContext, string cardInGameCode)
        {
            int deskIndex = -1;
            int start = 1, end = 8;
            BaseServant servant = null;
            if (gameContext.Players[0].AllCards.Any(c => c.CardInGameCode == cardInGameCode))
            {
                if (gameContext.Players[0].IsFirst == false)
                {
                    start = 9;
                    end = 16;
                }
                for (int i = start; i < end; i++)
                {
                    if (gameContext.DeskCards[i] == null)
                    {
                        deskIndex = i;
                        break;
                    }
                }

                if (gameContext.Players[0].HandCards.Any(c => c.CardInGameCode == cardInGameCode))
                {
                    servant = gameContext.Players[0].HandCards.First(c => c.CardInGameCode == cardInGameCode) as BaseServant;
                    gameContext.Players[0].HandCards.RemoveAt(gameContext.Players[0].HandCards.FindIndex(c => c.CardInGameCode == cardInGameCode));
                }
                else if (gameContext.Players[0].StockCards.Any(c => c.CardInGameCode == cardInGameCode))
                {
                    servant = gameContext.Players[0].StockCards.First(c => c.CardInGameCode == cardInGameCode) as BaseServant;
                    gameContext.Players[0].StockCards.RemoveAt(gameContext.Players[0].StockCards.FindIndex(c => c.CardInGameCode == cardInGameCode));
                }

            }
            else
            {
                if (gameContext.Players[1].IsFirst == false)
                {
                    start = 9;
                    end = 16;
                }
                for (int i = start; i < end; i++)
                {
                    if (gameContext.DeskCards[i] == null)
                    {
                        deskIndex = i;
                        break;
                    }
                }

                if (gameContext.Players[1].HandCards.Any(c => c.CardInGameCode == cardInGameCode))
                {
                    servant = gameContext.Players[1].HandCards.First(c => c.CardInGameCode == cardInGameCode) as BaseServant;
                    gameContext.Players[1].HandCards.RemoveAt(gameContext.Players[1].HandCards.FindIndex(c => c.CardInGameCode == cardInGameCode));
                }
                else if (gameContext.Players[1].StockCards.Any(c => c.CardInGameCode == cardInGameCode))
                {
                    servant = gameContext.Players[1].StockCards.First(c => c.CardInGameCode == cardInGameCode) as BaseServant;
                    gameContext.Players[1].StockCards.RemoveAt(gameContext.Players[1].StockCards.FindIndex(c => c.CardInGameCode == cardInGameCode));
                }
            }
            gameContext.CastCardCount++;
            servant.CastIndex = gameContext.CastCardCount;
            servant.CanAttack = true;
            servant.RemainAttackTimes = 1;
            servant.DeskIndex = deskIndex;
            gameContext.DeskCards[deskIndex] = servant;            
        }

        public static void TurnEnd(GameContext gameContext)
        {
            string current = gameContext.Players.First(c => c.IsActivation == true).UserCode.ToString();
            string enemy = gameContext.Players.First(c => c.IsActivation == false).UserCode.ToString();
            Controller_Base_Proxy.TurnEnd(gameContext.GameCode, current);
            Controller_Base_Proxy.TurnStart(gameContext.GameCode, enemy);
        }
    }
}
