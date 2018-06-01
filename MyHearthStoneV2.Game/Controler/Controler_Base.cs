using MyHearthStoneV2.Game.CardLibrary;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.Monitor;
using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Model;
using MyHearthStoneV2.Model.CustomModels;
using MyHearthStoneV2.Redis;
using System.Collections.Generic;
using System.Linq;
using System;

namespace MyHearthStoneV2.Game.Controler
{
    /// <summary>
    /// 游戏控制器
    /// </summary>
    public partial class Controler_Base
    {
        /// <summary>
        /// 游戏环境对象
        /// </summary>
        public GameContext GameContext { get; set; }


        [ControlerMonitor, PlayerActionMonitor, UserActionMonitor]
        public void GameStart(HS_Game game, CUsers firstPlayer, CUsers secondPlayer, List<HS_UserCardGroupDetail> firstCardGroup, List<HS_UserCardGroupDetail> secondCardGroup,string firstUserProfession, string secondUserProfession)
        {
            #region 加载玩家卡组
            //gameContextOutput = new GameContextOutput();
            UserContext firstUser = new UserContext
            {
                UserCode = firstPlayer.UserCode,
                User = firstPlayer,
                IsActivation = true,
                IsFirst = true,
                AllCards = new List<Card>()
            };
            List<Card> lstCardLib;
            using (var redisClient = RedisManager.GetClient())
            {
                lstCardLib = redisClient.Get<List<Card>>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.CardsInstance));
            }
            
            int cardInGameIndex = 0;
            foreach (var cg in firstCardGroup)
            {
                Card libCard = lstCardLib.First(c => c.CardCode == cg.CardCode);
                var card = Activator.CreateInstance(libCard.GetType()) as Card;
                card.CardCode = libCard.CardCode;
                card.CardInGameCode = cardInGameIndex.ToString();
                card.IsFirstPlayerCard = true;
                firstUser.AllCards.Add(card);
                cardInGameIndex++;
            }

            //firstCardGroup.ForEach(delegate (HS_UserCardGroupDetail detail)
            //{
            //    firstUser.AllCards.Add(lstCardLib.First(c => c.CardCode == detail.CardCode));
            //});
            //firstUser.StockCards = firstUser.AllCards;

            UserContext secondUser = new UserContext
            {
                UserCode = secondPlayer.UserCode,
                User = secondPlayer,
                IsActivation = true,
                IsFirst = false,
                AllCards = new List<Card>()
            };
            secondCardGroup.ForEach(delegate (HS_UserCardGroupDetail detail)
            {
                Card libCard = lstCardLib.First(c => c.CardCode == detail.CardCode);
                var card = Activator.CreateInstance(libCard.GetType()) as Card;
                card.CardCode = libCard.CardCode;
                card.CardInGameCode = cardInGameIndex.ToString();
                card.IsFirstPlayerCard = false;
                secondUser.AllCards.Add(card);
                cardInGameIndex++;
            });

            //secondUser.StockCards = secondUser.AllCards;
            
            
            GameContext = new GameContext
            {
                Players = new List<UserContext>(),
                DeskCards = null,
                GameCode = game.GameCode,
                CurrentTurnCode = game.CurrentTurnCode,
                NextTurnCode = game.NextTurnCode,
                GameStatus = GameStatus.进行中
            };
            GameContext.Players.Add(firstUser);
            GameContext.Players.Add(secondUser);
            #endregion

            #region 初始化开场选牌
            int firstPickUpCount = 4;
            List<int> lstRndIndex = RandomUtil.CreateRandomInt(0, GameContext.Players.First(c => c.IsFirst).AllCards.Count - 1, firstPickUpCount);
            for (int i = 0; i < lstRndIndex.Count; i++)
            {
                if (i < lstRndIndex.Count - 1)
                {
                    //lstFirstPickUpCard.Add(GameContext.Players.First(c => c.IsFirst).AllCards[lstRndIndex[i]]);
                    GameContext.Players.First(c => c.IsFirst).AllCards[lstRndIndex[i]].CardLocation = CardLocation.InitCard;
                }
                //lstSecondPickUpCard.Add(GameContext.Players.First(c => c.IsFirst == false).AllCards[lstRndIndex[i]]);
                GameContext.Players.First(c => c.IsFirst == false).AllCards[lstRndIndex[i]].CardLocation = CardLocation.InitCard;
            }
            
            BaseHero firstHero = null, secondHero = null;
            switch (firstUserProfession)
            {
                case "Druid": firstHero = new Druid(); break;
                case "Hunter": firstHero = new Hunter(); break;
                case "Mage": firstHero = new Mage(); break;
                case "Paladin": firstHero = new Paladin(); break;
                case "Priest": firstHero = new Priest(); break;
                case "Rogue": firstHero = new Rogue(); break;
                case "Shaman": firstHero = new Shaman(); break;
                case "Warlock": firstHero = new Warlock(); break;
                case "Warrior": firstHero = new Warrior(); break;
            }
            switch (secondUserProfession)
            {
                case "Druid": secondHero = new Druid(); break;
                case "Hunter": secondHero = new Hunter(); break;
                case "Mage": secondHero = new Mage(); break;
                case "Paladin": secondHero = new Paladin(); break;
                case "Priest": secondHero = new Priest(); break;
                case "Rogue": secondHero = new Rogue(); break;
                case "Shaman": secondHero = new Shaman(); break;
                case "Warlock": secondHero = new Warlock(); break;
                case "Warrior": secondHero = new Warrior(); break;
            }

            //firstUser.HandCards = new List<Card>();
            //firstUser.InitCards = lstFirstPickUpCard;

            //secondUser.HandCards = new List<Card>();
            //secondUser.InitCards = lstSecondPickUpCard;

            cardInGameIndex++;
            firstHero.CardCode = lstCardLib.First(c => c.GetType().Name == firstHero.GetType().Name).CardCode;
            firstHero.CardInGameCode = cardInGameIndex.ToString();
            firstHero.DeskIndex = 0;
            firstHero.IsFirstPlayerCard = true;
            //firstUser.AllCards.Add(firstHero);

            cardInGameIndex++;
            secondHero.CardCode = lstCardLib.First(c => c.GetType().Name == secondHero.GetType().Name).CardCode;
            secondHero.CardInGameCode = cardInGameIndex.ToString();
            secondHero.DeskIndex = 8;
            secondHero.IsFirstPlayerCard = false;
            //secondUser.AllCards.Add(secondHero);

            GameContext.DeskCards = new DeskBoard() { firstHero, null, null, null, null, null, null, null, secondHero, null, null, null, null, null, null, null };
            #endregion

            //List<Card> lstAll = new List<Card>();
            //lstAll.AddRange(firstUser.AllCards);
            //lstAll.AddRange(secondUser.AllCards);
            //GameContext.AllCard = lstAll;
        }       
    }
}
