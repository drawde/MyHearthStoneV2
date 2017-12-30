using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.CardLibrary.Context;
using MyHearthStoneV2.CardLibrary.Hero;
using MyHearthStoneV2.CardLibrary.Monitor;
using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Model;
using MyHearthStoneV2.Model.CustomModels;
using MyHearthStoneV2.Redis;
using System.Collections.Generic;
using System.Linq;


namespace MyHearthStoneV2.CardLibrary.Controler
{
    /// <summary>
    /// 游戏控制器
    /// </summary>
    internal partial class Controler_Base
    {
        /// <summary>
        /// 游戏ID
        /// </summary>
        public string GameCode { get; set; }

        public GameContext gameContext { get; set; }

        /// <summary>
        /// 游戏输出模型
        /// </summary>
        public GameContextOutput gameContextOutput { get; set; }

        /// <summary>
        /// 当前回合剩余秒数
        /// </summary>
        public int currentTurnRemainingSecond { get; set; }

        /// <summary>
        /// 进行完的回合数
        /// </summary>
        public int TurnIndex { get; set; }

        /// <summary>
        /// 当前回合编码
        /// </summary>
        public string currentTurnCode { get; set; }

        /// <summary>
        /// 下个回合编码
        /// </summary>
        public string nextTurnCode { get; set; }
        
        [ControlerMonitor, PlayerActionMonitor]
        internal void GameStart(HS_Game game, CUsers _firstPlayer, CUsers _secondPlayer, List<HS_UserCardGroupDetail> firstCardGroup, List<HS_UserCardGroupDetail> secondCardGroup,string firstUserProfession, string secondUserProfession)
        {            
            GameCode = game.GameCode;
            currentTurnCode = game.CurrentTurnCode;
            nextTurnCode = game.NextTurnCode;

            #region 加载玩家卡组
            gameContextOutput = new GameContextOutput();
            UserContext firstUser = new UserContext
            {
                UserCode = _firstPlayer.UserCode,
                User = _firstPlayer,
                IsActivation = true,
                IsFirst = true,
                AllCards = new List<Card>()
            };
            List<Card> lstCardLib = new List<Card>();
            using (var redisClient = RedisManager.GetClient())
            {
                lstCardLib = redisClient.Get<List<Card>>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.CardsInstance));
            }

            //初始化游戏中的卡牌编码链表
            int cardInGameIndex = 0;
            foreach (var cg in firstCardGroup)
            {
                var card = lstCardLib.First(c => c.CardCode == cg.CardCode);
                card.CardInGameCode = cardInGameIndex.ToString();
                firstUser.AllCards.Add(card);
                cardInGameIndex++;
            }

            //firstCardGroup.ForEach(delegate (HS_UserCardGroupDetail detail)
            //{
            //    firstUser.AllCards.Add(lstCardLib.First(c => c.CardCode == detail.CardCode));
            //});
            firstUser.StockCards = firstUser.AllCards;

            UserContext secondUser = new UserContext
            {
                UserCode = _secondPlayer.UserCode,
                User = _secondPlayer,
                IsActivation = true,
                IsFirst = false,
                AllCards = new List<Card>()
            };
            secondCardGroup.ForEach(delegate (HS_UserCardGroupDetail detail)
            {
                var card = lstCardLib.First(c => c.CardCode == detail.CardCode);
                card.CardInGameCode = cardInGameIndex.ToString();
                secondUser.AllCards.Add(card);
                cardInGameIndex++;
            });

            secondUser.StockCards = secondUser.AllCards;
            

            var lstAllDeskCards = new List<BaseBiology>();
            lstAllDeskCards.AddRange(firstUser.DeskCards);
            lstAllDeskCards.AddRange(secondUser.DeskCards);
            gameContext = new GameContext
            {
                Players = new List<UserContext>(),
                DeskCards = lstAllDeskCards,                
            };
            gameContext.Players.Add(firstUser);
            gameContext.Players.Add(secondUser);
            #endregion

            #region 初始化开场选牌
            int firstPickUpCount = 4;
            List<Card> lstFirstPickUpCard = new List<Card>();
            List<Card> lstSecondPickUpCard = new List<Card>();

            List<int> lstRndIndex = RandomUtil.CreateRandomInt(0, gameContext.Players.First(c => c.IsFirst).AllCards.Count - 1, firstPickUpCount);
            for (int i = 0; i < lstRndIndex.Count; i++)
            {
                if (i < lstRndIndex.Count - 1)
                {
                    lstFirstPickUpCard.Add(gameContext.Players.First(c => c.IsFirst).AllCards[lstRndIndex[i]]);
                }
                lstSecondPickUpCard.Add(gameContext.Players.First(c => c.IsFirst == false).AllCards[lstRndIndex[i]]);
            }
            firstUser.InitCards = lstFirstPickUpCard;
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
            firstUser.Hero = firstHero;
            firstUser.DeskCards = new List<BaseBiology>() { firstHero, null, null, null, null, null, null, null };
            firstUser.HandCards = new List<Card>();

            secondUser.Hero = secondHero;
            secondUser.InitCards = lstSecondPickUpCard;
            secondUser.DeskCards = new List<BaseBiology>() { secondHero, null, null, null, null, null, null, null };
            secondUser.HandCards = new List<Card>();
            #endregion

            List<Card> lstAll = new List<Card>();
            lstAll.AddRange(firstUser.AllCards);
            lstAll.AddRange(secondUser.AllCards);
            gameContext.AllCard = lstAll;
        }       
    }
}
