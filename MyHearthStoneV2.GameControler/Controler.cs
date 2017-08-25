using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.Common.Enum;
using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Game;
using MyHearthStoneV2.Model;
using MyHearthStoneV2.Redis;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.GameControler
{
    /// <summary>
    /// 游戏控制器
    /// </summary>
    public partial class Controler
    {
        /// <summary>
        /// 游戏ID
        /// </summary>
        public string GameID { get; set; }

        /// <summary>
        /// 初始化控制器
        /// </summary>
        /// <param name="gameID"></param>
        /// <param name="_firstPlayer"></param>
        /// <param name="_secondPlayer"></param>
        /// <param name="firstCardGroup"></param>
        /// <param name="secondCardGroup"></param>
        public Controler(string gameID, HS_Users _firstPlayer, HS_Users _secondPlayer, List<HS_UserCardGroupDetail> firstCardGroup, List<HS_UserCardGroupDetail> secondCardGroup)
        {
            #region 加载玩家卡组
            GameID = gameID;
            

            UserCards firstUser = new UserCards();
            firstUser.User = _firstPlayer;
            firstUser.IsActivation = true;
            firstUser.IsFirst = true;
            firstUser.AllCards = new List<Card>();
            List<Card> lstCardLib = new List<Card>();
            using (var redisClient = RedisManager.GetClient())
            {
                lstCardLib = redisClient.Get<List<Card>>(RedisKeyEnum.CardsInstance.ToString());
            }
            firstCardGroup.ForEach(delegate (HS_UserCardGroupDetail detail)
            {
                firstUser.AllCards.Add(lstCardLib.First(c => c.CardCode == detail.CardCode));
            });
            firstUser.StockCards = firstUser.AllCards;

            UserCards secondUser = new UserCards();
            secondUser.User = _secondPlayer;
            secondUser.IsActivation = true;
            secondUser.IsFirst = false;
            secondUser.AllCards = new List<Card>();
            secondCardGroup.ForEach(delegate (HS_UserCardGroupDetail detail)
            {
                secondUser.AllCards.Add(lstCardLib.First(c => c.CardCode == detail.CardCode));
            });

            secondUser.StockCards = secondUser.AllCards;

            chessboard = new Chessboard();
            chessboard.Players = new List<UserCards>();
            chessboard.Players.Add(firstUser);
            chessboard.Players.Add(secondUser);
            #endregion

            #region 初始化开场选牌
            int firstPickUpCount = 4;
            List<Card> lstFirstPickUpCard = new List<Card>();
            List<Card> lstSecondPickUpCard = new List<Card>();

            List<int> lstRndIndex = RandomUtil.CreateRandomInt(0, chessboard.Players.First(c => c.IsFirst).AllCards.Count - 1, firstPickUpCount);
            for (int i = 0; i < lstRndIndex.Count; i++)
            {
                if (i < lstRndIndex.Count - 1)
                {
                    lstFirstPickUpCard.Add(chessboard.Players.First(c => c.IsFirst).AllCards[lstRndIndex[i]]);
                }
                lstSecondPickUpCard.Add(chessboard.Players.First(c => c.IsFirst == false).AllCards[lstRndIndex[i]]);
            }
            firstUser.InitCards = lstFirstPickUpCard;
            firstUser.DeskCards = new List<Card>();
            firstUser.HandCards = new List<Card>();
            firstUser.StockCards = new List<Card>();
            
            secondUser.InitCards = lstSecondPickUpCard;
            secondUser.DeskCards = new List<Card>();
            secondUser.HandCards = new List<Card>();
            secondUser.StockCards = new List<Card>();
            #endregion

            List<Card> lstAll = new List<Card>();
            lstAll.AddRange(firstUser.AllCards);
            lstAll.AddRange(secondUser.AllCards);
            chessboard.AllCard = lstAll;
            SetCurrentRoundCode();
        }

        //System.Timers.Timer

        public Chessboard chessboard { get; set; }

        //internal HS_Users firstPlayer;
        //internal HS_Users secondPlayer;


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

        public void GameStart()
        {
        }





        public void PickUpACard(string userCode)
        {

        }

        public void RoundStart()
        {
        }
    }
}
