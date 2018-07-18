using BattleForAzeroth.Game.CardLibrary;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.CardLibrary.Hero;

using BattleForAzeroth.Game.Util;
using System.Collections.Generic;
using System.Linq;
using System;
using BattleForAzeroth.Game.Model;
using BattleForAzeroth.Game.Cache;

namespace BattleForAzeroth.Game.Controler
{
    /// <summary>
    /// 游戏控制器
    /// </summary>
    public partial class Controler_Base
    {
        private IGameCache _gameCache;
        public Controler_Base(IGameCache gameCache)
        {
            _gameCache = gameCache;
        }
        /// <summary>
        /// 游戏环境对象
        /// </summary>
        public GameContext GameContext { get; set; }


        public void GameStart(GameModel game, PlayerModel firstPlayer, PlayerModel secondPlayer, List<UserCardGroupDetailModel> firstCardGroup, List<UserCardGroupDetailModel> secondCardGroup, string firstUserProfession, string secondUserProfession)
        {
            #region 加载玩家卡组
            UserContext firstUser = new UserContext
            {
                UserCode = firstPlayer.UserCode,
                Player = firstPlayer,
                IsActivation = true,
                IsFirst = true,
                AllCards = new List<Card>()
            };
            List<Card> lstCardLib = _gameCache.GetAllCard();

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

            UserContext secondUser = new UserContext
            {
                UserCode = secondPlayer.UserCode,
                Player = secondPlayer,
                IsActivation = true,
                IsFirst = false,
                AllCards = new List<Card>()
            };
            secondCardGroup.ForEach(delegate (UserCardGroupDetailModel detail)
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
                GameStatus = GameStatus.进行中,
                GameCache = _gameCache
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

            cardInGameIndex++;
            firstHero.CardCode = lstCardLib.First(c => c.GetType().Name == firstHero.GetType().Name).CardCode;
            firstHero.CardInGameCode = cardInGameIndex.ToString();
            firstHero.DeskIndex = 0;
            firstHero.IsFirstPlayerCard = true;

            cardInGameIndex++;
            secondHero.CardCode = lstCardLib.First(c => c.GetType().Name == secondHero.GetType().Name).CardCode;
            secondHero.CardInGameCode = cardInGameIndex.ToString();
            secondHero.DeskIndex = 8;
            secondHero.IsFirstPlayerCard = false;

            GameContext.DeskCards = new DeskBoard() { firstHero, null, null, null, null, null, null, null, secondHero, null, null, null, null, null, null, null };
            #endregion

            Settlement();
        }

        private void Settlement()
        {
            GameContext.AddEndOfPlayerActionEvent();
            GameContext.EventQueueSettlement();
            GameContext.QueueSettlement();
        }
    }
}
