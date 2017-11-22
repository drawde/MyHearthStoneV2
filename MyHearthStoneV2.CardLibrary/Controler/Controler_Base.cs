using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.CardLibrary.Context;
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
    public partial class Controler_Base
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
        public int currentRoundRemainingSecond { get; set; }

        /// <summary>
        /// 进行完的回合数
        /// </summary>
        public int roundIndex { get; set; }

        /// <summary>
        /// 当前回合编码
        /// </summary>
        public string currentRoundCode { get; set; }

        /// <summary>
        /// 下个回合编码
        /// </summary>
        public string nextRoundCode { get; set; }

        /// <summary>
        /// 在游戏中的卡牌编码链表
        /// </summary>
        public LinkedList<string> cardInGameCodes = new LinkedList<string>();

        [ControlerMonitor, PlayerActionMonitor]
        public void GameStart(HS_Game game, CUsers _firstPlayer, CUsers _secondPlayer, List<HS_UserCardGroupDetail> firstCardGroup, List<HS_UserCardGroupDetail> secondCardGroup)
        {            
            GameCode = game.GameCode;
            currentRoundCode = game.CurrentRoundCode;
            nextRoundCode = game.NextRoundCode;

            #region 加载玩家卡组
            gameContextOutput = new GameContextOutput();
            UserCards firstUser = new UserCards();
            firstUser.UserCode = _firstPlayer.UserCode;
            firstUser.User = _firstPlayer;
            firstUser.IsActivation = true;
            firstUser.IsFirst = true;
            firstUser.AllCards = new List<Card>();
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
                cardInGameCodes.AddLast(card.CardInGameCode);
                cardInGameIndex++;
            }

            //firstCardGroup.ForEach(delegate (HS_UserCardGroupDetail detail)
            //{
            //    firstUser.AllCards.Add(lstCardLib.First(c => c.CardCode == detail.CardCode));
            //});
            firstUser.StockCards = firstUser.AllCards;

            UserCards secondUser = new UserCards
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
                cardInGameCodes.AddLast(card.CardInGameCode);
                cardInGameIndex++;
            });

            secondUser.StockCards = secondUser.AllCards;

            gameContext = new GameContext
            {
                Players = new List<UserCards>()
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
            firstUser.DeskCards = new List<Card>() { null, null, null, null, null, null, null };
            firstUser.HandCards = new List<Card>();
            //firstUser.StockCards = new List<Card>();

            secondUser.InitCards = lstSecondPickUpCard;
            secondUser.DeskCards = new List<Card>() { null, null, null, null, null, null, null };
            secondUser.HandCards = new List<Card>();
            //secondUser.StockCards = new List<Card>();
            #endregion

            List<Card> lstAll = new List<Card>();
            lstAll.AddRange(firstUser.AllCards);
            lstAll.AddRange(secondUser.AllCards);
            gameContext.AllCard = lstAll;
            //SetCurrentRoundCode();
        }





        public void PickUpACard(string userCode)
        {

        }

        public void RoundStart()
        {
        }
        
    }
}
