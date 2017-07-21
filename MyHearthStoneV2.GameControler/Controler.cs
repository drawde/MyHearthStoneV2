using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Game;
using MyHearthStoneV2.Model;
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
    public class Controler
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
        internal Controler(string gameID, HS_Users _firstPlayer, HS_Users _secondPlayer, HS_UserCardGroup firstCardGroup, HS_UserCardGroup secondCardGroup)
        {
            GameID = gameID;
            firstPlayer = _firstPlayer;
            secondPlayer = _secondPlayer;
            chessboard = new Chessboard();
            chessboard.FirstUser = firstPlayer;
            chessboard.SecondUser = secondPlayer;
            chessboard.FirstPlayerCards = JsonConvert.DeserializeObject<List<Card>>(firstCardGroup.CardDetail);
        }
        internal Chessboard chessboard;
        internal HS_Users firstPlayer;
        internal HS_Users secondPlayer;

        /// <summary>
        /// 先手玩家费用
        /// </summary>
        internal int FirstPlayerPower = 0;

        /// <summary>
        /// 后手玩家费用
        /// </summary>
        internal int SecondPlayerPower = 0;

        /// <summary>
        /// 当前回合玩家
        /// </summary>
        internal HS_Users currentPlayer;

        /// <summary>
        /// 当前回合剩余秒数
        /// </summary>
        internal int currentRoundRemainingSecond;

        /// <summary>
        /// 进行完的回合数
        /// </summary>
        private int roundCount = 0;

        

        public void GameStart()
        {
        }

        public void RoundEnd(string player)
        {
        }
        public void RoundStart(string player)
        {
        }
    }
}
