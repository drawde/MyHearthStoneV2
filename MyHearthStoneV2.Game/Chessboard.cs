using MyHearthStoneV2.CardLibrary.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.Model;
namespace MyHearthStoneV2.Game
{
    /// <summary>
    /// 当前棋盘中的卡牌
    /// </summary>
    public class Chessboard
    {
        //public Chessboard(HS_Users firstPlayer, HS_Users secondPlayer, List<Card> fristCardGroup, List<Card> secondCardGroup)
        //{
        //    FirstUser = firstPlayer;
        //    SecondUser = secondPlayer;
        //    FirstPlayerCards = fristCardGroup;

        //}
        /// <summary>
        /// 先手玩家
        /// </summary>
        public HS_Users FirstUser;

        /// <summary>
        /// 后手玩家
        /// </summary>
        public HS_Users SecondUser;

        /// <summary>
        /// 本局中所有的牌
        /// </summary>
        public List<Card> AllCard;


        /// <summary>
        /// 先手玩家的所有牌
        /// </summary>
        public List<Card> FirstPlayerCards;

        /// <summary>
        /// 后手玩家的所有牌
        /// </summary>
        public List<Card> SecondPlayerCards;


        /// <summary>
        /// 先手玩家的手牌
        /// </summary>
        public List<Card> FirstPlayerHandCards;

        /// <summary>
        /// 后手玩家的手牌
        /// </summary>
        public List<Card> SecondPlayerHandCards;

        /// <summary>
        /// 先手玩家牌库的牌
        /// </summary>
        public List<Card> FirstPlayerStockCards;

        /// <summary>
        /// 后手玩家牌库的牌
        /// </summary>
        public List<Card> SecondPlayerStockCards;

        /// <summary>
        /// 先手玩家场上的牌
        /// </summary>
        public List<Card> FirstPlayerDeskCards;

        /// <summary>
        /// 后手玩家场上的牌
        /// </summary>
        public List<Card> SecondPlayerDeskCards;
    }
}
