using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Controler;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Equip;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Player;
using MyHearthStoneV2.Game.CardLibrary.Equip;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Controler.Proxy;
using MyHearthStoneV2.Game.Parameter.Controler;
using MyHearthStoneV2.Game.Parameter.Equip;
using MyHearthStoneV2.Game.Parameter.Player;
using MyHearthStoneV2.Redis;
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
        public static void DrawCard(string gameCode, int drawCount)
        {
            GameContext gameContext = null;
            using (var redisClient = RedisManager.GetClient())
            {
                gameContext = redisClient.Get<GameContext>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.GameContext, gameCode));
            }
            DrawCardActionParameter para = new DrawCardActionParameter()
            {
                DrawCount = drawCount,
                GameContext = gameContext,
                UserContext = gameContext.GetActivationUserContext()
            };
            Action.IGameAction drawCardAction = new DrawCardAction();
            drawCardAction.Action(para);

            using (var redisClient = RedisManager.GetClient())
            {
                redisClient.Set(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.GameContext, gameContext.GameCode), gameContext);
            }
        }

        public static void CastServant(string gameCode, string cardInGameCode)
        {
            int deskIndex = -1;
            int start = 1, end = 8;
            BaseServant servant = null;
            GameContext gameContext = null;
            using (var redisClient = RedisManager.GetClient())
            {
                gameContext = redisClient.Get<GameContext>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.GameContext, gameCode));
            }
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

            using (var redisClient = RedisManager.GetClient())
            {
                redisClient.Set(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.GameContext, gameContext.GameCode), gameContext);
            }
        }

        public static void TurnEnd(string gameCode)
        {
            GameContext gameContext = null;
            using (var redisClient = RedisManager.GetClient())
            {
                gameContext = redisClient.Get<GameContext>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.GameContext, gameCode));
            }
            string current = gameContext.Players.First(c => c.IsActivation == true).UserCode.ToString();
            string enemy = gameContext.Players.First(c => c.IsActivation == false).UserCode.ToString();
            Controller_Base_Proxy.TurnEnd(gameContext.GameCode, current);
            Controller_Base_Proxy.TurnStart(gameContext.GameCode, enemy);
        }

        public static void GodDraw<T>(string gameCode) where T : Card
        {
            GameContext gameContext = null;
            using (var redisClient = RedisManager.GetClient())
            {
                gameContext = redisClient.Get<GameContext>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.GameContext, gameCode));
            }
            var current = gameContext.Players.First(c => c.IsActivation == true);
            if (current.AllCards.Any(c => c.GetType() == typeof(T)))
            {
                var card = current.StockCards.First(c => c.GetType() == typeof(T));
                current.StockCards.RemoveAt(current.StockCards.FindIndex(c => c.GetType() == typeof(T)));
                current.HandCards.Add(card);

                using (var redisClient = RedisManager.GetClient())
                {
                    redisClient.Set(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.GameContext, gameContext.GameCode), gameContext);
                }
            }
        }

        public static Card CreateCard<T>(string gameCode) where T : Card
        {
            GameContext gameContext = null;
            using (var redisClient = RedisManager.GetClient())
            {
                gameContext = redisClient.Get<GameContext>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.GameContext, gameCode));
                UserContext user = gameContext.GetActivationUserContext();
                var card = new CreateNewCardInControllerAction<T>().Action(new ControlerActionParameter() { GameContext = gameContext, UserContext = user }) as T;
                user.HandCards.Add(card);
                gameContext.AllCard.Add(card);
                redisClient.Set(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.GameContext, gameContext.GameCode), gameContext);
                return card;
            }            
        }


        public static void LoadEquip<T>(string gameCode) where T : BaseEquip
        {
            GameContext gameContext = null;
            using (var redisClient = RedisManager.GetClient())
            {
                gameContext = redisClient.Get<GameContext>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.GameContext, gameCode));
            }
            var current = gameContext.Players.First(c => c.IsActivation == true);
            var enemy = gameContext.Players.First(c => c.IsActivation == false);
            bool isfirst = true;

            //T equip = Activator.CreateInstance<T>();
            ControlerActionParameter ctlPara = null;


            if (current.AllCards.Any(c => c.GetType() == typeof(T)))
            {
                isfirst = current.IsFirst;
                ctlPara = new ControlerActionParameter()
                {
                    GameContext = gameContext,
                    UserContext = current
                };
            }
            else
            {
                isfirst = enemy.IsFirst;
                ctlPara = new ControlerActionParameter()
                {
                    GameContext = gameContext,
                    UserContext = enemy
                };
            }
            
            BaseEquip equip = new CreateNewCardInControllerAction<T>().Action(ctlPara) as BaseEquip;
            EquipActionParameter equipPara = new EquipActionParameter()
            {
                GameContext = gameContext,
                Equip = equip,
                Hero = gameContext.DeskCards.GetHeroByIsFirst(isfirst),
            };
            new LoadAction().Action(equipPara);

            using (var redisClient = RedisManager.GetClient())
            {
                redisClient.Set(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.GameContext, gameContext.GameCode), gameContext);
            }
        }

        public static void QueueSettlement(string gameCode)
        {
            GameContext gameContext = null;
            using (var redisClient = RedisManager.GetClient())
            {
                gameContext = redisClient.Get<GameContext>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.GameContext, gameCode));
                gameContext.QueueSettlement();
                redisClient.Set(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.GameContext, gameContext.GameCode), gameContext);
            }            
        }

        public static void FullPower(string gameCode)
        {
            GameContext gameContext = null;
            using (var redisClient = RedisManager.GetClient())
            {
                gameContext = redisClient.Get<GameContext>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.GameContext, gameCode));
                gameContext.GetActivationUserContext().Power = 10;
                redisClient.Set(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.GameContext, gameContext.GameCode), gameContext);
            }
        }
    }
}
